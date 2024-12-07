using Microsoft.Office.Interop.Excel;
using System;
using System.Reflection;

namespace Smart3DSpecWriter.Excel
{
    /// <summary>
    /// This class is used by PipeBranchSheet
    /// 
    /// </summary>
    public class SheetBase
    {
        public Worksheet WorkSheet { get; }

        public SheetBase(Worksheet workSheet)
        {
            WorkSheet = workSheet ?? throw new ArgumentNullException(nameof(workSheet));
        }

        public int HeadRowNumber => WorkSheet.Columns["A"].Find("HEAD")?.row ?? 0;  //if Find return null, return 0
        public int DefinitionRowNumber => WorkSheet.Columns["A"].Find("definition")?.row ?? 0; //not case sensitive
        public int StartRowNumber => WorkSheet.Columns["A"].Find("start").row ?? 0;
        public int EndRowNumber => WorkSheet.Columns["A"].Find("end").row ?? 0;
        public int LastColumnNumberOfRow(int rowNumber)
        {
            return WorkSheet.Rows[rowNumber]?.Find("*", Missing.Value, Missing.Value, Missing.Value, XlSearchOrder.xlByColumns, XlSearchDirection.xlPrevious)?.Column ?? 0;
        }
        public int LastRowNumberOfColumn(int columnNumber)
        {
            return WorkSheet.Columns[columnNumber]?.Find("*", Missing.Value, Missing.Value, Missing.Value, XlSearchOrder.xlByRows, XlSearchDirection.xlPrevious)?.Column ?? 0;
        }
        public int LastRowNumberOfSheet => WorkSheet.Cells.SpecialCells(XlCellType.xlCellTypeLastCell, XlSpecialCellsValue.xlTextValues).Row;

        public int LastColumnNumberOfSheet()
        {
            return WorkSheet.Cells.SpecialCells(XlCellType.xlCellTypeLastCell, XlSpecialCellsValue.xlTextValues).Column;
        }
        public bool IsEmptyOrCommentRow(int rowNumber)
        {
            string s = WorkSheet.Cells[rowNumber, 1].Value as string;
            if (s?.Trim() == "!")
            {
                return true;
            }

            try
            {
                int col = WorkSheet.Rows[rowNumber].Find("*", Missing.Value, Missing.Value, Missing.Value, XlSearchOrder.xlByColumns, XlSearchDirection.xlPrevious).Column;
                if (col > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return true;
            }
        }
        public int ColumnNumberOfData(int rowNumber, string dataString)
        {
            return WorkSheet.Rows[rowNumber].Find(dataString)?.row ?? 0;  //if Find return null, return 0
        }

        public int ColumnNumberOfHeadData(string HeadDataString)
        {
            int rowNumber = HeadRowNumber;
            if (rowNumber != 0)
            {
                return WorkSheet.Rows[rowNumber].Find(HeadDataString)?.column ?? 0;  //if Find return null, return 0
            }
            else
            {
                return 0;
            }
        }

        //

        /// <summary>
        ///     Next Row number with Data (not empty) in given column, starting serach from startingRowNumber
        /// </summary>
        /// <param name="strToFind"></param>
        /// <param name="ColumnNumber"></param>
        /// <param name="startingRowNumber"></param>
        /// <returns> NOTE: if not find NEXT, will restart from top</returns>
        public int FindNextRowNumberWithDataInColumn(string strToFind, int ColumnNumber, int startingRowNumber)
        {
            try
            {
                if (ColumnNumber < 1)
                {
                    return 0;
                }

                int row = WorkSheet.Columns[ColumnNumber].Find(strToFind,       //string or any excel object to find
                    WorkSheet.Cells[startingRowNumber, ColumnNumber],            //the cell after which your search begins
                    XlFindLookIn.xlValues,                                  //value, formulars, comments, 
                    XlLookAt.xlWhole,                                       //Whole, Part
                    XlSearchOrder.xlByRows,
                    XlSearchDirection.xlNext

                    )?.Row ?? 0;
                return row;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void FitRowsAndColumns()
        {
            //WorkSheet.Cells.Select();
            //WorkSheet.Selection().ColumnWidth = 36.29;
            WorkSheet.Cells.EntireColumn.AutoFit();
            WorkSheet.Cells.EntireRow.AutoFit();
        }

    }
}




