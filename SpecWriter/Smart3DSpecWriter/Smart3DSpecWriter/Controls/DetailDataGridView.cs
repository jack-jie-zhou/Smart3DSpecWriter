using Microsoft.Office.Interop.Excel;
using Smart3DSpecWriter.Excel;
using Smart3DSpecWriter.Utilities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Smart3DSpecWriter.Controls
{
    public partial class DetailDataGridView : DataGridView
    {
        private Worksheet _sheet;
        private List<CellInfo> _list;

        public DetailDataGridView()
        {
            InitializeComponent();
            RegisterEventHandlers();
        }
        #region "Events"
        private void RegisterEventHandlers()
        {
            toolStripMenuItemHideEmpty.Click += ToolStripMenuItemHideEmpty_Click;
            toolStripMenuItemShowEmpty.Click += ToolStripMenuItemShowEmpty_Click;
            toolStripMenuItemUpdate.Click += ToolStripMenuItemUpdate_Click;
            toolStripMenuItemShortDesc.Click += ToolStripMenuItemShortDesc_Click;
            toolStripMenuItemLongDesc.Click += ToolStripMenuItemLongDesc_Click;
            toolStripMenuItemDisplaySymbolIcon.Click += ToolStripMenuItemDisplaySymbolIcon_Click;
            CellValueChanged += DetailDataGridView_CellValueChanged;
        }

        private void ToolStripMenuItemDisplaySymbolIcon_Click(object sender, EventArgs e)
        {
            CommonFunctions.DisplayIcon(_list);
            //string iconName = "";
            //for (int i = 0; i < _list.Count; i++)
            //{
            //    if (_list[i].Name == "SymbolIcon")
            //    {
            //        iconName = _list[i].Value;
            //        break;
            //    }
            //}

            //if (iconName == "")
            //{
            //    MessageBox.Show("No symbolIcon value is provided in the worksheet");
            //    return;
            //}

            //if (string.IsNullOrWhiteSpace(Properties.Settings.Default.IConPath))
            //{
            //    MessageBox.Show("Please set up symbol path first!");
            //    return;
            //}
            //string fileName = Properties.Settings.Default.IConPath + "\\" + iconName;

            //DisplayIconForm frm = new DisplayIconForm();
            //frm.FileName = fileName;
            //frm.TopMost = true;
            //frm.Show();
        }

        private void DetailDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CellInfo cellInfo = CurrentCell.OwningRow.DataBoundItem as CellInfo;
            if (cellInfo.Value != _sheet.Cells[cellInfo.Row, cellInfo.Column].Value?.ToString())
            {

                CurrentCell.Style.BackColor = System.Drawing.Color.Yellow;
                _sheet.Cells[cellInfo.Row, cellInfo.Column].Value = CurrentCell.Value;
                _sheet.Cells[cellInfo.Row, cellInfo.Column].Interior.Color = XlRgbColor.rgbGreenYellow;
            }
        }

        private void ToolStripMenuItemLongDesc_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ToolStripMenuItemShortDesc_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ToolStripMenuItemUpdate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _list.Count; i++)
            {
                CellInfo cell = _list[i];
                _sheet.Cells[cell.Row, cell.Column].Value = cell.Value;
            }
        }

        private void ToolStripMenuItemShowEmpty_Click(object sender, EventArgs e)
        {
            DataSource = null;
            DataSource = _list;
            AutoResizeColumns();
            CommonFunctions.Coloring(Rows, RowCount, 3);

        }

        private void ToolStripMenuItemHideEmpty_Click(object sender, EventArgs e)
        {
            DataSource = null;
            DataSource = NoneEmptyList();
            AutoResizeColumns();
            CommonFunctions.Coloring(Rows, RowCount, 3);

        }

        #endregion

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
                HeaderText = "Value"
            };
            DataGridViewTextBoxColumn CodeList = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CodeList",
                DisplayIndex = 2,
                HeaderText = "Code List",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true

            };
            Columns.Add(Name);
            Columns.Add(Value);
            Columns.Add(CodeList);
        }

        internal void SetDataSource(List<CellInfo> cellInfoDetails, Worksheet sheet)
        {
            _sheet = sheet ?? throw new ArgumentNullException(nameof(sheet));
            _list = cellInfoDetails;
            DataViewGridSettings();
            DataSource = null;
            DataSource = cellInfoDetails;
            AutoResizeColumns();
            CommonFunctions.Coloring(Rows, RowCount, 3);
        }

        private List<CellInfo> NoneEmptyList()
        {
            List<CellInfo> list = new List<CellInfo>();
            for (int i = 0; i < _list.Count; i++)
            {
                CellInfo cell = _list[i];
                if (!string.IsNullOrWhiteSpace(cell.Value))
                {
                    list.Add(cell);
                }
            }
            return list;
        }



    }
}
