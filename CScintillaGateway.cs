using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kbg.NppPluginNET.PluginInfrastructure;

namespace ERPHelper
{
    public interface ICScintillaGateway : IScintillaGateway
    {
        void SetXML(string xml);
    }
    class CScintillaGateway : ScintillaGateway, ICScintillaGateway
    {
        public CScintillaGateway(IntPtr scintilla) : base(scintilla)
        {
        }
        public void SetXML(string xml)
        {
            this.SetText(xml);
            NppMenuCmd mnuCmd = NppMenuCmd.IDM_LANG_XML;
            Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_MENUCOMMAND, 0, mnuCmd);
        }
    }
}
