
using CommodityCodeBuilder;
using Microsoft.Office.Interop.Excel;
using Smart3DSpecWriter.PipeBranchTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranchControlWinFormApp.TestingClasses
{
    public static class BuildPipeBranchRowList
    {
        public static PipeBranchRowList BuildList()
        {
            string fileName = @"C:\Compass 2016\CatalogData_src\mroot\CatalogData\BulkLoad\DataFiles\Ten_Specs_SpecificationData.xls";
            Workbook book = ExcelHelper.OpenWorkbook(fileName);
            Worksheet sheet = book.Worksheets["PipeBranch"];
            //Range activeCell = sheet.Cells[1342, 2];
            PipeBranchSheet pbSheet = new PipeBranchSheet(sheet);
            //Range pmcRange = pbSheet.SelectAllRowsOfPMC(activeCell);
            Range pmcRange = pbSheet.Sheet.Range["C1343", "K1363"];
            PipeBranchRowList list = new PipeBranchRowList(pmcRange, pbSheet);
            return list;

        }
    }
}
