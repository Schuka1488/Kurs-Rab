using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;

namespace Autorization
{
    public partial class TabelForm : Form
    {
        Point lastPoint; // специальный класс для задачи координат
        int year;
        int month;
        public TabelForm()
        {
            InitializeComponent();
        }
        private void TabelForm_Load(object sender, EventArgs e)
        {
            chromiumWebBrowser1.JavascriptMessageReceived += OnBrowserJavascriptMessageReceived;
        }
        private void OnBrowserJavascriptMessageReceived(object sender, JavascriptMessageReceivedEventArgs e)
        {
             var windowSelection = (string)e.Message;
            ChangeTabelForm edit = new ChangeTabelForm(windowSelection, year, month);
            edit.ShowDialog();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            month = DateTime.Now.Month;
            year = DateTime.Now.Year;
            TimeSheetGenerator generator = new TimeSheetGenerator(year, month);
            ClassForTabel loader = new ClassForTabel();
            loader.LoadDataFromBD(DateTime.Now);
            loader.LoadAllIntoBuilder(generator);
            string html  = generator.GenCode();
            File.WriteAllText("tmp.html", html);
            string formater = Directory.GetCurrentDirectory();

            formater = formater.Replace('\\', '/');
            chromiumWebBrowser1.Load($"file://{formater}/tmp.html");

            button1.Visible = false;
            buttonRefresh.Visible = true;
        }
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            month = DateTime.Now.Month;
            year = DateTime.Now.Year;
            TimeSheetGenerator generator = new TimeSheetGenerator(year, month);
            ClassForTabel loader = new ClassForTabel();
            loader.LoadDataFromBD(DateTime.Now);
            loader.LoadAllIntoBuilder(generator);
            string html = generator.GenCode();
            File.WriteAllText("tmp.html", html);
            string formater = Directory.GetCurrentDirectory();

            formater = formater.Replace('\\', '/');
            chromiumWebBrowser1.Load($"file://{formater}/tmp.html");

            button1.Visible = false;
            buttonRefresh.Visible = true;
        }
        private void buttonCloseTabel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void TabelForm_MouseDown(object sender, MouseEventArgs e) => lastPoint = new Point(e.X, e.Y);//метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на панели
        private void TabelForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) //определяет координату панели по оси X и Y, считывает ее перемещение при нажатии на ЛКМ
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
    }
}
