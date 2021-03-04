using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Manager
{
	public partial class DlgSetupDB : Form
	{
        public SqlConnData Data = new SqlConnData();
		public DlgSetupDB()
		{
			InitializeComponent();
		}
		private void DlgSetupDB_Load(object sender, EventArgs e)
		{
            cbServer.Text = Data.Server;
            radioAuthSQL.Checked = Data.AuthSQL;
            radioAuthWin.Checked = !Data.AuthSQL;
            tbUser.Text = Data.User;
            tbPwd.Text = Data.Pwd;
            cbDatabase.Text = Data.Database;
            
			radioAuthSQL_CheckedChanged(null, null);
		}
        private void DlgSetupDB_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
                e.Cancel = !SaveData(true);
        }
		private void radioAuthSQL_CheckedChanged(object sender, EventArgs e)
		{
            tbUser.Enabled = radioAuthSQL.Checked;
            tbPwd.Enabled = radioAuthSQL.Checked;
		}
        private void cbServer_DropDown(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            cbServer.BeginUpdate();
            try
            {
                cbServer.Items.Clear();
                foreach(DataRow row in SqlDataSourceEnumerator.Instance.GetDataSources().Rows)
                    cbServer.Items.Add(row.IsNull("InstanceName")?row["ServerName"].ToString():string.Format("{0}\\{1}", row["ServerName"], row["InstanceName"]));
            }
            catch(Exception ex) { GM.ShowErrorMessageBox(this, "Error occured when loading server list!", ex); }
            finally
            {
                cbServer.EndUpdate();
                Cursor.Current = Cursors.Default; 
            }
        }
        private void cbDatabase_DropDown(object sender, EventArgs e)
        {       
			if ( !SaveData(false) )
				return;

            Cursor.Current = Cursors.WaitCursor;
            cbDatabase.BeginUpdate();
            try
            {
                cbDatabase.Items.Clear();
                using (SqlConnection conn = new SqlConnection(Data.GetConnectionString(false)) )
                {
                    conn.Open();

                    // open recordset with databases
                    using (SqlCommand cmd = new SqlCommand("SELECT name FROM sys.databases ORDER BY name ASC", conn))   // SELECT name FROM master..sysdatabases WHERE name LIKE '%system%' ORDER BY name ASC", conn); 
                    using (SqlDataReader reader = cmd.ExecuteReader())                                                  // WHERE dbid > 6 ~ to exclude system databases
                        while (reader.Read())
                            cbDatabase.Items.Add(reader.GetString(0));
            }
            }
            catch (Exception ex) { GM.ShowErrorMessageBox(this, "Error occured when reading database list!", ex); }
            finally
            {
                cbDatabase.EndUpdate();
                Cursor.Current = Cursors.Default;
            }
        }
		private void btnTestConn_Click(object sender, EventArgs e)
		{
            if (!SaveData(false))
                return;

            Cursor = Cursors.WaitCursor;
            try
            {
                using (SqlConnection conn = new SqlConnection(Data.GetConnectionString(false)))
                    conn.Open();

                GM.ShowInfoMessageBox(this, "Test connection succeeded!");
            }
            catch (Exception ex) { GM.ShowErrorMessageBox(this, "Test connection failed!", ex); }
            finally { Cursor.Current = Cursors.Default; }
		}

        private bool SaveData(bool inclDB)
        {
            // server
            Data.Server = cbServer.Text.Trim();
            if (string.IsNullOrEmpty(Data.Server))
            {
                GM.ShowErrorMessageBox(this, "Enter server name!");
                cbServer.Focus();
                return false;
            }
            // authentication
            Data.AuthSQL = radioAuthSQL.Checked;
            if (Data.AuthSQL)
            {
                // SQL user
                Data.User = tbUser.Text.Trim();
                if (string.IsNullOrEmpty(Data.User))
                {
                    GM.ShowErrorMessageBox(this, "Enter user!");
                    tbUser.Focus();
                    return false;
                }
                // SQL pwd
                Data.PwdDecrypted = tbPwd.Text;
            }

            // database
            if (inclDB)
            {
                Data.Database = cbDatabase.Text.Trim();
                if (string.IsNullOrEmpty(Data.Database))
                {
                    GM.ShowErrorMessageBox(this, "Enter database!");
                    cbDatabase.Focus();
                    return false;
                }
            }

			return true;
        }
	}
}