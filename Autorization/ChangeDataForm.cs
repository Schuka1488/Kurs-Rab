﻿using System;
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
    public partial class ChangeDataForm : Form
    {
        public ChangeDataForm()
        {
            InitializeComponent();
        }
        // string id_selected_rows = "0";
        Point lastPoint; // специальный класс для задачи координат
        DBclass db = new DBclass();
        private BindingSource bSource = new BindingSource(); // обьявлен для связи с источником соединения
        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y); // класс поинт создан для определении позиции в пространстве
        }

        private void panel5_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y); // класс поинт создан для определении позиции в пространстве
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void изПрограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void изАккаунтаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm1 auth = new LoginForm1();
            auth.Show();
        }

        private void вГлавноеМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void dataGridViewTransformData2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y); // класс поинт создан для определении позиции в пространстве
        }

        private void dataGridViewTransformData2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        #region [ Кнопки тем ]
        private void WhiteThemeButton_Click(object sender, EventArgs e)
        {
            ThemeMethodClass.ThemeMethodLight3(panel4, panel5, dataGridViewTransformData2, DarkThemeButton, WhiteThemeButton, labelTheme);
            dR = labelTheme.BackColor.R - labelTheme.ForeColor.R;
            dG = labelTheme.BackColor.G - labelTheme.ForeColor.G;
            dB = labelTheme.BackColor.B - labelTheme.ForeColor.B;
            sign = 2;
            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += timer2_Tick;
            timer.Start();
        }

        private void DarkThemeButton_Click(object sender, EventArgs e)
        {
            ThemeMethodClass.ThemeMethod3(panel4, panel5, dataGridViewTransformData2, DarkThemeButton, WhiteThemeButton, labelTheme);
            dR = labelTheme.BackColor.R - labelTheme.ForeColor.R;
            dG = labelTheme.BackColor.G - labelTheme.ForeColor.G;
            dB = labelTheme.BackColor.B - labelTheme.ForeColor.B;
            sign = 1;
            Timer timer = new Timer();
            timer.Interval = 100;
            timer.Tick += timer1_Tick;
            timer.Start();
        }
        int dR, dG, dB, sign;
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
        #endregion
        private void вТаблицеСотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string commandStr = "SELECT EmployeesID AS 'Код сотрудника', employeesBirthday AS 'Дата рождения сотрудника', employeesDateOfEmployed AS 'Дата приема на работу', employeesName AS 'Имя', employeesSurname AS 'Фамилия', employeesPatronymic AS 'Отчество', employeesJobTitle AS 'Профессия' FROM Employees"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            DataTable table = new DataTable(); // класс для таблиц
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            dataGridViewTransformData2.DataSource = bSource; // показывается таблица при выборе вкладки
            dataGridViewTransformData2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
                Column1Label.Visible = true;
                Column2Label.Visible = true;
                Column3Label.Visible = true;
                Column4Label.Visible = true;
                Column5Label.Visible = true;
                Column6Label.Visible = true;
                Column7Label.Visible = true;
                        AddLineButton.Visible = true;
                        AddLineButton2.Visible = false;
                        AddLineButton3.Visible = false;
                        AddLineButton4.Visible = false;
                        AddLineButton5.Visible = false;
                        AddLineButton6.Visible = false;
        }
        private void SupplemenEmloyee()
        {
            db.openConnection();
            MySqlCommand cmd = new MySqlCommand($"INSERT INTO Employees(employeesBirthday, employeesDateOfEmployed, employeesName, employeesSurname, employeesPatronymic, employeesJobTitle ) VALUES( \"{textBox2.Text}\", \"{textBox3.Text}\",'{textBox4.Text}','{textBox5.Text}','{textBox6.Text}','{textBox7.Text}')", db.getConnection());
            MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Данные добавились!" : "Данные не добавились!");
            db.closeConnection();
        }

        private void вТаблицеЗаказчикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string commandStr = "SELECT CustomerID AS 'Код клиента', customerCompanyName AS 'Название компании', customerAddress AS 'Адрес компании', MSRN AS 'ОГРН', TIN AS 'ИНН' FROM Customer"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            DataTable table = new DataTable(); // класс для таблиц
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            dataGridViewTransformData2.DataSource = bSource; // показывается таблица при выборе вкладки
            dataGridViewTransformData2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            textBox1.Visible = false;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = false;
            textBox7.Visible = false;
                Column1Label.Visible = true;
                Column2Label.Visible = true;
                Column3Label.Visible = true;
                Column4Label.Visible = true;
                Column5Label.Visible = true;
                Column6Label.Visible = false;
                Column7Label.Visible = false;
                        AddLineButton.Visible = false;
                        AddLineButton2.Visible = true;
                        AddLineButton3.Visible = false;
                        AddLineButton4.Visible = false;
                        AddLineButton5.Visible = false;
                        AddLineButton6.Visible = false;
        }
        private void SupplemenEmloyee2()
        {
            db.openConnection();
            MySqlCommand cmd = new MySqlCommand($"INSERT INTO Employees(employeesBirthday, employeesDateOfEmployed, employeesName, employeesSurname, employeesPatronymic, employeesJobTitle ) VALUES( \"{textBox2.Text}\", \"{textBox3.Text}\",'{textBox4.Text}','{textBox5.Text}','{textBox6.Text}','{textBox7.Text}')", db.getConnection());
            MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Данные добавились!" : "Данные не добавились!");
            db.closeConnection();
        }
        private void заказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string commandStr = "SELECT ProjectOrderID AS 'Код заказа', ProjectID AS 'Код проекта', EmployeesID AS 'Код сотрудника', CustomerID AS 'Код клиента', projectName AS 'Название проекта', projectCategory AS 'Категория проекта' , projectPrice AS 'Цена' FROM ProjectOrder"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            DataTable table = new DataTable(); // класс для таблиц
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            dataGridViewTransformData2.DataSource = bSource; // показывается таблица при выборе вкладки
            dataGridViewTransformData2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
                Column1Label.Visible = true;
                Column2Label.Visible = true;
                Column3Label.Visible = true;
                Column4Label.Visible = true;
                Column5Label.Visible = true;
                Column6Label.Visible = true;
                Column7Label.Visible = true;
                        AddLineButton.Visible = false;
                        AddLineButton2.Visible = false;
                        AddLineButton3.Visible = true;
                        AddLineButton4.Visible = false;
                        AddLineButton5.Visible = false;
                        AddLineButton6.Visible = false;
        }
        private void SupplemenEmloyee3()
        {
            db.openConnection();
            MySqlCommand cmd = new MySqlCommand($"INSERT INTO Employees(employeesBirthday, employeesDateOfEmployed, employeesName, employeesSurname, employeesPatronymic, employeesJobTitle ) VALUES( \"{textBox2.Text}\", \"{textBox3.Text}\",'{textBox4.Text}','{textBox5.Text}','{textBox6.Text}','{textBox7.Text}')", db.getConnection());
            MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Данные добавились!" : "Данные не добавились!");
            db.closeConnection();
        }

        private void продажиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string commandStr = "SELECT ProjectID AS 'Код проекта', SaleID AS 'Код продажи', datePurchase AS 'Дата покупки' FROM ProjectSales"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            DataTable table = new DataTable(); // класс для таблиц
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            dataGridViewTransformData2.DataSource = bSource; // показывается таблица при выборе вкладки
            dataGridViewTransformData2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = true;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
                Column1Label.Visible = true;
                Column2Label.Visible = true;
                Column3Label.Visible = true;
                Column4Label.Visible = false;
                Column5Label.Visible = false;
                Column6Label.Visible = false;
                Column7Label.Visible = false;
                        AddLineButton.Visible = false;
                        AddLineButton2.Visible = false;
                        AddLineButton3.Visible = false;
                        AddLineButton4.Visible = true;
                        AddLineButton5.Visible = false;
                        AddLineButton6.Visible = false;
        }
        private void SupplemenEmloyee4()
        {
            db.openConnection();
            MySqlCommand cmd = new MySqlCommand($"INSERT INTO Employees(employeesBirthday, employeesDateOfEmployed, employeesName, employeesSurname, employeesPatronymic, employeesJobTitle ) VALUES( \"{textBox2.Text}\", \"{textBox3.Text}\",'{textBox4.Text}','{textBox5.Text}','{textBox6.Text}','{textBox7.Text}')", db.getConnection());
            MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Данные добавились!" : "Данные не добавились!");
            db.closeConnection();
        }

        private void ценаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string commandStr = "SELECT SaleID AS 'Код продажи', saleDate AS 'Дата продажи', saleNotes AS 'Кол-во страниц' FROM Sales"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            DataTable table = new DataTable(); // класс для таблиц
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            dataGridViewTransformData2.DataSource = bSource; // показывается таблица при выборе вкладки
            dataGridViewTransformData2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            textBox1.Visible = false;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
                Column1Label.Visible = true;
                Column2Label.Visible = true;
                Column3Label.Visible = true;
                Column4Label.Visible = false;
                Column5Label.Visible = false;
                Column6Label.Visible = false;
                Column7Label.Visible = false;
                        AddLineButton.Visible = false;
                        AddLineButton2.Visible = false;
                        AddLineButton3.Visible = false;
                        AddLineButton4.Visible = false;
                        AddLineButton5.Visible = true;
                        AddLineButton6.Visible = false;

        }
        private void SupplemenEmloyee5()
        {
            db.openConnection();
            MySqlCommand cmd = new MySqlCommand($"INSERT INTO Employees(employeesBirthday, employeesDateOfEmployed, employeesName, employeesSurname, employeesPatronymic, employeesJobTitle ) VALUES( \"{textBox2.Text}\", \"{textBox3.Text}\",'{textBox4.Text}','{textBox5.Text}','{textBox6.Text}','{textBox7.Text}')", db.getConnection());
            MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Данные добавились!" : "Данные не добавились!");
            db.closeConnection();
        }
        private void вТаблицеАвторизацииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string commandStr = "SELECT AuthorizationID AS 'Код авторизации', EmployeesID AS 'Код сотрудника', employeesJobTitle AS 'Профессия', login AS 'Логин', password AS 'Пароль', roleTitle AS 'Название роли', levelRole AS 'Уровень роли' FROM authorization"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            DataTable table = new DataTable(); // класс для таблиц
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            dataGridViewTransformData2.DataSource = bSource; // показывается таблица при выборе вкладки
            dataGridViewTransformData2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
                Column1Label.Visible = true;
                Column2Label.Visible = true;
                Column3Label.Visible = true;
                Column4Label.Visible = true;
                Column5Label.Visible = true;
                Column6Label.Visible = true;
                Column7Label.Visible = true;
                        AddLineButton.Visible = false;
                        AddLineButton2.Visible = false;
                        AddLineButton3.Visible = false;
                        AddLineButton4.Visible = false;
                        AddLineButton5.Visible = false;
                        AddLineButton6.Visible = true;
        }
        private void SupplemenEmloyee6()
        {
            db.openConnection();
            MySqlCommand cmd = new MySqlCommand($"INSERT INTO Employees(employeesBirthday, employeesDateOfEmployed, employeesName, employeesSurname, employeesPatronymic, employeesJobTitle ) VALUES( \"{textBox2.Text}\", \"{textBox3.Text}\",'{textBox4.Text}','{textBox5.Text}','{textBox6.Text}','{textBox7.Text}')", db.getConnection());
            MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Данные добавились!" : "Данные не добавились!");
            db.closeConnection();
        }
        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void AddLineButton2_Click(object sender, EventArgs e)
        {
            SupplemenEmloyee2();
        }
        private void AddLineButton3_Click(object sender, EventArgs e)
        {
            SupplemenEmloyee3();
        }
        private void AddLineButton4_Click(object sender, EventArgs e)
        {
            SupplemenEmloyee4();
        }
        private void AddLineButton5_Click(object sender, EventArgs e)
        {
            SupplemenEmloyee5();
        }
        private void AddLineButton6_Click(object sender, EventArgs e)
        {
            SupplemenEmloyee6();
        }
        private void ChangeDataForm_Load(object sender, EventArgs e)
        {
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
            toolTip2.SetToolTip(label2, "Коды (ID поля) не обязательно заполнять, они заполняются автоматически! \n Даты пишутся в формате 2004-12-12\n Первое число - год, Второе - месяц, Третье - день.");
        }
        private void AddLineButton_Click(object sender, EventArgs e)
        {
            SupplemenEmloyee();
        }
        private void DeleteLineButton_Click(object sender, EventArgs e)
        {

        }
    }
}
