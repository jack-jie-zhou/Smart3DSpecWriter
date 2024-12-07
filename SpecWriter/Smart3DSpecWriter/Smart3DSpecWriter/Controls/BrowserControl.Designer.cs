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
            this.lstSheetNameList = new System.Windows.Forms.ListBox();
            this.tabSheetCategory = new System.Windows.Forms.TabPage();
            this.contextMenuStripBrowser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.wideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regularToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.narrowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageBranchTable = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailDataGridView1)).BeginInit();
            this.tabDef.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.definitionDataGridView1)).BeginInit();
            this.tabSheet.SuspendLayout();
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
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(507, 822);
            this.tabControl1.TabIndex = 0;
            // 
            // tabData
            // 
            this.tabData.Controls.Add(this.detailDataGridView1);
            this.tabData.Location = new System.Drawing.Point(4, 22);
            this.tabData.Name = "tabData";
            this.tabData.Padding = new System.Windows.Forms.Padding(3);
            this.tabData.Size = new System.Drawing.Size(499, 796);
            this.tabData.TabIndex = 0;
            this.tabData.Text = "Data";
            this.tabData.ToolTipText = "Detail";
            this.tabData.UseVisualStyleBackColor = true;
            // 
            // detailDataGridView1
            // 
            this.detailDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.detailDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailDataGridView1.Location = new System.Drawing.Point(3, 3);
            this.detailDataGridView1.Name = "detailDataGridView1";
            this.detailDataGridView1.Size = new System.Drawing.Size(493, 790);
            this.detailDataGridView1.TabIndex = 0;
            // 
            // tabDef
            // 
            this.tabDef.Controls.Add(this.definitionDataGridView1);
            this.tabDef.Location = new System.Drawing.Point(4, 22);
            this.tabDef.Name = "tabDef";
            this.tabDef.Padding = new System.Windows.Forms.Padding(3);
            this.tabDef.Size = new System.Drawing.Size(499, 796);
            this.tabDef.TabIndex = 1;
            this.tabDef.Text = "Def";
            this.tabDef.ToolTipText = "Definition";
            this.tabDef.UseVisualStyleBackColor = true;
            // 
            // definitionDataGridView1
            // 
            this.definitionDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.definitionDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.definitionDataGridView1.Location = new System.Drawing.Point(3, 3);
            this.definitionDataGridView1.Name = "definitionDataGridView1";
            this.definitionDataGridView1.Size = new System.Drawing.Size(493, 790);
            this.definitionDataGridView1.TabIndex = 0;
            // 
            // tabSheet
            // 
            this.tabSheet.Controls.Add(this.lstSheetNameList);
            this.tabSheet.Location = new System.Drawing.Point(4, 22);
            this.tabSheet.Name = "tabSheet";
            this.tabSheet.Size = new System.Drawing.Size(499, 796);
            this.tabSheet.TabIndex = 2;
            this.tabSheet.Text = "Sheets";
            this.tabSheet.ToolTipText = "Excel Sheets";
            this.tabSheet.UseVisualStyleBackColor = true;
            // 
            // lstSheetNameList
            // 
            this.lstSheetNameList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSheetNameList.FormattingEnabled = true;
            this.lstSheetNameList.Location = new System.Drawing.Point(0, 0);
            this.lstSheetNameList.Name = "lstSheetNameList";
            this.lstSheetNameList.Size = new System.Drawing.Size(499, 796);
            this.lstSheetNameList.TabIndex = 0;
            this.lstSheetNameList.SelectedIndexChanged += new System.EventHandler(this.lstSheetNameList_SelectedIndexChanged);
            // 
            // tabSheetCategory
            // 
            this.tabSheetCategory.Location = new System.Drawing.Point(4, 22);
            this.tabSheetCategory.Name = "tabSheetCategory";
            this.tabSheetCategory.Size = new System.Drawing.Size(499, 796);
            this.tabSheetCategory.TabIndex = 3;
            this.tabSheetCategory.Text = "SC";
            this.tabSheetCategory.ToolTipText = "Shett Categories";
            this.tabSheetCategory.UseVisualStyleBackColor = true;
            // 
            // contextMenuStripBrowser
            // 
            this.contextMenuStripBrowser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wideToolStripMenuItem,
            this.regularToolStripMenuItem,
            this.narrowToolStripMenuItem});
            this.contextMenuStripBrowser.Name = "contextMenuStripBrowser";
            this.contextMenuStripBrowser.Size = new System.Drawing.Size(115, 70);
            // 
            // wideToolStripMenuItem
            // 
            this.wideToolStripMenuItem.Name = "wideToolStripMenuItem";
            this.wideToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.wideToolStripMenuItem.Text = "Wide";
            this.wideToolStripMenuItem.Click += new System.EventHandler(this.wideToolStripMenuItem_Click);
            // 
            // regularToolStripMenuItem
            // 
            this.regularToolStripMenuItem.Name = "regularToolStripMenuItem";
            this.regularToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.regularToolStripMenuItem.Text = "Regular";
            this.regularToolStripMenuItem.Click += new System.EventHandler(this.regularToolStripMenuItem_Click);
            // 
            // narrowToolStripMenuItem
            // 
            this.narrowToolStripMenuItem.Name = "narrowToolStripMenuItem";
            this.narrowToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.narrowToolStripMenuItem.Text = "Narrow";
            this.narrowToolStripMenuItem.Click += new System.EventHandler(this.narrowToolStripMenuItem_Click);
            // 
            // tabPageBranchTable
            // 
            this.tabPageBranchTable.Location = new System.Drawing.Point(4, 22);
            this.tabPageBranchTable.Name = "tabPageBranchTable";
            this.tabPageBranchTable.Size = new System.Drawing.Size(499, 796);
            this.tabPageBranchTable.TabIndex = 4;
            this.tabPageBranchTable.Text = "BR";
            this.tabPageBranchTable.ToolTipText = "Pipe Branch Table";
            this.tabPageBranchTable.UseVisualStyleBackColor = true;
            // 
            // BrowserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.contextMenuStripBrowser;
            this.Controls.Add(this.tabControl1);
            this.Name = "BrowserControl";
            this.Size = new System.Drawing.Size(507, 822);
            this.tabControl1.ResumeLayout(false);
            this.tabData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.detailDataGridView1)).EndInit();
            this.tabDef.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.definitionDataGridView1)).EndInit();
            this.tabSheet.ResumeLayout(false);
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
    }
}
