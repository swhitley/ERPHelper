using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;

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
    }
}
