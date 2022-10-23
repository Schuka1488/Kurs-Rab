using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Autorization
{
    class DBclass // класс создан для удобства, чтобы можнно было вызывать 1 метод, который отвечает за открытия соединения с БД и за закрытие
    {
        MySqlConnection connection = new MySqlConnection("server=chuc.caseum.ru;port=33333;username=st_3_20_21;password=15733563;database=is_3_20_st21_KURS");
        //MySqlConnection connection = new MySqlConnection("server=10.90.12.110;port=33333;username=st_3_20_21;password=15733563;database=is_3_20_st21_KURS");
        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed) // открытие соединения
                connection.Open();
        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open) // закрытие соединения 
                connection.Close();
        }
        public MySqlConnection getConnection() // пишем 1 метод там где нужно соединения, вместо того чтобы каждый раз писать connection.Open и connection.Close  
        {
            return connection; // возвращаем соединение 
        }
    }
}
