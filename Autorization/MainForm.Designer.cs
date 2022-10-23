
namespace Autorization
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LabelDeleteTable = new System.Windows.Forms.Label();
            this.DarkThemeBox1 = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.программуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.формуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вТаблицеСотрудникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вТаблицеЗаказчиковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вТаблицеЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вТаблицеПродажToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вТаблицеЦенToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицаСотрудниковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицаКлиентовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицаЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицаПродажToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицаЦенToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteTable = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.LabelDeleteTable);
            this.panel1.Controls.Add(this.DarkThemeBox1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.DeleteTable);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(635, 450);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // LabelDeleteTable
            // 
            this.LabelDeleteTable.AutoSize = true;
            this.LabelDeleteTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelDeleteTable.Location = new System.Drawing.Point(12, 400);
            this.LabelDeleteTable.Name = "LabelDeleteTable";
            this.LabelDeleteTable.Size = new System.Drawing.Size(193, 16);
            this.LabelDeleteTable.TabIndex = 8;
            this.LabelDeleteTable.Text = "Укажите название таблицы:";
            // 
            // DarkThemeBox1
            // 
            this.DarkThemeBox1.AutoSize = true;
            this.DarkThemeBox1.BackColor = System.Drawing.Color.Lavender;
            this.DarkThemeBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DarkThemeBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DarkThemeBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DarkThemeBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DarkThemeBox1.Location = new System.Drawing.Point(482, 414);
            this.DarkThemeBox1.Name = "DarkThemeBox1";
            this.DarkThemeBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DarkThemeBox1.Size = new System.Drawing.Size(142, 24);
            this.DarkThemeBox1.TabIndex = 7;
            this.DarkThemeBox1.Text = "ТЕМНАЯ ТЕМА";
            this.DarkThemeBox1.UseVisualStyleBackColor = false;
            this.DarkThemeBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DarkThemeBox1_MouseDown);
            this.DarkThemeBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DarkThemeBox1_MouseMove);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Lavender;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 106);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(611, 275);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDown);
            this.dataGridView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseMove);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(503, 387);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(12, 419);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(188, 21);
            this.textBox1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(635, 100);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.закрытьToolStripMenuItem,
            this.изменитьДанныеToolStripMenuItem,
            this.показатьДанныеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(635, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.программуToolStripMenuItem,
            this.формуToolStripMenuItem});
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.закрытьToolStripMenuItem.Text = "Выход";
            // 
            // программуToolStripMenuItem
            // 
            this.программуToolStripMenuItem.Name = "программуToolStripMenuItem";
            this.программуToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.программуToolStripMenuItem.Text = "Из программы";
            this.программуToolStripMenuItem.Click += new System.EventHandler(this.программуToolStripMenuItem_Click);
            // 
            // формуToolStripMenuItem
            // 
            this.формуToolStripMenuItem.Name = "формуToolStripMenuItem";
            this.формуToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.формуToolStripMenuItem.Text = "Из аккаунта";
            this.формуToolStripMenuItem.Click += new System.EventHandler(this.формуToolStripMenuItem_Click);
            // 
            // изменитьДанныеToolStripMenuItem
            // 
            this.изменитьДанныеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вТаблицеСотрудникиToolStripMenuItem,
            this.вТаблицеЗаказчиковToolStripMenuItem,
            this.вТаблицеЗаказовToolStripMenuItem,
            this.вТаблицеПродажToolStripMenuItem,
            this.вТаблицеЦенToolStripMenuItem});
            this.изменитьДанныеToolStripMenuItem.Name = "изменитьДанныеToolStripMenuItem";
            this.изменитьДанныеToolStripMenuItem.Size = new System.Drawing.Size(117, 20);
            this.изменитьДанныеToolStripMenuItem.Text = "Изменить данные";
            // 
            // вТаблицеСотрудникиToolStripMenuItem
            // 
            this.вТаблицеСотрудникиToolStripMenuItem.Name = "вТаблицеСотрудникиToolStripMenuItem";
            this.вТаблицеСотрудникиToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.вТаблицеСотрудникиToolStripMenuItem.Text = "В таблице сотрудников";
            // 
            // вТаблицеЗаказчиковToolStripMenuItem
            // 
            this.вТаблицеЗаказчиковToolStripMenuItem.Name = "вТаблицеЗаказчиковToolStripMenuItem";
            this.вТаблицеЗаказчиковToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.вТаблицеЗаказчиковToolStripMenuItem.Text = "В таблице заказчиков";
            // 
            // вТаблицеЗаказовToolStripMenuItem
            // 
            this.вТаблицеЗаказовToolStripMenuItem.Name = "вТаблицеЗаказовToolStripMenuItem";
            this.вТаблицеЗаказовToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.вТаблицеЗаказовToolStripMenuItem.Text = "В таблице заказов";
            // 
            // вТаблицеПродажToolStripMenuItem
            // 
            this.вТаблицеПродажToolStripMenuItem.Name = "вТаблицеПродажToolStripMenuItem";
            this.вТаблицеПродажToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.вТаблицеПродажToolStripMenuItem.Text = "В таблице продаж";
            // 
            // вТаблицеЦенToolStripMenuItem
            // 
            this.вТаблицеЦенToolStripMenuItem.Name = "вТаблицеЦенToolStripMenuItem";
            this.вТаблицеЦенToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.вТаблицеЦенToolStripMenuItem.Text = "В таблице цен";
            // 
            // показатьДанныеToolStripMenuItem
            // 
            this.показатьДанныеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.таблицаСотрудниковToolStripMenuItem,
            this.таблицаКлиентовToolStripMenuItem,
            this.таблицаЗаказовToolStripMenuItem,
            this.таблицаПродажToolStripMenuItem,
            this.таблицаЦенToolStripMenuItem});
            this.показатьДанныеToolStripMenuItem.Name = "показатьДанныеToolStripMenuItem";
            this.показатьДанныеToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.показатьДанныеToolStripMenuItem.Text = "Показать данные";
            // 
            // таблицаСотрудниковToolStripMenuItem
            // 
            this.таблицаСотрудниковToolStripMenuItem.Name = "таблицаСотрудниковToolStripMenuItem";
            this.таблицаСотрудниковToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.таблицаСотрудниковToolStripMenuItem.Text = "Таблица сотрудников";
            this.таблицаСотрудниковToolStripMenuItem.Click += new System.EventHandler(this.таблицаСотрудниковToolStripMenuItem_Click);
            // 
            // таблицаКлиентовToolStripMenuItem
            // 
            this.таблицаКлиентовToolStripMenuItem.Name = "таблицаКлиентовToolStripMenuItem";
            this.таблицаКлиентовToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.таблицаКлиентовToolStripMenuItem.Text = "Таблица заказчиков";
            this.таблицаКлиентовToolStripMenuItem.Click += new System.EventHandler(this.таблицаКлиентовToolStripMenuItem_Click);
            // 
            // таблицаЗаказовToolStripMenuItem
            // 
            this.таблицаЗаказовToolStripMenuItem.Name = "таблицаЗаказовToolStripMenuItem";
            this.таблицаЗаказовToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.таблицаЗаказовToolStripMenuItem.Text = "Таблица заказов";
            this.таблицаЗаказовToolStripMenuItem.Click += new System.EventHandler(this.таблицаЗаказовToolStripMenuItem_Click);
            // 
            // таблицаПродажToolStripMenuItem
            // 
            this.таблицаПродажToolStripMenuItem.Name = "таблицаПродажToolStripMenuItem";
            this.таблицаПродажToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.таблицаПродажToolStripMenuItem.Text = "Таблица продаж";
            this.таблицаПродажToolStripMenuItem.Click += new System.EventHandler(this.таблицаПродажToolStripMenuItem_Click);
            // 
            // таблицаЦенToolStripMenuItem
            // 
            this.таблицаЦенToolStripMenuItem.Name = "таблицаЦенToolStripMenuItem";
            this.таблицаЦенToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.таблицаЦенToolStripMenuItem.Text = "Таблица цен";
            this.таблицаЦенToolStripMenuItem.Click += new System.EventHandler(this.таблицаЦенToolStripMenuItem_Click);
            // 
            // DeleteTable
            // 
            this.DeleteTable.BackColor = System.Drawing.Color.Lavender;
            this.DeleteTable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteTable.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DeleteTable.Location = new System.Drawing.Point(206, 400);
            this.DeleteTable.Name = "DeleteTable";
            this.DeleteTable.Size = new System.Drawing.Size(170, 40);
            this.DeleteTable.TabIndex = 1;
            this.DeleteTable.Text = "УДАЛИТЬ ТАБЛИЦУ";
            this.DeleteTable.UseVisualStyleBackColor = false;
            this.DeleteTable.Click += new System.EventHandler(this.DeleteTable_Click);
            this.DeleteTable.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DeleteTable_MouseDown);
            this.DeleteTable.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DeleteTable_MouseMove);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem программуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem формуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьДанныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показатьДанныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem таблицаСотрудниковToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem таблицаКлиентовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem таблицаЗаказовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem таблицаПродажToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem таблицаЦенToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вТаблицеСотрудникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вТаблицеЗаказчиковToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вТаблицеЗаказовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вТаблицеПродажToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вТаблицеЦенToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button DeleteTable;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox DarkThemeBox1;
        private System.Windows.Forms.Label LabelDeleteTable;
    }
}