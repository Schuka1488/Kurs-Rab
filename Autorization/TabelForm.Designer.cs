
namespace Autorization
{
    partial class TabelForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.chromiumWebBrowser1 = new CefSharp.WinForms.ChromiumWebBrowser();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonCloseTabel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1097, 587);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(251, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "ОТОБРАЗИТЬ ТАБЕЛЬ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chromiumWebBrowser1
            // 
            this.chromiumWebBrowser1.ActivateBrowserOnCreation = false;
            this.chromiumWebBrowser1.Location = new System.Drawing.Point(13, 13);
            this.chromiumWebBrowser1.Name = "chromiumWebBrowser1";
            this.chromiumWebBrowser1.Size = new System.Drawing.Size(1335, 550);
            this.chromiumWebBrowser1.TabIndex = 1;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefresh.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRefresh.Location = new System.Drawing.Point(1097, 587);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(251, 34);
            this.buttonRefresh.TabIndex = 2;
            this.buttonRefresh.Text = "ОБНОВИТЬ ТАБЕЛЬ";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Visible = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonCloseTabel
            // 
            this.buttonCloseTabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCloseTabel.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCloseTabel.Location = new System.Drawing.Point(13, 587);
            this.buttonCloseTabel.Name = "buttonCloseTabel";
            this.buttonCloseTabel.Size = new System.Drawing.Size(251, 34);
            this.buttonCloseTabel.TabIndex = 3;
            this.buttonCloseTabel.Text = "ЗАКРЫТЬ ТАБЕЛЬ";
            this.buttonCloseTabel.UseVisualStyleBackColor = true;
            this.buttonCloseTabel.Click += new System.EventHandler(this.buttonCloseTabel_Click);
            // 
            // TabelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1360, 633);
            this.Controls.Add(this.buttonCloseTabel);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.chromiumWebBrowser1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TabelForm";
            this.Text = "TabelForm";
            this.Load += new System.EventHandler(this.TabelForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TabelForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TabelForm_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser1;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonCloseTabel;
    }
}