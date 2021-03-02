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
    public partial class ViewAddress : Manager.BaseView
    {
        public ViewAddress()
        {
            InitializeComponent();

            selectCommand = "SELECT * FROM Address WHERE deldate IS NULL";
            idColumnName = "addr_id";

            AddTextColumn("addr_name", "Name", 150);
            AddTextColumn("addr_street", "Street", 150);
            AddTextColumn("addr_city", "City", 150);
            AddTextColumn("addr_zip", "Zip", 50);
            AddTextColumn("addr_ico", "IC", 70);
            AddTextColumn("addr_dic", "DIC", 100);

            DataGridViewColumn col = AddTextColumn("addr_tel", "Phone", 150);
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        public override void OnAdd()
        {
            try
            {
                using ( DlgAddress dlg = new DlgAddress() )
                {
                    if ( dlg.ShowDialog() != DialogResult.OK )
                        return;

                    DataTable tbl = bindDataSrc.DataSource as DataTable;
                    if ( tbl == null )
                        return;

                    DataRow newRow = tbl.NewRow();
                    dlg.Data.Save(newRow);
                    tbl.Rows.Add(newRow);   // saving to database is envoked automatically, see. BaseView.tbl_RowChanged
                    if ( !newRow.IsNull("addr_id") )
                    {
                        prevSelID = Convert.ToInt32(newRow["addr_id"]);
                        RestorePrevSelection();
                    }
                }
            }
            catch(Exception ex)
            {
                GM.ReportError(this, ex, "Error occured when adding address to database!");
            }
        }
        public override void OnEdit()
        {
            base.OnEdit();

            try
            {
                DataGridViewRow curRow = dgView.CurrentRow;
                if ( curRow == null )
                {
                    MessageBox.Show(this, "No row selected!", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataRowView rView = curRow.DataBoundItem as DataRowView;
                if ( rView == null || rView.Row == null )
                    return;
                using ( DlgAddress dlg = new DlgAddress() )
                {
                    dlg.Data.Load(rView.Row);
                    if ( dlg.ShowDialog() != DialogResult.OK )
                        return;

                    dlg.Data.Save(rView.Row); // saving to database is envoked automatically, see. BaseView.tbl_RowChanged
                }
            }
            catch(Exception ex)
            {
                GM.ReportError(this, ex, "Error occured when editing address!");
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
                GM.ReportError(this, ex, "Error occured when deleting address from database!");
            }
        }
    }
}
