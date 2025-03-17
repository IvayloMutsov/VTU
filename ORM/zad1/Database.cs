using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ORM
{
    public class Database
    {
        private string _connectionString; // IVAYLO\SQLEXPRESS

        public Database(string connectionString)
        {
            _connectionString = connectionString;  // set connection string
        }

        public void CreateDatabase(string databaseName) // Creating DB if it does not exist
        {
            string tempConnection = @"Server=IVAYLO\SQLEXPRESS;Database=master;Trusted_Connection=True;TrustServerCertificate=true;";
            using (SqlConnection connection = new SqlConnection(tempConnection))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(@"
                IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = @DatabaseName)
                BEGIN
                    DECLARE @sql NVARCHAR(MAX);
                    SET @sql = 'CREATE DATABASE [' + @DatabaseName + ']';
                    EXEC sp_executesql @sql;
                END", connection);

                cmd.Parameters.Add(new SqlParameter("@DatabaseName", databaseName));
                cmd.ExecuteNonQuery();
            }
        }

        public void CreateTable(string tableName) // Creating table if it does not exist
        {
            if (tableName != "x")
            {
                string createTableQuery = @"
                IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @TableName)
                BEGIN
                    DECLARE @sql NVARCHAR(MAX);
                    SET @sql = 'CREATE TABLE [' + @TableName + '] (
                        [' + @TableName + 'Id] INT PRIMARY KEY IDENTITY(1,1),
                        [' + @TableName + 'Name] NVARCHAR(30) NOT NULL
                    )';
                    EXEC sp_executesql @sql;
                END";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(createTableQuery, connection);
                    cmd.Parameters.Add(new SqlParameter("@TableName", tableName));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void InsertValuesIntoTable(string tableName, string[] tableValue) // Inserting values in the table
        {
            if (tableName != "x")
            {
                foreach (var item in tableValue)
                {
                    string insertQuery = @"
                    DECLARE @sql NVARCHAR(MAX);
                    SET @sql = 'INSERT INTO [' + @TableName + '] ([' + @TableName + 'Name]) VALUES (@Value)';
                    EXEC sp_executesql @sql, N'@Value NVARCHAR(30)', @Value = @Value;";

                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(insertQuery, connection);
                        command.Parameters.Add(new SqlParameter("@TableName", tableName));
                        command.Parameters.Add(new SqlParameter("@Value", item));
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void CreateRelation(string relationName, string table1, string table2) // Creating a many-to-many relation
        {
            string relationQuery = @"
            IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @RelationName)
            BEGIN
                DECLARE @sql NVARCHAR(MAX);
                SET @sql = 'CREATE TABLE [' + @RelationName + '] (
                    [' + @RelationName + 'Id] INT PRIMARY KEY IDENTITY(1,1),
                    [' + @Table1 + 'Id] INT,
                    [' + @Table2 + 'Id] INT,
                    FOREIGN KEY ([' + @Table1 + 'Id]) REFERENCES [' + @Table1 + ']([' + @Table1 + 'Id]),
                    FOREIGN KEY ([' + @Table2 + 'Id]) REFERENCES [' + @Table2 + ']([' + @Table2 + 'Id])
                )';
                EXEC sp_executesql @sql;
            END";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(relationQuery, connection);
                cmd.Parameters.Add(new SqlParameter("@RelationName", relationName));
                cmd.Parameters.Add(new SqlParameter("@Table1", table1));
                cmd.Parameters.Add(new SqlParameter("@Table2", table2));
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void CustomerBuyProduct(int[] tableValue, string tableName) // Inserting values in the relation table
        {
            List<string> cols = GetColumnNames(tableName);
            if (!tableValue.Contains(0))
            {
                string orderQuery = @"
                DECLARE @sql NVARCHAR(MAX);
                SET @sql = 'INSERT INTO [' + @TableName + '] ([' + @Col1 + '], [' + @Col2 + ']) VALUES (@Value1, @Value2)';
                EXEC sp_executesql @sql, N'@Value1 INT, @Value2 INT', @Value1 = @Value1, @Value2 = @Value2;";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(orderQuery, connection);
                    command.Parameters.Add(new SqlParameter("@TableName", tableName));
                    command.Parameters.Add(new SqlParameter("@Col1", cols[1]));
                    command.Parameters.Add(new SqlParameter("@Col2", cols[2]));
                    command.Parameters.Add(new SqlParameter("@Value1", tableValue[0]));
                    command.Parameters.Add(new SqlParameter("@Value2", tableValue[1]));
                    command.ExecuteNonQuery();
                }
            }
        }

        private List<string> GetColumnNames(string tableName)
        {
            List<string> columns = new List<string>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @TableName;";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add(new SqlParameter("@TableName", tableName));

                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        columns.Add(reader.GetString(0)); // Get the column name
                    }
                }
            }
            return columns;
        }
    }
}