using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.IO;

namespace Manager
{
    public partial class DlgSetupSQLCE : Form
    {
        public SqlCeConnData Data;
        public DlgSetupSQLCE()
        {
            InitializeComponent();
        }
#region UI event handlers
        private void DlgSetupSQLCE_Load(object sender, EventArgs e)
        {
            tbDbFile.Text = Data.DbFile;
            tbPwd.Text = Data.Pwd;
        }
        private void DlgSetupSQLCE_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ( DialogResult != DialogResult.OK )
                return;

            e.Cancel = !SaveData(true);
        }
        private void btnSelDbCE_Click(object sender, EventArgs e)
        {
            using ( OpenFileDialog dlg = new OpenFileDialog() )
            {
                if ( tbDbFile.Text.Length > 0 )
                    try { dlg.InitialDirectory = Path.GetDirectoryName(tbDbFile.Text); }
                    catch { }
                dlg.Filter = "SQL CE database files (*.sdf)|*.sdf";
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
                using (SqlCeConnection conn = new SqlCeConnection(Data.GetConnStr()) )
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
            Data.Pwd    = tbPwd.Text;

			return true;
        }
#endregion
    }
}
