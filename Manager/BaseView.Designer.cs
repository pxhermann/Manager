namespace Manager
{
    partial class BaseView
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.panelHeader = new System.Windows.Forms.Panel();
			this.btnFilter = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnDel = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.lblTitle = new System.Windows.Forms.Label();
			this.contMenuGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.miGridAdd = new System.Windows.Forms.ToolStripMenuItem();
			this.miGridEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.miGridDel = new System.Windows.Forms.ToolStripMenuItem();
			this.miGridSep1 = new System.Windows.Forms.ToolStripSeparator();
			this.miGridRefresh = new System.Windows.Forms.ToolStripMenuItem();
			this.miGridSep2 = new System.Windows.Forms.ToolStripSeparator();
			this.miGridFilter = new System.Windows.Forms.ToolStripMenuItem();
			this.dgView = new System.Windows.Forms.DataGridView();
			this.tbSearch = new System.Windows.Forms.TextBox();
			this.panelHeader.SuspendLayout();
			this.contMenuGrid.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
			this.SuspendLayout();
			// 
			// panelHeader
			// 
			this.panelHeader.Controls.Add(this.btnFilter);
			this.panelHeader.Controls.Add(this.btnEdit);
			this.panelHeader.Controls.Add(this.btnDel);
			this.panelHeader.Controls.Add(this.btnAdd);
			this.panelHeader.Controls.Add(this.lblTitle);
			this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelHeader.Location = new System.Drawing.Point(0, 0);
			this.panelHeader.Name = "panelHeader";
			this.panelHeader.Size = new System.Drawing.Size(456, 30);
			this.panelHeader.TabIndex = 0;
			// 
			// btnFilter
			// 
			this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.btnFilter.BackColor = System.Drawing.Color.Maroon;
			this.btnFilter.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnFilter.ForeColor = System.Drawing.Color.White;
			this.btnFilter.Location = new System.Drawing.Point(260, 3);
			this.btnFilter.Name = "btnFilter";
			this.btnFilter.Size = new System.Drawing.Size(80, 24);
			this.btnFilter.TabIndex = 3;
			this.btnFilter.TabStop = false;
			this.btnFilter.Text = "Filter";
			this.btnFilter.UseVisualStyleBackColor = false;
			// 
			// btnEdit
			// 
			this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.btnEdit.BackColor = System.Drawing.Color.Maroon;
			this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnEdit.ForeColor = System.Drawing.Color.White;
			this.btnEdit.Location = new System.Drawing.Point(86, 3);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(80, 24);
			this.btnEdit.TabIndex = 1;
			this.btnEdit.TabStop = false;
			this.btnEdit.Text = "Edit";
			this.btnEdit.UseVisualStyleBackColor = false;
			this.btnEdit.Click += new System.EventHandler(this.action_Click);
			// 
			// btnDel
			// 
			this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.btnDel.BackColor = System.Drawing.Color.Maroon;
			this.btnDel.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDel.ForeColor = System.Drawing.Color.White;
			this.btnDel.Location = new System.Drawing.Point(169, 3);
			this.btnDel.Name = "btnDel";
			this.btnDel.Size = new System.Drawing.Size(80, 24);
			this.btnDel.TabIndex = 2;
			this.btnDel.TabStop = false;
			this.btnDel.Text = "Del";
			this.btnDel.UseVisualStyleBackColor = false;
			this.btnDel.Click += new System.EventHandler(this.action_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAdd.BackColor = System.Drawing.Color.Maroon;
			this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
			this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAdd.ForeColor = System.Drawing.Color.White;
			this.btnAdd.Location = new System.Drawing.Point(3, 3);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(80, 24);
			this.btnAdd.TabIndex = 0;
			this.btnAdd.TabStop = false;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = false;
			this.btnAdd.Click += new System.EventHandler(this.action_Click);
			// 
			// lblTitle
			// 
			this.lblTitle.BackColor = System.Drawing.Color.Black;
			this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lblTitle.ForeColor = System.Drawing.Color.White;
			this.lblTitle.Location = new System.Drawing.Point(0, 0);
			this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
			this.lblTitle.Size = new System.Drawing.Size(456, 30);
			this.lblTitle.TabIndex = 4;
			this.lblTitle.Text = "<title>";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// contMenuGrid
			// 
			this.contMenuGrid.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.contMenuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miGridAdd,
            this.miGridEdit,
            this.miGridDel,
            this.miGridSep1,
            this.miGridRefresh,
            this.miGridSep2,
            this.miGridFilter});
			this.contMenuGrid.Name = "contMenuGrid";
			this.contMenuGrid.Size = new System.Drawing.Size(141, 126);
			// 
			// miGridAdd
			// 
			this.miGridAdd.Name = "miGridAdd";
			this.miGridAdd.ShortcutKeys = System.Windows.Forms.Keys.Insert;
			this.miGridAdd.Size = new System.Drawing.Size(140, 22);
			this.miGridAdd.Text = "Add";
			this.miGridAdd.Click += new System.EventHandler(this.action_Click);
			// 
			// miGridEdit
			// 
			this.miGridEdit.Name = "miGridEdit";
			this.miGridEdit.ShortcutKeyDisplayString = "Enter";
			this.miGridEdit.Size = new System.Drawing.Size(140, 22);
			this.miGridEdit.Text = "Edit";
			this.miGridEdit.Click += new System.EventHandler(this.action_Click);
			// 
			// miGridDel
			// 
			this.miGridDel.Name = "miGridDel";
			this.miGridDel.ShortcutKeys = System.Windows.Forms.Keys.Delete;
			this.miGridDel.Size = new System.Drawing.Size(140, 22);
			this.miGridDel.Text = "Delete";
			this.miGridDel.Click += new System.EventHandler(this.action_Click);
			// 
			// miGridSep1
			// 
			this.miGridSep1.Name = "miGridSep1";
			this.miGridSep1.Size = new System.Drawing.Size(137, 6);
			// 
			// miGridRefresh
			// 
			this.miGridRefresh.Name = "miGridRefresh";
			this.miGridRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
			this.miGridRefresh.Size = new System.Drawing.Size(140, 22);
			this.miGridRefresh.Text = "Refresh";
			this.miGridRefresh.Click += new System.EventHandler(this.action_Click);
			// 
			// miGridSep2
			// 
			this.miGridSep2.Name = "miGridSep2";
			this.miGridSep2.Size = new System.Drawing.Size(137, 6);
			// 
			// miGridFilter
			// 
			this.miGridFilter.Name = "miGridFilter";
			this.miGridFilter.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
			this.miGridFilter.Size = new System.Drawing.Size(140, 22);
			this.miGridFilter.Text = "Filter";
			this.miGridFilter.Click += new System.EventHandler(this.action_Click);
			// 
			// dgView
			// 
			this.dgView.AllowUserToAddRows = false;
			this.dgView.AllowUserToDeleteRows = false;
			this.dgView.AllowUserToOrderColumns = true;
			this.dgView.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.dgView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgView.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dgView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgView.Location = new System.Drawing.Point(0, 30);
			this.dgView.MultiSelect = false;
			this.dgView.Name = "dgView";
			this.dgView.ReadOnly = true;
			this.dgView.RowHeadersVisible = false;
			this.dgView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgView.Size = new System.Drawing.Size(456, 270);
			this.dgView.TabIndex = 0;
			this.dgView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgView_CellDoubleClick);
			this.dgView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgView_ColumnHeaderMouseClick);
			this.dgView.SelectionChanged += new System.EventHandler(this.dgView_SelectionChanged);
			// 
			// tbSearch
			// 
			this.tbSearch.BackColor = System.Drawing.SystemColors.Info;
			this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.tbSearch.Location = new System.Drawing.Point(4, 36);
			this.tbSearch.Name = "tbSearch";
			this.tbSearch.Size = new System.Drawing.Size(162, 22);
			this.tbSearch.TabIndex = 1;
			this.tbSearch.Visible = false;
			this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
			this.tbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyDown);
			this.tbSearch.LostFocus += new System.EventHandler(this.tbSearch_LostFocus);
			// 
			// BaseView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tbSearch);
			this.Controls.Add(this.dgView);
			this.Controls.Add(this.panelHeader);
			this.Name = "BaseView";
			this.Size = new System.Drawing.Size(456, 300);
			this.Load += new System.EventHandler(this.BaseView_Load);
			this.panelHeader.ResumeLayout(false);
			this.contMenuGrid.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.ToolStripMenuItem miGridAdd;
        private System.Windows.Forms.ToolStripMenuItem miGridEdit;
        private System.Windows.Forms.ToolStripMenuItem miGridDel;
        private System.Windows.Forms.ToolStripSeparator miGridSep1;
        private System.Windows.Forms.ToolStripMenuItem miGridRefresh;
        private System.Windows.Forms.ToolStripSeparator miGridSep2;
        private System.Windows.Forms.ToolStripMenuItem miGridFilter;
        protected System.Windows.Forms.ContextMenuStrip contMenuGrid;
        protected System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnFilter;
        internal System.Windows.Forms.DataGridView dgView;
        internal System.Windows.Forms.TextBox tbSearch;
    }
}
