using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ERPHelper
{
    public partial class CComboBox : ComboBox
    {
        public void AddWorkdayURLs()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(Properties.Resources.WDEnvironments);
            foreach (XmlNode node in xmlDoc.SelectNodes("//env"))
            {
                this.Items.Add(new WDURLItem("https://" + node.SelectSingleNode("e2-endpoint").InnerText + "/ccx", node.Attributes["name"].Value));
            }
        }

        public string ReturnKey()
        {
            if (this.SelectedIndex != ListBox.NoMatches)
            {
                return ((KeyValuePair<string, string>)this.SelectedItem).Key.ToString();
            }

            return "";
        }

        public string ReturnValue()
        {
            if (this.SelectedIndex != ListBox.NoMatches)
            {
                return ((KeyValuePair<string, string>) this.SelectedItem).Value.ToString();
            }

            return "";
        }

        public int FindByKey(string key)
        {
            for (int ndx = 0; ndx < this.Items.Count; ndx++)
            {
                WDURLItem url = (WDURLItem) this.Items[ndx];
                if (key == url.Key)
                {
                    return ndx;
                }
            }
            return -1;
        }
    }
}
