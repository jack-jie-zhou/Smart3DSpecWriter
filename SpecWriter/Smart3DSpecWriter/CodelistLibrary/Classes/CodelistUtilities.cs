using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace CodelistLibrary
{
    /// <summary>
    ///  Utilities of get codelist data
    /// </summary>
    public class CodelistUtilities
    {
        /// <summary>
        /// Get codelist table name from spec property name
        /// </summary>
        /// <param name="propertyName">spec property name</param>
        /// <param name="partClassType">By default, it value is ""</param>
        /// <returns>return null, if no table name is found</returns>
        public static string GetCodelistTableName(string propertyName, string partClassType = "")
        {
            string clTableName, sql;
            if (partClassType == "")
            {
                sql = "select CodeListTableName from PropertyNameToCodeListMap where PropertyName='" + propertyName + "'";
            }
            else
            {
                sql = $"select CodeListTableName from PropertyNameToCodeListMap where PropertyName='{propertyName}' and PartClassType='{partClassType}'";
            }
            using (IDbConnection db = new SQLiteConnection(ConnStr.Str()))
            {
                clTableName = db.Query<string>(sql).FirstOrDefault();
                if (clTableName == null) { return null; }
                return clTableName;
            }
        }
        /// <summary>
        /// <para>1. Find codelist table name from "PropertyNameToCodeListMap" </para>
        /// <para>2. Find CodelistValueView by using tablename and valudID </para>
        /// <para> </para>
        /// <para> </para>
        /// <para> </para>
        /// </summary>
        /// <param name="propertyName">Spec proertyName</param>
        /// <param name="valueID">valueID (如果此值可以被转为整数，则此值代表valueId, 如此值为一个无法转为整数的字符串，则代表shortStringValue)</param>
        /// <returns>Return null if no table is found</returns>
        public static CodelistValueView CodelistLookup(string propertyName, string valueID)
        {
            string clTableName;
            string sql = "select CodeListTableName from PropertyNameToCodeListMap where PropertyName='" + propertyName + "'";
            var xx = ConnStr.Str();
            using (IDbConnection db = new SQLiteConnection(ConnStr.Str()))
            {
                clTableName = db.Query<string>(sql).FirstOrDefault();
                if (clTableName == null) { return null; }

                string sql1;
                int number;
                if (int.TryParse(valueID, out number))
                {
                    sql1 = $"select * from CodelistValueView where TableName='{clTableName}' and ValueID={number}";
                }
                else
                {
                    sql1 = $"select * from CodelistValueView where TableName='{clTableName}' and shortStringValue='{valueID}'";
                }

                return db.Query<CodelistValueView>(sql1).FirstOrDefault();
            }
        }
    }
}
