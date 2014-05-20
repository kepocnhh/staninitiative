using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace StanInitiative
{
    public class Comands
    {
        Paths shp = new Paths();
        Funk shf = new Funk();
        Form1 frm;
        private Tree.Node shtn;
        private List<string> comok;
        public Comands(Form1 f1)
        {
            shtn = new Tree().nodegen;
            frm = f1;
            frm.SetText3(shtn.getname());
            frm.SetCom(shtn);
            comok = new List<string>();
        }
        private int releasecomand(string sm)
        {
            String[] strm = sm.Split('\t');
            string str = strm[0];
            if (str.Equals("999"))
            {
                System.Environment.Exit(0);
                return 0;
            }
            if (str.Equals("1-1"))
            {
                new Shell32_dll().clearbasket();
                return 0;
            }
            if (str.Equals("1-2") && strm.Length > 1)
            {
                shf.setvol(Convert.ToInt32(strm[1]));
                return 0;
            }
            if (str.Equals("1-3"))
            {
                shf.opendir("D:\\Загрузки");
                return 0;
            }
            if (str.Equals("1-2-2"))
            {
                shf.mutevol(true);
                return 0;
            }
            if (str.Equals("1-2-1"))
            {
                shf.mutevol(false);
                return 0;
            }
            return -1;
        }
        public void nllcmk()
        {
            this.comok.Clear();
            frm.useComs(shp.endrec);
        }
        public void fincom(string s)
        {
            s = shf.jsontostring(s);
            for (int i = 0; i < comok.Count; i++)
                s = new Regex(comok[i]).Replace(s,"",1);
            frm.Setcomok(comok);
            frm.useComs(s);
            frm.SetGoogle(s);
            int n = 0;
            n = shf.findcom(s);
            if (n != -1 && shtn.getreturn() != null)
            {
                while (n != -1)
                {
                    shtn = shtn.getreturn();
                    comok.Add(shp.cnclsm[n]);
                    s = new Regex(shp.cnclsm[n]).Replace(s, "", 1);
                    n = shf.findcom(s);
                    frm.Setimage(-2);
                }
            }
            else
            {
                n = 0;
                while (n != -1)
                {
                    n = shtn.findcom(s);
                    if (n != -1)
                    {
                        s = new Regex(shtn.getnode(n).getname()).Replace(s, "", 1);
                        //new Comands(shtn.getnode(n).getid());
                        frm.Setimage(releasecomand(shtn.getnode(n).getid()));
                        comok.Add(shtn.getnode(n).getname());
                        if (shtn.getnode(n).getlen() > 0)
                            shtn = shtn.getnode(n);
                    }
                }
                if(shtn.numb)
                {
                    int vol=-1;
                    String[] sm = s.Split(' ');
                    for(int i=sm.Length-1;i>-1;i--)
                    {
                        try
                        {
                            vol = Convert.ToInt32(sm[i]);
                        }
                        catch (FormatException e)
                        { 
                            //ну и ладно
                            vol = -1;
                        }
                        if(vol!=-1)
                        {
                            if (vol < shtn.getf() || vol > shtn.getl())
                                continue;
                            //new Comands(shtn.getid() + "\t" + vol);
                            frm.Setimage(releasecomand(shtn.getnode(n).getid()));
                            comok.Add("" + vol);
                            break;
                        }
                    }
                }
            }
            frm.SetText3(shtn.getname());
            frm.SetCom(shtn);
        }
    }
}
