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
        public Dictionary<string, string> SavedDatasource = null;

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

        public void TextFilter(object sender, EventArgs e)
        {
            if(this.SavedDatasource == null)
            {
                this.SavedDatasource = (Dictionary<string, string>)(((BindingSource)this.DataSource).DataSource);
            }
            Dictionary<string,string> filteredItems = new Dictionary<string, string>();
            string filter_param = this.Text;

            foreach (KeyValuePair<string,string> item in this.SavedDatasource)
            {
                if (item.Value.ToUpper().Contains(filter_param.ToUpper()))
                {
                    filteredItems.Add(item.Key, item.Value);
                }
            }

            if (filteredItems.Count > 0)
            {
                this.DataSource = null;
                this.DataSource = new BindingSource(filteredItems, null);     
            }

            if (String.IsNullOrWhiteSpace(filter_param))
            { 
                this.DataSource = null;
                this.DataSource = new BindingSource(this.SavedDatasource, null);
            }

            this.DisplayMember = "Value";
            this.ValueMember = "Key";
            this.DroppedDown = true;
            Cursor.Current = Cursors.Default;

            // this will ensure that the drop down is as long as the list
            this.IntegralHeight = true;

            // remove automatically selected first item
            this.SelectedIndex = -1;

            this.Text = filter_param;

            // set the position of the cursor
            this.SelectionStart = filter_param.Length;
            this.SelectionLength = 0;
        }

    }
}
