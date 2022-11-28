using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Office.Interop.Word;

namespace Autorization
{
    public partial class MainForm : Form
    {
        string id_selected_rows = "0"; //Переменная для индекс выбранной строки в гриде
        private BindingSource bSource = new BindingSource(); // обьявлен для связи с источником соединения
        DBclass db = new DBclass(); // переменная класса для БД, и последующей работе с ними
        System.Drawing.Point lastPoint; // специальный класс для задачи координат
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)  // краткое описание ролей и их возможностей
        { 
            if (Username.user1.Role == 1)
                изменитьДанныеToolStripMenuItem.Visible = true; // если роль = 1 (например как у администратора) то изменить данные можно
            else
                изменитьДанныеToolStripMenuItem.Visible = false; // иначе, изменить данные нельзя, эти вкладки будут не доступны

            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(label4, "Закрытие программы");
            ToolTip toolTip2 = new ToolTip();
            toolTip2.AutoPopDelay = 5000;
            toolTip2.InitialDelay = 1000;
            toolTip2.ReshowDelay = 500;
            toolTip2.ShowAlways = true;
            toolTip2.SetToolTip(label2, "Главное меню создано для просмотра таблиц. \nИзменять данные в таблицах может только сотрудник с ролью admin.");

            dataGridView1.AllowUserToAddRows = false;
        }
        private void panel2_MouseDown(object sender, MouseEventArgs e) //метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на панели
        {
            lastPoint = new System.Drawing.Point(e.X, e.Y); // класс поинт создан для определении позиции в пространстве
        }
        private void panel2_MouseMove(object sender, MouseEventArgs e) //метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на панели
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e) //метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на панели
        {
            lastPoint = new System.Drawing.Point(e.X, e.Y); // класс поинт создан для определении позиции в пространстве
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e) //метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на панели
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private void программуToolStripMenuItem_Click(object sender, EventArgs e) // краткий метод для выхода из программы
        {
            System.Windows.Forms.Application.Exit(); 
        }
        private void формуToolStripMenuItem_Click(object sender, EventArgs e) // выход из главной формы и возвращение к авторизации, без потери производительности
        {
            this.Hide();
            LoginForm1 auth = new LoginForm1();
            auth.Show();
        }
        public void GetSelectedIDString() //Метод получения ID выделенной строки, для последующего вызова его в нужных методах
        {
            //Переменная для индекс выбранной строки в гриде
            string index_selected_rows;
            //Индекс выбранной строки
            index_selected_rows = dataGridView1.SelectedCells[0].RowIndex.ToString();
            //ID конкретной записи в Базе данных, на основании индекса строки
            id_selected_rows = dataGridView1.Rows[Convert.ToInt32(index_selected_rows)].Cells[0].Value.ToString();
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
            dataGridView1.CurrentRow.Selected = true;
            //Метод получения ID выделенной строки в глобальную переменную
            GetSelectedIDString();
        }
        private void таблицаСотрудниковToolStripMenuItem_Click(object sender, EventArgs e) // метод при нажатии которого осуществяется SQL запрос с получением данных из таблицы БД
        {
            string commandStr = "SELECT EmployeesID AS 'Код сотрудника', employeesBirthday AS 'Дата рождения сотрудника', employeesDateOfEmployed AS 'Дата приема на работу', employeesName AS 'Имя', employeesSurname AS 'Фамилия', employeesPatronymic AS 'Отчество', employeesJobTitle AS 'Профессия' FROM Employees"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            System.Data.DataTable table = new System.Data.DataTable(); // создание элемента таблицы
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            dataGridView1.DataSource = bSource; // показывается таблица при выборе вкладки
        }
        private void таблицаКлиентовToolStripMenuItem_Click(object sender, EventArgs e) // метод при нажатии которого осуществяется SQL запрос с получением данных из таблицы БД
        {
            string commandStr = "SELECT CustomerID AS 'Код клиента', customerCompanyName AS 'Название компании', customerAddress AS 'Адрес компании', MSRN AS 'ОГРН', TIN AS 'ИНН' FROM Customer"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            System.Data.DataTable table = new System.Data.DataTable(); // создание элемента таблицы
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            dataGridView1.DataSource = bSource; // показывается таблица при выборе вкладки
        }
        private void таблицаЗаказовToolStripMenuItem_Click(object sender, EventArgs e) // метод при нажатии которого осуществяется SQL запрос с получением данных из таблицы БД
        {
            string commandStr = "SELECT ProjectOrderID AS 'Код заказа', projectName AS 'Название проекта', projectCategory AS 'Категория проекта', 	projectPrice AS 'Цена', ProjectID AS 'Код проекта', EmployeesID AS 'Код сотрудника', CustomerID AS 'Код клиента' FROM ProjectOrder"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            System.Data.DataTable table = new System.Data.DataTable(); // создание элемента таблицы
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            dataGridView1.DataSource = bSource; // показывается таблица при выборе вкладки
        }
        private void таблицаПродажToolStripMenuItem_Click(object sender, EventArgs e) // метод при нажатии которого осуществяется SQL запрос с получением данных из таблицы БД
        {
            string commandStr = "SELECT ProjectID AS 'Код проекта', SaleID AS 'Код продажи', datePurchase AS 'Дата покупки' FROM ProjectSales"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            System.Data.DataTable table = new System.Data.DataTable(); // создание элемента таблицы
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            dataGridView1.DataSource = bSource; // показывается таблица при выборе вкладки
        }
        private void таблицаЦенToolStripMenuItem_Click(object sender, EventArgs e) // метод при нажатии которого осуществяется SQL запрос с получением данных из таблицы БД
        {
            string commandStr = "SELECT SaleID AS 'Код продажи', saleDate AS 'Дата продажи', saleNotes AS 'Кол-во страниц' FROM Sales"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            System.Data.DataTable table = new System.Data.DataTable(); // создание элемента таблицы
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            dataGridView1.DataSource = bSource; // показывается таблица при выборе вкладки
        }
        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)//метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на гриде
        {
            lastPoint = new System.Drawing.Point(e.X, e.Y); // класс поинт создан для определении позиции в пространстве
        }
        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)//метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на гриде
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private void изменитьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangeDataForm changedataForm = new ChangeDataForm(); // после авторизации показывается ChangeDataForm
            changedataForm.Show(); // метод для показа ChangeDataForm
        }
        private void label4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
        private void WhiteThemeButton_Click(object sender, EventArgs e)
        {
            ThemeMethodClass.LightThemeMethodMainForm(panel1, panel2, dataGridView1, DarkThemeButton, WhiteThemeButton, labelTheme, label1, label2);
            dR = labelTheme.BackColor.R - labelTheme.ForeColor.R;
            dG = labelTheme.BackColor.G - labelTheme.ForeColor.G;
            dB = labelTheme.BackColor.B - labelTheme.ForeColor.B;
            sign = 2;
            Timer timer = new Timer();
            timer.Interval = 10;
            timer.Tick += timer2_Tick;
            timer.Start();
        }
        private void DarkThemeButton_Click(object sender, EventArgs e)
        {
            ThemeMethodClass.DarkThemeMethodMainForm(panel1, panel2, dataGridView1, DarkThemeButton, WhiteThemeButton, labelTheme, label1, label2);
            dR = labelTheme.BackColor.R - labelTheme.ForeColor.R;
            dG = labelTheme.BackColor.G - labelTheme.ForeColor.G;
            dB = labelTheme.BackColor.B - labelTheme.ForeColor.B;
            sign = 1;
            Timer timer = new Timer();
            timer.Interval = 10;
            timer.Tick += timer1_Tick;
            timer.Start();
        }
        int dR, dG, dB, sign;

        private void таблицаСотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void таблицаЗаказчикиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void таблицаЗаказовToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        private void таблицаПродажToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        private void таблицаЦенToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Math.Abs(labelTheme.ForeColor.R - labelTheme.BackColor.R) < Math.Abs(dR / 10))
            {
                sign *= -1;
                labelTheme.Text = "Темная тема вкл.";
            }
            labelTheme.ForeColor = Color.FromArgb(255, labelTheme.ForeColor.R + sign * dR / 10, labelTheme.ForeColor.G + sign * dG / 10, labelTheme.ForeColor.B + sign * dB / 10);
            if (labelTheme.BackColor.R == labelTheme.ForeColor.R + dR)
            {
                ((Timer)sender).Stop();
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Math.Abs(labelTheme.ForeColor.R - labelTheme.BackColor.R) < Math.Abs(dR / 10))
            {
                sign *= -1;
                labelTheme.Text = "Светлая тема вкл.";
            }
            labelTheme.ForeColor = Color.FromArgb(255, labelTheme.ForeColor.R + sign * dR / 10, labelTheme.ForeColor.G + sign * dG / 10, labelTheme.ForeColor.B + sign * dB / 10);
            if (labelTheme.BackColor.R == labelTheme.ForeColor.R + dR)
            {
                ((Timer)sender).Stop();
            }
        }
    }
}
