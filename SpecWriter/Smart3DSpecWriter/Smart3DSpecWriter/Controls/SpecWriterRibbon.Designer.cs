namespace Smart3DSpecWriter
{
    partial class SpecWriterRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public SpecWriterRibbon()
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
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.bnKillExcel = this.Factory.CreateRibbonButton();
            this.bnSettings = this.Factory.CreateRibbonButton();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.bnReadPipeBranch = this.Factory.CreateRibbonButton();
            this.bnWritePipeBranchTable = this.Factory.CreateRibbonButton();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.bnEditor = this.Factory.CreateRibbonButton();
            this.tab2 = this.Factory.CreateRibbonTab();
            this.group4 = this.Factory.CreateRibbonGroup();
            this.button1 = this.Factory.CreateRibbonButton();
            this.button2 = this.Factory.CreateRibbonButton();
            this.group5 = this.Factory.CreateRibbonGroup();
            this.button3 = this.Factory.CreateRibbonButton();
            this.button4 = this.Factory.CreateRibbonButton();
            this.group6 = this.Factory.CreateRibbonGroup();
            this.button5 = this.Factory.CreateRibbonButton();
            this.group7 = this.Factory.CreateRibbonGroup();
            this.bnTest = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.group3.SuspendLayout();
            this.group2.SuspendLayout();
            this.tab2.SuspendLayout();
            this.group4.SuspendLayout();
            this.group5.SuspendLayout();
            this.group6.SuspendLayout();
            this.group7.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group1);
            this.tab1.Groups.Add(this.group3);
            this.tab1.Groups.Add(this.group2);
            this.tab1.Label = "Smart3D";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.bnKillExcel);
            this.group1.Items.Add(this.bnSettings);
            this.group1.Label = "Settings";
            this.group1.Name = "group1";
            // 
            // bnKillExcel
            // 
            this.bnKillExcel.Label = "Kill Excel";
            this.bnKillExcel.Name = "bnKillExcel";
            this.bnKillExcel.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.bnKillExcel_Click);
            // 
            // bnSettings
            // 
            this.bnSettings.Label = "Settings";
            this.bnSettings.Name = "bnSettings";
            this.bnSettings.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.bnSettings_Click);
            // 
            // group3
            // 
            this.group3.Items.Add(this.bnReadPipeBranch);
            this.group3.Items.Add(this.bnWritePipeBranchTable);
            this.group3.Label = "Pipe Branch";
            this.group3.Name = "group3";
            // 
            // bnReadPipeBranch
            // 
            this.bnReadPipeBranch.Label = "Read Pipe Branch";
            this.bnReadPipeBranch.Name = "bnReadPipeBranch";
            this.bnReadPipeBranch.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.bnReadPipeBranch_Click);
            // 
            // bnWritePipeBranchTable
            // 
            this.bnWritePipeBranchTable.Label = "Write Pipe Branch";
            this.bnWritePipeBranchTable.Name = "bnWritePipeBranchTable";
            this.bnWritePipeBranchTable.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.bnWritePipeBranchTable_Click);
            // 
            // group2
            // 
            this.group2.Items.Add(this.bnEditor);
            this.group2.Label = "Editor";
            this.group2.Name = "group2";
            // 
            // bnEditor
            // 
            this.bnEditor.Label = "Editor";
            this.bnEditor.Name = "bnEditor";
            this.bnEditor.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.bnEditor_Click);
            // 
            // tab2
            // 
            this.tab2.Groups.Add(this.group4);
            this.tab2.Groups.Add(this.group5);
            this.tab2.Groups.Add(this.group6);
            this.tab2.Groups.Add(this.group7);
            this.tab2.Label = "SP3D Spec Writer";
            this.tab2.Name = "tab2";
            // 
            // group4
            // 
            this.group4.Items.Add(this.button1);
            this.group4.Items.Add(this.button2);
            this.group4.Label = "Settings";
            this.group4.Name = "group4";
            // 
            // button1
            // 
            this.button1.Label = "Kill Excel";
            this.button1.Name = "button1";
            this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Label = "Settings";
            this.button2.Name = "button2";
            this.button2.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button2_Click);
            // 
            // group5
            // 
            this.group5.Items.Add(this.button3);
            this.group5.Items.Add(this.button4);
            this.group5.Label = "Pipe Branch";
            this.group5.Name = "group5";
            // 
            // button3
            // 
            this.button3.Label = "Read Pipe Branch";
            this.button3.Name = "button3";
            this.button3.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Label = "Write Pipe Branch";
            this.button4.Name = "button4";
            // 
            // group6
            // 
            this.group6.Items.Add(this.button5);
            this.group6.Label = "Editor";
            this.group6.Name = "group6";
            // 
            // button5
            // 
            this.button5.Label = "Editor";
            this.button5.Name = "button5";
            // 
            // group7
            // 
            this.group7.Items.Add(this.bnTest);
            this.group7.Label = "group7";
            this.group7.Name = "group7";
            // 
            // bnTest
            // 
            this.bnTest.Label = "Test";
            this.bnTest.Name = "bnTest";
            this.bnTest.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.bnTest_Click);
            // 
            // SpecWriterRibbon
            // 
            this.Name = "SpecWriterRibbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Tabs.Add(this.tab2);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.SpecWriterRibbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.tab2.ResumeLayout(false);
            this.tab2.PerformLayout();
            this.group4.ResumeLayout(false);
            this.group4.PerformLayout();
            this.group5.ResumeLayout(false);
            this.group5.PerformLayout();
            this.group6.ResumeLayout(false);
            this.group6.PerformLayout();
            this.group7.ResumeLayout(false);
            this.group7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton bnSettings;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton bnEditor;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton bnReadPipeBranch;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton bnWritePipeBranchTable;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton bnKillExcel;
        private Microsoft.Office.Tools.Ribbon.RibbonTab tab2;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group4;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button2;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group5;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button4;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group6;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button5;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group7;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton bnTest;
    }

    partial class ThisRibbonCollection
    {
        internal SpecWriterRibbon SpecWriterRibbon
        {
            get { return this.GetRibbon<SpecWriterRibbon>(); }
        }
    }
}
