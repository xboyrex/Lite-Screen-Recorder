using System;
using System.IO;
using System.Media;
using System.Threading.Tasks;

namespace quick_screen_recorder
{
    public static class HapticsEngine
    {
        public static bool Enabled = true;

        public static void PlayTap()
        {
            if (!Enabled) return;
            PlayToneAsync(680.0, 920.0, 14, 0.18);
        }

        public static void PlayStartRec()
        {
            if (!Enabled) return;
            PlayToneAsync(520.0, 880.0, 42, 0.28);
        }

        public static void PlayStopRec()
        {
            if (!Enabled) return;
            PlayToneAsync(780.0, 440.0, 48, 0.28);
        }

        public static void PlayShutter()
        {
            if (!Enabled) return;
            PlayToneAsync(1200.0, 600.0, 22, 0.25);
        }

        private static void PlayToneAsync(double freqStart, double freqEnd, int durationMs, double amplitude)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    int sampleRate = 44100;
                    int totalSamples = (sampleRate * durationMs) / 1000;
                    if (totalSamples < 64) totalSamples = 64;

                    int dataBytes = totalSamples * 2;
                    using (MemoryStream ms = new MemoryStream(44 + dataBytes))
                    using (BinaryWriter bw = new BinaryWriter(ms))
                    {
                        // WAV RIFF Header
                        bw.Write(new char[] { 'R', 'I', 'F', 'F' });
                        bw.Write(36 + dataBytes);
                        bw.Write(new char[] { 'W', 'A', 'V', 'E' });
                        bw.Write(new char[] { 'f', 'm', 't', ' ' });
                        bw.Write(16);
                        bw.Write((short)1); // PCM
                        bw.Write((short)1); // Mono
                        bw.Write(sampleRate);
                        bw.Write(sampleRate * 2);
                        bw.Write((short)2);
                        bw.Write((short)16);
                        bw.Write(new char[] { 'd', 'a', 't', 'a' });
                        bw.Write(dataBytes);

                        double phase = 0.0;
                        for (int i = 0; i < totalSamples; i++)
                        {
                            double t = (double)i / (double)totalSamples;
                            // Smooth Hann envelope so there is zero harsh pop
                            double env = Math.Sin(Math.PI * t);
                            double freq = freqStart + (freqEnd - freqStart) * t;
                            phase += (2.0 * Math.PI * freq) / (double)sampleRate;
                            short sample = (short)(Math.Sin(phase) * env * amplitude * 32767.0);
                            bw.Write(sample);
                        }

                        bw.Flush();
                        ms.Position = 0;
                        using (SoundPlayer sp = new SoundPlayer(ms))
                        {
                            sp.PlaySync();
                        }
                    }
                }
                catch { }
            });
        }
    }
}
