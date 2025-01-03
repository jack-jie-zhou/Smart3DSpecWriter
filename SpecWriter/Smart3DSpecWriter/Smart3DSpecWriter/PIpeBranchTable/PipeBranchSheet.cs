using Microsoft.Office.Interop.Excel;
using Smart3DSpecWriter.Excel;
using System;

namespace Smart3DSpecWriter.PipeBranchTable
{
    /// <summary>
    /// Pipe Branch Sheet functions
    /// </summary>
    public class PipeBranchSheet : SheetBase
    {
        /// <summary>
        /// worksheet 
        /// </summary>
        private readonly Worksheet _sheet;

        /// <summary>
        /// worksheet 
        /// </summary>
        public Worksheet Sheet => _sheet;

        /// <summary>
        /// column number (int) of the column with data in 'Head' as 'SpecName' 
        /// </summary>
        public int SpecNameColumnNumber => ColumnNumberOfHeadData("SpecName");
        /// <summary>
        /// column number (int) of the column with data in 'Head' as 'HeaderSize' 
        /// </summary>
        public int HeaderSizeColumnNumber => ColumnNumberOfHeadData("HeaderSize");
        /// <summary>
        /// column number (int) of the column with data in 'Head' as 'BranchSize' 
        /// </summary>
        public int BranchSizeColumnNumber => ColumnNumberOfHeadData("BranchSize");
        /// <summary>
        /// column number (int) of the column with data in 'Head' as 'AngleHigh' 
        /// </summary>
        public int AngleHighColumnNumber => ColumnNumberOfHeadData("AngleHigh");
        /// <summary>
        /// column number (int) of the column with data in 'Head' as 'AngleLow' 
        /// </summary>
        public int AngleLowColumnNumber => ColumnNumberOfHeadData("AngleLow");
        /// <summary>
        /// column number (int) of the column with data in 'Head' as 'HdrSizeNPDUnitType' 
        /// </summary>
        public int HdrSizeNPDUnitTypeColumnNumber => ColumnNumberOfHeadData("HdrSizeNPDUnitType");
        /// <summary>
        /// column number (int) of the column with data in 'Head' as 'BrSizeNPDUnittype' 
        /// </summary>
        public int BrSizeNPDUnittypeColumnNumber => ColumnNumberOfHeadData("BrSizeNPDUnittype");
        /// <summary>
        /// column number (int) of the column with data in 'Head' as 'SpecName' 
        /// </summary>
        public int ShortCodeColumnNumber => ColumnNumberOfHeadData("SecondaryShortCode");
        /// <summary>
        /// column number (int) of the column with data in 'Head' as 'SpecName' 
        /// </summary>
        public int SecondaryShortCodeColumnNumber => ColumnNumberOfHeadData("SecondaryShortCode");
        /// <summary>
        /// column number (int) of the column with data in 'Head' as 'TertiaryShortCode' 
        /// </summary>
        public int TertiaryShortCodeColumnNumber => ColumnNumberOfHeadData("TertiaryShortCode");

        public string PMCName { get; private set; }

        /// <summary>
        /// Check if the sheet is a branch table sheet
        /// </summary>
        /// <returns>true/false</returns>
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
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="sheet"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public PipeBranchSheet(Worksheet sheet) : base(sheet)
        {
            _sheet = sheet ?? throw new ArgumentNullException(nameof(sheet));
        }

        /// <summary>
        /// Select all rows that belong to the selected pmc
        /// </summary>
        /// <param name="pmcNameCell">cell contains the select pmc name</param>
        /// <returns></returns>
        public Range SelectAllRowsOfPMC(Range pmcNameCell)
        {
            //get current selected cell
            //  Range pmcNameCell = _app.ActiveCell as Range;
            int row = pmcNameCell.Row;
            int column = pmcNameCell.Column;

            // PMCName can be assigned as null, or ""
            // PMCName is a public property of this clas
            PMCName = pmcNameCell.Value?.ToString() ?? "";

            //row number with 'start'/'end' as value of first column.
            if (row < StartRowNumber || row > EndRowNumber)
            {
                return null;
            }

            //the column number of 'SpecName' in head row
            if (column != ColumnNumberOfHeadData("SpecName"))
            {
                return null;
            }

            int nextPMCRowNumber = FindNextRowNumberWithDataInColumn("*", 2, row + 1);
            //next PMC row
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
