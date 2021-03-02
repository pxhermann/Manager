namespace Manager
{
    partial class DlgUser
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Button btnCancel;
            System.Windows.Forms.Button btnOK;
            System.Windows.Forms.GroupBox groupBox1;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
            this.tbPwd = new System.Windows.Forms.TextBox();
            this.tbPwdConfirm = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.chbAdmin = new System.Windows.Forms.CheckBox();
            this.chbUser = new System.Windows.Forms.CheckBox();
            this.chbAddr = new System.Windows.Forms.CheckBox();
            this.chbProd = new System.Windows.Forms.CheckBox();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            btnCancel = new System.Windows.Forms.Button();
            btnOK = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            groupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbPwd
            // 
            this.tbPwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPwd.Location = new System.Drawing.Point(107, 53);
            this.tbPwd.MaxLength = 64;
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.PasswordChar = '*';
            this.tbPwd.Size = new System.Drawing.Size(249, 20);
            this.tbPwd.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(44, 56);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(56, 13);
            label2.TabIndex = 2;
            label2.Text = "Password:";
            // 
            // tbPwdConfirm
            // 
            this.tbPwdConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPwdConfirm.Location = new System.Drawing.Point(107, 79);
            this.tbPwdConfirm.MaxLength = 64;
            this.tbPwdConfirm.Name = "tbPwdConfirm";
            this.tbPwdConfirm.PasswordChar = '*';
            this.tbPwdConfirm.Size = new System.Drawing.Size(249, 20);
            this.tbPwdConfirm.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(7, 82);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(93, 13);
            label1.TabIndex = 4;
            label1.Text = "Confirm password:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(62, 19);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(38, 13);
            label3.TabIndex = 0;
            label3.Text = "Name:";
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.Location = new System.Drawing.Point(107, 16);
            this.tbName.MaxLength = 50;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(249, 20);
            this.tbName.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancel.Location = new System.Drawing.Point(290, 234);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(100, 27);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Storno";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnOK.Location = new System.Drawing.Point(172, 234);
            btnOK.Name = "btnOK";
            btnOK.Size = new System.Drawing.Size(100, 27);
            btnOK.TabIndex = 7;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            groupBox1.Controls.Add(tableLayoutPanel1);
            groupBox1.Controls.Add(this.chbAdmin);
            groupBox1.Location = new System.Drawing.Point(15, 119);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(375, 101);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Access rights";
            // 
            // chbAdmin
            // 
            this.chbAdmin.AutoSize = true;
            this.chbAdmin.Location = new System.Drawing.Point(92, 0);
            this.chbAdmin.Name = "chbAdmin";
            this.chbAdmin.Size = new System.Drawing.Size(85, 17);
            this.chbAdmin.TabIndex = 0;
            this.chbAdmin.Text = "administrator";
            this.chbAdmin.UseVisualStyleBackColor = true;
            this.chbAdmin.CheckedChanged += new System.EventHandler(this.chbAdmin_CheckedChanged);
            // 
            // chbUser
            // 
            this.chbUser.AutoSize = true;
            this.chbUser.Location = new System.Drawing.Point(3, 34);
            this.chbUser.Name = "chbUser";
            this.chbUser.Size = new System.Drawing.Size(51, 17);
            this.chbUser.TabIndex = 2;
            this.chbUser.Text = "users";
            this.chbUser.UseVisualStyleBackColor = true;
            // 
            // chbAddr
            // 
            this.chbAddr.AutoSize = true;
            this.chbAddr.Location = new System.Drawing.Point(3, 3);
            this.chbAddr.Name = "chbAddr";
            this.chbAddr.Size = new System.Drawing.Size(74, 17);
            this.chbAddr.TabIndex = 0;
            this.chbAddr.Text = "addresses";
            this.chbAddr.UseVisualStyleBackColor = true;
            // 
            // chbProd
            // 
            this.chbProd.AutoSize = true;
            this.chbProd.Location = new System.Drawing.Point(171, 3);
            this.chbProd.Name = "chbProd";
            this.chbProd.Size = new System.Drawing.Size(67, 17);
            this.chbProd.TabIndex = 1;
            this.chbProd.Text = "products";
            this.chbProd.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(this.chbProd, 1, 0);
            tableLayoutPanel1.Controls.Add(this.chbUser, 0, 1);
            tableLayoutPanel1.Controls.Add(this.chbAddr, 0, 0);
            tableLayoutPanel1.Location = new System.Drawing.Point(32, 25);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new System.Drawing.Size(337, 62);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // DlgUser
            // 
            this.AcceptButton = btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = btnCancel;
            this.ClientSize = new System.Drawing.Size(402, 273);
            this.Controls.Add(groupBox1);
            this.Controls.Add(btnCancel);
            this.Controls.Add(btnOK);
            this.Controls.Add(this.tbName);
            this.Controls.Add(label3);
            this.Controls.Add(this.tbPwdConfirm);
            this.Controls.Add(label1);
            this.Controls.Add(this.tbPwd);
            this.Controls.Add(label2);
            this.MinimumSize = new System.Drawing.Size(410, 300);
            this.Name = "DlgUser";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User";
            this.Load += new System.EventHandler(this.DlgUser_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DlgUser_FormClosing);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPwd;
        private System.Windows.Forms.TextBox tbPwdConfirm;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.CheckBox chbProd;
        private System.Windows.Forms.CheckBox chbAddr;
        private System.Windows.Forms.CheckBox chbUser;
        private System.Windows.Forms.CheckBox chbAdmin;
    }
}