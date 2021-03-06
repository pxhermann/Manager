﻿using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Manager
{
    public partial class FormMain : Form
    {
        private AppSetting appCfg = new AppSetting();
        private User curUser = new User();
        private Control curView = null;

        public FormMain()
        {
            InitializeComponent();

            siVersion.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            appCfg = AppSetting.Load();
            DB.ConnData = appCfg.Sql;

            UserChanged();
        }

#region UI handlers
        private void FormMain_Shown(object sender, EventArgs e)
        {
			for (; ;)
			{
            // test SQL connection
                if ( !DB.ConnData.IsValid() )  // pokud chybi nastaveni, predvypl implicitni hodnoty a prejdi rovnou k nastaveni
                {
                    DB.ConnData.Server = ".";
                    DB.ConnData.Database = "TestManager";
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    try
                    {
                        using (SqlConnection conn = DB.OpenConnection() )
					        ;
                        break;
                    }
                    catch (Exception ex) { GM.ShowErrorMessageBox(this, "Connection to database failed!", ex); }
                    finally { Cursor.Current = Cursors.Default; }
                }
            // setup SQL
                if ( !SetupDB() )
                {
                    Close();
    				return;
                }
			}

        // login user
            Login();
        }
        // status item has no ContextMenuStrip property, so show context menu after right click
        private void siUser_MouseDown(object sender, MouseEventArgs e)
        {
            if ( e.Button == MouseButtons.Right )
                contMenuUser.Show(mainStatus, new Point(e.X+siUser.Bounds.Left, e.Y+siUser.Bounds.Top), ToolStripDropDownDirection.AboveRight);
        }
        private void menuItem_DropDownOpening(object sender, EventArgs e)
        {
            if ( sender == miView )         
                miViewNavigPanel.Checked = panelNavig.Visible;
            else if ( sender == miViewTbl ) 
            {
                miViewTblAddr.Checked = (curView is ViewAddress);
                miViewTblProd.Checked = (curView is ViewProduct);
                miViewTblUser.Checked = (curView is ViewUser);
            }
            else if (sender == miData)
            {
                BaseView bv = curView as BaseView;

                miDataAdd.Enabled = (bv != null && bv.ViewAllowAdd);
                miDataEdit.Enabled = (bv != null && bv.ViewAllowEdit);
                miDataDel.Enabled = (bv != null && bv.ViewAllowDel);
                miDataFilter.Enabled = (bv != null && bv.ViewAllowFilter);
                miDataRefresh.Enabled = (bv != null);
            }
            else if (sender == miAppUser)
            {
                miAppUserLogin.Enabled = DB.ConnData.IsValid();
                miAppUserLogout.Enabled = curUser.IsValid();
                miAppUserChangePwd.Enabled = curUser.IsValid();
            }
        }
        private void toolStripItem_Click(object sender, EventArgs e)
        {
            if ( sender == miDataAdd && curView is BaseView ) (curView as BaseView ).OnAdd();
            else if ( sender == miDataEdit && curView is BaseView ) (curView as BaseView ).OnEdit();
            else if ( sender == miDataDel && curView is BaseView ) (curView as BaseView ).OnDel();
            else if ( sender == miDataRefresh && curView is BaseView ) (curView as BaseView ).OnRefresh();
            else if ( sender == miDataFilter && curView is BaseView ) (curView as BaseView ).OnFilter();
            else if ( sender == miAppUserLogin || sender == miUserLogin || sender == siUser )  Login();
            else if ( sender == miAppUserLogout || sender == miUserLogout )  Logout();
            else if ( sender == miAppUserChangePwd || sender == miUserChangePwd )  ChangePwd();
            else if ( sender == miNavigPanelLeft )  panelNavig.Dock = DockStyle.Left;
            else if ( sender == miNavigPanelRight ) panelNavig.Dock = DockStyle.Right;
            else if ( sender == miViewNavigPanel || sender == miNavigPanelHide) panelNavig.Visible = !panelNavig.Visible;
            else if ( sender == miAppSetup )  
            {
                if ( SetupDB() ) 
                    GM.ShowInfoMessageBox(this, "New setup will take efect till after restarting application!");
            }
            else if ( sender == miAppExit )   Application.Exit();
            else if ( sender == miHlpAbout || sender == siVersion )
            {
                using (DlgAbout dlg = new DlgAbout())
                    dlg.ShowDialog(this);
            }
        }
        private void changeView_Click(object sender, EventArgs e)
        {
            Type t = null;
            if (      (sender == btnViewAddr || sender == miViewTblAddr) && curUser.ARaddr ) t = typeof(ViewAddress);
            else if ( (sender == btnViewProd || sender == miViewTblProd) && curUser.ARprod ) t = typeof(ViewProduct);
            else if ( (sender == btnViewUser || sender == miViewTblUser) && curUser.ARuser ) t = typeof(ViewUser);

            SetCurrentView(t);
        }

        private void FormMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            BaseView bv = curView as BaseView;
            if ( bv != null && !bv.tbSearch.Visible && bv.dgView.SortedColumn != null && char.IsLetterOrDigit(e.KeyChar) )
            {
                bv.tbSearch.Top = bv.dgView.Top;
                bv.tbSearch.Left = 0; foreach(DataGridViewColumn col in bv.dgView.Columns) {if (col == bv.dgView.SortedColumn) break; else bv.tbSearch.Left += col.Width;}
                bv.tbSearch.Size = bv.dgView.SortedColumn.HeaderCell.Size;

                bv.tbSearch.Text = e.KeyChar.ToString();
                bv.tbSearch.Visible = true;
                bv.tbSearch.Focus();
                bv.tbSearch.Select(bv.tbSearch.Text.Length, 0);
            }
        }
#endregion

#region helper methods
        private bool SetupDB()
        {
            using (DlgSetupDB dlg = new DlgSetupDB())
            {
                dlg.Data.CopyFrom(appCfg.Sql);
                if (dlg.ShowDialog(this) != DialogResult.OK)
                    return false;

                appCfg.Sql.CopyFrom(dlg.Data);
                appCfg.Save();
            }

            return true;
        }

#region user related methods
        private bool Login()
        {
            using (DlgLogin dlg = new DlgLogin())
            {
                dlg.SelUserID = appCfg.LastUserID;
                if (dlg.ShowDialog(this) != DialogResult.OK)
                    return false;

                try
                {
                // save selected user to setting
                    appCfg.LastUserID = dlg.SelUserID;
                    appCfg.Save();

                // load current user
                    DataTable tbl = DB.GetDataTable("SELECT * FROM Users WHERE user_id ="+dlg.SelUserID);
                    if ( tbl != null && tbl.Rows.Count > 0 )
                        curUser.Load(tbl.Rows[0]);
                }
                catch(Exception ex)
                {
    #if DEBUG
                    GM.ShowErrorMessageBox(this, "Saving selected user failed!", ex);
    #endif
                    return false;
                }

                UserChanged();  
            }

            return true;
        }
        private void Logout()
        {
            if ( GM.ShowQuestionMessageBox(this, "Really to logout?") != DialogResult.Yes )
                return;

            curUser.Reset();

            UserChanged();
        }
        private void ChangePwd()
        {
            if ( curUser == null || !curUser.IsValid() )
            {
                return;
            }
            using ( DlgChangePwd dlg = new DlgChangePwd(curUser.Pwd) )
            { 
                if ( dlg.ShowDialog(this) != DialogResult.OK )
                    return;

                curUser.Pwd = dlg.tbNewPwd.Text;
            }
            // save to database
            try
            {
                string s = string.Format("UPDATE Users SET user_pwd='{0}' WHERE user_id={1}", GM.DESEncrypt(curUser.Pwd), curUser.ID);
                DB.ExecuteNoQuery(s);
            }
            catch(Exception ex)
            {
                GM.ShowErrorMessageBox(this, "Saving password to database failed!", ex);
            }
        }
        private void UserChanged()
        {
            siUser.Text = curUser.ToString();

            btnViewAddr.Enabled = miViewTblAddr.Enabled = curUser.ARaddr; 
            btnViewProd.Enabled = miViewTblProd.Enabled = curUser.ARprod; 
            btnViewUser.Enabled = miViewTblUser.Enabled = curUser.ARuser; 

            if ( curView != null )
                curView.HandleDestroyed -= view_Destroyed;  // změnil se uzivatel, proto takto zamez ulozeni aktualniho layout, protoze by se uložil do configu jineho uzivatele nez ktery layout vytvoril
            SetCurrentView(typeof(ViewIntro));
        }
#endregion

#region methods related to switching current view
        private void SetCurrentView(Type newViewType)
        {
         // ensure valid view
            if ( newViewType == null )
                newViewType = typeof(ViewIntro);
         // check whether required view is already on
            if ( newViewType.IsInstanceOfType(curView) )
                return;

            Control newView = Activator.CreateInstance(newViewType) as Control;
            if ( newView == null )
                return;

            if ( newView is BaseView && !DesignMode )  // enable to handle user setting - saving and restoring columns layout
            {
                newView.HandleDestroyed += view_Destroyed;
                (newView as BaseView).Load += view_Load;
            }

            SuspendLayout();

         // set new view
            newView.Dock = DockStyle.Fill;
            newView.TabIndex = panelNavig.TabIndex + 1;
            if ( newView is UserControl )
                (newView as UserControl).BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(newView);
            newView.BringToFront(); // ensure correct docking
            newView.Focus();

         // hide previous view
            if ( curView != null )
            {
                Controls.Remove(curView);
                curView.Dispose();
            }
            curView = newView;

            ResumeLayout(true);
        }
        void view_Load(object sender, EventArgs e)
        {
            BaseView bv = sender as BaseView;
            if ( bv == null || bv.dgView.Columns.Count < 1 )
                return;

            string viewName = sender.GetType().Name;
            CfgViewData viewData = null;
            foreach(CfgViewData v in curUser.Cfg.Views)
                if ( v.Name == viewName )
                {
                    viewData = v;
                    break;
                }
            if ( viewData == null || viewData.Columns == null || viewData.Columns.Count < 1 )
                return;
            // restore column layout
            foreach(DataGridViewColumn col in bv.dgView.Columns)
                foreach(CfgColumnData ini in viewData.Columns)
                    if ( col.DataPropertyName == ini.DataPropertyName )
                    {
                        if ( col.DisplayIndex >= 0 && col.DisplayIndex < bv.dgView.Columns.Count )
                        {
                            col.DisplayIndex = ini.DisplayIndex;
                            col.Width = ( ini.Width < 0 || ini.Width > 1000 )?100:ini.Width;
                        }
                        break;
                    }
            // restore sorting
            if ( viewData.SortColIdx >= 0 && viewData.SortColIdx < bv.dgView.Columns.Count )
            {
                DataGridViewColumn newCol = bv.dgView.Columns[viewData.SortColIdx];
                System.Windows.Forms.SortOrder newOrder = viewData.SortAsc?System.Windows.Forms.SortOrder.Ascending:System.Windows.Forms.SortOrder.Descending;
                if ( bv.dgView.SortedColumn != newCol || bv.dgView.SortOrder != newOrder ) 
                {
                    if ( bv.dgView.SortedColumn != null && bv.dgView.SortedColumn != newCol )
                        bv.dgView.SortedColumn.HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.None;

                    bv.dgView.Sort(newCol, viewData.SortAsc?ListSortDirection.Descending:ListSortDirection.Descending);
                    bv.dgView.SortedColumn.HeaderCell.SortGlyphDirection = newOrder;
                }
            }
        }
        void view_Destroyed(object sender, EventArgs e)
        {
            BaseView bv = sender as BaseView;
            if ( bv == null || bv.dgView.Columns.Count < 1 )
                return;

            try
            {
                string viewName = sender.GetType().Name;

                CfgViewData viewData = null;
                foreach(CfgViewData v in curUser.Cfg.Views)
                if ( v.Name == viewName )
                {
                    viewData = v;
                    break;
                }
                if ( viewData == null )
                {
                    viewData = new CfgViewData();
                    viewData.Name = viewName;
                    curUser.Cfg.Views.Add(viewData);
                }
                if ( bv.dgView.SortedColumn != null )
                {
                    viewData.SortColIdx = bv.dgView.Columns.IndexOf(bv.dgView.SortedColumn);
                    viewData.SortAsc = (bv.dgView.SortOrder == System.Windows.Forms.SortOrder.Ascending);
                }
                viewData.Columns.Clear();
                foreach(DataGridViewColumn col in bv.dgView.Columns)
                    viewData.Columns.Add(new CfgColumnData(col.DisplayIndex, col.Width, col.DataPropertyName));

            // save to database
                DB.ExecuteNoQuery("UPDATE Users SET user_cfgXML=@cfg WHERE user_id="+curUser.ID, 
                                          "@cfg", curUser.Cfg.SaveXML() );
            }
            catch(Exception ex)
            {
#if DEBUG
                GM.ShowErrorMessageBox(this, "Saving view layout!", ex);
#endif
            }
        }
    #endregion

#endregion
    }
}
