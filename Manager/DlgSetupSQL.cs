using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Manager
{
	public partial class DlgSetupSQL : Form
	{
        public SqlConnData Data;
		public DlgSetupSQL()
		{
			InitializeComponent();

            Data.Reset();
		}

#region UI event handlers
		private void DlgSetupBasic_Load(object sender, EventArgs e)
		{
            cbServer.Text = Data.Server;
            radioAuthSQL.Checked = Data.AuthSQL;
            radioAuthWin.Checked = !Data.AuthSQL;
            tbUser.Text = Data.User;
            tbPwd.Text = Data.Pwd;
            cbDatabase.Text = Data.Database;
            
			radioAuth_CheckedChanged(null, null);
		}
        private void DlgSetupDB_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ( DialogResult != DialogResult.OK )
                return;

            e.Cancel = !SaveData(true);
        }
		private void radioAuth_CheckedChanged(object sender, EventArgs e)
		{
            tbUser.Enabled = radioAuthSQL.Checked;
            tbPwd.Enabled = radioAuthSQL.Checked;
		}
        private void cbServer_DropDown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                cbServer.Items.Clear();

                string s;
                DataTable serversTable = System.Data.Sql.SqlDataSourceEnumerator.Instance.GetDataSources();
                foreach(DataRow row in serversTable.Rows)
                {
                    if ( row.IsNull("InstanceName") )
                        s = row["ServerName"].ToString();
                    else 
                        s = string.Format("{0}\\{1}", row["ServerName"], row["InstanceName"]);
                    cbServer.Items.Add(s);
                }
            }
            catch(Exception ex)
            {
                string s = string.Format("Error occured when loading server list{0}{0}{1}", Environment.NewLine, ex.Message);
                MessageBox.Show(this, s, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void cbDatabase_DropDown(object sender, EventArgs e)
        {       
			if ( !SaveData(false) )
				return;

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                cbDatabase.Items.Clear();

                using (SqlConnection conn = new SqlConnection(Data.GetConnStr(false)) )
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT name FROM master.dbo.sysdatabases ORDER BY name", conn);    // WHERE dbid > 6 ~ to exclude system databases

                    using ( SqlDataReader set = cmd.ExecuteReader() )
                        while ( set.Read() )
                            cbDatabase.Items.Add(set.GetString(0));
            }
            }
            catch (Exception ex)
            {
                string s = string.Format("Error occured when reading database list!{0}{0}{1}", Environment.NewLine, ex.Message);
                MessageBox.Show(this, s, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
		private void btnTestConn_Click(object sender, EventArgs e)
		{
			if ( !SaveData(false) )
				return;

            Cursor.Current = Cursors.WaitCursor;
            try
            {
				// try to open connection
                using (SqlConnection conn = new SqlConnection(Data.GetConnStr(false)) )
					conn.Open();

                MessageBox.Show(this, "Test connection succeeded!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                GM.ReportError(this, ex, "Test connection failed!");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
		}
#endregion   

#region Helper methods
        private bool SaveData(bool inclDB)
        {
            // server
            if (cbServer.Text.Trim().Length < 1)
            {
                MessageBox.Show(this, "Enter server!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbServer.Focus();
                return false;
            }
            // database
            if (inclDB && cbDatabase.Text.Trim().Length < 1)
            {
                MessageBox.Show(this, "Enter database!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbDatabase.Focus();
                return false;
            }
            // user for SQL authentication
            if (radioAuthSQL.Checked && tbUser.Text.Trim().Length < 1)
            {
                MessageBox.Show(this, "Enter user name!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbUser.Focus();
                return false;
            }

            Data.Server = cbServer.Text;
            Data.AuthSQL= radioAuthSQL.Checked;
            Data.User   = tbUser.Text;
            Data.Pwd    = tbPwd.Text;
            Data.Database=cbDatabase.Text;

			return true;
        }
#endregion
	}
}