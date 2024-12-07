using CodelistUserControl.DBClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsTestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //List<CodelistTableInfoView> tables = CodelistAPI.GetTopLevelTables();
            //foreach (CodelistTableInfoView table in tables)
            //{
            //    //Write to Output window
            //    Debug.WriteLine($"|{table.Name}|-|{table.ChildTableName}|");
            //}


            //CodelistValueView value = CodelistAPI.GetCLValueFromTableNameAndValueId("EquipmentTypes3", 325);
            var tablelist = CodelistAPI.GetTableTreeFromTableName("SelectionBasis");

            //  List<CodelistValueView> valuelist = CodelistAPI.GetValueTreeFromTableNameAndValueId("EquipmentTypes6", 495);
            List<CodelistValueView> valuelist = CodelistAPI.GetValueTreeFromTableNameAndValueId("SelectionBasis", 75);
            //List<CodelistValueView> valuelist = CodelistAPI.GetValueTreeFromTableNameAndValueId("EquipmentTypes6", 400);

            //foreach (var y in x)
            //{
            //    Debug.WriteLine($"{y.TableName}--{y.ValueId}--{y.ShortStringValue}--{y.LongStringValue}");
            //}

            codelistUserControl1.populateTree(tablelist, valuelist);

            //frmCodelist frm = new frmCodelist();
            //frm.populateTree(tablelist, valuelist);

            //frm.ShowDialog();
        }
    }
}
