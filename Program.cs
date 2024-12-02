using System;
using MySql.Data.MySqlClient;

namespace DatabaseApp
{
    public class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string connString = $"Server=localhost;Database=capstone_db;User Id=jun;Password=evaluation1;SslMode=none;";
            return new MySqlConnection(connString);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Getting Connection ...");

            using (MySqlConnection conn = DBUtils.GetDBConnection())
            {
                try
                {
                    Console.WriteLine("Opening Connection ...");
                    conn.Open();
                    Console.WriteLine("Connection successful!");

                    string query = "SELECT * FROM userAddress";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"ID: {reader["userAddressID"]}, Country: {reader["country"]}");
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }

            Console.ReadLine();
        }
    }
}
