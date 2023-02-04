
namespace Autorization
{
    partial class ErrorForm
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
            this.chromiumWebBrowser1 = new CefSharp.WinForms.ChromiumWebBrowser();
            this.Desc = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ExitButtonErrorForm = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chromiumWebBrowser1
            // 
            this.chromiumWebBrowser1.ActivateBrowserOnCreation = false;
            this.chromiumWebBrowser1.Location = new System.Drawing.Point(22, 21);
            this.chromiumWebBrowser1.Name = "chromiumWebBrowser1";
            this.chromiumWebBrowser1.Size = new System.Drawing.Size(919, 505);
            this.chromiumWebBrowser1.TabIndex = 0;
            this.chromiumWebBrowser1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chromiumWebBrowser1_MouseDown);
            this.chromiumWebBrowser1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chromiumWebBrowser1_MouseMove);
            // 
            // Desc
            // 
            this.Desc.AutoSize = true;
            this.Desc.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Desc.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Desc.Location = new System.Drawing.Point(22, 549);
            this.Desc.Name = "Desc";
            this.Desc.Size = new System.Drawing.Size(54, 22);
            this.Desc.TabIndex = 1;
            this.Desc.Text = "label1";
            this.Desc.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Desc_MouseDown);
            this.Desc.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Desc_MouseMove);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Controls.Add(this.ExitButtonErrorForm);
            this.panel1.Controls.Add(this.Desc);
            this.panel1.Controls.Add(this.chromiumWebBrowser1);
            this.panel1.Location = new System.Drawing.Point(-10, -9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(963, 595);
            this.panel1.TabIndex = 2;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // ExitButtonErrorForm
            // 
            this.ExitButtonErrorForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButtonErrorForm.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButtonErrorForm.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ExitButtonErrorForm.Location = new System.Drawing.Point(818, 539);
            this.ExitButtonErrorForm.Name = "ExitButtonErrorForm";
            this.ExitButtonErrorForm.Size = new System.Drawing.Size(123, 38);
            this.ExitButtonErrorForm.TabIndex = 2;
            this.ExitButtonErrorForm.Text = "ЗАКРЫТЬ";
            this.ExitButtonErrorForm.UseVisualStyleBackColor = true;
            this.ExitButtonErrorForm.Click += new System.EventHandler(this.ExitButtonErrorForm_Click);
            this.ExitButtonErrorForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ExitButtonErrorForm_MouseDown);
            this.ExitButtonErrorForm.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ExitButtonErrorForm_MouseMove);
            // 
            // ErrorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 579);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ErrorForm";
            this.Text = "ErrorForm";
            this.Load += new System.EventHandler(this.ErrorForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ErrorForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ErrorForm_MouseMove);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser1;
        private System.Windows.Forms.Label Desc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ExitButtonErrorForm;
    }
}