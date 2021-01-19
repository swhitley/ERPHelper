using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ERPHelper
{
    public partial class CListBox : ListBox
    {
        public string ValuesToString(string proposedValue = "")
        {
            List<string> conns = new List<string>();
            foreach (var conn in this.Items)
            {
                conns.Add(conn.ToString());
            }
            if (!String.IsNullOrEmpty(proposedValue))
            {
                conns.Add(proposedValue);
            }

            return String.Join(",", conns.ToArray());
        }
    }
}
