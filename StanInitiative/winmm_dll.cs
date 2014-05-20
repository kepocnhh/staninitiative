using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace StanInitiative
{
    class winmm_dll
    {
        [DllImport("winmm.dll")]
        public static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);
        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);
        public winmm_dll()
        {
        }
        public void vOFF2()
        {
            int NewVolume = 0;
            uint NewVolumeAllChannels = (((uint)NewVolume & 0x0000ffff) | ((uint)NewVolume << 16));
            waveOutSetVolume(IntPtr.Zero, NewVolumeAllChannels);
        }
        public void vON()
        {
            waveOutSetVolume(IntPtr.Zero, Convert.ToUInt32("100"));
        }
        public void vOFF()
        {
        }
    }
}
