namespace quick_screen_recorder
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.licenseLabel = new System.Windows.Forms.Label();
            this.darkThemeRadio = new QuickLibrary.QlibRadioButton();
            this.lightThemeRadio = new QuickLibrary.QlibRadioButton();
            this.systemThemeRadio = new QuickLibrary.QlibRadioButton();
            this.updatesCheckBox = new QuickLibrary.QlibCheckBox();
            this.checkNowBtn = new System.Windows.Forms.Button();
            this.minTaskbarCheckBox = new QuickLibrary.QlibCheckBox();
            this.autoDateCheckBox = new QuickLibrary.QlibCheckBox();
            this.openFolderAfterCheckBox = new QuickLibrary.QlibCheckBox();
            this.timestampOverlayCheckBox = new QuickLibrary.QlibCheckBox();
            this.countdownLabel = new System.Windows.Forms.Label();
            this.countdownComboBox = new QuickLibrary.QlibComboBox();
            this.autoStopLabel = new System.Windows.Forms.Label();
            this.autoStopComboBox = new QuickLibrary.QlibComboBox();
            this.settingsTabs = new QuickLibrary.QlibTabControl();
            this.recPage = new System.Windows.Forms.TabPage();
            this.themePage = new System.Windows.Forms.TabPage();
            this.audioPage = new System.Windows.Forms.TabPage();
            this.updatesPage = new System.Windows.Forms.TabPage();
            this.mixerBtn = new System.Windows.Forms.Button();
            this.winSoundBtn = new System.Windows.Forms.Button();
            this.settingsTabs.SuspendLayout();
            this.recPage.SuspendLayout();
            this.themePage.SuspendLayout();
            this.audioPage.SuspendLayout();
            this.updatesPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingsTabs
            // 
            this.settingsTabs.ActiveColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.settingsTabs.AllowDrop = true;
            this.settingsTabs.BackTabColor = System.Drawing.Color.White;
            this.settingsTabs.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.settingsTabs.ClosingButtonColor = System.Drawing.Color.WhiteSmoke;
            this.settingsTabs.ClosingMessage = null;
            this.settingsTabs.Controls.Add(this.recPage);
            this.settingsTabs.Controls.Add(this.themePage);
            this.settingsTabs.Controls.Add(this.audioPage);
            this.settingsTabs.Controls.Add(this.updatesPage);
            this.settingsTabs.HeaderColor = System.Drawing.SystemColors.ControlLight;
            this.settingsTabs.HorizontalLineColor = System.Drawing.Color.Transparent;
            this.settingsTabs.ItemSize = new System.Drawing.Size(270, 16);
            this.settingsTabs.Location = new System.Drawing.Point(9, 9);
            this.settingsTabs.Name = "settingsTabs";
            this.settingsTabs.SelectedIndex = 0;
            this.settingsTabs.SelectedTextColor = System.Drawing.Color.White;
            this.settingsTabs.ShowClosingButton = false;
            this.settingsTabs.ShowClosingMessage = false;
            this.settingsTabs.Size = new System.Drawing.Size(296, 192);
            this.settingsTabs.TabIndex = 0;
            this.settingsTabs.TextColor = System.Drawing.Color.Black;
            // 
            // recPage
            // 
            this.recPage.BackColor = System.Drawing.Color.White;
            this.recPage.Controls.Add(this.minTaskbarCheckBox);
            this.recPage.Controls.Add(this.autoDateCheckBox);
            this.recPage.Controls.Add(this.openFolderAfterCheckBox);
            this.recPage.Controls.Add(this.timestampOverlayCheckBox);
            this.recPage.Controls.Add(this.countdownLabel);
            this.recPage.Controls.Add(this.countdownComboBox);
            this.recPage.Controls.Add(this.autoStopLabel);
            this.recPage.Controls.Add(this.autoStopComboBox);
            this.recPage.Location = new System.Drawing.Point(4, 20);
            this.recPage.Name = "recPage";
            this.recPage.Size = new System.Drawing.Size(288, 168);
            this.recPage.TabIndex = 0;
            this.recPage.Text = "Recording";
            // 
            // minTaskbarCheckBox
            // 
            this.minTaskbarCheckBox.Checked = true;
            this.minTaskbarCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.minTaskbarCheckBox.Location = new System.Drawing.Point(9, 10);
            this.minTaskbarCheckBox.Name = "minTaskbarCheckBox";
            this.minTaskbarCheckBox.Size = new System.Drawing.Size(270, 19);
            this.minTaskbarCheckBox.TabIndex = 0;
            this.minTaskbarCheckBox.Text = "Minimize to bottom taskbar tab on Start";
            this.minTaskbarCheckBox.CheckedChanged += new System.EventHandler(this.minTaskbarCheckBox_CheckedChanged);
            // 
            // autoDateCheckBox
            // 
            this.autoDateCheckBox.Location = new System.Drawing.Point(9, 34);
            this.autoDateCheckBox.Name = "autoDateCheckBox";
            this.autoDateCheckBox.Size = new System.Drawing.Size(270, 19);
            this.autoDateCheckBox.TabIndex = 1;
            this.autoDateCheckBox.Text = "Auto-append date & time to file name";
            this.autoDateCheckBox.CheckedChanged += new System.EventHandler(this.autoDateCheckBox_CheckedChanged);
            // 
            // openFolderAfterCheckBox
            // 
            this.openFolderAfterCheckBox.Location = new System.Drawing.Point(9, 58);
            this.openFolderAfterCheckBox.Name = "openFolderAfterCheckBox";
            this.openFolderAfterCheckBox.Size = new System.Drawing.Size(270, 19);
            this.openFolderAfterCheckBox.TabIndex = 2;
            this.openFolderAfterCheckBox.Text = "Open output folder after recording";
            this.openFolderAfterCheckBox.CheckedChanged += new System.EventHandler(this.openFolderAfterCheckBox_CheckedChanged);
            // 
            // timestampOverlayCheckBox
            // 
            this.timestampOverlayCheckBox.Location = new System.Drawing.Point(9, 82);
            this.timestampOverlayCheckBox.Name = "timestampOverlayCheckBox";
            this.timestampOverlayCheckBox.Size = new System.Drawing.Size(270, 19);
            this.timestampOverlayCheckBox.TabIndex = 3;
            this.timestampOverlayCheckBox.Text = "Add live timestamp overlay on video";
            this.timestampOverlayCheckBox.CheckedChanged += new System.EventHandler(this.timestampOverlayCheckBox_CheckedChanged);
            // 
            // countdownLabel
            // 
            this.countdownLabel.AutoSize = true;
            this.countdownLabel.Location = new System.Drawing.Point(8, 111);
            this.countdownLabel.Name = "countdownLabel";
            this.countdownLabel.Size = new System.Drawing.Size(70, 15);
            this.countdownLabel.TabIndex = 4;
            this.countdownLabel.Text = "Countdown:";
            // 
            // countdownComboBox
            // 
            this.countdownComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.countdownComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countdownComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.countdownComboBox.FormattingEnabled = true;
            this.countdownComboBox.Items.AddRange(new object[] {
            "None (Start immediately)",
            "3 seconds",
            "5 seconds",
            "10 seconds"});
            this.countdownComboBox.Location = new System.Drawing.Point(84, 108);
            this.countdownComboBox.Name = "countdownComboBox";
            this.countdownComboBox.Size = new System.Drawing.Size(194, 24);
            this.countdownComboBox.TabIndex = 5;
            this.countdownComboBox.SelectedIndexChanged += new System.EventHandler(this.countdownComboBox_SelectedIndexChanged);
            // 
            // autoStopLabel
            // 
            this.autoStopLabel.AutoSize = true;
            this.autoStopLabel.Location = new System.Drawing.Point(8, 140);
            this.autoStopLabel.Name = "autoStopLabel";
            this.autoStopLabel.Size = new System.Drawing.Size(62, 15);
            this.autoStopLabel.TabIndex = 6;
            this.autoStopLabel.Text = "Auto-Stop:";
            // 
            // autoStopComboBox
            // 
            this.autoStopComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.autoStopComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.autoStopComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.autoStopComboBox.FormattingEnabled = true;
            this.autoStopComboBox.Items.AddRange(new object[] {
            "No limit (Manual stop)",
            "Stop after 5 minutes",
            "Stop after 15 minutes",
            "Stop after 30 minutes",
            "Stop after 60 minutes"});
            this.autoStopComboBox.Location = new System.Drawing.Point(84, 137);
            this.autoStopComboBox.Name = "autoStopComboBox";
            this.autoStopComboBox.Size = new System.Drawing.Size(194, 24);
            this.autoStopComboBox.TabIndex = 7;
            this.autoStopComboBox.SelectedIndexChanged += new System.EventHandler(this.autoStopComboBox_SelectedIndexChanged);
            // 
            // themePage
            // 
            this.themePage.BackColor = System.Drawing.Color.White;
            this.themePage.Controls.Add(this.licenseLabel);
            this.themePage.Controls.Add(this.systemThemeRadio);
            this.themePage.Controls.Add(this.darkThemeRadio);
            this.themePage.Controls.Add(this.lightThemeRadio);
            this.themePage.Location = new System.Drawing.Point(4, 20);
            this.themePage.Name = "themePage";
            this.themePage.Padding = new System.Windows.Forms.Padding(3);
            this.themePage.Size = new System.Drawing.Size(288, 168);
            this.themePage.TabIndex = 1;
            this.themePage.Text = "Theme";
            // 
            // systemThemeRadio
            // 
            this.systemThemeRadio.Checked = true;
            this.systemThemeRadio.Location = new System.Drawing.Point(9, 12);
            this.systemThemeRadio.Name = "systemThemeRadio";
            this.systemThemeRadio.Size = new System.Drawing.Size(140, 19);
            this.systemThemeRadio.TabIndex = 0;
            this.systemThemeRadio.TabStop = true;
            this.systemThemeRadio.Text = "Use system setting";
            this.systemThemeRadio.CheckedChanged += new System.EventHandler(this.systemThemeRadio_CheckedChanged);
            // 
            // lightThemeRadio
            // 
            this.lightThemeRadio.Location = new System.Drawing.Point(9, 40);
            this.lightThemeRadio.Name = "lightThemeRadio";
            this.lightThemeRadio.Size = new System.Drawing.Size(60, 19);
            this.lightThemeRadio.TabIndex = 1;
            this.lightThemeRadio.Text = "Light";
            this.lightThemeRadio.CheckedChanged += new System.EventHandler(this.lightThemeRadio_CheckedChanged);
            // 
            // darkThemeRadio
            // 
            this.darkThemeRadio.Location = new System.Drawing.Point(9, 68);
            this.darkThemeRadio.Name = "darkThemeRadio";
            this.darkThemeRadio.Size = new System.Drawing.Size(60, 19);
            this.darkThemeRadio.TabIndex = 2;
            this.darkThemeRadio.Text = "Dark";
            this.darkThemeRadio.CheckedChanged += new System.EventHandler(this.darkThemeRadio_CheckedChanged);
            // 
            // licenseLabel
            // 
            this.licenseLabel.AutoSize = true;
            this.licenseLabel.Location = new System.Drawing.Point(6, 108);
            this.licenseLabel.Name = "licenseLabel";
            this.licenseLabel.Size = new System.Drawing.Size(120, 15);
            this.licenseLabel.TabIndex = 3;
            this.licenseLabel.Text = "* App restart required";
            // 
            // audioPage
            // 
            this.audioPage.BackColor = System.Drawing.Color.White;
            this.audioPage.Controls.Add(this.winSoundBtn);
            this.audioPage.Controls.Add(this.mixerBtn);
            this.audioPage.Location = new System.Drawing.Point(4, 20);
            this.audioPage.Name = "audioPage";
            this.audioPage.Size = new System.Drawing.Size(288, 168);
            this.audioPage.TabIndex = 2;
            this.audioPage.Text = "Audio";
            // 
            // mixerBtn
            // 
            this.mixerBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.mixerBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.mixerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mixerBtn.Image = ((System.Drawing.Image)(resources.GetObject("mixerBtn.Image")));
            this.mixerBtn.Location = new System.Drawing.Point(9, 14);
            this.mixerBtn.Name = "mixerBtn";
            this.mixerBtn.Size = new System.Drawing.Size(268, 40);
            this.mixerBtn.TabIndex = 0;
            this.mixerBtn.Text = " Open volume mixer";
            this.mixerBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mixerBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.mixerBtn.UseVisualStyleBackColor = false;
            this.mixerBtn.Click += new System.EventHandler(this.mixerBtn_Click);
            // 
            // winSoundBtn
            // 
            this.winSoundBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.winSoundBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.winSoundBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.winSoundBtn.Image = ((System.Drawing.Image)(resources.GetObject("winSoundBtn.Image")));
            this.winSoundBtn.Location = new System.Drawing.Point(9, 64);
            this.winSoundBtn.Name = "winSoundBtn";
            this.winSoundBtn.Size = new System.Drawing.Size(268, 40);
            this.winSoundBtn.TabIndex = 1;
            this.winSoundBtn.Text = " Manage audio devices";
            this.winSoundBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.winSoundBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.winSoundBtn.UseVisualStyleBackColor = false;
            this.winSoundBtn.Click += new System.EventHandler(this.winSoundBtn_Click);
            // 
            // updatesPage
            // 
            this.updatesPage.BackColor = System.Drawing.Color.White;
            this.updatesPage.Controls.Add(this.updatesCheckBox);
            this.updatesPage.Controls.Add(this.checkNowBtn);
            this.updatesPage.Location = new System.Drawing.Point(4, 20);
            this.updatesPage.Name = "updatesPage";
            this.updatesPage.Padding = new System.Windows.Forms.Padding(3);
            this.updatesPage.Size = new System.Drawing.Size(288, 168);
            this.updatesPage.TabIndex = 3;
            this.updatesPage.Text = "Updates";
            // 
            // updatesCheckBox
            // 
            this.updatesCheckBox.Location = new System.Drawing.Point(9, 14);
            this.updatesCheckBox.Name = "updatesCheckBox";
            this.updatesCheckBox.Size = new System.Drawing.Size(240, 19);
            this.updatesCheckBox.TabIndex = 0;
            this.updatesCheckBox.Text = "Check for updates on app startup";
            this.updatesCheckBox.CheckedChanged += new System.EventHandler(this.updatesCheckBox_CheckedChanged);
            // 
            // checkNowBtn
            // 
            this.checkNowBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkNowBtn.Location = new System.Drawing.Point(9, 48);
            this.checkNowBtn.Name = "checkNowBtn";
            this.checkNowBtn.Size = new System.Drawing.Size(268, 36);
            this.checkNowBtn.TabIndex = 1;
            this.checkNowBtn.Text = "Check for Updates & Changelog";
            this.checkNowBtn.UseVisualStyleBackColor = false;
            this.checkNowBtn.Click += new System.EventHandler(this.checkNowBtn_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(314, 210);
            this.Controls.Add(this.settingsTabs);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SettingsForm_KeyDown);
            this.settingsTabs.ResumeLayout(false);
            this.recPage.ResumeLayout(false);
            this.recPage.PerformLayout();
            this.themePage.ResumeLayout(false);
            this.themePage.PerformLayout();
            this.audioPage.ResumeLayout(false);
            this.updatesPage.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private QuickLibrary.QlibRadioButton lightThemeRadio;
        private QuickLibrary.QlibRadioButton systemThemeRadio;
        private QuickLibrary.QlibRadioButton darkThemeRadio;
        private QuickLibrary.QlibCheckBox updatesCheckBox;
        private System.Windows.Forms.Button checkNowBtn;
        private QuickLibrary.QlibCheckBox minTaskbarCheckBox;
        private QuickLibrary.QlibCheckBox autoDateCheckBox;
        private QuickLibrary.QlibCheckBox openFolderAfterCheckBox;
        private QuickLibrary.QlibCheckBox timestampOverlayCheckBox;
        private System.Windows.Forms.Label countdownLabel;
        private QuickLibrary.QlibComboBox countdownComboBox;
        private System.Windows.Forms.Label autoStopLabel;
        private QuickLibrary.QlibComboBox autoStopComboBox;
        private System.Windows.Forms.Label licenseLabel;
        private QuickLibrary.QlibTabControl settingsTabs;
        private System.Windows.Forms.TabPage recPage;
        private System.Windows.Forms.TabPage themePage;
        private System.Windows.Forms.TabPage updatesPage;
        private System.Windows.Forms.TabPage audioPage;
        private System.Windows.Forms.Button mixerBtn;
        private System.Windows.Forms.Button winSoundBtn;
    }
}
