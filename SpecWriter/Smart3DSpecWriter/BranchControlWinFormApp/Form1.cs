using BranchControlWinFormApp.DataSource;
using BranchControlWinFormApp.DataSource.S3DCatDataSetTableAdapters;
using BranchControlWinFormApp.TestingClasses;
using Smart3DSpecWriter.PipeBranchTable;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BranchControlWinFormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /*
         explain:
         1. table contains completed list of NPDs
         2. rowList contains sub list of NPDs
         3. the table are converted to List<SelectedSize> during the process
         4. MarkSelected extension mark the completed rowList of NPDs with the ones that contained in the list.
             
             */
        private void Button1_Click(object sender, EventArgs e)
        {
            PipeNominalDiametersTableAdapter a = new PipeNominalDiametersTableAdapter();
            //List<S3DCatDataSet.PipeNominalDiametersRow> fullList = a.GetEnglishList().AsEnumerable<S3DCatDataSet.PipeNominalDiametersRow>().Where(n => n.Npd > 10).
            //    ToList<S3DCatDataSet.PipeNominalDiametersRow>();


            S3DCatDataSet.PipeNominalDiametersDataTable table = a.GetEnglishList();
            PipeBranchRowList rowList = BuildPipeBranchRowList.BuildList();
            //double[] headSizes = rowList.Select(n => n.HeadSize).OrderBy(n => n).Distinct().ToArray();


            List<SelectedSize> x = table.ABB(rowList);

            dg1.DataSource = x;
        }
    }

    public static class NPDTableEtension
    {
        public static List<SelectedSize> ABB(this S3DCatDataSet.PipeNominalDiametersDataTable table, PipeBranchRowList rowList)
        {
            //[1] transform from PipeNominalDiametersDataTabe to List<SelectedSize>
            //[2] rowList is used as Captured Outer variable. ***use the value at runtime, not CAPTURED time.
            List<SelectedSize> x = table.AsEnumerable().Select(n => new SelectedSize { Size = n.Npd }).MarkSelected(n => rowList.Select(m => m.HeadSize).Contains(n.Size)).ToList();
            x.Dump();
            return x;
        }
    }

    public class SelectedSize
    {
        public bool Selected { get; set; }
        public double Size { get; set; }
    }


    public static class SelectedSizeExtension
    {

        // 1. the returned type should be the same as input IEnumerable<T> type, so the Enumertion can continue.
        // 2. the extension method can capture the outer variables, PipeBranchRowList in this example and use it in predicate
        public static IEnumerable<SelectedSize> MarkSelected(this IEnumerable<SelectedSize> list, Func<SelectedSize, bool> predicate)
        {
            foreach (SelectedSize item in list)
            {
                if (predicate(item))
                {
                    item.Selected = true;
                }
                yield return item;
            }
        }

        //calling: list.Dump();
        public static void Dump(this IEnumerable<SelectedSize> list)
        {
            foreach (SelectedSize item in list)
            {
                Console.WriteLine($"{item.Selected}    {item.Size}");
            }
        }
    }




}
