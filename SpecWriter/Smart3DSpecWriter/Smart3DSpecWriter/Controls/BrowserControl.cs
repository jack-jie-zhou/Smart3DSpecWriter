using Microsoft.Office.Interop.Excel;
using Smart3DSpecWriter.Excel;
using Smart3DSpecWriter.Utilities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Smart3DSpecWriter
{
    public partial class BrowserControl : UserControl
    {
        public BrowserControl()
        {
            InitializeComponent();
        }

        public string CurrentSheetName { get; internal set; }
        public string PartClassType { get; internal set; }

        internal void AddSheetNameList(List<string> sheetNameList)
        {
            lstSheetNameList.DataSource = null;
            lstSheetNameList.DataSource = sheetNameList;
        }

        private void lstSheetNameList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSheetNameList.SelectedItem != null)
            {
                Worksheet sheet = Globals.Smart3DAddIn.Application.Worksheets[lstSheetNameList.SelectedItem.ToString()];
                sheet.Activate();
            }
        }

        internal void SetDefinitionInformation(List<CellInfo> cellInfos, Worksheet sheet)
        {
            definitionDataGridView1.SetDataSource(cellInfos,  sheet);
        }

        internal void SetDetailInformation(List<CellInfo> cellInfoDetails,Worksheet sheet)
        {
            detailDataGridView1.SetDataSource(cellInfoDetails,sheet);
        }

        private void wideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonFunctions.SetBrowserWidth(600);
        }

        private void regularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonFunctions.SetBrowserWidth(360);
        }

        private void narrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonFunctions.SetBrowserWidth(180);

        }
    }
}
