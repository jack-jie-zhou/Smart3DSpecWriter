using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;

namespace Smart3DSpecWriter.Utilities
{
    /// <summary>
    /// Get the names of all sheets in current file and put them into a String List
    /// </summary>
    internal class GetSheetNameFromBook
    {
        /// <summary>
        /// Get sheet names of current Excel file
        /// </summary>
        /// <param name="book">Workbook</param>
        /// <returns>Sheet Names</returns>
        
        public static List<string> GetSheetNames(Workbook book)
        {
            List<string> list = new List<string>();
            try
            {
                foreach (Worksheet worksheet in book.Sheets)
                {
                    list.Add(worksheet.Name);
                }
                return list;
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
