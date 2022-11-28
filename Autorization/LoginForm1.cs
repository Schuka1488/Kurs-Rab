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
    public partial class LoginForm1 : Form 
    {
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
            animateComponent1.ShowForm(750);
            this.passwordName.AutoSize = false; // отключается авторазмер у пароля
        }
        private void label4_Click(object sender, EventArgs e)
        {
            animateComponent1.CloseForm(750);
        }
        Point lastPoint; // специальный класс для задачи координат
        private void panel1_MouseMove(object sender, MouseEventArgs e)  //метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на панели
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e) //метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на панели
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
        private void panel2_MouseDown(object sender, MouseEventArgs e) //метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на панели
        {
            lastPoint = new Point(e.X, e.Y); // класс поинт создан для определении позиции в пространстве
        }
        private void buttonLoginPass_Click(object sender, EventArgs e) // метод при помощи которого осуществляется авторизация и полноценные вход в приложение 
        {
            //Получаем данные о пользователе
            string Userlogin = loginName.Text; // данные о пользователе из текстбокса loginName
            string Userpassword = sha256(passwordName.Text); // кодируем пароль
            //Создаем объекты
            DBclass db = new DBclass();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            //Указываем команду, которая должна выполниться в отношении базы данных
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
                MainForm mainForm = new MainForm(); // после авторизации показывается MainForm
                mainForm.Show(); // метод для показа MainForm
                db.closeConnection(); // Полсе обрубается соединение
                this.Hide(); // происходит сокрытие
            }
            else 
                MessageBox.Show("Логин или пароль указан неверно."); // обработка исключения
        }
        private void WhiteThemeButton_Click(object sender, EventArgs e)
        {
            ThemeMethodClass.LightThemeMethodLoginForm(panel1, panel2, label2, label3, buttonLoginPass, loginName, passwordName, DarkThemeButton, WhiteThemeButton, labelTheme);
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
            ThemeMethodClass.DarkThemeMethodLoginForm(panel1, panel2, label2, label3, buttonLoginPass, loginName, passwordName, DarkThemeButton, WhiteThemeButton, labelTheme);
            dR = labelTheme.BackColor.R - labelTheme.ForeColor.R;
            dG = labelTheme.BackColor.G - labelTheme.ForeColor.G;
            dB = labelTheme.BackColor.B - labelTheme.ForeColor.B;
            sign = 1;
            Timer timer = new Timer();
            timer.Interval = 10;
            timer.Tick += timer1_Tick;
            timer.Start();
        }

        private void LoginForm1_Load(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(label4, "Закрытие программы");
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
    }
}
