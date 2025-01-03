namespace Smart3DSpecWriter.SpecTask
{
    partial class CtlSheetCategory
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
            this.comboCategory = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgSheetList = new System.Windows.Forms.DataGridView();
            this.Exist = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DisplayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SheetName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSheetList)).BeginInit();
            this.SuspendLayout();
            // 
            // comboCategory
            // 
            this.comboCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboCategory.FormattingEnabled = true;
            this.comboCategory.Location = new System.Drawing.Point(6, 35);
            this.comboCategory.Name = "comboCategory";
            this.comboCategory.Size = new System.Drawing.Size(538, 28);
            this.comboCategory.TabIndex = 0;
            this.comboCategory.SelectedIndexChanged += new System.EventHandler(this.comboCategory_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.comboCategory);
            this.groupBox1.Location = new System.Drawing.Point(13, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 87);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Task";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgSheetList);
            this.groupBox2.Location = new System.Drawing.Point(13, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(550, 969);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Related Sheets";
            // 
            // dgSheetList
            // 
            this.dgSheetList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgSheetList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgSheetList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSheetList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Exist,
            this.DisplayName,
            this.SheetName});
            this.dgSheetList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgSheetList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgSheetList.Location = new System.Drawing.Point(3, 22);
            this.dgSheetList.MultiSelect = false;
            this.dgSheetList.Name = "dgSheetList";
            this.dgSheetList.RowHeadersVisible = false;
            this.dgSheetList.RowHeadersWidth = 62;
            this.dgSheetList.RowTemplate.Height = 28;
            this.dgSheetList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSheetList.Size = new System.Drawing.Size(544, 944);
            this.dgSheetList.TabIndex = 0;
            this.dgSheetList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSheetList_CellDoubleClick);
            // 
            // Exist
            // 
            this.Exist.DataPropertyName = "Exist";
            this.Exist.HeaderText = "Exist";
            this.Exist.MinimumWidth = 8;
            this.Exist.Name = "Exist";
            this.Exist.ReadOnly = true;
            this.Exist.Width = 49;
            // 
            // DisplayName
            // 
            this.DisplayName.DataPropertyName = "DisplayName";
            this.DisplayName.HeaderText = "Display Name";
            this.DisplayName.MinimumWidth = 8;
            this.DisplayName.Name = "DisplayName";
            this.DisplayName.ReadOnly = true;
            this.DisplayName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DisplayName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DisplayName.Width = 112;
            // 
            // SheetName
            // 
            this.SheetName.DataPropertyName = "SheetName";
            this.SheetName.HeaderText = "Sheet Name";
            this.SheetName.MinimumWidth = 8;
            this.SheetName.Name = "SheetName";
            this.SheetName.ReadOnly = true;
            this.SheetName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SheetName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SheetName.Width = 104;
            // 
            // CtlSheetCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "CtlSheetCategory";
            this.Size = new System.Drawing.Size(579, 1114);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSheetList)).EndInit();
            this.ResumeLayout(false);
            
        }

        #endregion

        private System.Windows.Forms.ComboBox comboCategory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgSheetList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Exist;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SheetName;
    }
}
