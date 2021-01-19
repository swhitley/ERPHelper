using System;
using System.Windows.Forms;

namespace ERPHelper
{
    public partial class PasswordForm : Form
    {
        public DialogResult Result { get; set; }
        public string Password { get; set; }

        public PasswordForm()
        {
            InitializeComponent();
        }

        private void btnOkay_Click(object sender, EventArgs e)
        {
            Password = txtPassword.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
