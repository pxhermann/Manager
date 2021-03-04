using System;
using System.Data;
using System.Windows.Forms;

namespace Manager
{
    public partial class ViewAddress : BaseView
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
                GM.ShowErrorMessageBox(this, "Error occured when adding address to database!", ex);
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
                    GM.ShowErrorMessageBox(this, "No row selected!");
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
                GM.ShowErrorMessageBox(this, "Error occured when editing address!", ex);
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
                    GM.ShowErrorMessageBox(this, "No row selected!");
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
                GM.ShowErrorMessageBox(this, "Error occured when deleting address from database!", ex);
            }
        }
    }
}
