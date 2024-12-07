using Microsoft.Office.Interop.Excel;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;

namespace Smart3DSpecWriter.PipeBranchTable
{
    public class PipeBranchRowList : List<PipeBranchRow>
    {
        public string PMCName { get; }

        public PipeBranchRowList(Range range, PipeBranchSheet pbSheet)
        {
            Worksheet sheet = pbSheet.Sheet;
            PMCName = pbSheet.PMCName;
            if (range.Columns.Count != 9)
            {
                throw new ArgumentException("Invalid range used to build PipeBranchRow");
            };
            foreach (Range row in range.Rows)
            {
                int rowNumber = row.Row;
                //try
                //{
                //    PipeBranchRow pb = new PipeBranchRow
                //    {
                //        HeadSize = CellAsDouble(row.Cells[1, pbSheet.HeaderSizeColumnNumber].Value),
                //        BranchSize = CellAsDouble(row.Cells[1, pbSheet.BranchSizeColumnNumber].Value),
                //        Angle = new PipeBranchAngle(row.Cells[1, pbSheet.AngleHighColumnNumber].Value,
                //                                    row.Cells[1, pbSheet.AngleLowColumnNumber].Value),

                //        ShortCode = new PipeBranchShortCode(row.Cells[1, pbSheet.ShortCodeColumnNumber].Value,
                //                                           row.Cells[1, pbSheet.SecondaryShortCodeColumnNumber].Value ?? "",
                //                                           row.Cells[1, pbSheet.TertiaryShortCodeColumnNumber].Value ?? "")
                //    };
                //    pb.HeadUnitType = row.Cells[1, pbSheet.HdrSizeNPDUnitTypeColumnNumber].Value;
                //    pb.BranchUnitType = row.Cells[1, pbSheet.BrSizeNPDUnittypeColumnNumber].Value;
                //    Add(pb);
                //}
                try
                {
                    PipeBranchRow pb = new PipeBranchRow
                    {
                        HeadSize = CellAsDouble(sheet.Cells[rowNumber, pbSheet.HeaderSizeColumnNumber].Value),
                        BranchSize = CellAsDouble(sheet.Cells[rowNumber, pbSheet.BranchSizeColumnNumber].Value),
                        Angle = new PipeBranchAngle(sheet.Cells[rowNumber, pbSheet.AngleHighColumnNumber].Value,
                                                    sheet.Cells[rowNumber, pbSheet.AngleLowColumnNumber].Value),

                        ShortCode = new PipeBranchShortCode(sheet.Cells[rowNumber, pbSheet.ShortCodeColumnNumber].Value,
                                                           sheet.Cells[rowNumber, pbSheet.SecondaryShortCodeColumnNumber].Value ?? "",
                                                           sheet.Cells[rowNumber, pbSheet.TertiaryShortCodeColumnNumber].Value ?? "")
                    };
                    pb.HeadUnitType = sheet.Cells[rowNumber, pbSheet.HdrSizeNPDUnitTypeColumnNumber].Value;
                    pb.BranchUnitType = sheet.Cells[rowNumber, pbSheet.BrSizeNPDUnittypeColumnNumber].Value;
                    Add(pb);
                }
                catch (Exception ex)
                {
                    Log.Error("{0}", ex);
                    throw;
                }

            }
        }

        private double CellAsDouble(dynamic value)
        {
            if (value == null)
            {
                return -9999;
            }
            if (double.TryParse(value.ToString(), out double d))
            {
                return d;
            }
            else
            {
                return 0;
            }
        }

        public void Dump()
        {
            var ser = new JavaScriptSerializer();
            string s = ser.Serialize(this);
            File.WriteAllText("x123456.txt", s);
        }
    }
}
