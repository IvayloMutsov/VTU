using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace ORM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Въведете име на базата от данни: ");
            string clientDatabaseName = Console.ReadLine();
            string connectionString = $"Server=IVAYLO\\SQLEXPRESS;Database={clientDatabaseName};Trusted_Connection=True;TrustServerCertificate=true;";
            Database db = new Database(connectionString);
            db.CreateDatabase(clientDatabaseName);
            Console.WriteLine("---------------------------------------");
            string table = string.Empty;
            List<string> databaseTables = new List<string>();
            while (table != "x")
            {
                Console.Write("Въведете име на таблицата (Натиснете латинско x за да спрете въвеждането!): ");
                table = Console.ReadLine();
                databaseTables.Add(table);
                db.CreateTable(table);
            }
            Console.WriteLine("---------------------------------------");
            string tableName = string.Empty;
            while (tableName != "x")
            {
                Console.Write("В коя таблица ще въвеждате данни (Натиснете латинско x за да спрете въвеждането!): ");
                tableName = Console.ReadLine();
                if (tableName != "x")
                {
                    Console.Write("Въведете данни за таблицата: ");
                    string[] tableValues = Console.ReadLine().Split(',').ToArray();
                    db.InsertValuesIntoTable(tableName, tableValues);
                }
            }
            Console.WriteLine("---------------------------------------");
            Console.Write("Задаите име на свързващата таблица: ");
            string relName = Console.ReadLine();
            Console.Write("Кои таблици ще се свързват (2 Макс): ");
            string[] relTables = new string[2];
            relTables = Console.ReadLine().Split(',').ToArray();
            db.CreateRelation(relName, relTables[0], relTables[1]);
            Console.WriteLine("---------------------------------------");
            int[] values = new int[2];
            do
            {
                Console.Write("Въведете данни за свързващата таблица (2 индекса макс/Въведете 0 за да спрете): ");
                values = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
                db.CustomerBuyProduct(values, relName);
            }
            while (!values.Contains(0));
        }
    }
}