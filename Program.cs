using System;
using MySql.Data.MySqlClient;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Server=localhost;Uid=root;Pwd=0000;";

        using (var connection = new MySqlConnection(connectionString))
        {
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                connection.Open();

                // Check if the database exists
                string checkDatabaseQuery = "SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = 'capstone_db'";
                using (var checkCmd = new MySqlCommand(checkDatabaseQuery, connection))
                {
                    var result = checkCmd.ExecuteScalar();
                    if (result == null)
                    {
                        Console.WriteLine("Database 'capstone_db' not found. Creating...");
                        string createDatabaseQuery = "CREATE DATABASE capstone_db";
                        using (var createCmd = new MySqlCommand(createDatabaseQuery, connection))
                        {
                            createCmd.ExecuteNonQuery();
                            Console.WriteLine("Database 'capstone_db' created successfully.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Database 'capstone_db' already exists.");
                    }
                }

                // Select the database
                string useDatabaseQuery = "USE capstone_db;";
                using (var useCmd = new MySqlCommand(useDatabaseQuery, connection))
                {
                    useCmd.ExecuteNonQuery();
                    Console.WriteLine("Database 'capstone_db' selected.");
                }

                // Now you can run further queries for this database
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MySQL Error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Closing connection...");
                connection.Close();
            }
        }
    }
}
