using Microsoft.Office.Interop.Excel;
using Serilog;
using Smart3DSpecWriter.Excel;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Smart3DSpecWriter.Excel
{
    /// <summary>
    /// This is the generic sheet info class used by controls
    /// </summary>
    /// <remarks> remarks</remarks>
    public class SheetInfo
    {
        /// <summary>
        /// Excel Sheet name
        /// </summary>
        //sheet
        public string SheetName { get; private set; }
        /// <summary>
        /// Reference to current worksheet
        /// </summary>
        private Worksheet _sheet;

        //row and column numbers
        /// <summary>
        /// Row number of "Definition" in Column A; or 0 if not found
        /// </summary>
        public int DefinitionRowNumber { get; set; }

        /// <summary>
        /// Row number of "Head" in Column A; or 0 if not found
        /// </summary>
        public int HeadRowNumber { get; set; }

        /// <summary>
        /// Row Number of "Start" in Column A; or 0 if not found
        /// </summary>
        public int StartRowNumber { get; set; }

        /// <summary>
        /// Row Number of "End" in Column A; 
        /// <para>If no "End" found, it will return the Row number of last cell which contains Text</para>
        /// </summary>
        public int EndRowNumber { get; set; }

        /// <summary>
        /// The number of last column in defintion row
        /// </summary>
        public int DefinitionLastColumnNumber { get; set; }

        /// <summary>
        /// The number of the last column in detail section
        /// </summary>
        public int DetailLastColumnNumber { get; set; }

        //Definition row and Current Detail row info
        /// <summary>
        /// The cells infomation of the title row of detail section
        /// </summary>
        public List<CellInfo> DetailTitleRowInformation => ReadDetailsTitleRow();

        /// <summary>
        /// The cells information of the definition title row
        /// </summary>
        public List<CellInfo> DefinitionRowInfomation => ReadDefinitionRow();

        /// <summary>
        /// The Value of the PartClassType in Definition Row. e.g. "PipeComponentClass", "ValveOperatorClass", "PipeStockClass"
        /// </summary>
        public string PartClassType { get; internal set; }

        /// <summary>
        /// Get current SheetInfo data by calling "GetSheetRowAndColumnInformation"
        /// </summary>
        /// <param name="sheet"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public SheetInfo(Worksheet sheet)
        {
            _sheet = sheet ?? throw new ArgumentNullException(nameof(sheet));
            GetSheetRowAndColumnInformation();

        }


        /// <summary>
        /// <para>Get the following properties for SheetInfo in a worksheet</para>
        /// <para> Head, Defintion, Start, End, DefinitionLasColumnNumber, DetailastColumnNumber, EndRowNumber</para>
        /// </summary>
        private void GetSheetRowAndColumnInformation()
        {
            try
            {
                //row and column number start from 1.
                //if not found, return null
                HeadRowNumber = _sheet.Columns["A"].Find("HEAD")?.row ?? 0;  //if Find return null, return 0
                DefinitionRowNumber = _sheet.Columns["A"].Find("definition")?.row ?? 0;
                StartRowNumber = _sheet.Columns["A"].Find("start").row ?? 0;
                EndRowNumber = _sheet.Columns["A"].Find("end").row ?? 0;

                //Rows[0] will thorw exception, so need to test before using it.
                if (DefinitionRowNumber != 0)
                {
                    //find by column, from right to left, will get last cell from right. it's column number is the last column number of the row.
                    DefinitionLastColumnNumber = _sheet.Rows[DefinitionRowNumber]?.Find("*", Missing.Value, Missing.Value, Missing.Value, XlSearchOrder.xlByColumns, XlSearchDirection.xlPrevious)?.Column ?? 0;
                }
                if (HeadRowNumber != 0)
                {
                    DetailLastColumnNumber = _sheet.Rows[HeadRowNumber].Find("*", Missing.Value, Missing.Value, Missing.Value, XlSearchOrder.xlByColumns, XlSearchDirection.xlPrevious)?.Column ?? 0;
                }

                if (EndRowNumber == 0)
                {
                    EndRowNumber = _sheet.Cells.SpecialCells(XlCellType.xlCellTypeLastCell, XlSpecialCellsValue.xlTextValues).Row;
                }
            }
            catch (Exception ex)
            {
                Log.Error("GetSheetRowAndColumnInformation[{0}]-[{1}]", _sheet.Name, ex);
                //throw;
            }
        }

        /// <summary>
        /// if the row is empty(no text in the row), return true
        /// </summary>
        /// <param name="rowNumber"></param>
        /// <returns></returns>
        private bool IsEmptyRow(int rowNumber)
        {
            string s = _sheet.Cells[rowNumber, 1].Value as string;
            if (s?.Trim() == "!")
            {
                return true;
            }

            try
            {
                int col = _sheet.Rows[rowNumber].Find("*", Missing.Value, Missing.Value, Missing.Value, XlSearchOrder.xlByColumns, XlSearchDirection.xlPrevious).Column;
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
        ///  Read the data value of definition row. Jump the comment and empty rows. 
        /// </summary>
        /// <returns>if definition row contains no data, or it is empty, return null. or List(CellInfo) </returns>
        public List<CellInfo> ReadDefinitionRow()
        {
            List<CellInfo> list = new List<CellInfo>();
            try
            {
                for (int r = DefinitionRowNumber + 1; r < HeadRowNumber - 1; r++)
                {
                    //skip comment lines
                    if (IsEmptyRow(r))
                    {
                        continue;
                    }

                    //read
                    for (int cc = 2; cc <= DefinitionLastColumnNumber; cc++)
                    {
                        CellInfo cellInfo = new CellInfo
                        {
                            Row = r,
                            Column = cc,
                            Name = _sheet.Cells[DefinitionRowNumber, cc]?.Value??"",
                            Value = _sheet.Cells[r, cc].Value ?? ""
                        };
                        if (cellInfo.Name.ToUpper() == "PARTCLASSTYPE")
                        {
                            PartClassType = cellInfo.Value ?? "";
                        }
                        list.Add(cellInfo);
                    }
                    if (list.Count == 0)
                    {
                        return null;
                    }
                    else
                    {
                        return list;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Log.Error("{0}", ex);
                throw;
            }
        }

        /// <summary>
        /// Read title informatio of the detail section
        /// </summary>
        /// <returns></returns>
        public List<CellInfo> ReadDetailsTitleRow()
        {
            List<CellInfo> list = new List<CellInfo>();
            try
            {
                for (int col = 2; col <= DetailLastColumnNumber; col++)
                {
                    CellInfo cell = new CellInfo
                    {
                        Row = HeadRowNumber,
                        Column = col,
                        Name = _sheet.Cells[HeadRowNumber, col].Value
                    };
                    list.Add(cell);
                }
                return list;
            }
            catch (Exception ex)
            {
                Log.Error("{0}", ex);
                throw;
            }
        }

        /// <summary>
        /// read the data in detail section of selected row
        /// </summary>
        /// <param name="row">current select row</param>
        /// <returns>return null on error</returns>
        public List<CellInfo> ReadDetailsRow(int row)
        {
            List<CellInfo> rowInfo = DetailTitleRowInformation;
            try
            {
                for (int c = 2; c <= DetailLastColumnNumber; c++)
                {
                    CellInfo cell = rowInfo[c - 2];
                    if (row <= HeadRowNumber || row >= EndRowNumber)
                    {
                        cell.Value = "";
                        cell.Row = row;
                    }
                    else
                    {
                        if (_sheet.Cells[row, c].Value == null)
                        {
                            cell.Value = null;
                            cell.Row = row;
                        }
                        else
                        {
                            cell.Value = _sheet.Cells[row, c].Value.ToString();
                            cell.Row = row;
                        }

                    }
                }
                return rowInfo;
            }
            catch (Exception ex)
            {
                Log.Error("{0}", ex);
                return null;
                //  throw;
            }

        }

    }
}

