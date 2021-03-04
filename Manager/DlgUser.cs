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
    public partial class DlgUser : Form
    {
        public User Data = new User();

        public DlgUser()
        {
            InitializeComponent();
        }
        private void DlgUser_Load(object sender, EventArgs e)
        {
            tbName.Text = Data.Name;
            tbPwd.Text = tbPwdConfirm.Text = Data.Pwd;

            chbAdmin.Checked = Data.ARadmin;
            chbUser.Checked = Data.ARuser;
            chbAddr.Checked = Data.ARaddr;
            chbProd.Checked = Data.ARprod;

            chbAdmin_CheckedChanged(null, null);
        }
        private void DlgUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ( DialogResult != DialogResult.OK )
                return;
        // check data 
            if ( string.IsNullOrEmpty(tbName.Text) )
            {
                GM.ShowErrorMessageBox(this, "Name may not be empty!");
                tbName.Focus();
                e.Cancel = true;
                return;
            }
/*            if ( string.IsNullOrEmpty(tbPwd.Text) )
            {
                GM.ShowErrorMessageBox(this, "Password may not be empty!");
                tbPwd.Focus();
                e.Cancel = true;
                return;
            }
*/            if ( tbPwd.Text != tbPwdConfirm.Text )
            {
                GM.ShowErrorMessageBox(this, "Confirm password incorrect!");
                tbPwdConfirm.Focus();
                tbPwdConfirm.SelectAll();
                e.Cancel = true;
                return;
            }
        // save data
            Data.Name = tbName.Text;
            Data.Pwd  = tbPwd.Text;

            Data.ARadmin = chbAdmin.Checked;
            Data.ARuser  = Data.ARadmin || chbUser.Checked;
            Data.ARaddr  = Data.ARadmin || chbAddr.Checked;
            Data.ARprod  = Data.ARadmin || chbProd.Checked;
        }
        private void chbAdmin_CheckedChanged(object sender, EventArgs e)
        {
            chbAddr.Enabled = chbProd.Enabled = chbUser.Enabled = !chbAdmin.Checked;
        }
    }
}
