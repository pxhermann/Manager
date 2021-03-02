namespace Manager
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripMenuItem miApp;
            System.Windows.Forms.ToolStripMenuItem miHlp;
            System.Windows.Forms.ToolStripStatusLabel siLabelUser;
            System.Windows.Forms.ToolStripStatusLabel siLabelVersion;
            System.Windows.Forms.ToolStripSeparator miUserSep1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.miAppSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.miAppUser = new System.Windows.Forms.ToolStripMenuItem();
            this.miAppUserLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.miAppUserLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.miAppUserSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.miAppUserChangePwd = new System.Windows.Forms.ToolStripMenuItem();
            this.miAppSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.miAppExit = new System.Windows.Forms.ToolStripMenuItem();
            this.miHlpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.miView = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewNavigPanel = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewSep = new System.Windows.Forms.ToolStripSeparator();
            this.miViewTbl = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewTblAddr = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewTblProd = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewTblUser = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.miData = new System.Windows.Forms.ToolStripMenuItem();
            this.miDataAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.miDataEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.miDataDel = new System.Windows.Forms.ToolStripMenuItem();
            this.miDataSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.miDataRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.miDataSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.miDataFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.panelNavig = new System.Windows.Forms.Panel();
            this.contMenuNavigPanel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miNavigPanelLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.miNavigPanelRight = new System.Windows.Forms.ToolStripMenuItem();
            this.miNavigPanelHide = new System.Windows.Forms.ToolStripMenuItem();
            this.btnViewUser = new System.Windows.Forms.Button();
            this.btnViewProd = new System.Windows.Forms.Button();
            this.btnViewAddr = new System.Windows.Forms.Button();
            this.mainStatus = new System.Windows.Forms.StatusStrip();
            this.siCurAction = new System.Windows.Forms.ToolStripStatusLabel();
            this.siUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.siVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.contMenuUser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miUserLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.miUserLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.miUserChangePwd = new System.Windows.Forms.ToolStripMenuItem();
            miApp = new System.Windows.Forms.ToolStripMenuItem();
            miHlp = new System.Windows.Forms.ToolStripMenuItem();
            siLabelUser = new System.Windows.Forms.ToolStripStatusLabel();
            siLabelVersion = new System.Windows.Forms.ToolStripStatusLabel();
            miUserSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuMain.SuspendLayout();
            this.panelNavig.SuspendLayout();
            this.contMenuNavigPanel.SuspendLayout();
            this.mainStatus.SuspendLayout();
            this.contMenuUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // miApp
            // 
            miApp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAppSetup,
            this.miAppUser,
            this.miAppSep1,
            this.miAppExit});
            miApp.Name = "miApp";
            miApp.Size = new System.Drawing.Size(80, 20);
            miApp.Text = "Application";
            // 
            // miAppSetup
            // 
            this.miAppSetup.Name = "miAppSetup";
            this.miAppSetup.Size = new System.Drawing.Size(135, 22);
            this.miAppSetup.Text = "Setup...";
            this.miAppSetup.Click += new System.EventHandler(this.toolStripItem_Click);
            // 
            // miAppUser
            // 
            this.miAppUser.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAppUserLogin,
            this.miAppUserLogout,
            this.miAppUserSep1,
            this.miAppUserChangePwd});
            this.miAppUser.Name = "miAppUser";
            this.miAppUser.Size = new System.Drawing.Size(135, 22);
            this.miAppUser.Text = "User";
            // 
            // miAppUserLogin
            // 
            this.miAppUserLogin.Name = "miAppUserLogin";
            this.miAppUserLogin.Size = new System.Drawing.Size(177, 22);
            this.miAppUserLogin.Text = "Login...";
            this.miAppUserLogin.Click += new System.EventHandler(this.toolStripItem_Click);
            // 
            // miAppUserLogout
            // 
            this.miAppUserLogout.Name = "miAppUserLogout";
            this.miAppUserLogout.Size = new System.Drawing.Size(177, 22);
            this.miAppUserLogout.Text = "Logout";
            this.miAppUserLogout.Click += new System.EventHandler(this.toolStripItem_Click);
            // 
            // miAppUserSep1
            // 
            this.miAppUserSep1.Name = "miAppUserSep1";
            this.miAppUserSep1.Size = new System.Drawing.Size(174, 6);
            // 
            // miAppUserChangePwd
            // 
            this.miAppUserChangePwd.Name = "miAppUserChangePwd";
            this.miAppUserChangePwd.Size = new System.Drawing.Size(177, 22);
            this.miAppUserChangePwd.Text = "Change password...";
            this.miAppUserChangePwd.Click += new System.EventHandler(this.toolStripItem_Click);
            // 
            // miAppSep1
            // 
            this.miAppSep1.Name = "miAppSep1";
            this.miAppSep1.Size = new System.Drawing.Size(132, 6);
            // 
            // miAppExit
            // 
            this.miAppExit.Name = "miAppExit";
            this.miAppExit.ShortcutKeyDisplayString = "Alt+F4";
            this.miAppExit.Size = new System.Drawing.Size(135, 22);
            this.miAppExit.Text = "Exit";
            this.miAppExit.Click += new System.EventHandler(this.toolStripItem_Click);
            // 
            // miHlp
            // 
            miHlp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            miHlp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miHlpAbout});
            miHlp.Name = "miHlp";
            miHlp.Size = new System.Drawing.Size(44, 20);
            miHlp.Text = "Help";
            // 
            // miHlpAbout
            // 
            this.miHlpAbout.Name = "miHlpAbout";
            this.miHlpAbout.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.miHlpAbout.Size = new System.Drawing.Size(197, 22);
            this.miHlpAbout.Text = "About application...";
            this.miHlpAbout.Click += new System.EventHandler(this.toolStripItem_Click);
            // 
            // siLabelUser
            // 
            siLabelUser.Name = "siLabelUser";
            siLabelUser.Size = new System.Drawing.Size(75, 17);
            siLabelUser.Text = "Current user:";
            siLabelUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // siLabelVersion
            // 
            siLabelVersion.Name = "siLabelVersion";
            siLabelVersion.Size = new System.Drawing.Size(48, 17);
            siLabelVersion.Text = "Version:";
            // 
            // miUserSep1
            // 
            miUserSep1.Name = "miUserSep1";
            miUserSep1.Size = new System.Drawing.Size(174, 6);
            // 
            // miView
            // 
            this.miView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miViewNavigPanel,
            this.miViewSep,
            this.miViewTbl});
            this.miView.Name = "miView";
            this.miView.Size = new System.Drawing.Size(44, 20);
            this.miView.Text = "View";
            this.miView.DropDownOpening += new System.EventHandler(this.menuItem_DropDownOpening);
            // 
            // miViewNavigPanel
            // 
            this.miViewNavigPanel.Name = "miViewNavigPanel";
            this.miViewNavigPanel.Size = new System.Drawing.Size(137, 22);
            this.miViewNavigPanel.Text = "Navig panel";
            this.miViewNavigPanel.Click += new System.EventHandler(this.toolStripItem_Click);
            // 
            // miViewSep
            // 
            this.miViewSep.Name = "miViewSep";
            this.miViewSep.Size = new System.Drawing.Size(134, 6);
            // 
            // miViewTbl
            // 
            this.miViewTbl.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miViewTblAddr,
            this.miViewTblProd,
            this.miViewTblUser});
            this.miViewTbl.Name = "miViewTbl";
            this.miViewTbl.Size = new System.Drawing.Size(137, 22);
            this.miViewTbl.Text = "Table";
            this.miViewTbl.DropDownOpening += new System.EventHandler(this.menuItem_DropDownOpening);
            // 
            // miViewTblAddr
            // 
            this.miViewTblAddr.Name = "miViewTblAddr";
            this.miViewTblAddr.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.miViewTblAddr.Size = new System.Drawing.Size(154, 22);
            this.miViewTblAddr.Text = "Address";
            this.miViewTblAddr.Click += new System.EventHandler(this.changeView_Click);
            // 
            // miViewTblProd
            // 
            this.miViewTblProd.Name = "miViewTblProd";
            this.miViewTblProd.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.miViewTblProd.Size = new System.Drawing.Size(154, 22);
            this.miViewTblProd.Text = "Product";
            this.miViewTblProd.Click += new System.EventHandler(this.changeView_Click);
            // 
            // miViewTblUser
            // 
            this.miViewTblUser.Name = "miViewTblUser";
            this.miViewTblUser.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.U)));
            this.miViewTblUser.Size = new System.Drawing.Size(154, 22);
            this.miViewTblUser.Text = "Users";
            this.miViewTblUser.Click += new System.EventHandler(this.changeView_Click);
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            miApp,
            miHlp,
            this.miView,
            this.miData});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(802, 24);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "menuStrip1";
            // 
            // miData
            // 
            this.miData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miDataAdd,
            this.miDataEdit,
            this.miDataDel,
            this.miDataSep1,
            this.miDataRefresh,
            this.miDataSep2,
            this.miDataFilter});
            this.miData.Name = "miData";
            this.miData.Size = new System.Drawing.Size(43, 20);
            this.miData.Text = "Data";
            this.miData.DropDownOpening += new System.EventHandler(this.menuItem_DropDownOpening);
            // 
            // miDataAdd
            // 
            this.miDataAdd.Name = "miDataAdd";
            this.miDataAdd.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.miDataAdd.Size = new System.Drawing.Size(140, 22);
            this.miDataAdd.Text = "Add";
            this.miDataAdd.Click += new System.EventHandler(this.toolStripItem_Click);
            // 
            // miDataEdit
            // 
            this.miDataEdit.Name = "miDataEdit";
            this.miDataEdit.ShortcutKeyDisplayString = "Enter";
            this.miDataEdit.Size = new System.Drawing.Size(140, 22);
            this.miDataEdit.Text = "Edit";
            this.miDataEdit.Click += new System.EventHandler(this.toolStripItem_Click);
            // 
            // miDataDel
            // 
            this.miDataDel.Name = "miDataDel";
            this.miDataDel.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.miDataDel.Size = new System.Drawing.Size(140, 22);
            this.miDataDel.Text = "Delete";
            this.miDataDel.Click += new System.EventHandler(this.toolStripItem_Click);
            // 
            // miDataSep1
            // 
            this.miDataSep1.Name = "miDataSep1";
            this.miDataSep1.Size = new System.Drawing.Size(137, 6);
            // 
            // miDataRefresh
            // 
            this.miDataRefresh.Name = "miDataRefresh";
            this.miDataRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.miDataRefresh.Size = new System.Drawing.Size(140, 22);
            this.miDataRefresh.Text = "Refresh";
            this.miDataRefresh.Click += new System.EventHandler(this.toolStripItem_Click);
            // 
            // miDataSep2
            // 
            this.miDataSep2.Name = "miDataSep2";
            this.miDataSep2.Size = new System.Drawing.Size(137, 6);
            // 
            // miDataFilter
            // 
            this.miDataFilter.Name = "miDataFilter";
            this.miDataFilter.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.miDataFilter.Size = new System.Drawing.Size(140, 22);
            this.miDataFilter.Text = "Filter";
            this.miDataFilter.Click += new System.EventHandler(this.toolStripItem_Click);
            // 
            // panelNavig
            // 
            this.panelNavig.ContextMenuStrip = this.contMenuNavigPanel;
            this.panelNavig.Controls.Add(this.btnViewUser);
            this.panelNavig.Controls.Add(this.btnViewProd);
            this.panelNavig.Controls.Add(this.btnViewAddr);
            this.panelNavig.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelNavig.Location = new System.Drawing.Point(0, 24);
            this.panelNavig.Name = "panelNavig";
            this.panelNavig.Size = new System.Drawing.Size(150, 453);
            this.panelNavig.TabIndex = 1;
            // 
            // contMenuNavigPanel
            // 
            this.contMenuNavigPanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miNavigPanelLeft,
            this.miNavigPanelRight,
            this.miNavigPanelHide});
            this.contMenuNavigPanel.Name = "contMenuNavigPanel";
            this.contMenuNavigPanel.Size = new System.Drawing.Size(103, 70);
            // 
            // miNavigPanelLeft
            // 
            this.miNavigPanelLeft.Name = "miNavigPanelLeft";
            this.miNavigPanelLeft.Size = new System.Drawing.Size(102, 22);
            this.miNavigPanelLeft.Text = "Left";
            this.miNavigPanelLeft.Click += new System.EventHandler(this.toolStripItem_Click);
            // 
            // miNavigPanelRight
            // 
            this.miNavigPanelRight.Name = "miNavigPanelRight";
            this.miNavigPanelRight.Size = new System.Drawing.Size(102, 22);
            this.miNavigPanelRight.Text = "Right";
            this.miNavigPanelRight.Click += new System.EventHandler(this.toolStripItem_Click);
            // 
            // miNavigPanelHide
            // 
            this.miNavigPanelHide.Name = "miNavigPanelHide";
            this.miNavigPanelHide.Size = new System.Drawing.Size(102, 22);
            this.miNavigPanelHide.Text = "Hide";
            this.miNavigPanelHide.Click += new System.EventHandler(this.toolStripItem_Click);
            // 
            // btnViewUser
            // 
            this.btnViewUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnViewUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnViewUser.Image = global::Manager.Properties.Resources.User;
            this.btnViewUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewUser.Location = new System.Drawing.Point(3, 104);
            this.btnViewUser.Name = "btnViewUser";
            this.btnViewUser.Size = new System.Drawing.Size(144, 40);
            this.btnViewUser.TabIndex = 2;
            this.btnViewUser.Text = "Users";
            this.btnViewUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnViewUser.UseVisualStyleBackColor = true;
            this.btnViewUser.Click += new System.EventHandler(this.changeView_Click);
            // 
            // btnViewProd
            // 
            this.btnViewProd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewProd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnViewProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnViewProd.Image = global::Manager.Properties.Resources.Prod;
            this.btnViewProd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewProd.Location = new System.Drawing.Point(3, 49);
            this.btnViewProd.Name = "btnViewProd";
            this.btnViewProd.Size = new System.Drawing.Size(144, 40);
            this.btnViewProd.TabIndex = 1;
            this.btnViewProd.Text = "Products";
            this.btnViewProd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnViewProd.UseVisualStyleBackColor = true;
            this.btnViewProd.Click += new System.EventHandler(this.changeView_Click);
            // 
            // btnViewAddr
            // 
            this.btnViewAddr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewAddr.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnViewAddr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnViewAddr.Image = global::Manager.Properties.Resources.Addr;
            this.btnViewAddr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewAddr.Location = new System.Drawing.Point(3, 3);
            this.btnViewAddr.Name = "btnViewAddr";
            this.btnViewAddr.Size = new System.Drawing.Size(144, 40);
            this.btnViewAddr.TabIndex = 0;
            this.btnViewAddr.Text = "Addresses";
            this.btnViewAddr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnViewAddr.UseVisualStyleBackColor = true;
            this.btnViewAddr.Click += new System.EventHandler(this.changeView_Click);
            // 
            // mainStatus
            // 
            this.mainStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.siCurAction,
            siLabelUser,
            this.siUser,
            siLabelVersion,
            this.siVersion});
            this.mainStatus.Location = new System.Drawing.Point(0, 477);
            this.mainStatus.Name = "mainStatus";
            this.mainStatus.Size = new System.Drawing.Size(802, 22);
            this.mainStatus.TabIndex = 2;
            // 
            // siCurAction
            // 
            this.siCurAction.Name = "siCurAction";
            this.siCurAction.Size = new System.Drawing.Size(434, 17);
            this.siCurAction.Spring = true;
            this.siCurAction.Text = "Ready";
            this.siCurAction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // siUser
            // 
            this.siUser.AutoSize = false;
            this.siUser.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.siUser.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.siUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.siUser.DoubleClickEnabled = true;
            this.siUser.Margin = new System.Windows.Forms.Padding(0, 3, 10, 2);
            this.siUser.Name = "siUser";
            this.siUser.Size = new System.Drawing.Size(140, 17);
            this.siUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.siUser.DoubleClick += new System.EventHandler(this.toolStripItem_Click);
            this.siUser.MouseDown += new System.Windows.Forms.MouseEventHandler(this.siUser_MouseDown);
            // 
            // siVersion
            // 
            this.siVersion.AutoSize = false;
            this.siVersion.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.siVersion.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.siVersion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.siVersion.DoubleClickEnabled = true;
            this.siVersion.Margin = new System.Windows.Forms.Padding(0, 3, 10, 2);
            this.siVersion.Name = "siVersion";
            this.siVersion.Size = new System.Drawing.Size(70, 17);
            this.siVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.siVersion.DoubleClick += new System.EventHandler(this.toolStripItem_Click);
            // 
            // contMenuUser
            // 
            this.contMenuUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miUserLogin,
            this.miUserLogout,
            miUserSep1,
            this.miUserChangePwd});
            this.contMenuUser.Name = "contMenuUser";
            this.contMenuUser.Size = new System.Drawing.Size(178, 76);
            // 
            // miUserLogin
            // 
            this.miUserLogin.Name = "miUserLogin";
            this.miUserLogin.Size = new System.Drawing.Size(177, 22);
            this.miUserLogin.Text = "Login...";
            this.miUserLogin.Click += new System.EventHandler(this.toolStripItem_Click);
            // 
            // miUserLogout
            // 
            this.miUserLogout.Name = "miUserLogout";
            this.miUserLogout.Size = new System.Drawing.Size(177, 22);
            this.miUserLogout.Text = "Logout";
            this.miUserLogout.Click += new System.EventHandler(this.toolStripItem_Click);
            // 
            // miUserChangePwd
            // 
            this.miUserChangePwd.Name = "miUserChangePwd";
            this.miUserChangePwd.Size = new System.Drawing.Size(177, 22);
            this.miUserChangePwd.Text = "Change password...";
            this.miUserChangePwd.Click += new System.EventHandler(this.toolStripItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 499);
            this.Controls.Add(this.panelNavig);
            this.Controls.Add(this.mainStatus);
            this.Controls.Add(this.menuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuMain;
            this.Name = "FormMain";
            this.Text = "Manager";
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormMain_KeyPress);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.panelNavig.ResumeLayout(false);
            this.contMenuNavigPanel.ResumeLayout(false);
            this.mainStatus.ResumeLayout(false);
            this.mainStatus.PerformLayout();
            this.contMenuUser.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem miAppExit;
        private System.Windows.Forms.ToolStripMenuItem miHlpAbout;
        private System.Windows.Forms.Panel panelNavig;
        private System.Windows.Forms.Button btnViewAddr;
        private System.Windows.Forms.ContextMenuStrip contMenuNavigPanel;
        private System.Windows.Forms.ToolStripMenuItem miNavigPanelLeft;
        private System.Windows.Forms.ToolStripMenuItem miNavigPanelRight;
        private System.Windows.Forms.ToolStripMenuItem miNavigPanelHide;
        private System.Windows.Forms.ToolStripMenuItem miViewNavigPanel;
        private System.Windows.Forms.ToolStripSeparator miViewSep;
        private System.Windows.Forms.ToolStripMenuItem miViewTbl;
        private System.Windows.Forms.ToolStripMenuItem miViewTblAddr;
        private System.Windows.Forms.ToolStripMenuItem miViewTblProd;
        private System.Windows.Forms.Button btnViewProd;
        private System.Windows.Forms.ToolStripMenuItem miView;
        private System.Windows.Forms.ToolStripMenuItem miData;
        private System.Windows.Forms.ToolStripMenuItem miDataAdd;
        private System.Windows.Forms.ToolStripMenuItem miDataEdit;
        private System.Windows.Forms.ToolStripMenuItem miDataDel;
        private System.Windows.Forms.ToolStripSeparator miDataSep1;
        private System.Windows.Forms.ToolStripMenuItem miDataRefresh;
        private System.Windows.Forms.ToolStripSeparator miDataSep2;
        private System.Windows.Forms.ToolStripMenuItem miDataFilter;
        private System.Windows.Forms.ToolStripMenuItem miAppSetup;
        private System.Windows.Forms.StatusStrip mainStatus;
        private System.Windows.Forms.ToolStripStatusLabel siCurAction;
        private System.Windows.Forms.ToolStripStatusLabel siUser;
        private System.Windows.Forms.ToolStripSeparator miAppSep1;
        private System.Windows.Forms.ToolStripStatusLabel siVersion;
        private System.Windows.Forms.Button btnViewUser;
        private System.Windows.Forms.ToolStripMenuItem miViewTblUser;
        private System.Windows.Forms.ContextMenuStrip contMenuUser;
        private System.Windows.Forms.ToolStripMenuItem miUserLogin;
        private System.Windows.Forms.ToolStripMenuItem miUserChangePwd;
        private System.Windows.Forms.ToolStripMenuItem miAppUser;
        private System.Windows.Forms.ToolStripMenuItem miAppUserLogin;
        private System.Windows.Forms.ToolStripMenuItem miAppUserLogout;
        private System.Windows.Forms.ToolStripMenuItem miAppUserChangePwd;
        private System.Windows.Forms.ToolStripSeparator miAppUserSep1;
        private System.Windows.Forms.ToolStripMenuItem miUserLogout;
    }
}

