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
                SqlCommand cmd = new SqlCommand($@"
                IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = @DatabaseName)
                BEGIN
                    CREATE DATABASE {databaseName};
                END
        ", connection);

                cmd.Parameters.AddWithValue("@DatabaseName", databaseName);
                cmd.ExecuteNonQuery();
            }
        }


        public void CreateTable(string tableName) // Creating table it it does not exist
        {
            if (tableName != "x")
            {
              string createTableQuery = $@"
             IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @TableName)
             BEGIN
                CREATE TABLE {tableName} (
                {tableName}Id INT PRIMARY KEY IDENTITY(1,1),
                {tableName}Name NVARCHAR(30) NOT NULL
                );
             END";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(createTableQuery, connection);
                    cmd.Parameters.AddWithValue("@TableName", tableName);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void InsertValuesIntoTable(string tableName, string[] tableValue) // Insearting values in the table
        {
            if (tableName != "x")
            {
                foreach (var item in tableValue)
                {
                    string insertQuerry = $@"INSERT INTO {tableName} ({tableName}Name) VALUES (@Value);";
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(insertQuerry, connection);
                        command.Parameters.AddWithValue("@Value", item);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void CreateRelation(string relationName, string table1, string table2) // Creating a many-to-many relation
        {
            string relationQuerry = $@"
            IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{relationName}')
            BEGIN
                 CREATE TABLE {relationName} (
                    {relationName}Id INT PRIMARY KEY IDENTITY(1,1),
                    {table1}Id INT,
                    {table2}Id INT,
                    FOREIGN KEY ({table1}Id) REFERENCES {table1}({table1}Id),
                    FOREIGN KEY ({table2}Id) REFERENCES {table2}({table2}Id)
                    );
            END";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(relationQuerry,connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@TableName", relationName);
                cmd.ExecuteNonQuery();
            }
        }

        public void CustomerBuyProduct(int[] tableValue, string tableName) //inserting values in the relation table
        {
            List<string> cols = GetColumnNames(tableName);
            if (!tableValue.Contains(0))
            {
                string orderQuerry = $@"INSERT INTO {tableName} ({cols[1]},{cols[2]}) VALUES ({tableValue[0]},{tableValue[1]});";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(orderQuerry, connection);
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
                cmd.Parameters.AddWithValue("@TableName", tableName);

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
