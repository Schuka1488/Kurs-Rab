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
    public partial class HistoryForm : Form
    {
        System.Data.DataTable table; // глобальная переменная для простоты вывода в Microsoft Word
        DBclass db = new DBclass(); // переменная класса для БД, и последующей работе с ними
        private BindingSource bSource = new BindingSource(); // обьявлен для связи с источником соединения
        Point lastPoint; // специальный класс для задачи координат
        string id_selected_rows; // переменная для определения целой строки, по нажатию на поле id в dataGrid
        public HistoryForm()
        {
            InitializeComponent();
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None; // убрал все стили границ форму
            // добавил свои границы
            Panel pnlTop = new Panel() { Height = 4, Dock = DockStyle.Top, BackColor = SystemColors.ActiveBorder };
            this.Controls.Add(pnlTop);
            Panel pnlRight = new Panel() { Width = 4, Dock = DockStyle.Right, BackColor = SystemColors.ActiveBorder };
            this.Controls.Add(pnlRight);
            Panel pnlBottom = new Panel() { Height = 4, Dock = DockStyle.Bottom, BackColor = SystemColors.ActiveBorder };
            this.Controls.Add(pnlBottom);
            Panel pnlLeft = new Panel() { Width = 4, Dock = DockStyle.Left, BackColor = SystemColors.ActiveBorder };
            this.Controls.Add(pnlLeft);

            string commandStr = "SELECT Log_ID AS 'Код изменения', Log_EmployeesID AS 'Код сотрудника', Log_Desc AS 'Описание изменения', log_date AS 'Дата изменения' FROM LogTable"; // SQL запрос данных из БД
            MySqlCommand cmd = new MySqlCommand(commandStr, db.getConnection()); // осуществяется подключение к БД
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // используется адаптер для получения таблицы 
            table = new DataTable(); // класс для таблиц
            adapter.SelectCommand = cmd; // адаптер берет соединение
            adapter.Fill(table); // адаптер передает значение для того чтобы показать таблицу
            bSource.DataSource = table;  // принимается таблица для последующего показа таблицы
            dataGridView1.DataSource = bSource; // показывается таблица при выборе вкладки
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // автосайз для столбца для гридера (растягивает столбец по ширине)

            dataGridView1.ForeColor = Color.DeepSkyBlue;
            dataGridView1.GridColor = Color.DarkGray;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Lavender;
        }

        private void ExitButtonErrorForm_Click(object sender, EventArgs e)
        {
            this.Hide(); // эта форма скрывается
        }
        private void dataGridView1_MouseDown(object sender, MouseEventArgs e) => lastPoint = new Point(e.X, e.Y);//метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на панели
        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) //определяет координату панели по оси X и Y, считывает ее перемещение при нажатии на ЛКМ
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void HistoryForm_MouseDown(object sender, MouseEventArgs e) => lastPoint = new Point(e.X, e.Y);//метод который создан для того, чтобы можно было перетаксивать форму, зажимая лкм на панели
        private void HistoryForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) //определяет координату панели по оси X и Y, считывает ее перемещение при нажатии на ЛКМ
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        private void dataGridViewTransformData2_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!e.RowIndex.Equals(-1) && !e.ColumnIndex.Equals(-1) && e.Button.Equals(MouseButtons.Right))
            {
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
                dataGridView1.CurrentCell.Selected = true;
                //Метод получения ID выделенной строки в глобальную переменную
                GetSelectedIDString();
            }
        }
        private void dataGridViewTransformData2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
            dataGridView1.CurrentRow.Selected = true;
            //Метод получения ID выделенной строки в глобальную переменную
            GetSelectedIDString();
        }
        public void GetSelectedIDString()
        {
            //Переменная для индекса выбранной строки в гриде
            string index_selected_rows;
            //Индекс выбранной строки
            index_selected_rows = dataGridView1.SelectedCells[0].RowIndex.ToString();
            //ID конкретной записи в Базе данных, на основании индекса строки
            id_selected_rows = dataGridView1.Rows[Convert.ToInt32(index_selected_rows)].Cells[0].Value.ToString();//Указываем ID выделенной строки при выборе и делаем из нее полноценную строку string
        }
    }
}
