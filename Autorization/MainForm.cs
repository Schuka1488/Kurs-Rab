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
        DBclass db = new DBclass();
        public MainForm()
        {
            InitializeComponent();

            textBox1.Text = "Введите название таблицы"; // текстбоксу задается текст
            textBox1.ForeColor = Color.Gray; // а так же цвет
        }
        private void MainForm_Load(object sender, EventArgs e)  // краткое описание ролей и их возможностей
        { 
            if (Username.user1.Role == 1)
                изменитьДанныеToolStripMenuItem.Visible = true;
            else
                изменитьДанныеToolStripMenuItem.Visible = false;
        }
        Point lastPoint; // специальный класс для задачи координат
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        { 
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
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_Leave(object sender, EventArgs e) // когда мы перестаем использовать текстбокс ему обратно возвращается цвет DarkGray
        {
            if (textBox1.Text == "") 
            {
                textBox1.Text = "ВВЕДИТЕ НАЗВАНИЕ ТАБЛИЦЫ";
                textBox1.ForeColor = Color.DarkGray;
            }
        }
        private void textBox1_Enter(object sender, EventArgs e) // когда мы начинаем печатать в текстбоксе тексту задается цвет Black
        {
            if (textBox1.Text == "ВВЕДИТЕ НАЗВАНИЕ ТАБЛИЦЫ")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }
        private void DeleteTable_Click(object sender, EventArgs e)
        {
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
            string commandStr = "SELECT EmployeesID AS 'Код сотрудника', employeesBirthday AS 'Дата рождения сотрудника', employeesDateOfEmployed AS 'Дата приема на работу', employeesName AS 'Имя', employeesSurname AS 'Фамилия', employeesPatronymic AS 'Отчество', employeesJobTitle AS 'Профессия' FROM Employees";
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            DataTable table = new DataTable();
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            bSource.DataSource = table;
            dataGridView1.DataSource = bSource;
        }

        private void таблицаКлиентовToolStripMenuItem_Click(object sender, EventArgs e) // метод при нажатии которого осуществяется SQL запрос с получением данных из таблицы БД
        {
            string commandStr = "SELECT CustomerID AS 'Код клиента', customerCompanyName AS 'Название компании', customerAddress AS 'Адрес компании', MSRN AS 'ОГРН', TIN AS 'ИНН' FROM Customer";
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            DataTable table = new DataTable();
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            bSource.DataSource = table;
            dataGridView1.DataSource = bSource;
        }

        private void таблицаЗаказовToolStripMenuItem_Click(object sender, EventArgs e) // метод при нажатии которого осуществяется SQL запрос с получением данных из таблицы БД
        {
            string commandStr = "SELECT ProjectOrderID AS 'Код заказа', projectName AS 'Название проекта', projectCategory AS 'Категория проекта', 	projectPrice AS 'Цена', ProjectID AS 'Код проекта', EmployeesID AS 'Код сотрудника', CustomerID AS 'Код клиента' FROM ProjectOrder";
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            DataTable table = new DataTable();
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            bSource.DataSource = table;
            dataGridView1.DataSource = bSource;
        }

        private void таблицаПродажToolStripMenuItem_Click(object sender, EventArgs e) // метод при нажатии которого осуществяется SQL запрос с получением данных из таблицы БД
        {
            string commandStr = "SELECT ProjectID AS 'Код проекта', SaleID AS 'Код продажи', datePurchase AS 'Дата покупки' FROM ProjectSales";
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            DataTable table = new DataTable();
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            bSource.DataSource = table;
            dataGridView1.DataSource = bSource;
        }

        private void таблицаЦенToolStripMenuItem_Click(object sender, EventArgs e) // метод при нажатии которого осуществяется SQL запрос с получением данных из таблицы БД
        {
            string commandStr = "SELECT SaleID AS 'Код продажи', saleDate AS 'Дата продажи', saleNotes AS 'Кол-во страниц' FROM Sales";
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            DataTable table = new DataTable();
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            bSource.DataSource = table;
            dataGridView1.DataSource = bSource;
        }
    }
}
