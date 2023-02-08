
namespace Autorization
{
    partial class ChangeTabelForm
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
            this.Markcombobox = new System.Windows.Forms.ComboBox();
            this.Surnamelabel = new System.Windows.Forms.Label();
            this.Datalable = new System.Windows.Forms.Label();
            this.buttonSaveTabel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCloseChangeTabelForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Markcombobox
            // 
            this.Markcombobox.FormattingEnabled = true;
            this.Markcombobox.Items.AddRange(new object[] {
            "Н",
            "Б",
            "О",
            "УВ",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.Markcombobox.Location = new System.Drawing.Point(18, 166);
            this.Markcombobox.Name = "Markcombobox";
            this.Markcombobox.Size = new System.Drawing.Size(121, 21);
            this.Markcombobox.TabIndex = 0;
            // 
            // Surnamelabel
            // 
            this.Surnamelabel.AutoSize = true;
            this.Surnamelabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Surnamelabel.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Surnamelabel.Location = new System.Drawing.Point(12, 9);
            this.Surnamelabel.Name = "Surnamelabel";
            this.Surnamelabel.Size = new System.Drawing.Size(48, 22);
            this.Surnamelabel.TabIndex = 1;
            this.Surnamelabel.Text = "ФИО";
            // 
            // Datalable
            // 
            this.Datalable.AutoSize = true;
            this.Datalable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Datalable.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Datalable.Location = new System.Drawing.Point(14, 44);
            this.Datalable.Name = "Datalable";
            this.Datalable.Size = new System.Drawing.Size(49, 22);
            this.Datalable.TabIndex = 2;
            this.Datalable.Text = "Дата";
            // 
            // buttonSaveTabel
            // 
            this.buttonSaveTabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveTabel.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveTabel.Location = new System.Drawing.Point(223, 154);
            this.buttonSaveTabel.Name = "buttonSaveTabel";
            this.buttonSaveTabel.Size = new System.Drawing.Size(135, 40);
            this.buttonSaveTabel.TabIndex = 3;
            this.buttonSaveTabel.Text = "СОХРАНИТЬ";
            this.buttonSaveTabel.UseVisualStyleBackColor = true;
            this.buttonSaveTabel.Click += new System.EventHandler(this.buttonSaveTabel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Выбор:";
            // 
            // buttonCloseChangeTabelForm
            // 
            this.buttonCloseChangeTabelForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCloseChangeTabelForm.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCloseChangeTabelForm.Location = new System.Drawing.Point(223, 108);
            this.buttonCloseChangeTabelForm.Name = "buttonCloseChangeTabelForm";
            this.buttonCloseChangeTabelForm.Size = new System.Drawing.Size(135, 40);
            this.buttonCloseChangeTabelForm.TabIndex = 5;
            this.buttonCloseChangeTabelForm.Text = "ЗАКРЫТЬ";
            this.buttonCloseChangeTabelForm.UseVisualStyleBackColor = true;
            this.buttonCloseChangeTabelForm.Click += new System.EventHandler(this.buttonCloseChangeTabelForm_Click);
            // 
            // ChangeTabelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(370, 206);
            this.Controls.Add(this.buttonCloseChangeTabelForm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSaveTabel);
            this.Controls.Add(this.Datalable);
            this.Controls.Add(this.Surnamelabel);
            this.Controls.Add(this.Markcombobox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChangeTabelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangeTabelForm";
            this.Load += new System.EventHandler(this.ChangeTabelForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChangeTabelForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ChangeTabelForm_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Markcombobox;
        private System.Windows.Forms.Label Surnamelabel;
        private System.Windows.Forms.Label Datalable;
        private System.Windows.Forms.Button buttonSaveTabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCloseChangeTabelForm;
    }
}