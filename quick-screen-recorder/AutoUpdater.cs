using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace quick_screen_recorder
{
    public class ReleaseUpdateInfo
    {
        public string CurrentVersion { get; set; }
        public string LatestVersion { get; set; }
        public string TagName { get; set; }
        public string ReleaseTitle { get; set; }
        public string PublishedAt { get; set; }
        public string HtmlUrl { get; set; }
        public string DownloadUrl { get; set; }
        public string AssetName { get; set; }
        public long AssetSize { get; set; }
        public string ChangelogText { get; set; }
        public bool IsUpdateAvailable { get; set; }
        public bool ApiReachable { get; set; }
    }

    public static class AutoUpdater
    {
        public const string GithubOwner = "xboyrex";
        public const string GithubRepo = "Lite-Screen-Recorder";
        public const string AppTitle = "Lite Screen Recorder";
        public const string BrandAuthor = "ㅤᏞᴀᴢʏㅤᎷꫝʏᴀɴк まやんく (@xboyrex)";

        public static string GetCurrentVersionString()
        {
            try
            {
                Version v = Assembly.GetExecutingAssembly().GetName().Version;
                return string.Format("{0}.{1}.{2}", v.Major, v.Minor, v.Build);
            }
            catch
            {
                return "2.0.0";
            }
        }

        public static string GetBuiltInChangelog()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("==================================================================");
            sb.AppendLine("  LITE SCREEN RECORDER — OFFICIAL CHANGELOG & RELEASE HISTORY");
            sb.AppendLine("  Developed & Maintained by Mayank Droid (@xboyrex)");
            sb.AppendLine("==================================================================");
            sb.AppendLine();
            sb.AppendLine("[v2.0.0] — Pro Edition (Mayank Droid / @xboyrex Release)");
            sb.AppendLine("  • Complete rebranding & UI upgrade for Lite Screen Recorder by @xboyrex.");
            sb.AppendLine("  • Instant switch from Home window to Recorder Menu tab on clicking REC.");
            sb.AppendLine("  • Added selectable Frame Rate (10, 15, 24, 30, 60 FPS) & Ultra 90% Quality.");
            sb.AppendLine("  • Added Pause / Resume Recording (Alt+P) with audio-video sync.");
            sb.AppendLine("  • Added Mouse Click Effect Highlights (Left-Click Red / Right-Click Cyan).");
            sb.AppendLine("  • Added Live Brand Watermark & Real-time Timestamp Video Overlay.");
            sb.AppendLine("  • Added Instant Full-Res PNG Screenshot Capture (Alt+S) anytime.");
            sb.AppendLine("  • Added Recording Countdown Timer (3s, 5s, 10s) & Auto-Stop Duration Timer.");
            sb.AppendLine("  • Added System Tray Minimize mode during active screen recording.");
            sb.AppendLine("  • Added Auto-Updater with live GitHub Releases Changelog & Self-Install.");
            sb.AppendLine("  • Fixed multi-monitor and custom-area cursor offset bug.");
            sb.AppendLine("  • Added circular SVG & multi-DPI desktop icon + Setup Installer builder.");
            sb.AppendLine();
            sb.AppendLine("[v1.2.1] — Base Engine Improvements");
            sb.AppendLine("  • Improved Motion JPEG encoding stability and WASAPI loopback capture.");
            sb.AppendLine("  • Added dark/light theme synchronization.");
            sb.AppendLine();
            sb.AppendLine("[v1.1.0] — Initial Desktop Release");
            sb.AppendLine("  • Core AVI screen capture, custom area selection, and WAV audio output.");
            return sb.ToString();
        }

        public static ReleaseUpdateInfo FetchLatestReleaseInfo()
        {
            string curVer = GetCurrentVersionString();
            ReleaseUpdateInfo info = new ReleaseUpdateInfo()
            {
                CurrentVersion = curVer,
                LatestVersion = curVer,
                TagName = "v" + curVer,
                ReleaseTitle = "Lite Screen Recorder v" + curVer + " (Pro Edition)",
                PublishedAt = DateTime.Now.ToString("yyyy-MM-dd"),
                HtmlUrl = string.Format("https://github.com/{0}/{1}/releases", GithubOwner, GithubRepo),
                DownloadUrl = "",
                AssetName = "",
                AssetSize = 0,
                ChangelogText = GetBuiltInChangelog(),
                IsUpdateAvailable = false,
                ApiReachable = false
            };

            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072 | (SecurityProtocolType)768 | SecurityProtocolType.Tls;

                string apiUrl = string.Format("https://api.github.com/repos/{0}/{1}/releases", GithubOwner, GithubRepo);
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(apiUrl);
                req.Method = "GET";
                req.UserAgent = "Lite-Screen-Recorder-Updater-xboyrex/2.0.0";
                req.Accept = "application/vnd.github.v3+json";
                req.Timeout = 10000;

                using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
                using (StreamReader reader = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
                {
                    string json = reader.ReadToEnd();
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    object parsed = serializer.DeserializeObject(json);
                    object[] releases = parsed as object[];

                    if (releases != null && releases.Length > 0)
                    {
                        info.ApiReachable = true;
                        StringBuilder allNotes = new StringBuilder();
                        allNotes.AppendLine("==================================================================");
                        allNotes.AppendLine("  LIVE GITHUB RELEASES CHANGELOG (" + GithubOwner + "/" + GithubRepo + ")");
                        allNotes.AppendLine("==================================================================");
                        allNotes.AppendLine();

                        for (int i = 0; i < releases.Length; i++)
                        {
                            Dictionary<string, object> rel = releases[i] as Dictionary<string, object>;
                            if (rel == null) continue;

                            string tag = GetDictString(rel, "tag_name", "v2.0.0");
                            string name = GetDictString(rel, "name", tag);
                            string pub = GetDictString(rel, "published_at", "");
                            if (pub.Length >= 10) pub = pub.Substring(0, 10);
                            string body = GetDictString(rel, "body", "No release notes provided.");
                            string htmlUrl = GetDictString(rel, "html_url", info.HtmlUrl);

                            allNotes.AppendLine(string.Format(">>> [{0}] {1}  (Released: {2})", tag, name, pub));
                            allNotes.AppendLine(body.Replace("\r\n", "\n").Replace("\n", Environment.NewLine));
                            allNotes.AppendLine(new string('-', 66));
                            allNotes.AppendLine();

                            if (i == 0)
                            {
                                info.TagName = tag;
                                info.LatestVersion = CleanVersionString(tag);
                                info.ReleaseTitle = name;
                                info.PublishedAt = pub;
                                info.HtmlUrl = htmlUrl;
                                info.IsUpdateAvailable = IsNewerVersion(curVer, info.LatestVersion);

                                object[] assets = rel.ContainsKey("assets") ? (rel["assets"] as object[]) : null;
                                if (assets != null && assets.Length > 0)
                                {
                                    Dictionary<string, object> chosenAsset = null;
                                    for (int a = 0; a < assets.Length; a++)
                                    {
                                        Dictionary<string, object> assetObj = assets[a] as Dictionary<string, object>;
                                        if (assetObj == null) continue;
                                        string aName = GetDictString(assetObj, "name", "").ToLowerInvariant();
                                        if (aName.EndsWith(".zip") || aName.EndsWith(".exe") || aName.EndsWith(".msi"))
                                        {
                                            chosenAsset = assetObj;
                                            break;
                                        }
                                    }
                                    if (chosenAsset == null)
                                    {
                                        chosenAsset = assets[0] as Dictionary<string, object>;
                                    }
                                    if (chosenAsset != null)
                                    {
                                        info.AssetName = GetDictString(chosenAsset, "name", "Lite-Screen-Recorder-Release.zip");
                                        info.DownloadUrl = GetDictString(chosenAsset, "browser_download_url", "");
                                        long sz = 0;
                                        long.TryParse(GetDictString(chosenAsset, "size", "0"), out sz);
                                        info.AssetSize = sz;
                                    }
                                }

                                if (string.IsNullOrEmpty(info.DownloadUrl))
                                {
                                    string zipball = GetDictString(rel, "zipball_url", "");
                                    if (!string.IsNullOrEmpty(zipball))
                                    {
                                        info.AssetName = "Lite-Screen-Recorder-" + tag + ".zip";
                                        info.DownloadUrl = zipball;
                                    }
                                }
                            }
                        }

                        allNotes.AppendLine();
                        allNotes.AppendLine(GetBuiltInChangelog());
                        info.ChangelogText = allNotes.ToString();
                    }
                }
            }
            catch
            {
            }

            return info;
        }

        private static string GetDictString(Dictionary<string, object> dict, string key, string fallback)
        {
            if (dict != null && dict.ContainsKey(key) && dict[key] != null)
            {
                return dict[key].ToString();
            }
            return fallback;
        }

        public static string CleanVersionString(string tag)
        {
            if (string.IsNullOrEmpty(tag)) return "2.0.0";
            string cleaned = tag.Trim();
            while (cleaned.Length > 0 && !char.IsDigit(cleaned[0]))
            {
                cleaned = cleaned.Substring(1);
            }
            int dashIdx = cleaned.IndexOf('-');
            if (dashIdx > 0)
            {
                cleaned = cleaned.Substring(0, dashIdx);
            }
            return string.IsNullOrEmpty(cleaned) ? "2.0.0" : cleaned;
        }

        public static bool IsNewerVersion(string currentVer, string latestVer)
        {
            try
            {
                Version vCur = new Version(NormalizeThreePartVersion(currentVer));
                Version vLat = new Version(NormalizeThreePartVersion(latestVer));
                return vLat > vCur;
            }
            catch
            {
                return !string.Equals(currentVer, latestVer, StringComparison.OrdinalIgnoreCase);
            }
        }

        private static string NormalizeThreePartVersion(string v)
        {
            string c = CleanVersionString(v);
            string[] parts = c.Split('.');
            if (parts.Length == 1) return parts[0] + ".0.0";
            if (parts.Length == 2) return parts[0] + "." + parts[1] + ".0";
            return parts[0] + "." + parts[1] + "." + parts[2];
        }

        public static void CheckForUpdates(bool showDialogAlways, bool darkMode, bool topMost, Form owner)
        {
            System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                ReleaseUpdateInfo info = FetchLatestReleaseInfo();
                if (showDialogAlways || info.IsUpdateAvailable)
                {
                    if (owner != null && owner.IsHandleCreated)
                    {
                        owner.BeginInvoke((MethodInvoker)(() =>
                        {
                            UpdateForm uf = new UpdateForm(info, darkMode);
                            uf.Owner = owner;
                            uf.TopMost = topMost;
                            uf.ShowDialog(owner);
                        }));
                    }
                }
            });
        }

        public static void ApplyDownloadedUpdate(string downloadedFilePath)
        {
            try
            {
                string ext = Path.GetExtension(downloadedFilePath).ToLowerInvariant();
                string appDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\', '/');
                string currentExe = Application.ExecutablePath;

                if (ext == ".msi")
                {
                    Process.Start("msiexec.exe", string.Format("/i \"{0}\"", downloadedFilePath));
                    Application.Exit();
                    return;
                }
                else if (ext == ".exe")
                {
                    Process.Start(downloadedFilePath);
                    Application.Exit();
                    return;
                }
                else if (ext == ".zip")
                {
                    string extractDir = Path.Combine(Path.GetTempPath(), "LiteScreenRecorder_Extracted_" + Guid.NewGuid().ToString("N").Substring(0, 8));
                    if (Directory.Exists(extractDir))
                    {
                        Directory.Delete(extractDir, true);
                    }
                    ZipFile.ExtractToDirectory(downloadedFilePath, extractDir);

                    string sourceCopyDir = extractDir;
                    string[] subDirs = Directory.GetDirectories(extractDir);
                    if (Directory.GetFiles(extractDir, "*.exe").Length == 0 && subDirs.Length == 1)
                    {
                        sourceCopyDir = subDirs[0];
                    }

                    string batchPath = Path.Combine(Path.GetTempPath(), "_lite_screen_recorder_updater.bat");
                    StringBuilder bat = new StringBuilder();
                    bat.AppendLine("@echo off");
                    bat.AppendLine("title Lite Screen Recorder Auto-Updater (@xboyrex)");
                    bat.AppendLine("echo Applying Lite Screen Recorder update...");
                    bat.AppendLine("ping 127.0.0.1 -n 3 > nul");
                    bat.AppendLine(string.Format("xcopy /E /Y /I \"{0}\\*\" \"{1}\\\"", sourceCopyDir, appDir));
                    bat.AppendLine(string.Format("start \"\" \"{0}\"", currentExe));
                    bat.AppendLine(string.Format("rmdir /S /Q \"{0}\"", extractDir));
                    bat.AppendLine("del \"%~f0\"");

                    File.WriteAllText(batchPath, bat.ToString(), Encoding.Default);

                    ProcessStartInfo psi = new ProcessStartInfo()
                    {
                        FileName = batchPath,
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        WindowStyle = ProcessWindowStyle.Hidden
                    };
                    Process.Start(psi);
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Downloaded update package saved at:\r\n" + downloadedFilePath + "\r\n\r\nDetails: " + ex.Message,
                    "Lite Screen Recorder Updater",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
    }
}
