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
        string GetAllText();
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

        public string GetAllText()
        {
            const int BATCHSIZE = 10000;
            string text = "";
            int textLength = this.GetTextLength();
            
            int batches = (int) Math.Floor(textLength / (decimal) BATCHSIZE);
            int position = 0;
            for (int batch = 0; batch < batches; batch++) 
            {
                this.SetTargetRange(new Position(position), new Position(position + BATCHSIZE));
                position += BATCHSIZE;
                text += this.GetTargetText();
            }
            int batchedTextLength = Encoding.UTF8.GetByteCount(text);
            if (batchedTextLength < textLength)
            {
                this.SetTargetRange(new Position(batchedTextLength), new Position(textLength));
                text += this.GetTargetText();
            }
            return text;           
        }
    }
}
