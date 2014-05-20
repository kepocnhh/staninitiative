using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StanInitiative
{
    public class Paths
    {
        public Paths()
        { }
        static string StanPATH = "C:\\COM\\";
        public string genPATH = StanPATH;
        public string dllPATH = StanPATH + "DLLs\\";
        public string vcPATH = StanPATH + "VOICE\\";
        public string fcPATH = StanPATH + "FACE\\";
        public string noans = "   - net_otveta - ";
        public string endrec = "   - konec_zapis - - - - ";
        public string[] cnclsm = "отмена\tзабей\tне надо".Split('\t');
    }
}
