using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Autorization
{
    class ClassForTabel
    {

        DBclass db = new DBclass();
        struct tabelEmployee
        {
            public string Id;
            public string FullName;
            public long Hours;
            public string Role;
            public List<TabelMark> marks;
        }
        List<tabelEmployee> general;
        List<EmployeeData> workers;
        public string FormatDateToSql(DateTime time)
        {
            return time.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }
        public string FormatDateHourToSql(DateTime time)
        {
            return time.ToString("yyyy-MM-dd HH:mm");
        }
        public string FormatOnlyDateToSql(DateTime time)
        {
            return time.ToString("yyyy-MM-dd");
        }
        public string FormatOnlyMonthToSql(DateTime time)
        {
            return time.ToString("yyyy-MM");
        }
        public void LoadDataFromBD(DateTime month)
        {
            workers = new List<EmployeeData>();
            general = new List<tabelEmployee>();
            string commandStr = "SELECT EmployeesID AS 'Код сотрудника', employeesBirthday AS 'Дата рождения сотрудника', employeesDateOfEmployed AS 'Дата приема на работу', employeesName AS 'Имя', employeesSurname AS 'Фамилия', employeesPatronymic AS 'Отчество', employeesJobTitle AS 'Профессия' FROM Employees"; // SQL запрос данных из БД
            MySqlCommand cmdGlob = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapterGlob = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            DataTable tableGlob = new System.Data.DataTable(); // создание элемента таблицы
            adapterGlob.SelectCommand = cmdGlob; // адаптер берет соединение
            adapterGlob.Fill(tableGlob); // адаптер передает значение для того чтобы показать таблицу
            foreach(DataRow row in tableGlob.Rows) // колонкам из таблицы задается переменная и отправляется в табель
            {
                EmployeeData data = new EmployeeData();
                data.EmployeeId = int.Parse(row.ItemArray[0].ToString());
                data.employeesName = row.ItemArray[3].ToString();
                data.employeesSurname = row.ItemArray[4].ToString();
                data.employeesPatronymic = row.ItemArray[5].ToString();
                data.employeesJobTitle = row.ItemArray[6].ToString();
                workers.Add(data);
            }
            foreach (EmployeeData worker in workers)
            {
                tabelEmployee emp = new tabelEmployee(); // переопределение переменных из таблицы сотрудников в таблицу для отправки в табель
                emp.FullName = $"{worker.employeesSurname} {worker.employeesName} {worker.employeesPatronymic}";
                emp.marks = new List<TabelMark>();
                emp.Id = worker.EmployeeId.ToString();
                emp.Role = worker.employeesJobTitle;
                string sql = $"SELECT timessheet_id, timessheet_mark, timessheet_date FROM `TimesSheet` WHERE timessheet_EmployeesID={worker.EmployeeId} AND timessheet_date LIKE '{FormatOnlyMonthToSql(month)}%' ORDER BY timessheet_date ASC";
                MySqlCommand cmd = new MySqlCommand(sql, db.getConnection());
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(table);
                long hoursCount = 0;
                int count = 0;
                List<TabelDate> dates = new List<TabelDate>(); 
                foreach (DataRow row in table.Rows) // так же передаем переменные колонкам из таблицы
                {
                    string id = row.ItemArray[0].ToString();
                    string mark = row.ItemArray[1].ToString();
                    string day = row.ItemArray[2].ToString();
                    DateTime time = DateTime.Parse(day);
                    count++;
                    if (Char.IsDigit(mark[0]))
                    {
                        hoursCount += Int32.Parse(mark);
                    }
                    TabelDate d = new TabelDate();
                    d.mark = mark;
                    d.time = time;
                    d.id = id;
                    dates.Add(d);
                }
                int SystemCount = DateTime.DaysInMonth(month.Year, month.Month);
                int ResCount = SystemCount - count;
                emp.marks = new List<TabelMark>(TimeSheetGenerator.ConvertMarksToTabelFormat(month.Year, month.Month, dates.ToArray())); // при помощи генератора передаем все значение и форматируем в таблицу
                emp.Hours = hoursCount;
                general.Add(emp);
            }
        }
        public void LoadAllIntoBuilder(TimeSheetGenerator generator)
        {
            foreach (tabelEmployee emp0 in general) // сборка табеля
            {
                LoadIntoBuilder(emp0, generator);
            }
        }
        private void LoadIntoBuilder(tabelEmployee d, TimeSheetGenerator generator)
        {
            WorkTimeEmployee emp2 = new WorkTimeEmployee(); // окончательная передача переменных для табеля и его сборка
            emp2.FullName = d.FullName;
            emp2.Id = int.Parse(d.Id);
            emp2.Hours = d.Hours;
            emp2.Role = d.Role;
            generator.PushHTMLContent(emp2, d.marks.ToArray());
        }
    }
    public struct EmployeeData // поля для табеля
    {
        public int EmployeeId;
        public string employeesName;
        public string employeesSurname;
        public string employeesPatronymic;
        public string address;
        public string employeesJobTitle;
        public string roleTitle;
    }
}
