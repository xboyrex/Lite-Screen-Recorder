namespace quick_screen_recorder
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.folderTextBox = new System.Windows.Forms.TextBox();
            this.browseFolderBtn = new QuickLibrary.QlibTextButton();
            this.openFolderBtn = new QuickLibrary.QlibTextButton();
            this.folderLabel = new System.Windows.Forms.Label();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.fileLabel = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.qualityLabel = new System.Windows.Forms.Label();
            this.fpsLabel = new System.Windows.Forms.Label();
            this.fpsComboBox = new QuickLibrary.QlibComboBox();
            this.resLabel = new System.Windows.Forms.Label();
            this.resComboBox = new QuickLibrary.QlibComboBox();
            this.areaLabel = new System.Windows.Forms.Label();
            this.videoGroup = new QuickLibrary.QlibGroupBox();
            this.refreshScreensBtn = new System.Windows.Forms.Button();
            this.hideTaskbarCheckBox = new QuickLibrary.QlibCheckBox();
            this.sizelabel = new System.Windows.Forms.Label();
            this.yNumeric = new QuickLibrary.QlibNumericBox();
            this.xNumeric = new QuickLibrary.QlibNumericBox();
            this.locationLabel = new System.Windows.Forms.Label();
            this.widthNumeric = new QuickLibrary.QlibNumericBox();
            this.qualityComboBox = new QuickLibrary.QlibComboBox();
            this.heightNumeric = new QuickLibrary.QlibNumericBox();
            this.areaComboBox = new QuickLibrary.QlibComboBox();
            this.captureCursorCheckBox = new QuickLibrary.QlibCheckBox();
            this.clickEffectCheckBox = new QuickLibrary.QlibCheckBox();
            this.hapticsCheckBox = new QuickLibrary.QlibCheckBox();
            this.inputDeviceLabel = new System.Windows.Forms.Label();
            this.audioGroup = new QuickLibrary.QlibGroupBox();
            this.refreshAudioBtn = new System.Windows.Forms.Button();
            this.inputDeviceComboBox = new QuickLibrary.QlibComboBox();
            this.separateAudioCheckBox = new QuickLibrary.QlibCheckBox();
            this.generalGroup = new QuickLibrary.QlibGroupBox();
            this.aviLabel = new System.Windows.Forms.Label();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.recButton = new System.Windows.Forms.Button();
            this.shotButton = new System.Windows.Forms.Button();
            this.previewBox = new System.Windows.Forms.PictureBox();
            this.brandBadgeBox = new System.Windows.Forms.PictureBox();
            this.tgFooterBtn = new System.Windows.Forms.Button();
            this.ghFooterBtn = new System.Windows.Forms.Button();
            this.toolStrip1 = new QuickLibrary.QlibToolStrip();
            this.previewBtn = new System.Windows.Forms.ToolStripButton();
            this.onTopBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.telegramBtn = new System.Windows.Forms.ToolStripButton();
            this.githubBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsBtn = new System.Windows.Forms.ToolStripButton();
            this.aboutBtn = new System.Windows.Forms.ToolStripButton();
            this.mainTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.videoGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightNumeric)).BeginInit();
            this.audioGroup.SuspendLayout();
            this.generalGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brandBadgeBox)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // recButton
            // 
            this.recButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.recButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.recButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.recButton.Image = ((System.Drawing.Image)(resources.GetObject("recButton.Image")));
            this.recButton.Location = new System.Drawing.Point(9, 9);
            this.recButton.Margin = new System.Windows.Forms.Padding(0);
            this.recButton.Name = "recButton";
            this.recButton.Size = new System.Drawing.Size(112, 40);
            this.recButton.TabIndex = 0;
            this.recButton.Text = " REC (Alt+R)";
            this.recButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.recButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.recButton.UseVisualStyleBackColor = false;
            this.recButton.Click += new System.EventHandler(this.recButton_Click);
            // 
            // shotButton
            // 
            this.shotButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.shotButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.shotButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shotButton.Location = new System.Drawing.Point(126, 9);
            this.shotButton.Margin = new System.Windows.Forms.Padding(0);
            this.shotButton.Name = "shotButton";
            this.shotButton.Size = new System.Drawing.Size(68, 40);
            this.shotButton.TabIndex = 1;
            this.shotButton.Text = "Shot";
            this.mainTooltip.SetToolTip(this.shotButton, "Take Instant PNG Screenshot (Alt+S)");
            this.shotButton.UseVisualStyleBackColor = false;
            this.shotButton.Click += new System.EventHandler(this.shotButton_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.CanOverflow = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.previewBtn,
            this.onTopBtn,
            this.toolStripSeparator1,
            this.telegramBtn,
            this.githubBtn,
            this.toolStripSeparator2,
            this.settingsBtn,
            this.aboutBtn});
            this.toolStrip1.Location = new System.Drawing.Point(198, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(5);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(156, 43);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.TabStop = true;
            // 
            // previewBtn
            // 
            this.previewBtn.AutoSize = false;
            this.previewBtn.CheckOnClick = true;
            this.previewBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.previewBtn.Image = ((System.Drawing.Image)(resources.GetObject("previewBtn.Image")));
            this.previewBtn.Margin = new System.Windows.Forms.Padding(0);
            this.previewBtn.Name = "previewBtn";
            this.previewBtn.Size = new System.Drawing.Size(23, 25);
            this.previewBtn.ToolTipText = "Preview | Ctrl + P";
            this.previewBtn.CheckedChanged += new System.EventHandler(this.previewBtn_CheckedChanged);
            // 
            // onTopBtn
            // 
            this.onTopBtn.AutoSize = false;
            this.onTopBtn.CheckOnClick = true;
            this.onTopBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.onTopBtn.Image = ((System.Drawing.Image)(resources.GetObject("onTopBtn.Image")));
            this.onTopBtn.Margin = new System.Windows.Forms.Padding(0);
            this.onTopBtn.Name = "onTopBtn";
            this.onTopBtn.Size = new System.Drawing.Size(23, 25);
            this.onTopBtn.ToolTipText = "Always on top | Ctrl + T";
            this.onTopBtn.CheckedChanged += new System.EventHandler(this.onTopCheckBox_CheckedChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(2, 16);
            // 
            // telegramBtn
            // 
            this.telegramBtn.AutoSize = false;
            this.telegramBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.telegramBtn.Margin = new System.Windows.Forms.Padding(0);
            this.telegramBtn.Name = "telegramBtn";
            this.telegramBtn.Size = new System.Drawing.Size(23, 25);
            this.telegramBtn.ToolTipText = "Telegram: @MayankDroid7";
            this.telegramBtn.Click += new System.EventHandler(this.telegramBtn_Click);
            // 
            // githubBtn
            // 
            this.githubBtn.AutoSize = false;
            this.githubBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.githubBtn.Margin = new System.Windows.Forms.Padding(0);
            this.githubBtn.Name = "githubBtn";
            this.githubBtn.Size = new System.Drawing.Size(23, 25);
            this.githubBtn.ToolTipText = "GitHub: @xboyrex";
            this.githubBtn.Click += new System.EventHandler(this.githubBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(2, 16);
            // 
            // settingsBtn
            // 
            this.settingsBtn.AutoSize = false;
            this.settingsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.settingsBtn.Image = ((System.Drawing.Image)(resources.GetObject("settingsBtn.Image")));
            this.settingsBtn.Margin = new System.Windows.Forms.Padding(0);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(23, 25);
            this.settingsBtn.ToolTipText = "Settings | Ctrl + Comma";
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // aboutBtn
            // 
            this.aboutBtn.AutoSize = false;
            this.aboutBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.aboutBtn.Image = ((System.Drawing.Image)(resources.GetObject("aboutBtn.Image")));
            this.aboutBtn.Margin = new System.Windows.Forms.Padding(0);
            this.aboutBtn.Name = "aboutBtn";
            this.aboutBtn.Size = new System.Drawing.Size(23, 25);
            this.aboutBtn.ToolTipText = "About | F1";
            this.aboutBtn.Click += new System.EventHandler(this.aboutBtn_Click);
            // 
            // generalGroup
            // 
            this.generalGroup.Controls.Add(this.aviLabel);
            this.generalGroup.Controls.Add(this.folderTextBox);
            this.generalGroup.Controls.Add(this.browseFolderBtn);
            this.generalGroup.Controls.Add(this.openFolderBtn);
            this.generalGroup.Controls.Add(this.folderLabel);
            this.generalGroup.Controls.Add(this.fileNameTextBox);
            this.generalGroup.Controls.Add(this.fileLabel);
            this.generalGroup.Location = new System.Drawing.Point(9, 55);
            this.generalGroup.Name = "generalGroup";
            this.generalGroup.Size = new System.Drawing.Size(340, 86);
            this.generalGroup.TabIndex = 2;
            this.generalGroup.TabStop = false;
            this.generalGroup.Text = "General options";
            // 
            // folderLabel
            // 
            this.folderLabel.AutoSize = true;
            this.folderLabel.Location = new System.Drawing.Point(24, 24);
            this.folderLabel.Name = "folderLabel";
            this.folderLabel.Size = new System.Drawing.Size(43, 15);
            this.folderLabel.TabIndex = 3;
            this.folderLabel.Text = "Folder:";
            // 
            // folderTextBox
            // 
            this.folderTextBox.AllowDrop = true;
            this.folderTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.folderTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.folderTextBox.Location = new System.Drawing.Point(73, 20);
            this.folderTextBox.Name = "folderTextBox";
            this.folderTextBox.Size = new System.Drawing.Size(142, 23);
            this.folderTextBox.TabIndex = 3;
            this.folderTextBox.TextChanged += new System.EventHandler(this.folderTextBox_TextChanged);
            this.folderTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.folderTextBox_DragDrop);
            this.folderTextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.folderTextBox_DragEnter);
            // 
            // browseFolderBtn
            // 
            this.browseFolderBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.browseFolderBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.browseFolderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseFolderBtn.Location = new System.Drawing.Point(220, 20);
            this.browseFolderBtn.Name = "browseFolderBtn";
            this.browseFolderBtn.Size = new System.Drawing.Size(60, 23);
            this.browseFolderBtn.TabIndex = 4;
            this.browseFolderBtn.Text = "Browse";
            this.browseFolderBtn.UseVisualStyleBackColor = false;
            this.browseFolderBtn.Click += new System.EventHandler(this.browseFolderBtn_Click);
            // 
            // openFolderBtn
            // 
            this.openFolderBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.openFolderBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.openFolderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openFolderBtn.Location = new System.Drawing.Point(284, 20);
            this.openFolderBtn.Name = "openFolderBtn";
            this.openFolderBtn.Size = new System.Drawing.Size(50, 23);
            this.openFolderBtn.TabIndex = 5;
            this.openFolderBtn.Text = "Open";
            this.openFolderBtn.UseVisualStyleBackColor = false;
            this.openFolderBtn.Click += new System.EventHandler(this.openFolderBtn_Click);
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Location = new System.Drawing.Point(6, 53);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(61, 15);
            this.fileLabel.TabIndex = 5;
            this.fileLabel.Text = "File name:";
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.fileNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fileNameTextBox.Location = new System.Drawing.Point(73, 50);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(230, 23);
            this.fileNameTextBox.TabIndex = 5;
            this.fileNameTextBox.Text = "NewVideo1";
            // 
            // aviLabel
            // 
            this.aviLabel.AutoSize = true;
            this.aviLabel.Location = new System.Drawing.Point(309, 53);
            this.aviLabel.Name = "aviLabel";
            this.aviLabel.Size = new System.Drawing.Size(25, 15);
            this.aviLabel.TabIndex = 26;
            this.aviLabel.Text = ".avi";
            // 
            // videoGroup
            // 
            this.videoGroup.Controls.Add(this.refreshScreensBtn);
            this.videoGroup.Controls.Add(this.hideTaskbarCheckBox);
            this.videoGroup.Controls.Add(this.sizelabel);
            this.videoGroup.Controls.Add(this.yNumeric);
            this.videoGroup.Controls.Add(this.xNumeric);
            this.videoGroup.Controls.Add(this.locationLabel);
            this.videoGroup.Controls.Add(this.widthNumeric);
            this.videoGroup.Controls.Add(this.qualityComboBox);
            this.videoGroup.Controls.Add(this.fpsLabel);
            this.videoGroup.Controls.Add(this.fpsComboBox);
            this.videoGroup.Controls.Add(this.resLabel);
            this.videoGroup.Controls.Add(this.resComboBox);
            this.videoGroup.Controls.Add(this.heightNumeric);
            this.videoGroup.Controls.Add(this.areaComboBox);
            this.videoGroup.Controls.Add(this.captureCursorCheckBox);
            this.videoGroup.Controls.Add(this.clickEffectCheckBox);
            this.videoGroup.Controls.Add(this.hapticsCheckBox);
            this.videoGroup.Controls.Add(this.areaLabel);
            this.videoGroup.Controls.Add(this.qualityLabel);
            this.videoGroup.Location = new System.Drawing.Point(9, 148);
            this.videoGroup.Name = "videoGroup";
            this.videoGroup.Size = new System.Drawing.Size(340, 168);
            this.videoGroup.TabIndex = 6;
            this.videoGroup.TabStop = false;
            this.videoGroup.Text = "Video options (1080p / 180p & 60FPS Real-Time)";
            // 
            // qualityLabel
            // 
            this.qualityLabel.AutoSize = true;
            this.qualityLabel.Location = new System.Drawing.Point(19, 24);
            this.qualityLabel.Name = "qualityLabel";
            this.qualityLabel.Size = new System.Drawing.Size(48, 15);
            this.qualityLabel.TabIndex = 10;
            this.qualityLabel.Text = "Quality:";
            // 
            // qualityComboBox
            // 
            this.qualityComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.qualityComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.qualityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.qualityComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.qualityComboBox.FormattingEnabled = true;
            this.qualityComboBox.IntegralHeight = false;
            this.qualityComboBox.Items.AddRange(new object[] {
            "25% - Low (MJPEG)",
            "50% - Medium (MJPEG)",
            "75% - High (MJPEG)",
            "90% - Ultra HQ (MJPEG)",
            "100% - Original Max HQ",
            "Uncompressed"});
            this.qualityComboBox.Location = new System.Drawing.Point(73, 20);
            this.qualityComboBox.Name = "qualityComboBox";
            this.qualityComboBox.Size = new System.Drawing.Size(152, 24);
            this.qualityComboBox.TabIndex = 7;
            this.qualityComboBox.SelectedIndexChanged += new System.EventHandler(this.qualityComboBox_SelectedIndexChanged);
            // 
            // fpsLabel
            // 
            this.fpsLabel.AutoSize = true;
            this.fpsLabel.Location = new System.Drawing.Point(230, 24);
            this.fpsLabel.Name = "fpsLabel";
            this.fpsLabel.Size = new System.Drawing.Size(28, 15);
            this.fpsLabel.TabIndex = 11;
            this.fpsLabel.Text = "FPS:";
            // 
            // fpsComboBox
            // 
            this.fpsComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.fpsComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.fpsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fpsComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.fpsComboBox.FormattingEnabled = true;
            this.fpsComboBox.IntegralHeight = false;
            this.fpsComboBox.Items.AddRange(new object[] {
            "15 FPS",
            "24 FPS",
            "30 FPS",
            "60 FPS"});
            this.fpsComboBox.Location = new System.Drawing.Point(260, 20);
            this.fpsComboBox.Name = "fpsComboBox";
            this.fpsComboBox.Size = new System.Drawing.Size(74, 24);
            this.fpsComboBox.TabIndex = 8;
            this.fpsComboBox.SelectedIndexChanged += new System.EventHandler(this.fpsComboBox_SelectedIndexChanged);
            // 
            // resLabel
            // 
            this.resLabel.AutoSize = true;
            this.resLabel.Location = new System.Drawing.Point(11, 53);
            this.resLabel.Name = "resLabel";
            this.resLabel.Size = new System.Drawing.Size(56, 15);
            this.resLabel.TabIndex = 12;
            this.resLabel.Text = "HD Mode:";
            // 
            // resComboBox
            // 
            this.resComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.resComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.resComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.resComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.resComboBox.FormattingEnabled = true;
            this.resComboBox.IntegralHeight = false;
            this.resComboBox.Items.AddRange(new object[] {
            "Native Screen (Original Size)",
            "1080p Full HD (1920x1080 High Quality)",
            "720p HD (1280x720 High Quality)",
            "180p Ultra-Fast (320x180 High Clarity)"});
            this.resComboBox.Location = new System.Drawing.Point(73, 49);
            this.resComboBox.Name = "resComboBox";
            this.resComboBox.Size = new System.Drawing.Size(261, 24);
            this.resComboBox.TabIndex = 9;
            this.resComboBox.SelectedIndexChanged += new System.EventHandler(this.resComboBox_SelectedIndexChanged);
            // 
            // areaLabel
            // 
            this.areaLabel.AutoSize = true;
            this.areaLabel.Location = new System.Drawing.Point(33, 82);
            this.areaLabel.Name = "areaLabel";
            this.areaLabel.Size = new System.Drawing.Size(34, 15);
            this.areaLabel.TabIndex = 18;
            this.areaLabel.Text = "Area:";
            // 
            // areaComboBox
            // 
            this.areaComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.areaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.areaComboBox.FormattingEnabled = true;
            this.areaComboBox.IntegralHeight = false;
            this.areaComboBox.Location = new System.Drawing.Point(73, 79);
            this.areaComboBox.Name = "areaComboBox";
            this.areaComboBox.Size = new System.Drawing.Size(231, 24);
            this.areaComboBox.TabIndex = 10;
            this.areaComboBox.SelectedIndexChanged += new System.EventHandler(this.areaComboBox_SelectedIndexChanged);
            // 
            // refreshScreensBtn
            // 
            this.refreshScreensBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.refreshScreensBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.refreshScreensBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshScreensBtn.Image = ((System.Drawing.Image)(resources.GetObject("refreshScreensBtn.Image")));
            this.refreshScreensBtn.Location = new System.Drawing.Point(311, 79);
            this.refreshScreensBtn.Margin = new System.Windows.Forms.Padding(0);
            this.refreshScreensBtn.Name = "refreshScreensBtn";
            this.refreshScreensBtn.Size = new System.Drawing.Size(23, 23);
            this.refreshScreensBtn.TabIndex = 11;
            this.refreshScreensBtn.UseVisualStyleBackColor = false;
            this.refreshScreensBtn.Click += new System.EventHandler(this.refreshScreensBtn_Click);
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Location = new System.Drawing.Point(11, 111);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(56, 15);
            this.locationLabel.TabIndex = 19;
            this.locationLabel.Text = "Location:";
            // 
            // xNumeric
            // 
            this.xNumeric.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xNumeric.Location = new System.Drawing.Point(73, 109);
            this.xNumeric.Maximum = new decimal(new int[] { 4096, 0, 0, 0 });
            this.xNumeric.Name = "xNumeric";
            this.xNumeric.Size = new System.Drawing.Size(47, 23);
            this.xNumeric.TabIndex = 12;
            this.xNumeric.ValueChanged += new System.EventHandler(this.xNumeric_ValueChanged);
            // 
            // yNumeric
            // 
            this.yNumeric.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.yNumeric.Location = new System.Drawing.Point(127, 109);
            this.yNumeric.Maximum = new decimal(new int[] { 4096, 0, 0, 0 });
            this.yNumeric.Name = "yNumeric";
            this.yNumeric.Size = new System.Drawing.Size(47, 23);
            this.yNumeric.TabIndex = 13;
            this.yNumeric.ValueChanged += new System.EventHandler(this.yNumeric_ValueChanged);
            // 
            // sizelabel
            // 
            this.sizelabel.AutoSize = true;
            this.sizelabel.Location = new System.Drawing.Point(197, 111);
            this.sizelabel.Name = "sizelabel";
            this.sizelabel.Size = new System.Drawing.Size(30, 15);
            this.sizelabel.TabIndex = 22;
            this.sizelabel.Text = "Size:";
            // 
            // widthNumeric
            // 
            this.widthNumeric.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.widthNumeric.Increment = new decimal(new int[] { 2, 0, 0, 0 });
            this.widthNumeric.Location = new System.Drawing.Point(233, 109);
            this.widthNumeric.Maximum = new decimal(new int[] { 4096, 0, 0, 0 });
            this.widthNumeric.Minimum = new decimal(new int[] { 160, 0, 0, 0 });
            this.widthNumeric.Name = "widthNumeric";
            this.widthNumeric.Size = new System.Drawing.Size(47, 23);
            this.widthNumeric.TabIndex = 14;
            this.widthNumeric.Value = new decimal(new int[] { 160, 0, 0, 0 });
            this.widthNumeric.ValueChanged += new System.EventHandler(this.widthNumeric_ValueChanged);
            // 
            // heightNumeric
            // 
            this.heightNumeric.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.heightNumeric.Increment = new decimal(new int[] { 2, 0, 0, 0 });
            this.heightNumeric.Location = new System.Drawing.Point(287, 109);
            this.heightNumeric.Maximum = new decimal(new int[] { 4096, 0, 0, 0 });
            this.heightNumeric.Minimum = new decimal(new int[] { 160, 0, 0, 0 });
            this.heightNumeric.Name = "heightNumeric";
            this.heightNumeric.Size = new System.Drawing.Size(47, 23);
            this.heightNumeric.TabIndex = 15;
            this.heightNumeric.Value = new decimal(new int[] { 160, 0, 0, 0 });
            this.heightNumeric.ValueChanged += new System.EventHandler(this.heightNumeric_ValueChanged);
            // 
            // hideTaskbarCheckBox
            // 
            this.hideTaskbarCheckBox.Location = new System.Drawing.Point(10, 140);
            this.hideTaskbarCheckBox.Name = "hideTaskbarCheckBox";
            this.hideTaskbarCheckBox.Size = new System.Drawing.Size(90, 19);
            this.hideTaskbarCheckBox.TabIndex = 16;
            this.hideTaskbarCheckBox.Text = "Hide taskbar";
            this.hideTaskbarCheckBox.UseVisualStyleBackColor = true;
            this.hideTaskbarCheckBox.CheckedChanged += new System.EventHandler(this.hideTaskbarCheckBox_CheckedChanged);
            // 
            // captureCursorCheckBox
            // 
            this.captureCursorCheckBox.Checked = true;
            this.captureCursorCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.captureCursorCheckBox.Location = new System.Drawing.Point(104, 140);
            this.captureCursorCheckBox.Name = "captureCursorCheckBox";
            this.captureCursorCheckBox.Size = new System.Drawing.Size(64, 19);
            this.captureCursorCheckBox.TabIndex = 17;
            this.captureCursorCheckBox.Text = "Cursor";
            this.captureCursorCheckBox.UseVisualStyleBackColor = true;
            this.captureCursorCheckBox.CheckedChanged += new System.EventHandler(this.captureCursorCheckBox_CheckedChanged);
            // 
            // clickEffectCheckBox
            // 
            this.clickEffectCheckBox.Checked = true;
            this.clickEffectCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.clickEffectCheckBox.Location = new System.Drawing.Point(172, 140);
            this.clickEffectCheckBox.Name = "clickEffectCheckBox";
            this.clickEffectCheckBox.Size = new System.Drawing.Size(78, 19);
            this.clickEffectCheckBox.TabIndex = 18;
            this.clickEffectCheckBox.Text = "Click FX";
            this.clickEffectCheckBox.UseVisualStyleBackColor = true;
            this.clickEffectCheckBox.CheckedChanged += new System.EventHandler(this.clickEffectCheckBox_CheckedChanged);
            // 
            // hapticsCheckBox
            // 
            this.hapticsCheckBox.Checked = true;
            this.hapticsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hapticsCheckBox.Location = new System.Drawing.Point(254, 140);
            this.hapticsCheckBox.Name = "hapticsCheckBox";
            this.hapticsCheckBox.Size = new System.Drawing.Size(78, 19);
            this.hapticsCheckBox.TabIndex = 19;
            this.hapticsCheckBox.Text = "Haptics";
            this.hapticsCheckBox.UseVisualStyleBackColor = true;
            this.hapticsCheckBox.CheckedChanged += new System.EventHandler(this.hapticsCheckBox_CheckedChanged);
            // 
            // audioGroup
            // 
            this.audioGroup.Controls.Add(this.refreshAudioBtn);
            this.audioGroup.Controls.Add(this.inputDeviceComboBox);
            this.audioGroup.Controls.Add(this.separateAudioCheckBox);
            this.audioGroup.Controls.Add(this.inputDeviceLabel);
            this.audioGroup.Location = new System.Drawing.Point(9, 323);
            this.audioGroup.Name = "audioGroup";
            this.audioGroup.Size = new System.Drawing.Size(340, 78);
            this.audioGroup.TabIndex = 16;
            this.audioGroup.TabStop = false;
            this.audioGroup.Text = "Audio options";
            // 
            // inputDeviceLabel
            // 
            this.inputDeviceLabel.AutoSize = true;
            this.inputDeviceLabel.Location = new System.Drawing.Point(29, 25);
            this.inputDeviceLabel.Name = "inputDeviceLabel";
            this.inputDeviceLabel.Size = new System.Drawing.Size(38, 15);
            this.inputDeviceLabel.TabIndex = 26;
            this.inputDeviceLabel.Text = "Input:";
            // 
            // inputDeviceComboBox
            // 
            this.inputDeviceComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.inputDeviceComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.inputDeviceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputDeviceComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.inputDeviceComboBox.FormattingEnabled = true;
            this.inputDeviceComboBox.IntegralHeight = false;
            this.inputDeviceComboBox.Items.AddRange(new object[] {
            "None",
            "System sounds (Soundcard)"});
            this.inputDeviceComboBox.Location = new System.Drawing.Point(73, 21);
            this.inputDeviceComboBox.Name = "inputDeviceComboBox";
            this.inputDeviceComboBox.Size = new System.Drawing.Size(231, 24);
            this.inputDeviceComboBox.TabIndex = 17;
            this.inputDeviceComboBox.SelectedIndexChanged += new System.EventHandler(this.inputDeviceComboBox_SelectedIndexChanged);
            // 
            // refreshAudioBtn
            // 
            this.refreshAudioBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.refreshAudioBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.refreshAudioBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshAudioBtn.Image = ((System.Drawing.Image)(resources.GetObject("refreshAudioBtn.Image")));
            this.refreshAudioBtn.Location = new System.Drawing.Point(311, 21);
            this.refreshAudioBtn.Margin = new System.Windows.Forms.Padding(0);
            this.refreshAudioBtn.Name = "refreshAudioBtn";
            this.refreshAudioBtn.Size = new System.Drawing.Size(23, 23);
            this.refreshAudioBtn.TabIndex = 18;
            this.refreshAudioBtn.UseVisualStyleBackColor = false;
            this.refreshAudioBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // separateAudioCheckBox
            // 
            this.separateAudioCheckBox.Location = new System.Drawing.Point(123, 51);
            this.separateAudioCheckBox.Name = "separateAudioCheckBox";
            this.separateAudioCheckBox.Size = new System.Drawing.Size(211, 19);
            this.separateAudioCheckBox.TabIndex = 19;
            this.separateAudioCheckBox.Text = "Write audio to a separate file (.wav)";
            this.separateAudioCheckBox.UseVisualStyleBackColor = true;
            // 
            // brandBadgeBox
            // 
            this.brandBadgeBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.brandBadgeBox.Location = new System.Drawing.Point(9, 408);
            this.brandBadgeBox.Name = "brandBadgeBox";
            this.brandBadgeBox.Size = new System.Drawing.Size(220, 26);
            this.brandBadgeBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.brandBadgeBox.TabIndex = 27;
            this.brandBadgeBox.TabStop = false;
            this.mainTooltip.SetToolTip(this.brandBadgeBox, "Created by ㅤᏞᴀᴢʏㅤᎷꫝʏᴀɴк まやんく (@xboyrex)");
            this.brandBadgeBox.Click += new System.EventHandler(this.brandBadgeBox_Click);
            // 
            // tgFooterBtn
            // 
            this.tgFooterBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tgFooterBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tgFooterBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.tgFooterBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tgFooterBtn.Location = new System.Drawing.Point(287, 407);
            this.tgFooterBtn.Name = "tgFooterBtn";
            this.tgFooterBtn.Size = new System.Drawing.Size(28, 28);
            this.tgFooterBtn.TabIndex = 28;
            this.mainTooltip.SetToolTip(this.tgFooterBtn, "Direct Telegram: @MayankDroid7");
            this.tgFooterBtn.UseVisualStyleBackColor = false;
            this.tgFooterBtn.Click += new System.EventHandler(this.telegramBtn_Click);
            // 
            // ghFooterBtn
            // 
            this.ghFooterBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ghFooterBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ghFooterBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.ghFooterBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ghFooterBtn.Location = new System.Drawing.Point(321, 407);
            this.ghFooterBtn.Name = "ghFooterBtn";
            this.ghFooterBtn.Size = new System.Drawing.Size(28, 28);
            this.ghFooterBtn.TabIndex = 29;
            this.mainTooltip.SetToolTip(this.ghFooterBtn, "GitHub Profile: @xboyrex");
            this.ghFooterBtn.UseVisualStyleBackColor = false;
            this.ghFooterBtn.Click += new System.EventHandler(this.githubBtn_Click);
            // 
            // previewBox
            // 
            this.previewBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previewBox.BackColor = System.Drawing.Color.Black;
            this.previewBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewBox.Location = new System.Drawing.Point(358, 9);
            this.previewBox.Margin = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(437, 426);
            this.previewBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.previewBox.TabIndex = 26;
            this.previewBox.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(804, 444);
            this.Controls.Add(this.ghFooterBtn);
            this.Controls.Add(this.tgFooterBtn);
            this.Controls.Add(this.brandBadgeBox);
            this.Controls.Add(this.previewBox);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.generalGroup);
            this.Controls.Add(this.audioGroup);
            this.Controls.Add(this.videoGroup);
            this.Controls.Add(this.shotButton);
            this.Controls.Add(this.recButton);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lite Screen Recorder";
            this.TransparencyKey = System.Drawing.Color.MediumBlue;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.videoGroup.ResumeLayout(false);
            this.videoGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightNumeric)).EndInit();
            this.audioGroup.ResumeLayout(false);
            this.audioGroup.PerformLayout();
            this.generalGroup.ResumeLayout(false);
            this.generalGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brandBadgeBox)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button recButton;
        private System.Windows.Forms.Button shotButton;
        private System.Windows.Forms.TextBox folderTextBox;
        private QuickLibrary.QlibTextButton browseFolderBtn;
        private QuickLibrary.QlibTextButton openFolderBtn;
        private System.Windows.Forms.Label folderLabel;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.Label fileLabel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label qualityLabel;
        private System.Windows.Forms.Label fpsLabel;
        private QuickLibrary.QlibComboBox fpsComboBox;
        private System.Windows.Forms.Label resLabel;
        private QuickLibrary.QlibComboBox resComboBox;
        private System.Windows.Forms.Label areaLabel;
        private QuickLibrary.QlibGroupBox videoGroup;
        private QuickLibrary.QlibCheckBox captureCursorCheckBox;
        private QuickLibrary.QlibCheckBox clickEffectCheckBox;
        private QuickLibrary.QlibCheckBox hapticsCheckBox;
        private System.Windows.Forms.Label inputDeviceLabel;
        private QuickLibrary.QlibGroupBox audioGroup;
        private QuickLibrary.QlibGroupBox generalGroup;
        private System.Windows.Forms.Label aviLabel;
        private System.Windows.Forms.Timer updateTimer;
        private QuickLibrary.QlibComboBox areaComboBox;
        private QuickLibrary.QlibComboBox qualityComboBox;
        private QuickLibrary.QlibComboBox inputDeviceComboBox;
        private QuickLibrary.QlibNumericBox heightNumeric;
        private QuickLibrary.QlibNumericBox widthNumeric;
        private System.Windows.Forms.Button refreshAudioBtn;
        private QuickLibrary.QlibToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton onTopBtn;
        private System.Windows.Forms.ToolStripButton telegramBtn;
        private System.Windows.Forms.ToolStripButton githubBtn;
        private System.Windows.Forms.ToolStripButton aboutBtn;
        private System.Windows.Forms.ToolStripButton settingsBtn;
        private QuickLibrary.QlibCheckBox separateAudioCheckBox;
        private System.Windows.Forms.Label locationLabel;
        private QuickLibrary.QlibNumericBox xNumeric;
        private QuickLibrary.QlibNumericBox yNumeric;
        private System.Windows.Forms.Label sizelabel;
        private QuickLibrary.QlibCheckBox hideTaskbarCheckBox;
        private System.Windows.Forms.Button refreshScreensBtn;
        private System.Windows.Forms.PictureBox previewBox;
        private System.Windows.Forms.PictureBox brandBadgeBox;
        private System.Windows.Forms.Button tgFooterBtn;
        private System.Windows.Forms.Button ghFooterBtn;
        private System.Windows.Forms.ToolStripButton previewBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolTip mainTooltip;
    }
}
