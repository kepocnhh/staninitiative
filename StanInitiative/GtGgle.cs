using CUETools.Codecs;
using CUETools.Codecs.FLAKE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace StanInitiative
{
    public class GtGgle
    {
        Paths shp = new Paths();
        Funk shf = new Funk();
        Comands shc;
        int aaaaa;
        private string ans = null;
        private List<byte[]> btsm;
        object LockObj = new object();
        public GtGgle( Comands cmd)
        {
            shc = cmd;
            this.btsm = new List<byte[]>();
        }
        private byte[] Wav2FlacBuffConverter(byte[] Buffer)
        {
            Stream OutWavStream = new MemoryStream();
            Stream OutFlacStream = new MemoryStream();
            AudioPCMConfig pcmconf = new AudioPCMConfig(16, 1, 16000);
            WAVWriter wr = new WAVWriter(null, OutWavStream, pcmconf);
            wr.Write(new AudioBuffer(pcmconf, Buffer, Buffer.Length / 2));
            OutWavStream.Seek(0, SeekOrigin.Begin);
            WAVReader audioSource = new WAVReader(null, OutWavStream);
            if (audioSource.PCM.SampleRate != 16000) 
            return null;
            AudioBuffer buff = new AudioBuffer(audioSource, 0x10000);
            FlakeWriter flakeWriter = new FlakeWriter(null, OutFlacStream, audioSource.PCM);
            flakeWriter.CompressionLevel = 8;
            while (audioSource.Read(buff, -1) != 0)
            {
                flakeWriter.Write(buff);
            }
            OutFlacStream.Seek(0, SeekOrigin.Begin);
            byte[] barr = new byte[OutFlacStream.Length];
            OutFlacStream.Read(barr, 0, (int)OutFlacStream.Length);
            return barr;
        }
        //
        public void post(byte[] data)
        {
            if (btsm.Count > 1 && btsm[btsm.Count - 1] == null && data == null)
                return;
            if (data != null)
                data = Wav2FlacBuffConverter(data);
                btsm.Add(data);
                new Thread(postreq).Start();
        }
        void postreq()
        {
            byte[] datain;
            lock (LockObj)
            {
                datain = btsm[0];
                btsm.RemoveAt(0);
                if (datain == null)
                {
                    shc.nllcmk();
                    return;
                }
                HttpWebRequest httpWReq =
                (HttpWebRequest)WebRequest.Create("https://www.google.com/"
                            + "speech-api/v1/recognize?xjerr=1&client="
                            + "chromium&lang=ru-RU");
                httpWReq.Method = "POST";
                httpWReq.ContentType = "audio/x-flac; rate=16000";
                httpWReq.ContentLength = datain.Length;
                using (Stream stream = httpWReq.GetRequestStream())
                {
                    stream.Write(datain, 0, datain.Length);
                    stream.Close();
                }
                HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                string ans1 = new StreamReader(response.GetResponseStream()).ReadToEnd();
                shc.fincom(ans1);
            }
        }
    }
}
