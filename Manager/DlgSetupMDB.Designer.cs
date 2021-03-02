namespace Manager
{
    partial class DlgSetupMDB
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
            System.Windows.Forms.Label lblServer;
            this.btnSelDbFile = new System.Windows.Forms.Button();
            this.tbDbFile = new System.Windows.Forms.TextBox();
            this.btnTestConn = new System.Windows.Forms.Button();
            this.tbPwd = new System.Windows.Forms.TextBox();
            this.lblPwd = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            lblServer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblServer
            // 
            lblServer.Location = new System.Drawing.Point(8, 18);
            lblServer.Name = "lblServer";
            lblServer.Size = new System.Drawing.Size(74, 20);
            lblServer.TabIndex = 0;
            lblServer.Text = "Database file:";
            lblServer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSelDbFile
            // 
            this.btnSelDbFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelDbFile.Location = new System.Drawing.Point(411, 18);
            this.btnSelDbFile.Name = "btnSelDbFile";
            this.btnSelDbFile.Size = new System.Drawing.Size(24, 21);
            this.btnSelDbFile.TabIndex = 2;
            this.btnSelDbFile.Text = "...";
            this.btnSelDbFile.UseVisualStyleBackColor = true;
            this.btnSelDbFile.Click += new System.EventHandler(this.btnSelDbFile_Click);
            // 
            // tbDbFile
            // 
            this.tbDbFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDbFile.Location = new System.Drawing.Point(88, 19);
            this.tbDbFile.Name = "tbDbFile";
            this.tbDbFile.Size = new System.Drawing.Size(323, 20);
            this.tbDbFile.TabIndex = 1;
            // 
            // btnTestConn
            // 
            this.btnTestConn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestConn.Location = new System.Drawing.Point(302, 66);
            this.btnTestConn.Name = "btnTestConn";
            this.btnTestConn.Size = new System.Drawing.Size(133, 27);
            this.btnTestConn.TabIndex = 7;
            this.btnTestConn.Text = "Test connection...";
            this.btnTestConn.Click += new System.EventHandler(this.btnTestConn_Click);
            // 
            // tbPwd
            // 
            this.tbPwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPwd.Location = new System.Drawing.Point(88, 81);
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.PasswordChar = '*';
            this.tbPwd.Size = new System.Drawing.Size(159, 20);
            this.tbPwd.TabIndex = 6;
            // 
            // lblPwd
            // 
            this.lblPwd.Location = new System.Drawing.Point(10, 80);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(71, 20);
            this.lblPwd.TabIndex = 5;
            this.lblPwd.Text = "Password:";
            this.lblPwd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(335, 134);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 27);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Storno";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(229, 134);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 27);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // tbUser
            // 
            this.tbUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUser.Location = new System.Drawing.Point(88, 56);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(159, 20);
            this.tbUser.TabIndex = 4;
            // 
            // lblUser
            // 
            this.lblUser.Location = new System.Drawing.Point(12, 56);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(70, 20);
            this.lblUser.TabIndex = 3;
            this.lblUser.Text = "User:";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DlgSetupMDB
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(442, 173);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.btnSelDbFile);
            this.Controls.Add(this.tbDbFile);
            this.Controls.Add(this.btnTestConn);
            this.Controls.Add(this.tbPwd);
            this.Controls.Add(this.lblPwd);
            this.Controls.Add(lblServer);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "DlgSetupMDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DlgSetupMDB";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DlgSetupMDB_FormClosing);
            this.Load += new System.EventHandler(this.DlgSetupMDB_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelDbFile;
        internal System.Windows.Forms.TextBox tbDbFile;
        private System.Windows.Forms.Button btnTestConn;
        internal System.Windows.Forms.TextBox tbPwd;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Label lblUser;
    }
}