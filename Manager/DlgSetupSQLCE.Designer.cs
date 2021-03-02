namespace Manager
{
    partial class DlgSetupSQLCE
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnTestConn = new System.Windows.Forms.Button();
            this.tbPwd = new System.Windows.Forms.TextBox();
            this.lblPwd = new System.Windows.Forms.Label();
            this.btnSelDbFile = new System.Windows.Forms.Button();
            this.tbDbFile = new System.Windows.Forms.TextBox();
            lblServer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblServer
            // 
            lblServer.Location = new System.Drawing.Point(3, 21);
            lblServer.Name = "lblServer";
            lblServer.Size = new System.Drawing.Size(74, 20);
            lblServer.TabIndex = 0;
            lblServer.Text = "Database file:";
            lblServer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(330, 134);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 27);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Storno";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(212, 134);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 27);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnTestConn
            // 
            this.btnTestConn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestConn.Location = new System.Drawing.Point(297, 69);
            this.btnTestConn.Name = "btnTestConn";
            this.btnTestConn.Size = new System.Drawing.Size(133, 27);
            this.btnTestConn.TabIndex = 5;
            this.btnTestConn.Text = "Test connection...";
            this.btnTestConn.Click += new System.EventHandler(this.btnTestConn_Click);
            // 
            // tbPwd
            // 
            this.tbPwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPwd.Location = new System.Drawing.Point(84, 73);
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.PasswordChar = '*';
            this.tbPwd.Size = new System.Drawing.Size(160, 20);
            this.tbPwd.TabIndex = 4;
            // 
            // lblPwd
            // 
            this.lblPwd.Location = new System.Drawing.Point(6, 72);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(71, 20);
            this.lblPwd.TabIndex = 3;
            this.lblPwd.Text = "Password:";
            this.lblPwd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSelDbFile
            // 
            this.btnSelDbFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelDbFile.Location = new System.Drawing.Point(406, 21);
            this.btnSelDbFile.Name = "btnSelDbFile";
            this.btnSelDbFile.Size = new System.Drawing.Size(24, 21);
            this.btnSelDbFile.TabIndex = 2;
            this.btnSelDbFile.Text = "...";
            this.btnSelDbFile.UseVisualStyleBackColor = true;
            this.btnSelDbFile.Click += new System.EventHandler(this.btnSelDbCE_Click);
            // 
            // tbDbFile
            // 
            this.tbDbFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDbFile.Location = new System.Drawing.Point(83, 22);
            this.tbDbFile.Name = "tbDbFile";
            this.tbDbFile.Size = new System.Drawing.Size(323, 20);
            this.tbDbFile.TabIndex = 1;
            this.tbDbFile.Text = "(local)";
            // 
            // DlgSetupSQLCE
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(442, 173);
            this.Controls.Add(this.btnSelDbFile);
            this.Controls.Add(this.tbDbFile);
            this.Controls.Add(this.btnTestConn);
            this.Controls.Add(this.tbPwd);
            this.Controls.Add(this.lblPwd);
            this.Controls.Add(lblServer);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.MaximumSize = new System.Drawing.Size(1000, 200);
            this.MinimumSize = new System.Drawing.Size(450, 200);
            this.Name = "DlgSetupSQLCE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DlgSetupSQLCE";
            this.Load += new System.EventHandler(this.DlgSetupSQLCE_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DlgSetupSQLCE_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnTestConn;
        internal System.Windows.Forms.TextBox tbPwd;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.Button btnSelDbFile;
        internal System.Windows.Forms.TextBox tbDbFile;
    }
}