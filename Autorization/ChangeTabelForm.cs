using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Autorization
{
    public partial class ChangeTabelForm : Form
    {
        public string employeeId;
        EmployeeData employeeData;
        static DBclass db = new DBclass(); // переменная класса для БД, и последующей работе с ними
        Point lastPoint; // специальный класс для задачи координат
        public ChangeTabelForm(string browserOutput, int year, int month)
        {
            //employeeData = LoadEmployee(int.Parse(employeeId));
            //this.employeeId = employeeId;
            InitializeComponent();
            SplitStr(browserOutput, year, month);
            this.year = year;
            this.month = month;
        }
        string tableID;
        string workerID;
        string date;
        int year, month;
        private void SplitStr(string browserOutput, int year, int month)
        {
            string[] words = browserOutput.Split('|');
            tableID = words[0];
            workerID = words[1];
            int day = int.Parse(words[2]);
            day += 1;
            date = $"{day}.{month}.{year}";
        }
        private void ChangeTabelForm_Load(object sender, EventArgs e)
        {
            db.openConnection();
            string commandStr = $"SELECT employeesBirthday AS 'Дата рождения сотрудника', employeesDateOfEmployed AS 'Дата приема на работу', employeesName AS 'Имя', employeesSurname AS 'Фамилия', employeesPatronymic AS 'Отчество', employeesJobTitle AS 'Профессия' FROM Employees WHERE EmployeesID={workerID}"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БДMySql
            string Fullname = "";
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            Fullname = $"{reader[3].ToString()} {reader[2].ToString()} {reader[4].ToString()}";
            reader.Close();
            db.closeConnection();
            Surnamelabel.Text = Fullname;
            Datalable.Text = date;

            this.FormBorderStyle = FormBorderStyle.None; // убрал все стили границ форму
            // добавил свои границы
            Panel pnlTop = new Panel() { Height = 4, Dock = DockStyle.Top, BackColor = SystemColors.ActiveBorder };
            this.Controls.Add(pnlTop);
            Panel pnlRight = new Panel() { Width = 4, Dock = DockStyle.Right, BackColor = SystemColors.ActiveBorder };
            this.Controls.Add(pnlRight);
            Panel pnlBottom = new Panel() { Height = 4, Dock = DockStyle.Bottom, BackColor = SystemColors.ActiveBorder };
            this.Controls.Add(pnlBottom);
            Panel pnlLeft = new Panel() { Width = 4, Dock = DockStyle.Left, BackColor = SystemColors.ActiveBorder };
            this.Controls.Add(pnlLeft);
        }
        // форматы для правильного отображения даты и времени (на основе предпочтений культуры)
        public static string FormatDateToSql(DateTime time)
        {
            return time.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }
        public static string FormatDateHourToSql(DateTime time)
        {
            return time.ToString("yyyy-MM-dd HH:mm");
        }

        public static string FormatOnlyDateToSql(DateTime time)
        {
            return time.ToString("yyyy-MM-dd");
        }

        private void ChangeTabelForm_MouseDown(object sender, MouseEventArgs e) => lastPoint = new Point(e.X, e.Y);//метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на панели

        private void ChangeTabelForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) //определяет координату панели по оси X и Y, считывает ее перемещение при нажатии на ЛКМ
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private void ExitButtonErrorForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSaveTabel_Click(object sender, EventArgs e)
        {
            if (Markcombobox.SelectedItem == null)
            {
                MessageBox.Show("Выберите отметку и списка!", "Табель не изменен", MessageBoxButtons.OK, MessageBoxIcon.Information);// MessageBox показывает в какой таблице произошли изменения
                return;
            }
            if(tableID == "NULL")
            {
                db.CreateTable(comboBox1.SelectedItem.ToString(), workerID, FormatDateToSql(DateTime.Parse(date)));
            }
            else
            {
                db.UpdateTable(tableID, comboBox1.SelectedItem.ToString());
            }
            this.Close();
        }
        public static void AddFillTable(string desc, string logid, int employeeId, DateTime firstDate, DateTime endDateTime, FillTableType type)
        {
            string placeHolder;
            string historyMessage;

            switch (type)
            {
                case FillTableType.vacation:
                    placeHolder = "О";
                    historyMessage = $"Внесен отпуск с {firstDate.ToString()} по {endDateTime.ToString()} по причине {desc}";
                    break;

                case FillTableType.medical:
                    placeHolder = "Б";
                    historyMessage = $"Внесен больничный с {firstDate.ToString()} по {endDateTime.ToString()} по причине {desc}";
                    break;

                case FillTableType.goodreason:
                    placeHolder = "УВ";
                    historyMessage = $"Внесена уважительная причина с {firstDate.ToString()} по {endDateTime.ToString()} по причине {desc}";
                    break;

                default:
                    throw new Exception("Неизвестный тип!");
            }

            db.openConnection();

            for (DateTime dt = firstDate; dt <= endDateTime; dt = dt.AddDays(1))
            {
                MySqlCommand cmd = new MySqlCommand($"SELECT timessheet_id FROM TimesSheet JOIN Employees ON Employees.EmployeesID=`TimesSheet`.timessheet_EmployeesID WHERE Employees.EmployeesID={employeeId} AND `TimesSheet`.`timessheet_date` LIKE '{FormatOnlyDateToSql(dt)}%' ", db.getConnection());
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                DataTable table = new DataTable();
                adapter.SelectCommand = cmd;
                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    string tableID = table.Rows[0].ItemArray[0].ToString();
                    UpdateTable(tableID, placeHolder, false);
                }
                else
                {
                    CreateTable(placeHolder, employeeId.ToString(), FormatDateToSql(dt), false);
                }
            }

            HistoryCreate(logid, employeeId.ToString(), DateTime.Now, historyMessage, false);
            db.closeConnection();
        }
        public static void UpdateTable(string tableid, string mark, bool OpenConnection = true)
        {
            if (OpenConnection)
                db.openConnection();
            string sql = $"UPDATE `TimesSheet` SET timessheet_mark='{mark}' WHERE timessheet_id={tableid}";

            MySqlCommand cmd = new MySqlCommand(sql, db.getConnection());

            cmd.ExecuteNonQuery();

            if (OpenConnection)
                db.closeConnection();
        }
        public static void CreateTable(string mark, string employeeID, string date, bool OpenConnection = true)
        {
            if (OpenConnection)
                db.openConnection();
            string sql = $"INSERT INTO `TimesSheet` (timessheet_mark, timessheet_EmployeesID, timessheet_date) VALUES ('{mark}', {employeeID}, '{date}')";

            MySqlCommand cmd = new MySqlCommand(sql, db.getConnection());

            cmd.ExecuteNonQuery();

            if (OpenConnection)
                db.closeConnection();
        }
        public enum FillTableType
        {
            // отпуск
            vacation,
            // больничный
            medical,
            // дикрет
            goodreason
        }

        public static void HistoryCreate(string logid, string id, DateTime date, string desc, bool openConnection = true)
        {
            if (openConnection)
                db.openConnection();
            MySqlCommand cmd;

            string sql = $"INSERT INTO Log (Log_ID, Log_EmployeesID, Log_Desc, log_date) VALUES ('{logid}', {id}, '{desc}', '{date.ToString()}')";
            cmd = new MySqlCommand(sql, db.getConnection());

            cmd.ExecuteNonQuery();

            if (openConnection)
                db.closeConnection();
        }
        public static DataTable LoadTable(string commandStr)
        { //Метод отображения таблицы из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            return table;
        }
        public static void LoadEmployees(List<EmployeeData> res)
        {
            string commandStr = "SELECT EmployeesID  AS 'Код сотрудника', employeesName AS 'Имя', employeesSurname AS 'Фамилия', employeesPatronymic AS 'Отчество', employeesJobTitle AS 'Должность' FROM Employees";
            DataTable Employees = LoadTable(commandStr);
            foreach (DataRow row in Employees.Rows)
            {
                EmployeeData newRow = new EmployeeData();
                newRow.EmployeeId = Convert.ToInt32(row.ItemArray[0]);
                newRow.employeesName = row.ItemArray[1].ToString();
                newRow.employeesSurname = row.ItemArray[2].ToString();
                newRow.employeesPatronymic = row.ItemArray[3].ToString();
                newRow.employeesJobTitle = row.ItemArray[4].ToString();
                res.Add(newRow);
            }
        }
        public static EmployeeData LoadEmployee(int employeeId)
        {
            string commandStr = $"SELECT EmployeesID  AS 'Код сотрудника', employeesName AS 'Имя', employeesSurname AS 'Фамилия', employeesPatronymic AS 'Отчество', employeesJobTitle AS 'Должность' FROM Employees WHERE EmployeesID={employeeId}";

            DataTable Employees = LoadTable(commandStr);
            EmployeeData res;
            var row = Employees.Rows[0];

            res.EmployeeId = Convert.ToInt32(row.ItemArray[0]);
            res.employeesName = row.ItemArray[1].ToString();
            res.employeesSurname = row.ItemArray[2].ToString();
            res.employeesPatronymic = row.ItemArray[3].ToString();
            res.employeesJobTitle = row.ItemArray[4].ToString();

            return res;
        }
        static void LoadHistroy(List<HistroyInfo> res)
        {
            MySqlCommand cmd;
            db.openConnection();

            string sql = $"SELECT Log_ID , 	Log_EmployeesID, log_date, Log_Desc FROM LogTable";
            cmd = new MySqlCommand(sql, db.getConnection());

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                HistroyInfo inf = new HistroyInfo();
                inf.id = row.ItemArray[0].ToString();
                inf.owner = row.ItemArray[1].ToString();
                inf.date = row.ItemArray[2].ToString();
                inf.desc = row.ItemArray[3].ToString();

                res.Add(inf);
            }

            db.closeConnection();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FillTableType type = FillTableType.vacation;

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    type = FillTableType.vacation;
                    break;
                case 1:
                    type = FillTableType.medical;
                    break;
                case 2:
                    type = FillTableType.goodreason;
                    break;
            }
            AddFillTable(textBox1.Text, $"{employeeData.employeesName} {employeeData.employeesSurname}", int.Parse(employeeId), dateTimePicker1.Value, dateTimePicker2.Value, type);
        }
        public struct EmployeeData // список информации об отдельном работнике
        {
            public int EmployeeId;
            public string employeesName;
            public string employeesSurname;
            public string employeesPatronymic;
            public string employeesJobTitle;
        }
        internal struct HistroyInfo // список информации о том, что должно отправляться в таблицу с историей изменений данных в табеле
        {
            public string id;
            public string owner;
            public string employee_target_ID;
            public string date;
            public string desc;
        }
    }
}

