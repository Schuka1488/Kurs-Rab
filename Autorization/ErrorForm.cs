using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;

namespace Autorization
{
    public partial class ErrorForm : Form
    {
        Point lastPoint; // специальный класс для задачи координат
        public static void Show(string desc)
        {
            ErrorForm error = new ErrorForm(desc);
            error.ShowDialog();
        }
        string desc;
        public ErrorForm(string desc)
        {
            InitializeComponent();
            this.desc = desc;
        }
        private void ErrorForm_Load(object sender, EventArgs e)
        {
            chromiumWebBrowser1.LoadHtml(Properties.Resources.errors);
            
            Desc.Text = desc;

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
        private void ExitButtonErrorForm_Click(object sender, EventArgs e)
        {
            this.Hide(); // эта форма скрывается
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e) => lastPoint = new Point(e.X, e.Y);//метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на панели
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) //определяет координату панели по оси X и Y, считывает ее перемещение при нажатии на ЛКМ
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private void ExitButtonErrorForm_MouseDown(object sender, MouseEventArgs e) => lastPoint = new Point(e.X, e.Y);//метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на панели
        private void ExitButtonErrorForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) //определяет координату панели по оси X и Y, считывает ее перемещение при нажатии на ЛКМ
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private void chromiumWebBrowser1_MouseDown(object sender, MouseEventArgs e) => lastPoint = new Point(e.X, e.Y);//метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на панели
        private void chromiumWebBrowser1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) //определяет координату панели по оси X и Y, считывает ее перемещение при нажатии на ЛКМ
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private void Desc_MouseDown(object sender, MouseEventArgs e) => lastPoint = new Point(e.X, e.Y);//метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на панели
        private void Desc_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) //определяет координату панели по оси X и Y, считывает ее перемещение при нажатии на ЛКМ
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private void ErrorForm_MouseDown(object sender, MouseEventArgs e) => lastPoint = new Point(e.X, e.Y);//метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на панели
        private void ErrorForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) //определяет координату панели по оси X и Y, считывает ее перемещение при нажатии на ЛКМ
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
    }
}
