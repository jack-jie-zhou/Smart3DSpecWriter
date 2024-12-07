using Microsoft.Office.Interop.Excel;
using Smart3DSpecWriter.Excel;
using Smart3DSpecWriter.Utilities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Smart3DSpecWriter.Controls
{
    public partial class DefinitionDataGridView : DataGridView
    {
        private Worksheet _sheet;
        private List<CellInfo> _list;

        public DefinitionDataGridView()
        {
            InitializeComponent();
            toolStripMenuItemDisplayIcon.Click += ToolStripMenuItemDisplayIcon_Click;
        }

        private void ToolStripMenuItemDisplayIcon_Click(object sender, EventArgs e)
        {
            CommonFunctions.DisplayIcon(_list);

        }



        private void DataViewGridSettings()
        {
            Columns.Clear();
            AutoGenerateColumns = false;
            MultiSelect = false;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            RowHeadersVisible = false;
            EditMode = DataGridViewEditMode.EditOnEnter;
            BackgroundColor = System.Drawing.Color.White;
            DataGridViewTextBoxColumn Name = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                DisplayIndex = 0,
                HeaderText = "Name",
                ReadOnly = true
            };
            DataGridViewTextBoxColumn Value = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Value",
                DisplayIndex = 1,
                HeaderText = "Value",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            Columns.Add(Name);
            Columns.Add(Value);
        }

        internal void SetDataSource(List<CellInfo> cellInfos, Worksheet sheet)
        {
            DataViewGridSettings();
            _sheet = sheet ?? throw new ArgumentNullException(nameof(sheet));
            _list = cellInfos;
            DataSource = null;
            DataSource = cellInfos;
            AutoResizeColumns();
            CommonFunctions.Coloring(Rows, RowCount);
        }

    }
}
