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
    public partial class ChangeDataForm : Form
    {
        int dR, dG, dB, sign; // переменные для rgb и индекса таймера
        DataTable table; // глобальная переменная для простоты вывода в Microsoft Word
        DBclass db = new DBclass(); // переменная класса для БД, и последующей работе с ними
        private BindingSource bSource = new BindingSource(); // обьявлен для связи с источником соединения
        Point lastPoint; // специальный класс для задачи координат
        string id_selected_rows; // переменная для определения целой строки, по нажатию на поле id в dataGrid

        public ChangeDataForm()
        {
            InitializeComponent();
            GridViewMethodLight();
        }
        private void GridViewMethodLight()
        {
            dataGridViewTransformData2.ForeColor = Color.DeepSkyBlue;
            dataGridViewTransformData2.GridColor = Color.DarkGray;
            dataGridViewTransformData2.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender;
            dataGridViewTransformData2.EnableHeadersVisualStyles = false;
            dataGridViewTransformData2.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;
        }
        private void GridViewMethodDark()
        {
            dataGridViewTransformData2.ForeColor = Color.Black;
            dataGridViewTransformData2.GridColor = Color.Black;
            dataGridViewTransformData2.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;
            dataGridViewTransformData2.EnableHeadersVisualStyles = false;
            dataGridViewTransformData2.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
        }
        private void ChangeDataForm_Load(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip(); // тул тип для подсказок
            toolTip1.AutoPopDelay = 5000; // параметры показа подсказки, в течении какого времени будет видна подсказка
            toolTip1.InitialDelay = 1000; // в течении какого кол-ва времени после наведения курсора будет показываться подсказка
            toolTip1.ReshowDelay = 500; // возвращает или задает интервал времени, который должен пройти перед появлением окна очередной всплывающей подсказки при перемещении указателя мыши с одного элемента управления на другой.
            toolTip1.ShowAlways = true; // статус видимости
            toolTip1.SetToolTip(label4, "Закрытие программы"); // текст который виден при наведении на элемент формы
            ToolTip toolTip2 = new ToolTip(); // тул тип для подсказок
            toolTip2.AutoPopDelay = 5000; // параметры показа подсказки, в течении какого времени будет видна подсказка
            toolTip2.InitialDelay = 1000; // в течении какого кол-ва времени после наведения курсора будет показываться подсказка
            toolTip2.ReshowDelay = 500; // возвращает или задает интервал времени, который должен пройти перед появлением окна очередной всплывающей подсказки при перемещении указателя мыши с одного элемента управления на другой.
            toolTip2.ShowAlways = true; // статус видимости
            toolTip2.SetToolTip(label2, "Коды (ID поля) не нужно заполнять, они заполняются автоматически! \n Даты пишутся в формате 2004-12-12\n Первое число - год, Второе - месяц, Третье - день."); // текст который виден при наведении на элемент формы
        }
        static string sha256(string randomString)
        {
            //Тут происходит криптографическая магия. Смысл данного метода заключается в том, что строка залетает в метод
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
        private void panel5_MouseDown(object sender, MouseEventArgs e) => lastPoint = new Point(e.X, e.Y);//метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на панели
        private void panel5_MouseMove(object sender, MouseEventArgs e) //метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на панели
        {
            if (e.Button == MouseButtons.Left) //определяет координату панели по оси X и Y, считывает ее перемещение при нажатии на ЛКМ
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e) => lastPoint = new Point(e.X, e.Y);//метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на панели
        private void panel4_MouseMove(object sender, MouseEventArgs e) //метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на панели
        {
            if (e.Button == MouseButtons.Left) //определяет координату панели по оси X и Y, считывает ее перемещение при нажатии на ЛКМ
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private void dataGridViewTransformData2_MouseDown(object sender, MouseEventArgs e) => lastPoint = new Point(e.X, e.Y);//метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на гриде
        private void dataGridViewTransformData2_MouseMove(object sender, MouseEventArgs e) //метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на гриде
        {
            if (e.Button == MouseButtons.Left) //определяет координату панели по оси X и Y, считывает ее перемещение при нажатии на ЛКМ
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void изПрограммыToolStripMenuItem_Click(object sender, EventArgs e) // метод закрытия программы
        {
            DialogResult res = new DialogResult();
            res = MessageBox.Show("Вы действительно хотите выйти?", "Выход из программы", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes) // при нажатии на "Да" происходит выход из программы
            {
                Application.Exit(); // выход из программы
            }
            else return; // при нажатии на "Нет" MessageBox убирается(возвращается всё то, что было до нажатия на кнопку при помощи return)
        }
        private void label4_Click(object sender, EventArgs e) // метод закрытия программы
        {
            DialogResult res = new DialogResult();
            res = MessageBox.Show("Вы действительно хотите выйти?", "Выход из программы", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes) // при нажатии на "Да" происходит выход из программы
            { 
                Application.Exit(); // выход из программы
            }
            else return; // при нажатии на "Нет" MessageBox убирается(возвращается всё то, что было до нажатия на кнопку при помощи return)
        }

        private void изАккаунтаToolStripMenuItem_Click(object sender, EventArgs e) // метод закрытия программы
        {
            DialogResult res = new DialogResult(); 
            res = MessageBox.Show("Вы действительно хотите выйти из аккаунта?", "Выход из аккаунта", MessageBoxButtons.YesNo, MessageBoxIcon.Question); //Настройка MessageBox
            if (res == DialogResult.Yes) // при нажатии на "Да" происходит выход из программы
            {
                this.Hide(); // скрывается данная форма
                LoginForm1 auth = new LoginForm1();
                auth.Show(); // открывается форма авторизации
            }
            else return; // при нажатии на "Нет" MessageBox убирается(возвращается всё то, что было до нажатия на кнопку при помощи return)
        }

        private void вГлавноеМенюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = new DialogResult(); // переменная для обработки выбранных кнопок в MessageBox
            res = MessageBox.Show("Вы действительно хотите выйти в главное меню?", "Выход в главное меню", MessageBoxButtons.YesNo, MessageBoxIcon.Question); //Настройка MessageBox
            if (res == DialogResult.Yes) // если мы нажимаем кнопку Да
            {
                this.Hide(); // сокрытие открытой формы
                MainForm main = new MainForm();
                main.Show(); // открытие главной формы
            }
            else return; // возвращаемся на форму
        }
        #region [ Кнопки тем ]
        private void WhiteThemeButton_Click(object sender, EventArgs e) // кнопка светлой темы
        {
            // все элементы которые меняют свой цвет, который заявлен в специально созданном для этого классе
            panel4.BackColor = ThemeMethodClass.Theme.LightColor2; // панели
            panel5.BackColor = ThemeMethodClass.Theme.LightColor;
            DeleteLineButton.BackColor = ThemeMethodClass.Theme.LightColor2; // кнопки удаления данных из таблицы
            DeleteLineButton2.BackColor = ThemeMethodClass.Theme.LightColor2;
            DeleteLineButton3.BackColor = ThemeMethodClass.Theme.LightColor2;
            DeleteLineButton4.BackColor = ThemeMethodClass.Theme.LightColor2;
            DeleteLineButton5.BackColor = ThemeMethodClass.Theme.LightColor2;
            DeleteLineButton6.BackColor = ThemeMethodClass.Theme.LightColor2;
            AddLineButton.BackColor = ThemeMethodClass.Theme.LightColor2; // кнопки добавления новой строки в таблицу
            AddLineButton2.BackColor = ThemeMethodClass.Theme.LightColor2;
            AddLineButton3.BackColor = ThemeMethodClass.Theme.LightColor2;
            AddLineButton4.BackColor = ThemeMethodClass.Theme.LightColor2;
            AddLineButton5.BackColor = ThemeMethodClass.Theme.LightColor2;
            AddLineButton6.BackColor = ThemeMethodClass.Theme.LightColor2;
            dataGridViewTransformData2.BackgroundColor = ThemeMethodClass.Theme.LightColor2; // datagrid для вывода данных из БД 
            richTextBoxTime.BackColor = ThemeMethodClass.Theme.LightColor; // фон ричтекстбокса для отображения времени и даты
            GridViewMethodLight();

            dR = labelTheme.BackColor.R - labelTheme.ForeColor.R; // плавный переход текста из одного в другой, без потери цвета
            dG = labelTheme.BackColor.G - labelTheme.ForeColor.G;
            dB = labelTheme.BackColor.B - labelTheme.ForeColor.B;
            sign = 2; // знак таймера
            Timer timer = new Timer(); // создаем таймер
            timer.Interval = 4; // интервал 4 доли секунды, до следующего нажатия на кнопку(и запуска таймера)
            timer.Tick += timer2_Tick;
            timer.Start(); // таймер включается
        }

        private void DarkThemeButton_Click(object sender, EventArgs e) // кнопка темной темы
        {
            // все элементы которые меняют свой цвет, который заявлен в специально созданном для этого классе
            panel4.BackColor = ThemeMethodClass.Theme.DarkColor2; // панели
            panel5.BackColor = ThemeMethodClass.Theme.DarkColor;
            DeleteLineButton.BackColor = ThemeMethodClass.Theme.DarkColor2; // кнопки удаления данных из таблицы
            DeleteLineButton2.BackColor = ThemeMethodClass.Theme.DarkColor2;
            DeleteLineButton3.BackColor = ThemeMethodClass.Theme.DarkColor2;
            DeleteLineButton4.BackColor = ThemeMethodClass.Theme.DarkColor2;
            DeleteLineButton5.BackColor = ThemeMethodClass.Theme.DarkColor2;
            DeleteLineButton6.BackColor = ThemeMethodClass.Theme.DarkColor2;
            AddLineButton.BackColor = ThemeMethodClass.Theme.DarkColor2; // кнопки добавления новой строки в таблицу
            AddLineButton2.BackColor = ThemeMethodClass.Theme.DarkColor2;
            AddLineButton3.BackColor = ThemeMethodClass.Theme.DarkColor2;
            AddLineButton4.BackColor = ThemeMethodClass.Theme.DarkColor2;
            AddLineButton5.BackColor = ThemeMethodClass.Theme.DarkColor2;
            AddLineButton6.BackColor = ThemeMethodClass.Theme.DarkColor2;
            dataGridViewTransformData2.BackgroundColor = ThemeMethodClass.Theme.DarkColor2; // datagrid для вывода данных из БД 
            richTextBoxTime.BackColor = ThemeMethodClass.Theme.DarkColor; // фон ричтекстбокса для отображения времени и даты
            GridViewMethodDark();

            dR = labelTheme.BackColor.R - labelTheme.ForeColor.R; // плавный переход текста из одного в другой, без потери цвета
            dG = labelTheme.BackColor.G - labelTheme.ForeColor.G;
            dB = labelTheme.BackColor.B - labelTheme.ForeColor.B;
            sign = 1; // знак таймера
            Timer timer = new Timer(); // создаем таймер
            timer.Interval = 4; // интервал 4 доли секунды, до следующего нажатия на кнопку(и запуска таймера)
            timer.Tick += timer1_Tick;
            timer.Start(); // таймер включается
        }
        private void timer1_Tick(object sender, EventArgs e) 
        {
            try
            {
                if (Math.Abs(labelTheme.ForeColor.R - labelTheme.BackColor.R) < Math.Abs(dR / 10)) // создаем интервал для перехода цветов 
                {
                    sign *= -1; // знак таймера
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
                if (Math.Abs(labelTheme.ForeColor.R - labelTheme.BackColor.R) < Math.Abs(dR / 10)) // создаем интервал для перехода цветов 
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
        #endregion
        private void EmployeesSelect()
        {
            string commandStr = "SELECT EmployeesID AS 'Код сотрудника', employeesBirthday AS 'Дата рождения сотрудника', employeesDateOfEmployed AS 'Дата приема на работу', employeesName AS 'Имя', employeesSurname AS 'Фамилия', employeesPatronymic AS 'Отчество', employeesJobTitle AS 'Профессия' FROM Employees"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            table = new DataTable(); // класс для таблиц
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
            // сокрытие и показ всех необходимых элементов формы
            // текстбоксы куда мы вводим данные в таблицу, для дальнейшей работы с ними
            textBox1.Visible = false; 
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            // номера столбцов
            Column1Label.Visible = false;
            Column2Label.Visible = true;
            Column3Label.Visible = true;
            Column4Label.Visible = true;
            Column5Label.Visible = true;
            Column6Label.Visible = true;
            Column7Label.Visible = true;
            // кнопки добавления новой строки в таблицу
            AddLineButton.Visible = true;
            AddLineButton2.Visible = false;
            AddLineButton3.Visible = false;
            AddLineButton4.Visible = false;
            AddLineButton5.Visible = false;
            AddLineButton6.Visible = false;
            // кнопки удаления строки, выбранной клавишой ЛКМ
            DeleteLineButton.Visible = true;
            DeleteLineButton2.Visible = false;
            DeleteLineButton3.Visible = false;
            DeleteLineButton4.Visible = false;
            DeleteLineButton5.Visible = false;
            DeleteLineButton6.Visible = false;
            // кнопки изменения строки, выбранной клавишой ЛКМ (необходимо ввести новые данные в текстбоксы)
            UpdateLineButton1.Visible = true;
            UpdateLineButton2.Visible = false;
            UpdateLineButton3.Visible = false;
            UpdateLineButton4.Visible = false;
            UpdateLineButton5.Visible = false;
            UpdateLineButton6.Visible = false;
            // кнопки обновления данных в таблице
            RefreshButton1.Visible = true;
            RefreshButton2.Visible = false;
            RefreshButton3.Visible = false;
            RefreshButton4.Visible = false;
            RefreshButton5.Visible = false;
            RefreshButton6.Visible = false;
        }
        private void вТаблицеСотрудникиToolStripMenuItem_Click(object sender, EventArgs e) // кнопка вывода данных из БД в datagrid в виде таблицы
        {
            EmployeesSelect();
        }
        private void SupplemenEmloyee() // метод добавления новой строки в тблице и перенос её в БД
        {
            try
            {
                db.openConnection(); // осуществляем подключение к БД
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO Employees(employeesBirthday, employeesDateOfEmployed, employeesName, employeesSurname, employeesPatronymic, employeesJobTitle ) VALUES( \"{textBox2.Text}\", \"{textBox3.Text}\",'{textBox4.Text}','{textBox5.Text}','{textBox6.Text}','{textBox7.Text}')", db.getConnection()); // запрос к БД на добавление новой строки в таблицу (данные введены через текстбоксы)
                MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Данные добавились" : "Данные  добавились", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); // что выводится на экран при успешном выполнении
                db.closeConnection(); // отключаем подключение к БД
                textboxNoVisibleText();
            }
            catch
            {
                DialogResult res = new DialogResult();
                res = MessageBox.Show("Данные не добавились!", "Ошибка ввода!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // обработка исключения
                if (res == DialogResult.Cancel) //если нажимаем кнопку отмена, то у нас высвечивается уже отрытая таблица
                {
                    EmployeesSelect();
                }
                else
                {
                    return; // возвращаем всё то, что было до нажатия кнопку (данные в таблице высвечиваются, при этом никак не измененные)
                }
                db.closeConnection(); // отключаем подключение к БД
            }
        }
        private void DeleteTable() // метод удаления строки в таблице и перенос её в БД
        {
            try
            {
                db.openConnection(); // осуществляем подключение к БД
                MySqlCommand cmd = new MySqlCommand($"DELETE FROM Employees WHERE EmployeesID = {id_selected_rows}", db.getConnection()); // удаление выбранной строки из таблицы, и перенос обновленной таблицы в БД
                MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Данные удалены" : "Данные  удалены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); // что выводится на экран при успешном выполнении
                db.closeConnection(); // отключаем подключение к БД
            }
            catch
            {
                DialogResult res = new DialogResult();
                res = MessageBox.Show("Данные не удалены!", "Строка не выбрана!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error); // обработка исключения
                if (res == DialogResult.Cancel) //если нажимаем кнопку отмена, то у нас высвечивается уже отрытая таблица
                {
                    EmployeesSelect();
                }
                else
                {
                    return; // возвращаем всё то, что было до нажатия кнопку (данные в таблице высвечиваются, при этом никак не измененные)
                }
                db.closeConnection(); // отключаем подключение к БД
            }
        }
        private void UpdateTable() // метод изменения строки в таблице и перенос её в БД
        {
            try
            { 
                db.openConnection(); // осуществляем подключение к БД
                MySqlCommand cmd = new MySqlCommand($"UPDATE Employees SET employeesBirthday = \"{textBox2.Text}\", employeesDateOfEmployed = \"{textBox3.Text}\", employeesName = '{textBox4.Text}', employeesSurname = '{textBox5.Text}', employeesPatronymic = '{textBox6.Text}', employeesJobTitle = '{textBox7.Text}' WHERE EmployeesID = {id_selected_rows}", db.getConnection()); // запрос на изменения данных в выбранной строки, и присвоение ей новых данных, вписаных в текстбоксы
                MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Данные изменены" : "Данные изменены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); // что выводится на экран при успешном выполнении
                db.closeConnection(); // отключаем подключение к БД
                textboxNoVisibleText();
            }
            catch
            {
                DialogResult res = new DialogResult();
                res = MessageBox.Show("Данные не изменены!", "Строка не выбрана!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error); // обработка исключения
                if (res == DialogResult.Cancel) //если нажимаем кнопку отмена, то у нас высвечивается уже отрытая таблица
                {
                    EmployeesSelect();
                }
                else
                {
                    return; // возвращаем всё то, что было до нажатия кнопку (данные в таблице высвечиваются, при этом никак не измененные)
                }
                db.closeConnection(); // отключаем подключение к БД
            }
        }
        private void CustomerSelect()
        {
            string commandStr = "SELECT CustomerID AS 'Код клиента', customerCompanyName AS 'Название компании', customerAddress AS 'Адрес компании', PSRN AS 'ОГРН', ITN AS 'ИНН', TRRC AS 'КПП' FROM Customer"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            table = new DataTable(); // класс для таблиц
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
            // сокрытие и показ всех необходимых элементов формы
            // текстбоксы куда мы вводим данные в таблицу, для дальнейшей работы с ними
            textBox1.Visible = false; 
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = false;
            // номера столбцов
            Column1Label.Visible = false;
            Column2Label.Visible = true;
            Column3Label.Visible = true;
            Column4Label.Visible = true;
            Column5Label.Visible = true;
            Column6Label.Visible = true;
            Column7Label.Visible = false;
            // кнопки добавления новой строки в таблицу
            AddLineButton.Visible = false;
            AddLineButton2.Visible = true;
            AddLineButton3.Visible = false;
            AddLineButton4.Visible = false;
            AddLineButton5.Visible = false;
            AddLineButton6.Visible = false;
            // кнопки удаления строки, выбранной клавишой ЛКМ
            DeleteLineButton.Visible = false;
            DeleteLineButton2.Visible = true;
            DeleteLineButton3.Visible = false;
            DeleteLineButton4.Visible = false;
            DeleteLineButton5.Visible = false;
            DeleteLineButton6.Visible = false;
            // кнопки изменения строки, выбранной клавишой ЛКМ (необходимо ввести новые данные в текстбоксы)
            UpdateLineButton1.Visible = false;
            UpdateLineButton2.Visible = true;
            UpdateLineButton3.Visible = false;
            UpdateLineButton4.Visible = false;
            UpdateLineButton5.Visible = false;
            UpdateLineButton6.Visible = false;
            // кнопки обновления данных в таблице
            RefreshButton1.Visible = false;
            RefreshButton2.Visible = true;
            RefreshButton3.Visible = false;
            RefreshButton4.Visible = false;
            RefreshButton5.Visible = false;
            RefreshButton6.Visible = false;
        }
        private void вТаблицеЗаказчикиToolStripMenuItem_Click(object sender, EventArgs e) // кнопка вывода данных из БД в datagrid в виде таблицы
        {
            CustomerSelect();
        }
        private void SupplemenEmloyee2() // метод добавления новой строки в таблице и перенос её в БД
        {
            try
            {
                db.openConnection(); // осуществляем подключение к БД
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO Customer(customerCompanyName, customerAddress, PSRN, ITN, TRRC) VALUES( '{textBox2.Text}', '{textBox3.Text}',{textBox4.Text},{textBox5.Text},{textBox6.Text})", db.getConnection()); // запрос к БД на добавление новой строки в таблицу (данные введены через текстбоксы)
                MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Данные добавились" : "Данные  добавились", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); // что выводится на экран при успешном выполнении
                db.closeConnection(); // отключаем подключение к БД
                textboxNoVisibleText();
            }
            catch
            {
                DialogResult res = new DialogResult();
                res = MessageBox.Show("Данные не добавились!", "Ошибка ввода!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // обработка исключения
                if (res == DialogResult.Cancel) //если нажимаем кнопку отмена, то у нас высвечивается уже отрытая таблица
                {
                    CustomerSelect();
                }
                else
                {
                    return; // возвращаем всё то, что было до нажатия кнопку (данные в таблице высвечиваются, при этом никак не измененные)
                }
                db.closeConnection(); // отключаем подключение к БД
            }
        }
        private void DeleteTable2() // метод удаления строки в таблице и перенос её в БД
        {
            try
            {
                db.openConnection(); // осуществляем подключение к БД
                MySqlCommand cmd = new MySqlCommand($"DELETE FROM Customer WHERE CustomerID = {id_selected_rows}", db.getConnection()); // удаление выбранной строки из таблицы, и перенос обновленной таблицы в БД
                MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Данные удалены" : "Данные  удалены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); // что выводится на экран при успешном выполнении
                db.closeConnection(); // отключаем подключение к БД
            }
            catch
            {
                DialogResult res = new DialogResult();
                res = MessageBox.Show("Данные не удалены!", "Строка не выбрана!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error); // обработка исключения
                if (res == DialogResult.Cancel) //если нажимаем кнопку отмена, то у нас высвечивается уже отрытая таблица
                {
                    CustomerSelect();
                }
                else
                {
                    return;
                }
                db.closeConnection(); // отключаем подключение к БД
            }
        }
        private void UpdateTable2() // метод изменения строки в таблице и перенос её в БД
        {
            try
            {
                db.openConnection(); // осуществляем подключение к БД
                MySqlCommand cmd = new MySqlCommand($"UPDATE Customer SET customerCompanyName = '{textBox2.Text}', customerAddress = '{textBox3.Text}', PSRN = {textBox4.Text}, ITN = {textBox5.Text}, TRRC = {textBox6.Text} WHERE CustomerID = {id_selected_rows}", db.getConnection()); // запрос на изменения данных в выбранной строки, и присвоение ей новых данных, вписаных в текстбоксы
                MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Данные изменены" : "Данные изменены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); // что выводится на экран при успешном выполнении
                db.closeConnection(); // отключаем подключение к БД
                textboxNoVisibleText();
            }
            catch
            {
                DialogResult res = new DialogResult();
                res = MessageBox.Show("Данные не изменены!", "Строка не выбрана!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error); // обработка исключения
                if (res == DialogResult.Cancel) //если нажимаем кнопку отмена, то у нас высвечивается уже отрытая таблица
                {
                    CustomerSelect();
                }
                else
                {
                    return; // возвращаем всё то, что было до нажатия кнопку (данные в таблице высвечиваются, при этом никак не измененные)
                }
                db.closeConnection(); // отключаем подключение к БД
            }
        }
        private void ProjectOrderSelect()
        {
            string commandStr = "SELECT ProjectOrderID AS 'Код заказа', projectName AS 'Название проекта', projectCategory AS 'Категория проекта' , projectPrice AS 'Цена в рублях',  ProjectID AS 'Код проекта', EmployeesID AS 'Код сотрудника', CustomerID AS 'Код клиента' FROM ProjectOrder"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            table = new DataTable(); // класс для таблиц
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
            // сокрытие и показ всех необходимых элементов формы
            // текстбоксы куда мы вводим данные в таблицу, для дальнейшей работы с ними
            textBox1.Visible = false; 
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            // номера столбцов
            Column1Label.Visible = false;
            Column2Label.Visible = true;
            Column3Label.Visible = true;
            Column4Label.Visible = true;
            Column5Label.Visible = true;
            Column6Label.Visible = true;
            Column7Label.Visible = true;
            // кнопки добавления новой строки в таблицу
            AddLineButton.Visible = false;
            AddLineButton2.Visible = false;
            AddLineButton3.Visible = true;
            AddLineButton4.Visible = false;
            AddLineButton5.Visible = false;
            AddLineButton6.Visible = false;
            // кнопки удаления строки, выбранной клавишой ЛКМ
            DeleteLineButton.Visible = false;
            DeleteLineButton2.Visible = false;
            DeleteLineButton3.Visible = true;
            DeleteLineButton4.Visible = false;
            DeleteLineButton5.Visible = false;
            DeleteLineButton6.Visible = false;
            // кнопки изменения строки, выбранной клавишой ЛКМ (необходимо ввести новые данные в текстбоксы)
            UpdateLineButton1.Visible = false;
            UpdateLineButton2.Visible = false;
            UpdateLineButton3.Visible = true;
            UpdateLineButton4.Visible = false;
            UpdateLineButton5.Visible = false;
            UpdateLineButton6.Visible = false;
            // кнопки обновления данных в таблице
            RefreshButton1.Visible = false;
            RefreshButton2.Visible = false;
            RefreshButton3.Visible = true;
            RefreshButton4.Visible = false;
            RefreshButton5.Visible = false;
            RefreshButton6.Visible = false;
        }
        private void заказыToolStripMenuItem_Click(object sender, EventArgs e) // кнопка вывода данных из БД в datagrid в виде таблицы
        {
            ProjectOrderSelect();
        }
        private void SupplemenEmloyee3() // метод добавления новой строки в таблице и перенос её в БД
        {
            try
            {
                db.openConnection(); // осуществляем подключение к БД
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO ProjectOrder(projectName, projectCategory, projectPrice, ProjectID, EmployeesID, CustomerID) VALUES('{textBox2.Text}','{textBox3.Text}',{textBox4.Text}, '{textBox5.Text}', '{textBox6.Text}','{textBox7.Text}')", db.getConnection()); // запрос к БД на добавление новой строки в таблицу (данные введены через текстбоксы)
                MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Данные добавились" : "Данные  добавились", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); // что выводится на экран при успешном выполнении
                db.closeConnection(); // отключаем подключение к БД
                textboxNoVisibleText();
            }
            catch
            {
                DialogResult res = new DialogResult();
                res = MessageBox.Show("Данные не добавились!", "Ошибка ввода!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // обработка исключения
                if (res == DialogResult.Cancel) //если нажимаем кнопку отмена, то у нас высвечивается уже отрытая таблица
                {
                    ProjectOrderSelect();
                }
                else
                {
                    return; // возвращаем всё то, что было до нажатия кнопку (данные в таблице высвечиваются, при этом никак не измененные)
                }
                db.closeConnection(); // отключаем подключение к БД
            }
        }
        private void DeleteTable3() // метод удаления строки в таблице и перенос её в БД
        {
            try
            {
                db.openConnection(); // осуществляем подключение к БД
                MySqlCommand cmd = new MySqlCommand($"DELETE FROM ProjectOrder WHERE ProjectOrderID = {id_selected_rows}", db.getConnection()); // удаление выбранной строки из таблицы, и перенос обновленной таблицы в БД
                MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Данные удалены" : "Данные  удалены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); // что выводится на экран при успешном выполнении
                db.closeConnection(); // отключаем подключение к БД
            }
            catch
            {
                DialogResult res = new DialogResult();
                res = MessageBox.Show("Данные не удалены!", "Строка не выбрана!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error); // обработка исключения
                if (res == DialogResult.Cancel) //если нажимаем кнопку отмена, то у нас высвечивается уже отрытая таблица
                {
                    ProjectOrderSelect();
                }
                else
                {
                    return; // возвращаем всё то, что было до нажатия кнопку (данные в таблице высвечиваются, при этом никак не измененные)
                }
                db.closeConnection(); // отключаем подключение к БД
            }
        }
        private void UpdateTable3() // метод изменения строки в таблице и перенос её в БД
        {
            try
            {
                db.openConnection(); // осуществляем подключение к БД
                MySqlCommand cmd = new MySqlCommand($"UPDATE ProjectOrder SET projectName = '{textBox2.Text}', projectCategory = '{textBox3.Text}', projectPrice = {textBox4.Text}, ProjectID = '{textBox5.Text}', EmployeesID = '{textBox6.Text}', CustomerID = '{textBox7.Text}' WHERE ProjectOrderID = {id_selected_rows}", db.getConnection()); // запрос на изменения данных в выбранной строки, и присвоение ей новых данных, вписаных в текстбоксы
                MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Данные изменены" : "Данные изменены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); // что выводится на экран при успешном выполнении
                db.closeConnection(); // отключаем подключение к БД
                textboxNoVisibleText();
            }
            catch
            {
                DialogResult res = new DialogResult();
                res = MessageBox.Show("Данные не изменены!", "Строка не выбрана!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error); // обработка исключения
                if (res == DialogResult.Cancel) //если нажимаем кнопку отмена, то у нас высвечивается уже отрытая таблица
                {
                    ProjectOrderSelect();
                }
                else
                {
                    return; // возвращаем всё то, что было до нажатия кнопку (данные в таблице высвечиваются, при этом никак не измененные)
                }
                db.closeConnection(); // отключаем подключение к БД
            }
        }
        private void ProjectSalesSelect()
        {
            string commandStr = "SELECT ProjectID AS 'Код проекта', SaleID AS 'Код продажи', datePurchase AS 'Дата покупки' FROM ProjectSales"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            table = new DataTable(); // класс для таблиц
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            dataGridViewTransformData2.DataSource = bSource; // показывается таблица при выборе вкладки
            dataGridViewTransformData2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            // сокрытие и показ всех необходимых элементов формы
            // текстбоксы куда мы вводим данные в таблицу, для дальнейшей работы с ними
            textBox1.Visible = false; 
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            // номера столбцов
            Column1Label.Visible = false;
            Column2Label.Visible = true;
            Column3Label.Visible = true;
            Column4Label.Visible = false;
            Column5Label.Visible = false;
            Column6Label.Visible = false;
            Column7Label.Visible = false;
            // кнопки добавления новой строки в таблицу
            AddLineButton.Visible = false;
            AddLineButton2.Visible = false;
            AddLineButton3.Visible = false;
            AddLineButton4.Visible = true;
            AddLineButton5.Visible = false;
            AddLineButton6.Visible = false;
            // кнопки удаления строки, выбранной клавишой ЛКМ
            DeleteLineButton.Visible = false;
            DeleteLineButton2.Visible = false;
            DeleteLineButton3.Visible = false;
            DeleteLineButton4.Visible = true;
            DeleteLineButton5.Visible = false;
            DeleteLineButton6.Visible = false;
            // кнопки изменения строки, выбранной клавишой ЛКМ (необходимо ввести новые данные в текстбоксы)
            UpdateLineButton1.Visible = false;
            UpdateLineButton2.Visible = false;
            UpdateLineButton3.Visible = false;
            UpdateLineButton4.Visible = true;
            UpdateLineButton5.Visible = false;
            UpdateLineButton6.Visible = false;
            // кнопки обновления данных в таблице
            RefreshButton1.Visible = false;
            RefreshButton2.Visible = false;
            RefreshButton3.Visible = false;
            RefreshButton4.Visible = true;
            RefreshButton5.Visible = false;
            RefreshButton6.Visible = false;
        }
        private void продажиToolStripMenuItem_Click(object sender, EventArgs e) // кнопка вывода данных из БД в datagrid в виде таблицы
        {
            ProjectSalesSelect();
        }
        private void SupplemenEmloyee4() // метод добавления новой строки в таблице и перенос её в БД
        {
            try
            {
                db.openConnection(); // осуществляем подключение к БД
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO ProjectSales(SaleID, datePurchase) VALUES('{textBox2.Text}', \"{textBox3.Text}\")", db.getConnection()); // запрос к БД на добавление новой строки в таблицу (данные введены через текстбоксы)
                MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Данные добавились" : "Данные  добавились", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); // что выводится на экран при успешном выполнении
                db.closeConnection(); // отключаем подключение к БД
                textboxNoVisibleText();
            }
            catch
            {
                DialogResult res = new DialogResult();
                res = MessageBox.Show("Данные не добавились!", "Ошибка ввода!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // обработка исключения
                if (res == DialogResult.Cancel) //если нажимаем кнопку отмена, то у нас высвечивается уже отрытая таблица
                {
                    ProjectSalesSelect();
                }
                else
                {
                    return; // возвращаем всё то, что было до нажатия кнопку (данные в таблице высвечиваются, при этом никак не измененные)
                }
                db.closeConnection(); // отключаем подключение к БД
            }
        }
        private void DeleteTable4() // метод удаления строки в таблице и перенос её в БД
        {
            try
            {
                db.openConnection(); // осуществляем подключение к БД
                MySqlCommand cmd = new MySqlCommand($"DELETE FROM ProjectSales WHERE ProjectID = {id_selected_rows}", db.getConnection()); // удаление выбранной строки из таблицы, и перенос обновленной таблицы в БД
                MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Данные удалены" : "Данные  удалены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); // что выводится на экран при успешном выполнении
                db.closeConnection(); // отключаем подключение к БД
            }
            catch
            {
                DialogResult res = new DialogResult();
                res = MessageBox.Show("Данные не удалены!", "Строка не выбрана!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error); // обработка исключения
                if (res == DialogResult.Cancel) //если нажимаем кнопку отмена, то у нас высвечивается уже отрытая таблица
                {
                    ProjectSalesSelect();
                }
                else
                {
                    return; // возвращаем всё то, что было до нажатия кнопку (данные в таблице высвечиваются, при этом никак не измененные)
                }
                db.closeConnection(); // отключаем подключение к БД
            }
        }
        private void UpdateTable4() // метод изменения строки в таблице и перенос её в БД
        {
            try
            {
                db.openConnection(); // осуществляем подключение к БД
                MySqlCommand cmd = new MySqlCommand($"UPDATE ProjectSales SET SaleID = '{textBox2.Text}', datePurchase = \"{textBox3.Text}\" WHERE ProjectID = {id_selected_rows}", db.getConnection()); // запрос на изменения данных в выбранной строки, и присвоение ей новых данных, вписаных в текстбоксы
                MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Данные изменены" : "Данные изменены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); // что выводится на экран при успешном выполнении
                db.closeConnection(); // отключаем подключение к БД
                textboxNoVisibleText();
            }
            catch
            {
                DialogResult res = new DialogResult();
                res = MessageBox.Show("Данные не изменены!", "Строка не выбрана!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error); // обработка исключения
                if (res == DialogResult.Cancel) //если нажимаем кнопку отмена, то у нас высвечивается уже отрытая таблица
                {
                    ProjectSalesSelect();
                }
                else
                {
                    return; // возвращаем всё то, что было до нажатия кнопку (данные в таблице высвечиваются, при этом никак не измененные)
                }
                db.closeConnection(); // отключаем подключение к БД
            }
        }
        private void SalesSelect()
        {
            string commandStr = "SELECT SaleID AS 'Код продажи', saleDate AS 'Дата продажи', saleNotes AS 'Кол-во страниц', saleCost AS 'Цена в рублях' FROM Sales"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            table = new DataTable(); // класс для таблиц
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            dataGridViewTransformData2.DataSource = bSource; // показывается таблица при выборе вкладки
            dataGridViewTransformData2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            dataGridViewTransformData2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)
            // сокрытие и показ всех необходимых элементов формы
            // текстбоксы куда мы вводим данные в таблицу, для дальнейшей работы с ними
            textBox1.Visible = false; 
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            // номера столбцов
            Column1Label.Visible = false;
            Column2Label.Visible = true;
            Column3Label.Visible = true;
            Column4Label.Visible = true;
            Column5Label.Visible = false;
            Column6Label.Visible = false;
            Column7Label.Visible = false;
            // кнопки добавления новой строки в таблицу
            AddLineButton.Visible = false;
            AddLineButton2.Visible = false;
            AddLineButton3.Visible = false;
            AddLineButton4.Visible = false;
            AddLineButton5.Visible = true;
            AddLineButton6.Visible = false;
            // кнопки удаления строки, выбранной клавишой ЛКМ
            DeleteLineButton.Visible = false;
            DeleteLineButton2.Visible = false;
            DeleteLineButton3.Visible = false;
            DeleteLineButton4.Visible = false;
            DeleteLineButton5.Visible = true;
            DeleteLineButton6.Visible = false;
            // кнопки изменения строки, выбранной клавишой ЛКМ (необходимо ввести новые данные в текстбоксы)
            UpdateLineButton1.Visible = false;
            UpdateLineButton2.Visible = false;
            UpdateLineButton3.Visible = false;
            UpdateLineButton4.Visible = false;
            UpdateLineButton5.Visible = true;
            UpdateLineButton6.Visible = false;
            // кнопки обновления данных в таблице
            RefreshButton1.Visible = false;
            RefreshButton2.Visible = false;
            RefreshButton3.Visible = false;
            RefreshButton4.Visible = false;
            RefreshButton5.Visible = true;
            RefreshButton6.Visible = false;
        }
        private void ценаToolStripMenuItem_Click(object sender, EventArgs e) // кнопка вывода данных из БД в datagrid в виде таблицы
        {
            SalesSelect();
        }
        private void SupplemenEmloyee5() // метод добавления новой строки в таблице и перенос её в БД
        {
            try
            {
                db.openConnection(); // осуществляем подключение к БД
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO Sales(saleDate, saleNotes, saleCost) VALUES( \"{textBox2.Text}\", {textBox3.Text}, {textBox4.Text})", db.getConnection()); // запрос к БД на добавление новой строки в таблицу (данные введены через текстбоксы)
                MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Данные добавились" : "Данные  добавились", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); // что выводится на экран при успешном выполнении
                db.closeConnection(); // отключаем подключение к БД
                textboxNoVisibleText();
            }
            catch
            {
                DialogResult res = new DialogResult();
                res = MessageBox.Show("Данные не добавились!", "Ошибка ввода!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // обработка исключения
                if (res == DialogResult.Cancel) //если нажимаем кнопку отмена, то у нас высвечивается уже отрытая таблица
                {
                    SalesSelect();
                }
                else
                {
                    return; // возвращаем всё то, что было до нажатия кнопку (данные в таблице высвечиваются, при этом никак не измененные)
                }
                db.closeConnection(); // отключаем подключение к БД
            }
        }
        private void DeleteTable5() // метод удаления строки в таблице и перенос её в БД
        {
            try
            {
                db.openConnection(); // осуществляем подключение к БД
                MySqlCommand cmd = new MySqlCommand($"DELETE FROM Sales WHERE SaleID = {id_selected_rows}", db.getConnection()); // удаление выбранной строки из таблицы, и перенос обновленной таблицы в БД
                MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Данные удалены" : "Данные  удалены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); // что выводится на экран при успешном выполнении
                db.closeConnection(); // отключаем подключение к БД
            }
            catch
            {
                DialogResult res = new DialogResult();
                res = MessageBox.Show("Данные не удалены!", "Строка не выбрана!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error); // обработка исключения
                if (res == DialogResult.Cancel) //если нажимаем кнопку отмена, то у нас высвечивается уже отрытая таблица
                {
                    SalesSelect();
                }
                else
                {
                    return; // возвращаем всё то, что было до нажатия кнопку (данные в таблице высвечиваются, при этом никак не измененные)
                }
                db.closeConnection(); // отключаем подключение к БД
            }
        }
        private void UpdateTable5() // метод изменения строки в таблице и перенос её в БД
        {
            try
            {
                db.openConnection(); // осуществляем подключение к БД
                MySqlCommand cmd = new MySqlCommand($"UPDATE Sales SET saleDate = \"{textBox2.Text}\", saleNotes = {textBox3.Text}, saleCost = {textBox4.Text} WHERE SaleID = {id_selected_rows}", db.getConnection()); // запрос на изменения данных в выбранной строки, и присвоение ей новых данных, вписаных в текстбоксы
                MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Данные изменены" : "Данные изменены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); // что выводится на экран при успешном выполнении
                db.closeConnection(); // отключаем подключение к БД
                textboxNoVisibleText();
            }
            catch
            {
                DialogResult res = new DialogResult();
                res = MessageBox.Show("Данные не изменены!", "Строка не выбрана!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error); // обработка исключения
                if (res == DialogResult.Cancel) //если нажимаем кнопку отмена, то у нас высвечивается уже отрытая таблица
                {
                    SalesSelect();
                }
                else
                {
                    return; // возвращаем всё то, что было до нажатия кнопку (данные в таблице высвечиваются, при этом никак не измененные)
                }
                db.closeConnection(); // отключаем подключение к БД
            }
        }
        private void AutorizationSelect()
        {
            string commandStr = "SELECT AuthorizationID AS 'Код авторизации', EmployeesID AS 'Код сотрудника', employeesJobTitle AS 'Профессия', login AS 'Логин', password AS 'Пароль', roleTitle AS 'Название роли', levelRole AS 'Уровень роли' FROM authorization"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            table = new DataTable(); // класс для таблиц
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
            // сокрытие и показ всех необходимых элементов формы
            // текстбоксы куда мы вводим данные в таблицу, для дальнейшей работы с ними
            textBox1.Visible = false; 
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            // номера столбцов
            Column1Label.Visible = false;
            Column2Label.Visible = true;
            Column3Label.Visible = true;
            Column4Label.Visible = true;
            Column5Label.Visible = true;
            Column6Label.Visible = true;
            Column7Label.Visible = true;
            // кнопки добавления новой строки в таблицу
            AddLineButton.Visible = false;
            AddLineButton2.Visible = false;
            AddLineButton3.Visible = false;
            AddLineButton4.Visible = false;
            AddLineButton5.Visible = false;
            AddLineButton6.Visible = true;
            // кнопки удаления строки, выбранной клавишой ЛКМ
            DeleteLineButton.Visible = false;
            DeleteLineButton2.Visible = false;
            DeleteLineButton3.Visible = false;
            DeleteLineButton4.Visible = false;
            DeleteLineButton5.Visible = false;
            DeleteLineButton6.Visible = true;
            // кнопки изменения строки, выбранной клавишой ЛКМ (необходимо ввести новые данные в текстбоксы)
            UpdateLineButton1.Visible = false;
            UpdateLineButton2.Visible = false;
            UpdateLineButton3.Visible = false;
            UpdateLineButton4.Visible = false;
            UpdateLineButton5.Visible = false;
            UpdateLineButton6.Visible = true;
            // кнопки обновления данных в таблице
            RefreshButton1.Visible = false;
            RefreshButton2.Visible = false;
            RefreshButton3.Visible = false;
            RefreshButton4.Visible = false;
            RefreshButton5.Visible = false;
            RefreshButton6.Visible = true;
        }
        private void вТаблицеАвторизацииToolStripMenuItem_Click(object sender, EventArgs e) // кнопка вывода данных из БД в datagrid в виде таблицы
        {
            AutorizationSelect();
        }
        private void SupplemenEmloyee6() // метод добавления новой строки в таблице и перенос её в БД
        {
            try
            {
                db.openConnection(); // осуществляем подключение к БД
                MySqlCommand cmd = new MySqlCommand($"INSERT INTO authorization(EmployeesID, employeesJobTitle, login, password, roleTitle, levelRole ) VALUES( '{textBox2.Text}', '{textBox3.Text}','{textBox4.Text}','{sha256(textBox5.Text)}','{textBox6.Text}',{textBox7.Text})", db.getConnection()); // запрос к БД на добавление новой строки в таблицу (данные введены через текстбоксы)
                MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Данные добавились" : "Данные  добавились", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); // что выводится на экран при успешном выполнении
                db.closeConnection(); // отключаем подключение к БД
                textboxNoVisibleText();
            }
            catch
            {
                DialogResult res = new DialogResult();
                res = MessageBox.Show("Данные не добавились!", "Ошибка ввода!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // обработка исключения
                if (res == DialogResult.Cancel) //если нажимаем кнопку отмена, то у нас высвечивается уже отрытая таблица
                {
                    AutorizationSelect();
                }
                else
                {
                    return; // возвращаем всё то, что было до нажатия кнопку (данные в таблице высвечиваются, при этом никак не измененные)
                }
                db.closeConnection(); // отключаем подключение к БД
            }
        }
        private void DeleteTable6() // метод удаления строки в таблице и перенос её в БД
        {
            try
            {
                db.openConnection(); // осуществляем подключение к БД
                MySqlCommand cmd = new MySqlCommand($"DELETE FROM authorization WHERE AuthorizationID = {id_selected_rows}", db.getConnection()); // удаление выбранной строки из таблицы, и перенос обновленной таблицы в БД
                MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Данные удалены" : "Данные  удалены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); // что выводится на экран при успешном выполнении
                db.closeConnection(); // отключаем подключение к БД
            }
            catch
            {
                DialogResult res = new DialogResult();
                res = MessageBox.Show("Данные не удалены!", "Строка не выбрана!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error); // обработка исключения
                if (res == DialogResult.Cancel) //если нажимаем кнопку отмена, то у нас высвечивается уже отрытая таблица
                {
                    AutorizationSelect();
                }
                else
                {
                    return; // возвращаем всё то, что было до нажатия кнопку (данные в таблице высвечиваются, при этом никак не измененные)
                }
                db.closeConnection(); // отключаем подключение к БД
            }
        }
        private void UpdateTable6() // метод изменения строки в таблице и перенос её в БД
        {
            try
            {
                db.openConnection(); // осуществляем подключение к БД
                MySqlCommand cmd = new MySqlCommand($"UPDATE authorization SET EmployeesID = '{textBox2.Text}', employeesJobTitle = '{textBox3.Text}', login = '{textBox4.Text}', password = '{sha256(textBox5.Text)}', roleTitle = '{textBox6.Text}', levelRole = {textBox7.Text} WHERE AuthorizationID = {id_selected_rows}", db.getConnection()); // запрос на изменения данных в выбранной строки, и присвоение ей новых данных, вписаных в текстбоксы
                MessageBox.Show(cmd.ExecuteNonQuery() > 0 ? "Данные изменены" : "Данные изменены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); // что выводится на экран при успешном выполнении
                db.closeConnection(); // отключаем подключение к БД
                textboxNoVisibleText();
            }
            catch
            {
                DialogResult res = new DialogResult();
                res = MessageBox.Show("Данные не изменены!", "Строка не выбрана!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error); // обработка исключения
                if (res == DialogResult.Cancel) //если нажимаем кнопку отмена, то у нас высвечивается уже отрытая таблица
                {
                    AutorizationSelect();
                }
                else
                {
                    return; // возвращаем всё то, что было до нажатия кнопку (данные в таблице высвечиваются, при этом никак не измененные)
                }
                db.closeConnection(); // отключаем подключение к БД
            }
        }
        // метод убирающий текст из текстбоксов (срабатывает при успешном добавлении и изменении данных в таблице)
        private void textboxNoVisibleText()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }
        // кнопки добавления данных в таблицу
        private void AddLineButton_Click(object sender, EventArgs e)
        {
            SupplemenEmloyee();
            EmployeesSelect();
        }
        private void AddLineButton2_Click(object sender, EventArgs e)
        {
            SupplemenEmloyee2();
            CustomerSelect();
        }
        private void AddLineButton3_Click(object sender, EventArgs e)
        {
            SupplemenEmloyee3();
            ProjectOrderSelect();
        }
        private void AddLineButton4_Click(object sender, EventArgs e)
        {
            SupplemenEmloyee4();
            ProjectSalesSelect();
        }
        private void AddLineButton5_Click(object sender, EventArgs e)
        {
            SupplemenEmloyee5();
            SalesSelect();
        }
        private void AddLineButton6_Click(object sender, EventArgs e)
        {
            SupplemenEmloyee6();
            AutorizationSelect();
        }
        // кнопки удаления данных в таблице
        private void DeleteLineButton_Click(object sender, EventArgs e)
        {
            DeleteTable();
            EmployeesSelect();
        }
        private void DeleteLineButton2_Click(object sender, EventArgs e)
        {
            DeleteTable2();
            CustomerSelect();
        }
        private void DeleteLineButton3_Click(object sender, EventArgs e)
        {
            DeleteTable3();
            ProjectOrderSelect();
        }
        private void DeleteLineButton4_Click(object sender, EventArgs e)
        {
            DeleteTable4();
            ProjectSalesSelect();
        }
        private void DeleteLineButton5_Click(object sender, EventArgs e)
        {
            DeleteTable5();
            SalesSelect();
        }
        private void DeleteLineButton6_Click(object sender, EventArgs e)
        {
            DeleteTable6();
            AutorizationSelect();
        }
        // кнопки изменения данных в таблице
        private void UpdateLineButton1_Click(object sender, EventArgs e)
        {
            UpdateTable();
            EmployeesSelect();
        }
        private void UpdateLineButton2_Click(object sender, EventArgs e)
        {
            UpdateTable2();
            CustomerSelect();
        }
        private void UpdateLineButton3_Click(object sender, EventArgs e)
        {
            UpdateTable3();
            ProjectOrderSelect();
        }
        private void UpdateLineButton4_Click(object sender, EventArgs e)
        {
            UpdateTable4();
            ProjectSalesSelect();
        }

        private void UpdateLineButton5_Click(object sender, EventArgs e)
        {
            UpdateTable5();
            SalesSelect();
        }

        private void UpdateLineButton6_Click(object sender, EventArgs e)
        {
            UpdateTable6();
            AutorizationSelect();
        }
        // кнопки обновления данных в выбранной таблице
        private void RefreshButton1_Click(object sender, EventArgs e)
        {
            EmployeesSelect();
            MessageBox.Show("Данные в таблице сотрудников обновлены", "Таблица сотрудников", MessageBoxButtons.OK, MessageBoxIcon.Information); // MessageBox показывает в какой таблице произошли изменения
        }

        private void RefreshButton2_Click(object sender, EventArgs e)
        {
            CustomerSelect();
            MessageBox.Show("Данные в таблице заказчиков обновлены", "Таблица заказчиков", MessageBoxButtons.OK, MessageBoxIcon.Information); // MessageBox показывает в какой таблице произошли изменения
        }

        private void RefreshButton3_Click(object sender, EventArgs e)
        {
            ProjectOrderSelect();
            MessageBox.Show("Данные в таблице заказов обновлены", "Таблица заказов", MessageBoxButtons.OK, MessageBoxIcon.Information); // MessageBox показывает в какой таблице произошли изменения
        }

        private void RefreshButton4_Click(object sender, EventArgs e)
        {
            ProjectSalesSelect();
            MessageBox.Show("Данные в таблице покупок обновлены", "Таблица покупок", MessageBoxButtons.OK, MessageBoxIcon.Information); // MessageBox показывает в какой таблице произошли изменения
        }

        private void RefreshButton5_Click(object sender, EventArgs e)
        {
            SalesSelect();
            MessageBox.Show("Данные в таблице продаж обновлены", "Таблица продаж", MessageBoxButtons.OK, MessageBoxIcon.Information); // MessageBox показывает в какой таблице произошли изменения
        }

        private void RefreshButton6_Click(object sender, EventArgs e)
        {
            AutorizationSelect();
            MessageBox.Show("Данные в таблице авторзации обновлены", "Таблица авторзации", MessageBoxButtons.OK, MessageBoxIcon.Information);// MessageBox показывает в какой таблице произошли изменения
        }

        private void dataGridViewTransformData2_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!e.RowIndex.Equals(-1) && !e.ColumnIndex.Equals(-1) && e.Button.Equals(MouseButtons.Right))
            {
                dataGridViewTransformData2.CurrentCell = dataGridViewTransformData2[e.ColumnIndex, e.RowIndex];
                dataGridViewTransformData2.CurrentCell.Selected = true;
                //Метод получения ID выделенной строки в глобальную переменную
                GetSelectedIDString();
            }
        }
        private void dataGridViewTransformData2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridViewTransformData2.CurrentCell = dataGridViewTransformData2[e.ColumnIndex, e.RowIndex];
            dataGridViewTransformData2.CurrentRow.Selected = true;
            //Метод получения ID выделенной строки в глобальную переменную
            GetSelectedIDString();
        }
        public void GetSelectedIDString()
        {
            //Переменная для индекса выбранной строки в гриде
            string index_selected_rows;
            //Индекс выбранной строки
            index_selected_rows = dataGridViewTransformData2.SelectedCells[0].RowIndex.ToString();
            //ID конкретной записи в Базе данных, на основании индекса строки
            id_selected_rows = dataGridViewTransformData2.Rows[Convert.ToInt32(index_selected_rows)].Cells[0].Value.ToString();//Указываем ID выделенной строки в метке
        }
    }
}
