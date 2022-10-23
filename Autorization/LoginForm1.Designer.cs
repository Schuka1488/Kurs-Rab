
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
            this.DarkThemeBox1 = new System.Windows.Forms.CheckBox();
            this.buttonLoginPass = new System.Windows.Forms.Button();
            this.passwordName = new System.Windows.Forms.TextBox();
            this.loginName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.animateComponent1 = new Autorization.AnimateComponent(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.DarkThemeBox1);
            this.panel1.Controls.Add(this.buttonLoginPass);
            this.panel1.Controls.Add(this.passwordName);
            this.panel1.Controls.Add(this.loginName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(372, 473);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // DarkThemeBox1
            // 
            this.DarkThemeBox1.AutoSize = true;
            this.DarkThemeBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DarkThemeBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DarkThemeBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DarkThemeBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DarkThemeBox1.Location = new System.Drawing.Point(219, 437);
            this.DarkThemeBox1.Name = "DarkThemeBox1";
            this.DarkThemeBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DarkThemeBox1.Size = new System.Drawing.Size(142, 24);
            this.DarkThemeBox1.TabIndex = 6;
            this.DarkThemeBox1.Text = "ТЕМНАЯ ТЕМА";
            this.DarkThemeBox1.UseVisualStyleBackColor = true;
            // 
            // buttonLoginPass
            // 
            this.buttonLoginPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLoginPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoginPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLoginPass.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonLoginPass.Location = new System.Drawing.Point(12, 370);
            this.buttonLoginPass.Name = "buttonLoginPass";
            this.buttonLoginPass.Size = new System.Drawing.Size(348, 53);
            this.buttonLoginPass.TabIndex = 5;
            this.buttonLoginPass.Text = "ВОЙТИ";
            this.buttonLoginPass.UseVisualStyleBackColor = true;
            this.buttonLoginPass.Click += new System.EventHandler(this.buttonLoginPass_Click);
            // 
            // passwordName
            // 
            this.passwordName.Font = new System.Drawing.Font("Arial Narrow", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordName.Location = new System.Drawing.Point(17, 261);
            this.passwordName.Multiline = true;
            this.passwordName.Name = "passwordName";
            this.passwordName.PasswordChar = '*';
            this.passwordName.Size = new System.Drawing.Size(343, 46);
            this.passwordName.TabIndex = 4;
            this.passwordName.TextChanged += new System.EventHandler(this.passwordName_TextChanged);
            // 
            // loginName
            // 
            this.loginName.Font = new System.Drawing.Font("Arial Narrow", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginName.Location = new System.Drawing.Point(17, 165);
            this.loginName.Multiline = true;
            this.loginName.Name = "loginName";
            this.loginName.Size = new System.Drawing.Size(343, 46);
            this.loginName.TabIndex = 3;
            this.loginName.TextChanged += new System.EventHandler(this.loginName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(12, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "ПАРОЛЬ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(12, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "ЛОГИН";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(372, 100);
            this.panel2.TabIndex = 0;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(337, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 31);
            this.label4.TabIndex = 1;
            this.label4.Text = "X";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Old English Text MT", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(42, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "АВТОРИЗАЦИЯ";
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
            this.ClientSize = new System.Drawing.Size(372, 473);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm1";
            this.Text = "LoginForm1";
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
        private System.Windows.Forms.CheckBox DarkThemeBox1;
        private AnimateComponent animateComponent1;
    }
}