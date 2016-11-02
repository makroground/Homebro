using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Homebro
{
    class DBConnect
    {
        public DBConnect()
        {

        }

        static string server = "85.214.232.234";
        static string database = "rb_homebro";
        static string user = "root";
        static string pswd = "rgEntwicklung2016";

        public static bool login(string username, string password_hash)
        {
            string connectionString = "Server = " + server + ";database = " + database + ";uid = " + user + ";password = " + pswd + ";SslMode=None;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand checkLogin = new MySqlCommand("SELECT Password FROM users WHERE Username = \"" + username + "\";", connection);
                using (MySqlDataReader reader = checkLogin.ExecuteReader())
                {
                    reader.Read();
                    string password;
                    try
                    {
                        password = reader.GetString("Password");
                    } catch (MySqlException)
                    {
                        password = null;
                        Debug.Write("Login: Bei der Abfrage an der Datenbank ist ein Fehler aufgetreten.");
                    }

                    connection.Close();
                    if (password != null && password.Equals(password_hash))
                        return true;
                    else
                        return false;
                }
            }
        }
    }
}
