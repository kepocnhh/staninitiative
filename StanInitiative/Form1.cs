using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using NAudio;
using NAudio.Wave;
using System.Diagnostics;

namespace StanInitiative
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            shm = new Micro(this);
            progressBar1.Maximum = 300;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            shcform = new Comands(this);
        }
        Paths shp = new Paths();
        Funk shf = new Funk();
        private Micro shm;
        private Comands shcform;
        private void button1_Click(object sender, EventArgs e)
        {
            shm.StartRec();
            Setimage(0);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            shm.StopRecording2();
            Setimage(-1);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            /*
            //SetGoogle("ggl " + shf.GGLlen("\"recycle bin\" \"" + textBox1.Text + "\""));
            Process[] processes = Process.GetProcesses();
            for (int i = 0; i < processes.Length; i++)
            {
                
                //useComs(processes[i].MainModule.FileName);
                //"System.ComponentModel.Win32Exception" в System.dll
                try
                {
                    useComs(processes[i].MainModule.ModuleName);
                }
                catch (Win32Exception Win32Exception)
                {
                    //ну и ладно
                }
            }
            */
            /*
            shcform.fincom("\"utterance\":\"" + textBox1.Text + "\",\"confidence\"");
            shcform.nllcmk();
            */
            //useComs(new user32_dll().GetActiveWindow());
            /*
            if (new user32_dll().BringWindowToTop())
                useComs(":)");
            */
            //new user32_dll().MoveWindowToMonitor(0);
            //Process.Start("::{645FF040-5081-101B-9F08-00AA002F954E}"); //откроет корзину
            //Process.Start("::{20D04FE0-3AEA-1069-A2D8-08002B30309D}"); //откроет Мой компьютер
            //Process.Start("http://www.csharpdeveloping.net"); //открыть страницу по адресу
            //Process.Start("chrome"); //новая вкладка
        }
        public void SetTextSafe(string newText)
        {
            if (label2.InvokeRequired) label2.Invoke(new Action<string>((s) => label2.Text = s), newText);
            else label2.Text = newText;
        }
        public void SetPrbr(int newText)
        {
            if (progressBar1.InvokeRequired)
            {
                int max = progressBar1.Maximum;
                if (newText > max)
                    max = newText;
                progressBar1.Invoke(new Action<int>((s) => progressBar1.Maximum = max), newText);
                progressBar1.Invoke(new Action<int>((s) => progressBar1.Value = s), newText);
            }
            else
            {
                if (newText > progressBar1.Maximum)
                    progressBar1.Maximum = newText;
                progressBar1.Value = newText;
            }
        }

        public void SetGoogle(string newText)
        {
            if (label1.InvokeRequired) label1.Invoke(new Action<string>((s) => label1.Text = s), newText);
            else label1.Text = newText;
        }
        public void SetText3(string newText)
        {
            if (label3.InvokeRequired) label3.Invoke(new Action<string>((s) => label3.Text = s), newText);
            else label3.Text = newText;
        }
        public void SetCom(Tree.Node n)
        {
            if (listBox1.InvokeRequired)
            {
                listBox1.Invoke(new Action<Tree.Node>((s) =>
                    listBox1 = shf.addlstbx(s, listBox1, true)
                    ), n);
            }
            else
            {
                listBox1 = shf.addlstbx(n, listBox1, true);
            }
        }
        public void useComs(string n)
        {
            if (listBox2.InvokeRequired)
            {
                listBox2.Invoke(new Action<string>((s) =>
                listBox2 = shf.additlb(s, listBox2, true)
                    ), n);
            }
            else
            {
                listBox2 = shf.additlb(n, listBox2, true);
            }
        }
        public void Setcomok(List<string> n)
        {
            if (listBox3.InvokeRequired)
            {
                listBox3.Invoke(new Action<List<string>>((s) =>
                    listBox3 = shf.addlstbx(s, listBox3, true)
                    ), n);
            }
            else
            {
                listBox3 = shf.addlstbx(n, listBox3, true);
            }
        }
        public void Setimage(int i)
        {
            if (pictureBox1.InvokeRequired) pictureBox1.Invoke(new Action<string>((s) => pictureBox1.Image = Image.FromFile(shp.fcPATH+i.ToString()+".jpg")), i.ToString());
            else pictureBox1.Image = Image.FromFile(shp.fcPATH + i.ToString() + ".jpg");
        }
    }
}
