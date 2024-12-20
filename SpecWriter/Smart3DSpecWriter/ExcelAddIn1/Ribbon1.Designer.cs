﻿namespace ExcelAddIn1
{
    partial class Ribbon1 : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon1()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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
            this.MYWork = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.button1 = this.Factory.CreateRibbonButton();
            this.tab1 = this.Factory.CreateRibbonTab();
            this.tab2 = this.Factory.CreateRibbonTab();
            this.tab3 = this.Factory.CreateRibbonTab();
            this.MYWork.SuspendLayout();
            this.group1.SuspendLayout();
            this.tab1.SuspendLayout();
            this.tab2.SuspendLayout();
            this.tab3.SuspendLayout();
            this.SuspendLayout();
            // 
            // MYWork
            // 
            this.MYWork.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.MYWork.Groups.Add(this.group1);
            this.MYWork.Label = "TabAddIns";
            this.MYWork.Name = "MYWork";
            // 
            // group1
            // 
            this.group1.Items.Add(this.button1);
            this.group1.Label = "group1";
            this.group1.Name = "group1";
            // 
            // button1
            // 
            this.button1.Label = "button1";
            this.button1.Name = "button1";
            this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // tab1
            // 
            this.tab1.Label = "tab1";
            this.tab1.Name = "tab1";
            // 
            // tab2
            // 
            this.tab2.Label = "tab2";
            this.tab2.Name = "tab2";
            // 
            // tab3
            // 
            this.tab3.Label = "tab3";
            this.tab3.Name = "tab3";
            // 
            // Ribbon1
            // 
            this.Name = "Ribbon1";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.MYWork);
            this.Tabs.Add(this.tab1);
            this.Tabs.Add(this.tab2);
            this.Tabs.Add(this.tab3);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.MYWork.ResumeLayout(false);
            this.MYWork.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.tab2.ResumeLayout(false);
            this.tab2.PerformLayout();
            this.tab3.ResumeLayout(false);
            this.tab3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab MYWork;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        private Microsoft.Office.Tools.Ribbon.RibbonTab tab2;
        private Microsoft.Office.Tools.Ribbon.RibbonTab tab3;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon1 Ribbon1
        {
            get { return this.GetRibbon<Ribbon1>(); }
        }
    }
}
