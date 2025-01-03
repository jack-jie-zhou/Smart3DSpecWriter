namespace Smart3DSpecWriter
{
    partial class BrowserControl
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabData = new System.Windows.Forms.TabPage();
            this.detailDataGridView1 = new Smart3DSpecWriter.Controls.DetailDataGridView();
            this.tabDef = new System.Windows.Forms.TabPage();
            this.definitionDataGridView1 = new Smart3DSpecWriter.Controls.DefinitionDataGridView();
            this.tabSheet = new System.Windows.Forms.TabPage();
            this.bnSheetlistFilterClear = new System.Windows.Forms.Button();
            this.bnSheetlistFilterApple = new System.Windows.Forms.Button();
            this.txtSheetListFilter = new System.Windows.Forms.TextBox();
            this.lstSheetNameList = new System.Windows.Forms.ListBox();
            this.tabSheetCategory = new System.Windows.Forms.TabPage();
            this.tabPageBranchTable = new System.Windows.Forms.TabPage();
            this.contextMenuStripBrowser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.wideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regularToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.narrowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctlSheetCategory1 = new Smart3DSpecWriter.SpecTask.CtlSheetCategory();
            this.tabControl1.SuspendLayout();
            this.tabData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailDataGridView1)).BeginInit();
            this.tabDef.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.definitionDataGridView1)).BeginInit();
            this.tabSheet.SuspendLayout();
            this.tabSheetCategory.SuspendLayout();
            this.contextMenuStripBrowser.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabData);
            this.tabControl1.Controls.Add(this.tabDef);
            this.tabControl1.Controls.Add(this.tabSheet);
            this.tabControl1.Controls.Add(this.tabSheetCategory);
            this.tabControl1.Controls.Add(this.tabPageBranchTable);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(760, 1265);
            this.tabControl1.TabIndex = 0;
            // 
            // tabData
            // 
            this.tabData.Controls.Add(this.detailDataGridView1);
            this.tabData.Location = new System.Drawing.Point(4, 29);
            this.tabData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabData.Name = "tabData";
            this.tabData.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabData.Size = new System.Drawing.Size(752, 1232);
            this.tabData.TabIndex = 0;
            this.tabData.Text = "Data";
            this.tabData.ToolTipText = "Detail";
            this.tabData.UseVisualStyleBackColor = true;
            // 
            // detailDataGridView1
            // 
            this.detailDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.detailDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailDataGridView1.Location = new System.Drawing.Point(4, 5);
            this.detailDataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.detailDataGridView1.Name = "detailDataGridView1";
            this.detailDataGridView1.RowHeadersWidth = 62;
            this.detailDataGridView1.Size = new System.Drawing.Size(744, 1222);
            this.detailDataGridView1.TabIndex = 0;
            // 
            // tabDef
            // 
            this.tabDef.Controls.Add(this.definitionDataGridView1);
            this.tabDef.Location = new System.Drawing.Point(4, 29);
            this.tabDef.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabDef.Name = "tabDef";
            this.tabDef.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabDef.Size = new System.Drawing.Size(752, 1232);
            this.tabDef.TabIndex = 1;
            this.tabDef.Text = "Def";
            this.tabDef.ToolTipText = "Definition";
            this.tabDef.UseVisualStyleBackColor = true;
            // 
            // definitionDataGridView1
            // 
            this.definitionDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.definitionDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.definitionDataGridView1.Location = new System.Drawing.Point(4, 5);
            this.definitionDataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.definitionDataGridView1.Name = "definitionDataGridView1";
            this.definitionDataGridView1.RowHeadersWidth = 62;
            this.definitionDataGridView1.Size = new System.Drawing.Size(744, 1222);
            this.definitionDataGridView1.TabIndex = 0;
            // 
            // tabSheet
            // 
            this.tabSheet.Controls.Add(this.bnSheetlistFilterClear);
            this.tabSheet.Controls.Add(this.bnSheetlistFilterApple);
            this.tabSheet.Controls.Add(this.txtSheetListFilter);
            this.tabSheet.Controls.Add(this.lstSheetNameList);
            this.tabSheet.Location = new System.Drawing.Point(4, 29);
            this.tabSheet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabSheet.Name = "tabSheet";
            this.tabSheet.Size = new System.Drawing.Size(752, 1232);
            this.tabSheet.TabIndex = 2;
            this.tabSheet.Text = "Sheets";
            this.tabSheet.ToolTipText = "Excel Sheets";
            this.tabSheet.UseVisualStyleBackColor = true;
            // 
            // bnSheetlistFilterClear
            // 
            this.bnSheetlistFilterClear.Location = new System.Drawing.Point(269, 18);
            this.bnSheetlistFilterClear.Name = "bnSheetlistFilterClear";
            this.bnSheetlistFilterClear.Size = new System.Drawing.Size(88, 34);
            this.bnSheetlistFilterClear.TabIndex = 3;
            this.bnSheetlistFilterClear.Text = "Clear";
            this.bnSheetlistFilterClear.UseVisualStyleBackColor = true;
            this.bnSheetlistFilterClear.Click += new System.EventHandler(this.bnSheetlistFilterClear_Click);
            // 
            // bnSheetlistFilterApple
            // 
            this.bnSheetlistFilterApple.Location = new System.Drawing.Point(153, 17);
            this.bnSheetlistFilterApple.Name = "bnSheetlistFilterApple";
            this.bnSheetlistFilterApple.Size = new System.Drawing.Size(99, 36);
            this.bnSheetlistFilterApple.TabIndex = 2;
            this.bnSheetlistFilterApple.Text = "Filter";
            this.bnSheetlistFilterApple.UseVisualStyleBackColor = true;
            this.bnSheetlistFilterApple.Click += new System.EventHandler(this.bnSheetlistFilterApple_Click);
            // 
            // txtSheetListFilter
            // 
            this.txtSheetListFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSheetListFilter.Location = new System.Drawing.Point(17, 20);
            this.txtSheetListFilter.Name = "txtSheetListFilter";
            this.txtSheetListFilter.Size = new System.Drawing.Size(112, 30);
            this.txtSheetListFilter.TabIndex = 1;
            this.txtSheetListFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSheetListFilter_KeyDown);
            // 
            // lstSheetNameList
            // 
            this.lstSheetNameList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSheetNameList.FormattingEnabled = true;
            this.lstSheetNameList.ItemHeight = 20;
            this.lstSheetNameList.Location = new System.Drawing.Point(0, 60);
            this.lstSheetNameList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstSheetNameList.Name = "lstSheetNameList";
            this.lstSheetNameList.Size = new System.Drawing.Size(746, 1144);
            this.lstSheetNameList.TabIndex = 0;
            this.lstSheetNameList.SelectedIndexChanged += new System.EventHandler(this.lstSheetNameList_SelectedIndexChanged);
            // 
            // tabSheetCategory
            // 
            this.tabSheetCategory.Controls.Add(this.ctlSheetCategory1);
            this.tabSheetCategory.Location = new System.Drawing.Point(4, 29);
            this.tabSheetCategory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabSheetCategory.Name = "tabSheetCategory";
            this.tabSheetCategory.Size = new System.Drawing.Size(752, 1232);
            this.tabSheetCategory.TabIndex = 3;
            this.tabSheetCategory.Text = "SC";
            this.tabSheetCategory.ToolTipText = "Shett Categories";
            this.tabSheetCategory.UseVisualStyleBackColor = true;
            // 
            // tabPageBranchTable
            // 
            this.tabPageBranchTable.Location = new System.Drawing.Point(4, 29);
            this.tabPageBranchTable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPageBranchTable.Name = "tabPageBranchTable";
            this.tabPageBranchTable.Size = new System.Drawing.Size(752, 1232);
            this.tabPageBranchTable.TabIndex = 4;
            this.tabPageBranchTable.Text = "BR";
            this.tabPageBranchTable.ToolTipText = "Pipe Branch Table";
            this.tabPageBranchTable.UseVisualStyleBackColor = true;
            // 
            // contextMenuStripBrowser
            // 
            this.contextMenuStripBrowser.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripBrowser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wideToolStripMenuItem,
            this.regularToolStripMenuItem,
            this.narrowToolStripMenuItem});
            this.contextMenuStripBrowser.Name = "contextMenuStripBrowser";
            this.contextMenuStripBrowser.Size = new System.Drawing.Size(144, 100);
            // 
            // wideToolStripMenuItem
            // 
            this.wideToolStripMenuItem.Name = "wideToolStripMenuItem";
            this.wideToolStripMenuItem.Size = new System.Drawing.Size(143, 32);
            this.wideToolStripMenuItem.Text = "Wide";
            this.wideToolStripMenuItem.Click += new System.EventHandler(this.wideToolStripMenuItem_Click);
            // 
            // regularToolStripMenuItem
            // 
            this.regularToolStripMenuItem.Name = "regularToolStripMenuItem";
            this.regularToolStripMenuItem.Size = new System.Drawing.Size(143, 32);
            this.regularToolStripMenuItem.Text = "Regular";
            this.regularToolStripMenuItem.Click += new System.EventHandler(this.regularToolStripMenuItem_Click);
            // 
            // narrowToolStripMenuItem
            // 
            this.narrowToolStripMenuItem.Name = "narrowToolStripMenuItem";
            this.narrowToolStripMenuItem.Size = new System.Drawing.Size(143, 32);
            this.narrowToolStripMenuItem.Text = "Narrow";
            this.narrowToolStripMenuItem.Click += new System.EventHandler(this.narrowToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // ctlSheetCategory1
            // 
            this.ctlSheetCategory1.BackColor = System.Drawing.Color.LightBlue;
            this.ctlSheetCategory1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlSheetCategory1.Location = new System.Drawing.Point(0, 0);
            this.ctlSheetCategory1.Name = "ctlSheetCategory1";
            this.ctlSheetCategory1.Size = new System.Drawing.Size(752, 1232);
            this.ctlSheetCategory1.TabIndex = 0;
            // 
            // BrowserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.contextMenuStripBrowser;
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BrowserControl";
            this.Size = new System.Drawing.Size(760, 1265);
            this.tabControl1.ResumeLayout(false);
            this.tabData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.detailDataGridView1)).EndInit();
            this.tabDef.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.definitionDataGridView1)).EndInit();
            this.tabSheet.ResumeLayout(false);
            this.tabSheet.PerformLayout();
            this.tabSheetCategory.ResumeLayout(false);
            this.contextMenuStripBrowser.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabData;
        private System.Windows.Forms.TabPage tabDef;
        private System.Windows.Forms.TabPage tabSheet;
        private System.Windows.Forms.TabPage tabSheetCategory;
        private System.Windows.Forms.ListBox lstSheetNameList;
        private Controls.DetailDataGridView detailDataGridView1;
        private Controls.DefinitionDataGridView definitionDataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripBrowser;
        private System.Windows.Forms.ToolStripMenuItem wideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regularToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem narrowToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPageBranchTable;
        private System.Windows.Forms.Button bnSheetlistFilterClear;
        private System.Windows.Forms.Button bnSheetlistFilterApple;
        private System.Windows.Forms.TextBox txtSheetListFilter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private SpecTask.CtlSheetCategory ctlSheetCategory1;
    }
}
