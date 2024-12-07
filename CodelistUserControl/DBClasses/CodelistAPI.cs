

using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using Dapper;
using System.Configuration;

namespace CodelistUserControl.DBClasses
{
    public class ConnStr
    {
        static public string Str()
        {
            return ConfigurationManager.ConnectionStrings["CodelistConnectionStr"].ConnectionString;
        }
    }

    public class CodelistAPI
    {
        static List<CodelistTableInfoView> _getTableList(string sql)
        {
            List<CodelistTableInfoView> tables = new List<CodelistTableInfoView>();
            using (IDbConnection db = new SQLiteConnection(ConnStr.Str()))
            {
                return db.Query<CodelistTableInfoView>(sql).ToList();
            }
        }

        static public List<CodelistValueView> _getValueList(string sql)
        {
            List<CodelistValueView> tables = new List<CodelistValueView>();
            using (IDbConnection db = new SQLiteConnection(ConnStr.Str()))
            {
                return db.Query<CodelistValueView>(sql).ToList();
            }
        }

        static CodelistValueView _getValue(string sql)
        {
            using (IDbConnection db = new SQLiteConnection(ConnStr.Str()))
            {
                var x = db.Query<CodelistValueView>(sql).FirstOrDefault();
                return x;
            }
        }
        static CodelistTableInfoView _getTable(string sql)
        {
            using (IDbConnection db = new SQLiteConnection(ConnStr.Str()))
            {
                return db.Query<CodelistTableInfoView>(sql).FirstOrDefault();
            }
        }
        static public List<CodelistTableInfoView> GetTopLevelTables()
        {
            string sql = "select * from CodelistTableInfoView where ParentTableID='00000000-0000-0000-0000-000000000000'";


            return _getTableList(sql);
        }

        static public CodelistValueView GetValueFromTableNameAndValueId(string tableName, int valueId)
        {
            string sql = $"select * from CodelistValueView where TableName='{tableName}' and ValueID={valueId}";
            return _getValue(sql);
        }
        static public CodelistTableInfoView GetTableFromTablename(string tablename)
        {
            string sql = $"select * from CodelistTableInfoView where Name ='{tablename}'";
            return _getTable(sql);
        }

        static public CodelistTableInfoView GetParentTableFromTablename(string tablename)
        {
            string sql = $"select * from CodelistTableInfoView where ChildTableName ='{tablename}'";
            return _getTable(sql);
        }

        static public CodelistTableInfoView GetChildrenTableFromTablename(string tablename)
        {
            string sql = $"select * from CodelistTableInfoView where ParentTableName ='{tablename}'";
            return _getTable(sql);
        }

        static public List<CodelistValueView> GetValueListFromTablename(string tableName)
        {
            string sql = $"select * from CodelistValueView where TableName ='{tableName}'";
            return _getValueList(sql);
        }

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
        static public List<CodelistValueView> GetValueTreeFromTableNameAndValueId(string tableName, int valueId)
        {
            LinkedList<CodelistValueView> linkedList = new LinkedList<CodelistValueView>();
            CodelistValueView currentValue = GetValueFromTableNameAndValueId(tableName, valueId);
            if (currentValue == null) return null;

            linkedList.AddLast(currentValue);
            //this is for adding children of current to the linked list
            LinkedListNode<CodelistValueView> childNode = linkedList.Find(currentValue);

            while (currentValue != null)
            {
                CodelistValueView parentValue = GetValueFromTableNameAndValueId(currentValue.ParentTableName, currentValue.ParentValueId);
                if (parentValue != null)
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
