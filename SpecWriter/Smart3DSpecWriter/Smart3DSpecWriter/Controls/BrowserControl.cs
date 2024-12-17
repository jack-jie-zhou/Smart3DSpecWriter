using Microsoft.Office.Interop.Excel;
using Smart3DSpecWriter.Excel;
using Smart3DSpecWriter.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /// List of all sheet name in current workbook
        /// </summary>
        List<string> _sheetNameList;
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
            _sheetNameList = sheetNameList;
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

        private void bnSheetlistFilterApple_Click(object sender, EventArgs e)
        {
            /*
             1. sheetlist without filter: _sheetNamelist
             2. filter the list with txtSheetListFilter
             3. assign the filtered list to the grid
             */

            List<string> filters = _sheetNameList.Where(item=>item.ToLower().Contains(txtSheetListFilter.Text.ToLower())).ToList();
            lstSheetNameList.DataSource = filters;  
        }

        private void bnSheetlistFilterClear_Click(object sender, EventArgs e)
        {
            txtSheetListFilter.Text = "";
            lstSheetNameList.DataSource=_sheetNameList;
        }

        private void txtSheetListFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true; // Prevent the default Enter key behavior
                e.SuppressKeyPress = true; // Suppress the "ding" sound
                bnSheetlistFilterApple.PerformClick(); // Trigger the button's Click event
            }
        }
    }
}
