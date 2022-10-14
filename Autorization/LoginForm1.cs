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


            this.passwordName.AutoSize = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loginName_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordName_TextChanged(object sender, EventArgs e)
        {
            
        }
        Point lastPoint; // специальный класс для задачи координат
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void buttonLoginPass_Click(object sender, EventArgs e)
        {
            //Получаем данные о пользователе
            string Userlogin = loginName.Text;
            string Userpassword = sha256(passwordName.Text);
            //Создаем объекты
            DBclass db = new DBclass();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            //Указываем команду, которая должна выполниться в отношении базы данных
            MySqlCommand command = new MySqlCommand("SELECT * FROM `authorization` WHERE `login` = @Login AND `password` = @Password", db.getConnection());
            command.Parameters.Add("@Login", MySqlDbType.VarChar).Value = Userlogin;
            command.Parameters.Add("@Password", MySqlDbType.VarChar).Value = Userpassword;

            //Выбор данных
            adapter.SelectCommand = command;
            //Помещение их в объект
            adapter.Fill(table);

            //Проверка на верность данных (логин и пароль)
            if (table.Rows.Count > 0)
                MessageBox.Show("Успешная авторизация!");
            else
                MessageBox.Show("Логин или пароль указан неверно.");
        }
    }
}
