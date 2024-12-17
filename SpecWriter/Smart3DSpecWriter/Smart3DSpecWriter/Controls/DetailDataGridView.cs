using CodelistLibrary;
using Microsoft.Office.Interop.Excel;
using Smart3DSpecWriter.Excel;
using Smart3DSpecWriter.Forms;
using Smart3DSpecWriter.Utilities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Smart3DSpecWriter.Controls
{
    /// <summary>
    /// DataGridView used to display detail section of worksheet row
    /// </summary>
    public partial class DetailDataGridView : DataGridView
    {
        /// <summary>
        /// current worksheet
        /// </summary>
        private Worksheet _sheet;

        /// <summary>
        /// List of cells information in current
        /// </summary>
        private List<CellInfo> _list;

        /// <summary>
        /// PartClassType
        /// </summary>
        private string _partClassType;

        private frmPopup _frmPopup = new frmPopup();

        /// <summary>
        /// This dataGridView has four columns: name, value, short, long
        /// </summary>
        public DetailDataGridView()
        {
            InitializeComponent();
            RegisterEventHandlers();
        }
        #region "Events"
        /// <summary>
        /// register event handlers
        /// </summary>
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

        /// <summary>
        /// Display icon
        /// </summary>
        /// <param name="sender">-</param>
        /// <param name="e">-</param>
        private void ToolStripMenuItemDisplaySymbolIcon_Click(object sender, EventArgs e)
        {
            CommonFunctions.DisplayIcon(_list);
        }

        /// <summary>
        /// Update the data on the worksheet with the data from the DetailDataGridView 
        /// </summary>
        /// <param name="sender">-</param>
        /// <param name="e">-</param>
        private void DetailDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CellInfo cellInfo = CurrentCell.OwningRow.DataBoundItem as CellInfo;
            if (cellInfo.Value != _sheet.Cells[cellInfo.Row, cellInfo.Column].Value?.ToString())
            {
                Rows[CurrentCell.RowIndex].Cells[1].Style.BackColor = System.Drawing.Color.Yellow;

                //Update the cell on the worksheet with the data of current on column 1(value)
                //  _sheet.Cells[cellInfo.Row, cellInfo.Column].Value = Rows[CurrentCell.RowIndex].Cells[1].Value;
                //  _sheet.Cells[cellInfo.Row, cellInfo.Column].Interior.Color = XlRgbColor.rgbGreenYellow;
            }
        }

        private void ToolStripMenuItemLongDesc_Click(object sender, EventArgs e)
        {
            DataGridViewRow row;
            for (int i = 0; i < Rows.Count - 1; i++)
            {
                row = Rows[i];
                CodelistValueView x = CodelistUtilities.CodelistLookup((string)row.Cells[0].Value, (string)row.Cells[1].Value, _partClassType);
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
            /*
             1. Get the propertyName, partClassType 
             2. Get codelist table name and byShortDesc
             3. lookup for codelist value by using tablename and valudId/shortDesc
             4. populate the row with codelist value record
             
             */


            DataGridViewRow row;
            for (int i = 0; i < Rows.Count - 1; i++)
            {
                row = Rows[i];
                CodelistValueView x = CodelistUtilities.CodelistLookup((string)row.Cells[0].Value, (string)row.Cells[1].Value, _partClassType);
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
                Width = 100,
                HeaderText = "Value"
            };
            DataGridViewTextBoxColumn CodeList = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CodeList",
                DisplayIndex = 2,
                Width = 100,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cellInfoDetails"></param>
        /// <param name="sheet"></param>
        /// <param name="partClassType"></param>
        /// <exception cref="ArgumentNullException"></exception>
        internal void SetDataSource(List<CellInfo> cellInfoDetails, Worksheet sheet, string partClassType)
        {
            _sheet = sheet ?? throw new ArgumentNullException(nameof(sheet));
            _list = cellInfoDetails;
            _partClassType = partClassType;
            DataViewGridSettings();
            DataSource = null;
            DataSource = cellInfoDetails;


            DataGridViewRow row;
            for (int i = 0; i < Rows.Count - 1; i++)
            {
                row = Rows[i];
                CodelistValueView x = CodelistUtilities.CodelistLookup((string)row.Cells[0].Value, (string)row.Cells[1].Value, _partClassType);
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
            CommonFunctions.Coloring(Rows, RowCount, 3);
        }



        /// <summary>
        /// Build a new list with all its items are non empty, and return the new list
        /// </summary>
        /// <returns>new list with all items are non-empty</returns>
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

        /// <summary>
        /// Open codelist form for selection, Replace the values of current selected row with the data selected from the form.
        /// </summary>
        /// <param name="sender">-</param>
        /// <param name="e">-</param>
        private void DetailDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex != 1) return;
            string propertyName = Rows[e.RowIndex].Cells[0].Value.ToString();
            string valueRaw = Rows[e.RowIndex].Cells[1].Value?.ToString();

            bool byShortDesc;
            string clTablename;

            (clTablename, byShortDesc) = CodelistUtilities.GetCodelistTableName(propertyName, _partClassType);
            if (string.IsNullOrWhiteSpace(clTablename)) { return; }

            List<CodelistValueView> valuelist;

            if (byShortDesc == true)
            {
                valuelist = CodelistAPI.GetValueTreeFromTableNameAndShortStringValue(clTablename, valueRaw);
            }
            else
            {
                int result;
                bool success = int.TryParse(valueRaw, out result);
                if (success)
                {
                    valuelist = CodelistAPI.GetValueTreeFromTableNameAndValueId(clTablename, int.Parse(valueRaw));
                }
                else
                {
                    valuelist = null;
                }
            }

            var tablelist = CodelistAPI.GetTableTreeFromTableName(clTablename);
            if (tablelist != null)
            {
                frmCodelist frm = new frmCodelist();
                frm.populateTree(tablelist, clTablename, valuelist);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (byShortDesc == true)
                    {
                        Rows[e.RowIndex].Cells[1].Value = frm.SelectedValue.ShortStringValue;
                    }
                    else
                    {
                        Rows[e.RowIndex].Cells[1].Value = frm.SelectedValue.ValueId;
                    };
                    Rows[e.RowIndex].Cells[2].Value = frm.SelectedValue.ShortStringValue;
                    Rows[e.RowIndex].Cells[3].Value = frm.SelectedValue.LongStringValue;
                    Rows[e.RowIndex].Cells[0].Selected = true;
                };
            }
            Refresh();
            AutoResizeColumns();
        }

        //private void DetailDataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.ColumnIndex != 1) return;
        //    if (e.RowIndex >= 1)
        //    {
        //        DataGridViewRow row = this.Rows[e.RowIndex];
        //        _frmPopup.labelName.Text = row.Cells[0].Value?.ToString();
        //        _frmPopup.labelValue.Text = row.Cells[1].Value?.ToString();
        //        _frmPopup.labelShort.Text = row.Cells[2].Value?.ToString();
        //        _frmPopup.labelLong.Text = row.Cells[3].Value?.ToString();
        //        //Point point = PointToScreen(new System.Drawing.Point(e., e.Y));
        //        //frmPopup.Location = new Point(point.X + 10, point.Y + 10);


        //        var cellRect = GetCellDisplayRectangle(e.RowIndex, e.ColumnIndex, true);
        //        var cellLocalationOnScreen = PointToScreen(new System.Drawing.Point(cellRect.X, cellRect.Y));
        //        _frmPopup.Location = cellLocalationOnScreen;
        //        _frmPopup.Show();


        //    }
        //}

        //private void DetailDataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        //{
        //    _frmPopup.Hide();
        //}

        private void DetailDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Ensure a valid cell was clicked
            {
                // Check if the Ctrl key is pressed
                if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                {
                    DataGridViewRow row = this.Rows[e.RowIndex];
                    //_frmPopup.labelName.Text = row.Cells[0].Value?.ToString();
                    //_frmPopup.labelValue.Text = row.Cells[1].Value?.ToString();
                    //_frmPopup.labelShort.Text = row.Cells[2].Value?.ToString();
                    //_frmPopup.labelLong.Text = row.Cells[3].Value?.ToString();
                    ////Point point = PointToScreen(new System.Drawing.Point(e., e.Y));
                    ////frmPopup.Location = new Point(point.X + 10, point.Y + 10);

                    //_frmPopup =new frmPopup();
                    //var cellRect = GetCellDisplayRectangle(1, e.RowIndex, false);
                    //var cellLocalationOnScreen = PointToScreen(new System.Drawing.Point(cellRect.X+Left, cellRect.Y+Top));

                    //_frmPopup.Location = cellLocalationOnScreen;
                    //_frmPopup.Show();

                    var cell = row.Cells[0];
                    cell.ToolTipText = "dfddd\ndsfsds\ndfds";
                }

            }
        }

        private void DetailDataGridView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control)
            {
                _frmPopup.Hide();
            }
        }

        private void DetailDataGridView_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (GlobalSettings.ShowTooltip == false) return;
            // Check if the cell is valid
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                DataGridViewRow row = this.Rows[e.RowIndex];
                string name = row.Cells[0].Value?.ToString();
                string value = row.Cells[1].Value?.ToString();

                string sh = row.Cells[2].Value?.ToString();
                string lg = row.Cells[3].Value?.ToString();

                // Set the tooltip text for the hovered cell
                e.ToolTipText = $"Name:{name} \nValue: {value} \nShort: {sh} \nLong: {lg}";
            }
        }
    }
}

