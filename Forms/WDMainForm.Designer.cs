namespace ERPHelper
{
    partial class WDMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

       

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WDMainForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabXForm = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel13 = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.lnkXFormInst = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTransform = new System.Windows.Forms.Button();
            this.lblWarning = new System.Windows.Forms.Label();
            this.tabWDStudioFiles = new System.Windows.Forms.TabPage();
            this.pnlTreeView = new System.Windows.Forms.Panel();
            this.pnlFiles = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel10 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtWDStudioFolder = new System.Windows.Forms.TextBox();
            this.btnFolderSelect = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutPanel11 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.tabWebSvcs = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblWWS = new System.Windows.Forms.Label();
            this.lblOperation = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblVersion1 = new System.Windows.Forms.Label();
            this.txtVersion1 = new System.Windows.Forms.TextBox();
            this.btnGenXML = new System.Windows.Forms.Button();
            this.lblWebServiceResources = new System.Windows.Forms.Label();
            this.lnkWWS = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.tabAPICalls = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel9 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSampleAPIRequest = new System.Windows.Forms.Button();
            this.btnGetSOAP = new System.Windows.Forms.Button();
            this.flowLayoutPanel14 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblInstructions3 = new System.Windows.Forms.Label();
            this.lnkAddlActions = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel8 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnConns = new System.Windows.Forms.Button();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTenant = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.txtVersion2 = new System.Windows.Forms.TextBox();
            this.lnkApiUrl = new System.Windows.Forms.LinkLabel();
            this.flowLayoutPanel12 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCallAPI = new System.Windows.Forms.Button();
            this.lblInstructions2 = new System.Windows.Forms.Label();
            this.lnkCallAPIInst = new System.Windows.Forms.LinkLabel();
            this.lblPassword = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.treeView1 = new ERPHelper.CTreeView();
            this.cboWWS1 = new ERPHelper.CComboBox();
            this.cboXSD = new ERPHelper.CComboBox();
            this.cboConnections = new ERPHelper.CComboBox();
            this.cboWWS2 = new ERPHelper.CComboBox();
            this.tabControl.SuspendLayout();
            this.tabXForm.SuspendLayout();
            this.flowLayoutPanel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabWDStudioFiles.SuspendLayout();
            this.pnlTreeView.SuspendLayout();
            this.pnlFiles.SuspendLayout();
            this.flowLayoutPanel10.SuspendLayout();
            this.flowLayoutPanel11.SuspendLayout();
            this.tabWebSvcs.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tabAPICalls.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.flowLayoutPanel9.SuspendLayout();
            this.flowLayoutPanel14.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel7.SuspendLayout();
            this.flowLayoutPanel8.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel12.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl.Controls.Add(this.tabXForm);
            this.tabControl.Controls.Add(this.tabWDStudioFiles);
            this.tabControl.Controls.Add(this.tabWebSvcs);
            this.tabControl.Controls.Add(this.tabAPICalls);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl.ItemSize = new System.Drawing.Size(25, 110);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(407, 378);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 4;
            this.tabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl_Selected);
            // 
            // tabXForm
            // 
            this.tabXForm.AutoScroll = true;
            this.tabXForm.BackColor = System.Drawing.SystemColors.Info;
            this.tabXForm.Controls.Add(this.flowLayoutPanel13);
            this.tabXForm.Controls.Add(this.pictureBox1);
            this.tabXForm.Controls.Add(this.label2);
            this.tabXForm.Controls.Add(this.btnTransform);
            this.tabXForm.Controls.Add(this.lblWarning);
            this.tabXForm.Location = new System.Drawing.Point(114, 4);
            this.tabXForm.Margin = new System.Windows.Forms.Padding(2);
            this.tabXForm.Name = "tabXForm";
            this.tabXForm.Padding = new System.Windows.Forms.Padding(2);
            this.tabXForm.Size = new System.Drawing.Size(289, 370);
            this.tabXForm.TabIndex = 0;
            this.tabXForm.Text = "XSLT";
            // 
            // flowLayoutPanel13
            // 
            this.flowLayoutPanel13.Controls.Add(this.label6);
            this.flowLayoutPanel13.Controls.Add(this.lnkXFormInst);
            this.flowLayoutPanel13.Location = new System.Drawing.Point(126, 125);
            this.flowLayoutPanel13.Name = "flowLayoutPanel13";
            this.flowLayoutPanel13.Size = new System.Drawing.Size(143, 33);
            this.flowLayoutPanel13.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 6);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 6, 0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Instructions";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lnkXFormInst
            // 
            this.lnkXFormInst.AutoSize = true;
            this.lnkXFormInst.Location = new System.Drawing.Point(64, 6);
            this.lnkXFormInst.Margin = new System.Windows.Forms.Padding(0, 6, 2, 0);
            this.lnkXFormInst.Name = "lnkXFormInst";
            this.lnkXFormInst.Size = new System.Drawing.Size(19, 13);
            this.lnkXFormInst.TabIndex = 6;
            this.lnkXFormInst.TabStop = true;
            this.lnkXFormInst.Text = "[?]";
            this.lnkXFormInst.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkXFormInst.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkInstructions_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 40);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 66);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Transform an XML file using XSLT";
            // 
            // btnTransform
            // 
            this.btnTransform.Location = new System.Drawing.Point(10, 125);
            this.btnTransform.Margin = new System.Windows.Forms.Padding(2);
            this.btnTransform.Name = "btnTransform";
            this.btnTransform.Size = new System.Drawing.Size(81, 25);
            this.btnTransform.TabIndex = 0;
            this.btnTransform.Text = "Transform";
            this.btnTransform.UseVisualStyleBackColor = true;
            this.btnTransform.Click += new System.EventHandler(this.btnTransform_Click);
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.Location = new System.Drawing.Point(13, 151);
            this.lblWarning.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(0, 13);
            this.lblWarning.TabIndex = 1;
            // 
            // tabWDStudioFiles
            // 
            this.tabWDStudioFiles.AutoScroll = true;
            this.tabWDStudioFiles.BackColor = System.Drawing.SystemColors.Info;
            this.tabWDStudioFiles.Controls.Add(this.pnlTreeView);
            this.tabWDStudioFiles.Controls.Add(this.pnlFiles);
            this.tabWDStudioFiles.Location = new System.Drawing.Point(114, 4);
            this.tabWDStudioFiles.Margin = new System.Windows.Forms.Padding(2);
            this.tabWDStudioFiles.Name = "tabWDStudioFiles";
            this.tabWDStudioFiles.Padding = new System.Windows.Forms.Padding(2);
            this.tabWDStudioFiles.Size = new System.Drawing.Size(289, 370);
            this.tabWDStudioFiles.TabIndex = 1;
            this.tabWDStudioFiles.Text = "Studio Files";
            this.tabWDStudioFiles.Resize += new System.EventHandler(this.tabWDStudioFiles_Resize);
            // 
            // pnlTreeView
            // 
            this.pnlTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTreeView.AutoSize = true;
            this.pnlTreeView.Controls.Add(this.treeView1);
            this.pnlTreeView.Location = new System.Drawing.Point(0, 140);
            this.pnlTreeView.Margin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.pnlTreeView.Name = "pnlTreeView";
            this.pnlTreeView.Padding = new System.Windows.Forms.Padding(10, 0, 0, 10);
            this.pnlTreeView.Size = new System.Drawing.Size(260, 396);
            this.pnlTreeView.TabIndex = 12;
            // 
            // pnlFiles
            // 
            this.pnlFiles.Controls.Add(this.label3);
            this.pnlFiles.Controls.Add(this.label4);
            this.pnlFiles.Controls.Add(this.flowLayoutPanel10);
            this.pnlFiles.Controls.Add(this.label5);
            this.pnlFiles.Controls.Add(this.flowLayoutPanel11);
            this.pnlFiles.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiles.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlFiles.Location = new System.Drawing.Point(2, 2);
            this.pnlFiles.Margin = new System.Windows.Forms.Padding(2);
            this.pnlFiles.Name = "pnlFiles";
            this.pnlFiles.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.pnlFiles.Size = new System.Drawing.Size(268, 134);
            this.pnlFiles.TabIndex = 11;
            this.pnlFiles.WrapContents = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Find and Open Workday Studio Files";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 31);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 10, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Workday Studio Workspace";
            // 
            // flowLayoutPanel10
            // 
            this.flowLayoutPanel10.Controls.Add(this.txtWDStudioFolder);
            this.flowLayoutPanel10.Controls.Add(this.btnFolderSelect);
            this.flowLayoutPanel10.Location = new System.Drawing.Point(9, 44);
            this.flowLayoutPanel10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.flowLayoutPanel10.Name = "flowLayoutPanel10";
            this.flowLayoutPanel10.Size = new System.Drawing.Size(241, 30);
            this.flowLayoutPanel10.TabIndex = 12;
            // 
            // txtWDStudioFolder
            // 
            this.txtWDStudioFolder.Location = new System.Drawing.Point(2, 2);
            this.txtWDStudioFolder.Margin = new System.Windows.Forms.Padding(2);
            this.txtWDStudioFolder.Name = "txtWDStudioFolder";
            this.txtWDStudioFolder.Size = new System.Drawing.Size(193, 20);
            this.txtWDStudioFolder.TabIndex = 5;
            // 
            // btnFolderSelect
            // 
            this.btnFolderSelect.Location = new System.Drawing.Point(199, 0);
            this.btnFolderSelect.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.btnFolderSelect.Name = "btnFolderSelect";
            this.btnFolderSelect.Size = new System.Drawing.Size(21, 21);
            this.btnFolderSelect.TabIndex = 6;
            this.btnFolderSelect.Text = "...";
            this.btnFolderSelect.UseVisualStyleBackColor = true;
            this.btnFolderSelect.Click += new System.EventHandler(this.btnFolderSelect_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 82);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 6, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "File Filter";
            // 
            // flowLayoutPanel11
            // 
            this.flowLayoutPanel11.Controls.Add(this.txtFilter);
            this.flowLayoutPanel11.Controls.Add(this.btnFilter);
            this.flowLayoutPanel11.Location = new System.Drawing.Point(9, 95);
            this.flowLayoutPanel11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.flowLayoutPanel11.Name = "flowLayoutPanel11";
            this.flowLayoutPanel11.Size = new System.Drawing.Size(235, 31);
            this.flowLayoutPanel11.TabIndex = 13;
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(2, 2);
            this.txtFilter.Margin = new System.Windows.Forms.Padding(2);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(193, 20);
            this.txtFilter.TabIndex = 8;
            this.txtFilter.Text = "*.xslt, *.xml, *.xsl";
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnFilter.BackgroundImage = global::ERPHelper.Properties.Resources.Filter_16x;
            this.btnFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFilter.Location = new System.Drawing.Point(199, 0);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(21, 21);
            this.btnFilter.TabIndex = 9;
            this.btnFilter.Text = "...";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // tabWebSvcs
            // 
            this.tabWebSvcs.AutoScroll = true;
            this.tabWebSvcs.BackColor = System.Drawing.SystemColors.Info;
            this.tabWebSvcs.Controls.Add(this.flowLayoutPanel1);
            this.tabWebSvcs.Controls.Add(this.label7);
            this.tabWebSvcs.Location = new System.Drawing.Point(114, 4);
            this.tabWebSvcs.Margin = new System.Windows.Forms.Padding(2);
            this.tabWebSvcs.Name = "tabWebSvcs";
            this.tabWebSvcs.Size = new System.Drawing.Size(289, 370);
            this.tabWebSvcs.TabIndex = 2;
            this.tabWebSvcs.Text = "Web Services";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblWWS);
            this.flowLayoutPanel1.Controls.Add(this.cboWWS1);
            this.flowLayoutPanel1.Controls.Add(this.lblOperation);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.lblVersion1);
            this.flowLayoutPanel1.Controls.Add(this.txtVersion1);
            this.flowLayoutPanel1.Controls.Add(this.btnGenXML);
            this.flowLayoutPanel1.Controls.Add(this.lblWebServiceResources);
            this.flowLayoutPanel1.Controls.Add(this.lnkWWS);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(7, 34);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(263, 272);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // lblWWS
            // 
            this.lblWWS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWWS.AutoSize = true;
            this.lblWWS.Location = new System.Drawing.Point(4, 2);
            this.lblWWS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWWS.Name = "lblWWS";
            this.lblWWS.Size = new System.Drawing.Size(43, 13);
            this.lblWWS.TabIndex = 22;
            this.lblWWS.Text = "Service";
            this.lblWWS.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblOperation
            // 
            this.lblOperation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOperation.AutoSize = true;
            this.lblOperation.Location = new System.Drawing.Point(4, 53);
            this.lblOperation.Margin = new System.Windows.Forms.Padding(2, 13, 2, 0);
            this.lblOperation.Name = "lblOperation";
            this.lblOperation.Size = new System.Drawing.Size(53, 13);
            this.lblOperation.TabIndex = 14;
            this.lblOperation.Text = "Operation";
            this.lblOperation.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.cboXSD);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(4, 68);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(258, 26);
            this.flowLayoutPanel2.TabIndex = 20;
            // 
            // lblVersion1
            // 
            this.lblVersion1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVersion1.AutoSize = true;
            this.lblVersion1.Location = new System.Drawing.Point(5, 109);
            this.lblVersion1.Margin = new System.Windows.Forms.Padding(3, 13, 2, 0);
            this.lblVersion1.Name = "lblVersion1";
            this.lblVersion1.Size = new System.Drawing.Size(42, 13);
            this.lblVersion1.TabIndex = 24;
            this.lblVersion1.Text = "Version";
            // 
            // txtVersion1
            // 
            this.txtVersion1.Location = new System.Drawing.Point(6, 124);
            this.txtVersion1.Margin = new System.Windows.Forms.Padding(4, 2, 2, 2);
            this.txtVersion1.Name = "txtVersion1";
            this.txtVersion1.Size = new System.Drawing.Size(68, 20);
            this.txtVersion1.TabIndex = 25;
            this.txtVersion1.TextChanged += new System.EventHandler(this.txtVersion1_TextChanged);
            // 
            // btnGenXML
            // 
            this.btnGenXML.Location = new System.Drawing.Point(4, 162);
            this.btnGenXML.Margin = new System.Windows.Forms.Padding(2, 16, 2, 2);
            this.btnGenXML.Name = "btnGenXML";
            this.btnGenXML.Size = new System.Drawing.Size(139, 25);
            this.btnGenXML.TabIndex = 4;
            this.btnGenXML.Text = "Generate";
            this.btnGenXML.UseVisualStyleBackColor = true;
            this.btnGenXML.Click += new System.EventHandler(this.btnGenXML_Click);
            // 
            // lblWebServiceResources
            // 
            this.lblWebServiceResources.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblWebServiceResources.AutoSize = true;
            this.lblWebServiceResources.Location = new System.Drawing.Point(4, 221);
            this.lblWebServiceResources.Margin = new System.Windows.Forms.Padding(2, 32, 2, 0);
            this.lblWebServiceResources.Name = "lblWebServiceResources";
            this.lblWebServiceResources.Size = new System.Drawing.Size(58, 13);
            this.lblWebServiceResources.TabIndex = 26;
            this.lblWebServiceResources.Text = "Resources";
            // 
            // lnkWWS
            // 
            this.lnkWWS.AutoSize = true;
            this.lnkWWS.Location = new System.Drawing.Point(4, 237);
            this.lnkWWS.Margin = new System.Windows.Forms.Padding(2, 3, 2, 2);
            this.lnkWWS.Name = "lnkWWS";
            this.lnkWWS.Size = new System.Drawing.Size(203, 13);
            this.lnkWWS.TabIndex = 23;
            this.lnkWWS.TabStop = true;
            this.lnkWWS.Text = "Workday Web Services (WWS) Directory";
            this.lnkWWS.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkWWS_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(7, 10);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(239, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Generate Sample Workday API Requests";
            // 
            // tabAPICalls
            // 
            this.tabAPICalls.AutoScroll = true;
            this.tabAPICalls.BackColor = System.Drawing.SystemColors.Info;
            this.tabAPICalls.Controls.Add(this.groupBox3);
            this.tabAPICalls.Controls.Add(this.groupBox2);
            this.tabAPICalls.Controls.Add(this.groupBox1);
            this.tabAPICalls.Controls.Add(this.lblPassword);
            this.tabAPICalls.Controls.Add(this.label9);
            this.tabAPICalls.Location = new System.Drawing.Point(114, 4);
            this.tabAPICalls.Margin = new System.Windows.Forms.Padding(2);
            this.tabAPICalls.Name = "tabAPICalls";
            this.tabAPICalls.Size = new System.Drawing.Size(289, 370);
            this.tabAPICalls.TabIndex = 3;
            this.tabAPICalls.Text = "API Calls";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.flowLayoutPanel9);
            this.groupBox3.Location = new System.Drawing.Point(7, 323);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(262, 126);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Additional Actions";
            // 
            // flowLayoutPanel9
            // 
            this.flowLayoutPanel9.Controls.Add(this.btnSampleAPIRequest);
            this.flowLayoutPanel9.Controls.Add(this.btnGetSOAP);
            this.flowLayoutPanel9.Controls.Add(this.flowLayoutPanel14);
            this.flowLayoutPanel9.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel9.Location = new System.Drawing.Point(4, 18);
            this.flowLayoutPanel9.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel9.Name = "flowLayoutPanel9";
            this.flowLayoutPanel9.Padding = new System.Windows.Forms.Padding(3);
            this.flowLayoutPanel9.Size = new System.Drawing.Size(250, 98);
            this.flowLayoutPanel9.TabIndex = 22;
            this.flowLayoutPanel9.WrapContents = false;
            // 
            // btnSampleAPIRequest
            // 
            this.btnSampleAPIRequest.Location = new System.Drawing.Point(5, 5);
            this.btnSampleAPIRequest.Margin = new System.Windows.Forms.Padding(2);
            this.btnSampleAPIRequest.Name = "btnSampleAPIRequest";
            this.btnSampleAPIRequest.Size = new System.Drawing.Size(123, 25);
            this.btnSampleAPIRequest.TabIndex = 23;
            this.btnSampleAPIRequest.Text = "Create Sample";
            this.btnSampleAPIRequest.UseVisualStyleBackColor = true;
            this.btnSampleAPIRequest.Click += new System.EventHandler(this.btnSampleAPIRequest_Click);
            // 
            // btnGetSOAP
            // 
            this.btnGetSOAP.Location = new System.Drawing.Point(5, 34);
            this.btnGetSOAP.Margin = new System.Windows.Forms.Padding(2);
            this.btnGetSOAP.Name = "btnGetSOAP";
            this.btnGetSOAP.Size = new System.Drawing.Size(123, 25);
            this.btnGetSOAP.TabIndex = 10;
            this.btnGetSOAP.Text = "Add SOAP Wrapper";
            this.btnGetSOAP.UseVisualStyleBackColor = true;
            this.btnGetSOAP.Click += new System.EventHandler(this.btnGetSOAP_Click);
            // 
            // flowLayoutPanel14
            // 
            this.flowLayoutPanel14.Controls.Add(this.lblInstructions3);
            this.flowLayoutPanel14.Controls.Add(this.lnkAddlActions);
            this.flowLayoutPanel14.Location = new System.Drawing.Point(6, 64);
            this.flowLayoutPanel14.Name = "flowLayoutPanel14";
            this.flowLayoutPanel14.Size = new System.Drawing.Size(122, 34);
            this.flowLayoutPanel14.TabIndex = 29;
            this.flowLayoutPanel14.WrapContents = false;
            // 
            // lblInstructions3
            // 
            this.lblInstructions3.AutoSize = true;
            this.lblInstructions3.Location = new System.Drawing.Point(3, 7);
            this.lblInstructions3.Margin = new System.Windows.Forms.Padding(3, 7, 0, 0);
            this.lblInstructions3.Name = "lblInstructions3";
            this.lblInstructions3.Size = new System.Drawing.Size(61, 13);
            this.lblInstructions3.TabIndex = 24;
            this.lblInstructions3.Text = "Instructions";
            this.lblInstructions3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lnkAddlActions
            // 
            this.lnkAddlActions.AutoSize = true;
            this.lnkAddlActions.Location = new System.Drawing.Point(64, 7);
            this.lnkAddlActions.Margin = new System.Windows.Forms.Padding(0, 7, 2, 0);
            this.lnkAddlActions.Name = "lnkAddlActions";
            this.lnkAddlActions.Size = new System.Drawing.Size(19, 13);
            this.lnkAddlActions.TabIndex = 23;
            this.lnkAddlActions.TabStop = true;
            this.lnkAddlActions.Text = "[?]";
            this.lnkAddlActions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkAddlActions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAddlActions_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel7);
            this.groupBox2.Location = new System.Drawing.Point(7, 39);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(257, 109);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connection";
            // 
            // flowLayoutPanel7
            // 
            this.flowLayoutPanel7.Controls.Add(this.flowLayoutPanel8);
            this.flowLayoutPanel7.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel7.Controls.Add(this.flowLayoutPanel6);
            this.flowLayoutPanel7.Location = new System.Drawing.Point(4, 16);
            this.flowLayoutPanel7.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel7.Name = "flowLayoutPanel7";
            this.flowLayoutPanel7.Size = new System.Drawing.Size(249, 89);
            this.flowLayoutPanel7.TabIndex = 31;
            // 
            // flowLayoutPanel8
            // 
            this.flowLayoutPanel8.Controls.Add(this.cboConnections);
            this.flowLayoutPanel8.Controls.Add(this.btnConns);
            this.flowLayoutPanel8.Location = new System.Drawing.Point(2, 2);
            this.flowLayoutPanel8.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel8.Name = "flowLayoutPanel8";
            this.flowLayoutPanel8.Size = new System.Drawing.Size(244, 27);
            this.flowLayoutPanel8.TabIndex = 35;
            this.flowLayoutPanel8.WrapContents = false;
            // 
            // btnConns
            // 
            this.btnConns.Location = new System.Drawing.Point(213, 0);
            this.btnConns.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.btnConns.Name = "btnConns";
            this.btnConns.Size = new System.Drawing.Size(21, 21);
            this.btnConns.TabIndex = 32;
            this.btnConns.Text = "...";
            this.btnConns.UseVisualStyleBackColor = true;
            this.btnConns.Click += new System.EventHandler(this.btnConns_Click);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label12);
            this.flowLayoutPanel3.Controls.Add(this.txtTenant);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(2, 33);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(244, 25);
            this.flowLayoutPanel3.TabIndex = 33;
            this.flowLayoutPanel3.WrapContents = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(2, 2);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Tenant";
            // 
            // txtTenant
            // 
            this.txtTenant.Location = new System.Drawing.Point(63, 2);
            this.txtTenant.Margin = new System.Windows.Forms.Padding(18, 2, 2, 2);
            this.txtTenant.MaximumSize = new System.Drawing.Size(168, 25);
            this.txtTenant.MinimumSize = new System.Drawing.Size(168, 25);
            this.txtTenant.Name = "txtTenant";
            this.txtTenant.ReadOnly = true;
            this.txtTenant.Size = new System.Drawing.Size(168, 20);
            this.txtTenant.TabIndex = 19;
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.Controls.Add(this.label13);
            this.flowLayoutPanel6.Controls.Add(this.txtUsername);
            this.flowLayoutPanel6.Location = new System.Drawing.Point(2, 62);
            this.flowLayoutPanel6.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(244, 23);
            this.flowLayoutPanel6.TabIndex = 34;
            this.flowLayoutPanel6.WrapContents = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(2, 2);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Username";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(61, 2);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsername.MaximumSize = new System.Drawing.Size(168, 25);
            this.txtUsername.MinimumSize = new System.Drawing.Size(168, 25);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(168, 20);
            this.txtUsername.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel4);
            this.groupBox1.Location = new System.Drawing.Point(7, 159);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(257, 151);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Service";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.AutoSize = true;
            this.flowLayoutPanel4.Controls.Add(this.cboWWS2);
            this.flowLayoutPanel4.Controls.Add(this.flowLayoutPanel5);
            this.flowLayoutPanel4.Controls.Add(this.lnkApiUrl);
            this.flowLayoutPanel4.Controls.Add(this.flowLayoutPanel12);
            this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(4, 16);
            this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(246, 128);
            this.flowLayoutPanel4.TabIndex = 22;
            this.flowLayoutPanel4.WrapContents = false;
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.label11);
            this.flowLayoutPanel5.Controls.Add(this.txtVersion2);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(2, 27);
            this.flowLayoutPanel5.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(133, 25);
            this.flowLayoutPanel5.TabIndex = 25;
            this.flowLayoutPanel5.WrapContents = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(2, 2);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Version";
            // 
            // txtVersion2
            // 
            this.txtVersion2.Location = new System.Drawing.Point(48, 2);
            this.txtVersion2.Margin = new System.Windows.Forms.Padding(2);
            this.txtVersion2.Name = "txtVersion2";
            this.txtVersion2.Size = new System.Drawing.Size(54, 20);
            this.txtVersion2.TabIndex = 24;
            this.txtVersion2.TextChanged += new System.EventHandler(this.txtVersion2_TextChanged);
            // 
            // lnkApiUrl
            // 
            this.lnkApiUrl.AutoEllipsis = true;
            this.lnkApiUrl.AutoSize = true;
            this.lnkApiUrl.Location = new System.Drawing.Point(2, 54);
            this.lnkApiUrl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnkApiUrl.MaximumSize = new System.Drawing.Size(225, 32);
            this.lnkApiUrl.MinimumSize = new System.Drawing.Size(225, 32);
            this.lnkApiUrl.Name = "lnkApiUrl";
            this.lnkApiUrl.Size = new System.Drawing.Size(225, 32);
            this.lnkApiUrl.TabIndex = 27;
            this.lnkApiUrl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkURL_LinkClicked);
            // 
            // flowLayoutPanel12
            // 
            this.flowLayoutPanel12.Controls.Add(this.btnCallAPI);
            this.flowLayoutPanel12.Controls.Add(this.lblInstructions2);
            this.flowLayoutPanel12.Controls.Add(this.lnkCallAPIInst);
            this.flowLayoutPanel12.Location = new System.Drawing.Point(3, 89);
            this.flowLayoutPanel12.Name = "flowLayoutPanel12";
            this.flowLayoutPanel12.Size = new System.Drawing.Size(232, 33);
            this.flowLayoutPanel12.TabIndex = 28;
            this.flowLayoutPanel12.WrapContents = false;
            // 
            // btnCallAPI
            // 
            this.btnCallAPI.Location = new System.Drawing.Point(2, 2);
            this.btnCallAPI.Margin = new System.Windows.Forms.Padding(2);
            this.btnCallAPI.Name = "btnCallAPI";
            this.btnCallAPI.Size = new System.Drawing.Size(97, 25);
            this.btnCallAPI.TabIndex = 9;
            this.btnCallAPI.Text = "Call API";
            this.btnCallAPI.UseVisualStyleBackColor = true;
            this.btnCallAPI.Click += new System.EventHandler(this.btnCallAPI_Click);
            // 
            // lblInstructions2
            // 
            this.lblInstructions2.AutoSize = true;
            this.lblInstructions2.Location = new System.Drawing.Point(126, 7);
            this.lblInstructions2.Margin = new System.Windows.Forms.Padding(25, 7, 0, 0);
            this.lblInstructions2.Name = "lblInstructions2";
            this.lblInstructions2.Size = new System.Drawing.Size(61, 13);
            this.lblInstructions2.TabIndex = 24;
            this.lblInstructions2.Text = "Instructions";
            this.lblInstructions2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lnkCallAPIInst
            // 
            this.lnkCallAPIInst.AutoSize = true;
            this.lnkCallAPIInst.Location = new System.Drawing.Point(187, 7);
            this.lnkCallAPIInst.Margin = new System.Windows.Forms.Padding(0, 7, 2, 0);
            this.lnkCallAPIInst.Name = "lnkCallAPIInst";
            this.lnkCallAPIInst.Size = new System.Drawing.Size(19, 13);
            this.lnkCallAPIInst.TabIndex = 23;
            this.lnkCallAPIInst.TabStop = true;
            this.lnkCallAPIInst.Text = "[?]";
            this.lnkCallAPIInst.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkCallAPIInst.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCallAPIInst_LinkClicked);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(71, 1161);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(0, 13);
            this.lblPassword.TabIndex = 8;
            this.lblPassword.Visible = false;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 10);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(238, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "Make API Requests using a Document";
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 20000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 100;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.treeView1.Location = new System.Drawing.Point(10, 0);
            this.treeView1.Margin = new System.Windows.Forms.Padding(0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(250, 386);
            this.treeView1.TabIndex = 7;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // cboWWS1
            // 
            this.cboWWS1.FormattingEnabled = true;
            this.cboWWS1.Location = new System.Drawing.Point(4, 17);
            this.cboWWS1.Margin = new System.Windows.Forms.Padding(2);
            this.cboWWS1.Name = "cboWWS1";
            this.cboWWS1.Size = new System.Drawing.Size(230, 21);
            this.cboWWS1.TabIndex = 0;
            this.cboWWS1.SelectedIndexChanged += new System.EventHandler(this.cboWWS1_SelectedIndexChanged);
            // 
            // cboXSD
            // 
            this.cboXSD.FormattingEnabled = true;
            this.cboXSD.Location = new System.Drawing.Point(2, 2);
            this.cboXSD.Margin = new System.Windows.Forms.Padding(2);
            this.cboXSD.Name = "cboXSD";
            this.cboXSD.Size = new System.Drawing.Size(230, 21);
            this.cboXSD.TabIndex = 1;
            this.cboXSD.SelectedIndexChanged += new System.EventHandler(this.cboXSD_SelectedIndexChanged);
            // 
            // cboConnections
            // 
            this.cboConnections.FormattingEnabled = true;
            this.cboConnections.Location = new System.Drawing.Point(2, 2);
            this.cboConnections.Margin = new System.Windows.Forms.Padding(2);
            this.cboConnections.Name = "cboConnections";
            this.cboConnections.Size = new System.Drawing.Size(207, 21);
            this.cboConnections.TabIndex = 33;
            this.cboConnections.SelectedIndexChanged += new System.EventHandler(this.cboConnections_SelectedIndexChanged);
            // 
            // cboWWS2
            // 
            this.cboWWS2.FormattingEnabled = true;
            this.cboWWS2.Location = new System.Drawing.Point(2, 2);
            this.cboWWS2.Margin = new System.Windows.Forms.Padding(2);
            this.cboWWS2.Name = "cboWWS2";
            this.cboWWS2.Size = new System.Drawing.Size(230, 21);
            this.cboWWS2.TabIndex = 22;
            this.cboWWS2.SelectedIndexChanged += new System.EventHandler(this.cboWWS2_SelectedIndexChanged);
            // 
            // WDMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(407, 378);
            this.Controls.Add(this.tabControl);
            this.Name = "WDMainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ERP Helper - Workday";
            this.tabControl.ResumeLayout(false);
            this.tabXForm.ResumeLayout(false);
            this.tabXForm.PerformLayout();
            this.flowLayoutPanel13.ResumeLayout(false);
            this.flowLayoutPanel13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabWDStudioFiles.ResumeLayout(false);
            this.tabWDStudioFiles.PerformLayout();
            this.pnlTreeView.ResumeLayout(false);
            this.pnlFiles.ResumeLayout(false);
            this.pnlFiles.PerformLayout();
            this.flowLayoutPanel10.ResumeLayout(false);
            this.flowLayoutPanel10.PerformLayout();
            this.flowLayoutPanel11.ResumeLayout(false);
            this.flowLayoutPanel11.PerformLayout();
            this.tabWebSvcs.ResumeLayout(false);
            this.tabWebSvcs.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.tabAPICalls.ResumeLayout(false);
            this.tabAPICalls.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.flowLayoutPanel9.ResumeLayout(false);
            this.flowLayoutPanel14.ResumeLayout(false);
            this.flowLayoutPanel14.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.flowLayoutPanel7.ResumeLayout(false);
            this.flowLayoutPanel8.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.flowLayoutPanel12.ResumeLayout(false);
            this.flowLayoutPanel12.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabXForm;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTransform;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.TabPage tabWDStudioFiles;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TabPage tabWebSvcs;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabAPICalls;
        private System.Windows.Forms.Button btnCallAPI;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnGetSOAP;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblOperation;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private CComboBox cboXSD;
        private System.Windows.Forms.Button btnGenXML;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private CComboBox cboWWS2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtVersion2;
        private System.Windows.Forms.LinkLabel lnkApiUrl;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel8;
        private CComboBox cboConnections;
        private System.Windows.Forms.Button btnConns;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTenant;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblWWS;
        private CComboBox cboWWS1;
        private System.Windows.Forms.LinkLabel lnkWWS;
        private System.Windows.Forms.LinkLabel lnkXFormInst;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel9;
        private System.Windows.Forms.LinkLabel lnkCallAPIInst;
        private CTreeView treeView1;
        private System.Windows.Forms.FlowLayoutPanel pnlFiles;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Button btnFolderSelect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtWDStudioFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel10;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel11;
        private System.Windows.Forms.Panel pnlTreeView;
        private System.Windows.Forms.Label lblVersion1;
        private System.Windows.Forms.TextBox txtVersion1;
        private System.Windows.Forms.Label lblWebServiceResources;
        private System.Windows.Forms.Button btnSampleAPIRequest;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel12;
        private System.Windows.Forms.Label lblInstructions2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel13;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel14;
        private System.Windows.Forms.Label lblInstructions3;
        private System.Windows.Forms.LinkLabel lnkAddlActions;
    }
}