using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Manager
{
    public partial class ViewProduct : Manager.BaseView
    {
        public ViewProduct()
        {
            InitializeComponent();

            selectCommand = "SELECT * FROM Product WHERE deldate IS NULL";
            idColumnName = "prod_id";

            AddTextColumn("prod_name", "Name", 150);
            AddTextColumn("prod_catalog", "Catalog", 100);
            AddTextColumn("prod_unit", "Unit", 150);
            {
                DataGridViewColumn col = AddTextColumn("prod_vatrate", "VAT [%]", 70);
                DataGridViewCellStyle style = new DataGridViewCellStyle();
                style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
                style.Format = "N0";
                col.DefaultCellStyle = style;
            }
            {
                DataGridViewColumn col = AddTextColumn("prod_saleprice", "Price", 100);
                DataGridViewCellStyle style = new DataGridViewCellStyle();
                style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
                style.Format = "N2";
                col.DefaultCellStyle = style;
            }
            int colIdx = dgView.Columns.Add("colDummy", ""); dgView.Columns[colIdx].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        public override void OnAdd()
        {
            try
            {
                using ( DlgProduct dlg = new DlgProduct() )
                {
                    if ( dlg.ShowDialog() != DialogResult.OK )
                        return;

                    DataTable tbl = bindDataSrc.DataSource as DataTable;
                    if ( tbl == null )
                        return;

                    DataRow newRow = tbl.NewRow();
                    dlg.Data.Save(newRow);
                    tbl.Rows.Add(newRow);   // saving to database is envoked automatically, see. BaseView.tbl_RowChanged
                    if ( !newRow.IsNull("prod_id") )
                    {
                        prevSelID = Convert.ToInt32(newRow["prod_id"]);
                        RestorePrevSelection();
                    }
                }
            }
            catch(Exception ex)
            {
                GM.ReportError(this, ex, "Error occured when adding product to database!");
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
                using ( DlgProduct dlg = new DlgProduct() )
                {
                    dlg.Data.Load(rView.Row);
                    if ( dlg.ShowDialog() != DialogResult.OK )
                        return;

                    dlg.Data.Save(rView.Row); // saving to database is envoked automatically, see. BaseView.tbl_RowChanged
                }
            }
            catch(Exception ex)
            {
                GM.ReportError(this, ex, "Error occured when editing product!");
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
                GM.ReportError(this, ex, "Error occured when deleting record from database!");
            }
        }
    }
}
