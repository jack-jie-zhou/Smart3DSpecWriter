namespace Smart3DSpecWriter.Forms
{
    partial class frmGlobalSettings
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
            this.chkShowTooltip = new System.Windows.Forms.CheckBox();
            this.bnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bnSelectIconPath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIconPath = new System.Windows.Forms.TextBox();
            this.chkHighlightSeledRowAndCol = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkShowTooltip
            // 
            this.chkShowTooltip.AutoSize = true;
            this.chkShowTooltip.Location = new System.Drawing.Point(6, 25);
            this.chkShowTooltip.Name = "chkShowTooltip";
            this.chkShowTooltip.Size = new System.Drawing.Size(126, 24);
            this.chkShowTooltip.TabIndex = 1;
            this.chkShowTooltip.Text = "Show Tooltip";
            this.chkShowTooltip.UseVisualStyleBackColor = true;
            // 
            // bnSave
            // 
            this.bnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bnSave.Location = new System.Drawing.Point(671, 395);
            this.bnSave.Name = "bnSave";
            this.bnSave.Size = new System.Drawing.Size(104, 43);
            this.bnSave.TabIndex = 2;
            this.bnSave.Text = "Save";
            this.bnSave.UseVisualStyleBackColor = true;
            this.bnSave.Click += new System.EventHandler(this.bnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkHighlightSeledRowAndCol);
            this.groupBox1.Controls.Add(this.bnSelectIconPath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtIconPath);
            this.groupBox1.Controls.Add(this.chkShowTooltip);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 110);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detail Data Grid Settings";
            // 
            // bnSelectIconPath
            // 
            this.bnSelectIconPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bnSelectIconPath.Location = new System.Drawing.Point(725, 53);
            this.bnSelectIconPath.Name = "bnSelectIconPath";
            this.bnSelectIconPath.Size = new System.Drawing.Size(38, 32);
            this.bnSelectIconPath.TabIndex = 4;
            this.bnSelectIconPath.Text = "...";
            this.bnSelectIconPath.UseVisualStyleBackColor = true;
            this.bnSelectIconPath.Click += new System.EventHandler(this.bnSelectIconPath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Icon Path";
            // 
            // txtIconPath
            // 
            this.txtIconPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIconPath.Location = new System.Drawing.Point(95, 56);
            this.txtIconPath.Name = "txtIconPath";
            this.txtIconPath.Size = new System.Drawing.Size(624, 26);
            this.txtIconPath.TabIndex = 2;
            // 
            // chkHighlightSeledRowAndCol
            // 
            this.chkHighlightSeledRowAndCol.AutoSize = true;
            this.chkHighlightSeledRowAndCol.Location = new System.Drawing.Point(179, 24);
            this.chkHighlightSeledRowAndCol.Name = "chkHighlightSeledRowAndCol";
            this.chkHighlightSeledRowAndCol.Size = new System.Drawing.Size(286, 24);
            this.chkHighlightSeledRowAndCol.TabIndex = 5;
            this.chkHighlightSeledRowAndCol.Text = "Highlight selected Row and Column";
            this.chkHighlightSeledRowAndCol.UseVisualStyleBackColor = true;
            // 
            // frmGlobalSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bnSave);
            this.Name = "frmGlobalSettings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.frmGlobalSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkShowTooltip;
        private System.Windows.Forms.Button bnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bnSelectIconPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIconPath;
        private System.Windows.Forms.CheckBox chkHighlightSeledRowAndCol;
    }
}