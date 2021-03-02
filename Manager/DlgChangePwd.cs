using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Manager
{
    public partial class DlgChangePwd : Form
    {
        private string oldPwd = "";
        public DlgChangePwd(string oldPwd)
        {
            InitializeComponent();

            this.oldPwd = oldPwd;
        }

        private void DlgChangePwd_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ( DialogResult != DialogResult.OK )
                return;
        // check data 
            if ( tbOldPwd.Text != oldPwd )
            {
                MessageBox.Show(this, "Old password doesn't match!", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbOldPwd.Focus();
                tbOldPwd.SelectAll();
                e.Cancel = true;
                return;
            }
            //
/*          if ( tbNewPwd.Text.Length < 1 )
            {
                MessageBox.Show(this, "New password may not be empty!", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbNewPwd.Focus();
                e.Cancel = true;
                return;
            }
*/          if ( tbNewPwd.Text != tbPwdConfirm.Text )
            {
                MessageBox.Show(this, "Confirm password incorrect!", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbPwdConfirm.Focus();
                tbPwdConfirm.SelectAll();
                e.Cancel = true;
                return;
            }

            if ( tbNewPwd.Text == oldPwd )
                DialogResult = DialogResult.Cancel;
        }
    }
}
