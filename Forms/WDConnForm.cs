using System;
using System.Windows.Forms;
using Kbg.NppPluginNET.PluginInfrastructure;

namespace ERPHelper.Forms
{
    public partial class WDConnForm : Form
    {
        public string SelectedConnection { get; set; }
        public string Password { get; set; }

        public WDConnForm()
        {
            InitializeComponent();

            try
            {
                toolTip1.SetToolTip(lnkConnURL, Properties.Resources.Instructions_Click2Copy2Clipboard);
                toolTip1.SetToolTip(lnkSavePassword, Properties.Resources.Instructions_SavePassword);

                // Load Environment Dropdown
                cboConnEnv.AddWorkdayURLs();

                // Get previously saved connections
                string conns = Settings.Get(IniSection.Connections, IniKey.Names);
                lstConnections.Items.Clear();
                foreach (string conn in conns.Split(','))
                {
                    if (!String.IsNullOrEmpty(conn))
                    {
                        lstConnections.Items.Add(conn);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error initializing the connection form. " + ex.Message, "Connections Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnNew_Click(null, null);
        }

        protected override void OnShown(EventArgs e)
        {
            int ndx = lstConnections.FindStringExact(this.SelectedConnection);
            if (ndx != ListBox.NoMatches)
            {
                lstConnections.SelectedIndex = ndx;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(lstConnections.SelectedItem != null )
            {
                if (MessageBox.Show("Delete " + lstConnections.SelectedItem.ToString() + "?", "Delete Connection", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        string conn = lstConnections.SelectedItem.ToString();
                        Settings.DeleteSection(IniSection.Connection, conn);
                        lstConnections.Items.RemoveAt(lstConnections.SelectedIndex);
                        lstConnections.Refresh();
                        string conns = lstConnections.ValuesToString();
                        Settings.Set(IniSection.Connections, IniKey.Names, conns);
                        btnNew_Click(null, null);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Select a connection to delete.", "Select Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text.Length == 0)
                {
                    throw new Exception("Name is required.");
                }
                if(cboConnEnv.SelectedIndex == ListBox.NoMatches)
                {
                    throw new Exception("An environment URL must be selected.");
                }

                txtName.Enabled = false;
                string conn = txtName.Text;
                string tenant = txtTenant.Text;
                string username = txtUsername.Text;
                string password = Crypto.Protect(txtPassword.Text);
                string envText = ((WDURLItem)cboConnEnv.SelectedItem).Value;
                string envURL = ((WDURLItem)cboConnEnv.SelectedItem).Key;
                bool savePassword = chkSavePassword.Checked;
                this.Password = password;
                string url = "";

                // New Item
                if (lstConnections.FindStringExact(txtName.Text) == ListBox.NoMatches)
                {
                    if (lstConnections.ValuesToString(txtName.Text).Length + conn.Length <= 500)
                    {
                        lstConnections.Items.Add(txtName.Text);
                        string conns = lstConnections.ValuesToString();
                        Settings.Set(IniSection.Connections, IniKey.Names, conns);
                    }
                    else
                    {
                        throw new Exception("List of all names cannot exceed 500 characters.");
                    }
                }
                Settings.Set(IniSection.Connection, conn, IniKey.Environment, envText);
                
                Settings.Set(IniSection.Connection, conn, IniKey.Tenant, tenant);
                Settings.Set(IniSection.Connection, conn, IniKey.Username, username);
                Settings.Set(IniSection.Connection, conn, IniKey.SavePassword, savePassword.ToString());

                if (cboConnEnv.SelectedIndex != ListBox.NoMatches && txtTenant.Text.Length > 0
                    && txtUsername.Text.Length > 0 && txtPassword.Text.Length > 0)
                {
                    url = WDWebService.GetServiceURL(((WDURLItem)cboConnEnv.SelectedItem).Key, txtTenant.Text, txtUsername.Text, txtPassword.Text);
                    url = String.Concat(url, "/", tenant, "/");
                    Settings.Set(IniSection.Connection, conn, IniKey.URL, url);
                    lnkConnURL.Text = url;
                }

                if (chkSavePassword.Checked)
                {
                    Settings.Set(IniSection.Connection, conn, IniKey.Password, password);
                }
                else
                {
                    if (txtPassword.Text.Length == 0)
                    {
                        Settings.Set(IniSection.Connection, conn, IniKey.Password, "");
                    }
                }
                MessageBox.Show("Saved", "Connection Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving connection. " + Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstConnections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstConnections.SelectedIndex != ListBox.NoMatches)
            {
                try
                {
                    string conn = lstConnections.SelectedItem.ToString();
                    SelectedConnection = conn;
                    txtName.Text = conn;
                    txtName.Enabled = false;
                    cboConnEnv.SelectedIndex = cboConnEnv.FindStringExact(Settings.Get(IniSection.Connection, conn, IniKey.Environment));
                    lnkConnURL.Text = Settings.Get(IniSection.Connection, conn, IniKey.URL);
                    txtTenant.Text = Settings.Get(IniSection.Connection, conn, IniKey.Tenant);
                    txtUsername.Text = Settings.Get(IniSection.Connection, conn, IniKey.Username);
                    txtPassword.Text = Crypto.Unprotect(Settings.Get(IniSection.Connection, conn, IniKey.Password));
                    this.Password = Settings.Get(IniSection.Connection, conn, IniKey.Password);
                    bool savePassword = false;
                    Boolean.TryParse(Settings.Get(IniSection.Connection, conn, IniKey.SavePassword), out savePassword);
                    chkSavePassword.Checked = savePassword;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error selecting a connection. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            txtName.Text = txtName.Text.RemoveNonAlphaNumeric();
            txtName.SelectionStart = txtName.Text.Length;
            txtName.SelectionLength = 0;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            lstConnections.SelectedIndex = -1;
            txtName.Text = "";
            txtName.Enabled = true;
            cboConnEnv.SelectedIndex = -1;
            txtTenant.Text = "";
            txtUsername.Text = "";
            chkSavePassword.Checked = false;
            txtPassword.Text = "";
            this.Password = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboConnEnv_SelectedIndexChanged(object sender, EventArgs e)
        {
            lnkConnURL.Text = "";
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                string url = WDWebService.GetServiceURL(((WDURLItem)cboConnEnv.SelectedItem).Key, txtTenant.Text, txtUsername.Text, txtPassword.Text);
                if(url.Length > 4 && url.Substring(0,4) == "http")
                {
                    lnkConnURL.Text = String.Concat(url, "/", txtTenant.Text, "/");
                    MessageBox.Show("Success", "Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if(url.Length > 30)
                    {
                        url = url.Substring(0, 30) + "...";
                    }
                    throw new Exception("Data returned: " + url);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Test failed. " + ex.Message, "Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkConnURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Clipboard.SetText(lnkConnURL.Text);
                lnkConnURL.LinkVisited = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error during clipboard save. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (lstConnections.ValuesToString(((TextBox)sender).Text).Length > 500)
            {
                MessageBox.Show("List of all names cannot exceed 500 characters.", "Maximum Name List", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkSavePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            toolTip1.SetToolTip(lnkSavePassword, Properties.Resources.Instructions_SavePassword);
        }

        private void lnkSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_DOOPEN, 0, Settings.iniFilePath);
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
