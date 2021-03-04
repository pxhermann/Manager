using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Manager
{
    public partial class BaseView : UserControl
    {
        protected SqlDataAdapter dataAdapter = null;
        protected BindingSource bindDataSrc = null;
        protected int prevSelID = DB.INVALID_ID;
        protected string idColumnName = "";
        protected string selectCommand = "";

        public BaseView()
        {
            InitializeComponent();

            bindDataSrc = new BindingSource();

            dgView.AutoGenerateColumns = false;
            dgView.DataSource = bindDataSrc;

            dgView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgView.ColumnHeadersHeight = tbSearch.Height;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ( keyData == Keys.Enter )    // allow Enter key this way - it cannot be assigned to shortcut as e.g. Insert or Delete
            {
                if ( ViewAllowEdit )
                    OnEdit();

                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
#region UI handlers
        private void BaseView_Load(object sender, EventArgs e)
        {
            if ( !DesignMode )
                OnRefresh();
        }
        protected void action_Click(object sender, EventArgs e)
        {
            if (sender == miGridAdd || sender == btnAdd) OnAdd();
            else if (sender == miGridEdit || sender == btnEdit) OnEdit();
            else if (sender == miGridDel || sender == btnDel) OnDel();
            else if (sender == miGridFilter) OnFilter();
            else if (sender == miGridRefresh) OnRefresh();
        }
        private void dgView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgView.Rows.Count && e.ColumnIndex >= 0 && e.ColumnIndex < dgView.Columns.Count)
                OnEdit();
        }
    #region searching related methods
/* following functionality is moved to FormMain - so that keyboard events are always handled, not only when this view is focused
        private void BaseView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ( !tbSearch.Visible && dgView.SortedColumn != null)
            {
                tbSearch.Text = e.KeyChar.ToString();
                tbSearch.Top = dgView.Top;
                tbSearch.Left = 0; foreach(DataGridViewColumn col in dgView.Columns) {if (col == dgView.SortedColumn) break; else tbSearch.Left += col.Width;}
                tbSearch.Size = dgView.SortedColumn.HeaderCell.Size;

                tbSearch.Visible = true;
                tbSearch.Focus();
            }
        }
*/      
        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbSearch.Visible && (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape))
            {
                tbSearch.Visible = false;
                return;
            }
        }
        void tbSearch_LostFocus(object sender, EventArgs e)
        {
            tbSearch.Visible = false;
        }
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if ( dgView.SortedColumn == null || dgView.Rows.Count < 1)
                return;

            try
            {
//            bindDataSrc.Filter = string.Format("convert({0},System.String) Like '{1}%'", dgView.SortedColumn.DataPropertyName, tbSearch.Text);
                string strSearch = tbSearch.Text.ToLower();
                string s = "";
                int cur, first, last;
                first = 0;
                last = dgView.Rows.Count-1;
                while (true)
                {
                    if ( last - first < 2 )
                    {
                        if ( first == last )
                        {
                            cur = first;
                            break;
                        }
                        s = (dgView.Rows[first].DataBoundItem as DataRowView).Row[dgView.SortedColumn.DataPropertyName].ToString().ToLower();
                        if ( strSearch.CompareTo(s) == 0 )
                            cur = first;
                        else if (strSearch.CompareTo(s) > 0 )
                            cur = (dgView.SortOrder == System.Windows.Forms.SortOrder.Descending)?first:last;
                        else
                        {
                            s = (dgView.Rows[last].DataBoundItem as DataRowView).Row[dgView.SortedColumn.DataPropertyName].ToString().ToLower();
                            if ( strSearch.CompareTo(s) == 0 )
                                cur = last;
                            else if ( strSearch.CompareTo(s) > 0 )
                                cur = (dgView.SortOrder == System.Windows.Forms.SortOrder.Descending)?first:last;
                            else 
                                cur = (dgView.SortOrder == System.Windows.Forms.SortOrder.Descending)?last:first;
                        }
                        break;
                    }
                    // 
                    cur = (first+last)/2;
                    s = (dgView.Rows[cur].DataBoundItem as DataRowView).Row[dgView.SortedColumn.DataPropertyName].ToString().ToLower();
                    if ( strSearch.CompareTo(s) == 0 )
                        break;
			        else if(strSearch.CompareTo(s) < 0)
			        {
				        if ( dgView.SortOrder == System.Windows.Forms.SortOrder.Descending )
					        first = cur;
				        else
					        last = cur;
			        }
			        else
			        {
				        if ( dgView.SortOrder == System.Windows.Forms.SortOrder.Descending )
					        last = cur;
				        else
					        first = cur;
			        }
                }
                dgView.ClearSelection();
                dgView.FirstDisplayedScrollingRowIndex = cur;
                dgView.CurrentCell = dgView.Rows[cur].Cells[0];
                dgView.Rows[cur].Selected = true;
            }
            catch(Exception ex)
            {
                GM.ShowErrorMessageBox(this, "Searching failed!", ex);
            }
        }
    #endregion

    #region last selection related methods
        // save ID of selected row, so that this row can be restored after refresh and resorting
        private void dgView_SelectionChanged(object sender, EventArgs e)
        {
            if ( idColumnName == null || idColumnName.Length < 1 || dgView.SelectedRows == null || dgView.SelectedRows.Count < 1)
                return;

            DataGridViewRow curRow = dgView.SelectedRows[0];    //dgView.CurrentRow;
            if (curRow != null)
            {
                DataRowView rw = (curRow.DataBoundItem as DataRowView);
                if (rw != null && rw.Row != null && rw.Row[idColumnName] is int)
                    prevSelID = Convert.ToInt32(rw.Row[idColumnName]);
            }
        }
        // implement programatic sorting owing to handling previous selection; 
        // automatic sorting mantains selected index and thus changes row selection
        private void dgView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.ColumnIndex < dgView.Columns.Count)
            {
                ListSortDirection direction = ListSortDirection.Ascending;
                DataGridViewColumn newCol = dgView.Columns[e.ColumnIndex];
                if (dgView.SortedColumn == newCol)
                {
                    if (dgView.SortOrder == System.Windows.Forms.SortOrder.Ascending)
                        direction = ListSortDirection.Descending;
                }
                else if (dgView.SortedColumn != null)
                    dgView.SortedColumn.HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.None;

                int prevID = prevSelID;
                dgView.Sort(newCol, direction);
                newCol.HeaderCell.SortGlyphDirection = (direction == ListSortDirection.Ascending) ? System.Windows.Forms.SortOrder.Ascending : System.Windows.Forms.SortOrder.Descending;

                prevSelID = prevID;
                RestorePrevSelection();
            }
        }
    #endregion
