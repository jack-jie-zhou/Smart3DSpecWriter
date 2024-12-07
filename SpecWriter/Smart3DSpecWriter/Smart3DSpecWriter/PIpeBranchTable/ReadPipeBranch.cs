using Microsoft.Office.Interop.Excel;
using Smart3DSpecWriter.PipeBranchTable;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace Smart3DSpecWriter.PipeBranchTable
{
    public class ReadPipeBranchTable

    {
        private static Microsoft.Office.Interop.Excel.Application _app = Globals.Smart3DAddIn.Application;
        private static readonly Worksheet _sheet = Globals.Smart3DAddIn.Application.ActiveSheet;
        private static PipeBranchSheet _pbSheet;

        public static void ReadSheet()
        {
            _pbSheet = new PipeBranchSheet(_sheet);
            if (!_pbSheet.IsValidPipeBranchSheet())
            {
                MessageBox.Show("Active sheet is not a valid PipeBranch sheet");
                return;
            }

            Range pmcRange = _pbSheet.SelectAllRowsOfPMC(_app.ActiveCell);

            if(_app.ActiveCell.Worksheet.Name.ToLower()!="pipebranch"|| pmcRange==null)
            {
                MessageBox.Show("Please select a PMC name on the PipeBranch Sheet");
                return;
            }
          //  Range rng3 = _app.Selection;
            PipeBranchRowList list = new PipeBranchRowList(pmcRange,_pbSheet);
            list.Dump();
            List<PipeBranchAngle> angleSets = list.GetAngleSets();
            foreach (PipeBranchAngle pipeBranchAngle  in angleSets)
            {
                //Worksheet sheet = list.GenerateTemporaryBranchSheet(pipeBranchAngle);
                WriteTemporaryPipeBranchSheet writer = new WriteTemporaryPipeBranchSheet(pipeBranchAngle, list);
            }
        }

        //public static void MakeSelection()
        //{
        //    //get current selected cell
        //    Range rng = _app.ActiveCell as Range;
        //    int row = rng.Row;
        //    int column = rng.Column;

        //    int nextPMCRowNumber = FindNextRowNumber(_sheet, "*", 2, row + 1);      //next PMC row
        //    int endRowNumber = FindLastRowNumber(_sheet, "end", 1);                 //"end" row number
        //    int last = FindLastRowNumberOfTheSheet(_sheet);                                   //last row of the sheet

        //    Range rng2 = null;
        //    if (nextPMCRowNumber > row)      //if No next PMC, nextPMCRowNumber will retart from top
        //    {
        //        rng2 = _sheet.Range[_sheet.Cells[row + 1, column + 1], _sheet.Cells[nextPMCRowNumber - 1, column + 9]];
        //    }
        //    else
        //    {
        //        if (endRowNumber != 0)
        //        {
        //            rng2 = _sheet.Range[_sheet.Cells[row + 1, column + 1], _sheet.Cells[endRowNumber - 1, column + 9]];
        //        }
        //        else
        //        {
        //            rng2 = _sheet.Range[_sheet.Cells[row + 1, column + 1], _sheet.Cells[last, column + 9]];
        //        }

        //    }
        //    rng2.Select();

        //  //  GenerateTemporarySheet();

        //}

        //private static void GenerateTemporarySheet()
        //{
        //    Range rng3 = _app.Selection;
        //    PipeBranchRowList list = new PipeBranchRowList(rng3);
        //    List<PipeBranchAngle> angles = list.GetAngleSets();

        //    string paString = angles[0];
        //    PipeBranchAngle pa1 = (PipeBranchAngle)paString;
        //    Worksheet sheet = list.GenerateTemporaryBranchSheet();
        //}

        //internal static void GenerateTemporaryPipeBranchSheet()
        //{
        //    //select pmc, system make a selection of the selected pmc.
        // //   MakeSelection();

        //    //using selection to generate the List and the Sheet
        //    //
        //    GenerateTemporarySheet();
        //}

        //private static int FindLastRowNumberOfTheSheet(Worksheet sheet)
        //{
        //    int row = sheet.Cells.SpecialCells(XlCellType.xlCellTypeLastCell, XlSpecialCellsValue.xlTextValues).Row;
        //    return row;
        //}
        //// if not found,will return 0
        //private static int FindLastRowNumber(Worksheet sheet, string strToFind, int ColumnNumber)
        //{
        //    try
        //    {
        //        if (ColumnNumber < 1)
        //        {
        //            return 0;
        //        }

        //        int row = sheet.Columns[ColumnNumber].Find(strToFind, Missing.Value, Missing.Value, Missing.Value, XlSearchOrder.xlByRows, XlSearchDirection.xlPrevious)?.Row ?? 0;
        //        return row;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}


        ////if not find NEXT, will restart from top
        //private static int FindNextRowNumber(Worksheet sheet, string strToFind, int ColumnNumber, int startingRowNumber)
        //{
        //    try
        //    {
        //        if (ColumnNumber < 1)
        //        {
        //            return 0;
        //        }

        //        int row = sheet.Columns[ColumnNumber].Find(strToFind,       //string or any excel object to find
        //            sheet.Cells[startingRowNumber, ColumnNumber],            //the cell after which your search begins
        //            XlFindLookIn.xlValues,                                  //value, formulars, comments, 
        //            XlLookAt.xlWhole,                                       //Whole, Part
        //            XlSearchOrder.xlByRows,
        //            XlSearchDirection.xlNext

        //            )?.Row ?? 0;
        //        return row;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}

/*
Parameter       Type        Description                                                                 Values
What            Required    The value you are searching for	                                            Any VBA data type e.g String, Long
After           Optional    A single cell range that you start your search from                         Range("A5")
LookIn          Optional    What to search in e.g.Formulas, Values or Comments                          xlValues, xlFormulas, xlComments
LookAt          Optional    Look at a part or the whole of the cell                                     xlWhole, xlPart
SearchOrder     Optional    The order to search                                                         xlByRows or xlByColumns.
SearchDirection Optional    The direction to search                                                     xlNext, xlPrevious
MatchCase       Optional    If search is case sensitive                                                 True or False
MatchByte       Optional    Used for double byte languages                                              True or False
SearchFormat    Optional    Allow searching by format.The format is set using Application.FindFormat	True or False
 */


