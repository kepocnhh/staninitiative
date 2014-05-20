using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
enum RecycleFlags : int
{
    SHERB_NOCONFIRMATION = 0x00000001,
    SHERB_NOPROGRESSUI = 0x00000001,
    SHERB_NOSOUND = 0x00000004
}

namespace StanInitiative
{
    class Shell32_dll
    {
        [DllImport("Shell32.dll")]
        public static extern int SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, RecycleFlags dwFlags);
        public Shell32_dll()
        {
        }
        public void clearbasket()
        {
            SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHERB_NOPROGRESSUI);
        }
    }
}
