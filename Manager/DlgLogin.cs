using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Manager
{
    public partial class DlgLogin : Form
    {
        public int SelUserID = GD.INVALID_ID;

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
                GM.ReportError(this, ex, "Login failed. Cannot read list of users!");
                DialogResult = DialogResult.Cancel;
            }
        }
        private void DlgLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ( DialogResult != DialogResult.OK )
                return;

            if ( cbUser.SelectedIndex < 0 )
            {
                MessageBox.Show(this, "No user selected!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    MessageBox.Show(this, "Password incorrect!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbPwd.Focus();
                    tbPwd.SelectAll();

                    e.Cancel = true;
                    return;
                }
            }
            catch(Exception ex)
            {
                GM.ReportError(this, ex, "Checking password failed!");
                e.Cancel = true;
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            SelUserID = (int)cbUser.SelectedValue;
        }
    }
}