#endregion

#region helper methods
        protected void RestorePrevSelection()
        {
            if ( idColumnName == null || idColumnName.Length<1 )
            {
                GM.ShowErrorMessageBox(this, string.Format("ID column not set in view '{0}'!{1}{1}Maintainig selection will not work!", ViewTitle, Environment.NewLine));
                return;
            }

            if (dgView.Rows.Count>0)
            {
                int idx = bindDataSrc.Find(idColumnName, prevSelID);
                if (idx < 0 || idx >= dgView.Rows.Count)
                    idx = 0;

                dgView.FirstDisplayedScrollingRowIndex = idx;
                dgView.ClearSelection();
                dgView.CurrentCell = dgView.Rows[idx].Cells[0];
//                dgView.Rows[idx].Selected = true;
            }
        }
        protected DataGridViewColumn AddTextColumn(string dataName, string headerText, int width)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.Name = col.DataPropertyName = dataName;
            col.HeaderText = headerText;
            col.MinimumWidth = 20;
            col.Width = width;
            col.SortMode = DataGridViewColumnSortMode.Programmatic; // use programatic sorting to be able keep previous selection, see. dgView_ColumnHeaderMouseClick

            dgView.Columns.Add(col);

            return col;
        }
        protected DataGridViewColumn AddBoolColumn(string dataName, string headerText, int width)
        {
            DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
            col.Name = col.DataPropertyName = dataName;
            col.HeaderText = headerText;
            col.MinimumWidth = 20;
            col.Width = width;
            col.SortMode = DataGridViewColumnSortMode.Programmatic; // use programatic sorting to be able keep previous selection, see. dgView_ColumnHeaderMouseClick

            dgView.Columns.Add(col);

            return col;
        }
