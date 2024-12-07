using System;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Text;

namespace DataTransfer
{
    class DataTransfer
    {
        static public void run()
        {
            // MSSQL connection string
            string mssqlConnectionString = @"Server=JIE-PC\SQLEXPRESS;Database=SP3DTrain_CDB_Schema;User Id=sa;Password=sa;Integrated Security=False;TrustServerCertificate=True" ;

            // SQLite connection string
            string sqliteConnectionString = "Data Source=CDB.db";

            // Export data from MSSQL view to CSV
            string csvFilePath = "CodelistValueView.csv";
            ExportDataToCSV(mssqlConnectionString, "CodelistValueView", csvFilePath);

            // Import data from CSV to SQLite view
            //ImportFromCSVToSQLite(sqliteConnectionString, "Your SQLite view name", csvFilePath);
        }

        static void ExportDataToCSV(string mssqlConnectionString, string viewName, string csvFilePath)
        {
            using (SqlConnection connection = new SqlConnection(mssqlConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand($"SELECT * FROM {viewName}", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        //using (StreamWriter writer = new StreamWriter(csvFilePath, Encoding.UTF8))
                        using (StreamWriter writer = new StreamWriter(csvFilePath))
                        {
                            // Write header row
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                writer.Write(reader.GetName(i));
                                if (i < reader.FieldCount - 1)
                                {
                                    writer.Write(",");
                                }
                            }
                            writer.WriteLine();

                            // Write data rows
                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    writer.Write(reader.GetValue(i));
                                    if (i < reader.FieldCount - 1)
                                    {
                                        writer.Write(",");
                                    }
                                }
                                writer.WriteLine();
                            }
                        }
                    }
                }
            }
        }

        static void ImportFromCSVToSQLite(string sqliteConnectionString, string viewName, string csvFilePath)
        {
            using (SQLiteConnection connection = new SQLiteConnection(sqliteConnectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand($"INSERT INTO {viewName} VALUES (@column1, @column2, ...)", connection))
                {
                    using (StreamReader reader = new StreamReader(csvFilePath))
                    {
                        // Skip header row
                        reader.ReadLine();

                        while (!reader.EndOfStream)
                        {
                            string[] values = reader.ReadLine().Split(',');

                            for (int i = 0; i < values.Length; i++)
                            {
                                command.Parameters.AddWithValue($"@column{i + 1}", values[i]);
                            }

                            command.ExecuteNonQuery();
                            command.Parameters.Clear();
                        }
                    }
                }
            }
        }
    }
}