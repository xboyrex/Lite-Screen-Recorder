using QuickLibrary;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace quick_screen_recorder
{
    partial class SettingsForm : Form
    {
        private bool darkMode;
        private bool loadingSettings = true;

        public SettingsForm(bool darkMode)
        {
            if (darkMode)
            {
                this.HandleCreated += new EventHandler(ThemeManager.formHandleCreated);
            }

            this.darkMode = darkMode;

            InitializeComponent();

            if (darkMode)
            {
                this.BackColor = ThemeManager.DarkBackColor;
                this.ForeColor = Color.White;

                settingsTabs.BackTabColor = ThemeManager.DarkBackColor;
                settingsTabs.BorderColor = ThemeManager.DarkSecondColor;
                settingsTabs.HeaderColor = ThemeManager.DarkSecondColor;
                settingsTabs.TextColor = Color.White;
                settingsTabs.HorizontalLineColor = Color.Transparent;

                mixerBtn.BackColor = ThemeManager.DarkSecondColor;
                mixerBtn.Image = Properties.Resources.white_mixer;
                winSoundBtn.BackColor = ThemeManager.DarkSecondColor;
                winSoundBtn.Image = Properties.Resources.white_speaker;

                checkNowBtn.BackColor = ThemeManager.DarkSecondColor;
                checkNowBtn.ForeColor = Color.White;
            }

            settingsTabs.ActiveColor = ThemeManager.AccentColor;

            systemThemeRadio.SetDarkMode(darkMode);
            darkThemeRadio.SetDarkMode(darkMode);
            lightThemeRadio.SetDarkMode(darkMode);
            updatesCheckBox.SetDarkMode(darkMode);
            minTaskbarCheckBox.SetDarkMode(darkMode);
            autoDateCheckBox.SetDarkMode(darkMode);
            openFolderAfterCheckBox.SetDarkMode(darkMode);
            timestampOverlayCheckBox.SetDarkMode(darkMode);
            countdownComboBox.SetDarkMode(darkMode);
            autoStopComboBox.SetDarkMode(darkMode);

            int theme = Properties.Settings.Default.Theme;
            if (theme == 0) systemThemeRadio.Checked = true;
            else if (theme == 1) lightThemeRadio.Checked = true;
            else darkThemeRadio.Checked = true;

            updatesCheckBox.Checked = Properties.Settings.Default.CheckForUpdates;
            minTaskbarCheckBox.Checked = Properties.Settings.Default.MinimizeToTray;
            autoDateCheckBox.Checked = Properties.Settings.Default.AutoTimestampFile;
            openFolderAfterCheckBox.Checked = Properties.Settings.Default.OpenFolderAfterRec;
            timestampOverlayCheckBox.Checked = Properties.Settings.Default.ShowTimestamp;

            int cdIdx = Properties.Settings.Default.CountdownIndex;
            if (cdIdx >= 0 && cdIdx < countdownComboBox.Items.Count) countdownComboBox.SelectedIndex = cdIdx;
            else countdownComboBox.SelectedIndex = 0;

            int asIdx = Properties.Settings.Default.AutoStopIndex;
            if (asIdx >= 0 && asIdx < autoStopComboBox.Items.Count) autoStopComboBox.SelectedIndex = asIdx;
            else autoStopComboBox.SelectedIndex = 0;

            loadingSettings = false;
        }

        private void SettingsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void updatesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (loadingSettings) return;
            Properties.Settings.Default.CheckForUpdates = updatesCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void minTaskbarCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (loadingSettings) return;
            Properties.Settings.Default.MinimizeToTray = minTaskbarCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void autoDateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (loadingSettings) return;
            Properties.Settings.Default.AutoTimestampFile = autoDateCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void openFolderAfterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (loadingSettings) return;
            Properties.Settings.Default.OpenFolderAfterRec = openFolderAfterCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void timestampOverlayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (loadingSettings) return;
            Properties.Settings.Default.ShowTimestamp = timestampOverlayCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void countdownComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadingSettings) return;
            Properties.Settings.Default.CountdownIndex = countdownComboBox.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void autoStopComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loadingSettings) return;
            Properties.Settings.Default.AutoStopIndex = autoStopComboBox.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void checkNowBtn_Click(object sender, EventArgs e)
        {
            AutoUpdater.CheckForUpdates(true, darkMode, this.TopMost, this.Owner ?? this);
        }

        private void systemThemeRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (loadingSettings) return;
            if (systemThemeRadio.Checked)
            {
                Properties.Settings.Default.Theme = 0;
                Properties.Settings.Default.Save();
            }
        }

        private void lightThemeRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (loadingSettings) return;
            if (lightThemeRadio.Checked)
            {
                Properties.Settings.Default.Theme = 1;
                Properties.Settings.Default.Save();
            }
        }

        private void darkThemeRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (loadingSettings) return;
            if (darkThemeRadio.Checked)
            {
                Properties.Settings.Default.Theme = 2;
                Properties.Settings.Default.Save();
            }
        }

        private void mixerBtn_Click(object sender, EventArgs e)
        {
            var cplPath = System.IO.Path.Combine(Environment.SystemDirectory, "sndvol.exe");
            System.Diagnostics.Process.Start(cplPath);
        }

        private void winSoundBtn_Click(object sender, EventArgs e)
        {
            var cplPath = System.IO.Path.Combine(Environment.SystemDirectory, "control.exe");
            System.Diagnostics.Process.Start(cplPath, "/name Microsoft.Sound");
        }
    }
}