#endregion

#region properties
        [Description("Text shown in header bar ~ title of the view.")]
        public string ViewTitle
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }
        [Description("Indicate whether new record can be added in this view. Shows/hides 'Add' button in header bar, 'Add' item in context menu and enables/disables 'Add' item in main menu.")]
        public bool ViewAllowAdd
        {
            get { return btnAdd.Visible; }
            set { btnAdd.Visible = value; FlagsChanged(); }
        }
        [Description("Indicate whether records can be edited in this view. Shows/hides 'Edit' button in header bar, 'Edit' item in context menu and enables/disables 'Edit' item in main menu.")]
        public bool ViewAllowEdit
        {
            get { return btnEdit.Visible; }
            set { btnEdit.Visible = value; FlagsChanged(); }
        }
        [Description("Indicate whether records can be deleted in this view. Shows/hides 'Delete' button in header bar, 'Delete' item in context menu and enables/disables 'Delete' item in main menu.")]
        public bool ViewAllowDel
        {
            get { return btnDel.Visible; }
            set { btnDel.Visible = value; FlagsChanged(); }
        }
        [Description("Indicate whether records can be filtered in this view. Shows/hides 'Filter' button in header bar, 'Filter' item in context menu and enables/disables 'Filter' item in main menu.")]
        public bool ViewAllowFilter
        {
            get { return btnFilter.Visible; }
            set { btnFilter.Visible = value; }
        }
        [Description("Context menu strip for the grid control in this view..")]
        public ContextMenuStrip ViewContextMenuStrip
        {
            get { return dgView.ContextMenuStrip; }
            set { dgView.ContextMenuStrip = value; FlagsChanged(); }
        }

        private void FlagsChanged()
        {
            int x = btnAdd.Left;
            if ( ViewAllowAdd )   x += (btnAdd.Left + btnAdd.Width);
            if ( ViewAllowEdit ) { btnEdit.Left = x; x += (btnAdd.Left + btnAdd.Width);}
            if ( ViewAllowDel )  { btnDel.Left = x; x += (btnAdd.Left + btnAdd.Width);}
            if ( x > btnAdd.Left ) x += 10; // separator
            if ( ViewAllowFilter ) btnFilter.Left = x;

            miGridAdd.Visible = ViewAllowAdd;
            miGridEdit.Visible = ViewAllowEdit;
            miGridDel.Visible = ViewAllowDel;
            miGridSep1.Visible = ViewAllowAdd || ViewAllowEdit || ViewAllowDel;
            miGridSep2.Visible = miGridFilter.Visible = ViewAllowFilter;
        }
#endregion        

