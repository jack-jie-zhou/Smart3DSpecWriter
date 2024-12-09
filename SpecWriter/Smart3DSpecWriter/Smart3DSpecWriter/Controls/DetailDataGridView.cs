using CodelistLibrary;
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
        /// <summary>
        /// current worksheet
        /// </summary>
        private Worksheet _sheet;

        private List<CellInfo> _list;

        /// <summary>
        /// This dataGridView has four columns: name, value, short, long
        /// </summary>
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
                Rows[CurrentCell.RowIndex].Cells[1].Style.BackColor = System.Drawing.Color.Yellow;
                
                //CurrentCell.Style.BackColor = System.Drawing.Color.Yellow;
                _sheet.Cells[cellInfo.Row, cellInfo.Column].Value = CurrentCell.Value;
                _sheet.Cells[cellInfo.Row, cellInfo.Column].Interior.Color = XlRgbColor.rgbGreenYellow;
            }
        }

        private void ToolStripMenuItemLongDesc_Click(object sender, EventArgs e)
        {
            DataGridViewRow row;
            for (int i = 0; i < Rows.Count - 1; i++)
            {
                row = Rows[i];
                CodelistValueView x = CodelistUtilities.CodelistLookup((string)row.Cells[0].Value, (string)row.Cells[1].Value);
                if (x != null)
                {
                    row.Cells[2].Value = x.LongStringValue;
                }
                else
                {
                    row.Cells[2].Value = "";
                }
            }
        }

        private void ToolStripMenuItemShortDesc_Click(object sender, EventArgs e)
        {
            DataGridViewRow row;
            for (int i = 0; i < Rows.Count - 1; i++)
            {
                row = Rows[i];
                CodelistValueView x = CodelistUtilities.CodelistLookup((string)row.Cells[0].Value, (string)row.Cells[1].Value);
                if (x != null)
                {
                    row.Cells[2].Value = x.ShortStringValue;
                    row.Cells[3].Value = x.LongStringValue;
                }
                else
                {
                    row.Cells[2].Value = "";
                    row.Cells[3].Value = "";
                }
            }
            AutoResizeColumns();
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
                HeaderText = "Short",
                //  AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                ReadOnly = true

            };
            DataGridViewTextBoxColumn CodeListLong = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CodeList",
                DisplayIndex = 3,
                HeaderText = "Long",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true

            };
            Columns.Add(Name);
            Columns.Add(Value);
            Columns.Add(CodeList);
            Columns.Add(CodeListLong);
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

        private void DetailDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            string propertyName = Rows[e.RowIndex].Cells[0].Value.ToString();
            string valueId = Rows[e.RowIndex].Cells[1].Value.ToString();

            string clTablename = CodelistUtilities.GetCodelistTableName(propertyName);
            if (string.IsNullOrWhiteSpace(clTablename) || string.IsNullOrWhiteSpace(valueId)) { return; }

            List<CodelistValueView> valuelist = CodelistAPI.GetValueTreeFromTableNameAndValueId(clTablename,int.Parse(valueId));

            var tablelist = CodelistAPI.GetTableTreeFromTableName(clTablename);
            if (tablelist != null)
            {
                frmCodelist frm = new frmCodelist();
                frm.populateTree(tablelist,clTablename,valuelist);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Rows[e.RowIndex].Cells[1].Value=frm.SelectedValue.ValueId;
                    Rows[e.RowIndex].Cells[2].Value=frm.SelectedValue.ShortStringValue;
                    Rows[e.RowIndex].Cells[3].Value=frm.SelectedValue.LongStringValue;
                    Rows[e.RowIndex].Cells[0].Selected=true;
                };
            }
            Refresh();
            AutoResizeColumns();
        }
    }
}
