﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Word.Application; // передаем application ворду интероп для работы с пакетом 

namespace Autorization
{
    public partial class MainForm : Form
    {
        System.Data.DataTable table; // глобальная переменная для простоты вывода в Microsoft Word
        string id_selected_rows = "0"; //Переменная для индекс выбранной строки в гриде, по умолчанию в гридере стоит индекс -1
        private BindingSource bSource = new BindingSource(); // обьявлен для связи с источником соединения
        DBclass db = new DBclass(); // переменная класса для БД, и последующей работе с ними
        System.Drawing.Point lastPoint; // специальный класс для задачи координат
        public MainForm()
        {
            InitializeComponent();
            GridViewMethodLight();
        }
        private void GridViewMethodLight() // изменение стиля датагрида
        {
            dataGridView1.ForeColor = Color.DeepSkyBlue;
            dataGridView1.GridColor = Color.DarkGray;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;
        }
        private void GridViewMethodDark() // изменение стиля датагрида
        {
            dataGridView1.ForeColor = Color.Black;
            dataGridView1.GridColor = Color.Black;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
        }
        private void MainForm_Load(object sender, EventArgs e)  // краткое описание ролей и их возможностей
        { 
            if (Username.user1.Role == 1) // чтоб обладать полными полномочиями нужно иметь роль 1, это мы передаем в параметры
                изменитьДанныеToolStripMenuItem.Visible = true; // если роль = 1 (например как у администратора) то изменить данные можно
            else
                изменитьДанныеToolStripMenuItem.Visible = false; // иначе, изменить данные нельзя, эти вкладки будут не доступны

            this.FormBorderStyle = FormBorderStyle.None; // Создание панелей по бокам формы
            Panel pnlTop = new Panel() { Height = 4, Dock = DockStyle.Top, BackColor = SystemColors.ActiveBorder };
            this.Controls.Add(pnlTop);
            Panel pnlRight = new Panel() { Width = 4, Dock = DockStyle.Right, BackColor = SystemColors.ActiveBorder };
            this.Controls.Add(pnlRight);
            Panel pnlBottom = new Panel() { Height = 4, Dock = DockStyle.Bottom, BackColor = SystemColors.ActiveBorder };
            this.Controls.Add(pnlBottom);
            Panel pnlLeft = new Panel() { Width = 4, Dock = DockStyle.Left, BackColor = SystemColors.ActiveBorder };
            this.Controls.Add(pnlLeft);

            ToolTip toolTip1 = new ToolTip(); // тул тип для подсказок
            toolTip1.AutoPopDelay = 5000; // параметры показа подсказки, в течении какого времени будет видна подсказка
            toolTip1.InitialDelay = 100; // в течении какого кол-ва времени после наведения курсора будет показываться подсказка
            toolTip1.ReshowDelay = 500; // возвращает или задает интервал времени, который должен пройти перед появлением окна очередной всплывающей подсказки при перемещении указателя мыши с одного элемента управления на другой.
            toolTip1.ShowAlways = true; // статус видимости
            toolTip1.SetToolTip(label4, "Закрытие программы");
            ToolTip toolTip2 = new ToolTip(); // тул тип для подсказок
            toolTip2.AutoPopDelay = 5000; // параметры показа подсказки, в течении какого времени будет видна подсказка
            toolTip2.InitialDelay = 100; // в течении какого кол-ва времени после наведения курсора будет показываться подсказка
            toolTip2.ReshowDelay = 500; // возвращает или задает интервал времени, который должен пройти перед появлением окна очередной всплывающей подсказки при перемещении указателя мыши с одного элемента управления на другой.
            toolTip2.ShowAlways = true; // статус видимости
            toolTip2.SetToolTip(label2, "Главное меню создано для просмотра таблиц. \nИзменять данные в таблицах может только сотрудник с ролью admin.\nДля вывода в Microsoft Word необходимо выбрать таблицу в меню сверху (вкладка показать данные)");

            dataGridView1.AllowUserToAddRows = false; // изначально дата грид не показывается, показывается только тогда, когда мы выбираем таблицу для просмотра
            // в ChangeDataForm я реализовал скрытие дата гридера на форме через свойства, то также это можно сделать и в коде при помощи параметра добавления строк AllowUserToAddRows
        }
        private void panel2_MouseDown(object sender, MouseEventArgs e) => lastPoint = new System.Drawing.Point(e.X, e.Y);//метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на панели
        private void panel2_MouseMove(object sender, MouseEventArgs e) //метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на панели
        {
            if (e.Button == MouseButtons.Left) //определяет координату панели по оси X и Y, считывает ее перемещение при нажатии на ЛКМ
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e) => lastPoint = new System.Drawing.Point(e.X, e.Y);//метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на панели
        private void panel1_MouseMove(object sender, MouseEventArgs e) //метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на панели
        {
            if (e.Button == MouseButtons.Left) //определяет координату панели по оси X и Y, считывает ее перемещение при нажатии на ЛКМ
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private void программуToolStripMenuItem_Click(object sender, EventArgs e) // краткий метод для выхода из программы
        {
            DialogResult res = new DialogResult(); // переменная для обработки выбранных кнопок в MessageBox
            res = MessageBox.Show("Вы действительно хотите выйти?", "Выход из программы", MessageBoxButtons.YesNo, MessageBoxIcon.Question); //Настройка MessageBox
            if (res == DialogResult.Yes) // если мы нажимаем кнопку Да
            { 
                System.Windows.Forms.Application.Exit(); // выход из программы
            }
            else return;  // возвращаемся на форму
        }
        private void label4_Click(object sender, EventArgs e) // осуществил выход при помощи лейбла поставив X
        {
            DialogResult res = new DialogResult(); // переменная для обработки выбранных кнопок в MessageBox
            res = MessageBox.Show("Вы действительно хотите выйти?", "Выход из программы", MessageBoxButtons.YesNo, MessageBoxIcon.Question); //Настройка MessageBox
            if (res == DialogResult.Yes) // если мы нажимаем кнопку Да
            {
                System.Windows.Forms.Application.Exit(); // выход из программы 
            }
            else return; // возвращаемся на форму
        }
        private void формуToolStripMenuItem_Click(object sender, EventArgs e) // выход из главной формы и возвращение к авторизации, без потери производительности
        {
            DialogResult res = new DialogResult(); // переменная для обработки выбранных кнопок в MessageBox
            res = MessageBox.Show("Вы действительно хотите выйти из аккаунта?", "Выход из аккаунта", MessageBoxButtons.YesNo, MessageBoxIcon.Question); //Настройка MessageBox
            if (res == DialogResult.Yes) // если мы нажимаем кнопку Да
            {
                this.Hide(); // эта форма скрывается
                LoginForm1 auth = new LoginForm1();
                auth.Show(); // метод для показа формы авторизации
            }
            else return; // возвращаемся на форму
        }
        private void изменитьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangeDataForm changedataForm = new ChangeDataForm(); // после авторизации показывается ChangeDataForm
            changedataForm.Show(); // метод для показа ChangeDataForm
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
            string commandStr = "SELECT EmployeesID AS 'Код сотрудника', employeesBirthday AS 'Дата рождения сотрудника', employeesDateOfEmployed AS 'Дата приема на работу', employeesName AS 'Имя', employeesSurname AS 'Фамилия', employeesPatronymic AS 'Отчество', employeesJobTitle AS 'Профессия', employeesAddress AS 'Адрес', employeesStatus AS 'Статус' FROM Employees"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            table = new System.Data.DataTable(); // создание элемента таблицы
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            dataGridView1.DataSource = bSource; // показывается таблица при выборе вкладки
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            // указываем какие объекты будут видны на форме (разные текстбоксы для разной фильтрации)
            labelJob.Visible = true; // видимость названия профессии
            textBoxJob.Visible = true; // видимость текстбокса для фильтрации профессии

            labelITN.Visible = false; // видимость ИНН компании
            textBoxITN.Visible = false; // видимость тексбокса для фильтрации компаний по ИНН

            labelNameProject.Visible = false; // видимость названия проекта
            textBoxNameProject.Visible = false; // видимость тексбокса для фильтрации проектов по названию
        }
        private void таблицаКлиентовToolStripMenuItem_Click(object sender, EventArgs e) // метод при нажатии которого осуществяется SQL запрос с получением данных из таблицы БД
        {
            string commandStr = "SELECT CustomerID AS 'Код клиента', customerCompanyName AS 'Название компании', customerAddress AS 'Адрес компании', PSRN AS 'ОГРН', ITN AS 'ИНН', TRRC AS 'КПП' FROM Customer"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            table = new System.Data.DataTable(); // создание элемента таблицы
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            dataGridView1.DataSource = bSource; // показывается таблица при выборе вкладки
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            // указываем какие объекты будут видны на форме (разные текстбоксы для разной фильтрации)
            labelJob.Visible = false; // видимость названия профессии
            textBoxJob.Visible = false; // видимость текстбокса для фильтрации профессии

            labelITN.Visible = true; // видимость ИНН компании
            textBoxITN.Visible = true; // видимость тексбокса для фильтрации компаний по ИНН

            labelNameProject.Visible = false; // видимость названия проекта
            textBoxNameProject.Visible = false; // видимость тексбокса для фильтрации проектов по названию
        }
        private void таблицаЗаказовToolStripMenuItem_Click(object sender, EventArgs e) // метод при нажатии которого осуществяется SQL запрос с получением данных из таблицы БД
        {
            string commandStr = "SELECT ProjectOrderID AS 'Код заказа', projectName AS 'Название проекта', projectCategory AS 'Категория проекта', 	projectPrice AS 'Цена в рублях', ProjectID AS 'Код проекта', EmployeesID AS 'Код сотрудника', CustomerID AS 'Код клиента' FROM ProjectOrder"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            table = new System.Data.DataTable(); // создание элемента таблицы
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            dataGridView1.DataSource = bSource; // показывается таблица при выборе вкладки
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            // указываем какие объекты будут видны на форме (разные текстбоксы для разной фильтрации)
            labelJob.Visible = false; // видимость названия профессии
            textBoxJob.Visible = false; // видимость текстбокса для фильтрации профессии

            labelITN.Visible = false; // видимость ИНН компании
            textBoxITN.Visible = false; // видимость тексбокса для фильтрации компаний по ИНН

            labelNameProject.Visible = true; // видимость названия проекта
            textBoxNameProject.Visible = true; // видимость тексбокса для фильтрации проектов по названию
        }
        private void таблицаПродажToolStripMenuItem_Click(object sender, EventArgs e) // метод при нажатии которого осуществяется SQL запрос с получением данных из таблицы БД
        {
            string commandStr = "SELECT ProjectID AS 'Код проекта', SaleID AS 'Код продажи', datePurchase AS 'Дата покупки' FROM ProjectSales"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            table = new System.Data.DataTable(); // создание элемента таблицы
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            dataGridView1.DataSource = bSource; // показывается таблица при выборе вкладки
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            // указываем какие объекты будут видны на форме (разные текстбоксы для разной фильтрации)
            labelJob.Visible = false; // видимость названия профессии
            textBoxJob.Visible = false; // видимость текстбокса для фильтрации профессии

            labelITN.Visible = false; // видимость ИНН компании
            textBoxITN.Visible = false; // видимость тексбокса для фильтрации компаний по ИНН

            labelNameProject.Visible = false; // видимость названия проекта
            textBoxNameProject.Visible = false; // видимость тексбокса для фильтрации проектов по названию
        }
        private void таблицаЦенToolStripMenuItem_Click(object sender, EventArgs e) // метод при нажатии которого осуществяется SQL запрос с получением данных из таблицы БД
        {
            string commandStr = "SELECT SaleID AS 'Код продажи', saleDate AS 'Дата продажи', saleNotes AS 'Кол-во страниц', saleCost AS 'Цена в рублях' FROM Sales"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            table = new System.Data.DataTable(); // создание элемента таблицы
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            dataGridView1.DataSource = bSource; // показывается таблица при выборе вкладки
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            // указываем какие объекты будут видны на форме (разные текстбоксы для разной фильтрации)
            labelJob.Visible = false; // видимость названия профессии
            textBoxJob.Visible = false; // видимость текстбокса для фильтрации профессии

            labelITN.Visible = false; // видимость ИНН компании
            textBoxITN.Visible = false; // видимость тексбокса для фильтрации компаний по ИНН

            labelNameProject.Visible = false; // видимость названия проекта
            textBoxNameProject.Visible = false; // видимость тексбокса для фильтрации проектов по названию
        }
        private void dataGridView1_MouseDown(object sender, MouseEventArgs e) => lastPoint = new System.Drawing.Point(e.X, e.Y);//метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на гриде
        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)//метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на гриде
        {
            if (e.Button == MouseButtons.Left) //определяет координату панели по оси X и Y, считывает ее перемещение при нажатии на ЛКМ
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void WhiteThemeButton_Click(object sender, EventArgs e) // кнопка светлой темы
        {
            panel1.BackColor = ThemeMethodClass.Theme.LightColor2; // все элементы которые меняют свой цвет, который заявлен в специально созданном для этого классе
            panel2.BackColor = ThemeMethodClass.Theme.LightColor;
            dataGridView1.BackgroundColor = ThemeMethodClass.Theme.LightColor2;
            richTextBoxTime.BackColor = ThemeMethodClass.Theme.LightColor;
            GridViewMethodLight();
            dR = labelTheme.BackColor.R - labelTheme.ForeColor.R; // плавный переход текста из одного в другой, без потери цвета
            dG = labelTheme.BackColor.G - labelTheme.ForeColor.G;
            dB = labelTheme.BackColor.B - labelTheme.ForeColor.B;
            sign = 2; // знак таймера
            Timer timer = new Timer(); // создаем таймер
            timer.Interval = 4; // интервал с которым будет осуществляться переход 0,1 секунды = значение 10
            timer.Tick += timer2_Tick; // считываем нажатие
            timer.Start(); // таймер срабатывает 
        }
        private void DarkThemeButton_Click(object sender, EventArgs e) // кнопка темной темы
        {
            panel1.BackColor = ThemeMethodClass.Theme.DarkColor2; // все элементы которые меняют свой цвет, который заявлен в специально созданном для этого классе
            panel2.BackColor = ThemeMethodClass.Theme.DarkColor;
            dataGridView1.BackgroundColor = ThemeMethodClass.Theme.DarkColor2;
            richTextBoxTime.BackColor = ThemeMethodClass.Theme.DarkColor;
            GridViewMethodDark();
            dR = labelTheme.BackColor.R - labelTheme.ForeColor.R; // плавный переход текста из одного в другой, без потери цвета
            dG = labelTheme.BackColor.G - labelTheme.ForeColor.G;
            dB = labelTheme.BackColor.B - labelTheme.ForeColor.B;
            sign = 1; // знак таймера
            Timer timer = new Timer(); // создаем таймер
            timer.Interval = 4; // интервал с которым будет осуществляться переход 0,1 секунды = значение 10
            timer.Tick += timer1_Tick; // считываем нажатие
            timer.Start(); // таймер срабатывает 
        }
        private void печатьToolStripMenuItem1_Click(object sender, EventArgs e) // событие созданное для вывода таблицы из datagrid в Microsoft Word при нажатии по кнопке 
        {
            Application app = null; 
            try
            {
                app = new Application(); // новая переменная для application
                Document doc = app.Documents.Add(Visible: true); // переменная для того чтобы появилась возможность отображения документа
                Microsoft.Office.Interop.Word.Range r = doc.Range(); // задаем размер Word файлу
                Table t = doc.Tables.Add(r, dataGridView1.Rows.Count + 1, dataGridView1.Columns.Count); // добавляем в ворд файл строки и колонки
                int bdRow = 0; // указваем с какой строки начианется нумерация
                bool IsColumnReady = false; // отключаем нумерацию строк
                t.Borders.Enable = 1; // создаем границы таблицы в вордовском документе
                foreach (Row row in t.Rows) // перебор всех строк в таблице
                {
                    if (!IsColumnReady && bdRow == 0)
                    {
                        int tableCounter = 0;
                        foreach (Cell cell in row.Cells) //создаем ячейки в таблице
                        {
                            cell.Range.Text = table.Columns[tableCounter].ColumnName; //создаем отступ текста от границ ячейки, чтобы текст не наползал на границы
                            tableCounter++; // для каждой ячейки свой отступ текста от границ
                        }
                        IsColumnReady = true; // ячейки созданы, продолжаем перебор данных при помощи циклов
                        continue;
                    }
                    object[] collection = table.Rows[bdRow].ItemArray; // преобразуем строки из таблицы в объекты
                    int cellCount = 0;
                    foreach (Cell cell in row.Cells)
                    {
                        cell.Range.Text = collection[cellCount].ToString(); // все данные в ячейки приобразуем в строки, текст с которым уже можно бдует работать

                        cellCount++; // количество строк
                    }
                    bdRow++; // выводим все данные
                }
                doc.Save();  // выводится окно, которое придлагает сохранить документ прежде чем в нем работать
                doc.Close(); // документ закрывается программой и дальнейшее его использование программой прекращается
            }
            catch
            {
                MessageBox.Show("Необходимо выбрать или сохранить таблицу!                      (Код ошибки: 104)", "Ошибка вывода", MessageBoxButtons.OK, MessageBoxIcon.Error); // обработка исключения
                ErrorForm.Show("Возникла ошибка!");
            }
            finally
            {
                if (app !=null ) // если мы не открыли документо то...
                {
                    app.Quit(); // насильно прекращаем процесс работы с вордом для экономии оперативной памяти
                }
            }
        }


        private void выводВMicrosoftExcelВыбраннойТаблицыToolStripMenuItem_Click(object sender, EventArgs e) // событие созданное для вывода таблицы из datagrid в Microsoft Excel при нажатии по кнопке
        {
            Excel.Application exApp = null;
            try
            {
                exApp = new Excel.Application(); // создаем переменную класса Excel
                exApp.Workbooks.Add(); // добавляем рабочую область
                Excel.Worksheet wsh = (Excel.Worksheet)exApp.ActiveSheet; // создаем переменную для работы с Excel.Worksheet
                wsh.Cells[1, 1] = dataGridView1.Columns.ToString(); // начинаем переносить данные в Excel с 1 строки 1 столбца
                int i, j; // переменные для столбцов и строк
                for (i = 0; i <= dataGridView1.RowCount - 1; i++) // учитываем все строки
                {
                    for (j = 0; j <= dataGridView1.ColumnCount - 1; j++) // учитываем все стобцы
                    {
                        wsh.Cells[1, j + 1] = dataGridView1.Columns[j].HeaderText.ToString(); // учитываются наименования столбцов и переносятся в Excel 
                        wsh.Cells[i + 2, j + 1] = dataGridView1[j, i].Value.ToString();  // учитываются все столбцы и строки (включая первый столбец и последний, поэтому i+2, это связано с нумерацией строк в DataGridView с 0 и Excel с 1), и переносятся в Excel
                    }
                }
                exApp.Visible = true; // показывается созданный excel документ
            }
            catch
            {
                MessageBox.Show("Необходимо выбрать или сохранить таблицу!                          (Код ошибки: 104)", "Ошибка вывода", MessageBoxButtons.OK, MessageBoxIcon.Error); // обработка исключения
                ErrorForm.Show("Возникла ошибка!");
            }
            finally
            {
                if (exApp != null) // если мы не открыли документо то...
                {
                    exApp.Quit(); // насильно прекращаем процесс работы с вордом для экономии оперативной памяти
                }
            }
        }
        private void табельToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabelForm timessheetform = new TabelForm(); // после авторизации показывается ChangeDataForm
            timessheetform.Show(); // метод для показа ChangeDataForm
        }

