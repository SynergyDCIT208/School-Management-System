using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SchoolMS
{
    internal class DatabaseHelper
    {
        private static string connectionString = "Server=localhost;Database=Schooldb;User ID=root;Password=12345678;";
    
    public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    public static bool ValidateUser(string username, string password, string role)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password AND role = @role";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@role", role);
    
                int userCount = Convert.ToInt32(cmd.ExecuteScalar());
                return userCount > 0;
            }
        }
    } 
}
