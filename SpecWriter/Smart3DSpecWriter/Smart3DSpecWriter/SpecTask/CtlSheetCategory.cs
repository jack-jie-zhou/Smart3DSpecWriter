using Accessibility;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart3DSpecWriter.SpecTask
{
    /// <summary>
    /// Category is the task you need to do, e.g. 1. New PMC, 2. New Component, etc.
    /// </summary>
    public partial class CtlSheetCategory : UserControl
    {
        /// <summary>
        /// Category selected index
        /// </summary>
        static int _selectedIndex;

        /// <summary>
        /// List of sheets of the workbook
        /// </summary>
        List<string> _sheetlistOfWorkbook;

        /// <summary>
        /// List of the required sheets for the category
        /// </summary>
        List<SheetStatus> _listofRequiredSheets;

        /// <summary>
        /// ctor
        /// </summary>
        public CtlSheetCategory()
        {
            InitializeComponent();

         //   dgSheetList.Columns.Clear();
            dgSheetList.AutoGenerateColumns = false;
            dgSheetList.MultiSelect = false;
            dgSheetList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgSheetList.RowHeadersVisible = false;
            dgSheetList.EditMode = DataGridViewEditMode.EditOnEnter;
            dgSheetList.BackgroundColor = System.Drawing.Color.White;



            var categories = GetSpecTaskDbUtilities.GetCategories();
            comboCategory.DataSource = categories;
        }

        /// <summary>
        /// Set List of sheets in workbook to the control
        /// </summary>
        /// <param name="sheetNameList"></param>
        internal void SetSheetList(List<string> sheetNameList)
        {
            _sheetlistOfWorkbook = sheetNameList;
            CompareLists();
        }

        private void comboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            var x =comboCategory.SelectedItem as string;
            _selectedIndex=comboCategory.SelectedIndex;
            var y = GetSpecTaskDbUtilities.GetSheetListOfCategory(x);
            dgSheetList.DataSource = null;
            dgSheetList.DataSource = y;
            _listofRequiredSheets = y;
            CompareLists();
        }

        /// <summary>
        /// 
        /// </summary>
        void CompareLists()
        {
            if (_listofRequiredSheets == null || _sheetlistOfWorkbook == null) return;


            foreach ( var sheet in _listofRequiredSheets ) {
                var x =_sheetlistOfWorkbook.FirstOrDefault(p => p.ToLower() == sheet.SheetName.ToLower());
                if (x != null)
                {
                    sheet.Exist = true;
                }
                else
                {
                    sheet.Exist = false;
                }
            }
            //dgSheetList.DataSource = null;
            //dgSheetList.DataSource=_listofRequiredSheets;
        }



        private void dgSheetList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string sheetname = dgSheetList.Rows[e.RowIndex].Cells[2].Value.ToString();
            bool exist = Convert.ToBoolean(dgSheetList.Rows[e.RowIndex].Cells[0].Value);

            if (sheetname != null && exist )
            {
                Worksheet sheet = Globals.Smart3DAddIn.Application.Worksheets[sheetname];
                sheet.Activate();
            }
        }
    }
}
