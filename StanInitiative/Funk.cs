using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Google.API.Search;
using CoreAudioApi;
using System.Diagnostics;
namespace StanInitiative
{
    public class Funk
    {
        Paths shp = new Paths();
        public Funk()
        { }

        public int GGLlen(string str)
        {
            return new GwebSearchClient("http://www.google.com").Search(str,25).Count;
        }
        public string jsontostring(string str)
        {
            if (str==null)
                return shp.noans;
            if (str.IndexOf("\"utterance\":\"") != -1 && str.IndexOf("\",\"confidence\"") != -1)
                return str.Substring(str.IndexOf("\"utterance\":\"") +
                   "\"utterance\":\"".Length,
                   str.IndexOf("\",\"confidence\"") - str.IndexOf("\"utterance\":\"") -
                   "\"utterance\":\"".Length);
            else
                return shp.noans;
        }
        public ListBox addlstbx(Tree.Node n, ListBox lb1, bool fl)
        {
            if (fl)
                lb1.Items.Clear();
            for (int i = 1; i < n.getlen() + 1; i++)
                lb1.Items.Add(n.getnode(i - 1).getname());
            return lb1;
        }
        public ListBox addlstbx(List<string> n, ListBox lb1, bool fl)
        {
            if (fl)
                lb1.Items.Clear();
            for (int i = 0; i < n.Count(); i++)
                lb1.Items.Add(n[i]);
            return lb1;
        }
        public ListBox additlb(string n, ListBox lb1, bool fl)
        {
            lb1.Items.Add(n);
            if (fl)
            {
                lb1.SelectedIndex = lb1.Items.Count - 1;
                lb1.SelectedIndex = -1;
            }
            return lb1;
        }
        public int findcom(string str)
        {
            for (int i = 0; i < shp.cnclsm.Length; i++)
            {
                if (str.IndexOf(shp.cnclsm[i]) > -1)
                    return i;
            }
            return -1;
        }
        public void mutevol(bool fl)
        {
            new MMDeviceEnumerator().GetDefaultAudioEndpoint(
            EDataFlow.eRender, ERole.eMultimedia
            ).AudioEndpointVolume.Mute = fl;
        }
        public void setvol(int n)
        {
            new MMDeviceEnumerator().GetDefaultAudioEndpoint(
            EDataFlow.eRender, ERole.eMultimedia
            ).AudioEndpointVolume.MasterVolumeLevelScalar = ((float)n / 100.0f);
        }
        public void openseldir(string path)
        {
            Process PrFolder = new Process();
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.CreateNoWindow = true;
            psi.WindowStyle = ProcessWindowStyle.Normal;
            psi.FileName = "explorer";
            psi.Arguments = @"/n, /select, " + path;
            PrFolder.StartInfo = psi;
            PrFolder.Start();
        }
        public void opendir(string path)
        {
            Process.Start(path);
        }
    }
}
