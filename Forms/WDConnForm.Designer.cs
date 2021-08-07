﻿
namespace ERPHelper.Forms
{
    partial class WDConnForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnSave = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.lblConnections = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblConnURL = new System.Windows.Forms.Label();
            this.cboConnEnv = new ERPHelper.CComboBox();
            this.lnkConnURL = new System.Windows.Forms.LinkLabel();
            this.lblTenant = new System.Windows.Forms.Label();
            this.txtTenant = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.chkSavePassword = new System.Windows.Forms.CheckBox();
            this.lnkSavePassword = new System.Windows.Forms.LinkLabel();
            this.lnkSettings = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lstConnections = new ERPHelper.CListBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(345, 492);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 32);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(426, 492);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 32);
            this.button2.TabIndex = 10;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(262, 492);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 32);
            this.btnTest.TabIndex = 8;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(12, 329);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 32);
            this.btnNew.TabIndex = 14;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // lblConnections
            // 
            this.lblConnections.Location = new System.Drawing.Point(12, 23);
            this.lblConnections.Name = "lblConnections";
            this.lblConnections.Size = new System.Drawing.Size(98, 20);
            this.lblConnections.TabIndex = 13;
            this.lblConnections.Text = "Connections";
            this.lblConnections.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(426, 545);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 32);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblName);
            this.flowLayoutPanel1.Controls.Add(this.txtName);
            this.flowLayoutPanel1.Controls.Add(this.lblConnURL);
            this.flowLayoutPanel1.Controls.Add(this.cboConnEnv);
            this.flowLayoutPanel1.Controls.Add(this.lnkConnURL);
            this.flowLayoutPanel1.Controls.Add(this.lblTenant);
            this.flowLayoutPanel1.Controls.Add(this.txtTenant);
            this.flowLayoutPanel1.Controls.Add(this.lblUsername);
            this.flowLayoutPanel1.Controls.Add(this.txtUsername);
            this.flowLayoutPanel1.Controls.Add(this.lblPassword);
            this.flowLayoutPanel1.Controls.Add(this.txtPassword);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.lnkSettings);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(226, 20);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(274, 468);
            this.flowLayoutPanel1.TabIndex = 16;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblName.Location = new System.Drawing.Point(3, 6);
            this.lblName.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(106, 20);
            this.lblName.TabIndex = 16;
            this.lblName.Text = "Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(6, 29);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(238, 26);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lblConnURL
            // 
            this.lblConnURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblConnURL.Location = new System.Drawing.Point(3, 67);
            this.lblConnURL.Margin = new System.Windows.Forms.Padding(0, 9, 3, 0);
            this.lblConnURL.Name = "lblConnURL";
            this.lblConnURL.Size = new System.Drawing.Size(106, 20);
            this.lblConnURL.TabIndex = 25;
            this.lblConnURL.Text = "URL";
            this.lblConnURL.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cboConnEnv
            // 
            this.cboConnEnv.FormattingEnabled = true;
            this.cboConnEnv.Location = new System.Drawing.Point(6, 90);
            this.cboConnEnv.Name = "cboConnEnv";
            this.cboConnEnv.Size = new System.Drawing.Size(238, 28);
            this.cboConnEnv.TabIndex = 2;
            this.cboConnEnv.SelectedIndexChanged += new System.EventHandler(this.cboConnEnv_SelectedIndexChanged);
            // 
            // lnkConnURL
            // 
            this.lnkConnURL.AutoEllipsis = true;
            this.lnkConnURL.AutoSize = true;
            this.lnkConnURL.Location = new System.Drawing.Point(6, 121);
            this.lnkConnURL.MaximumSize = new System.Drawing.Size(225, 49);
            this.lnkConnURL.MinimumSize = new System.Drawing.Size(225, 49);
            this.lnkConnURL.Name = "lnkConnURL";
            this.lnkConnURL.Size = new System.Drawing.Size(225, 49);
            this.lnkConnURL.TabIndex = 3;
            this.lnkConnURL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkConnURL_LinkClicked);
            // 
            // lblTenant
            // 
            this.lblTenant.Location = new System.Drawing.Point(3, 179);
            this.lblTenant.Margin = new System.Windows.Forms.Padding(0, 9, 3, 0);
            this.lblTenant.Name = "lblTenant";
            this.lblTenant.Size = new System.Drawing.Size(150, 20);
            this.lblTenant.TabIndex = 18;
            this.lblTenant.Text = "Tenant";
            this.lblTenant.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtTenant
            // 
            this.txtTenant.Location = new System.Drawing.Point(6, 202);
            this.txtTenant.Name = "txtTenant";
            this.txtTenant.Size = new System.Drawing.Size(238, 26);
            this.txtTenant.TabIndex = 4;
            this.txtTenant.TextChanged += new System.EventHandler(this.txtTenant_TextChanged);
            // 
            // lblUsername
            // 
            this.lblUsername.Location = new System.Drawing.Point(3, 240);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(0, 9, 3, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(165, 20);
            this.lblUsername.TabIndex = 20;
            this.lblUsername.Text = "Username";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(6, 263);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(238, 26);
            this.txtUsername.TabIndex = 5;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(3, 301);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(0, 9, 3, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(132, 20);
            this.lblPassword.TabIndex = 22;
            this.lblPassword.Text = "Password";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(6, 324);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(238, 26);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.chkSavePassword);
            this.flowLayoutPanel2.Controls.Add(this.lnkSavePassword);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(6, 356);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(200, 28);
            this.flowLayoutPanel2.TabIndex = 27;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // chkSavePassword
            // 
            this.chkSavePassword.AutoSize = true;
            this.chkSavePassword.Location = new System.Drawing.Point(3, 3);
            this.chkSavePassword.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.chkSavePassword.Name = "chkSavePassword";
            this.chkSavePassword.Size = new System.Drawing.Size(144, 24);
            this.chkSavePassword.TabIndex = 8;
            this.chkSavePassword.Text = "Save Password";
            this.chkSavePassword.UseVisualStyleBackColor = true;
            this.chkSavePassword.CheckedChanged += new System.EventHandler(this.chkSavePassword_CheckedChanged);
            // 
            // lnkSavePassword
            // 
            this.lnkSavePassword.AutoSize = true;
            this.lnkSavePassword.Location = new System.Drawing.Point(147, 3);
            this.lnkSavePassword.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.lnkSavePassword.Name = "lnkSavePassword";
            this.lnkSavePassword.Size = new System.Drawing.Size(26, 20);
            this.lnkSavePassword.TabIndex = 27;
            this.lnkSavePassword.TabStop = true;
            this.lnkSavePassword.Text = "[?]";
            this.lnkSavePassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkSavePassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSavePassword_LinkClicked);
            // 
            // lnkSettings
            // 
            this.lnkSettings.AutoSize = true;
            this.lnkSettings.Location = new System.Drawing.Point(6, 393);
            this.lnkSettings.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lnkSettings.Name = "lnkSettings";
            this.lnkSettings.Size = new System.Drawing.Size(171, 20);
            this.lnkSettings.TabIndex = 28;
            this.lnkSettings.TabStop = true;
            this.lnkSettings.Text = "View Configuration File";
            this.lnkSettings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSettings_LinkClicked);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 20000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 100;
            // 
            // lstConnections
            // 
            this.lstConnections.FormattingEnabled = true;
            this.lstConnections.ItemHeight = 20;
            this.lstConnections.Location = new System.Drawing.Point(12, 54);
            this.lstConnections.Name = "lstConnections";
            this.lstConnections.Size = new System.Drawing.Size(194, 264);
            this.lstConnections.TabIndex = 0;
            this.lstConnections.SelectedIndexChanged += new System.EventHandler(this.lstConnections_SelectedIndexChanged);
            // 
            // WDConnForm
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 589);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblConnections);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lstConnections);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WDConnForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Connections";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WDConnForm_FormClosing);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CListBox lstConnections;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label lblConnections;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblConnURL;
        private CComboBox cboConnEnv;
        private System.Windows.Forms.Label lblTenant;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtTenant;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.LinkLabel lnkConnURL;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.CheckBox chkSavePassword;
        private System.Windows.Forms.LinkLabel lnkSavePassword;
        private System.Windows.Forms.LinkLabel lnkSettings;
    }
}