
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
            this.SuspendLayout();
            // 
            // Markcombobox
            // 
            this.Markcombobox.FormattingEnabled = true;
            this.Markcombobox.Items.AddRange(new object[] {
            "Н",
            "Б",
            "В",
            "О",
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
            this.Markcombobox.Location = new System.Drawing.Point(57, 96);
            this.Markcombobox.Name = "Markcombobox";
            this.Markcombobox.Size = new System.Drawing.Size(121, 21);
            this.Markcombobox.TabIndex = 0;
            // 
            // Surnamelabel
            // 
            this.Surnamelabel.AutoSize = true;
            this.Surnamelabel.Location = new System.Drawing.Point(307, 245);
            this.Surnamelabel.Name = "Surnamelabel";
            this.Surnamelabel.Size = new System.Drawing.Size(34, 13);
            this.Surnamelabel.TabIndex = 1;
            this.Surnamelabel.Text = "ФИО";
            // 
            // Datalable
            // 
            this.Datalable.AutoSize = true;
            this.Datalable.Location = new System.Drawing.Point(307, 275);
            this.Datalable.Name = "Datalable";
            this.Datalable.Size = new System.Drawing.Size(33, 13);
            this.Datalable.TabIndex = 2;
            this.Datalable.Text = "Дата";
            // 
            // buttonSaveTabel
            // 
            this.buttonSaveTabel.Location = new System.Drawing.Point(618, 265);
            this.buttonSaveTabel.Name = "buttonSaveTabel";
            this.buttonSaveTabel.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveTabel.TabIndex = 3;
            this.buttonSaveTabel.Text = "Сохранить";
            this.buttonSaveTabel.UseVisualStyleBackColor = true;
            this.buttonSaveTabel.Click += new System.EventHandler(this.buttonSaveTabel_Click);
            // 
            // ChangeTabelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonSaveTabel);
            this.Controls.Add(this.Datalable);
            this.Controls.Add(this.Surnamelabel);
            this.Controls.Add(this.Markcombobox);
            this.Name = "ChangeTabelForm";
            this.Text = "ChangeTabelForm";
            this.Load += new System.EventHandler(this.ChangeTabelForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Markcombobox;
        private System.Windows.Forms.Label Surnamelabel;
        private System.Windows.Forms.Label Datalable;
        private System.Windows.Forms.Button buttonSaveTabel;
    }
}