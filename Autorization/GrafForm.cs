using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ScottPlot;

namespace Autorization
{
    public partial class GrafForm : Form
    {
        DataTable table; // глобальная переменная для простоты вывода в Microsoft Word
        private BindingSource bSource = new BindingSource(); // обьявлен для связи с источником соединения
        DBclass db = new DBclass(); // переменная класса для БД, и последующей работе с ними
        Point lastPoint; // специальный класс для задачи координат
        public GrafForm()
        {
            InitializeComponent();
        }

        private void GrafForm_Load(object sender, EventArgs e)
        {
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

        private void CloseGrafFormbutton_Click(object sender, EventArgs e)
        {
            this.Hide(); // эта форма скрывается
        }

        private void BuildGrafButton_Click(object sender, EventArgs e)
        {
            string commandStr = "SELECT saleDate AS 'sd', saleCost AS 'sc' FROM Sales ORDER BY saleDate ASC"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            table = new DataTable(); // создание элемента таблицы
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            List<double> Xa = new List<double>();
            List<double> Ya = new List<double>();

            foreach(DataRow row in table.Rows)
            {
                DateTime date = DateTime.Parse(row.ItemArray[0].ToString());
                double value = Convert.ToDouble(row.ItemArray[1].ToString());

                Xa.Add(date.ToOADate());
                Ya.Add(value);
            }

            var splt = new ScottPlot.Plottable.ScatterPlot(Xa.ToArray(), Ya.ToArray());
            splt.Color = Color.Navy;
            splt.MarkerSize = 10;
            splt.MarkerShape = MarkerShape.filledDiamond;
            formsPlot1.plt.Add(splt);

            formsPlot1.plt.XAxis.DateTimeFormat(true);

            formsPlot1.plt.Legend();

            formsPlot1.plt.AddHorizontalLine(.85);

            formsPlot1.plt.XAxis.Label("Дата");
            formsPlot1.plt.YAxis.Label("Руб");

            formsPlot1.Refresh();
        }
        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            // Determine how large you want the plot to be on the page and resize accordingly
            int width = e.MarginBounds.Width;
            int height = (int)(e.MarginBounds.Width * .5);
            formsPlot1.Plot.Resize(width, height);

            // Give the plot a white background so it looks good on white paper
            formsPlot1.Plot.Style(figureBackground: Color.White);

            // Render the plot as a Bitmap and draw it onto the page
            Bitmap bmp = formsPlot1.Plot.Render();
            e.Graphics.DrawImage(bmp, e.MarginBounds.Left, e.MarginBounds.Top);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var printDocument = new System.Drawing.Printing.PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintPage);
            var printDialog = new PrintDialog { Document = printDocument };
            var printDiagResult = printDialog.ShowDialog();
            if (printDiagResult == DialogResult.OK)
                printDocument.Print();

        }
        private void GrafForm_MouseDown(object sender, MouseEventArgs e) => lastPoint = new Point(e.X, e.Y);//метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на панели
        private void GrafForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) //определяет координату панели по оси X и Y, считывает ее перемещение при нажатии на ЛКМ
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private void chart1_MouseDown(object sender, MouseEventArgs e) => lastPoint = new Point(e.X, e.Y);//метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на панели
        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) //определяет координату панели по оси X и Y, считывает ее перемещение при нажатии на ЛКМ
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
    }
}
