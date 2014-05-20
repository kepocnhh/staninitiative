using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NAudio;
using NAudio.Wave;
using System.Threading;

namespace StanInitiative
{
    public class Micro
    {
        Paths shp = new Paths();
        Funk shf = new Funk();
        private WaveInEvent WaveSourceStream = null;
        private byte[] resBuf;
        private List<byte[]> bufl;
        private int lvlv = 0;
        private int lvlv2 = 0;
        private Comands shc;
        private bool flag;
        Form1 frm;
        GtGgle shg;
        public Micro(Form1 f1)
        {
            frm = f1;
            shc = new Comands(f1);
            shg = new GtGgle(shc);
            flag = false;
        }
        private int GetAudioLevel(byte[] buf)
        {
            int sample32 = 0;
            for (int index = 0; index < buf.Length; index += 2)
            {
                short sample = (short)((buf[index + 1] << 8) |
                                        buf[index + 0]);
                sample32 += (int)Math.Abs(sample / 2768f);
            }
            return sample32;
        }
        private void sourceStream_DataAvailable(object sender, WaveInEventArgs e)
        {
            var buffer = new byte[3200];
            e.Buffer.CopyTo(buffer, 0);
            bufl.Add(buffer);
                lvlv = GetAudioLevel(bufl.Last());

            if(lvlv>555)
            {
                flag = true;
                lvlv2 ++;
                resBuf = new byte[3200 * bufl.Count];
                for (int i = 0; i < bufl.Count; i++)
                    bufl[i].CopyTo(resBuf, i * 3200);
                if (lvlv2 > 4)
                {
                    shg.post(resBuf);
                    lvlv2 = 0;
                }
            }
            else
            {
                if (flag)
                {
                    flag = false;
                    if (bufl.Count > 1)
                        shg.post(resBuf);
                    shg.post(null);
                    lvlv2 = 0;
                }
                bufl.Clear();
            }
            frm.SetTextSafe("" + lvlv);
            frm.SetPrbr(lvlv);
            lvlv=0;
            
        }
        public void StartRec()
        {
            WaveSourceStream = new NAudio.Wave.WaveInEvent();
            WaveSourceStream.DeviceNumber = 0;
            WaveSourceStream.WaveFormat = new WaveFormat(16000,1);
            WaveSourceStream.DataAvailable += sourceStream_DataAvailable;
            WaveSourceStream.StartRecording();
            bufl = new List<byte[]>();
        }
        public void StopRecording2()
        {
            if (WaveSourceStream != null)
            {
                WaveSourceStream.StopRecording();
                WaveSourceStream.Dispose();
                WaveSourceStream = null;
                bufl = null;
            }
        }
    }
}
