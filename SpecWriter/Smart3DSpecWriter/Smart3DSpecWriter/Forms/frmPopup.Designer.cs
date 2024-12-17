namespace Smart3DSpecWriter.Forms
{
    partial class frmPopup
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
            this.labelName = new System.Windows.Forms.Label();
            this.labelValue = new System.Windows.Forms.Label();
            this.labelShort = new System.Windows.Forms.Label();
            this.labelLong = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(8, 18);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(51, 20);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "label1";
            // 
            // labelValue
            // 
            this.labelValue.AutoSize = true;
            this.labelValue.Location = new System.Drawing.Point(8, 41);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(51, 20);
            this.labelValue.TabIndex = 1;
            this.labelValue.Text = "label2";
            // 
            // labelShort
            // 
            this.labelShort.AutoSize = true;
            this.labelShort.Location = new System.Drawing.Point(8, 64);
            this.labelShort.Name = "labelShort";
            this.labelShort.Size = new System.Drawing.Size(51, 20);
            this.labelShort.TabIndex = 2;
            this.labelShort.Text = "label3";
            // 
            // labelLong
            // 
            this.labelLong.AutoSize = true;
            this.labelLong.Location = new System.Drawing.Point(8, 87);
            this.labelLong.Name = "labelLong";
            this.labelLong.Size = new System.Drawing.Size(51, 20);
            this.labelLong.TabIndex = 3;
            this.labelLong.Text = "label4";
            // 
            // frmPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 124);
            this.Controls.Add(this.labelLong);
            this.Controls.Add(this.labelShort);
            this.Controls.Add(this.labelValue);
            this.Controls.Add(this.labelName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPopup";
            this.Text = "frmPopup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label labelName;
        public System.Windows.Forms.Label labelValue;
        public System.Windows.Forms.Label labelShort;
        public System.Windows.Forms.Label labelLong;
    }
}