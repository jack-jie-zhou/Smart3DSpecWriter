using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using Dapper;
using System.Configuration;

namespace CodelistLibrary
{
    /// <summary>
    /// Get connection to CDB.db
    /// </summary>
    public class ConnStr
    {
        /// <summary>
        /// Return connection string value of "YourConnectionStringName"
        /// </summary>
        /// <returns></returns>
        static public string Str()
        {
            return ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString;
        }
    }

    /// <summary>
    /// Codelist API
    /// </summary>
    public class CodelistAPI : CodelistAPIBase
    {
        /// <summary>
        /// Return tables with ParentTableID='00000000-0000-0000-0000-000000000000'
        /// </summary>
        /// <returns>list of tables</returns>
        static public List<CodelistTableInfoView> GetTopLevelTables()
        {
            string sql = "select * from CodelistTableInfoView where ParentTableID='00000000-0000-0000-0000-000000000000'";


            return GetTableList(sql);
        }

        /// <summary>
        /// return value by tableName and valueID
        /// </summary>
        /// <param name="tableName">table name</param>
        /// <param name="valueId">valueId</param>
        /// <returns>codelist value</returns>
        static public CodelistValueView GetValueFromTableNameAndValueId(string tableName, int valueId)
        {
            string sql = $"select * from CodelistValueView where TableName='{tableName}' and ValueID={valueId}";
            return GetValue(sql);
        }

        /// <summary>
        /// return A table by tablename
        /// </summary>
        /// <param name="tablename">table name</param>
        /// <returns>return table</returns>
        static public CodelistTableInfoView GetTableFromTablename(string tablename)
        {
            string sql = $"select * from CodelistTableInfoView where Name ='{tablename}'";
            return GetTable(sql);
        }


        /// <summary>
        /// get parent table from tablename
        /// </summary>
        /// <param name="tablename">table name</param>
        /// <returns>parent table</returns>
        static public CodelistTableInfoView GetParentTableFromTablename(string tablename)
        {
            string sql = $"select * from CodelistTableInfoView where ChildTableName ='{tablename}'";
            return GetTable(sql);
        }

        /// <summary>
        /// Get table by ParentTableName ='{tablename}'
        /// </summary>
        /// <param name="tablename">table name</param>
        /// <returns>table</returns>
        static public CodelistTableInfoView GetChildrenTableFromTablename(string tablename)
        {
            string sql = $"select * from CodelistTableInfoView where ParentTableName ='{tablename}'";
            return GetTable(sql);
        }

        /// <summary>
        /// Get values of a table by "tablename"
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        static public List<CodelistValueView> GetValueListFromTablename(string tableName)
        {
            string sql = $"select * from CodelistValueView where TableName ='{tableName}'";
            return GetValueList(sql);
        }

        /// <summary>
        /// Get all parent tables and children tables of current table by tablename
        /// </summary>
        /// <param name="tableName">tablename</param>
        /// <returns>list of tables from top to bottom</returns>
        static public List<CodelistTableInfoView> GetTableTreeFromTableName(string tableName)
        {
            LinkedList<CodelistTableInfoView> linkedList = new LinkedList<CodelistTableInfoView>();
            CodelistTableInfoView currentTable = GetTableFromTablename(tableName);

            linkedList.AddLast(currentTable);
            LinkedListNode<CodelistTableInfoView> childNode = linkedList.Find(currentTable);

            while (currentTable != null)
            {
                CodelistTableInfoView parentTable = GetParentTableFromTablename(currentTable.Name);
                if (parentTable != null)
                {
                    LinkedListNode<CodelistTableInfoView> currentNode = linkedList.Find(currentTable);
                    linkedList.AddBefore(currentNode, parentTable);
                }
                else
                {
                    break;
                }
                currentTable = parentTable;
            }

            currentTable = GetTableFromTablename(tableName);


            while (currentTable != null)
            {
                CodelistTableInfoView childTable = GetChildrenTableFromTablename(currentTable.Name);
                if (childTable != null)
                {
                    linkedList.AddAfter(childNode, childTable);
                    childNode = linkedList.Find(childTable);
                }
                currentTable = childTable;
            }

            return new List<CodelistTableInfoView>(linkedList);

        }

        /// <summary>
        /// Get list values from top to bottom tables with current table name and valueId
        /// </summary>
        /// <param name="tableName">table name</param>
        /// <param name="valueId">valueId</param>
        /// <returns></returns>
        static public List<CodelistValueView> GetValueTreeFromTableNameAndValueId(string tableName, int valueId)
        {
            LinkedList<CodelistValueView> linkedList = new LinkedList<CodelistValueView>();
            CodelistValueView currentValue =GetValueFromTableNameAndValueId(tableName, valueId);
            if (currentValue == null) return null;

            linkedList.AddLast(currentValue);
            //this is for adding children of current to the linked list
            LinkedListNode<CodelistValueView> childNode = linkedList.Find(currentValue);

            while (currentValue != null)
            {
                CodelistValueView parentValue = GetValueFromTableNameAndValueId(currentValue.ParentTableName, currentValue.ParentValueId);
                if(parentValue != null)
                {
                    LinkedListNode<CodelistValueView> currentNode = linkedList.Find(currentValue);
                    linkedList.AddBefore(currentNode, parentValue);
                }
                else
                {
                    break;
                }
                currentValue = parentValue;
            }

            return new List<CodelistValueView>(linkedList);
        }
    }

}
