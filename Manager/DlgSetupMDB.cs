using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

namespace Manager
{
    public partial class DlgSetupMDB : Form
    {
        public MdbConnData Data;

        public DlgSetupMDB()
        {
            InitializeComponent();
        }
#region UI event handlers
        private void DlgSetupMDB_Load(object sender, EventArgs e)
        {
            tbDbFile.Text = Data.DbFile;
            tbUser.Text = Data.User;
            tbPwd.Text = Data.Pwd;
        }
        private void DlgSetupMDB_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ( DialogResult != DialogResult.OK )
                return;

            e.Cancel = !SaveData(true);
        }
        private void btnSelDbFile_Click(object sender, EventArgs e)
        {
            using ( OpenFileDialog dlg = new OpenFileDialog() )
            {
                if ( tbDbFile.Text.Length > 0 )
                    try { dlg.InitialDirectory = Path.GetDirectoryName(tbDbFile.Text); }
                    catch { }
                dlg.Filter = "Access database files (*.mdb)|*.mdb";
                if ( dlg.ShowDialog() != DialogResult.OK )
                    return;

                tbDbFile.Text = dlg.FileName;
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
                using (OleDbConnection conn = new OleDbConnection(Data.GetConnStr()) )
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
            if (tbDbFile.Text.Trim().Length < 1)
            {
                MessageBox.Show(this, "Enter database file!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbDbFile.Focus();
                return false;
            }

            Data.DbFile = tbDbFile.Text;
            Data.User   = tbUser.Text;
            Data.Pwd    = tbPwd.Text;

			return true;
        }
#endregion
    }
}
