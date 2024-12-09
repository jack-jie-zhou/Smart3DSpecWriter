using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodelistLibrary
{
    /// <summary>
    /// From to display codelist
    /// </summary> 
    public partial class frmCodelist : Form
    {
  /// <summary>
  /// Selected code list value
  /// </summary>
        public CodelistValueView SelectedValue { get; set; }

        /// <summary>
        /// Current Selected Row in dgTableValueList???? Not sure
        /// </summary>
        int _currentRowIndex = -1;

        /// <summary>
        /// original codelist tables list
        /// </summary>
        List<CodelistTableInfoView> _tables;
        /// <summary>
        /// Original codelist values list
        /// </summary>
        List<CodelistValueView> _initValues;

        /// <summary>
        /// Form is used to choose valueId for this table
        /// </summary>
        string _currentTableName;

        /// <summary>
        ///  Rows displayed in dgTableValueList(top) dataGrid
        /// </summary>
        List<TreeClass> _classes = new List<TreeClass>();
        /// <summary>
        ///  Rows displayed in dgCurrentTable(bottom) DataGrid
        /// </summary>
        List<ValueClass> _values;

        public frmCodelist()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Populate the form with a hierarchy of tables and hierarchy of values
        /// </summary>
        /// <param name="tables">tables tree</param>
        /// <param name="values">values tree</param>
        /// <param name="currentTableName">此窗口将返回此表格选中的值</param>
        /// <example>
        /// <code language="cs">
        /// var tablelist = CodelistAPI.GetTableTreeFromTableName("SelectionBasis");
        /// List &lt;CodelistValueView&gt; valuelist = CodelistAPI.GetValueTreeFromTableNameAndValueId("SelectionBasis", 75);
        /// frmCodelist frm = new frmCodelist();
        /// frm.populateTree(tablelist, valuelist);
        /// frm.ShowDialog();
        /// </code>
        /// </example>
        public void populateTree(List<CodelistTableInfoView> tables, string currentTableName, List<CodelistValueView> values = null)
        {
            _currentTableName = currentTableName;
            this.Text = currentTableName;
            _tables = tables;
            _initValues = values;
            _classes.Clear();

            if (values == null)
            {
                foreach (var table in _tables)
                {
                    _classes.Add(new TreeClass() { Name = table.Name, ShortStringValue = string.Empty, LongStringValue = string.Empty, ValueId = null });
                }
                dgTableValueList.DataSource = _classes;
                _currentRowIndex = -1;
            }
            else
            {
                var joint =
                    from table in tables
                    join value in values
                    on table.Name equals value.TableName into gj
                    from subgroup in gj.DefaultIfEmpty()
                    select new TreeClass
                    {
                        Name = table.Name,
                        ValueId = subgroup?.ValueId ?? null,
                        ShortStringValue = subgroup?.ShortStringValue ?? string.Empty,
                        LongStringValue = subgroup?.LongStringValue ?? string.Empty
                    };
                _classes.Clear();
                _classes = joint.ToList<TreeClass>();
                dgTableValueList.DataSource = _classes;
                _currentRowIndex = -1;
            }
            dgTableValueList.AutoResizeColumns();
            dgCurrentTable.AutoResizeColumns();

        }

        /// <summary>
        /// <para>dgTableValueList is the datagrid control on the TOP of the Form</para>
        /// <para>It display the table tree</para>
        /// <para></para>
        /// </summary>
        /// <param name="sender">-</param>
        /// <param name="e">-</param>
        private void dgTableValueList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string sql;
            if (e.RowIndex == -1) return;
            if (e.ColumnIndex == 0)
            {
                string tableName = dgTableValueList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (tableName == string.Empty)
                {
                    dgCurrentTable.DataSource = null;
                    _values = null;
                    txtValuesFilter.Text = "";
                    _currentRowIndex = -1;
                    return;
                }
                int? parentValueId = null;
                if (e.RowIndex == 0)
                {
                    sql = $"select ValueId, ShortStringValue, LongStringValue from CodelistValueView where TableName ='{tableName}'and ParentTableId='00000000-0000-0000-0000-000000000000'";
                }
                else
                {
                    try
                    {
                        var x = dgTableValueList.Rows[e.RowIndex - 1].Cells[e.ColumnIndex + 1].Value;
                        if (x == null || x.Equals(string.Empty))
                        {
                            dgCurrentTable.DataSource = null;
                            txtValuesFilter.Text = "";
                            _values = null;
                            _currentRowIndex = -1;
                            return;
                        }
                        parentValueId = (int)x;

                    }
                    catch (Exception)
                    {

                        return;
                    }
                    sql = $"select ValueId, ShortStringValue, LongStringValue from CodelistValueView where TableName ='{tableName}'and ParentValueId={parentValueId}";
                }



                var results = CodelistAPI.GetValueList(sql).Select(
                    x => new ValueClass(x.ValueId, x.ShortStringValue, x.LongStringValue)
                    ).OrderBy(p => p.ValueId).ToList();
                dgCurrentTable.DataSource = results;
                _values = results;
                txtValuesFilter.Text = "";
                _currentRowIndex = e.RowIndex;
            }
            dgTableValueList.AutoResizeColumns();
            dgCurrentTable.AutoResizeColumns();
        }


        /// <summary>
        /// <para>dgCurrentTable is the datagrid control on the BOTTOM of the Form</para>
        /// 
        /// </summary>
        /// <param name="sender">-</param>
        /// <param name="e">-</param>


        private void dgCurrentTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_currentRowIndex == -1 || e.RowIndex == -1) { return; }

            var x = dgCurrentTable.Rows[e.RowIndex].Cells[0].Value;
            if (x == null)
            {
                return;
            }
            //_classes[_currentRowIndex].ValueId = (int)x;
            //_classes[_currentRowIndex].ShortStringValue = dgCurrentTable.Rows[e.RowIndex].Cells[1].Value.ToString();
            //_classes[_currentRowIndex].LongStringValue = dgCurrentTable.Rows[e.RowIndex].Cells[2].Value.ToString();
            _classes[_currentRowIndex].SetValue(new ValueClass((int)x, dgCurrentTable.Rows[e.RowIndex].Cells[1].Value.ToString(), dgCurrentTable.Rows[e.RowIndex].Cells[2].Value.ToString()));

            for (int i = _currentRowIndex + 1; i < _classes.Count; i++)
            {
                //_classes[i].ValueId = null;
                //_classes[i].ShortStringValue = string.Empty;
                //_classes[i].LongStringValue = string.Empty;
                _classes[i].SetValue(new ValueClass(null, string.Empty, string.Empty));
            }
            dgTableValueList.DataSource = null;
            dgTableValueList.DataSource = _classes;

            dgTableValueList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgCurrentTable.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        /// <summary>
        /// Restore the Form to the original state by calling "populateTree"
        /// </summary>
        /// <param name="sender">-</param>
        /// <param name="e">-</param>
        private void bnRestore_Click(object sender, EventArgs e)
        {
            dgCurrentTable.DataSource = null;
            txtValuesFilter.Text = "";
            dgTableValueList.DataSource = null;
            _currentRowIndex = -1;
            populateTree(_tables, _currentTableName, _initValues);

        }

        /// <summary>
        /// Search the value items that contains string displayed in "txtValuesFilter"
        /// </summary>
        /// <param name="sender">-</param>
        /// <param name="e">-</param>
        private void bnFilter_Click(object sender, EventArgs e)
        {
            if (_values == null) return;
            dgCurrentTable.DataSource = _values.Where(p => p.ShortStringValue.ToLower().Contains(txtValuesFilter.Text.ToLower()) || p.LongStringValue.ToLower().Contains(txtValuesFilter.Text.ToLower())).ToList();
        }
        /// <summary>
        /// Clear the filter indicated by "txtValuesFilter"
        /// </summary>
        /// <param name="sender">-</param>
        /// <param name="e">-</param>
        private void bnReset_Click(object sender, EventArgs e)
        {
            if (_values == null) return;
            dgCurrentTable.DataSource = _values;
            txtValuesFilter.Text = "";
        }

        private void dgTableValueList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bnOK_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _classes.Count; i++)
            {
                if (_classes[i].Name.ToLower() == _currentTableName.ToLower())
                {
                    if (_classes[i].ValueId == null) return;
                    int valueId = (int)_classes[i].ValueId;
                    if (MessageBox.Show($"Selected value={_classes[i].ValueId} in table {_currentTableName}", "Selected Value", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        SelectedValue = CodelistAPI.GetValueFromTableNameAndValueId(_currentTableName, valueId);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    };
                }
            }
        }
    }

    /// <summary>
    /// Each row in dbCurrentTable(bottom datagrid) contains a instance of ValueClass
    /// <para>All data are from value table</para>
    /// </summary>
    class ValueClass
    {
        public ValueClass(int? valueId, string shortstring, string longString)
        {
            ValueId = valueId;
            ShortStringValue = shortstring;
            LongStringValue = longString;
        }
        public int? ValueId { get; set; }
        public string ShortStringValue { get; set; }
        public string LongStringValue { get; set; }
    }

    /// <summary>
    /// Each row in dgTableValueList(top) contains a instance of TreeClass
    /// </summary>
    class TreeClass
    {
        /// <summary>
        /// Table name, comes from both table and value tables
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// from value table
        /// </summary>
        public int? ValueId { get; set; }
        /// <summary>
        /// from value table
        /// </summary>
        public string ShortStringValue { get; set; }
        /// <summary>
        /// from value table
        /// </summary>
        public string LongStringValue { get; set; }
        public void SetValue(ValueClass value)
        {
            ValueId = value.ValueId;
            ShortStringValue = value.ShortStringValue;
            LongStringValue = value.LongStringValue;
        }
    }
}

