namespace Smart3DSpecWriter.Controls
{
    partial class DefinitionDataGridView
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
            this.contextMenuStripDefinition = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemDisplayIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripDefinition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStripDefinition
            // 
            this.contextMenuStripDefinition.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemDisplayIcon});
            this.contextMenuStripDefinition.Name = "contextMenuStripDefinition";
            this.contextMenuStripDefinition.Size = new System.Drawing.Size(139, 26);
            // 
            // toolStripMenuItemDisplayIcon
            // 
            this.toolStripMenuItemDisplayIcon.Name = "toolStripMenuItemDisplayIcon";
            this.toolStripMenuItemDisplayIcon.Size = new System.Drawing.Size(138, 22);
            this.toolStripMenuItemDisplayIcon.Text = "Display Icon";
            // 
            // DefinitionDataGridView
            // 
            this.ContextMenuStrip = this.contextMenuStripDefinition;
            this.contextMenuStripDefinition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStripDefinition;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDisplayIcon;
    }
}
