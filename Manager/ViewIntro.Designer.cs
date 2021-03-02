namespace Manager
{
    partial class ViewIntro
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label lblText;
            lblText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblText
            // 
            lblText.BackColor = System.Drawing.Color.White;
            lblText.Dock = System.Windows.Forms.DockStyle.Fill;
            lblText.Font = new System.Drawing.Font("Monotype Corsiva", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            lblText.Location = new System.Drawing.Point(0, 0);
            lblText.Name = "lblText";
            lblText.Size = new System.Drawing.Size(436, 265);
            lblText.TabIndex = 0;
            lblText.Text = "Manager test";
            lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ViewIntro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(lblText);
            this.Name = "ViewIntro";
            this.Size = new System.Drawing.Size(436, 265);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
