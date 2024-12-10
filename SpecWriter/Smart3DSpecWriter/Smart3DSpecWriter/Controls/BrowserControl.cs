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

        /// <summary>
        /// Name of current selected worksheet
        /// </summary>
        public string CurrentSheetName { get; internal set; }

        /// <summary>
        /// The Value of the PartClassType in Definition Row. e.g. "PipeComponentClass", "ValveOperatorClass", "PipeStockClass"
        /// </summary>
        public string PartClassType { get; internal set; }

        /// <summary>
        /// Set list of worksheet to "lstSheetNameList" on the "Sheets" tab of BrowserControl datagrid
        /// </summary>
        /// <param name="sheetNameList"></param>
        internal void AddSheetNameList(List<string> sheetNameList)
        {
            lstSheetNameList.DataSource = null;
            lstSheetNameList.DataSource = sheetNameList;
        }

        /// <summary>
        /// Activate the selected sheet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstSheetNameList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSheetNameList.SelectedItem != null)
            {
                Worksheet sheet = Globals.Smart3DAddIn.Application.Worksheets[lstSheetNameList.SelectedItem.ToString()];
                sheet.Activate();
            }
        }

        /// <summary>
        /// definitionDataGridView1.SetDataSource(cellInfos,  sheet);
        /// </summary>
        /// <param name="cellInfos"></param>
        /// <param name="sheet"></param>
        internal void SetDefinitionInformation(List<CellInfo> cellInfos, Worksheet sheet)
        {
            definitionDataGridView1.SetDataSource(cellInfos,  sheet);
        }

        /// <summary>
        /// detailDataGridView1.SetDataSource(cellInfoDetails,sheet);
        /// </summary>
        /// <param name="cellInfoDetails"></param>
        /// <param name="sheet"></param>
        /// <param name="partClassType">-</param>
        internal void SetDetailInformation(List<CellInfo> cellInfoDetails,Worksheet sheet, string partClassType)
        {
            detailDataGridView1.SetDataSource(cellInfoDetails,sheet,partClassType);
        }

        /// <summary>
        /// SetBrowserWidth(600);
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonFunctions.SetBrowserWidth(600);
        }

        /// <summary>
        /// SetBrowserWidth(360);
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void regularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonFunctions.SetBrowserWidth(360);
        }

        /// <summary>
        /// SetBrowserWidth(180);
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void narrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonFunctions.SetBrowserWidth(180);

        }
    }
}
