using QuickLibrary;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quick_screen_recorder
{
    public partial class StopForm : Form
    {
        private MainForm mainFormRef;
        private DateTime startTime;
        private TimeSpan pausedAccumulated = TimeSpan.Zero;
        private DateTime pauseStartMoment;
        private bool isPaused = false;
        private int countdownSeconds = 0;
        private int autoStopSeconds = 0;
        private bool minimizeToTaskbar = true;
        private bool recordingStarted = false;
        private Action onStartRecordingCallback;

        public StopForm(
            MainForm mainForm,
            bool darkMode,
            string videoStr,
            string audioStr,
            int countdownSeconds,
            int autoStopSeconds,
            bool minimizeToTaskbar,
            Action onStartRecordingCallback)
        {
            if (darkMode)
            {
                this.HandleCreated += new EventHandler(ThemeManager.formHandleCreated);
            }

            this.mainFormRef = mainForm;
            this.countdownSeconds = countdownSeconds;
            this.autoStopSeconds = autoStopSeconds;
            this.minimizeToTaskbar = minimizeToTaskbar;
            this.onStartRecordingCallback = onStartRecordingCallback;

            InitializeComponent();

            this.ShowInTaskbar = true;

            videoLabel.Text = string.Format(videoLabel.Text, videoStr);
            audioLabel.Text = string.Format(audioLabel.Text, audioStr);

            if (audioStr == "None")
            {
                muteCheckBox.Enabled = false;
            }

            if (darkMode)
            {
                this.ForeColor = Color.White;
                this.BackColor = ThemeManager.DarkBackColor;

                stopButton.BackColor = ThemeManager.DarkSecondColor;
                stopButton.Image = Properties.Resources.white_stop;

                pauseButton.BackColor = ThemeManager.DarkSecondColor;
                pauseButton.ForeColor = Color.White;

                muteCheckBox.SetDarkMode(true);
            }

            optionsGroup.SetDarkMode(darkMode);
        }

        private void BeginCaptureSession()
        {
            if (countdownSeconds > 0)
            {
                pauseButton.Enabled = false;
                Task.Factory.StartNew(() =>
                {
                    for (int s = countdownSeconds; s >= 1; s--)
                    {
                        int rem = s;
                        if (this.IsDisposed) return;
                        try
                        {
                            this.Invoke((MethodInvoker)(() =>
                            {
                                timeLabel.Text = string.Format("In {0}s...", rem);
                                this.Text = string.Format("Starting in {0}s - Lite Screen Recorder", rem);
                            }));
                        }
                        catch { return; }
                        Thread.Sleep(1000);
                    }
                    if (this.IsDisposed) return;
                    try
                    {
                        this.Invoke((MethodInvoker)(() =>
                        {
                            LaunchRecorderNow();
                        }));
                    }
                    catch { }
                });
            }
            else
            {
                LaunchRecorderNow();
            }
        }

        private void LaunchRecorderNow()
        {
            if (minimizeToTaskbar)
            {
                this.WindowState = FormWindowState.Minimized;
                Application.DoEvents();
            }

            if (onStartRecordingCallback != null)
            {
                onStartRecordingCallback();
            }

            this.startTime = DateTime.Now;
            this.recordingStarted = true;
            pauseButton.Enabled = true;
            mainTimer.Start();
        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            if (!recordingStarted || isPaused)
            {
                return;
            }

            DateTime tickTime = DateTime.Now;
            TimeSpan result = (tickTime - startTime) - pausedAccumulated;
            if (result < TimeSpan.Zero) result = TimeSpan.Zero;

            int totalMins = (int)result.TotalMinutes;
            timeLabel.Text = string.Format("{0:D2}:{1:D2}.{2:D3}", totalMins, result.Seconds, result.Milliseconds);
            this.Text = string.Format("{0:D2}:{1:D2} - Lite Screen Recorder", totalMins, result.Seconds);

            if (autoStopSeconds > 0 && result.TotalSeconds >= autoStopSeconds)
            {
                mainTimer.Stop();
                this.Close();
            }
        }

        private void recButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            TogglePauseState();
        }

        private void TogglePauseState()
        {
            if (!recordingStarted || mainFormRef == null) return;

            if (!isPaused)
            {
                isPaused = true;
                pauseStartMoment = DateTime.Now;
                mainFormRef.TogglePauseRecorder(true);
                pauseButton.Text = "Resume";
                this.Text = "Paused - Lite Screen Recorder";
            }
            else
            {
                pausedAccumulated += (DateTime.Now - pauseStartMoment);
                isPaused = false;
                mainFormRef.TogglePauseRecorder(false);
                pauseButton.Text = "Pause";
            }
        }

        private void StopForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainTimer.Stop();

            HotkeyManager.UnregisterHotKey(this.Handle, 0);
            HotkeyManager.UnregisterHotKey(this.Handle, 1);
            HotkeyManager.UnregisterHotKey(this.Handle, 2);

            if (mainFormRef != null)
            {
                mainFormRef.StopRec();
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
                        this.Close();
                    }
                    else if (key == Keys.M)
                    {
                        muteCheckBox.Checked = !muteCheckBox.Checked;
                    }
                    else if (key == Keys.P)
                    {
                        TogglePauseState();
                    }
                }
            }
        }

        private void StopForm_Load(object sender, EventArgs e)
        {
            HotkeyManager.RegisterHotKey(this.Handle, 0, (int)HotkeyManager.KeyModifier.Alt, Keys.R.GetHashCode());
            HotkeyManager.RegisterHotKey(this.Handle, 1, (int)HotkeyManager.KeyModifier.Alt, Keys.M.GetHashCode());
            HotkeyManager.RegisterHotKey(this.Handle, 2, (int)HotkeyManager.KeyModifier.Alt, Keys.P.GetHashCode());

            if (minimizeToTaskbar && countdownSeconds == 0)
            {
                this.WindowState = FormWindowState.Minimized;
            }

            BeginCaptureSession();
        }

        public void UpdateVolumeBar(int volume)
        {
            try
            {
                int destVolume = volume;
                if (destVolume > progressBar1.Maximum) destVolume = progressBar1.Maximum;
                else if (destVolume < progressBar1.Minimum) destVolume = progressBar1.Minimum;

                progressBar1.BeginInvoke((MethodInvoker)(() =>
                {
                    if (!progressBar1.IsDisposed)
                    {
                        progressBar1.Value = destVolume;
                    }
                }));
            }
            catch
            {
            }
        }

        private void muteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (mainFormRef != null)
            {
                mainFormRef.MuteRecorder(muteCheckBox.Checked);
            }
        }
    }
}
