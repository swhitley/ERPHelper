using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Kbg.NppPluginNET.PluginInfrastructure;
using System.Threading;
using System.Net;
using System.Collections.Generic;
using System.Xml;
using System.Text;
using System.Xml.Linq;
using System.Text.Json;
using System.Reflection;
using System.Threading.Tasks;

namespace ERPHelper
{
    public partial class WDMainForm : Form
    {
        static INotepadPPGateway notepad = new NotepadPPGateway();
        static ICScintillaGateway editor = new CScintillaGateway(PluginBase.GetCurrentScintilla());
        static Dictionary<string, string> wdWebServices = new Dictionary<string, string>();
        const string WWSURI = "https://community.workday.com/sites/default/files/file-hosting/productionapi/";
        const string WWSURL = WWSURI + "index.html";
        const string WWSSAMPLE = WWSURI + "{0}/{1}/samples/{2}.xml";
        const string wwsFilePart = "ERPHelperWebServices";
        string wwsFile = wwsFilePart + Assembly.GetExecutingAssembly().GetName().Version.ToString() + ".txt";
        static string verDefault = "";

        public WDMainForm()
        {
            InitializeComponent();

            try
            {
                Cursor = Cursors.WaitCursor;
                lblWarning.Text = "";
                // Tool Tips
                toolTip1.SetToolTip(lnkXFormInst, Properties.Resources.Instructions_XForm);
                toolTip1.SetToolTip(lnkCallAPIInst, Properties.Resources.Instructions_CallAPI);
                toolTip1.SetToolTip(lnkApiUrl, Properties.Resources.Instructions_Click2Copy2Clipboard);
                toolTip1.SetToolTip(lnkAddlActions, Properties.Resources.Instructions_AdditionalActions);
                tabControl.DrawItem += new DrawItemEventHandler(tabControl_DrawItem);
                // Web Services Download
                string wdWebServicesURL = Settings.Get(IniSection.WDWebServices, IniKey.URL);
                string iniFolder = Path.GetDirectoryName(Settings.iniFilePath);

                if (!File.Exists(iniFolder + "\\" + wwsFile))
                {
                    try
                    {
                        // Clear any older versions
                        foreach(string file in Directory.GetFiles(iniFolder, wwsFilePart + "*.*"))
                        {
                            File.Delete(file);
                        }
                        wdWebServices = WDWebService.Download(WWSURL);
                        File.WriteAllText(iniFolder + "\\" + wwsFile, JsonSerializer.Serialize(wdWebServices));
                    }
                    finally
                    {
                        Settings.Set(IniSection.WDWebServices, IniKey.URL, WWSURL);
                    }
                }
                else
                {
                    try
                    {
                        wdWebServices = WDWebService.Load(File.ReadAllText(iniFolder + "\\" + wwsFile));
                    }
                    catch(Exception ex)
                    {
                        Settings.Set(IniSection.WDWebServices, IniKey.URL, "");
                    }
                }
                foreach(KeyValuePair<string,string> service in wdWebServices)
                {
                    try
                    {
                        Uri uri = new Uri(service.Key);
                        verDefault = uri.Segments[uri.Segments.Length - 2].Replace("/","");
                    }
                    catch 
                    { 
                        // ignore exception
                    }
                    break;
                }

                // Turn Off Event Handling During Init
                this.cboWWS1.SelectedIndexChanged -= new System.EventHandler(this.cboWWS1_SelectedIndexChanged);
                this.cboWWS2.SelectedIndexChanged -= new System.EventHandler(this.cboWWS2_SelectedIndexChanged);
                this.cboXSD.SelectedIndexChanged -= new System.EventHandler(this.cboXSD_SelectedIndexChanged);
                this.txtVersion1.TextChanged -= new System.EventHandler(this.txtVersion1_TextChanged);
                this.txtVersion2.TextChanged -= new System.EventHandler(this.txtVersion2_TextChanged);

                // Web Services
                cboWWS1.DisplayMember = "Value";
                cboWWS1.ValueMember = "Key";
                cboWWS1.DataSource = new BindingSource(wdWebServices, null);

                cboWWS2.DisplayMember = "Value";
                cboWWS2.ValueMember = "Key";
                cboWWS2.DataSource = new BindingSource(wdWebServices, null);

                // Connections
                ConnectionsLoad();

                // Init
                // Workday Studio Files
                string dir = Settings.Get(IniSection.WDStudio, IniKey.Workspace);
                if (!String.IsNullOrEmpty(dir) && Directory.Exists(dir))
                {
                    txtWDStudioFolder.Text = dir;
                    string filter = Settings.Get(IniSection.WDStudio, IniKey.WorkspaceFilter);
                    if (!String.IsNullOrEmpty(filter))
                    {
                        txtFilter.Text = filter;
                        TreeViewUpdate(txtWDStudioFolder.Text, txtFilter.Text);
                    }
                }
                pnlTreeView.Size = new Size(450, 609);

                // Web Services
                cboWWS1.SelectedIndex = cboWWS1.FindStringExact(Settings.Get(IniSection.State, cboWWS1.Name));
                cboXSD_Load(cboWWS1.ReturnKey());
                cboXSD.SelectedIndex = cboXSD.FindStringExact(Settings.Get(IniSection.State, cboXSD.Name));
                txtVersion1.Text = Settings.Get(IniSection.WDWebServices, IniKey.Version);
                if(String.IsNullOrEmpty(txtVersion1.Text))
                {
                    txtVersion1.Text = verDefault;
                }

                // API
                cboConnections.SelectedIndex = cboConnections.FindStringExact(Settings.Get(IniSection.State, cboConnections.Name));
                cboWWS2.SelectedIndex = cboWWS2.FindStringExact(Settings.Get(IniSection.State, cboWWS2.Name));
                txtVersion2.Text = Settings.Get(IniSection.WDWebServices, IniKey.Version);
                if (cboConnections.SelectedIndex != ListBox.NoMatches && cboWWS2.SelectedIndex != ListBox.NoMatches)
                {
                    string conn = cboConnections.SelectedItem.ToString();
                    string service = cboWWS2.ReturnValue();
                    lnkApiUrl.Text = WDWebService.BuildApiUrl(conn, service, txtVersion2.Text);
                }
                if (String.IsNullOrEmpty(txtVersion2.Text))
                {
                    txtVersion2.Text = verDefault;
                }

                // Hide Update Tab
                Octokit release = new Octokit();
                Task<GitHubRelease> task = Task.Run(() => release.GetLatest());
                task.Wait();
                if (task.Result != null & task.Result.Version != null & task.Result.Description != null)
                {
                    txtVersionDescr.Text = task.Result.Version + Environment.NewLine + task.Result.Description;
                }
                if (!task.Result.UpdateAvailable)
                {
                  tabControl.Controls.Remove(tabUpdate);
                }

                // Init as Soap
                radSoap.Checked = true;
                radGet.Checked = true;

                // Initial Tab
                string tab = Settings.Get(IniSection.State, tabControl.Name);
                if (!String.IsNullOrEmpty(tab))
                {
                    try
                    {
                        tabControl.SelectTab(tab);
                    }
                    catch
                    {
                        // ignore exception
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERP Helper Start", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Turn On Event Handling
                this.cboWWS1.SelectedIndexChanged += new System.EventHandler(this.cboWWS1_SelectedIndexChanged);
                this.cboWWS2.SelectedIndexChanged += new System.EventHandler(this.cboWWS2_SelectedIndexChanged);
                this.cboXSD.SelectedIndexChanged += new System.EventHandler(this.cboXSD_SelectedIndexChanged);
                this.txtVersion1.TextChanged += new System.EventHandler(this.txtVersion1_TextChanged);
                this.txtVersion2.TextChanged += new System.EventHandler(this.txtVersion2_TextChanged);
                Cursor = Cursors.Default;
            }
        }

        private void ConnectionsLoad()
        {
            try
            {
                cboConnections.Items.Clear();
                string connNames = Settings.Get(IniSection.Connections, IniKey.Names);
                if (!String.IsNullOrEmpty(connNames))
                {
                    string[] conns = connNames.Split(',');
                    foreach (string conn in conns)
                    {
                        cboConnections.Items.Add(conn);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("An unexpected error occurred. " + ex.Message, "Connections Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            try
            {
                // Get the item from the collection.
                TabPage _tabPage = tabControl.TabPages[e.Index];

                // Get the real bounds for the tab rectangle.
                Rectangle _tabBounds = tabControl.GetTabRect(e.Index);

                if (e.State == DrawItemState.Selected)
                {
                    _textBrush = SystemBrushes.ControlText;
                    g.FillRectangle(SystemBrushes.Control, e.Bounds);

                }
                else
                {
                    _textBrush = SystemBrushes.InactiveCaptionText;
                    g.FillRectangle(SystemBrushes.InactiveCaption, e.Bounds);

                }

                Font _tabFont = new Font(new FontFamily(SystemFonts.MenuFont.Name), 16.0f, FontStyle.Regular, GraphicsUnit.Pixel);

                // Draw string. Center the text.
                StringFormat _stringFlags = new StringFormat();
                _stringFlags.Alignment = StringAlignment.Center;
                _stringFlags.LineAlignment = StringAlignment.Center;
                g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
            }
            catch(Exception ex)
            {
                MessageBox.Show("An unexpected error occurred. " + ex.Message, "Tab Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTransform_Click(object sender, EventArgs e)
        {
            string xmlFileName = "";
            string xmlData = "";
            string xslData = "";
            string working = "Working...";

            // Check each file to the right of the XML file.
            bool foundXML = false;
            bool foundXSLT = false;
            bool foundXForm = false;

            try
            {
                Cursor = Cursors.WaitCursor;
                // Get the current doctype
                LangType docType = LangType.L_TEXT;
                Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_GETCURRENTLANGTYPE, 0, ref docType);
                bool isDocTypeXML = docType == LangType.L_XML;

                // Return if doctype is not XML
                if (!isDocTypeXML)
                {
                    lblWarning.Text = "Please select an XML file to transform.";
                    Utils.TimerWarning(lblWarning);
                    return;
                }

                // Get XML text
                xmlFileName = notepad.GetCurrentFilePath();
                xmlData = editor.GetAllText();
                

                // **************************************************
                // Find the XSLT document
                // **************************************************
                // Count of opened files
                int fileCnt = (int)Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_GETNBOPENFILES, 0, 0);

                using (ClikeStringArray cStrArray = new ClikeStringArray(fileCnt, Win32.MAX_PATH))
                {
                    if (Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_GETNBOPENFILES, cStrArray.NativePointer, fileCnt) != IntPtr.Zero)
                        // Search for the XSLT file
                        foreach (string file in cStrArray.ManagedStringsUnicode)
                        {
                            if (foundXML)
                            {
                                // Check for an XML document
                                Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_SWITCHTOFILE, 0, file);
                                Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_GETCURRENTLANGTYPE, 0, ref docType);
                                isDocTypeXML = docType == LangType.L_XML;
                                if (isDocTypeXML && !foundXSLT)
                                {
                                    foundXSLT = true;
                                    xslData = editor.GetAllText();
                                }
                                if (foundXSLT)
                                {
                                    if (file.ToLower().IndexOf(".xform") > 0)
                                    {
                                        Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_SWITCHTOFILE, 0, file);
                                        foundXForm = true;
                                        break;
                                    }
                                }
                            }
                            if (file == xmlFileName)
                            {
                                foundXML = true;
                            }
                        }
                    if (foundXML && foundXSLT)
                    {
                        if (!foundXForm)
                        {
                            notepad.FileNew();
                            Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_SAVECURRENTFILEAS, 0, Path.GetTempFileName() + ".xform");
                            foundXForm = true;
                        }
                        editor.SetText(working);
                        working = "";
                        Application.DoEvents();
                        var data = SaxonXForm.TransformXml(xmlData, xslData);
                        editor.SetXML(data + Environment.NewLine);
                    }
                    else
                    {
                        MessageBox.Show("The XML and XSLT documents could not be identified.", "ERP Helper", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show(message, "ERP Helper", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (foundXForm)
                {
                    if(working.Length == 0)
                    {
                        try
                        {
                            editor.SetText(working + Environment.NewLine);
                        }
                        catch
                        {
                            // ignore exception
                        }
                    }                        
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnFolderSelect_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowserDialog1.SelectedPath = txtWDStudioFolder.Text;
                DialogResult result = folderBrowserDialog1.ShowDialog();
                Cursor = Cursors.WaitCursor;
                if (result == DialogResult.OK)
                {
                    txtWDStudioFolder.Text = folderBrowserDialog1.SelectedPath;
                    folderBrowserDialog1.Dispose();
                    Application.DoEvents();
                    Thread.Sleep(250);                    
                    Settings.Set(IniSection.WDStudio, IniKey.Workspace, txtWDStudioFolder.Text);
                    TreeViewUpdate(txtWDStudioFolder.Text, txtFilter.Text);
                }
                             
            }
            catch(Exception ex)
            {
                // ignore exception
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                // Look for a file extension.
                if (e.Node.Text.Contains("."))
                {
                    Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_DOOPEN, 0, e.Node.Tag.ToString());
                }
            }
            // If the file is not found, handle the exception and inform the user.
            catch (System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("File not found.", "WD Studio File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                TreeViewUpdate(txtWDStudioFolder.Text, txtFilter.Text);
                Settings.Set(IniSection.WDStudio, IniKey.WorkspaceFilter, txtFilter.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred.", "File Filter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void TreeViewUpdate(string dir, string filter)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                DirectoryInfo d = new DirectoryInfo(dir);
                if (d.Parent == null && MessageBox.Show("The root folder has been selected. " +
                    "This may take some time.\n\nContinue?", "Root Folder",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                treeView1.Update(dir, filter, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred.", "File List Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            try
            {
                Settings.Set(IniSection.State, tabControl.Name, e.TabPage.Name);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred.", "Save State for Tabs", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenXML_Click(object sender, EventArgs e)
        {
            string sample = "";
            string url;

            try
            {
                Cursor = Cursors.WaitCursor;
                if (cboWWS1.SelectedIndex != ListBox.NoMatches && cboXSD.SelectedIndex != ListBox.NoMatches && !String.IsNullOrEmpty(txtVersion1.Text))
                {
                    url = String.Format(WWSSAMPLE, cboWWS1.ReturnValue(), txtVersion1.Text, cboXSD.ReturnValue());

                    using (var webClient = new WebClient())
                    {
                        sample = webClient.DownloadString(url);
                    }
                }

                if (sample.Length > 0)
                {
                    sample = sample.Replace("bsvc:version=\"string\"", "bsvc:version=\"" + txtVersion1.Text + "\"");
                    notepad.FileNew();
                    editor.SetXML(new XDeclaration("1.0", "UTF-8", null).ToString() + Environment.NewLine + sample + Environment.NewLine);
                }
                else
                {
                    throw new Exception("Sample could not be generated.  Check for a valid Service and Operation.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Generate XML Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void cboWWS1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboWWS1.SelectedIndex != ListBox.NoMatches)
            {
                try
                {
                    Settings.Set(IniSection.State, cboWWS1.Name, cboWWS1.ReturnValue());
                    cboXSD_Load(cboWWS1.ReturnKey());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "WWS Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cboXSD_Load(string url)
        {
            string xml;
            XmlDocument xmlDoc = new XmlDocument();

            try
            {
                if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
                {
                    using (var webClient = new WebClient())
                    {
                        xml = webClient.DownloadString(url);
                    }
                    xmlDoc.LoadXml(xml);
                    XmlNamespaceManager ns = new XmlNamespaceManager(xmlDoc.NameTable);
                    ns.AddNamespace("xsd", "http://www.w3.org/2001/XMLSchema");
                    XmlNodeList nodes = xmlDoc.SelectNodes("xsd:schema/xsd:element", ns);

                    Dictionary<string, string> items = new Dictionary<string, string>();

                    foreach (XmlNode node in nodes)
                    {
                        string key = node.Attributes["name"].Value;
                        string value = key;
                        items.Add(key, value);
                    }
                    cboXSD.DataSource = null;
                    cboXSD.DataSource = new BindingSource(items, null);
                    cboXSD.DisplayMember = "Value";
                    cboXSD.ValueMember = "Key";
                    cboXSD.SavedDatasource = null;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("An unexpected error occurred. " + ex.Message, "Load Operations Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCallAPI_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(lblPassword.Text))
                {
                    using (PasswordForm passwordForm = new PasswordForm())
                    {
                        if (passwordForm.ShowDialog() == DialogResult.OK)
                        {
                            lblPassword.Text = Crypto.Protect(passwordForm.Password);
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                string tenant = txtTenant.Text;
                string username = txtUsername.Text + "@" + tenant;
                string password = Crypto.Unprotect(lblPassword.Text);
                string serviceURL = lnkApiUrl.Text;
                string data = editor.GetAllText();

                try
                {
                    Cursor = Cursors.WaitCursor;
                    notepad.FileNew();
                    if (radSoap.Checked)
                    {
                        editor.SetXML(WDWebService.CallAPI(username, password, lnkApiUrl.Text, data));
                    }
                    else
                    {
                        string method = radGet.Text.ToUpper();
                        foreach (RadioButton r in flwRestActions.Controls)
                        {
                            if (r.Checked)
                                method = r.Text.ToUpper();
                        }
                        editor.SetXML(WDWebService.CallRest(txtUsername.Text, password, txtRest.Text, method, radRaaS.Checked, data));
                    }
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                string message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show(message, "Web API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnGetSOAP_Click(object sender, EventArgs e)
        {
            try
            {
                string xmlData = editor.GetAllText();
                notepad.FileNew();
                editor.SetXML(WDWebService.WrapSOAP("username", "password", xmlData) + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SOAP Generator Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConns_Click(object sender, EventArgs e)
        {
            using (Forms.WDConnForm frmConnection = new Forms.WDConnForm())
            {
                try
                {
                    if (cboConnections.SelectedIndex != ListBox.NoMatches)
                    {
                        frmConnection.SelectedConnection = cboConnections.SelectedItem.ToString();
                    }
                    frmConnection.ShowDialog(this);
                    ConnectionsLoad();
                    cboConnections.SelectedIndex = cboConnections.FindStringExact(frmConnection.SelectedConnection);
                    lblPassword.Text = frmConnection.Password;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Connections Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cboConnections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboConnections.SelectedIndex != ListBox.NoMatches)
            {
                try
                {
                    string conn = cboConnections.SelectedItem.ToString();
                    string tenant = Settings.Get(IniSection.Connection, conn, IniKey.Tenant);
                    string service = cboWWS2.ReturnValue();
                    string version = Settings.Get(IniSection.WDWebServices, IniKey.Version);
                    txtTenant.Text = tenant;
                    txtUsername.Text = Settings.Get(IniSection.Connection, conn, IniKey.Username);
                    lnkApiUrl.Text = WDWebService.BuildApiUrl(conn, service, version);
                    Settings.Set(IniSection.State, cboConnections.Name, conn);
                    lblPassword.Text = "";
                    string password = Settings.Get(IniSection.Connection, conn, IniKey.Password);
                    if (!String.IsNullOrEmpty(password))
                    {
                        lblPassword.Text = password;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error selecting a connection. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtVersion2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtVersion2.Text))
                {
                    txtVersion2.Text = verDefault;
                }
                Settings.Set(IniSection.WDWebServices, IniKey.Version, txtVersion2.Text);
                if (cboConnections.SelectedIndex != ListBox.NoMatches)
                {
                    string conn = cboConnections.SelectedItem.ToString();
                    string service = cboWWS2.ReturnValue();
                    lnkApiUrl.Text = WDWebService.BuildApiUrl(conn, service, txtVersion2.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving version. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboWWS2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboWWS2.SelectedIndex != ListBox.NoMatches && cboConnections.SelectedIndex != ListBox.NoMatches)
            {
                try
                {
                    Settings.Set(IniSection.State, cboWWS2.Name,cboWWS2.ReturnValue());
                    string conn = cboConnections.SelectedItem.ToString();
                    string service = cboWWS2.ReturnValue();
                    lnkApiUrl.Text = WDWebService.BuildApiUrl(conn, service, txtVersion2.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Web Service Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cboXSD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboXSD.SelectedIndex != ListBox.NoMatches)
            {
                try
                {
                    Settings.Set(IniSection.State, cboXSD.Name, cboXSD.ReturnValue());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error selecting an operation. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lnkURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Clipboard.SetText(lnkApiUrl.Text);
                lnkApiUrl.LinkVisited = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving to clipboard. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkWWS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                lnkWWS.LinkVisited = true;
                System.Diagnostics.Process.Start("https://community.workday.com/sites/default/files/file-hosting/productionapi/index.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred. " + ex.Message, "WWS Link Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkInstructions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            toolTip1.SetToolTip(lnkXFormInst, Properties.Resources.Instructions_XForm);
        }

        private void lnkCallAPIInst_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            toolTip1.SetToolTip(lnkCallAPIInst, Properties.Resources.Instructions_CallAPI);
        }

        private void tabWDStudioFiles_Resize(object sender, EventArgs e)
        {
            // Addresses a bug in Winforms that was hiding control borders on resize.
            this.Refresh();
        }

        private void txtVersion1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtVersion1.Text))
                {
                    txtVersion1.Text = verDefault;
                }
                Settings.Set(IniSection.WDWebServices, IniKey.Version, txtVersion1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred. " + ex.Message, "Version Change Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSampleAPIRequest_Click(object sender, EventArgs e)
        {
            try
            {
                notepad.FileNew();
                editor.SetXML(Properties.Resources.Sample_GetWorkers.Replace("{0}", txtVersion2.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating sample file. " + ex.Message, "Sample Request Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkAddlActions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            toolTip1.SetToolTip(lnkAddlActions, Properties.Resources.Instructions_AdditionalActions);
        }

        private void lnkLatestUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                lnkLatestUpdate.LinkVisited = true;
                System.Diagnostics.Process.Start(lnkLatestUpdate.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred. " + ex.Message, "Latest Update Link Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboXSD_TextUpdate(object sender, EventArgs e)
        {
            try
            {
                cboXSD.TextFilter(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred. " + ex.Message, "Operation Filter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void radRaaS_CheckedChanged(object sender, EventArgs e)
        {
            cboWWS2.Visible = false;
            txtVersion2.Visible = false;
            lblService.Text = "Url";
            lblVersion2.Visible = false;
            lnkApiUrl.Visible = false;
            txtRest.Visible = true;
            flwRestActions.Visible = false;
            lnkCallAPIInst.Visible = false;
            lblInstructions2.Visible = false;
            grpActions.Refresh();

        }

        private void radSoap_CheckedChanged(object sender, EventArgs e)
        {
            cboWWS2.Visible = true;
            txtVersion2.Visible = true;
            lblService.Text = "Service";
            lblVersion2.Visible = true;
            lnkApiUrl.Visible = true;
            txtRest.Visible = false;
            flwRestActions.Visible = false;
            lnkCallAPIInst.Visible = true;
            lblInstructions2.Visible = true;
            grpActions.Refresh();

        }

        private void radRestNoAuth_CheckedChanged(object sender, EventArgs e)
        {
            radRaaS_CheckedChanged(sender, e);
            flwRestActions.Visible = false;
        }
    }
}
