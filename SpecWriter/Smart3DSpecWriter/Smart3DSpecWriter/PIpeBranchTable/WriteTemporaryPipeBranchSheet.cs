using Microsoft.Office.Interop.Excel;
using Serilog;
using Smart3DSpecWriter.PipeBranchTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart3DSpecWriter.PipeBranchTable
{
    public  class WriteTemporaryPipeBranchSheet
    {
        private readonly PipeBranchAngle _angle;
        private readonly List<PipeBranchRow> _list;

        public  WriteTemporaryPipeBranchSheet(PipeBranchAngle angle, List<PipeBranchRow> list)
        {
            this._angle = angle ?? throw new ArgumentNullException(nameof(angle));
            this._list = list ?? throw new ArgumentNullException(nameof(list));

            try
            {
                Worksheet sheet = Globals.Smart3DAddIn.Application.Worksheets.Add();
                sheet.Name = "PB-" + angle;

                WriteTemporaryPipeBranchSheet1(list, ref sheet);
              //  return sheet;
            }
            catch (System.Exception ex)
            {
                Log.Error("{0}", ex);
                System.Windows.Forms.MessageBox.Show(ex.Message);
              //  return null;
            }
        }



        //branch:                                   head:
        //rowNumber = [2...branchLength+1]          columnNumber=[2...headLength+1]
        //branchIndex=[0...branchLength-1]          headIndex =[0, headLength-1]
        //branchIndex=branchLength-rowNumber+1      headIndex=headLength -columnNumber +1
         void WriteTemporaryPipeBranchSheet1(List<PipeBranchRow> list, ref Worksheet sheet)
        {
            list = list.OrderBy(n => n.HeadSize).ThenBy(n => n.BranchSize).ToList();
         //   double[] headSizes = GetHeadSizes(list);
            double[] headSizes = list.GetHeadSizes();
          //  double[] branchSizes = GetBranchSizes(list);
            double[] branchSizes = list.GetBranchSizes();
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
                        code = list.GetShortCode(headSizes[headIndex], branchSizes[branchIndex]);

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
