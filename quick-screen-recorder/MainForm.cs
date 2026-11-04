using NAudio.Wave;
using QuickLibrary;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace quick_screen_recorder
{
    public partial class MainForm : Form
    {
        private AreaForm areaForm;
        private StopForm stopForm;
        private Recorder recorder = null;
        private bool darkMode;
        private bool suppressAreaSync = false;
        private string lastRecordedFilePath = "";

        public MainForm(bool darkMode)
        {
            if (darkMode)
            {
                this.HandleCreated += new EventHandler(ThemeManager.formHandleCreated);
            }

            this.darkMode = darkMode;
            this.DoubleBuffered = true;

            InitializeComponent();

            areaForm = new AreaForm();
            areaForm.Owner = this;

            inputDeviceComboBox.SelectedIndex = 0;

            RefreshScreens();
            RefreshAudioDevices();

            previewBtn.Checked = Properties.Settings.Default.Preview;
            enabledPreview(previewBtn.Checked);

            applyDarkTheme(darkMode);
        }

        private void applyDarkTheme(bool darkMode)
        {
            if (darkMode)
            {
                this.ForeColor = Color.White;
                this.BackColor = ThemeManager.DarkBackColor;

                recButton.BackColor = ThemeManager.DarkSecondColor;
                recButton.Image = Properties.Resources.white_record;

                shotButton.BackColor = ThemeManager.DarkSecondColor;
                shotButton.ForeColor = Color.White;

                aboutBtn.Image = Properties.Resources.white_about;
                onTopBtn.Image = Properties.Resources.white_ontop;
                settingsBtn.Image = Properties.Resources.white_settings;
                previewBtn.Image = Properties.Resources.white_preview;

                telegramBtn.Image = Properties.Resources.telegram_icon;
                githubBtn.Image = Properties.Resources.github_icon;

                brandBadgeBox.Image = Properties.Resources.brand_dark;
                tgFooterBtn.Image = Properties.Resources.telegram_icon;
                tgFooterBtn.BackColor = ThemeManager.DarkSecondColor;
                ghFooterBtn.Image = Properties.Resources.github_icon;
                ghFooterBtn.BackColor = ThemeManager.DarkSecondColor;

                fileNameTextBox.BackColor = ThemeManager.DarkSecondColor;
                fileNameTextBox.ForeColor = Color.White;

                folderTextBox.BackColor = ThemeManager.DarkSecondColor;
                folderTextBox.ForeColor = Color.White;

                refreshAudioBtn.BackColor = ThemeManager.DarkSecondColor;
                refreshAudioBtn.Image = Properties.Resources.white_refresh;

                refreshScreensBtn.BackColor = ThemeManager.DarkSecondColor;
                refreshScreensBtn.Image = Properties.Resources.white_refresh;
            }
            else
            {
                telegramBtn.Image = Properties.Resources.telegram_icon;
                githubBtn.Image = Properties.Resources.github_icon_light;

                brandBadgeBox.Image = Properties.Resources.brand_light;
                tgFooterBtn.Image = Properties.Resources.telegram_icon;
                ghFooterBtn.Image = Properties.Resources.github_icon_light;
            }

            generalGroup.SetDarkMode(darkMode);
            videoGroup.SetDarkMode(darkMode);
            audioGroup.SetDarkMode(darkMode);
            toolStrip1.SetDarkMode(darkMode, false);
            browseFolderBtn.SetDarkMode(darkMode);
            openFolderBtn.SetDarkMode(darkMode);
            qualityComboBox.SetDarkMode(darkMode);
            fpsComboBox.SetDarkMode(darkMode);
            resComboBox.SetDarkMode(darkMode);
            inputDeviceComboBox.SetDarkMode(darkMode);
            areaComboBox.SetDarkMode(darkMode);
            widthNumeric.SetDarkMode(darkMode);
            heightNumeric.SetDarkMode(darkMode);
            xNumeric.SetDarkMode(darkMode);
            yNumeric.SetDarkMode(darkMode);
            separateAudioCheckBox.SetDarkMode(darkMode);
            captureCursorCheckBox.SetDarkMode(darkMode);
            clickEffectCheckBox.SetDarkMode(darkMode);
            hapticsCheckBox.SetDarkMode(darkMode);
            hideTaskbarCheckBox.SetDarkMode(darkMode);
        }

        private void SafeSetMaximum(NumericUpDown ctrl, int maxVal)
        {
            int minVal = (int)ctrl.Minimum;
            int safeMax = (maxVal < minVal) ? minVal : maxVal;
            if (ctrl.Value > safeMax)
            {
                ctrl.Value = safeMax;
            }
            ctrl.Maximum = safeMax;
        }

        private void SafeSetNumeric(NumericUpDown ctrl, int val)
        {
            int minVal = (int)ctrl.Minimum;
            int maxVal = (int)ctrl.Maximum;
            int clamped = val;
            if (clamped < minVal) clamped = minVal;
            if (clamped > maxVal) clamped = maxVal;
            ctrl.Value = clamped;
        }

        public void SetAreaWidth(int w)
        {
            if (suppressAreaSync) return;
            suppressAreaSync = true;
            try { SafeSetNumeric(widthNumeric, w); }
            finally { suppressAreaSync = false; }
        }

        public void SetAreaHeight(int h)
        {
            if (suppressAreaSync) return;
            suppressAreaSync = true;
            try { SafeSetNumeric(heightNumeric, h); }
            finally { suppressAreaSync = false; }
        }

        public void SetAreaX(int x)
        {
            if (suppressAreaSync) return;
            suppressAreaSync = true;
            try { SafeSetNumeric(xNumeric, x); }
            finally { suppressAreaSync = false; }
        }

        public void SetAreaY(int y)
        {
            if (suppressAreaSync) return;
            suppressAreaSync = true;
            try { SafeSetNumeric(yNumeric, y); }
            finally { suppressAreaSync = false; }
        }

        public void SetMaximumX(int maxX)
        {
            SafeSetMaximum(xNumeric, Math.Max(0, maxX));
        }

        public void SetMaximumY(int maxY)
        {
            SafeSetMaximum(yNumeric, Math.Max(0, maxY));
        }

        private void recButton_Click(object sender, EventArgs e)
        {
            HapticsEngine.PlayStartRec();
            CheckStartRec();
        }

        private void shotButton_Click(object sender, EventArgs e)
        {
            HapticsEngine.PlayShutter();
            TakeQuickScreenshot();
        }

        public void TakeQuickScreenshot()
        {
            try
            {
                int width = (int)widthNumeric.Value;
                int height = (int)heightNumeric.Value;
                int x = (int)xNumeric.Value;
                int y = (int)yNumeric.Value;

                string savedPath = Recorder.CaptureScreenshotToFile(
                    folderTextBox.Text,
                    x, y, width, height,
                    captureCursorCheckBox.Checked,
                    clickEffectCheckBox.Checked,
                    Properties.Settings.Default.EnableWatermark,
                    Properties.Settings.Default.WatermarkText,
                    Properties.Settings.Default.ShowTimestamp);

                this.Text = "Lite Screen Recorder — Saved " + Path.GetFileName(savedPath);
            }
            catch
            {
            }
        }

        public void StopRec()
        {
            try
            {
                HapticsEngine.PlayStopRec();

                if (recorder != null)
                {
                    recorder.Dispose();
                    recorder.OnPeakVolumeChanged -= Recorder_OnPeakVolumeChanged;
                    recorder = null;
                }

                // Smooth fade-in restore of Home window
                this.Opacity = 0.15;
                this.ShowInTaskbar = true;
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.Activate();

                for (int step = 1; step <= 6; step++)
                {
                    this.Opacity = Math.Min(1.0, 0.15 + step * 0.15);
                    Application.DoEvents();
                    Thread.Sleep(12);
                }
                this.Opacity = 1.0;

                HotkeyManager.RegisterHotKey(this.Handle, 0, (int)HotkeyManager.KeyModifier.Alt, Keys.R.GetHashCode());
                HotkeyManager.RegisterHotKey(this.Handle, 2, (int)HotkeyManager.KeyModifier.Alt, Keys.S.GetHashCode());

                if (areaComboBox.SelectedIndex == areaComboBox.Items.Count - 1)
                {
                    areaForm.Show();
                }

                this.Text = "Lite Screen Recorder";
                updateTimer.Start();

                if (Properties.Settings.Default.OpenFolderAfterRec && !string.IsNullOrEmpty(lastRecordedFilePath))
                {
                    string dir = Path.GetDirectoryName(lastRecordedFilePath);
                    if (!string.IsNullOrEmpty(dir) && Directory.Exists(dir))
                    {
                        Process.Start("explorer.exe", string.Format("/select,\"{0}\"", lastRecordedFilePath));
                    }
                }
            }
            catch
            {
                this.Opacity = 1.0;
                this.ShowInTaskbar = true;
                this.Show();
            }
        }

        public void TogglePauseRecorder(bool paused)
        {
            HapticsEngine.PlayTap();
            if (recorder != null)
            {
                recorder.Paused = paused;
            }
        }

        private int GetSelectedFps()
        {
            string txt = fpsComboBox.Text;
            int parsed = 60;
            int.TryParse(string.Concat(txt.Where(char.IsDigit)), out parsed);
            return (parsed >= 5 && parsed <= 60) ? parsed : 60;
        }

        private void GetTargetOutputResolution(int capW, int capH, out int outW, out int outH)
        {
            int idx = resComboBox.SelectedIndex;
            if (idx == 1)
            {
                // 1080p Full HD (1920x1080 High Quality)
                outW = 1920;
                outH = 1080;
            }
            else if (idx == 2)
            {
                // 720p HD (1280x720)
                outW = 1280;
                outH = 720;
            }
            else if (idx == 3)
            {
                // 180p Ultra-Fast (320x180)
                outW = 320;
                outH = 180;
            }
            else
            {
                // Native Screen / Custom Area Size
                outW = capW;
                outH = capH;
            }
        }

        private int GetCountdownSeconds()
        {
            int idx = Properties.Settings.Default.CountdownIndex;
            if (idx == 1) return 3;
            if (idx == 2) return 5;
            if (idx == 3) return 10;
            return 0;
        }

        private int GetAutoStopSeconds()
        {
            int idx = Properties.Settings.Default.AutoStopIndex;
            if (idx == 1) return 300;
            if (idx == 2) return 900;
            if (idx == 3) return 1800;
            if (idx == 4) return 3600;
            return 0;
        }

        private void CheckStartRec()
        {
            string baseName = string.IsNullOrEmpty(fileNameTextBox.Text.Trim()) ? "NewVideo1" : fileNameTextBox.Text.Trim();
            if (Properties.Settings.Default.AutoTimestampFile)
            {
                baseName = string.Format("{0}_{1}", baseName, DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
            }

            string folder = folderTextBox.Text;
            if (string.IsNullOrEmpty(folder) || !Directory.Exists(folder))
            {
                folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                folderTextBox.Text = folder;
            }

            string path = Path.Combine(folder, baseName + ".avi");

            if (File.Exists(path))
            {
                DialogResult window = MessageBox.Show(
                    baseName + ".avi already exists.\r\nDo you want to replace it and start recording?",
                    "Warning",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (window == DialogResult.Yes)
                {
                    StartRecWithSmoothTransition(path);
                }
            }
            else
            {
                StartRecWithSmoothTransition(path);
            }
        }

        private void StartRecWithSmoothTransition(string path)
        {
            try
            {
                updateTimer.Stop();
                HotkeyManager.UnregisterHotKey(this.Handle, 0);
                HotkeyManager.UnregisterHotKey(this.Handle, 2);

                areaForm.Hide();

                // Smooth 60fps slide-down + fade-out transition toward the bottom Taskbar tab
                int origTop = this.Top;
                for (int step = 1; step <= 8; step++)
                {
                    this.Top = origTop + (step * 5);
                    this.Opacity = Math.Max(0.05, 1.0 - (step * 0.12));
                    Application.DoEvents();
                    Thread.Sleep(14);
                }

                this.ShowInTaskbar = false;
                this.Hide();
                this.Top = origTop;
                this.Opacity = 1.0;
                Application.DoEvents();

                int quality = 0;
                int.TryParse(string.Concat(qualityComboBox.Text.Where(char.IsDigit)), out quality);
                int fps = GetSelectedFps();
                int inputSourceIndex = inputDeviceComboBox.SelectedIndex - 2;

                int capWidth = (int)widthNumeric.Value;
                int capHeight = (int)heightNumeric.Value;
                int x = (int)xNumeric.Value;
                int y = (int)yNumeric.Value;

                int outWidth, outHeight;
                GetTargetOutputResolution(capWidth, capHeight, out outWidth, out outHeight);

                lastRecordedFilePath = path;

                string videoStr = string.Format("{0}x{1} @ {2}fps (", outWidth, outHeight, fps);
                if (quality == 0)
                {
                    videoStr += "Uncompressed";
                }
                else
                {
                    videoStr += quality + "%";
                }
                if (captureCursorCheckBox.Checked)
                {
                    videoStr += ", Cursor";
                }
                videoStr += ")";

                string audioStr = inputDeviceComboBox.Text;
                int countdownSec = GetCountdownSeconds();
                int autoStopSec = GetAutoStopSeconds();
                bool minToTaskbar = Properties.Settings.Default.MinimizeToTray;

                stopForm = new StopForm(
                    this,
                    darkMode,
                    videoStr,
                    audioStr,
                    countdownSec,
                    autoStopSec,
                    minToTaskbar,
                    () =>
                    {
                        recorder = new Recorder(
                            path,
                            quality,
                            fps,
                            x,
                            y,
                            capWidth,
                            capHeight,
                            outWidth,
                            outHeight,
                            captureCursorCheckBox.Checked,
                            clickEffectCheckBox.Checked,
                            Properties.Settings.Default.EnableWatermark,
                            Properties.Settings.Default.WatermarkText,
                            Properties.Settings.Default.ShowTimestamp,
                            inputSourceIndex,
                            separateAudioCheckBox.Checked);

                        recorder.OnPeakVolumeChanged += Recorder_OnPeakVolumeChanged;
                    });

                stopForm.Show();
            }
            catch (Exception ex)
            {
                this.Opacity = 1.0;
                this.ShowInTaskbar = true;
                this.Show();
                updateTimer.Start();
                MessageBox.Show("Failed to start recording:\r\n" + ex.Message, "Error");
            }
        }

        private void Recorder_OnPeakVolumeChanged(object sender, OnPeakVolumeChangedArgs e)
        {
            if (stopForm != null && !stopForm.IsDisposed)
            {
                stopForm.UpdateVolumeBar(e.Volume);
            }
        }

        private void browseFolderBtn_Click(object sender, EventArgs e)
        {
            HapticsEngine.PlayTap();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void openFolderBtn_Click(object sender, EventArgs e)
        {
            HapticsEngine.PlayTap();
            try
            {
                string dir = folderTextBox.Text;
                if (string.IsNullOrEmpty(dir) || !Directory.Exists(dir))
                {
                    dir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                }
                Process.Start("explorer.exe", dir);
            }
            catch { }
        }

        private void telegramBtn_Click(object sender, EventArgs e)
        {
            HapticsEngine.PlayTap();
            Process.Start("https://t.me/MayankDroid7");
        }

        private void githubBtn_Click(object sender, EventArgs e)
        {
            HapticsEngine.PlayTap();
            Process.Start("https://github.com/xboyrex");
        }

        private void brandBadgeBox_Click(object sender, EventArgs e)
        {
            HapticsEngine.PlayTap();
            Process.Start("https://t.me/MayankDroid7");
        }

        private void aboutBtn_Click(object sender, EventArgs e)
        {
            HapticsEngine.PlayTap();
            AboutForm aboutBox = new AboutForm(darkMode);
            aboutBox.Owner = this;
            if (this.TopMost)
            {
                aboutBox.TopMost = true;
            }
            aboutBox.ShowDialog();
        }

        private void areaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshAreaInfo();
        }

        private void RefreshAreaInfo()
        {
            if (areaComboBox.SelectedIndex < 0) return;

            suppressAreaSync = true;
            try
            {
                int virtW = Math.Max(4096, SystemInformation.VirtualScreen.Width);
                int virtH = Math.Max(4096, SystemInformation.VirtualScreen.Height);
                SafeSetMaximum(widthNumeric, virtW);
                SafeSetMaximum(heightNumeric, virtH);
                SafeSetMaximum(xNumeric, virtW);
                SafeSetMaximum(yNumeric, virtH);

                if (areaComboBox.SelectedIndex == areaComboBox.Items.Count - 1)
                {
                    areaForm.Show();

                    SafeSetNumeric(widthNumeric, areaForm.Width);
                    SafeSetNumeric(heightNumeric, areaForm.Height);
                    SafeSetNumeric(xNumeric, areaForm.Left);
                    SafeSetNumeric(yNumeric, areaForm.Top);

                    widthNumeric.Enabled = true;
                    heightNumeric.Enabled = true;
                    xNumeric.Enabled = true;
                    yNumeric.Enabled = true;

                    hideTaskbarCheckBox.Enabled = false;
                }
                else
                {
                    areaForm.Hide();

                    widthNumeric.Enabled = false;
                    heightNumeric.Enabled = false;
                    xNumeric.Enabled = false;
                    yNumeric.Enabled = false;

                    hideTaskbarCheckBox.Enabled = true;

                    if (Screen.AllScreens.Length > 1 && areaComboBox.SelectedIndex == areaComboBox.Items.Count - 2)
                    {
                        SafeSetNumeric(widthNumeric, SystemInformation.VirtualScreen.Width);
                        SafeSetNumeric(heightNumeric, SystemInformation.VirtualScreen.Height);
                        SafeSetNumeric(xNumeric, Math.Max(0, SystemInformation.VirtualScreen.Left));
                        SafeSetNumeric(yNumeric, Math.Max(0, SystemInformation.VirtualScreen.Top));

                        hideTaskbarCheckBox.Enabled = false;
                    }
                    else if (areaComboBox.SelectedIndex < Screen.AllScreens.Length)
                    {
                        Screen scr = Screen.AllScreens[areaComboBox.SelectedIndex];
                        Rectangle rect = hideTaskbarCheckBox.Checked ? scr.WorkingArea : scr.Bounds;

                        SafeSetNumeric(widthNumeric, rect.Width);
                        SafeSetNumeric(heightNumeric, rect.Height);
                        SafeSetNumeric(xNumeric, Math.Max(0, rect.X));
                        SafeSetNumeric(yNumeric, Math.Max(0, rect.Y));
                    }
                }
            }
            catch { }
            finally
            {
                suppressAreaSync = false;
            }
        }

        private void widthNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (suppressAreaSync) return;
            if (widthNumeric.Enabled && areaForm != null && areaForm.Visible)
            {
                suppressAreaSync = true;
                try { areaForm.Width = (int)widthNumeric.Value; }
                catch { }
                finally { suppressAreaSync = false; }
            }
        }

        private void heightNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (suppressAreaSync) return;
            if (heightNumeric.Enabled && areaForm != null && areaForm.Visible)
            {
                suppressAreaSync = true;
                try { areaForm.Height = (int)heightNumeric.Value; }
                catch { }
                finally { suppressAreaSync = false; }
            }
        }

        private void xNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (suppressAreaSync) return;
            if (xNumeric.Enabled && areaForm != null && areaForm.Visible)
            {
                suppressAreaSync = true;
                try { areaForm.Left = (int)xNumeric.Value; }
                catch { }
                finally { suppressAreaSync = false; }
            }
        }

        private void yNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (suppressAreaSync) return;
            if (yNumeric.Enabled && areaForm != null && areaForm.Visible)
            {
                suppressAreaSync = true;
                try { areaForm.Top = (int)yNumeric.Value; }
                catch { }
                finally { suppressAreaSync = false; }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            HotkeyManager.RegisterHotKey(this.Handle, 0, (int)HotkeyManager.KeyModifier.Alt, Keys.R.GetHashCode());
            HotkeyManager.RegisterHotKey(this.Handle, 2, (int)HotkeyManager.KeyModifier.Alt, Keys.S.GetHashCode());

            onTopBtn.Checked = Properties.Settings.Default.AlwaysOnTop;

            int qIdx = Properties.Settings.Default.QualityIndex;
            if (qIdx >= 0 && qIdx < qualityComboBox.Items.Count) qualityComboBox.SelectedIndex = qIdx;
            else qualityComboBox.SelectedIndex = 4;

            int fIdx = Properties.Settings.Default.FpsIndex;
            if (fIdx >= 0 && fIdx < fpsComboBox.Items.Count) fpsComboBox.SelectedIndex = fIdx;
            else fpsComboBox.SelectedIndex = 3;

            int rIdx = Properties.Settings.Default.ResolutionIndex;
            if (rIdx >= 0 && rIdx < resComboBox.Items.Count) resComboBox.SelectedIndex = rIdx;
            else resComboBox.SelectedIndex = 1;

            captureCursorCheckBox.Checked = Properties.Settings.Default.CaptureCursor;
            clickEffectCheckBox.Checked = Properties.Settings.Default.HighlightClicks;
            hapticsCheckBox.Checked = Properties.Settings.Default.HapticsEnabled;
            HapticsEngine.Enabled = hapticsCheckBox.Checked;
            hideTaskbarCheckBox.Checked = Properties.Settings.Default.HideTaskbar;

            if (string.IsNullOrEmpty(Properties.Settings.Default.Folder))
            {
                folderTextBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            else
            {
                folderTextBox.Text = Properties.Settings.Default.Folder;
            }

            updateTimer.Interval = 120;
            updateTimer.Tick += updateTimer_Tick;
            updateTimer.Start();

            if (Properties.Settings.Default.CheckForUpdates)
            {
                AutoUpdater.CheckForUpdates(false, darkMode, this.TopMost, this);
            }
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            Preview();
        }

        private void Preview()
        {
            if (this.Visible && this.WindowState != FormWindowState.Minimized && this.Width > 700)
            {
                try
                {
                    int width = Math.Max(160, (int)widthNumeric.Value);
                    int height = Math.Max(160, (int)heightNumeric.Value);
                    int x = (int)xNumeric.Value;
                    int y = (int)yNumeric.Value;

                    Bitmap bmp = new Bitmap(width, height);
                    using (var g = Graphics.FromImage(bmp))
                    {
                        g.CopyFromScreen(new Point(x, y), Point.Empty, new Size(width, height), CopyPixelOperation.SourceCopy);

                        Recorder.RenderFrameOverlays(
                            g, x, y, width, height,
                            captureCursorCheckBox.Checked,
                            clickEffectCheckBox.Checked,
                            Properties.Settings.Default.EnableWatermark,
                            Properties.Settings.Default.WatermarkText,
                            Properties.Settings.Default.ShowTimestamp);

                        g.Flush();
                    }

                    Image oldImg = previewBox.Image;
                    previewBox.Image = bmp;
                    if (oldImg != null)
                    {
                        oldImg.Dispose();
                    }
                }
                catch
                {
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312)
            {
                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                HotkeyManager.KeyModifier modifier = (HotkeyManager.KeyModifier)((int)m.LParam & 0xFFFF);

                if (modifier == HotkeyManager.KeyModifier.Alt)
                {
                    if (key == Keys.R)
                    {
                        HapticsEngine.PlayStartRec();
                        CheckStartRec();
                    }
                    else if (key == Keys.S)
                    {
                        HapticsEngine.PlayShutter();
                        TakeQuickScreenshot();
                    }
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            updateTimer.Stop();
            HotkeyManager.UnregisterHotKey(this.Handle, 0);
            HotkeyManager.UnregisterHotKey(this.Handle, 2);
        }

        private void onTopCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            HapticsEngine.PlayTap();
            this.TopMost = onTopBtn.Checked;
            areaForm.TopMost = onTopBtn.Checked;
            Properties.Settings.Default.AlwaysOnTop = onTopBtn.Checked;
            Properties.Settings.Default.Save();
        }

        public void MuteRecorder(bool b)
        {
            if (recorder != null)
            {
                recorder.Mute = b;
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            HapticsEngine.PlayTap();
            RefreshAudioDevices();
        }

        private void RefreshAudioDevices()
        {
            inputDeviceComboBox.SelectedIndex = 0;

            while (inputDeviceComboBox.Items.Count > 2)
            {
                inputDeviceComboBox.Items.RemoveAt(inputDeviceComboBox.Items.Count - 1);
            }

            for (int i = 0; i < WaveIn.DeviceCount; i++)
            {
                inputDeviceComboBox.Items.Add(WaveIn.GetCapabilities(i).ProductName);
            }
        }

        private void RefreshScreens()
        {
            areaComboBox.Items.Clear();

            for (int i = 0; i < Screen.AllScreens.Length; i++)
            {
                if (Screen.AllScreens[i].Primary)
                {
                    areaComboBox.Items.Add("Primary screen (" + Screen.AllScreens[i].Bounds.Width + "x" + Screen.AllScreens[i].Bounds.Height + ")");
                }
                else
                {
                    areaComboBox.Items.Add("Screen " + (i + 1) + " (" + Screen.AllScreens[i].Bounds.Width + "x" + Screen.AllScreens[i].Bounds.Height + ")");
                }
            }

            if (Screen.AllScreens.Length > 1)
            {
                areaComboBox.Items.Add("Everything");
            }

            areaComboBox.Items.Add("Custom area");

            int maxW = Math.Max(4096, SystemInformation.VirtualScreen.Width);
            int maxH = Math.Max(4096, SystemInformation.VirtualScreen.Height);
            SafeSetMaximum(widthNumeric, maxW);
            SafeSetMaximum(heightNumeric, maxH);
            SafeSetMaximum(xNumeric, maxW);
            SafeSetMaximum(yNumeric, maxH);

            areaForm.SetMaximumArea(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height);
            areaComboBox.SelectedIndex = 0;
        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            HapticsEngine.PlayTap();
            SettingsForm settingsBox = new SettingsForm(darkMode);
            settingsBox.Owner = this;
            if (this.TopMost)
            {
                settingsBox.TopMost = true;
            }
            settingsBox.ShowDialog();
        }

        private void inputDeviceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            separateAudioCheckBox.Enabled = inputDeviceComboBox.SelectedIndex != 0;
        }

        private void hideTaskbarCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            RefreshAreaInfo();
            Properties.Settings.Default.HideTaskbar = hideTaskbarCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void refreshScreensBtn_Click(object sender, EventArgs e)
        {
            HapticsEngine.PlayTap();
            RefreshScreens();
        }

        private void captureCursorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CaptureCursor = captureCursorCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void clickEffectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.HighlightClicks = clickEffectCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void hapticsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            HapticsEngine.Enabled = hapticsCheckBox.Checked;
            Properties.Settings.Default.HapticsEnabled = hapticsCheckBox.Checked;
            Properties.Settings.Default.Save();
            if (hapticsCheckBox.Checked)
            {
                HapticsEngine.PlayTap();
            }
        }

        private void qualityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.QualityIndex = qualityComboBox.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void fpsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.FpsIndex = fpsComboBox.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void resComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ResolutionIndex = resComboBox.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void enabledPreview(bool b)
        {
            if (previewBtn.Checked)
            {
                this.Width = 820;
            }
            else
            {
                this.Width = 374;

                if (previewBox.Image != null)
                {
                    Image old = previewBox.Image;
                    previewBox.Image = null;
                    old.Dispose();
                }
            }
        }

        private void previewBtn_CheckedChanged(object sender, EventArgs e)
        {
            HapticsEngine.PlayTap();
            Properties.Settings.Default.Preview = previewBtn.Checked;
            Properties.Settings.Default.Save();

            enabledPreview(previewBtn.Checked);
        }

        private void folderTextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void folderTextBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            FileAttributes attr = File.GetAttributes(FileList[0]);

            if (attr.HasFlag(FileAttributes.Directory))
            {
                folderTextBox.Text = FileList[0];
            }
            else
            {
                folderTextBox.Text = Path.GetDirectoryName(FileList[0]);
            }
        }

        private void folderTextBox_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Folder = folderTextBox.Text;
            Properties.Settings.Default.Save();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.P)
                {
                    previewBtn.PerformClick();
                }
                else if (e.KeyCode == Keys.T)
                {
                    onTopBtn.PerformClick();
                }
                else if (e.KeyCode == Keys.Oemcomma)
                {
                    settingsBtn.PerformClick();
                }
            }
            else
            {
                if (e.KeyCode == Keys.F1)
                {
                    aboutBtn.PerformClick();
                }
            }
        }
    }
}
