using Microsoft.Office.Interop.Excel;
using Smart3DSpecWriter.Excel;
using System;

namespace Smart3DSpecWriter.PipeBranchTable
{
    public class PipeBranchSheet : SheetBase
    {
        private readonly Worksheet _sheet;
        public Worksheet Sheet => _sheet;

        public int SpecNameColumnNumber => ColumnNumberOfHeadData("SpecName");
        public int HeaderSizeColumnNumber => ColumnNumberOfHeadData("HeaderSize");
        public int BranchSizeColumnNumber => ColumnNumberOfHeadData("BranchSize");
        public int AngleHighColumnNumber => ColumnNumberOfHeadData("AngleHigh");
        public int AngleLowColumnNumber => ColumnNumberOfHeadData("AngleLow");
        public int HdrSizeNPDUnitTypeColumnNumber => ColumnNumberOfHeadData("HdrSizeNPDUnitType");
        public int BrSizeNPDUnittypeColumnNumber => ColumnNumberOfHeadData("BrSizeNPDUnittype");
        public int ShortCodeColumnNumber => ColumnNumberOfHeadData("ShortCode");
        public int SecondaryShortCodeColumnNumber => ColumnNumberOfHeadData("SecondaryShortCode");
        public int TertiaryShortCodeColumnNumber => ColumnNumberOfHeadData("TertiaryShortCode");

        public string PMCName { get; private set; }

        public bool IsValidPipeBranchSheet()
        {
            if (SpecNameColumnNumber == 0 ||
                HeaderSizeColumnNumber == 0 ||
                BranchSizeColumnNumber == 0 ||
                AngleHighColumnNumber == 0 ||
                AngleLowColumnNumber == 0 ||
                HdrSizeNPDUnitTypeColumnNumber == 0 ||
                BrSizeNPDUnittypeColumnNumber == 0 ||
                ShortCodeColumnNumber == 0 ||
                SecondaryShortCodeColumnNumber == 0 ||
                TertiaryShortCodeColumnNumber == 0
                )
            {
                return false;
            }
            else
            {
                if (_sheet.Cells[HeadRowNumber, SpecNameColumnNumber].Value.ToLower() != "specname")  //correct head information
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public PipeBranchSheet(Worksheet sheet) : base(sheet)
        {
            _sheet = sheet ?? throw new ArgumentNullException(nameof(sheet));
        }

        public Range SelectAllRowsOfPMC(Range pmcNameCell)
        {
            //get current selected cell
            //  Range pmcNameCell = _app.ActiveCell as Range;
            int row = pmcNameCell.Row;
            int column = pmcNameCell.Column;
            PMCName = pmcNameCell.Value?.ToString() ?? "";

            if (row < StartRowNumber || row > EndRowNumber)
            {
                return null;
            }

            if (column != ColumnNumberOfHeadData("SpecName"))
            {
                return null;
            }

            int nextPMCRowNumber = FindNextRowNumberWithDataInColumn("*", 2, row + 1);      //next PMC row
                                                                                            //  int EndRowNumber = FindLastRowNumber(_sheet, "end", 1);                 //"end" row number
                                                                                            //  int last = FindLastRowNumberOfTheSheet(_sheet);                                   //last row of the sheet

            Range rng2 = null;
            if (nextPMCRowNumber > row)      //if No next PMC, nextPMCRowNumber will retart from top
            {
                rng2 = _sheet.Range[_sheet.Cells[row + 1, column + 1], _sheet.Cells[nextPMCRowNumber - 1, column + 9]];
            }
            else
            {
                if (EndRowNumber != 0)
                {
                    rng2 = _sheet.Range[_sheet.Cells[row + 1, column + 1], _sheet.Cells[EndRowNumber - 1, column + 9]];
                }
                else
                {
                    rng2 = _sheet.Range[_sheet.Cells[row + 1, column + 1], _sheet.Cells[LastRowNumberOfSheet, column + 9]];
                }

            }
            rng2.Select();

            return rng2;

        }


    }
}
