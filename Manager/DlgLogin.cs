using System;
using System.Windows.Forms;

namespace Manager
{
    public partial class DlgLogin : Form
    {
        public int SelUserID = DB.INVALID_ID;

        public DlgLogin()
        {
            InitializeComponent();
        }
        private void DlgLogin_Load(object sender, EventArgs e)
        {
            try
            {
                cbUser.DataSource = DB.GetDataTable("SELECT * FROM Users WHERE deldate IS NULL ORDER BY user_name");
                cbUser.DisplayMember = "user_name";
                cbUser.ValueMember = "user_id";

                cbUser.SelectedValue = SelUserID;
                if ( cbUser.SelectedIndex < 0 )
                    cbUser.SelectedIndex = 0;
            }
            catch(Exception ex)
            {
                GM.ShowErrorMessageBox(this, "Login failed. Cannot read list of users!", ex);
                DialogResult = DialogResult.Cancel;
            }
        }
        private void DlgLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ( DialogResult != DialogResult.OK )
                return;

            if ( cbUser.SelectedIndex < 0 )
            {
                GM.ShowErrorMessageBox(this, "No user selected!");
                cbUser.Focus();

                e.Cancel = true;
                return;
            }

            Cursor = Cursors.WaitCursor;
            try
            {
                string s;
                if ( string.IsNullOrEmpty(tbPwd.Text) )
                    s = string.Format("SELECT COUNT(*) FROM Users WHERE user_id = {0} AND (user_pwd IS NULL or user_pwd = '')", cbUser.SelectedValue);
                else
                    s = string.Format("SELECT COUNT(*) FROM Users WHERE user_id = {0} AND user_pwd = '{1}'", cbUser.SelectedValue, GM.DESEncrypt(tbPwd.Text));
                if ( (int)DB.ExecuteScalar(s) < 1 )
                {
                    GM.ShowErrorMessageBox(this, "Password incorrect!");
                    tbPwd.Focus();
                    tbPwd.SelectAll();

                    e.Cancel = true;
                    return;
                }
            }
            catch(Exception ex)
            {
                GM.ShowErrorMessageBox(this, "Checking password failed!", ex);
                e.Cancel = true;
            }
            finally { Cursor = Cursors.Default; }

            SelUserID = (int)cbUser.SelectedValue;
        }
    }
}
