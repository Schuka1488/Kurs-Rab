
namespace Autorization
{
    partial class ChangeDataForm
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изПрограммыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изАккаунтаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вГлавноеМенюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewTransformData2 = new System.Windows.Forms.DataGridView();
            this.TransformDataLabel = new System.Windows.Forms.Label();
            this.WhiteThemeButton = new System.Windows.Forms.Button();
            this.DarkThemeButton = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransformData2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Lavender;
            this.panel4.Controls.Add(this.WhiteThemeButton);
            this.panel4.Controls.Add(this.DarkThemeButton);
            this.panel4.Controls.Add(this.dataGridViewTransformData2);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1102, 535);
            this.panel4.TabIndex = 2;
            this.panel4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel4_MouseDown);
            this.panel4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel4_MouseMove);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel5.Controls.Add(this.TransformDataLabel);
            this.panel5.Controls.Add(this.menuStrip1);
            this.panel5.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1102, 100);
            this.panel5.TabIndex = 0;
            this.panel5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel5_MouseDown);
            this.panel5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel5_MouseMove);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1102, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изПрограммыToolStripMenuItem,
            this.изАккаунтаToolStripMenuItem,
            this.вГлавноеМенюToolStripMenuItem});
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.выходToolStripMenuItem.Text = "Выход";
            // 
            // изПрограммыToolStripMenuItem
            // 
            this.изПрограммыToolStripMenuItem.Name = "изПрограммыToolStripMenuItem";
            this.изПрограммыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.изПрограммыToolStripMenuItem.Text = "Из программы";
            this.изПрограммыToolStripMenuItem.Click += new System.EventHandler(this.изПрограммыToolStripMenuItem_Click);
            // 
            // изАккаунтаToolStripMenuItem
            // 
            this.изАккаунтаToolStripMenuItem.Name = "изАккаунтаToolStripMenuItem";
            this.изАккаунтаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.изАккаунтаToolStripMenuItem.Text = "Из аккаунта";
            this.изАккаунтаToolStripMenuItem.Click += new System.EventHandler(this.изАккаунтаToolStripMenuItem_Click);
            // 
            // вГлавноеМенюToolStripMenuItem
            // 
            this.вГлавноеМенюToolStripMenuItem.Name = "вГлавноеМенюToolStripMenuItem";
            this.вГлавноеМенюToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.вГлавноеМенюToolStripMenuItem.Text = "В главное меню";
            this.вГлавноеМенюToolStripMenuItem.Click += new System.EventHandler(this.вГлавноеМенюToolStripMenuItem_Click);
            // 
            // dataGridViewTransformData2
            // 
            this.dataGridViewTransformData2.BackgroundColor = System.Drawing.Color.Lavender;
            this.dataGridViewTransformData2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewTransformData2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTransformData2.Location = new System.Drawing.Point(12, 106);
            this.dataGridViewTransformData2.Name = "dataGridViewTransformData2";
            this.dataGridViewTransformData2.Size = new System.Drawing.Size(866, 310);
            this.dataGridViewTransformData2.TabIndex = 6;
            // 
            // TransformDataLabel
            // 
            this.TransformDataLabel.AutoSize = true;
            this.TransformDataLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TransformDataLabel.Font = new System.Drawing.Font("Mongolian Baiti", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransformDataLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.TransformDataLabel.Location = new System.Drawing.Point(218, 38);
            this.TransformDataLabel.Name = "TransformDataLabel";
            this.TransformDataLabel.Size = new System.Drawing.Size(679, 52);
            this.TransformDataLabel.TabIndex = 4;
            this.TransformDataLabel.Text = "ФОРМА ИЗМЕНЕНИЯ ДАННЫХ";
            // 
            // WhiteThemeButton
            // 
            this.WhiteThemeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.WhiteThemeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WhiteThemeButton.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WhiteThemeButton.Location = new System.Drawing.Point(971, 475);
            this.WhiteThemeButton.Name = "WhiteThemeButton";
            this.WhiteThemeButton.Size = new System.Drawing.Size(119, 23);
            this.WhiteThemeButton.TabIndex = 12;
            this.WhiteThemeButton.Text = "СВЕТЛАЯ ТЕМА";
            this.WhiteThemeButton.UseVisualStyleBackColor = true;
            // 
            // DarkThemeButton
            // 
            this.DarkThemeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DarkThemeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DarkThemeButton.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DarkThemeButton.Location = new System.Drawing.Point(971, 503);
            this.DarkThemeButton.Name = "DarkThemeButton";
            this.DarkThemeButton.Size = new System.Drawing.Size(119, 23);
            this.DarkThemeButton.TabIndex = 11;
            this.DarkThemeButton.Text = "ТЕМНАЯ ТЕМА";
            this.DarkThemeButton.UseVisualStyleBackColor = true;
            // 
            // ChangeDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 535);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ChangeDataForm";
            this.Text = "ChangeDataForm";
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransformData2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изПрограммыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изАккаунтаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вГлавноеМенюToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewTransformData2;
        private System.Windows.Forms.Label TransformDataLabel;
        private System.Windows.Forms.Button WhiteThemeButton;
        private System.Windows.Forms.Button DarkThemeButton;
    }
}