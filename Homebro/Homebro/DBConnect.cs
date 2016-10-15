using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Homebro
{
    class DBConnect
    {
        public DBConnect()
        {

        }

        static string server = "h2550032.stratoserver.net";
        static string database = "homebro";
        static string user = "root";
        static string pswd = "rgEntwicklung2016";

        public static bool login()
        {
            string connectionString = "Server = " + server + ";database = " + database + ";uid = " + user + ";password = " + pswd + ";SslMode=None;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand checkLogin = new MySqlCommand("SELECT firstname FROM db_user WHERE IDX = \"" + 1 + "\"", connection);
                using (MySqlDataReader reader = checkLogin.ExecuteReader())
                {
                    reader.Read();
                    string name = reader.GetString("firstname");

                    if (name.Equals("Test"))
                        return true;
                    else
                        return false;
                }
            }
        }
    }
}