        private void textBox1_TextChanged(object sender, EventArgs e) => table.DefaultView.RowFilter = $"Профессия LIKE '%{textBoxJob.Text}%'";
        private void textBoxITN_TextChanged(object sender, EventArgs e)
        {
            if (textBoxITN.Text.Length < 0) return; // данные не могут быть равны 0
            table.DefaultView.RowFilter = $"Convert(ИНН, System.String) LIKE '%{textBoxITN.Text}%'"; // фильтр компаний по ИНН
        }
        private void textBoxNameProject_TextChanged(object sender, EventArgs e) => table.DefaultView.RowFilter = $"`Название проекта` LIKE '%{textBoxNameProject.Text}%'";

        private void графикПрибылиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GrafForm grafForm = new GrafForm();
            grafForm.Show();
        }
        private void историяИзмененийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistoryForm historyForm = new HistoryForm();
            historyForm.Show();
        }
        int dR, dG, dB, sign; // переменные для rgb и индекса таймера
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Math.Abs(labelTheme.ForeColor.R - labelTheme.BackColor.R) < Math.Abs(dR / 10)) // создаем интервал для перехода цветов 
                {
                    sign *= -1;// знак таймера
                    labelTheme.Text = "Темная тема вкл."; // указваем какой текст хотим видеть в лейбле
                }
                labelTheme.ForeColor = Color.FromArgb(255, labelTheme.ForeColor.R + sign * dR / 10, labelTheme.ForeColor.G + sign * dG / 10, labelTheme.ForeColor.B + sign * dB / 10);
                if (labelTheme.BackColor.R == labelTheme.ForeColor.R + dR) // параметры для плавного перехода без потери цвета
                {
                    ((Timer)sender).Stop(); // таймер останавливается
                }
            }
            catch
            {
                ((Timer)sender).Stop(); // таймер останавливается
                MessageBox.Show("Не спеши! А то успеешь.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // обработка исключения
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Math.Abs(labelTheme.ForeColor.R - labelTheme.BackColor.R) < Math.Abs(dR / 10))  // создаем интервал для перехода цветов 
                {
                    sign *= -1; // знак таймера
                    labelTheme.Text = "Светлая тема вкл."; // указваем какой текст хотим видеть в лейбле
                }
                labelTheme.ForeColor = Color.FromArgb(255, labelTheme.ForeColor.R + sign * dR / 10, labelTheme.ForeColor.G + sign * dG / 10, labelTheme.ForeColor.B + sign * dB / 10);
                if (labelTheme.BackColor.R == labelTheme.ForeColor.R + dR) // параметры для плавного перехода без потери цвета
                {
                    ((Timer)sender).Stop(); // таймер останавливается
                }
            }
            catch
            {
                ((Timer)sender).Stop(); // таймер останавливается
                MessageBox.Show("Не спеши! А то успеешь.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // обработка исключения
            }
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            string dateandtime = DateTime.Now.ToString(); // перевод вывода даты и времени в строку
            richTextBoxTime.Text = dateandtime; // вывод данных в рич текстбокс
        }
    }
}
