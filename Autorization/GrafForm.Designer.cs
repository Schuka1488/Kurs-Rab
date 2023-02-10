
namespace Autorization
{
    partial class GrafForm
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
            this.BuildGrafButton = new System.Windows.Forms.Button();
            this.CloseGrafFormbutton = new System.Windows.Forms.Button();
            this.formsPlot1 = new ScottPlot.FormsPlot();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BuildGrafButton
            // 
            this.BuildGrafButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BuildGrafButton.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuildGrafButton.Location = new System.Drawing.Point(1045, 664);
            this.BuildGrafButton.Name = "BuildGrafButton";
            this.BuildGrafButton.Size = new System.Drawing.Size(392, 58);
            this.BuildGrafButton.TabIndex = 1;
            this.BuildGrafButton.Text = "ПОСТРОИТЬ ГРАФИК ВЫРУЧКИ";
            this.BuildGrafButton.UseVisualStyleBackColor = true;
            this.BuildGrafButton.Click += new System.EventHandler(this.BuildGrafButton_Click);
            // 
            // CloseGrafFormbutton
            // 
            this.CloseGrafFormbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseGrafFormbutton.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseGrafFormbutton.Location = new System.Drawing.Point(12, 664);
            this.CloseGrafFormbutton.Name = "CloseGrafFormbutton";
            this.CloseGrafFormbutton.Size = new System.Drawing.Size(392, 58);
            this.CloseGrafFormbutton.TabIndex = 2;
            this.CloseGrafFormbutton.Text = "ЗАКРЫТЬ ПОСТРОИТЕЛЬ ГРАФИКОВ";
            this.CloseGrafFormbutton.UseVisualStyleBackColor = true;
            this.CloseGrafFormbutton.Click += new System.EventHandler(this.CloseGrafFormbutton_Click);
            // 
            // formsPlot1
            // 
            this.formsPlot1.Location = new System.Drawing.Point(12, 12);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(1425, 632);
            this.formsPlot1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(534, 664);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(392, 58);
            this.button1.TabIndex = 4;
            this.button1.Text = "ПЕЧАТЬ ГРАФИКА ВЫРУЧКИ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GrafForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1449, 734);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.formsPlot1);
            this.Controls.Add(this.CloseGrafFormbutton);
            this.Controls.Add(this.BuildGrafButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GrafForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GrafForm";
            this.Load += new System.EventHandler(this.GrafForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GrafForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GrafForm_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BuildGrafButton;
        private System.Windows.Forms.Button CloseGrafFormbutton;
        private ScottPlot.FormsPlot formsPlot1;
        private System.Windows.Forms.Button button1;
    }
}