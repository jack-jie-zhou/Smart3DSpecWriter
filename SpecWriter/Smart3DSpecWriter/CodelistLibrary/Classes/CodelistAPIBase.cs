using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace CodelistLibrary
{
    /// <summary>
    /// Base function for codelist API
    /// </summary>
    public class CodelistAPIBase
    {

        /// <summary>
        /// Get list of codelist values from sql
        /// </summary>
        /// <param name="sql">sql</param>
        /// <returns></returns>
        static public List<CodelistValueView> GetValueList(string sql)
        {
            List<CodelistValueView> tables = new List<CodelistValueView>();
            using (IDbConnection db = new SQLiteConnection(ConnStr.Str()))
            {
                return db.Query<CodelistValueView>(sql).ToList();
            }
        }
        /// <summary>
        /// Get a table information from sql
        /// </summary>
        /// <param name="sql">sql</param>
        /// <returns></returns>
        public static CodelistTableInfoView GetTable(string sql)
        {
            using (IDbConnection db = new SQLiteConnection(ConnStr.Str()))
            {
                return db.Query<CodelistTableInfoView>(sql).FirstOrDefault();
            }
        }

        /// <summary>
        ///  Get a list of table information from sql
        /// </summary>
        /// <param name="sql">sql</param>
        /// <returns></returns>
        public static List<CodelistTableInfoView> GetTableList(string sql)
        {
            List<CodelistTableInfoView> tables = new List<CodelistTableInfoView>();
            using (IDbConnection db = new SQLiteConnection(ConnStr.Str()))
            {
                return db.Query<CodelistTableInfoView>(sql).ToList();
            }
        }

        /// <summary>
        /// Get a codelist value record from sql
        /// </summary>
        /// <param name="sql">sql</param>
        /// <returns></returns>
        public static CodelistValueView GetValue(string sql)
        {
            using (IDbConnection db = new SQLiteConnection(ConnStr.Str()))
            {
                var x = db.Query<CodelistValueView>(sql).FirstOrDefault();
                return x;
            }
        }
    }
}