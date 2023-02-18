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
using Tulpep.NotificationWindow;
using System.Threading;

namespace Autorization
{
    public partial class LoginForm1 : Form
    {
        int dR, dG, dB, sign; // переменные для rgb и индекса таймера
        Point lastPoint; // специальный класс для задачи координат
        static string sha256(string randomString)
        {
            //Тут происходит криптографическая магия. Смысл данного метода заключается в том, что строка залетает в метод
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
        public LoginForm1()
        {
            InitializeComponent();
            animateComponent1.ShowForm(750); //компонент для плавного показа формы
            this.passwordName.AutoSize = false; // отключается авторазмер у пароля
        }
        private void LoginForm1_Load(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip(); // тул тип для подсказок
            toolTip1.AutoPopDelay = 5000; // параметры показа подсказки, в течении какого времени будет видна подсказка
            toolTip1.InitialDelay = 100; // в течении какого кол-ва времени после наведения курсора будет показываться подсказка
            toolTip1.ReshowDelay = 500; // возвращает или задает интервал времени, который должен пройти перед появлением окна очередной всплывающей подсказки при перемещении указателя мыши с одного элемента управления на другой.
            toolTip1.ShowAlways = true; // статус видимости
            toolTip1.SetToolTip(label4, "Закрытие программы");

            this.FormBorderStyle = FormBorderStyle.None;
            Panel pnlTop = new Panel() { Height = 4, Dock = DockStyle.Top, BackColor = SystemColors.ActiveBorder };
            this.Controls.Add(pnlTop);
            Panel pnlRight = new Panel() { Width = 4, Dock = DockStyle.Right, BackColor = SystemColors.ActiveBorder };
            this.Controls.Add(pnlRight);
            Panel pnlBottom = new Panel() { Height = 4, Dock = DockStyle.Bottom, BackColor = SystemColors.ActiveBorder };
            this.Controls.Add(pnlBottom);
            Panel pnlLeft = new Panel() { Width = 4, Dock = DockStyle.Left, BackColor = SystemColors.ActiveBorder };
            this.Controls.Add(pnlLeft);
        }
        private void label4_Click(object sender, EventArgs e) // кнопка выхода из программы реализованная в качестве лейбла
        {
            DialogResult res = new DialogResult(); // переменная для обработки выбранных кнопок в MessageBox
            res = MessageBox.Show("Вы действительно хотите выйти?", "Выход из программы", MessageBoxButtons.YesNo, MessageBoxIcon.Question); //Настройка MessageBox
            if (res == DialogResult.Yes) // при нажатии на "Да" происходит выход из программы
            {
                Application.Exit(); // выход из программы
            }
            else
            {
                return; // при нажатии на "Нет" MessageBox убирается(возвращается всё то, что было до нажатия на кнопку при помощи return)
            }
            animateComponent1.CloseForm(750); //компонент для плавного закрытия формы
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)  //метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на панели
        {
            if (e.Button == MouseButtons.Left) //определяет координату панели по оси X и Y, считывает ее перемещение при нажатии на ЛКМ
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e) => lastPoint = new Point(e.X, e.Y);//метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на панели
        private void panel2_MouseMove(object sender, MouseEventArgs e) //метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на панели
        {
            if (e.Button == MouseButtons.Left) //определяет координату панели по оси X и Y, считывает ее перемещение при нажатии на ЛКМ
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private void panel2_MouseDown(object sender, MouseEventArgs e) => lastPoint = new Point(e.X, e.Y);//метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на панели
        private void WhiteThemeButton_Click(object sender, EventArgs e) // кнопка светлой темы
        {
            panel1.BackColor = ThemeMethodClass.Theme.LightColor2; // все элементы которые меняют свой цвет, который заявлен в специально созданном для этого классе
            panel2.BackColor = ThemeMethodClass.Theme.LightColor;
            dR = labelTheme.BackColor.R - labelTheme.ForeColor.R; // плавное переливание текста в другой (при помощи rgb цвет фона не изменятся)
            dG = labelTheme.BackColor.G - labelTheme.ForeColor.G;
            dB = labelTheme.BackColor.B - labelTheme.ForeColor.B;
            sign = 2; // знак таймера
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer(); // создаем таймер
            timer.Interval = 4; // интевал, после которого снова можно будет осуществить нажатие
            timer.Tick += timer2_Tick; // при нажатии включается таймер
            timer.Start(); // включается таймер
        }
        private void DarkThemeButton_Click(object sender, EventArgs e) // кнопка темной темы
        {
            panel1.BackColor = ThemeMethodClass.Theme.DarkColor2; // все элементы которые меняют свой цвет, который заявлен в специально созданном для этого классе
            panel2.BackColor = ThemeMethodClass.Theme.DarkColor;
            dR = labelTheme.BackColor.R - labelTheme.ForeColor.R; // плавное переливание текста в другой (при помощи rgb цвет фона не изменятся)
            dG = labelTheme.BackColor.G - labelTheme.ForeColor.G;
            dB = labelTheme.BackColor.B - labelTheme.ForeColor.B;
            sign = 1; // знак таймера
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer(); // создаем таймер
            timer.Interval = 4; // интевал, после которого снова можно будет осуществить нажатие
            timer.Tick += timer1_Tick; // при нажатии включается таймер
            timer.Start(); // включается таймер
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // ссылка на сайт организации, на которую можно нажать
        {
            System.Diagnostics.Process.Start("http://www.интэкс-сервис.рф");
            this.linkLabel1.Name = "CompanyLinks";
            this.linkLabel1.LinkColor = Color.Purple;
            this.linkLabel1.ActiveLinkColor = Color.Blue;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Math.Abs(labelTheme.ForeColor.R - labelTheme.BackColor.R) < Math.Abs(dR / 10)) // создаем интервал для перехода цветов 
                {
                    sign *= -1;
                    labelTheme.Text = "Темная тема вкл."; // указваем какой текст хотим видеть в лейбле
                }
                labelTheme.ForeColor = Color.FromArgb(255, labelTheme.ForeColor.R + sign * dR / 10, labelTheme.ForeColor.G + sign * dG / 10, labelTheme.ForeColor.B + sign * dB / 10);
                if (labelTheme.BackColor.R == labelTheme.ForeColor.R + dR) // параметры для плавного перехода без потери цвета
                {
                    ((System.Windows.Forms.Timer)sender).Stop(); // таймер останавливается
                }
            }
            catch
            {
                ((System.Windows.Forms.Timer)sender).Stop(); // таймер останавливается
                MessageBox.Show("Не спеши! А то успеешь.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // обработка исключения
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Math.Abs(labelTheme.ForeColor.R - labelTheme.BackColor.R) < Math.Abs(dR / 10)) // создаем интервал для перехода цветов 
                {
                    sign *= -1;
                    labelTheme.Text = "Светлая тема вкл."; // указваем какой текст хотим видеть в лейбле
                }
                labelTheme.ForeColor = Color.FromArgb(255, labelTheme.ForeColor.R + sign * dR / 10, labelTheme.ForeColor.G + sign * dG / 10, labelTheme.ForeColor.B + sign * dB / 10);
                if (labelTheme.BackColor.R == labelTheme.ForeColor.R + dR) // параметры для плавного перехода без потери цвета
                {
                    ((System.Windows.Forms.Timer)sender).Stop(); // таймер останавливается
                }
            }
            catch
            {
                ((System.Windows.Forms.Timer)sender).Stop(); // таймер останавливается
                MessageBox.Show("Не спеши! А то успеешь.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // обработка исключения
            }
        }
        Thread thread1;
        MainForm mainForm = new MainForm();
        private void buttonLoginPass_Click(object sender, EventArgs e) // метод при помощи которого осуществляется авторизация и полноценные вход в приложение 
        {
            thread1 = new Thread(() => 
           { 
            //Получаем данные о пользователе
            string Userlogin = loginName.Text; // данные о пользователе из текстбокса loginName
            string Userpassword = sha256(passwordName.Text); // кодируем пароль
            //Создаем переменные
            DBclass db = new DBclass();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            //Указываем команду, которая должна выполниться в отношении базы данных (SQL запрос)
            MySqlCommand command = new MySqlCommand("SELECT * FROM `authorization` WHERE `login` = @Login AND `password` = @Password", db.getConnection()); // конект к базе данных SQL осущесвляется при помощи метода getConnection, который описан в отдельном классе
            command.Parameters.Add("@Login", MySqlDbType.VarChar).Value = Userlogin;
            command.Parameters.Add("@Password", MySqlDbType.VarChar).Value = Userpassword;
            //Выбор данных
            adapter.SelectCommand = command;
            //Помещение их в объект
            adapter.Fill(table);
            //Проверка на верность данных (логин и пароль)
            if (table.Rows.Count > 0)
            {
                int Id = int.Parse(table.Rows[0].ItemArray[0].ToString()); // переменные для проверки данных на верность помещаем в метод
                db.openConnection(); // открываем соединение
                string _Role = $"SELECT levelRole FROM `authorization` WHERE AuthorizationID = {Id}"; // запрос роли, которая относится к логину
                MySqlCommand cmd2 = new MySqlCommand(_Role, db.getConnection()); // осуществляется подключение к БД
                int Level = int.Parse(cmd2.ExecuteScalar().ToString()); // берутся значения из БД
                _Role = $"SELECT roleTitle FROM `authorization` WHERE AuthorizationID = {Id}"; // запрос названия роли
                cmd2 = new MySqlCommand(_Role, db.getConnection()); // осуществляется подключение к БД
                string title = cmd2.ExecuteScalar().ToString(); // берутся значения из БД
                Username user = new Username(loginName.Text, Level); // Запоминаем логин из текстбокса loginName
                //MainForm mainForm = new MainForm(); // после авторизации показывается MainForm
                this.Invoke(new Action (() => mainForm.Show())); // метод для показа MainForm
                db.closeConnection(); // Полсе обрубается соединение
                this.Invoke(new Action(() => Hide()));
                PopupNotifier popup = new PopupNotifier(); //создание новой переменной класса PopupNotifier NuGet компонента Tulpep
                popup.Image = Properties.Resources.pngres; // берем иконку из ресурсов проекта
                popup.ImageSize = new Size(80, 80); // задаем размер
                // задаем цвета для элементов всплвающего окна
                popup.HeaderColor = Color.DeepSkyBlue; // цвет верхней рамки
                popup.BodyColor = SystemColors.MenuBar; // цвет основной, для тела в рамке
                popup.TitleColor = Color.LightSlateGray; // цвет заголовка
                popup.ShowCloseButton = false; // убираем кнопку закрытия
                popup.TitleText = "ИНТЭКС-СЕРВИС"; // задаем текст
                popup.ContentText = $"Добро пожаловать {loginName.Text}!"; // выводим сообщение и логин вошедшего пользователя
                popup.Popup(); // после нажатия на кнопку высвечивается уведомление
            }
            else
            {
                MessageBox.Show("Логин или пароль указан неверно! (Код ошибки: 105)", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error); // обработка исключения
                ErrorForm.Show("Возникла ошибка!");
            }
         });
        thread1.Start();
        }
    }
}
