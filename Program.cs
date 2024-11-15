using System;
using Microsoft.Data.SqlClient;
namespace Tutorial.SqlConn
{
//class DBSQLServerUtils
//{
//public static SqlConnection
////GetDBConnection(string datasource, string database, string
//username, string password)
//{
//string connString = @"Data Source=" + datasource + ";Initial Catalog="
//+ database + ";Persist Security Info=True;User ID=" +
//username + ";Password=" + password + "Encrypt=False;";
//SqlConnection conn = new SqlConnection(connString);
//return conn;
//}
//}
public class DBUtils
{
public static SqlConnection GetDBConnection()
{
string datasource = @"localhost";
string database = "msdb";
string username = "sa";
string password = "dockerStrongPwd123";
string connString = @"Data Source=" + datasource + ";Initial Catalog="
+ database + ";Persist Security Info=True;User ID=" +
username + ";Password=" + password + "Encrypt=False;";
var ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
SqlConnection conn = new SqlConnection(ConnectionString);
return conn;
}
}
class Program
{
static void Main(string[] args)
{
Console.WriteLine("Getting Connection ...");
using (SqlConnection conn = DBUtils.GetDBConnection())
{
try
{
Console.WriteLine("Opening Connection ...");
conn.Open();
Console.WriteLine("Connection successful!");
}
catch (Exception e)
{
Console.WriteLine("Error: " + e.Message);
}
}
Console.ReadLine(); // Wait for user input before closing console
}
}
}