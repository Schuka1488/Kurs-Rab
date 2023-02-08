
namespace Autorization
{
    partial class NoWorkingInfoForm
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
            this.ExitButtonErrorForm = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ExitButtonErrorForm
            // 
            this.ExitButtonErrorForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButtonErrorForm.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButtonErrorForm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ExitButtonErrorForm.Location = new System.Drawing.Point(537, 400);
            this.ExitButtonErrorForm.Name = "ExitButtonErrorForm";
            this.ExitButtonErrorForm.Size = new System.Drawing.Size(251, 38);
            this.ExitButtonErrorForm.TabIndex = 4;
            this.ExitButtonErrorForm.Text = "ЗАКРЫТЬ ИСТОРИЮ";
            this.ExitButtonErrorForm.UseVisualStyleBackColor = true;
            this.ExitButtonErrorForm.Click += new System.EventHandler(this.ExitButtonErrorForm_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(12, 400);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(251, 38);
            this.button1.TabIndex = 5;
            this.button1.Text = "ЗАКРЫТЬ ИСТОРИЮ";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // NoWorkingInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ExitButtonErrorForm);
            this.Name = "NoWorkingInfoForm";
            this.Text = "NoWorkingInfoForm";
            this.Load += new System.EventHandler(this.NoWorkingInfoForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NoWorkingInfoForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NoWorkingInfoForm_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ExitButtonErrorForm;
        private System.Windows.Forms.Button button1;
    }
}