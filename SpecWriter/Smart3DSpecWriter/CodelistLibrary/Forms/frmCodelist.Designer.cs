namespace CodelistLibrary
{
    partial class frmCodelist
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
            this.dgTableValueList = new System.Windows.Forms.DataGridView();
            this.dgCurrentTable = new System.Windows.Forms.DataGridView();
            this.bnRestore = new System.Windows.Forms.Button();
            this.bnOK = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.groupBoxTop = new System.Windows.Forms.GroupBox();
            this.groupBoxBottom = new System.Windows.Forms.GroupBox();
            this.txtValuesFilter = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.bnFilter = new System.Windows.Forms.Button();
            this.bnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgTableValueList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCurrentTable)).BeginInit();
            this.groupBoxTop.SuspendLayout();
            this.groupBoxBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgTableValueList
            // 
            this.dgTableValueList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgTableValueList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTableValueList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTableValueList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgTableValueList.Location = new System.Drawing.Point(3, 22);
            this.dgTableValueList.MultiSelect = false;
            this.dgTableValueList.Name = "dgTableValueList";
            this.dgTableValueList.RowHeadersVisible = false;
            this.dgTableValueList.RowHeadersWidth = 62;
            this.dgTableValueList.RowTemplate.Height = 28;
            this.dgTableValueList.Size = new System.Drawing.Size(1225, 380);
            this.dgTableValueList.TabIndex = 0;
            this.dgTableValueList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTableValueList_CellClick);
            // 
            // dgCurrentTable
            // 
            this.dgCurrentTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgCurrentTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCurrentTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCurrentTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgCurrentTable.Location = new System.Drawing.Point(3, 22);
            this.dgCurrentTable.MultiSelect = false;
            this.dgCurrentTable.Name = "dgCurrentTable";
            this.dgCurrentTable.RowHeadersVisible = false;
            this.dgCurrentTable.RowHeadersWidth = 62;
            this.dgCurrentTable.RowTemplate.Height = 28;
            this.dgCurrentTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCurrentTable.Size = new System.Drawing.Size(1222, 331);
            this.dgCurrentTable.TabIndex = 1;
            this.dgCurrentTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCurrentTable_CellClick);
            // 
            // bnRestore
            // 
            this.bnRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bnRestore.Location = new System.Drawing.Point(916, 809);
            this.bnRestore.Name = "bnRestore";
            this.bnRestore.Size = new System.Drawing.Size(96, 42);
            this.bnRestore.TabIndex = 2;
            this.bnRestore.Text = "Restore";
            this.bnRestore.UseVisualStyleBackColor = true;
            this.bnRestore.Click += new System.EventHandler(this.bnRestore_Click);
            // 
            // bnOK
            // 
            this.bnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bnOK.Location = new System.Drawing.Point(1030, 809);
            this.bnOK.Name = "bnOK";
            this.bnOK.Size = new System.Drawing.Size(96, 42);
            this.bnOK.TabIndex = 3;
            this.bnOK.Text = "OK";
            this.bnOK.UseVisualStyleBackColor = true;
            // 
            // bnCancel
            // 
            this.bnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bnCancel.Location = new System.Drawing.Point(1144, 809);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(96, 42);
            this.bnCancel.TabIndex = 4;
            this.bnCancel.Text = "Cancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // groupBoxTop
            // 
            this.groupBoxTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTop.Controls.Add(this.dgTableValueList);
            this.groupBoxTop.Location = new System.Drawing.Point(12, 12);
            this.groupBoxTop.Name = "groupBoxTop";
            this.groupBoxTop.Size = new System.Drawing.Size(1231, 405);
            this.groupBoxTop.TabIndex = 5;
            this.groupBoxTop.TabStop = false;
            // 
            // groupBoxBottom
            // 
            this.groupBoxBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxBottom.Controls.Add(this.dgCurrentTable);
            this.groupBoxBottom.Location = new System.Drawing.Point(15, 432);
            this.groupBoxBottom.Name = "groupBoxBottom";
            this.groupBoxBottom.Size = new System.Drawing.Size(1228, 356);
            this.groupBoxBottom.TabIndex = 6;
            this.groupBoxBottom.TabStop = false;
            // 
            // txtValuesFilter
            // 
            this.txtValuesFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtValuesFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValuesFilter.Location = new System.Drawing.Point(50, 813);
            this.txtValuesFilter.Name = "txtValuesFilter";
            this.txtValuesFilter.Size = new System.Drawing.Size(100, 30);
            this.txtValuesFilter.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(916, 809);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 42);
            this.button2.TabIndex = 2;
            this.button2.Text = "Restore";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.bnRestore_Click);
            // 
            // bnFilter
            // 
            this.bnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bnFilter.Location = new System.Drawing.Point(183, 809);
            this.bnFilter.Name = "bnFilter";
            this.bnFilter.Size = new System.Drawing.Size(96, 42);
            this.bnFilter.TabIndex = 8;
            this.bnFilter.Text = "Filter";
            this.bnFilter.UseVisualStyleBackColor = true;
            this.bnFilter.Click += new System.EventHandler(this.bnFilter_Click);
            // 
            // bnReset
            // 
            this.bnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bnReset.Location = new System.Drawing.Point(296, 809);
            this.bnReset.Name = "bnReset";
            this.bnReset.Size = new System.Drawing.Size(96, 42);
            this.bnReset.TabIndex = 9;
            this.bnReset.Text = "Reset";
            this.bnReset.UseVisualStyleBackColor = true;
            this.bnReset.Click += new System.EventHandler(this.bnReset_Click);
            // 
            // frmCodelist
            // 
            this.AcceptButton = this.bnFilter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.ClientSize = new System.Drawing.Size(1254, 868);
            this.Controls.Add(this.bnReset);
            this.Controls.Add(this.bnFilter);
            this.Controls.Add(this.txtValuesFilter);
            this.Controls.Add(this.groupBoxBottom);
            this.Controls.Add(this.groupBoxTop);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnOK);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.bnRestore);
            this.KeyPreview = true;
            this.Name = "frmCodelist";
            this.Text = "frmCodelist";
            ((System.ComponentModel.ISupportInitialize)(this.dgTableValueList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCurrentTable)).EndInit();
            this.groupBoxTop.ResumeLayout(false);
            this.groupBoxBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgTableValueList;
        private System.Windows.Forms.DataGridView dgCurrentTable;
        private System.Windows.Forms.Button bnRestore;
        private System.Windows.Forms.Button bnOK;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.GroupBox groupBoxTop;
        private System.Windows.Forms.GroupBox groupBoxBottom;
        private System.Windows.Forms.TextBox txtValuesFilter;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button bnFilter;
        private System.Windows.Forms.Button bnReset;
    }
}