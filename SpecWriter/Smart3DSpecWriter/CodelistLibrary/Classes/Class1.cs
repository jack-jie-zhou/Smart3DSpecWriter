using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace CodelistLibrary
{
    public class Class1
    {
        static public void DBInfo()
        {
            MessageBox.Show("Hello");
            List<CodelistTableInfoView> tables = new List<CodelistTableInfoView>();
            using (IDbConnection db = new SQLiteConnection(ConnStr.Str()))
            {
                tables = db.Query<CodelistTableInfoView>("Select * from CodelistTableInfoView").ToList();
                MessageBox.Show(tables.Count.ToString());
            }
        }
    }
}


