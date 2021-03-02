namespace Manager
{
	partial class DlgSetupSQL
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbDatabase = new System.Windows.Forms.ComboBox();
            this.cbServer = new System.Windows.Forms.ComboBox();
            this.radioAuthSQL = new System.Windows.Forms.RadioButton();
            this.btnTestConn = new System.Windows.Forms.Button();
            this.tbPwd = new System.Windows.Forms.TextBox();
            this.lblPwd = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.radioAuthWin = new System.Windows.Forms.RadioButton();
            this.lblDB = new System.Windows.Forms.Label();
            this.lblConn = new System.Windows.Forms.Label();
            this.lblServer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(216, 202);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 27);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(322, 202);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 27);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Storno";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cbDatabase
            // 
            this.cbDatabase.FormattingEnabled = true;
            this.cbDatabase.Location = new System.Drawing.Point(104, 156);
            this.cbDatabase.Name = "cbDatabase";
            this.cbDatabase.Size = new System.Drawing.Size(318, 21);
            this.cbDatabase.TabIndex = 23;
            this.cbDatabase.Text = "master";
            this.cbDatabase.DropDown += new System.EventHandler(this.cbDatabase_DropDown);
            // 
            // cbServer
            // 
            this.cbServer.FormattingEnabled = true;
            this.cbServer.Location = new System.Drawing.Point(104, 12);
            this.cbServer.Name = "cbServer";
            this.cbServer.Size = new System.Drawing.Size(318, 21);
            this.cbServer.TabIndex = 13;
            this.cbServer.Text = "(local)";
            this.cbServer.DropDown += new System.EventHandler(this.cbServer_DropDown);
            // 
            // radioAuthSQL
            // 
            this.radioAuthSQL.Location = new System.Drawing.Point(104, 50);
            this.radioAuthSQL.Name = "radioAuthSQL";
            this.radioAuthSQL.Size = new System.Drawing.Size(160, 21);
            this.radioAuthSQL.TabIndex = 15;
            this.radioAuthSQL.Text = "SQL server authentication";
            this.radioAuthSQL.CheckedChanged += new System.EventHandler(this.radioAuth_CheckedChanged);
            // 
            // btnTestConn
            // 
            this.btnTestConn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestConn.Location = new System.Drawing.Point(289, 94);
            this.btnTestConn.Name = "btnTestConn";
            this.btnTestConn.Size = new System.Drawing.Size(133, 27);
            this.btnTestConn.TabIndex = 21;
            this.btnTestConn.Text = "Test connection...";
            this.btnTestConn.Click += new System.EventHandler(this.btnTestConn_Click);
            // 
            // tbPwd
            // 
            this.tbPwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPwd.Location = new System.Drawing.Point(104, 111);
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.PasswordChar = '*';
            this.tbPwd.Size = new System.Drawing.Size(140, 20);
            this.tbPwd.TabIndex = 20;
            // 
            // lblPwd
            // 
            this.lblPwd.Location = new System.Drawing.Point(18, 110);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(80, 20);
            this.lblPwd.TabIndex = 19;
            this.lblPwd.Text = "Password:";
            this.lblPwd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbUser
            // 
            this.tbUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUser.Location = new System.Drawing.Point(104, 85);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(140, 20);
            this.tbUser.TabIndex = 18;
            // 
            // lblUser
            // 
            this.lblUser.Location = new System.Drawing.Point(28, 85);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(70, 20);
            this.lblUser.TabIndex = 17;
            this.lblUser.Text = "User:";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // radioAuthWin
            // 
            this.radioAuthWin.Checked = true;
            this.radioAuthWin.Location = new System.Drawing.Point(269, 50);
            this.radioAuthWin.Name = "radioAuthWin";
            this.radioAuthWin.Size = new System.Drawing.Size(144, 21);
            this.radioAuthWin.TabIndex = 16;
            this.radioAuthWin.TabStop = true;
            this.radioAuthWin.Text = "Windows authentication";
            this.radioAuthWin.CheckedChanged += new System.EventHandler(this.radioAuth_CheckedChanged);
            // 
            // lblDB
            // 
            this.lblDB.Location = new System.Drawing.Point(21, 155);
            this.lblDB.Name = "lblDB";
            this.lblDB.Size = new System.Drawing.Size(77, 20);
            this.lblDB.TabIndex = 22;
            this.lblDB.Text = "Database:";
            this.lblDB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblConn
            // 
            this.lblConn.Location = new System.Drawing.Point(14, 50);
            this.lblConn.Name = "lblConn";
            this.lblConn.Size = new System.Drawing.Size(84, 20);
            this.lblConn.TabIndex = 14;
            this.lblConn.Text = "Authentication:";
            this.lblConn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblServer
            // 
            this.lblServer.Location = new System.Drawing.Point(25, 13);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(73, 20);
            this.lblServer.TabIndex = 12;
            this.lblServer.Text = "Server:";
            this.lblServer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DlgSetupSQL
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(434, 241);
            this.Controls.Add(this.cbDatabase);
            this.Controls.Add(this.cbServer);
            this.Controls.Add(this.radioAuthSQL);
            this.Controls.Add(this.btnTestConn);
            this.Controls.Add(this.tbPwd);
            this.Controls.Add(this.lblPwd);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.radioAuthWin);
            this.Controls.Add(this.lblDB);
            this.Controls.Add(this.lblConn);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximumSize = new System.Drawing.Size(450, 280);
            this.MinimumSize = new System.Drawing.Size(450, 280);
            this.Name = "DlgSetupSQL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Database setup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DlgSetupDB_FormClosing);
            this.Load += new System.EventHandler(this.DlgSetupBasic_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.ComboBox cbDatabase;
        internal System.Windows.Forms.ComboBox cbServer;
        internal System.Windows.Forms.RadioButton radioAuthSQL;
        private System.Windows.Forms.Button btnTestConn;
        internal System.Windows.Forms.TextBox tbPwd;
        private System.Windows.Forms.Label lblPwd;
        internal System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Label lblUser;
        internal System.Windows.Forms.RadioButton radioAuthWin;
        private System.Windows.Forms.Label lblDB;
        private System.Windows.Forms.Label lblConn;
        private System.Windows.Forms.Label lblServer;
    }
}