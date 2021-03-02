namespace Manager
{
    partial class DlgProduct
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
            System.Windows.Forms.Button btnCancel;
            System.Windows.Forms.Button btnOK;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbCatalog = new System.Windows.Forms.TextBox();
            this.tbUnit = new System.Windows.Forms.TextBox();
            this.tbSalePrice = new System.Windows.Forms.TextBox();
            this.tbBuyPrice = new System.Windows.Forms.TextBox();
            this.nudVatRate = new System.Windows.Forms.NumericUpDown();
            btnCancel = new System.Windows.Forms.Button();
            btnOK = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudVatRate)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancel.Location = new System.Drawing.Point(302, 137);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(100, 27);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Storno";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnOK.Location = new System.Drawing.Point(200, 137);
            btnOK.Name = "btnOK";
            btnOK.Size = new System.Drawing.Size(100, 27);
            btnOK.TabIndex = 12;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(14, 20);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(46, 13);
            label3.TabIndex = 0;
            label3.Text = "Catalog:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(22, 46);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(38, 13);
            label1.TabIndex = 4;
            label1.Text = "Name:";
            // 
            // label2
            // 
            label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(279, 20);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(29, 13);
            label2.TabIndex = 2;
            label2.Text = "Unit:";
            // 
            // label4
            // 
            label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(239, 83);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(69, 13);
            label4.TabIndex = 10;
            label4.Text = "VAT rate [%]:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(3, 108);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(57, 13);
            label5.TabIndex = 8;
            label5.Text = "Sale price:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(6, 81);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(54, 13);
            label6.TabIndex = 6;
            label6.Text = "Buy price:";
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.Location = new System.Drawing.Point(66, 43);
            this.tbName.MaxLength = 50;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(336, 20);
            this.tbName.TabIndex = 5;
            // 
            // tbCatalog
            // 
            this.tbCatalog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCatalog.Location = new System.Drawing.Point(66, 17);
            this.tbCatalog.MaxLength = 20;
            this.tbCatalog.Name = "tbCatalog";
            this.tbCatalog.Size = new System.Drawing.Size(151, 20);
            this.tbCatalog.TabIndex = 1;
            // 
            // tbUnit
            // 
            this.tbUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUnit.Location = new System.Drawing.Point(314, 17);
            this.tbUnit.MaxLength = 10;
            this.tbUnit.Name = "tbUnit";
            this.tbUnit.Size = new System.Drawing.Size(88, 20);
            this.tbUnit.TabIndex = 3;
            // 
            // tbSalePrice
            // 
            this.tbSalePrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSalePrice.Location = new System.Drawing.Point(66, 105);
            this.tbSalePrice.MaxLength = 20;
            this.tbSalePrice.Name = "tbSalePrice";
            this.tbSalePrice.Size = new System.Drawing.Size(151, 20);
            this.tbSalePrice.TabIndex = 9;
            // 
            // tbBuyPrice
            // 
            this.tbBuyPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBuyPrice.Location = new System.Drawing.Point(66, 79);
            this.tbBuyPrice.MaxLength = 20;
            this.tbBuyPrice.Name = "tbBuyPrice";
            this.tbBuyPrice.Size = new System.Drawing.Size(151, 20);
            this.tbBuyPrice.TabIndex = 7;
            // 
            // nudVatRate
            // 
            this.nudVatRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudVatRate.Location = new System.Drawing.Point(314, 80);
            this.nudVatRate.Name = "nudVatRate";
            this.nudVatRate.Size = new System.Drawing.Size(88, 20);
            this.nudVatRate.TabIndex = 11;
            // 
            // DlgProduct
            // 
            this.AcceptButton = btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = btnCancel;
            this.ClientSize = new System.Drawing.Size(414, 176);
            this.Controls.Add(this.nudVatRate);
            this.Controls.Add(this.tbBuyPrice);
            this.Controls.Add(label6);
            this.Controls.Add(this.tbSalePrice);
            this.Controls.Add(label5);
            this.Controls.Add(label4);
            this.Controls.Add(this.tbUnit);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Controls.Add(this.tbCatalog);
            this.Controls.Add(this.tbName);
            this.Controls.Add(label3);
            this.Controls.Add(btnCancel);
            this.Controls.Add(btnOK);
            this.MaximumSize = new System.Drawing.Size(430, 215);
            this.MinimumSize = new System.Drawing.Size(430, 215);
            this.Name = "DlgProduct";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Product";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DlgProduct_FormClosing);
            this.Load += new System.EventHandler(this.DlgProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudVatRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbCatalog;
        private System.Windows.Forms.TextBox tbUnit;
        private System.Windows.Forms.TextBox tbSalePrice;
        private System.Windows.Forms.TextBox tbBuyPrice;
        private System.Windows.Forms.NumericUpDown nudVatRate;
    }
}