namespace WindowsFormsTestApp
{
    partial class Form1
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
            this.bnDBConnTest = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.bnSearch = new System.Windows.Forms.Button();
            this.dg1 = new System.Windows.Forms.DataGridView();
            this.bnOpenSearchForm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg1)).BeginInit();
            this.SuspendLayout();
            // 
            // bnDBConnTest
            // 
            this.bnDBConnTest.Location = new System.Drawing.Point(53, 37);
            this.bnDBConnTest.Name = "bnDBConnTest";
            this.bnDBConnTest.Size = new System.Drawing.Size(281, 47);
            this.bnDBConnTest.TabIndex = 0;
            this.bnDBConnTest.Text = "Test Database Connection";
            this.bnDBConnTest.UseVisualStyleBackColor = true;
            this.bnDBConnTest.Click += new System.EventHandler(this.bnDBConnTest_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(493, 37);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(420, 30);
            this.txtSearch.TabIndex = 2;
            // 
            // bnSearch
            // 
            this.bnSearch.Location = new System.Drawing.Point(935, 32);
            this.bnSearch.Name = "bnSearch";
            this.bnSearch.Size = new System.Drawing.Size(116, 45);
            this.bnSearch.TabIndex = 3;
            this.bnSearch.Text = "查找";
            this.bnSearch.UseVisualStyleBackColor = true;
            this.bnSearch.Click += new System.EventHandler(this.bnSearch_Click);
            // 
            // dg1
            // 
            this.dg1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dg1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg1.Location = new System.Drawing.Point(387, 100);
            this.dg1.Name = "dg1";
            this.dg1.RowHeadersWidth = 62;
            this.dg1.RowTemplate.Height = 28;
            this.dg1.Size = new System.Drawing.Size(1044, 1142);
            this.dg1.TabIndex = 4;
            this.dg1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg1_CellClick);
            this.dg1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg1_CellContentClick);
            // 
            // bnOpenSearchForm
            // 
            this.bnOpenSearchForm.Location = new System.Drawing.Point(72, 137);
            this.bnOpenSearchForm.Name = "bnOpenSearchForm";
            this.bnOpenSearchForm.Size = new System.Drawing.Size(205, 45);
            this.bnOpenSearchForm.TabIndex = 5;
            this.bnOpenSearchForm.Text = "Open Global Search Form";
            this.bnOpenSearchForm.UseVisualStyleBackColor = true;
            this.bnOpenSearchForm.Click += new System.EventHandler(this.bnOpenSearchForm_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.bnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1533, 1270);
            this.Controls.Add(this.bnOpenSearchForm);
            this.Controls.Add(this.dg1);
            this.Controls.Add(this.bnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.bnDBConnTest);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnDBConnTest;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button bnSearch;
        private System.Windows.Forms.DataGridView dg1;
        private System.Windows.Forms.Button bnOpenSearchForm;
    }
}

