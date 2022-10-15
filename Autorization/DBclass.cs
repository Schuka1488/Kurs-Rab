using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Autorization
{
    class DBclass
    {
        MySqlConnection connection = new MySqlConnection("server=10.90.12.110;port=33333;username=st_3_20_21;password=15733563;database=is_3_20_st21_KURS"); 
        // для чюка
        // server=chuc.caseum.ru;port=33333;username=st_3_20_21;password=15733563;database=is_3_20_st21_KURS
        // закоменченное для дома
        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
        public MySqlConnection getConnection()
        {
            return connection;
        }
    }
}
