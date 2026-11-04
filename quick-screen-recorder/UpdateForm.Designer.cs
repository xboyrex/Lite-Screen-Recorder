namespace quick_screen_recorder
{
    partial class UpdateForm
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
            this.statusGroup = new QuickLibrary.QlibGroupBox();
            this.statusBannerLabel = new System.Windows.Forms.Label();
            this.currentVerLabel = new System.Windows.Forms.Label();
            this.latestVerLabel = new System.Windows.Forms.Label();
            this.downloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.progressStatusLabel = new System.Windows.Forms.Label();
            this.changelogGroup = new QuickLibrary.QlibGroupBox();
            this.changelogTextBox = new System.Windows.Forms.TextBox();
            this.updateNowBtn = new System.Windows.Forms.Button();
            this.refreshCheckBtn = new System.Windows.Forms.Button();
            this.openGithubBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.statusGroup.SuspendLayout();
            this.changelogGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusGroup
            // 
            this.statusGroup.Controls.Add(this.statusBannerLabel);
            this.statusGroup.Controls.Add(this.currentVerLabel);
            this.statusGroup.Controls.Add(this.latestVerLabel);
            this.statusGroup.Controls.Add(this.downloadProgressBar);
            this.statusGroup.Controls.Add(this.progressStatusLabel);
            this.statusGroup.Location = new System.Drawing.Point(12, 10);
            this.statusGroup.Name = "statusGroup";
            this.statusGroup.Size = new System.Drawing.Size(536, 132);
            this.statusGroup.TabIndex = 0;
            this.statusGroup.TabStop = false;
            this.statusGroup.Text = "Auto-Updater — Lite Screen Recorder (@xboyrex)";
            // 
            // statusBannerLabel
            // 
            this.statusBannerLabel.AutoSize = true;
            this.statusBannerLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.statusBannerLabel.Location = new System.Drawing.Point(12, 24);
            this.statusBannerLabel.Name = "statusBannerLabel";
            this.statusBannerLabel.Size = new System.Drawing.Size(320, 19);
            this.statusBannerLabel.TabIndex = 0;
            this.statusBannerLabel.Text = "Checking for updates...";
            // 
            // currentVerLabel
            // 
            this.currentVerLabel.AutoSize = true;
            this.currentVerLabel.Location = new System.Drawing.Point(12, 50);
            this.currentVerLabel.Name = "currentVerLabel";
            this.currentVerLabel.Size = new System.Drawing.Size(160, 15);
            this.currentVerLabel.TabIndex = 1;
            this.currentVerLabel.Text = "Installed Version: v2.0.0";
            // 
            // latestVerLabel
            // 
            this.latestVerLabel.AutoSize = true;
            this.latestVerLabel.Location = new System.Drawing.Point(250, 50);
            this.latestVerLabel.Name = "latestVerLabel";
            this.latestVerLabel.Size = new System.Drawing.Size(180, 15);
            this.latestVerLabel.TabIndex = 2;
            this.latestVerLabel.Text = "Latest GitHub Release: v2.0.0";
            // 
            // downloadProgressBar
            // 
            this.downloadProgressBar.Location = new System.Drawing.Point(12, 76);
            this.downloadProgressBar.Name = "downloadProgressBar";
            this.downloadProgressBar.Size = new System.Drawing.Size(510, 18);
            this.downloadProgressBar.TabIndex = 3;
            // 
            // progressStatusLabel
            // 
            this.progressStatusLabel.AutoSize = true;
            this.progressStatusLabel.Location = new System.Drawing.Point(12, 102);
            this.progressStatusLabel.Name = "progressStatusLabel";
            this.progressStatusLabel.Size = new System.Drawing.Size(260, 15);
            this.progressStatusLabel.TabIndex = 4;
            this.progressStatusLabel.Text = "Ready.";
            // 
            // changelogGroup
            // 
            this.changelogGroup.Controls.Add(this.changelogTextBox);
            this.changelogGroup.Location = new System.Drawing.Point(12, 148);
            this.changelogGroup.Name = "changelogGroup";
            this.changelogGroup.Size = new System.Drawing.Size(536, 240);
            this.changelogGroup.TabIndex = 1;
            this.changelogGroup.TabStop = false;
            this.changelogGroup.Text = "Release Notes & What's New (Changelog)";
            // 
            // changelogTextBox
            // 
            this.changelogTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.changelogTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular);
            this.changelogTextBox.Location = new System.Drawing.Point(12, 24);
            this.changelogTextBox.Multiline = true;
            this.changelogTextBox.Name = "changelogTextBox";
            this.changelogTextBox.ReadOnly = true;
            this.changelogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.changelogTextBox.Size = new System.Drawing.Size(510, 204);
            this.changelogTextBox.TabIndex = 0;
            // 
            // updateNowBtn
            // 
            this.updateNowBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateNowBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.updateNowBtn.Location = new System.Drawing.Point(12, 398);
            this.updateNowBtn.Name = "updateNowBtn";
            this.updateNowBtn.Size = new System.Drawing.Size(215, 34);
            this.updateNowBtn.TabIndex = 2;
            this.updateNowBtn.Text = "⬇ Download & Auto-Update Now";
            this.updateNowBtn.UseVisualStyleBackColor = false;
            this.updateNowBtn.Click += new System.EventHandler(this.updateNowBtn_Click);
            // 
            // refreshCheckBtn
            // 
            this.refreshCheckBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshCheckBtn.Location = new System.Drawing.Point(235, 398);
            this.refreshCheckBtn.Name = "refreshCheckBtn";
            this.refreshCheckBtn.Size = new System.Drawing.Size(105, 34);
            this.refreshCheckBtn.TabIndex = 3;
            this.refreshCheckBtn.Text = "🔄 Check Now";
            this.refreshCheckBtn.UseVisualStyleBackColor = false;
            this.refreshCheckBtn.Click += new System.EventHandler(this.refreshCheckBtn_Click);
            // 
            // openGithubBtn
            // 
            this.openGithubBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openGithubBtn.Location = new System.Drawing.Point(348, 398);
            this.openGithubBtn.Name = "openGithubBtn";
            this.openGithubBtn.Size = new System.Drawing.Size(115, 34);
            this.openGithubBtn.TabIndex = 4;
            this.openGithubBtn.Text = "🌐 GitHub Repo";
            this.openGithubBtn.UseVisualStyleBackColor = false;
            this.openGithubBtn.Click += new System.EventHandler(this.openGithubBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Location = new System.Drawing.Point(471, 398);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(77, 34);
            this.closeBtn.TabIndex = 5;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(560, 444);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.openGithubBtn);
            this.Controls.Add(this.refreshCheckBtn);
            this.Controls.Add(this.updateNowBtn);
            this.Controls.Add(this.changelogGroup);
            this.Controls.Add(this.statusGroup);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Software Updater & Changelog — Lite Screen Recorder";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UpdateForm_KeyDown);
            this.statusGroup.ResumeLayout(false);
            this.statusGroup.PerformLayout();
            this.changelogGroup.ResumeLayout(false);
            this.changelogGroup.PerformLayout();
            this.ResumeLayout(false);
        }

        private QuickLibrary.QlibGroupBox statusGroup;
        private System.Windows.Forms.Label statusBannerLabel;
        private System.Windows.Forms.Label currentVerLabel;
        private System.Windows.Forms.Label latestVerLabel;
        private System.Windows.Forms.ProgressBar downloadProgressBar;
        private System.Windows.Forms.Label progressStatusLabel;
        private QuickLibrary.QlibGroupBox changelogGroup;
        private System.Windows.Forms.TextBox changelogTextBox;
        private System.Windows.Forms.Button updateNowBtn;
        private System.Windows.Forms.Button refreshCheckBtn;
        private System.Windows.Forms.Button openGithubBtn;
        private System.Windows.Forms.Button closeBtn;
    }
}
