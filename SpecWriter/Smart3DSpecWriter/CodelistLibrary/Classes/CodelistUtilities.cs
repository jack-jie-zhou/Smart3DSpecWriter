using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Windows.Forms;

namespace CodelistLibrary
{
    /// <summary>
    ///  Utilities of get codelist data
    /// </summary>
    public class CodelistUtilities
    {
        ///// <summary>
        ///// Get codelist table name from spec property name
        ///// </summary>
        ///// <param name="propertyName">spec property name</param>
        ///// <param name="partClassType">By default, it value is ""</param>
        ///// <returns>return null, if no table name is found</returns>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="partClassType"></param>
        /// <returns></returns>
        public static (string, bool) GetCodelistTableNameOLD(string propertyName, string partClassType = "")
        {
            string clTableName, sql;
            bool byShortDesc;
            if (partClassType == "")
            {
                sql = "select CodeListTableName,LookupByShortDescription from PropertyNameToCodeListMap where PropertyName='" + propertyName + "'";
            }
            else
            {
                sql = $"select CodeListTableName,LookupByShortDescription from PropertyNameToCodeListMap where PropertyName='{propertyName}' and PartClassType='{partClassType}'";
            }
            using (IDbConnection db = new SQLiteConnection(ConnStr.Str()))
            {
                (clTableName, byShortDesc) = db.Query<(string, bool)>(sql).FirstOrDefault();
                if (clTableName == null) { return (null, false); }
                return (clTableName, byShortDesc);
            }
        }

        /// <summary>
        ///  Get codelist table name and property value used to search the codelist table [by valueId (null), or by ShortDesc (true)]
        /// </summary>
        /// <param name="propertyName">-</param>
        /// <param name="partClassType">optional, default value is null</param>
        /// <returns>(clTableName, byShortDesc)</returns>
        public static (string, bool) GetCodelistTableName(string propertyName, string partClassType = null)
        {
            /*
             1. get record(s) from PropertyNameToCodeListMap table with inputs of propertyName
             2. if one record is found, return that record
             3. if more than one records are found, find the one with correct partClassType value and return it
             4. if more than one records are found, but cannot find the record with correct partClassType value ???
             5. if no records is found, return (null, false)
             */
            string clTableName, sql;
            bool byShortDesc;

            sql = "select CodeListTableName,LookupByShortDescription from PropertyNameToCodeListMap where PropertyName='" + propertyName + "'";

            using (IDbConnection db = new SQLiteConnection(ConnStr.Str()))
            {
                //1
                List<(string, bool)> records = db.Query<(string, bool)>(sql).ToList();

                //2
                if (records.Count == 1 ) { return records[0]; }

                //3
                if (records.Count > 1)
                {
                    for (int i = 0; i < records.Count; i++)
                    {
                        if (records[i].Item1.ToLower() == partClassType.ToLower())
                        {
                            return records[i];
                        }
                    }

                    //4
                    MessageBox.Show($"Find multiple records with propertyName={propertyName} but none of them contains partClassType={partClassType}");
                    return (null, false);
                }

                //5
                if (records.Count == 0)
                {
                    MessageBox.Show($"No record with propertyName={propertyName} found!");
                    return (null, false);
                }

                return (null, false);
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
