namespace quick_screen_recorder
{
    partial class AboutForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.productLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.companyLabel = new System.Windows.Forms.Label();
            this.authorLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.developerLink = new System.Windows.Forms.LinkLabel();
            this.projectLink = new System.Windows.Forms.LinkLabel();
            this.youtubeLink = new System.Windows.Forms.LinkLabel();
            this.telegramLink = new System.Windows.Forms.LinkLabel();
            this.infoGroup = new QuickLibrary.QlibGroupBox();
            this.licenseLabel = new System.Windows.Forms.Label();
            this.updatesLink = new System.Windows.Forms.LinkLabel();
            this.pagesGroup = new QuickLibrary.QlibGroupBox();
            this.aboutTooltip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.infoGroup.SuspendLayout();
            this.pagesGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
            this.logoPictureBox.Location = new System.Drawing.Point(9, 9);
            this.logoPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(256, 80);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.logoPictureBox.TabIndex = 12;
            this.logoPictureBox.TabStop = false;
            // 
            // productLabel
            // 
            this.productLabel.AutoSize = true;
            this.productLabel.Location = new System.Drawing.Point(6, 28);
            this.productLabel.Name = "productLabel";
            this.productLabel.Size = new System.Drawing.Size(120, 15);
            this.productLabel.TabIndex = 27;
            this.productLabel.Text = "Lite Screen Recorder";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(6, 49);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(45, 15);
            this.versionLabel.TabIndex = 28;
            this.versionLabel.Text = "Version";
            // 
            // updatesLink
            // 
            this.updatesLink.AutoSize = true;
            this.updatesLink.Location = new System.Drawing.Point(6, 76);
            this.updatesLink.Name = "updatesLink";
            this.updatesLink.Size = new System.Drawing.Size(103, 15);
            this.updatesLink.TabIndex = 0;
            this.updatesLink.TabStop = true;
            this.updatesLink.Text = "Check for updates";
            this.updatesLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.updatesLink_LinkClicked);
            // 
            // companyLabel
            // 
            this.companyLabel.AutoSize = true;
            this.companyLabel.Location = new System.Drawing.Point(6, 103);
            this.companyLabel.Name = "companyLabel";
            this.companyLabel.Size = new System.Drawing.Size(145, 15);
            this.companyLabel.TabIndex = 29;
            this.companyLabel.Text = "Created by Mayank Droid";
            // 
            // authorLabel
            // 
            this.authorLabel.AutoSize = true;
            this.authorLabel.Location = new System.Drawing.Point(6, 124);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(150, 15);
            this.authorLabel.TabIndex = 30;
            this.authorLabel.Text = "Developer: @xboyrex";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(6, 151);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(221, 30);
            this.descriptionLabel.TabIndex = 31;
            this.descriptionLabel.Text = "Lightweight desktop screen recorder for\r\nWindows, built on top of WinForms (C#)";
            // 
            // licenseLabel
            // 
            this.licenseLabel.AutoSize = true;
            this.licenseLabel.Location = new System.Drawing.Point(6, 193);
            this.licenseLabel.Name = "licenseLabel";
            this.licenseLabel.Size = new System.Drawing.Size(93, 15);
            this.licenseLabel.TabIndex = 37;
            this.licenseLabel.Text = "License: GPL-3.0";
            // 
            // infoGroup
            // 
            this.infoGroup.Controls.Add(this.licenseLabel);
            this.infoGroup.Controls.Add(this.updatesLink);
            this.infoGroup.Controls.Add(this.versionLabel);
            this.infoGroup.Controls.Add(this.companyLabel);
            this.infoGroup.Controls.Add(this.productLabel);
            this.infoGroup.Controls.Add(this.descriptionLabel);
            this.infoGroup.Controls.Add(this.authorLabel);
            this.infoGroup.Location = new System.Drawing.Point(9, 98);
            this.infoGroup.Name = "infoGroup";
            this.infoGroup.Size = new System.Drawing.Size(256, 226);
            this.infoGroup.TabIndex = 34;
            this.infoGroup.TabStop = false;
            this.infoGroup.Text = "Info";
            // 
            // developerLink
            // 
            this.developerLink.AutoSize = true;
            this.developerLink.Location = new System.Drawing.Point(8, 28);
            this.developerLink.Name = "developerLink";
            this.developerLink.Size = new System.Drawing.Size(55, 15);
            this.developerLink.TabIndex = 2;
            this.developerLink.TabStop = true;
            this.developerLink.Text = "@xboyrex";
            this.developerLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.developerLink_LinkClicked);
            // 
            // projectLink
            // 
            this.projectLink.AutoSize = true;
            this.projectLink.Location = new System.Drawing.Point(74, 28);
            this.projectLink.Name = "projectLink";
            this.projectLink.Size = new System.Drawing.Size(52, 15);
            this.projectLink.TabIndex = 3;
            this.projectLink.TabStop = true;
            this.projectLink.Text = "GitHub";
            this.projectLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.projectLink_LinkClicked);
            // 
            // youtubeLink
            // 
            this.youtubeLink.AutoSize = true;
            this.youtubeLink.Location = new System.Drawing.Point(132, 28);
            this.youtubeLink.Name = "youtubeLink";
            this.youtubeLink.Size = new System.Drawing.Size(54, 15);
            this.youtubeLink.TabIndex = 4;
            this.youtubeLink.TabStop = true;
            this.youtubeLink.Text = "YouTube";
            this.youtubeLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.youtubeLink_LinkClicked);
            // 
            // telegramLink
            // 
            this.telegramLink.AutoSize = true;
            this.telegramLink.Location = new System.Drawing.Point(194, 28);
            this.telegramLink.Name = "telegramLink";
            this.telegramLink.Size = new System.Drawing.Size(56, 15);
            this.telegramLink.TabIndex = 5;
            this.telegramLink.TabStop = true;
            this.telegramLink.Text = "Telegram";
            this.telegramLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.telegramLink_LinkClicked);
            // 
            // pagesGroup
            // 
            this.pagesGroup.Controls.Add(this.telegramLink);
            this.pagesGroup.Controls.Add(this.developerLink);
            this.pagesGroup.Controls.Add(this.projectLink);
            this.pagesGroup.Controls.Add(this.youtubeLink);
            this.pagesGroup.Location = new System.Drawing.Point(9, 333);
            this.pagesGroup.Name = "pagesGroup";
            this.pagesGroup.Size = new System.Drawing.Size(256, 63);
            this.pagesGroup.TabIndex = 37;
            this.pagesGroup.TabStop = false;
            this.pagesGroup.Text = "Links";
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(274, 404);
            this.Controls.Add(this.pagesGroup);
            this.Controls.Add(this.infoGroup);
            this.Controls.Add(this.logoPictureBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AboutForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.infoGroup.ResumeLayout(false);
            this.infoGroup.PerformLayout();
            this.pagesGroup.ResumeLayout(false);
            this.pagesGroup.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label productLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label companyLabel;
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.LinkLabel developerLink;
        private System.Windows.Forms.LinkLabel projectLink;
        private System.Windows.Forms.LinkLabel youtubeLink;
        private System.Windows.Forms.LinkLabel telegramLink;
        private QuickLibrary.QlibGroupBox infoGroup;
        private System.Windows.Forms.LinkLabel updatesLink;
        private QuickLibrary.QlibGroupBox pagesGroup;
        private System.Windows.Forms.Label licenseLabel;
        private System.Windows.Forms.ToolTip aboutTooltip;
    }
}
