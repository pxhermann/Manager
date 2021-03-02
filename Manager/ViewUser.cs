using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Manager
{
    public partial class ViewUser : Manager.BaseView
    {
        public ViewUser()
        {
            InitializeComponent();

            selectCommand = "SELECT * FROM Users WHERE deldate is null";
            idColumnName = "user_id";

            AddTextColumn("user_name", "Name", 150);
            AddBoolColumn("user_ARadmin", "Admin", 40);
            AddBoolColumn("user_ARuser", "User", 40);
            AddBoolColumn("user_ARaddr", "Addr.", 40);
            AddBoolColumn("user_ARprod", "Prod.", 40);

            int colIdx = dgView.Columns.Add("colDummy", ""); dgView.Columns[colIdx].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        public override void OnAdd()
        {
            try
            {
                using ( DlgUser dlg = new DlgUser() )
                {
                    if ( dlg.ShowDialog() != DialogResult.OK )
                        return;

                    DataTable tbl = bindDataSrc.DataSource as DataTable;
                    if ( tbl == null )
                        return;

                    DataRow newRow = tbl.NewRow();
                    dlg.Data.Save(newRow);
                    tbl.Rows.Add(newRow);   // saving to database is envoked automatically, see. BaseView.tbl_RowChanged
                    if ( !newRow.IsNull("user_id") )
                    {
                        prevSelID = Convert.ToInt32(newRow["user_id"]);
                        RestorePrevSelection();
                    }
                }
            }
            catch(Exception ex)
            {
                GM.ReportError(this, ex, "Error occured when adding user to database!");
            }
        }
        public override void OnEdit()
        {
            try
            {
                DataGridViewRow curRow = dgView.CurrentRow;
                if ( curRow == null )
                {
                    MessageBox.Show(this, "No row selected!", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                DataRowView rView = curRow.DataBoundItem as DataRowView;
                if ( rView == null || rView.Row == null )
                    return;

                using ( DlgUser dlg = new DlgUser() )
                {
                    dlg.Data.Load(rView.Row);
                    if ( dlg.ShowDialog() != DialogResult.OK )
                        return;

                    dlg.Data.Save(rView.Row); // saving to database is envoked automatically, see. BaseView.tbl_RowChanged
                }
            }
            catch(Exception ex)
            {
                GM.ReportError(this, ex, "Error occured when editing user!");
            }
        }
        public override void OnDel()
        {
            base.OnDel();

            try
            {
                DataGridViewRow curRow = dgView.CurrentRow;
                if ( curRow == null )
                {
                    MessageBox.Show(this, "No row selected!", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                DataRowView rView = curRow.DataBoundItem as DataRowView;
                if ( rView == null || rView.Row == null )
                    return;

                rView.Row.BeginEdit();
                rView.Row["deldate"] = DateTime.Now;
                rView.Row.EndEdit();

                OnRefresh();
            }
            catch(Exception ex)
            {
                GM.ReportError(this, ex, "Error occured when deleting user from database!");
            }
        }
    }
}
