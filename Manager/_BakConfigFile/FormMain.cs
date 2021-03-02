using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Manager
{
    public partial class FormMain : Form
    {
        private Control curView = null;

        public FormMain()
        {
            InitializeComponent();

            siVersion.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            UserChanged();
        }

#region UI handlers
        private void FormMain_Shown(object sender, EventArgs e)
        {
			for (; ;)
			{
            // test SQL connection
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    using (SqlConnection conn = new SqlConnection(Program.CfgData.Sql.GetConnStr(true)) )
					    conn.Open();
                    break;
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            // setup SQL
                if ( !SetupDB() )
                {
                    Close();
    				return;
                }
			}

        // login user
            if ( !Login() )
                Close();
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
            else if ( sender == miData )
            {
                BaseView bv = curView as BaseView;

                miDataAdd.Enabled     = (bv != null && bv.ViewAllowAdd);
                miDataEdit.Enabled    = (bv != null && bv.ViewAllowEdit);
                miDataDel.Enabled     = (bv != null && bv.ViewAllowDel);
                miDataFilter.Enabled  = (bv != null && bv.ViewAllowFilter);
                miDataRefresh.Enabled = (bv != null);
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
                    MessageBox.Show(this, "New setup will take efect till after restarting application!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if ( sender == miAppExit )   Application.Exit();
            else if ( sender == miHlpAbout || sender == siVersion )
            {
                using ( DlgAbout dlg = new DlgAbout() )
                    dlg.ShowDialog();
            }
        }
        private void changeView_Click(object sender, EventArgs e)
        {
            Type t = null;
            if (      (sender == btnViewAddr || sender == miViewTblAddr) && Program.CurUser.ARaddr ) t = typeof(ViewAddress);
            else if ( (sender == btnViewProd || sender == miViewTblProd) && Program.CurUser.ARprod ) t = typeof(ViewProduct);
            else if ( (sender == btnViewUser || sender == miViewTblUser) && Program.CurUser.ARuser ) t = typeof(ViewUser);

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
            using ( DlgSetupDB dlg = new DlgSetupDB() )
            {
                dlg.Data = Program.CfgData.Sql;
                if ( dlg.ShowDialog() != DialogResult.OK )
                    return false;

                Program.CfgData.Sql = dlg.Data;
                Program.CfgData.Save();
            }

            return true;
        }
        private bool Login()
        {
            using ( DlgLogin dlg = new DlgLogin() )
                if ( dlg.ShowDialog() == DialogResult.OK )
                {
                    UserChanged();  
                    return true;
                }

            return false;
        }
        private void Logout()
        {
            if ( MessageBox.Show(this, "Really to logout?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes )
                return;

            Program.CurUser.Reset();

            UserChanged();
        }
        private void ChangePwd()
        {
            if ( Program.CurUser == null || !Program.CurUser.IsValid() )
            {
                return;
            }
            using ( DlgChangePwd dlg = new DlgChangePwd(Program.CurUser.Pwd) )
                if ( dlg.ShowDialog() == DialogResult.OK )
                    Program.CurUser.Pwd = dlg.tbNewPwd.Text;
                else 
                    return;
            // save to database
            try
            {
                using ( SqlConnection conn = new SqlConnection(Program.CfgData.Sql.GetConnStr(true)) )
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Users SET user_pwd=@pwd WHERE user_id="+Program.CurUser.ID, conn);
                    cmd.Parameters.AddWithValue("@pwd", GM.DESEncrypt(Program.CurUser.Pwd));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                GM.ReportError(this, ex, "Saving password to database failed!");
            }
        }
        private void UserChanged()
        {
            siUser.Text = Program.CurUser.ToString();

            btnViewAddr.Enabled = miViewTblAddr.Enabled = Program.CurUser.ARaddr; 
            btnViewProd.Enabled = miViewTblProd.Enabled = Program.CurUser.ARprod; 
            btnViewUser.Enabled = miViewTblUser.Enabled = Program.CurUser.ARuser; 

            SetCurrentView(typeof(ViewIntro));
        }
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
#endregion    
    }
}
