using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Diagnostics;
using System.Data.SQLite;
using Dapper;
using CodelistUserControl.DBClasses;

namespace CodelistUserControl
{
    public partial class CodelistUserControl : UserControl
    {
        public string OriginTableId { get; set; }
        public int OriginValueId { get; set; }
        public int SelectedValueId { get; set; }

        int _currentRowIndex = -1;
        List<TreeClass> _classes = new List<TreeClass>();
        List<CodelistTableInfoView> _tables;
        List<CodelistValueView> _initValues;
        List<ValueClass> _values;
        public CodelistUserControl()
        {
            InitializeComponent();
        }

        public void populateTree(List<CodelistTableInfoView> tables, List<CodelistValueView> values = null)
        {
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

        }


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



                var results = CodelistAPI._getValueList(sql).Select(
                    x => new ValueClass(x.ValueId, x.ShortStringValue, x.LongStringValue)
                    ).OrderBy(p => p.ValueId).ToList();
                dgCurrentTable.DataSource = results;
                _values = results;
                txtValuesFilter.Text = "";
                _currentRowIndex = e.RowIndex;
            }
        }


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
        }


        private void bnFilter_Click(object sender, EventArgs e)
        {
            if (_values == null) return;
            dgCurrentTable.DataSource = _values.Where(p => p.ShortStringValue.ToLower().Contains(txtValuesFilter.Text.ToLower()) || p.LongStringValue.ToLower().Contains(txtValuesFilter.Text.ToLower())).ToList();
        }


        private void bnReset_Click(object sender, EventArgs e)
        {
            if (_values == null) return;
            dgCurrentTable.DataSource = _values;
            txtValuesFilter.Text = "";
        }

        private void bnRestore_Click(object sender, EventArgs e)
        {
            dgCurrentTable.DataSource = null;
            txtValuesFilter.Text = "";
            dgTableValueList.DataSource = null;
            _currentRowIndex = -1;
            populateTree(_tables, _initValues);

        }
    }
}
