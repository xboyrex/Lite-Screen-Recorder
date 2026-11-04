using QuickLibrary;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace quick_screen_recorder
{
    public partial class UpdateForm : Form
    {
        private ReleaseUpdateInfo updateInfo;
        private bool darkMode;
        private WebClient downloadClient;
        private string targetDownloadPath;

        public UpdateForm(ReleaseUpdateInfo info, bool darkMode)
        {
            if (darkMode)
            {
                this.HandleCreated += new EventHandler(ThemeManager.formHandleCreated);
            }

            this.updateInfo = info ?? AutoUpdater.FetchLatestReleaseInfo();
            this.darkMode = darkMode;

            InitializeComponent();
            PopulateInfo();
            ApplyTheme(darkMode);
        }

        private void ApplyTheme(bool dark)
        {
            if (dark)
            {
                this.BackColor = ThemeManager.DarkBackColor;
                this.ForeColor = Color.White;

                changelogTextBox.BackColor = ThemeManager.DarkSecondColor;
                changelogTextBox.ForeColor = Color.FromArgb(230, 240, 255);

                updateNowBtn.BackColor = Color.FromArgb(0, 150, 136);
                updateNowBtn.ForeColor = Color.White;

                refreshCheckBtn.BackColor = ThemeManager.DarkSecondColor;
                refreshCheckBtn.ForeColor = Color.White;

                openGithubBtn.BackColor = ThemeManager.DarkSecondColor;
                openGithubBtn.ForeColor = Color.White;

                closeBtn.BackColor = ThemeManager.DarkSecondColor;
                closeBtn.ForeColor = Color.White;
            }
            else
            {
                changelogTextBox.BackColor = Color.FromArgb(245, 247, 250);
                changelogTextBox.ForeColor = Color.FromArgb(25, 30, 40);
            }

            statusGroup.SetDarkMode(dark);
            changelogGroup.SetDarkMode(dark);
        }

        private void PopulateInfo()
        {
            currentVerLabel.Text = "Installed Version: v" + updateInfo.CurrentVersion;
            latestVerLabel.Text = "Latest GitHub Release: " + updateInfo.TagName + " (" + updateInfo.PublishedAt + ")";
            changelogTextBox.Text = updateInfo.ChangelogText;
            changelogTextBox.SelectionStart = 0;
            changelogTextBox.SelectionLength = 0;

            if (updateInfo.IsUpdateAvailable)
            {
                statusBannerLabel.Text = "🚀 NEW UPDATE AVAILABLE: " + updateInfo.ReleaseTitle;
                statusBannerLabel.ForeColor = Color.FromArgb(0, 230, 118);
                updateNowBtn.Text = "⬇ Download & Auto-Update Now";
                updateNowBtn.Enabled = true;
            }
            else if (updateInfo.ApiReachable)
            {
                statusBannerLabel.Text = "✅ You are running the latest version (v" + updateInfo.CurrentVersion + ")";
                statusBannerLabel.ForeColor = Color.FromArgb(0, 210, 255);
                if (!string.IsNullOrEmpty(updateInfo.DownloadUrl))
                {
                    updateNowBtn.Text = "🔄 Re-Install Latest Release (" + updateInfo.TagName + ")";
                    updateNowBtn.Enabled = true;
                }
                else
                {
                    updateNowBtn.Text = "✅ Up to Date";
                    updateNowBtn.Enabled = false;
                }
            }
            else
            {
                statusBannerLabel.Text = "ℹ️ v" + updateInfo.CurrentVersion + " Ready • GitHub Repo: xboyrex/Lite-Screen-Recorder";
                statusBannerLabel.ForeColor = Color.FromArgb(0, 210, 255);
                updateNowBtn.Text = "🌐 Open GitHub Releases";
                updateNowBtn.Enabled = true;
            }

            if (updateInfo.AssetSize > 0)
            {
                double mb = updateInfo.AssetSize / (1024.0 * 1024.0);
                progressStatusLabel.Text = string.Format("Package: {0} ({1:0.00} MB)", updateInfo.AssetName, mb);
            }
            else
            {
                progressStatusLabel.Text = "Ready to check or install updates from github.com/xboyrex/Lite-Screen-Recorder";
            }
        }

        private void refreshCheckBtn_Click(object sender, EventArgs e)
        {
            refreshCheckBtn.Enabled = false;
            progressStatusLabel.Text = "Checking GitHub Releases API (xboyrex/Lite-Screen-Recorder)...";
            System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                ReleaseUpdateInfo refreshed = AutoUpdater.FetchLatestReleaseInfo();
                this.BeginInvoke((MethodInvoker)(() =>
                {
                    this.updateInfo = refreshed;
                    PopulateInfo();
                    refreshCheckBtn.Enabled = true;
                }));
            });
        }

        private void updateNowBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(updateInfo.DownloadUrl))
            {
                Process.Start(updateInfo.HtmlUrl);
                return;
            }

            try
            {
                updateNowBtn.Enabled = false;
                refreshCheckBtn.Enabled = false;
                downloadProgressBar.Value = 0;

                string tempFolder = Path.Combine(Path.GetTempPath(), "LiteScreenRecorder_Update");
                if (!Directory.Exists(tempFolder))
                {
                    Directory.CreateDirectory(tempFolder);
                }

                string fileName = string.IsNullOrEmpty(updateInfo.AssetName)
                    ? ("Lite-Screen-Recorder-" + updateInfo.TagName + ".zip")
                    : updateInfo.AssetName;

                targetDownloadPath = Path.Combine(tempFolder, fileName);

                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072 | (SecurityProtocolType)768 | SecurityProtocolType.Tls;
                downloadClient = new WebClient();
                downloadClient.Headers.Add("User-Agent", "Lite-Screen-Recorder-Updater-xboyrex/2.0.0");
                downloadClient.DownloadProgressChanged += DownloadClient_DownloadProgressChanged;
                downloadClient.DownloadFileCompleted += DownloadClient_DownloadFileCompleted;

                progressStatusLabel.Text = "Downloading " + fileName + " ... 0%";
                downloadClient.DownloadFileAsync(new Uri(updateInfo.DownloadUrl), targetDownloadPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to start update download: " + ex.Message, "Updater Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                updateNowBtn.Enabled = true;
                refreshCheckBtn.Enabled = true;
            }
        }

        private void DownloadClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            int pct = Math.Max(0, Math.Min(100, e.ProgressPercentage));
            downloadProgressBar.Value = pct;
            double recvMb = e.BytesReceived / (1024.0 * 1024.0);
            if (e.TotalBytesToReceive > 0)
            {
                double totalMb = e.TotalBytesToReceive / (1024.0 * 1024.0);
                progressStatusLabel.Text = string.Format("Downloading update: {0}% ({1:0.00} MB / {2:0.00} MB)", pct, recvMb, totalMb);
            }
            else
            {
                progressStatusLabel.Text = string.Format("Downloading update: {0:0.00} MB received...", recvMb);
            }
        }

        private void DownloadClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                progressStatusLabel.Text = "Update download cancelled.";
                updateNowBtn.Enabled = true;
                refreshCheckBtn.Enabled = true;
                return;
            }
            if (e.Error != null)
            {
                progressStatusLabel.Text = "Download error: " + e.Error.Message;
                MessageBox.Show(
                    "Could not download release asset automatically.\r\nOpening GitHub Releases page in browser.",
                    "Lite Screen Recorder Updater",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                Process.Start(updateInfo.HtmlUrl);
                updateNowBtn.Enabled = true;
                refreshCheckBtn.Enabled = true;
                return;
            }

            downloadProgressBar.Value = 100;
            progressStatusLabel.Text = "✅ Download complete! Applying update and restarting...";
            AutoUpdater.ApplyDownloadedUpdate(targetDownloadPath);
        }

        private void openGithubBtn_Click(object sender, EventArgs e)
        {
            Process.Start(updateInfo.HtmlUrl);
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            if (downloadClient != null && downloadClient.IsBusy)
            {
                downloadClient.CancelAsync();
            }
            this.Close();
        }

        private void UpdateForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
