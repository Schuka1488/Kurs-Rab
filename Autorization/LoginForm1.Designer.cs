
namespace Autorization
{
    partial class LoginForm1
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
            this.labelTheme = new System.Windows.Forms.Label();
            this.WhiteThemeButton = new System.Windows.Forms.Button();
            this.DarkThemeButton = new System.Windows.Forms.Button();
            this.buttonLoginPass = new System.Windows.Forms.Button();
            this.passwordName = new System.Windows.Forms.TextBox();
            this.loginName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.animateComponent1 = new Autorization.AnimateComponent(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.labelTheme);
            this.panel1.Controls.Add(this.WhiteThemeButton);
            this.panel1.Controls.Add(this.DarkThemeButton);
            this.panel1.Controls.Add(this.buttonLoginPass);
            this.panel1.Controls.Add(this.passwordName);
            this.panel1.Controls.Add(this.loginName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(416, 468);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // labelTheme
            // 
            this.labelTheme.AutoSize = true;
            this.labelTheme.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTheme.Location = new System.Drawing.Point(124, 427);
            this.labelTheme.Name = "labelTheme";
            this.labelTheme.Size = new System.Drawing.Size(144, 21);
            this.labelTheme.TabIndex = 13;
            this.labelTheme.Text = "Светлая тема вкл.";
            // 
            // WhiteThemeButton
            // 
            this.WhiteThemeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WhiteThemeButton.Font = new System.Drawing.Font("Mongolian Baiti", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WhiteThemeButton.Location = new System.Drawing.Point(274, 398);
            this.WhiteThemeButton.Name = "WhiteThemeButton";
            this.WhiteThemeButton.Size = new System.Drawing.Size(130, 23);
            this.WhiteThemeButton.TabIndex = 12;
            this.WhiteThemeButton.Text = "СВЕТЛАЯ ТЕМА";
            this.WhiteThemeButton.UseVisualStyleBackColor = true;
            this.WhiteThemeButton.Click += new System.EventHandler(this.WhiteThemeButton_Click);
            // 
            // DarkThemeButton
            // 
            this.DarkThemeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DarkThemeButton.Font = new System.Drawing.Font("Mongolian Baiti", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DarkThemeButton.Location = new System.Drawing.Point(274, 427);
            this.DarkThemeButton.Name = "DarkThemeButton";
            this.DarkThemeButton.Size = new System.Drawing.Size(130, 23);
            this.DarkThemeButton.TabIndex = 11;
            this.DarkThemeButton.Text = "ТЕМНАЯ ТЕМА";
            this.DarkThemeButton.UseVisualStyleBackColor = true;
            this.DarkThemeButton.Click += new System.EventHandler(this.DarkThemeButton_Click);
            // 
            // buttonLoginPass
            // 
            this.buttonLoginPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLoginPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoginPass.Font = new System.Drawing.Font("Mongolian Baiti", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoginPass.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonLoginPass.Location = new System.Drawing.Point(12, 333);
            this.buttonLoginPass.Name = "buttonLoginPass";
            this.buttonLoginPass.Size = new System.Drawing.Size(387, 48);
            this.buttonLoginPass.TabIndex = 5;
            this.buttonLoginPass.Text = "ВОЙТИ";
            this.buttonLoginPass.UseVisualStyleBackColor = true;
            this.buttonLoginPass.Click += new System.EventHandler(this.buttonLoginPass_Click);
            // 
            // passwordName
            // 
            this.passwordName.Font = new System.Drawing.Font("Arial Narrow", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordName.Location = new System.Drawing.Point(12, 243);
            this.passwordName.Multiline = true;
            this.passwordName.Name = "passwordName";
            this.passwordName.PasswordChar = '*';
            this.passwordName.Size = new System.Drawing.Size(387, 46);
            this.passwordName.TabIndex = 4;
            // 
            // loginName
            // 
            this.loginName.BackColor = System.Drawing.SystemColors.Window;
            this.loginName.Font = new System.Drawing.Font("Arial Narrow", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginName.Location = new System.Drawing.Point(12, 146);
            this.loginName.Multiline = true;
            this.loginName.Name = "loginName";
            this.loginName.Size = new System.Drawing.Size(387, 46);
            this.loginName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(12, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "ПАРОЛЬ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(12, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "ЛОГИН";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel2.Controls.Add(this.linkLabel1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(416, 100);
            this.panel2.TabIndex = 0;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(17, 26);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(156, 13);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://www.интэкс-сервис.рф";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(372, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 31);
            this.label4.TabIndex = 1;
            this.label4.Text = "X";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(37, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(348, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "ИНТЭКС-СЕРВИС";
            // 
            // animateComponent1
            // 
            this.animateComponent1.AccriveEffect = Autorization.FormAnimatedEffects.РАСКРЫТИЕ_СКРЫТИЕ;
            this.animateComponent1.CloseEffect = Autorization.FormAnimatedEffects.ПОЯВЛЕНИЕ_ЗАТУХАНИЕ;
            this.animateComponent1.SourceForm = this;
            // 
            // LoginForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 468);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm1";
            this.Text = "LoginForm1";
            this.Load += new System.EventHandler(this.LoginForm1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonLoginPass;
        private System.Windows.Forms.TextBox passwordName;
        private System.Windows.Forms.TextBox loginName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private AnimateComponent animateComponent1;
        private System.Windows.Forms.Button WhiteThemeButton;
        private System.Windows.Forms.Button DarkThemeButton;
        private System.Windows.Forms.Label labelTheme;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}