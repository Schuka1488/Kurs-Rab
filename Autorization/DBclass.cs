﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Autorization
{
    class DBclass // класс создан для удобства, чтобы можнно было вызывать 1 метод, который отвечает за открытия соединения с БД и за закрытие
    {
        //MySqlConnection connection = new MySqlConnection("server=chuc.sdlik.ru;port=33333;username=st_3_20_21;password=15733563;database=is_3_20_st21_KURS");
        MySqlConnection connection = new MySqlConnection("server=10.90.12.110;port=33333;username=st_3_20_21;password=15733563;database=is_3_20_st21_KURS");
        public void openConnection() // метод который можно вызвать в любой части программного кода для открытия соединения
        {
            if (connection.State == System.Data.ConnectionState.Closed) // проверка на то закрыто соединение или нет
                connection.Open(); // метод открытия
        }
        public void closeConnection() // метод который можно вызвать в любой части программного кода для закрытия соединения
        {
            if (connection.State == System.Data.ConnectionState.Open) // проверка на то открыто соединение или нет
                connection.Close(); // метод закрытия
        }
        public MySqlConnection getConnection() // пишем 1 метод там где нужно соединения, вместо того чтобы каждый раз писать connection.Open и connection.Close и т.д.  
        {
            return connection; // возвращаем соединение 
        }
        public void UpdateTable(string tableID, string mark, bool OpenConnection = true) // метод для удаления таблицы
        {
            if (OpenConnection)
                connection.Open();
            string sql = $"UPDATE `TimesSheet` SET timessheet_mark='{mark}' WHERE timessheet_id ={tableID}";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.ExecuteNonQuery();
            if (OpenConnection)
                connection.Close();
        }
        public void CreateTable(string mark, string employeeID, string date, bool OpenConnection = true) // метод для создания таблицы
        {
            if (OpenConnection)
                connection.Open();
            string sql = $"INSERT INTO `TimesSheet` (timessheet_mark, timessheet_EmployeesID, 	timessheet_date) VALUES ('{mark}', {employeeID}, '{date}')";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.ExecuteNonQuery();
            if (OpenConnection)
                connection.Close();
        }
    }
}
