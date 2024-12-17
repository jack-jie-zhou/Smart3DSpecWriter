namespace Smart3DSpecWriter.Controls
{
    partial class DetailDataGridView
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
            this.contextMenuStripDetailDataGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemShortDesc = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLongDesc = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemHideEmpty = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemShowEmpty = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemDisplaySymbolIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripDetailDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStripDetailDataGrid
            // 
            this.contextMenuStripDetailDataGrid.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripDetailDataGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemUpdate,
            this.toolStripSeparator1,
            this.toolStripMenuItemShortDesc,
            this.toolStripMenuItemLongDesc,
            this.toolStripSeparator2,
            this.toolStripMenuItemHideEmpty,
            this.toolStripMenuItemShowEmpty,
            this.toolStripSeparator3,
            this.toolStripMenuItemDisplaySymbolIcon});
            this.contextMenuStripDetailDataGrid.Name = "contextMenuStrip1";
            this.contextMenuStripDetailDataGrid.Size = new System.Drawing.Size(247, 214);
            // 
            // toolStripMenuItemUpdate
            // 
            this.toolStripMenuItemUpdate.Name = "toolStripMenuItemUpdate";
            this.toolStripMenuItemUpdate.Size = new System.Drawing.Size(246, 32);
            this.toolStripMenuItemUpdate.Text = "Update";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(243, 6);
            // 
            // toolStripMenuItemShortDesc
            // 
            this.toolStripMenuItemShortDesc.Name = "toolStripMenuItemShortDesc";
            this.toolStripMenuItemShortDesc.Size = new System.Drawing.Size(246, 32);
            this.toolStripMenuItemShortDesc.Text = "Short Description";
            // 
            // toolStripMenuItemLongDesc
            // 
            this.toolStripMenuItemLongDesc.Name = "toolStripMenuItemLongDesc";
            this.toolStripMenuItemLongDesc.Size = new System.Drawing.Size(246, 32);
            this.toolStripMenuItemLongDesc.Text = "Long Description";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(243, 6);
            // 
            // toolStripMenuItemHideEmpty
            // 
            this.toolStripMenuItemHideEmpty.Name = "toolStripMenuItemHideEmpty";
            this.toolStripMenuItemHideEmpty.Size = new System.Drawing.Size(246, 32);
            this.toolStripMenuItemHideEmpty.Text = "Hide Empty Values";
            // 
            // toolStripMenuItemShowEmpty
            // 
            this.toolStripMenuItemShowEmpty.Name = "toolStripMenuItemShowEmpty";
            this.toolStripMenuItemShowEmpty.Size = new System.Drawing.Size(246, 32);
            this.toolStripMenuItemShowEmpty.Text = "Show Empty Values";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(243, 6);
            // 
            // toolStripMenuItemDisplaySymbolIcon
            // 
            this.toolStripMenuItemDisplaySymbolIcon.Name = "toolStripMenuItemDisplaySymbolIcon";
            this.toolStripMenuItemDisplaySymbolIcon.Size = new System.Drawing.Size(246, 32);
            this.toolStripMenuItemDisplaySymbolIcon.Text = "Display Symbol Icon";
            // 
            // DetailDataGridView
            // 
            this.ContextMenuStrip = this.contextMenuStripDetailDataGrid;
            this.RowTemplate.Height = 28;
            this.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DetailDataGridView_CellClick);
            this.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DetailDataGridView_CellDoubleClick);
            this.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.DetailDataGridView_CellToolTipTextNeeded);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DetailDataGridView_KeyUp);
            this.contextMenuStripDetailDataGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStripDetailDataGrid;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemUpdate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShortDesc;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLongDesc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHideEmpty;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowEmpty;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDisplaySymbolIcon;
    }
}
