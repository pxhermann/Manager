namespace Manager
{
    partial class DlgAddress
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
			System.Windows.Forms.Label label3;
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label label2;
			System.Windows.Forms.Label label4;
			System.Windows.Forms.Label label5;
			System.Windows.Forms.Button btnCancel;
			System.Windows.Forms.Button btnOK;
			System.Windows.Forms.Label label6;
			System.Windows.Forms.Label label7;
			System.Windows.Forms.Label label8;
			System.Windows.Forms.Label label9;
			this.tbName = new System.Windows.Forms.TextBox();
			this.tbStreet = new System.Windows.Forms.TextBox();
			this.tbCity = new System.Windows.Forms.TextBox();
			this.tbZip = new System.Windows.Forms.TextBox();
			this.tbICO = new System.Windows.Forms.TextBox();
			this.tbDIC = new System.Windows.Forms.TextBox();
			this.tbTel = new System.Windows.Forms.TextBox();
			this.tbFax = new System.Windows.Forms.TextBox();
			this.tbNote = new System.Windows.Forms.TextBox();
			this.btnGetARES = new System.Windows.Forms.Button();
			label3 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			btnCancel = new System.Windows.Forms.Button();
			btnOK = new System.Windows.Forms.Button();
			label6 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(11, 20);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(38, 13);
			label3.TabIndex = 0;
			label3.Text = "Name:";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(11, 46);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(38, 13);
			label1.TabIndex = 2;
			label1.Text = "Street:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(22, 72);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(27, 13);
			label2.TabIndex = 4;
			label2.Text = "City:";
			// 
			// label4
			// 
			label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(308, 72);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(25, 13);
			label4.TabIndex = 6;
			label4.Text = "Zip:";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(29, 112);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(20, 13);
			label5.TabIndex = 8;
			label5.Text = "IC:";
			// 
			// btnCancel
			// 
			btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			btnCancel.Location = new System.Drawing.Point(328, 256);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new System.Drawing.Size(100, 27);
			btnCancel.TabIndex = 19;
			btnCancel.Text = "Storno";
			btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			btnOK.Location = new System.Drawing.Point(222, 256);
			btnOK.Name = "btnOK";
			btnOK.Size = new System.Drawing.Size(100, 27);
			btnOK.TabIndex = 18;
			btnOK.Text = "OK";
			btnOK.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(21, 138);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(28, 13);
			label6.TabIndex = 10;
			label6.Text = "DIC:";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(247, 112);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(21, 13);
			label7.TabIndex = 12;
			label7.Text = "tel:";
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(244, 138);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(24, 13);
			label8.TabIndex = 14;
			label8.Text = "fax:";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(16, 180);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(33, 13);
			label9.TabIndex = 16;
			label9.Text = "Note:";
			// 
			// tbName
			// 
			this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbName.Location = new System.Drawing.Point(55, 17);
			this.tbName.MaxLength = 50;
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(373, 20);
			this.tbName.TabIndex = 1;
			// 
			// tbStreet
			// 
			this.tbStreet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbStreet.Location = new System.Drawing.Point(55, 43);
			this.tbStreet.MaxLength = 30;
			this.tbStreet.Name = "tbStreet";
			this.tbStreet.Size = new System.Drawing.Size(373, 20);
			this.tbStreet.TabIndex = 3;
			// 
			// tbCity
			// 
			this.tbCity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbCity.Location = new System.Drawing.Point(55, 69);
			this.tbCity.MaxLength = 40;
			this.tbCity.Name = "tbCity";
			this.tbCity.Size = new System.Drawing.Size(234, 20);
			this.tbCity.TabIndex = 5;
			// 
			// tbZip
			// 
			this.tbZip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.tbZip.Location = new System.Drawing.Point(339, 69);
			this.tbZip.MaxLength = 10;
			this.tbZip.Name = "tbZip";
			this.tbZip.Size = new System.Drawing.Size(89, 20);
			this.tbZip.TabIndex = 7;
			// 
			// tbICO
			// 
			this.tbICO.Location = new System.Drawing.Point(55, 109);
			this.tbICO.MaxLength = 8;
			this.tbICO.Name = "tbICO";
			this.tbICO.Size = new System.Drawing.Size(122, 20);
			this.tbICO.TabIndex = 9;
			// 
			// tbDIC
			// 
			this.tbDIC.Location = new System.Drawing.Point(55, 135);
			this.tbDIC.MaxLength = 14;
			this.tbDIC.Name = "tbDIC";
			this.tbDIC.Size = new System.Drawing.Size(176, 20);
			this.tbDIC.TabIndex = 11;
			// 
			// tbTel
			// 
			this.tbTel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbTel.Location = new System.Drawing.Point(274, 109);
			this.tbTel.MaxLength = 128;
			this.tbTel.Name = "tbTel";
			this.tbTel.Size = new System.Drawing.Size(154, 20);
			this.tbTel.TabIndex = 13;
			// 
			// tbFax
			// 
			this.tbFax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbFax.Location = new System.Drawing.Point(274, 135);
			this.tbFax.MaxLength = 128;
			this.tbFax.Name = "tbFax";
			this.tbFax.Size = new System.Drawing.Size(154, 20);
			this.tbFax.TabIndex = 15;
			// 
			// tbNote
			// 
			this.tbNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbNote.Location = new System.Drawing.Point(55, 177);
			this.tbNote.MaxLength = 1024;
			this.tbNote.Multiline = true;
			this.tbNote.Name = "tbNote";
			this.tbNote.Size = new System.Drawing.Size(373, 64);
			this.tbNote.TabIndex = 17;
			// 
			// btnGetARES
			// 
			this.btnGetARES.Location = new System.Drawing.Point(177, 108);
			this.btnGetARES.Name = "btnGetARES";
			this.btnGetARES.Size = new System.Drawing.Size(54, 22);
			this.btnGetARES.TabIndex = 20;
			this.btnGetARES.Text = "ARES...";
			this.btnGetARES.UseVisualStyleBackColor = true;
			this.btnGetARES.Click += new System.EventHandler(this.btnGetARES_Click);
			// 
			// DlgAddress
			// 
			this.AcceptButton = btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = btnCancel;
			this.ClientSize = new System.Drawing.Size(440, 295);
			this.Controls.Add(this.btnGetARES);
			this.Controls.Add(label9);
			this.Controls.Add(this.tbNote);
			this.Controls.Add(this.tbFax);
			this.Controls.Add(label8);
			this.Controls.Add(this.tbTel);
			this.Controls.Add(label7);
			this.Controls.Add(this.tbDIC);
			this.Controls.Add(label6);
			this.Controls.Add(btnCancel);
			this.Controls.Add(btnOK);
			this.Controls.Add(this.tbICO);
			this.Controls.Add(label5);
			this.Controls.Add(this.tbZip);
			this.Controls.Add(label4);
			this.Controls.Add(this.tbCity);
			this.Controls.Add(label2);
			this.Controls.Add(this.tbStreet);
			this.Controls.Add(label1);
			this.Controls.Add(this.tbName);
			this.Controls.Add(label3);
			this.MinimumSize = new System.Drawing.Size(430, 250);
			this.Name = "DlgAddress";
			this.ShowIcon = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Address";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DlgAddress_FormClosing);
			this.Load += new System.EventHandler(this.DlgAddress_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbStreet;
        private System.Windows.Forms.TextBox tbCity;
        private System.Windows.Forms.TextBox tbZip;
        private System.Windows.Forms.TextBox tbICO;
        private System.Windows.Forms.TextBox tbDIC;
        private System.Windows.Forms.TextBox tbTel;
        private System.Windows.Forms.TextBox tbFax;
        private System.Windows.Forms.TextBox tbNote;
        private System.Windows.Forms.Button btnGetARES;
    }
}