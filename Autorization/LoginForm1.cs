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
            this.passwordName.AutoSize = false; // отключается авторазмер у пароля
        }
        private void label4_Click(object sender, EventArgs e)
        {
            this.Close(); // лэйбл является кнопкой закрытия формы
        }
        private void loginName_TextChanged(object sender, EventArgs e)
        {
        }
        private void passwordName_TextChanged(object sender, EventArgs e)
        {
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
            string Userlogin = loginName.Text;
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
                int Id = int.Parse(table.Rows[0].ItemArray[0].ToString());
                db.openConnection();
                string _Role = $"SELECT levelRole FROM `authorization` WHERE AuthorizationID = {Id}"; // запрос роли, которая относится к логину
                MySqlCommand cmd2 = new MySqlCommand(_Role, db.getConnection());
                int Level = int.Parse(cmd2.ExecuteScalar().ToString());
                 _Role = $"SELECT roleTitle FROM `authorization` WHERE AuthorizationID = {Id}"; // запрос названия роли
                 cmd2 = new MySqlCommand(_Role, db.getConnection());
                string title = cmd2.ExecuteScalar().ToString();
                //запоним кто вошел
                Username user = new Username(loginName.Text, Level);
                MainForm mainForm = new MainForm(); // после авторизации показывается MainForm
                mainForm.Show();
                db.closeConnection();
                this.Hide();
            }
            else 
                MessageBox.Show("Логин или пароль указан неверно."); // обработка исключения
        }
    }
}
