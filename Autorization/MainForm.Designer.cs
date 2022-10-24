
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
            this.LoginTransferLabel = new System.Windows.Forms.Label();
            this.ZdravstvoiteLabel = new System.Windows.Forms.Label();
            this.WhiteThemeButton = new System.Windows.Forms.Button();
            this.DarkThemeButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.MainMenuLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.программуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.формуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицаСотрудниковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицаКлиентовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицаЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицаПродажToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицаЦенToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.panel1.Controls.Add(this.LoginTransferLabel);
            this.panel1.Controls.Add(this.ZdravstvoiteLabel);
            this.panel1.Controls.Add(this.WhiteThemeButton);
            this.panel1.Controls.Add(this.DarkThemeButton);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(635, 450);
            this.panel1.TabIndex = 1;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // LoginTransferLabel
            // 
            this.LoginTransferLabel.AutoSize = true;
            this.LoginTransferLabel.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginTransferLabel.Location = new System.Drawing.Point(107, 419);
            this.LoginTransferLabel.Name = "LoginTransferLabel";
            this.LoginTransferLabel.Size = new System.Drawing.Size(46, 16);
            this.LoginTransferLabel.TabIndex = 12;
            this.LoginTransferLabel.Text = "label2";
            // 
            // ZdravstvoiteLabel
            // 
            this.ZdravstvoiteLabel.AutoSize = true;
            this.ZdravstvoiteLabel.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZdravstvoiteLabel.Location = new System.Drawing.Point(21, 419);
            this.ZdravstvoiteLabel.Name = "ZdravstvoiteLabel";
            this.ZdravstvoiteLabel.Size = new System.Drawing.Size(90, 16);
            this.ZdravstvoiteLabel.TabIndex = 11;
            this.ZdravstvoiteLabel.Text = "Здравствуйте";
            // 
            // WhiteThemeButton
            // 
            this.WhiteThemeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WhiteThemeButton.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WhiteThemeButton.Location = new System.Drawing.Point(503, 388);
            this.WhiteThemeButton.Name = "WhiteThemeButton";
            this.WhiteThemeButton.Size = new System.Drawing.Size(119, 23);
            this.WhiteThemeButton.TabIndex = 10;
            this.WhiteThemeButton.Text = "СВЕТЛАЯ ТЕМА";
            this.WhiteThemeButton.UseVisualStyleBackColor = true;
            // 
            // DarkThemeButton
            // 
            this.DarkThemeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DarkThemeButton.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DarkThemeButton.Location = new System.Drawing.Point(503, 416);
            this.DarkThemeButton.Name = "DarkThemeButton";
            this.DarkThemeButton.Size = new System.Drawing.Size(119, 23);
            this.DarkThemeButton.TabIndex = 9;
            this.DarkThemeButton.Text = "ТЕМНАЯ ТЕМА";
            this.DarkThemeButton.UseVisualStyleBackColor = true;
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel2.Controls.Add(this.MainMenuLabel);
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(635, 100);
            this.panel2.TabIndex = 0;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            // 
            // MainMenuLabel
            // 
            this.MainMenuLabel.AutoSize = true;
            this.MainMenuLabel.Font = new System.Drawing.Font("Mongolian Baiti", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.MainMenuLabel.Location = new System.Drawing.Point(124, 37);
            this.MainMenuLabel.Name = "MainMenuLabel";
            this.MainMenuLabel.Size = new System.Drawing.Size(378, 50);
            this.MainMenuLabel.TabIndex = 3;
            this.MainMenuLabel.Text = "ГЛАВНОЕ МЕНЮ";
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
            this.программуToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.программуToolStripMenuItem.Text = "Из программы";
            this.программуToolStripMenuItem.Click += new System.EventHandler(this.программуToolStripMenuItem_Click);
            // 
            // формуToolStripMenuItem
            // 
            this.формуToolStripMenuItem.Name = "формуToolStripMenuItem";
            this.формуToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.формуToolStripMenuItem.Text = "Из аккаунта";
            this.формуToolStripMenuItem.Click += new System.EventHandler(this.формуToolStripMenuItem_Click);
            // 
            // изменитьДанныеToolStripMenuItem
            // 
            this.изменитьДанныеToolStripMenuItem.Name = "изменитьДанныеToolStripMenuItem";
            this.изменитьДанныеToolStripMenuItem.Size = new System.Drawing.Size(117, 20);
            this.изменитьДанныеToolStripMenuItem.Text = "Изменить данные";
            this.изменитьДанныеToolStripMenuItem.Click += new System.EventHandler(this.изменитьДанныеToolStripMenuItem_Click);
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label MainMenuLabel;
        private System.Windows.Forms.Button WhiteThemeButton;
        private System.Windows.Forms.Button DarkThemeButton;
        private System.Windows.Forms.Label ZdravstvoiteLabel;
        private System.Windows.Forms.Label LoginTransferLabel;
    }
}