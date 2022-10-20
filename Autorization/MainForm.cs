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
        public MainForm()
        {
            InitializeComponent();

            textBox1.Text = "Введите название таблицы";
            textBox1.ForeColor = Color.Gray;
        }
        private void MainForm_Load(object sender, EventArgs e)
        { 
            if (Username.user1.Role == 1)
                изменитьДанныеToolStripMenuItem.Visible = true;
            else
                изменитьДанныеToolStripMenuItem.Visible = false;
        }
        Point lastPoint;
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        { 
        }
        private void panel2_MouseDown(object sender, MouseEventArgs e)
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
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private void программуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void формуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm1 auth = new LoginForm1();
            auth.Show();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "") 
            {
                textBox1.Text = "ВВЕДИТЕ НАЗВАНИЕ ТАБЛИЦЫ";
                textBox1.ForeColor = Color.DarkGray;
            }
        }
        private void textBox1_Enter(object sender, EventArgs e)
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
    }
}
