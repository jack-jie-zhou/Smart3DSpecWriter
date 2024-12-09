using CodelistLibrary;
using CodelistLibrary.Forms;
using NinjaNye.SearchExtensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Schema;

namespace WindowsFormsTestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bnDBConnTest_Click(object sender, EventArgs e)
        {
            //List<CodelistTableInfoView> tables = CodelistAPI.GetTopLevelTables();
            //foreach (CodelistTableInfoView table in tables)
            //{
            //    //Write to Output window
            //    Debug.WriteLine($"|{table.Name}|-|{table.ChildTableName}|");
            //}


            //CodelistValueView value = CodelistAPI.GetCLValueFromTableNameAndValueId("EquipmentTypes3", 325);

            //var tablelist = CodelistAPI.GetTableTreeFromTableName("SelectionBasis");
           // List<CodelistValueView> valuelist = CodelistAPI.GetValueTreeFromTableNameAndValueId("SelectionBasis", 75);

            var tablelist = CodelistAPI.GetTableTreeFromTableName("PipingCommodityType");

            //  List<CodelistValueView> valuelist = CodelistAPI.GetValueTreeFromTableNameAndValueId("EquipmentTypes6", 495);
           List<CodelistValueView> valuelist = CodelistAPI.GetValueTreeFromTableNameAndValueId("PipingCommodityType", 460);

            //foreach (var y in x)
            //{
            //    Debug.WriteLine($"{y.TableName}--{y.ValueId}--{y.ShortStringValue}--{y.LongStringValue}");
            //}

            frmCodelist frm = new frmCodelist();
            frm.populateTree(tablelist, "PipingCommodityType",valuelist);

            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        //https://github.com/ninjanye/SearchExtensions
        private void bnSearch_Click(object sender, EventArgs e)
        {
            string inputString = txtSearch.Text;
            string[] words = inputString.Split(' ').ToArray();
            //string concatenatedString = string.Join(",", words);
            //Console.WriteLine(concatenatedString);

            //string inputString = txtSearch.Text;
            //string[] words = inputString.Split(' ');

            //string concatenatedString = string.Join(", ", words.Select(word => $"\"{word}\""));

            //Console.WriteLine(concatenatedString);

            List<string> list = new List<string>();
            list.Add("gate");
            list.Add("DIN");

            var results = CodelistAPI.GetValueList("select * from CodelistValueView")
                .Search(x => x.LongStringValue, x => x.ShortStringValue, x => x.TableName)
                .SetCulture(StringComparison.CurrentCultureIgnoreCase)
                .ContainingAll(words)
                .Select(x => new { x.ValueId, x.TableName, x.ShortStringValue, x.LongStringValue });



            //string sql = $"select * from CodelistValueView where LongStringValue like '%{txtSearch.Text}%'";
            //var results = CodelistAPI._getValueList(sql).Select(x => new { x.ValueId, x.TableName,x.ShortStringValue, x.LongStringValue });
            dg1.DataSource = results.ToList();
            dg1.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dg1.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dg1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)  return ;





            int valueId = (int)dg1.Rows[e.RowIndex].Cells[0].Value;
            var tableName = dg1.Rows[e.RowIndex].Cells[1].Value.ToString();
            var tablelist = CodelistAPI.GetTableTreeFromTableName(tableName);

            List<CodelistValueView> valuelist = CodelistAPI.GetValueTreeFromTableNameAndValueId(tableName, valueId);
            frmCodelist frm = new frmCodelist();
            frm.populateTree(tablelist, tableName, valuelist);

            frm.ShowDialog();
        }

        private void dg1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bnOpenSearchForm_Click(object sender, EventArgs e)
        {
            frmGlobalSearch frm = new frmGlobalSearch();
            frm.ShowDialog(this);
        }
    }
}


