using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CommodityCodeBuilder
{
    public static class ExcelHelper
    {
        public static Application GetApplication()
        {
            Application app;
            try
            {
                Type t = Type.GetTypeFromProgID("Excel.Application");
                if (t == null)
                {
                    throw new Exception("Excel is not installed");
                }

                object o = null;
                try
                {
                    o = Marshal.GetActiveObject("Excel.Application");
                }
                catch (Exception)
                {
                }
                if (o == null)
                {
                    app = Activator.CreateInstance(t) as Application;
                }
                else
                {
                    app = (Application)o;
                }
                app.DisplayAlerts = false;
                return app;
            }
            catch (Exception e1)
            {
                throw e1;
            }
        }

        public static Workbook OpenWorkbook(string fileName)
        {
            Application app = GetApplication();
            Workbook book;
            try
            {
                book = app.Workbooks.Open(fileName, false, ReadOnly: true);
                return book;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<string> SheetName(string fileName)
        {
            Workbook book;
            List<string> names = new List<string>();
            try
            {
                book = OpenWorkbook(fileName);
                Sheets Sheets = book.Worksheets;
                for (int i = 1; i <= Sheets.Count; i++)
                {
                    string s = Sheets[i].Name;
                    names.Add(s);
                }
                book.Close();
                return names;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void KillExcel()
        {
            try
            {
                try
                {
                    foreach (Process proc in Process.GetProcessesByName("excel"))
                    {
                        proc.Kill();
                    }
                }
                catch (Exception)
                {
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
