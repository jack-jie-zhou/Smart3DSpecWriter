using Microsoft.Office.Interop.Excel;
using System;
using System.Reflection;

namespace Smart3DSpecWriter.PipeBranchTable

{
    /// <summary>
    /// This class is used by PipeBranchSheet
    /// 
    /// </summary>
    public class SheetBase
    {
        /// <summary>
        /// worksheet
        /// </summary>
        public Worksheet WorkSheet { get; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="workSheet"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public SheetBase(Worksheet workSheet)
        {
            WorkSheet = workSheet ?? throw new ArgumentNullException(nameof(workSheet));
        }

        /// <summary>
        /// 'Head' row number
        /// </summary>
        public int HeadRowNumber => WorkSheet.Columns["A"].Find("HEAD")?.row ?? 0;  //if Find return null, return 0
        /// <summary>
        /// 'Definition' row number
        /// </summary>
        public int DefinitionRowNumber => WorkSheet.Columns["A"].Find("definition")?.row ?? 0; //not case sensitive
        /// <summary>
        /// 'start' row number
        /// </summary>
        public int StartRowNumber => WorkSheet.Columns["A"].Find("start").row ?? 0;
        /// <summary>
        /// 'end' row number
        /// </summary>
        public int EndRowNumber => WorkSheet.Columns["A"].Find("end").row ?? 0;
        /// <summary>
        /// last column number in selected 'row'
        /// </summary>
        /// <param name="rowNumber">-</param>
        /// <returns></returns>
        public int LastColumnNumberOfRow(int rowNumber)
        {
            return WorkSheet.Rows[rowNumber]?.Find("*", Missing.Value, Missing.Value, Missing.Value, XlSearchOrder.xlByColumns, XlSearchDirection.xlPrevious)?.Column ?? 0;
        }
        /// <summary>
        /// -
        /// </summary>
        /// <param name="columnNumber"><-/param>
        /// <returns></returns>
        public int LastRowNumberOfColumn(int columnNumber)
        {
            return WorkSheet.Columns[columnNumber]?.Find("*", Missing.Value, Missing.Value, Missing.Value, XlSearchOrder.xlByRows, XlSearchDirection.xlPrevious)?.Column ?? 0;
        }
        /// <summary>
        /// 
        /// -
        /// </summary>
        public int LastRowNumberOfSheet => WorkSheet.Cells.SpecialCells(XlCellType.xlCellTypeLastCell, XlSpecialCellsValue.xlTextValues).Row;

        /// <summary>
        /// -
        /// </summary>
        /// <returns></returns>
        public int LastColumnNumberOfSheet()
        {
            return WorkSheet.Cells.SpecialCells(XlCellType.xlCellTypeLastCell, XlSpecialCellsValue.xlTextValues).Column;
        }
        /// <summary>
        /// -
        /// </summary>
        /// <param name="rowNumber">-</param>
        /// <returns>-</returns>
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
        /// <summary>
        /// -
        /// </summary>
        /// <param name="rowNumber"></param>
        /// <param name="dataString"></param>
        /// <returns></returns>
        public int ColumnNumberOfData(int rowNumber, string dataString)
        {
            return WorkSheet.Rows[rowNumber].Find(dataString)?.row ?? 0;  //if Find return null, return 0
        }


        /// <summary>
        /// Return column number (int) from column Head data (col[1].value='Head')
        /// </summary>
        /// <param name="HeadDataString"></param>
        /// <returns>0 - if no 'Head' row in the sheet</returns>
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
        /// <param name="ColumnNumber">'SpacName' column number</param>
        /// <param name="startingRowNumber">'SpacName' row number +1</param>
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
                    WorkSheet.Cells[startingRowNumber, ColumnNumber],           //the cell after which your search begins
                    XlFindLookIn.xlValues,                                      //value, formulars, comments, 
                    XlLookAt.xlWhole,                                           //Whole, Part
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

        /// <summary>
        /// Fit width of cells in sheet
        /// </summary>
        public void FitRowsAndColumns()
        {
            //WorkSheet.Cells.Select();
            //WorkSheet.Selection().ColumnWidth = 36.29;
            WorkSheet.Cells.EntireColumn.AutoFit();
            WorkSheet.Cells.EntireRow.AutoFit();
        }

    }
}




