using QuickLibrary;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace quick_screen_recorder
{
    partial class AboutForm : Form
    {
        private bool darkMode;

        public AboutForm(bool darkMode)
        {
            if (darkMode)
            {
                this.HandleCreated += new EventHandler(ThemeManager.formHandleCreated);
            }

            this.darkMode = darkMode;

            InitializeComponent();

            string fullVer = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            int lastDotIndex = fullVer.LastIndexOf('.');
            versionLabel.Text = string.Format("Version: {0}", fullVer.Substring(0, lastDotIndex));

            if (IntPtr.Size == 4)
            {
                versionLabel.Text += " (x32)";
            }
            else if (IntPtr.Size == 8)
            {
                versionLabel.Text += " (x64)";
            }

            if (darkMode)
            {
                this.BackColor = ThemeManager.DarkBackColor;
                this.ForeColor = Color.White;
            }

            updatesLink.LinkColor = ThemeManager.AccentColor;
            developerLink.LinkColor = ThemeManager.AccentColor;
            projectLink.LinkColor = ThemeManager.AccentColor;
            youtubeLink.LinkColor = ThemeManager.AccentColor;
            telegramLink.LinkColor = ThemeManager.AccentColor;

            infoGroup.SetDarkMode(darkMode);
            pagesGroup.SetDarkMode(darkMode);
        }

        private void developerLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/xboyrex");
        }

        private void projectLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/xboyrex/Lite-Screen-Recorder");
        }

        private void youtubeLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://youtube.com/@mayankdroid");
        }

        private void telegramLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://t.me/MayankDroid7");
        }

        private void updatesLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form parent = this.Owner ?? this;
            this.Close();
            AutoUpdater.CheckForUpdates(true, darkMode, this.TopMost, parent);
        }

        private void AboutForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
