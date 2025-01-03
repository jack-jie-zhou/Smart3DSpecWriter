using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodelistLibrary;
using Dapper;

namespace Smart3DSpecWriter.SpecTask
{


    /// <summary>
    /// Database utilities for spec writing tasks
    /// </summary>
    public class GetSpecTaskDbUtilities
    {
        /// <summary>
        /// get task categories
        /// </summary>
        /// <returns></returns>
        public static List<string> GetCategories()
        {
            using (IDbConnection db = new SQLiteConnection(ConnStr.Str()))
            {
                string sql = "select distinct CategoryName from SheetsCategory";
                return db.Query<string>(sql).ToList();
            }
        }

        /// <summary>
        /// Get sheetlist of given category
        /// </summary>
        /// <param name="category">Category Name</param>
        /// <returns>(DisplayName, SheetName)</returns>
        public static List<SheetStatus> GetSheetListOfCategory(string category)
        {
            using (IDbConnection db = new SQLiteConnection(ConnStr.Str()))
            {
                string sql = $"select DisplayName, SheetName from SheetsCategory where CategoryName='{category}'";
                return db.Query<SheetStatus>(sql).ToList();
            }
        }
    }
}
