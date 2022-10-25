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

namespace Autorization
{
    public partial class MainForm : Form
    {
        string id_selected_rows = "0"; //Переменная для индекс выбранной строки в гриде
        private BindingSource bSource = new BindingSource(); // обьявлен для связи с источником соединения
        DBclass db = new DBclass(); // переменная класса для БД, и последующей работе с ними
        Point lastPoint; // специальный класс для задачи координат
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
        }
        private void panel2_MouseDown(object sender, MouseEventArgs e) //метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на панели
        {
            lastPoint = new Point(e.X, e.Y); // класс поинт создан для определении позиции в пространстве
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
            lastPoint = new Point(e.X, e.Y); // класс поинт создан для определении позиции в пространстве
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
            Application.Exit(); 
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
            DataTable table = new DataTable(); // класс для таблиц
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
            DataTable table = new DataTable(); // класс для таблиц
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
            DataTable table = new DataTable(); // класс для таблиц
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
            DataTable table = new DataTable(); // класс для таблиц
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
            DataTable table = new DataTable(); // класс для таблиц
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            dataGridView1.DataSource = bSource; // показывается таблица при выборе вкладки
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)//метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на гриде
        {
            lastPoint = new Point(e.X, e.Y); // класс поинт создан для определении позиции в пространстве
        }

        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)//метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на гриде
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void DarkThemeBox1_MouseDown(object sender, MouseEventArgs e)//метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на чек боксе темной темы
        {
            lastPoint = new Point(e.X, e.Y); // класс поинт создан для определении позиции в пространстве
        }

        private void DarkThemeBox1_MouseMove(object sender, MouseEventArgs e)//метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на чек боксе темной темы
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void DeleteTable_MouseDown(object sender, MouseEventArgs e)//метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на кнопке удаления данных в таблице
        {
            lastPoint = new Point(e.X, e.Y); // класс поинт создан для определении позиции в пространстве
        }

        private void DeleteTable_MouseMove(object sender, MouseEventArgs e)//метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на кнопке удаления данных в таблице
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
            Application.Exit();
        }
        //private void dataGridView1_CellPainting(object sender,System.Windows.Forms.DataGridViewCellPaintingEventArgs e)
        // {
        // if (this.dataGridView1.Columns["ContactName"].Index ==
        // e.ColumnIndex && e.RowIndex >= 0)
        // {
        // Rectangle newRect = new Rectangle(e.CellBounds.X + 1,
        // e.CellBounds.Y + 1, e.CellBounds.Width - 4,
        //e.CellBounds.Height - 4);

        // using (
        // Brush gridBrush = new SolidBrush(this.dataGridView1.GridColor),
        // backColorBrush = new SolidBrush(e.CellStyle.BackColor))
        // {
        // using (Pen gridLinePen = new Pen(gridBrush))
        //{
        // Erase the cell.
        // e.Graphics.FillRectangle(backColorBrush, e.CellBounds);

        // Draw the grid lines (only the right and bottom lines;
        // DataGridView takes care of the others).
        // e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left,
        //   e.CellBounds.Bottom - 1, e.CellBounds.Right - 1,
        //  e.CellBounds.Bottom - 1);
        // e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1,
        // e.CellBounds.Top, e.CellBounds.Right - 1,
        // e.CellBounds.Bottom);

        // Draw the inset highlight box.
        //e.Graphics.DrawRectangle(Pens.Blue, newRect);

        // Draw the text content of the cell, ignoring alignment.
        // if (e.Value != null)
        //{
        // e.Graphics.DrawString((String)e.Value, e.CellStyle.Font,
        //  Brushes.Crimson, e.CellBounds.X + 2,
        //   e.CellBounds.Y + 2, StringFormat.GenericDefault);
        // }
        // e.Handled = true;
        // }
        //}
        //}
        //}

    }
}
