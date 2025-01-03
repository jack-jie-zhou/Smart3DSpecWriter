using Microsoft.Office.Interop.Excel;
using Serilog;
using Smart3DSpecWriter.PipeBranchTable;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Smart3DSpecWriter.PipeBranchTable
{
    /// <summary>
    /// Extension function of class List &lt;PipeBranchRow&gt;
    /// </summary>
    public static class PipeBranchRowListExtension
    {
        public static double[] GetHeadSizes(this List<PipeBranchRow> list)
        {
            return list.Select(n => n.HeadSize).Distinct().ToArray();
        }

        public static double[] GetBranchSizes(this List<PipeBranchRow> list)
        {
            return list.Select(n => n.HeadSize).Distinct().ToArray();
        }

        public static List<PipeBranchAngle> GetAngleSets(this List<PipeBranchRow> list)
        {
            List<PipeBranchAngle> x = list.Select(n => new PipeBranchAngle(n.Angle.AngleHigh, n.Angle.AngleLow)).Distinct().ToList();
            return x;
        }



        public static string GetShortCode(this List<PipeBranchRow> list, double headSize, double branchSize)
        {
            //  PipeBranchRow x = list.Where(n => n.HeadSize == headSize && n.BranchSize == branchSize).FirstOrDefault();
            PipeBranchShortCode x = list.Where(n => n.HeadSize == headSize && n.BranchSize == branchSize).FirstOrDefault()?.ShortCode;
            //if (x != null)
            //{
            //    string x1 = x.ShortCode1 ?? "";
            //    if (!string.IsNullOrWhiteSpace(x.ShortCode2))
            //    {
            //        x1 = x1 + ",\n" + x.ShortCode2;
            //    }

            //    if (!string.IsNullOrWhiteSpace(x.ShortCode3))
            //    {
            //        x1 = x1 + ",\n" + x.ShortCode3;
            //    }

            //    return x1;
            //}
            if (x == null)
            {
                return "";
            }
            else
            {
                return x;
            }
        }

        public static Worksheet GenerateTemporaryBranchSheet(this List<PipeBranchRow> list, PipeBranchAngle angle)
        {
            try
            {
                Worksheet sheet = Globals.Smart3DAddIn.Application.Worksheets.Add();
                sheet.Name = "PB-" + angle;

                WriteTemporaryPipeBranchSheet(list, ref sheet);
                return sheet;
            }
            catch (System.Exception ex)
            {
                Log.Error("{0}", ex);
                MessageBox.Show(ex.Message);
                return null;
            }

        }


        //branch:                                   head:
        //rowNumber = [2...branchLength+1]          columnNumber=[2...headLength+1]
        //branchIndex=[0...branchLength-1]          headIndex =[0, headLength-1]
        //branchIndex=branchLength-rowNumber+1      headIndex=headLength -columnNumber +1
        private static void WriteTemporaryPipeBranchSheet(List<PipeBranchRow> list, ref Worksheet sheet)
        {
            list = list.OrderBy(n => n.HeadSize).ThenBy(n => n.BranchSize).ToList();
            double[] headSizes = GetHeadSizes(list);
            double[] branchSizes = GetBranchSizes(list);
            int headLength = headSizes.Length;
            int branchLength = branchSizes.Length;
            int branchIndex;
            int headIndex;

            sheet.Cells[1, 1].Value = "Branch";
            sheet.Cells[branchLength + 2, 1].Value = "Head";
            for (int row = 2; row <= branchLength + 1; row++)
            {
                branchIndex = branchLength - row + 1;
                sheet.Cells[row, 1].Value = branchSizes[branchIndex];
                sheet.Cells[row, 1].Interior.Color = XlRgbColor.rgbGreenYellow;
                for (int col = 2; col <= headLength + 1; col++)
                {
                    headIndex = headLength - col + 1;
                    sheet.Cells[branchLength + 2, col].Value = headSizes[headIndex];
                    sheet.Cells[branchLength + 2, col].Interior.Color = XlRgbColor.rgbGreenYellow;
                    string code;
                    try
                    {
                        code = GetShortCode(list, headSizes[headIndex], branchSizes[branchIndex]);

                    }
                    catch (System.Exception)
                    {

                        throw;
                    }
                    if (!string.IsNullOrWhiteSpace(code))
                    {
                        sheet.Cells[row, col].Value = code;
                        sheet.Cells[row, col].Style.WrapText = true;
                    }
                }
            }
            sheet.Activate();
            sheet.Application.ActiveWindow.SplitColumn = 1;
            sheet.Application.ActiveWindow.FreezePanes = true;
            sheet.Cells.ColumnWidth = 100;
            sheet.Cells.EntireColumn.AutoFit();
            sheet.Cells.EntireRow.AutoFit();
        }
    }
}
