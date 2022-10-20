
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
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.DeleteTable);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(12, 373);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(188, 65);
            this.textBox1.TabIndex = 3;
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 100);
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
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.программуToolStripMenuItem,
            this.формуToolStripMenuItem});
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.закрытьToolStripMenuItem.Text = "закрыть ";
            // 
            // программуToolStripMenuItem
            // 
            this.программуToolStripMenuItem.Name = "программуToolStripMenuItem";
            this.программуToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.программуToolStripMenuItem.Text = "программу";
            this.программуToolStripMenuItem.Click += new System.EventHandler(this.программуToolStripMenuItem_Click);
            // 
            // формуToolStripMenuItem
            // 
            this.формуToolStripMenuItem.Name = "формуToolStripMenuItem";
            this.формуToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.формуToolStripMenuItem.Text = "форму";
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
            this.изменитьДанныеToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.изменитьДанныеToolStripMenuItem.Text = "изменить данные";
            // 
            // вТаблицеСотрудникиToolStripMenuItem
            // 
            this.вТаблицеСотрудникиToolStripMenuItem.Name = "вТаблицеСотрудникиToolStripMenuItem";
            this.вТаблицеСотрудникиToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.вТаблицеСотрудникиToolStripMenuItem.Text = "в таблице сотрудники";
            // 
            // вТаблицеЗаказчиковToolStripMenuItem
            // 
            this.вТаблицеЗаказчиковToolStripMenuItem.Name = "вТаблицеЗаказчиковToolStripMenuItem";
            this.вТаблицеЗаказчиковToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.вТаблицеЗаказчиковToolStripMenuItem.Text = "в таблице заказчиков";
            // 
            // вТаблицеЗаказовToolStripMenuItem
            // 
            this.вТаблицеЗаказовToolStripMenuItem.Name = "вТаблицеЗаказовToolStripMenuItem";
            this.вТаблицеЗаказовToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.вТаблицеЗаказовToolStripMenuItem.Text = "в таблице заказов";
            // 
            // вТаблицеПродажToolStripMenuItem
            // 
            this.вТаблицеПродажToolStripMenuItem.Name = "вТаблицеПродажToolStripMenuItem";
            this.вТаблицеПродажToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.вТаблицеПродажToolStripMenuItem.Text = "в таблице продаж";
            // 
            // вТаблицеЦенToolStripMenuItem
            // 
            this.вТаблицеЦенToolStripMenuItem.Name = "вТаблицеЦенToolStripMenuItem";
            this.вТаблицеЦенToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.вТаблицеЦенToolStripMenuItem.Text = "в таблице цен";
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
            this.показатьДанныеToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.показатьДанныеToolStripMenuItem.Text = "показать данные";
            // 
            // таблицаСотрудниковToolStripMenuItem
            // 
            this.таблицаСотрудниковToolStripMenuItem.Name = "таблицаСотрудниковToolStripMenuItem";
            this.таблицаСотрудниковToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.таблицаСотрудниковToolStripMenuItem.Text = "таблица сотрудников";
            // 
            // таблицаКлиентовToolStripMenuItem
            // 
            this.таблицаКлиентовToolStripMenuItem.Name = "таблицаКлиентовToolStripMenuItem";
            this.таблицаКлиентовToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.таблицаКлиентовToolStripMenuItem.Text = "таблица заказчиков";
            // 
            // таблицаЗаказовToolStripMenuItem
            // 
            this.таблицаЗаказовToolStripMenuItem.Name = "таблицаЗаказовToolStripMenuItem";
            this.таблицаЗаказовToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.таблицаЗаказовToolStripMenuItem.Text = "таблица заказов";
            // 
            // таблицаПродажToolStripMenuItem
            // 
            this.таблицаПродажToolStripMenuItem.Name = "таблицаПродажToolStripMenuItem";
            this.таблицаПродажToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.таблицаПродажToolStripMenuItem.Text = "таблица продаж";
            // 
            // таблицаЦенToolStripMenuItem
            // 
            this.таблицаЦенToolStripMenuItem.Name = "таблицаЦенToolStripMenuItem";
            this.таблицаЦенToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.таблицаЦенToolStripMenuItem.Text = "таблица цен";
            // 
            // DeleteTable
            // 
            this.DeleteTable.BackColor = System.Drawing.Color.Navy;
            this.DeleteTable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteTable.ForeColor = System.Drawing.SystemColors.Control;
            this.DeleteTable.Location = new System.Drawing.Point(206, 373);
            this.DeleteTable.Name = "DeleteTable";
            this.DeleteTable.Size = new System.Drawing.Size(205, 67);
            this.DeleteTable.TabIndex = 1;
            this.DeleteTable.Text = "УДАЛИТЬ ДАННЫЕ ВНУТРИ ТАБЛИЦЫ";
            this.DeleteTable.UseVisualStyleBackColor = false;
            this.DeleteTable.Click += new System.EventHandler(this.DeleteTable_Click);
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
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
    }
}