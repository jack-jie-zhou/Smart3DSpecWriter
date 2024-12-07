// See https://aka.ms/new-console-template for more information
using System.Data.SQLite;
using System.Reflection;
//using dbtrans.siteModel;

using Microsoft.EntityFrameworkCore;

// Console.WriteLine("Hello");
// ClearSqliteDb("CDB.db");
// var dbSource =new Sp3dtrainCdbSchemaContext();
// var dbTarget =new SQliteCdbSchemaContext();
// CopyDbSets(dbSource,dbTarget);
DataTransfer.DataTransfer.run();

void CopyDbSets(DbContext dbSource, DbContext dbDest)
{
    //DbSet is the property if DbContext
    //DbSet<Application> is a generic Type
    IEnumerable<PropertyInfo> dbSetProperties1 = dbSource.GetType().GetProperties()
        .Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>));
    foreach (PropertyInfo dbSetInstanceFromSourceContext in dbSetProperties1)
    {
        //dbSet<Application> --> Type of the dbSet --> Application
        var entityType = dbSetInstanceFromSourceContext.PropertyType.GetGenericArguments()[0];
        var property2 = dbDest.GetType().GetProperty(dbSetInstanceFromSourceContext.Name);
        if (property2 != null && property2.PropertyType == dbSetInstanceFromSourceContext.PropertyType)
        {
            var dbSet1 = dbSetInstanceFromSourceContext.GetValue(dbSource, null);
            var dbSet2 = property2.GetValue(dbDest, null);
            
            foreach (var entity in (IEnumerable<object>)dbSet1)
            {
                dbSet2.GetType().GetMethod("Add").Invoke(dbSet2, new[] { entity });
            }
            dbDest.SaveChanges();
        }
    }
}
void ClearSqliteDb(string dbname)
{
    string connectionString = $"Data Source= {dbname}";
    using (var connection = new System.Data.SQLite.SQLiteConnection(connectionString))
    {
        // Open the connection
        connection.Open();
        // Get a list of all table names in the database
        var command = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type='table'", connection);
        var reader = command.ExecuteReader();
        var tableNames = new List<string>();
        while (reader.Read())
        {
            tableNames.Add(reader.GetString(0));
        }
        // Delete all rows from each table
        foreach (var tableName in tableNames)
        {
            command = new SQLiteCommand($"DELETE FROM {tableName}", connection);
            command.ExecuteNonQuery();
        }
        // Close the connection
        connection.Close();
    }
}
