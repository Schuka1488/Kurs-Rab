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
        DBclass db = new DBclass(); // переменная класса для БД, и последующей работе с ними
        Point lastPoint; // специальный класс для задачи координат
        public ChangeTabelForm(string browserOutput, int year, int month)
        {
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
        }
        public string FormatDateToSql(DateTime time)
        {
            return time.ToString("yyyy-MM-dd HH:mm:ss.fff");
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
        private void buttonCloseChangeTabelForm_Click(object sender, EventArgs e)
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
                db.CreateTable(Markcombobox.SelectedItem.ToString(), workerID, FormatDateToSql(DateTime.Parse(date)));
            }
            else
            {
                db.UpdateTable(tableID, Markcombobox.SelectedItem.ToString());
            }
            this.Close();
        }
    }
}
