namespace CodelistUserControl
{
    partial class CodelistUserControl
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
            this.dgTableValueList = new System.Windows.Forms.DataGridView();
            this.dgCurrentTable = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.txtValuesFilter = new System.Windows.Forms.TextBox();
            this.bnCancel = new System.Windows.Forms.Button();
            this.bnOK = new System.Windows.Forms.Button();
            this.bnRestore = new System.Windows.Forms.Button();
            this.bnFilter = new System.Windows.Forms.Button();
            this.bnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgTableValueList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCurrentTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgTableValueList
            // 
            this.dgTableValueList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgTableValueList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTableValueList.Location = new System.Drawing.Point(15, 14);
            this.dgTableValueList.Name = "dgTableValueList";
            this.dgTableValueList.RowHeadersWidth = 62;
            this.dgTableValueList.RowTemplate.Height = 28;
            this.dgTableValueList.Size = new System.Drawing.Size(1080, 433);
            this.dgTableValueList.TabIndex = 0;
            this.dgTableValueList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTableValueList_CellClick);
            // 
            // dgCurrentTable
            // 
            this.dgCurrentTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgCurrentTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCurrentTable.Location = new System.Drawing.Point(15, 469);
            this.dgCurrentTable.Name = "dgCurrentTable";
            this.dgCurrentTable.RowHeadersWidth = 62;
            this.dgCurrentTable.RowTemplate.Height = 28;
            this.dgCurrentTable.Size = new System.Drawing.Size(1080, 409);
            this.dgCurrentTable.TabIndex = 1;
            this.dgCurrentTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCurrentTable_CellClick);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(170, 553);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 62;
            this.dataGridView2.RowTemplate.Height = 28;
            this.dataGridView2.Size = new System.Drawing.Size(8, 8);
            this.dataGridView2.TabIndex = 2;
            // 
            // txtValuesFilter
            // 
            this.txtValuesFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtValuesFilter.Location = new System.Drawing.Point(15, 902);
            this.txtValuesFilter.Name = "txtValuesFilter";
            this.txtValuesFilter.Size = new System.Drawing.Size(100, 26);
            this.txtValuesFilter.TabIndex = 3;
            // 
            // bnCancel
            // 
            this.bnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bnCancel.Location = new System.Drawing.Point(1022, 898);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(75, 35);
            this.bnCancel.TabIndex = 4;
            this.bnCancel.Text = "Cancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // bnOK
            // 
            this.bnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bnOK.Location = new System.Drawing.Point(926, 898);
            this.bnOK.Name = "bnOK";
            this.bnOK.Size = new System.Drawing.Size(75, 35);
            this.bnOK.TabIndex = 5;
            this.bnOK.Text = "OK";
            this.bnOK.UseVisualStyleBackColor = true;
            // 
            // bnRestore
            // 
            this.bnRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bnRestore.Location = new System.Drawing.Point(830, 898);
            this.bnRestore.Name = "bnRestore";
            this.bnRestore.Size = new System.Drawing.Size(75, 35);
            this.bnRestore.TabIndex = 6;
            this.bnRestore.Text = "Restore";
            this.bnRestore.UseVisualStyleBackColor = true;
            this.bnRestore.Click += new System.EventHandler(this.bnRestore_Click);
            // 
            // bnFilter
            // 
            this.bnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bnFilter.Location = new System.Drawing.Point(145, 898);
            this.bnFilter.Name = "bnFilter";
            this.bnFilter.Size = new System.Drawing.Size(75, 35);
            this.bnFilter.TabIndex = 7;
            this.bnFilter.Text = "Filter";
            this.bnFilter.UseVisualStyleBackColor = true;
            this.bnFilter.Click += new System.EventHandler(this.bnFilter_Click);
            // 
            // bnReset
            // 
            this.bnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bnReset.Location = new System.Drawing.Point(244, 898);
            this.bnReset.Name = "bnReset";
            this.bnReset.Size = new System.Drawing.Size(75, 35);
            this.bnReset.TabIndex = 8;
            this.bnReset.Text = "Reset";
            this.bnReset.UseVisualStyleBackColor = true;
            this.bnReset.Click += new System.EventHandler(this.bnReset_Click);
            // 
            // CodelistUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.bnReset);
            this.Controls.Add(this.bnFilter);
            this.Controls.Add(this.bnRestore);
            this.Controls.Add(this.bnOK);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.txtValuesFilter);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dgCurrentTable);
            this.Controls.Add(this.dgTableValueList);
            this.Name = "CodelistUserControl";
            this.Size = new System.Drawing.Size(1116, 947);
            ((System.ComponentModel.ISupportInitialize)(this.dgTableValueList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgCurrentTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgTableValueList;
        private System.Windows.Forms.DataGridView dgCurrentTable;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox txtValuesFilter;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Button bnOK;
        private System.Windows.Forms.Button bnRestore;
        private System.Windows.Forms.Button bnFilter;
        private System.Windows.Forms.Button bnReset;
    }
}
