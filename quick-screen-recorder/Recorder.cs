using NAudio.Wave;
using SharpAvi;
using SharpAvi.Codecs;
using SharpAvi.Output;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace quick_screen_recorder
{
    class Recorder : IDisposable
    {
        private AviWriter writer;
        private IAviVideoStream videoStream;
        private IAviAudioStream audioStream;
        private IVideoEncoder videoEncoder;
        private IWaveIn audioSource;
        private Thread screenThread;

        private ManualResetEvent stopThread = new ManualResetEvent(false);
        private WaveFileWriter waveFile;

        private int x;
        private int y;
        private int captureWidth;
        private int captureHeight;
        private int outWidth;
        private int outHeight;
        private int fps;
        private bool captureCursor;
        private bool highlightClicks;
        private bool enableWatermark;
        private string watermarkText;
        private bool showTimestamp;

        [StructLayout(LayoutKind.Sequential)]
        public struct POINTAPI
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CURSORINFO
        {
            public Int32 cbSize;
            public Int32 flags;
            public IntPtr hCursor;
            public POINTAPI ptScreenPos;
        }

        [DllImport("user32.dll")]
        public static extern bool GetCursorInfo(out CURSORINFO pci);

        [DllImport("user32.dll")]
        public static extern bool DrawIcon(IntPtr hDC, int X, int Y, IntPtr hIcon);

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);

        public const Int32 CURSOR_SHOWING = 0x00000001;
        public const int VK_LBUTTON = 0x01;
        public const int VK_RBUTTON = 0x02;

        public bool Mute = false;
        public volatile bool Paused = false;

        public Recorder(
            string filePath,
            int quality,
            int fps,
            int x,
            int y,
            int captureWidth,
            int captureHeight,
            int targetOutWidth,
            int targetOutHeight,
            bool captureCursor,
            bool highlightClicks,
            bool enableWatermark,
            string watermarkText,
            bool showTimestamp,
            int inputSourceIndex,
            bool separateAudio)
        {
            int safeCapW = Math.Max(160, captureWidth - (captureWidth % 2));
            int safeCapH = Math.Max(160, captureHeight - (captureHeight % 2));

            int safeOutW = (targetOutWidth > 0) ? Math.Max(160, targetOutWidth - (targetOutWidth % 2)) : safeCapW;
            int safeOutH = (targetOutHeight > 0) ? Math.Max(160, targetOutHeight - (targetOutHeight % 2)) : safeCapH;

            this.x = x;
            this.y = y;
            this.captureWidth = safeCapW;
            this.captureHeight = safeCapH;
            this.outWidth = safeOutW;
            this.outHeight = safeOutH;
            this.fps = (fps >= 5 && fps <= 60) ? fps : 30;
            this.captureCursor = captureCursor;
            this.highlightClicks = highlightClicks;
            this.enableWatermark = enableWatermark;
            this.watermarkText = watermarkText;
            this.showTimestamp = showTimestamp;

            writer = new AviWriter(filePath)
            {
                FramesPerSecond = this.fps,
                EmitIndex1 = true,
            };

            if (quality == 0)
            {
                videoEncoder = new UncompressedVideoEncoder(this.outWidth, this.outHeight);
                videoStream = writer.AddVideoStream(this.outWidth, this.outHeight, BitsPerPixel.Bpp24);
                videoStream.Codec = videoEncoder.Codec;
                videoStream.BitsPerPixel = videoEncoder.BitsPerPixel;
                videoStream.Name = "Lite Screen Recorder - Uncompressed Video";
            }
            else
            {
                int q = (quality >= 10 && quality <= 100) ? quality : 90;
                videoEncoder = new MotionJpegVideoEncoderWpf(this.outWidth, this.outHeight, q);
                videoStream = writer.AddVideoStream(this.outWidth, this.outHeight, BitsPerPixel.Bpp24);
                videoStream.Codec = videoEncoder.Codec;
                videoStream.BitsPerPixel = videoEncoder.BitsPerPixel;
                videoStream.Name = "Lite Screen Recorder - High Quality MJPEG Video";
            }

            try
            {
                if (inputSourceIndex >= 0)
                {
                    var waveFormat = new WaveFormat(44100, 16, 1);

                    audioStream = writer.AddAudioStream(
                        channelCount: waveFormat.Channels,
                        samplesPerSecond: waveFormat.SampleRate,
                        bitsPerSample: waveFormat.BitsPerSample
                    );
                    audioStream.Name = "Lite Screen Recorder - Input Audio";

                    audioSource = new WaveInEvent()
                    {
                        DeviceNumber = inputSourceIndex,
                        WaveFormat = waveFormat,
                        BufferMilliseconds = 40,
                        NumberOfBuffers = 3,
                    };
                    audioSource.DataAvailable += audioSource_DataAvailable;

                    if (separateAudio)
                    {
                        waveFile = new WaveFileWriter(filePath + " (Input audio).wav", audioSource.WaveFormat);
                    }
                }
                else if (inputSourceIndex == -1)
                {
                    audioSource = new WasapiLoopbackCapture();

                    audioStream = writer.AddAudioStream(
                        channelCount: 1,
                        samplesPerSecond: audioSource.WaveFormat.SampleRate,
                        bitsPerSample: 16
                    );
                    audioStream.Name = "Lite Screen Recorder - System Sounds";

                    audioSource.DataAvailable += audioSource_DataAvailable;

                    if (separateAudio)
                    {
                        waveFile = new WaveFileWriter(filePath + " (System sounds).wav", audioSource.WaveFormat);
                    }
                }
            }
            catch
            {
                audioSource = null;
                audioStream = null;
            }

            screenThread = new Thread(RecordScreen)
            {
                Name = typeof(Recorder).Name + ".RecordScreen",
                IsBackground = true,
                Priority = ThreadPriority.AboveNormal
            };

            if (audioSource != null)
            {
                audioSource.StartRecording();
            }

            screenThread.Start();
        }

        public void Dispose()
        {
            stopThread.Set();
            if (screenThread != null && screenThread.IsAlive)
            {
                screenThread.Join(3000);
            }

            if (waveFile != null)
            {
                try { waveFile.Dispose(); } catch { }
                waveFile = null;
            }

            if (audioSource != null)
            {
                try
                {
                    audioSource.StopRecording();
                    audioSource.DataAvailable -= audioSource_DataAvailable;
                }
                catch { }
            }

            if (writer != null)
            {
                try { writer.Close(); } catch { }
            }

            IDisposable dispEnc = videoEncoder as IDisposable;
            if (dispEnc != null)
            {
                try { dispEnc.Dispose(); } catch { }
            }

            stopThread.Dispose();
        }

        private void RecordScreen()
        {
            var stopwatch = new Stopwatch();
            var rawBuffer = new byte[outWidth * outHeight * 4];
            var encodedBuffer = new byte[videoEncoder.MaxEncodedSize];

            long framesWritten = 0;
            var timeTillNextFrame = TimeSpan.Zero;

            bool needsScaling = (captureWidth != outWidth) || (captureHeight != outHeight);

            using (var capBmp = new Bitmap(captureWidth, captureHeight, PixelFormat.Format32bppRgb))
            using (var capG = Graphics.FromImage(capBmp))
            using (var outBmp = needsScaling ? new Bitmap(outWidth, outHeight, PixelFormat.Format32bppRgb) : null)
            using (var outG = needsScaling ? Graphics.FromImage(outBmp) : null)
            {
                if (outG != null)
                {
                    outG.CompositingMode = CompositingMode.SourceCopy;
                    outG.InterpolationMode = InterpolationMode.HighQualityBilinear;
                    outG.PixelOffsetMode = PixelOffsetMode.HighSpeed;
                    outG.SmoothingMode = SmoothingMode.HighSpeed;
                }

                stopwatch.Start();

                while (!stopThread.WaitOne(timeTillNextFrame))
                {
                    if (Paused)
                    {
                        stopwatch.Stop();
                        while (Paused && !stopThread.WaitOne(30))
                        {
                        }
                        stopwatch.Start();
                        if (stopThread.WaitOne(0))
                        {
                            break;
                        }
                    }

                    // 1. Capture screen + overlays into rawBuffer
                    CaptureAndScaleFrame(capBmp, capG, outBmp, outG, rawBuffer, needsScaling);

                    // 2. Encode the frame ONCE into encodedBuffer
                    bool isKeyFrame = true;
                    int encodedBytes = videoEncoder.EncodeFrame(rawBuffer, 0, encodedBuffer, 0, out isKeyFrame);

                    // 3. Exact 1.0x Real-Time Frame Pacing:
                    // Calculate how many frames MUST be in the AVI stream right now for 1.0x real-time playback
                    double elapsedSec = stopwatch.Elapsed.TotalSeconds;
                    long expectedFrames = (long)Math.Floor(elapsedSec * (double)this.fps) + 1;
                    long framesToEmit = expectedFrames - framesWritten;
                    if (framesToEmit < 1) framesToEmit = 1;
                    if (framesToEmit > 6) framesToEmit = 6; // Cap catch-up burst

                    lock (writer)
                    {
                        for (long f = 0; f < framesToEmit; f++)
                        {
                            videoStream.WriteFrame(isKeyFrame, encodedBuffer, 0, encodedBytes);
                            framesWritten++;
                        }
                    }

                    // 4. Sleep until the exact timestamp of the next frame (framesWritten / fps)
                    double nextFrameTimeSec = (double)framesWritten / (double)this.fps;
                    double waitSec = nextFrameTimeSec - stopwatch.Elapsed.TotalSeconds;
                    if (waitSec > 0.001)
                    {
                        timeTillNextFrame = TimeSpan.FromSeconds(waitSec);
                    }
                    else
                    {
                        timeTillNextFrame = TimeSpan.Zero;
                    }
                }

                stopwatch.Stop();
            }
        }

        private void CaptureAndScaleFrame(
            Bitmap capBmp,
            Graphics capG,
            Bitmap outBmp,
            Graphics outG,
            byte[] destBuffer,
            bool needsScaling)
        {
            try
            {
                capG.CopyFromScreen(new Point(x, y), Point.Empty, new Size(captureWidth, captureHeight), CopyPixelOperation.SourceCopy);

                RenderFrameOverlays(
                    capG, x, y, captureWidth, captureHeight,
                    captureCursor, highlightClicks,
                    enableWatermark, watermarkText, showTimestamp);

                capG.Flush();

                Bitmap lockTarget = capBmp;
                if (needsScaling && outBmp != null && outG != null)
                {
                    outG.DrawImage(capBmp, new Rectangle(0, 0, outWidth, outHeight), new Rectangle(0, 0, captureWidth, captureHeight), GraphicsUnit.Pixel);
                    outG.Flush();
                    lockTarget = outBmp;
                }

                var bits = lockTarget.LockBits(
                    new Rectangle(0, 0, outWidth, outHeight),
                    ImageLockMode.ReadOnly,
                    PixelFormat.Format32bppRgb
                );
                try
                {
                    Marshal.Copy(bits.Scan0, destBuffer, 0, destBuffer.Length);
                }
                finally
                {
                    lockTarget.UnlockBits(bits);
                }
            }
            catch
            {
            }
        }

        public static void RenderFrameOverlays(
            Graphics g,
            int regionX,
            int regionY,
            int regionWidth,
            int regionHeight,
            bool captureCursor,
            bool highlightClicks,
            bool enableWatermark,
            string watermarkText,
            bool showTimestamp)
        {
            if (captureCursor)
            {
                try
                {
                    CURSORINFO pci;
                    pci.cbSize = Marshal.SizeOf(typeof(CURSORINFO));

                    if (GetCursorInfo(out pci))
                    {
                        if (pci.flags == CURSOR_SHOWING)
                        {
                            int curX = pci.ptScreenPos.x - regionX;
                            int curY = pci.ptScreenPos.y - regionY;

                            if (highlightClicks)
                            {
                                bool leftDown = (GetAsyncKeyState(VK_LBUTTON) & 0x8000) != 0;
                                bool rightDown = (GetAsyncKeyState(VK_RBUTTON) & 0x8000) != 0;

                                if (leftDown || rightDown)
                                {
                                    g.SmoothingMode = SmoothingMode.AntiAlias;
                                    Color ringColor = leftDown
                                        ? Color.FromArgb(200, 255, 46, 99)
                                        : Color.FromArgb(200, 0, 210, 255);
                                    Color fillColor = leftDown
                                        ? Color.FromArgb(60, 255, 46, 99)
                                        : Color.FromArgb(60, 0, 210, 255);

                                    using (Brush b = new SolidBrush(fillColor))
                                    using (Pen p = new Pen(ringColor, 2.5f))
                                    {
                                        g.FillEllipse(b, curX - 12, curY - 12, 32, 32);
                                        g.DrawEllipse(p, curX - 12, curY - 12, 32, 32);
                                    }
                                }
                            }

                            IntPtr hdc = g.GetHdc();
                            DrawIcon(hdc, curX, curY, pci.hCursor);
                            g.ReleaseHdc(hdc);
                        }
                    }
                }
                catch { }
            }

            if (enableWatermark || showTimestamp)
            {
                try
                {
                    string text = "";
                    if (enableWatermark && !string.IsNullOrEmpty(watermarkText))
                    {
                        text = watermarkText;
                    }
                    if (showTimestamp)
                    {
                        string ts = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        text = string.IsNullOrEmpty(text) ? ts : (text + "  |  " + ts);
                    }

                    if (!string.IsNullOrEmpty(text))
                    {
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        using (Font font = new Font("Segoe UI", 9f, FontStyle.Regular))
                        {
                            SizeF textSize = g.MeasureString(text, font);
                            float padX = 8f;
                            float padY = 4f;
                            float boxW = textSize.Width + padX * 2f;
                            float boxH = textSize.Height + padY * 2f;
                            float posX = Math.Max(6f, regionWidth - boxW - 10f);
                            float posY = Math.Max(6f, regionHeight - boxH - 10f);

                            using (Brush bgBrush = new SolidBrush(Color.FromArgb(150, 17, 24, 39)))
                            using (Brush txtBrush = new SolidBrush(Color.FromArgb(240, 255, 255, 255)))
                            {
                                g.FillRectangle(bgBrush, posX, posY, boxW, boxH);
                                g.DrawString(text, font, txtBrush, posX + padX, posY + padY);
                            }
                        }
                    }
                }
                catch { }
            }
        }

        public static string CaptureScreenshotToFile(
            string folderPath,
            int x,
            int y,
            int width,
            int height,
            bool captureCursor,
            bool highlightClicks,
            bool enableWatermark,
            string watermarkText,
            bool showTimestamp)
        {
            if (string.IsNullOrEmpty(folderPath) || !Directory.Exists(folderPath))
            {
                folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }

            int safeW = Math.Max(160, width);
            int safeH = Math.Max(160, height);

            string fileName = string.Format("Screenshot_{0}.png", DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
            string fullPath = Path.Combine(folderPath, fileName);

            using (var bmp = new Bitmap(safeW, safeH))
            {
                using (var g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(new Point(x, y), Point.Empty, new Size(safeW, safeH), CopyPixelOperation.SourceCopy);
                    RenderFrameOverlays(
                        g, x, y, safeW, safeH,
                        captureCursor, highlightClicks,
                        enableWatermark, watermarkText, showTimestamp);
                    g.Flush();
                }
                bmp.Save(fullPath, ImageFormat.Png);
            }

            return fullPath;
        }

        private void audioSource_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (Paused)
            {
                return;
            }

            int vol = 0;

            try
            {
                if (waveFile != null)
                {
                    if (Mute)
                    {
                        waveFile.Write(new byte[e.BytesRecorded], 0, e.BytesRecorded);
                    }
                    else
                    {
                        waveFile.Write(e.Buffer, 0, e.BytesRecorded);
                    }
                    waveFile.Flush();
                }

                if (audioStream != null && e.BytesRecorded > 0)
                {
                    if (audioSource.WaveFormat.BitsPerSample == 32)
                    {
                        byte[] newArray16Bit = new byte[e.BytesRecorded / 2];
                        if (!Mute)
                        {
                            short two;
                            float value;
                            for (int i = 0, j = 0; i < e.BytesRecorded; i += 4, j += 2)
                            {
                                value = (BitConverter.ToSingle(e.Buffer, i));
                                two = (short)(value * short.MaxValue);

                                newArray16Bit[j] = (byte)(two & 0xFF);
                                newArray16Bit[j + 1] = (byte)((two >> 8) & 0xFF);
                            }

                            float max = 0;
                            for (int index = 0; index < e.BytesRecorded / 2; index += 2)
                            {
                                short sample = (short)((newArray16Bit[index + 1] << 8) | newArray16Bit[index + 0]);
                                var sample32 = sample / 32768f;
                                if (sample32 < 0) sample32 = -sample32;
                                if (sample32 > max) max = sample32;
                            }
                            vol = (int)(100 * max);
                        }

                        lock (writer)
                        {
                            audioStream.WriteBlock(newArray16Bit, 0, newArray16Bit.Length);
                        }
                    }
                    else
                    {
                        byte[] pcmBytes = Mute ? new byte[e.BytesRecorded] : e.Buffer;
                        if (!Mute)
                        {
                            float max = 0;
                            for (int index = 0; index < e.BytesRecorded; index += 2)
                            {
                                short sample = (short)((e.Buffer[index + 1] << 8) | e.Buffer[index + 0]);
                                var sample32 = sample / 32768f;
                                if (sample32 < 0) sample32 = -sample32;
                                if (sample32 > max) max = sample32;
                            }
                            vol = (int)(100 * max);
                        }

                        lock (writer)
                        {
                            audioStream.WriteBlock(pcmBytes, 0, e.BytesRecorded);
                        }
                    }
                }
            }
            catch { }

            OnPeakVolumeChangedArgs opvcArgs = new OnPeakVolumeChangedArgs()
            {
                Volume = vol
            };
            PeakVolumeChanged(opvcArgs);
        }

        protected virtual void PeakVolumeChanged(OnPeakVolumeChangedArgs e)
        {
            EventHandler<OnPeakVolumeChangedArgs> handler = OnPeakVolumeChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<OnPeakVolumeChangedArgs> OnPeakVolumeChanged;
    }

    public class OnPeakVolumeChangedArgs : EventArgs
    {
        public int Volume { get; set; }
    }
}
