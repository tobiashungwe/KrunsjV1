using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Krunsj_V1
{

    //connectie sql server
    

    class DB
    {
        private MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=csharp_users_db");

        //deze function zorgt ervoor dat de connection open gaat van sql 
        public void openConnection()
        {
            if(connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        //deze function zorgt ervoor dat de connection sluit(closed) gaat van sql 
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        //create a function to return the connection
        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}
