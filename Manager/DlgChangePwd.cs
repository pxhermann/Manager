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
                GM.ShowErrorMessageBox(this, "Old password doesn't match!");
                tbOldPwd.Focus();
                tbOldPwd.SelectAll();
                e.Cancel = true;
                return;
            }
/*            if ( string.IsNullOrEmpty(tbNewPwd.Text) )
            {
                GM.ShowErrorMessageBox(this, "New password may not be empty!");
                tbNewPwd.Focus();
                e.Cancel = true;
                return;
            }
*/            if ( tbNewPwd.Text != tbPwdConfirm.Text )
            {
                GM.ShowErrorMessageBox(this, "Confirm password incorrect!");
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