#region virtual methods to be overriden in derived views - where will perform specific behaviour
        public virtual void OnAdd() { }
        public virtual void OnEdit() { }
        public virtual void OnDel() 
        { 
            // get selection after deleting
            if ( idColumnName == null || idColumnName.Length<1 || dgView.CurrentRow==null)
                return;

            int idx = dgView.Rows.IndexOf(dgView.CurrentRow);
            if ( idx >= dgView.Rows.Count-1 )
                idx--;
            else
                idx++;
            if ( idx >= 0 && idx < dgView.Rows.Count )
            {
                DataRowView rView = dgView.Rows[idx].DataBoundItem as DataRowView;
                if ( rView != null && rView.Row != null )
                    prevSelID = Convert.ToInt32(rView.Row[idColumnName]);
            }
        }
        public virtual void OnFilter() { }
        public virtual void OnRefresh()
        {
            if (selectCommand == null || selectCommand.Length < 1)
            {
                GM.ShowErrorMessageBox(this, string.Format("No select command speficied in view '{0}'!", ViewTitle));
                return;
            }

            Cursor = Cursors.WaitCursor;
            try
            {
                DataTable tbl = bindDataSrc.DataSource as DataTable;
                if (tbl == null)
                    tbl = new DataTable();
                
                tbl.RowChanged -= tbl_RowChanged;   // disable database update before refreshing tbl
                tbl.RowDeleted -= tbl_RowChanged;

                if ( dataAdapter == null || dataAdapter.SelectCommand == null || dataAdapter.SelectCommand.CommandText != selectCommand )
                {
                    dataAdapter = new SqlDataAdapter(selectCommand, DB.ConnData.GetConnectionString(true));
                    SqlCommandBuilder cb = new SqlCommandBuilder(dataAdapter);  // create command builder, so that dataAdapter.UpdateCan be called to save data from bindDataSrc.DataSource to database

                    // Get the Identity column value
                    if ( idColumnName != null && idColumnName.Length>0 )
                    {
				        SqlParameter outPar = new SqlParameter();
				        outPar.ParameterName = "@" + idColumnName;
				        outPar.SqlDbType = SqlDbType.BigInt;
				        outPar.Direction = ParameterDirection.Output;
				        outPar.SourceColumn = idColumnName;

                        dataAdapter.InsertCommand = cb.GetInsertCommand().Clone();  // bez Clone() by se ztratily následující úpravy v commandu, tj. při použití by se vrátil do stavu cb.GetInsertCommand()
				        dataAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
				        dataAdapter.InsertCommand.CommandText += ";\r\nSELECT @" + idColumnName + " = @@IDENTITY";
				        dataAdapter.InsertCommand.Parameters.Add(outPar);
                    }
                }

                int selID = prevSelID;
                dgView.DataSource = null;
                bindDataSrc.SuspendBinding();
                tbl.Clear();
                dataAdapter.Fill(tbl);

                tbl.RowChanged += tbl_RowChanged;   // enable database update
                tbl.RowDeleted += tbl_RowChanged;

                bindDataSrc.DataSource = tbl;
                bindDataSrc.ResumeBinding();
                dgView.DataSource = bindDataSrc;
                if (dgView.SortedColumn == null && dgView.Columns.Count > 0)
                {
                    dgView.Sort(dgView.Columns[0], ListSortDirection.Ascending);
                    dgView.Columns[0].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Ascending;
                }

                prevSelID = selID;
                RestorePrevSelection();
            }
            catch (Exception ex)
            {
                GM.ShowErrorMessageBox(this, "Error occured when loading data from database!", ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
#endregion
        // save changes made in DataTable associated with grid control to database
        void tbl_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            if ( (dataAdapter != null) && (bindDataSrc.DataSource is DataTable) && 
                (e.Action == DataRowAction.Add ||                                               // po pridani zaznamu prijde even tbl_RowChanged s e.Action == DataRowAction.Add, 
                 (e.Action == DataRowAction.Change && e.Row.RowState != DataRowState.Added) ||  // u MBD a SQLCE ale pote jeste v RowUpdated aktualizuji v pridanem zaznamu autoincrement sloupec, coz znovu vyvola tbl_RowChanged, tentokrat ale s e.Action == DataRowAction.Change
                 e.Action == DataRowAction.Delete) )
            {
                Cursor = Cursors.WaitCursor;
                try
                {
                    dataAdapter.Update(bindDataSrc.DataSource as DataTable);
                }
                catch(Exception ex)
                {
                    GM.ShowErrorMessageBox(this, "Error occured when saving changes to database!", ex);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }
    }
}
