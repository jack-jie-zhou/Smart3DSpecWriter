using NinjaNye.SearchExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodelistLibrary
{
    /// <summary>
    /// Global Search Form 
    /// </summary>
    public partial class frmGlobalSearch : Form
    {
        /// <summary>
        /// Search result is a CodelistTableInfoView record(true) or CodelistValueView(false)
        /// </summary>
        bool _searchTableName = false;
        public frmGlobalSearch()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Search button
        /// </summary>
        /// <param name="sender">-</param>
        /// <param name="e">-</param>
        private void bnSearch_Click(object sender, EventArgs e)
        {
            string inputString = txtSearch.Text;
            string[] words = inputString.Split(' ').ToArray();

            List<string> list = new List<string>();
            list.Add("gate");
            list.Add("DIN");
            if (chkTableName.Checked && chkTableValues.Checked)
            {
                var results = CodelistAPI.GetValueList("select * from CodelistValueView")
                    .Search(x => x.LongStringValue, x => x.ShortStringValue, x => x.TableName, x=>x.ValueId.ToString())
                    .SetCulture(StringComparison.CurrentCultureIgnoreCase)
                    .ContainingAll(words)
                    .Select(x => new { x.ValueId, x.TableName, x.ShortStringValue, x.LongStringValue });

                dg1.DataSource = results.ToList();
                dg1.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dg1.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            if (chkTableName.Checked && !chkTableValues.Checked)
            {
                var results = CodelistAPI.GetTableList("select * from CodelistTableInfoView")
                    .Search(x => x.Name)
                    .SetCulture(StringComparison.CurrentCultureIgnoreCase)
                    .ContainingAll(words)
                    .Select(x => new { x.Name });

                dg1.DataSource = results.ToList();
                _searchTableName = true;
                //dg1.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dg1.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            if (!chkTableName.Checked && chkTableValues.Checked)
            {
                var results = CodelistAPI.GetValueList("select * from CodelistValueView")
                    .Search(x => x.TableName)
                    .SetCulture(StringComparison.CurrentCultureIgnoreCase)
                    .ContainingAll(words)
                    .Select(x => new { x.ValueId, x.TableName, x.ShortStringValue, x.LongStringValue });

                dg1.DataSource = results.ToList();
                dg1.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dg1.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }

        }

        /// <summary>
        /// Select the row to open frmCodelist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dg1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            //chktableName.checked=false
            if (_searchTableName == false)
            {

                int valueId = (int)dg1.Rows[e.RowIndex].Cells[0].Value;
                var tableName = dg1.Rows[e.RowIndex].Cells[1].Value.ToString();
                var tablelist = CodelistAPI.GetTableTreeFromTableName(tableName);

                List<CodelistValueView> valuelist = CodelistAPI.GetValueTreeFromTableNameAndValueId(tableName, valueId);
                frmCodelist frm = new frmCodelist();
                frm.populateTree(tablelist, tableName, valuelist);

                frm.ShowDialog();
            }
            //chkTableName.checked=true
            if (_searchTableName == true)
            {

               // int valueId = (int)dg1.Rows[e.RowIndex].Cells[0].Value;
                var tableName = dg1.Rows[e.RowIndex].Cells[0].Value.ToString();
                var tablelist = CodelistAPI.GetTableTreeFromTableName(tableName);

              //  List<CodelistValueView> valuelist = CodelistAPI.GetValueTreeFromTableNameAndValueId(tableName, valueId);
                frmCodelist frm = new frmCodelist();
                frm.populateTree(tablelist, tableName);

                frm.ShowDialog();
            }
        }
    }
}
