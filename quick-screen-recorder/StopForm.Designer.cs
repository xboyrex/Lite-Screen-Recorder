namespace quick_screen_recorder
{
    partial class StopForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StopForm));
            this.timeLabel = new System.Windows.Forms.Label();
            this.stopButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.videoLabel = new System.Windows.Forms.Label();
            this.audioLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.volumeLabel = new System.Windows.Forms.Label();
            this.muteCheckBox = new QuickLibrary.QlibCheckBox();
            this.optionsGroup = new QuickLibrary.QlibGroupBox();
            this.optionsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.stopButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.stopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopButton.Image = ((System.Drawing.Image)(resources.GetObject("stopButton.Image")));
            this.stopButton.Location = new System.Drawing.Point(9, 9);
            this.stopButton.Margin = new System.Windows.Forms.Padding(0);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(112, 40);
            this.stopButton.TabIndex = 0;
            this.stopButton.Text = " STOP (Alt+R)";
            this.stopButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.stopButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Click += new System.EventHandler(this.recButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pauseButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.pauseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pauseButton.Location = new System.Drawing.Point(126, 9);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(58, 40);
            this.pauseButton.TabIndex = 1;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = false;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Consolas", 12.5F, System.Drawing.FontStyle.Regular);
            this.timeLabel.Location = new System.Drawing.Point(190, 19);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(90, 19);
            this.timeLabel.TabIndex = 23;
            this.timeLabel.Text = "00:00.000";
            // 
            // mainTimer
            // 
            this.mainTimer.Interval = 50;
            this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
            // 
            // videoLabel
            // 
            this.videoLabel.AutoSize = true;
            this.videoLabel.Location = new System.Drawing.Point(6, 28);
            this.videoLabel.Margin = new System.Windows.Forms.Padding(3, 9, 3, 0);
            this.videoLabel.Name = "videoLabel";
            this.videoLabel.Size = new System.Drawing.Size(57, 15);
            this.videoLabel.TabIndex = 25;
            this.videoLabel.Text = "Video: {0}";
            // 
            // audioLabel
            // 
            this.audioLabel.AutoSize = true;
            this.audioLabel.Location = new System.Drawing.Point(6, 52);
            this.audioLabel.Margin = new System.Windows.Forms.Padding(3, 9, 3, 0);
            this.audioLabel.Name = "audioLabel";
            this.audioLabel.Size = new System.Drawing.Size(59, 15);
            this.audioLabel.TabIndex = 26;
            this.audioLabel.Text = "Audio: {0}";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(59, 80);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(201, 8);
            this.progressBar1.TabIndex = 27;
            // 
            // volumeLabel
            // 
            this.volumeLabel.AutoSize = true;
            this.volumeLabel.Location = new System.Drawing.Point(6, 76);
            this.volumeLabel.Margin = new System.Windows.Forms.Padding(3, 9, 3, 0);
            this.volumeLabel.Name = "volumeLabel";
            this.volumeLabel.Size = new System.Drawing.Size(50, 15);
            this.volumeLabel.TabIndex = 28;
            this.volumeLabel.Text = "Volume:";
            // 
            // muteCheckBox
            // 
            this.muteCheckBox.Location = new System.Drawing.Point(161, 96);
            this.muteCheckBox.Name = "muteCheckBox";
            this.muteCheckBox.Size = new System.Drawing.Size(99, 19);
            this.muteCheckBox.TabIndex = 29;
            this.muteCheckBox.Text = "Mute (Alt+M)";
            this.muteCheckBox.UseVisualStyleBackColor = true;
            this.muteCheckBox.CheckedChanged += new System.EventHandler(this.muteCheckBox_CheckedChanged);
            // 
            // optionsGroup
            // 
            this.optionsGroup.Controls.Add(this.videoLabel);
            this.optionsGroup.Controls.Add(this.muteCheckBox);
            this.optionsGroup.Controls.Add(this.audioLabel);
            this.optionsGroup.Controls.Add(this.progressBar1);
            this.optionsGroup.Controls.Add(this.volumeLabel);
            this.optionsGroup.Location = new System.Drawing.Point(9, 58);
            this.optionsGroup.Margin = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.optionsGroup.Name = "optionsGroup";
            this.optionsGroup.Size = new System.Drawing.Size(266, 123);
            this.optionsGroup.TabIndex = 30;
            this.optionsGroup.TabStop = false;
            this.optionsGroup.Text = "Options";
            // 
            // StopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(284, 189);
            this.Controls.Add(this.optionsGroup);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.timeLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StopForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recording - Lite Screen Recorder";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StopForm_FormClosing);
            this.Load += new System.EventHandler(this.StopForm_Load);
            this.optionsGroup.ResumeLayout(false);
            this.optionsGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Timer mainTimer;
        private System.Windows.Forms.Label videoLabel;
        private System.Windows.Forms.Label audioLabel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label volumeLabel;
        private QuickLibrary.QlibCheckBox muteCheckBox;
        private QuickLibrary.QlibGroupBox optionsGroup;
    }
}
