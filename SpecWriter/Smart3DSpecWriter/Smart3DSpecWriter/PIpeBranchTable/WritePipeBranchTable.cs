using Microsoft.Office.Interop.Excel;
using Serilog;
using Smart3DSpecWriter.PipeBranchTable;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Smart3DSpecWriter.PipeBranchTable
{
    /// <summary>
    /// Write PipeBranch sheet with name 'TemporaryPipeBranch'
    /// </summary>
    public static class WritePipeBranchTable
    {
        /// <summary>
        /// Write list of PipeBranchRow to sheet "TemporaryPipeBranch"
        /// </summary>
        public static void WritePipeBranch()
        {
            List<PipeBranchRow> list = new List<PipeBranchRow>();

            try
            {
                Worksheet sheet = Globals.Smart3DAddIn.Application.Worksheets["TemporaryPipeBranch"];
                Range rng = sheet.Cells.SpecialCells(XlCellType.xlCellTypeLastCell, XlSpecialCellsValue.xlTextValues);
                int lastRow = rng.Row;
                int lastCol = rng.Column;
                for (int row = 2; row < lastRow; row++)
                {
                    for (int col = 2; col <= row; col++)
                    {
                        string code = sheet.Cells[row, col].Value;
                        (string sc, string sc2, string sc3) codes = GetCodes(code);
                        PipeBranchRow pb = new PipeBranchRow
                        {
                            HeadSize = (double)sheet.Cells[lastRow, col].Value,
                            BranchSize = (double)sheet.Cells[row, 1].Value,
                            //AngleHigh = "90.5deg",
                            //AngleLow = "89.5deg",
                            //ShortCode = codes.sc,
                            //ShortCode2 = codes.sc2,
                            //ShortCode3 = codes.sc3
                        };
                        list.Add(pb);
                    }
                }

                GenerateOutputPipeBranchSheet(list);
            }
            catch (Exception ex)
            {
                Log.Error("{0}", ex);
                throw;
            }
        }

        private static void GenerateOutputPipeBranchSheet(List<PipeBranchRow> list)
        {
            Worksheet sheet = Globals.Smart3DAddIn.Application.Worksheets.Add();
            sheet.Name = "OutputPipeBranch";
            AddHeader(sheet);
            AddContent(sheet, list, 90.0, "1C0031", "in");

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="list"></param>
        /// <param name="angle"></param>
        /// <param name="pmc"></param>
        /// <param name="unit"></param>
        private static void AddContent(Worksheet sheet, List<PipeBranchRow> list, double angle, string pmc, string unit)
        {
            try
            {
                int row = 5;
                sheet.Cells[3, 1].Value = "Start";
                sheet.Cells[4, 2].Value = pmc;
                list = list.OrderBy(n => n.HeadSize).ThenBy(n => n.BranchSize).ToList();

                (string high, string low) = GetAngles(angle);
                foreach (PipeBranchRow pb in list)
                {

                    sheet.Cells[row, 3].Value = pb.HeadSize;
                    sheet.Cells[row, 4].Value = pb.BranchSize;
                    sheet.Cells[row, 5].Value = low;
                    sheet.Cells[row, 6].Value = high;
                    sheet.Cells[row, 7].Value = unit;
                    sheet.Cells[row, 8].Value = unit;
                    sheet.Cells[row, 9].Value = pb.ShortCode;
                    //sheet.Cells[row, 10].Value = pb.ShortCode2;
                    //sheet.Cells[row, 11].Value = pb.ShortCode3;
                    row += 1;
                }
            }
            catch (Exception ex)
            {
                Log.Error("{0}", ex);
                throw;
            }

        }

        /// <summary>
        /// get sc,sc2,sc3 from string code
        /// </summary>
        /// <param name="code">-</param>
        /// <returns>-</returns>
        private static (string, string, string) GetCodes(string code)
        {
            string sc = "", sc2 = "", sc3 = "";
            string[] codes = code.Split('\n');
            if (codes.Length == 1)
            {
                sc = codes[0];
            }
            else if (codes.Length == 2)
            {
                sc = codes[0];
                sc2 = codes[1];
            }
            else if (codes.Length == 3)
            {
                sc = codes[0];
                sc2 = codes[1];
                sc3 = codes[3];
            }
            (string sc, string sc2, string sc3) r = (sc: sc, sc2: sc2, sc3: sc3);
            return r;
        }

        /// <summary>
        /// Get angle range from angle value, e.g. from 90 to 89.5 and 90.5
        /// </summary>
        /// <param name="angle">-</param>
        /// <returns>-</returns>
        private static (string, string) GetAngles(double angle)
        {
            (string high, string low) r = (high: "", low: "");
            r.high = string.Format($"{(angle + 0.5):0.0}deg");
            r.low = string.Format($"{(angle - 0.5):0.0}deg");
            return r;
        }


        /// <summary>
        /// Add Header row for branchtable sheet
        /// </summary>
        /// <param name="sheet">-</param>
        private static void AddHeader(Worksheet sheet)
        {
            sheet.Cells[1, 1].Value = "Head";
            sheet.Cells[1, 2].Value = "SpecName";
            sheet.Cells[1, 3].Value = "HeaderSize";
            sheet.Cells[1, 4].Value = "BranchSize";
            sheet.Cells[1, 5].Value = "AngleLow";
            sheet.Cells[1, 6].Value = "AngleHigh";
            sheet.Cells[1, 7].Value = "HdrSizeNPDUnitType";
            sheet.Cells[1, 8].Value = "BrSizeNPDUnitType";
            sheet.Cells[1, 9].Value = "ShortCode";
            sheet.Cells[1, 10].Value = "SecondaryShortCode";
            sheet.Cells[1, 11].Value = "TertiaryShortCode";
            sheet.Range["B1", "K1"].Orientation = XlOrientation.xlUpward;
            sheet.Range["B1", "K1"].Interior.Color = XlRgbColor.rgbGreenYellow;
        }
    }
}
