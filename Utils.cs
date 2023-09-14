using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;
using Kbg.NppPluginNET.PluginInfrastructure;
using System.Collections.Generic;
using System;

namespace ERPHelper
{
    public static class Utils
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        public static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, uint nSize, string lpFileName);

        public static void TimerWarning(Label lblWarning)
        {
            var t = new Timer();
            t.Interval = 3000; // it will Tick in 3 seconds
            t.Tick += (s, eArg) =>
            {
                lblWarning.Text = "";
                t.Stop();
            };
            t.Start();
        }

        public static List<string> GetOpenedFiles()
        {
            return (GetOpenedFilesIn(NppMsg.ALL_OPEN_FILES, NppMsg.NPPM_GETOPENFILENAMES));
        }

        private static List<string> GetOpenedFilesIn(NppMsg view, NppMsg mode)
        {
            var output = new List<string>();
            int nbFile = (int)Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_GETNBOPENFILES, 0, (int)view);

            using (ClikeStringArray cStrArray = new ClikeStringArray(nbFile, Win32.MAX_PATH))
            {
                if (Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)mode, cStrArray.NativePointer, nbFile) != IntPtr.Zero)
                {
                    output.AddRange(cStrArray.ManagedStringsUnicode);
                }
            }
            return (output);
        }
    }


}
