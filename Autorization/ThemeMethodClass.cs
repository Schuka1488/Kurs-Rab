using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Autorization
{
    class ThemeMethodClass
    {
        //  static Color Panel1BackColor;

        //static public void EnableDarkTheme()
        // {
        //    Panel1BackColor = SystemColors.WindowFrame;
        // }

        // static public void EnableWhiteTheme()
        // {
        //    Panel1BackColor = Color.Lavender;
        // }

        // так же нужны кнопки удаления для 3 методов, в форме изменений таблиц
        static public void ThemeMethod3(Panel panel4, Panel panel5, DataGridView dataGridViewTransformData2, Button DarkThemeButton, Button WhiteThemeButton, Label labelTheme, Button AddLineButton, Button AddLineButton2, Button AddLineButton3, Button AddLineButton4, Button AddLineButton5, Button AddLineButton6, Label label1, Label label2, Label Column1Label, Label Column2Label, Label Column3Label, Label Column4Label, Label Column5Label, Label Column6Label, Label Column7Label, TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4, TextBox textBox5, TextBox textBox6, TextBox textBox7)
        {
            panel4.BackColor = SystemColors.WindowFrame; // Panel1BackColor вместо цвета и класса цветов
            panel5.BackColor = SystemColors.GrayText;
            dataGridViewTransformData2.BackgroundColor = SystemColors.WindowFrame;
            DarkThemeButton.ForeColor = SystemColors.ControlLightLight;
            WhiteThemeButton.ForeColor = SystemColors.ControlLightLight;
            labelTheme.ForeColor = SystemColors.ControlLightLight;
            AddLineButton.ForeColor = SystemColors.ControlLightLight;
            AddLineButton.BackColor = SystemColors.WindowFrame;
            AddLineButton2.ForeColor = SystemColors.ControlLightLight;
            AddLineButton2.BackColor = SystemColors.WindowFrame;
            AddLineButton3.ForeColor = SystemColors.ControlLightLight;
            AddLineButton3.BackColor = SystemColors.WindowFrame;
            AddLineButton4.ForeColor = SystemColors.ControlLightLight;
            AddLineButton4.BackColor = SystemColors.WindowFrame;
            AddLineButton5.ForeColor = SystemColors.ControlLightLight;
            AddLineButton5.BackColor = SystemColors.WindowFrame;
            AddLineButton6.ForeColor = SystemColors.ControlLightLight;
            AddLineButton6.BackColor = SystemColors.WindowFrame;
            label1.ForeColor = SystemColors.ControlLightLight;
            label2.ForeColor = SystemColors.ControlLightLight;
            Column1Label.ForeColor = SystemColors.ControlLightLight;
            Column2Label.ForeColor = SystemColors.ControlLightLight;
            Column3Label.ForeColor = SystemColors.ControlLightLight;
            Column4Label.ForeColor = SystemColors.ControlLightLight;
            Column5Label.ForeColor = SystemColors.ControlLightLight;
            Column6Label.ForeColor = SystemColors.ControlLightLight;
            Column7Label.ForeColor = SystemColors.ControlLightLight;
            textBox1.BackColor = SystemColors.ScrollBar;
            textBox2.BackColor = SystemColors.ScrollBar;
            textBox3.BackColor = SystemColors.ScrollBar;
            textBox4.BackColor = SystemColors.ScrollBar;
            textBox5.BackColor = SystemColors.ScrollBar;
            textBox6.BackColor = SystemColors.ScrollBar;
            textBox7.BackColor = SystemColors.ScrollBar;
        }
        static public void ThemeMethodLight3(Panel panel4, Panel panel5, DataGridView dataGridViewTransformData2, Button DarkThemeButton, Button WhiteThemeButton, Label labelTheme, Button AddLineButton, Button AddLineButton2, Button AddLineButton3, Button AddLineButton4, Button AddLineButton5, Button AddLineButton6, Label label1, Label label2, Label Column1Label, Label Column2Label, Label Column3Label, Label Column4Label, Label Column5Label, Label Column6Label, Label Column7Label, TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4, TextBox textBox5, TextBox textBox6, TextBox textBox7)
        {
            panel4.BackColor = Color.Lavender;
            panel5.BackColor = Color.DeepSkyBlue;
            dataGridViewTransformData2.BackgroundColor = Color.Lavender;
            DarkThemeButton.ForeColor = SystemColors.ActiveCaptionText;
            WhiteThemeButton.ForeColor = SystemColors.ActiveCaptionText;
            labelTheme.ForeColor = SystemColors.ActiveCaptionText;
            AddLineButton.ForeColor = SystemColors.ActiveCaptionText;
            AddLineButton.BackColor = Color.Lavender; ;
            AddLineButton2.ForeColor = SystemColors.ActiveCaptionText;
            AddLineButton2.BackColor = Color.Lavender;
            AddLineButton3.ForeColor = SystemColors.ActiveCaptionText;
            AddLineButton3.BackColor = Color.Lavender;
            AddLineButton4.ForeColor = SystemColors.ActiveCaptionText;
            AddLineButton4.BackColor = Color.Lavender;
            AddLineButton5.ForeColor = SystemColors.ActiveCaptionText;
            AddLineButton5.BackColor = Color.Lavender;
            AddLineButton6.ForeColor = SystemColors.ActiveCaptionText;
            AddLineButton6.BackColor = Color.Lavender;
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label2.ForeColor = SystemColors.ActiveCaptionText;
            Column1Label.ForeColor = SystemColors.ActiveCaptionText;
            Column2Label.ForeColor = SystemColors.ActiveCaptionText;
            Column3Label.ForeColor = SystemColors.ActiveCaptionText;
            Column4Label.ForeColor = SystemColors.ActiveCaptionText;
            Column5Label.ForeColor = SystemColors.ActiveCaptionText;
            Column6Label.ForeColor = SystemColors.ActiveCaptionText;
            Column7Label.ForeColor = SystemColors.ActiveCaptionText;
            textBox1.BackColor = SystemColors.Window;
            textBox2.BackColor = SystemColors.Window;
            textBox3.BackColor = SystemColors.Window;
            textBox4.BackColor = SystemColors.Window;
            textBox5.BackColor = SystemColors.Window;
            textBox6.BackColor = SystemColors.Window;
            textBox7.BackColor = SystemColors.Window;
        }
        static public void ThemeMethod2(Panel panel1, Panel panel2, DataGridView dataGridView1, Button DarkThemeButton, Button WhiteThemeButton, Label labelTheme, Label label1, Label label2)
        {
            panel1.BackColor = SystemColors.WindowFrame; // Panel1BackColor вместо цвета и класса цветов
            panel2.BackColor = SystemColors.GrayText;
            dataGridView1.BackgroundColor = SystemColors.WindowFrame;
            DarkThemeButton.ForeColor = SystemColors.ControlLightLight;
            WhiteThemeButton.ForeColor = SystemColors.ControlLightLight;
            labelTheme.ForeColor = SystemColors.ControlLightLight;
            label1.ForeColor = SystemColors.ControlLightLight;
            label2.ForeColor = SystemColors.ControlLightLight;
        }
        static public void ThemeMethodLight2(Panel panel1, Panel panel2, DataGridView dataGridView1, Button DarkThemeButton, Button WhiteThemeButton, Label labelTheme, Label label1, Label label2)
        {
            panel1.BackColor = Color.Lavender;
            panel2.BackColor = Color.DeepSkyBlue;
            dataGridView1.BackgroundColor = Color.Lavender;
            DarkThemeButton.ForeColor = SystemColors.ActiveCaptionText;
            WhiteThemeButton.ForeColor = SystemColors.ActiveCaptionText;
            labelTheme.ForeColor = SystemColors.ActiveCaptionText;
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label2.ForeColor = SystemColors.ActiveCaptionText;
        }
        static public void ThemeMethod(Panel panel1, Panel panel2, Label label2, Label label3, Button buttonLoginPass, TextBox loginName, TextBox passwordName, Button DarkThemeButton, Button WhiteThemeButton, Label labelTheme)
        {
            panel1.BackColor = SystemColors.WindowFrame; // Panel1BackColor вместо цвета и класса цветов
            panel2.BackColor = SystemColors.GrayText;
            label2.ForeColor = SystemColors.ControlLightLight;
            label3.ForeColor = SystemColors.ControlLightLight;
            buttonLoginPass.ForeColor = SystemColors.ControlLightLight;
            loginName.BackColor= SystemColors.ScrollBar;
            passwordName.BackColor = SystemColors.ScrollBar;
            DarkThemeButton.ForeColor = SystemColors.ControlLightLight;
            WhiteThemeButton.ForeColor = SystemColors.ControlLightLight;
            labelTheme.ForeColor = SystemColors.ControlLightLight;
        }

        static public void ThemeMethodLight(Panel panel1, Panel panel2, Label label2, Label label3, Button buttonLoginPass, TextBox loginName, TextBox passwordName, Button DarkThemeButton, Button WhiteThemeButton, Label labelTheme)
        {
            panel1.BackColor = Color.Lavender;
            panel2.BackColor = Color.DeepSkyBlue;
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label3.ForeColor = SystemColors.ActiveCaptionText;
            buttonLoginPass.ForeColor = SystemColors.ActiveCaptionText;
            loginName.BackColor = SystemColors.Window;
            passwordName.BackColor = SystemColors.Window;
            DarkThemeButton.ForeColor = SystemColors.ActiveCaptionText;
            WhiteThemeButton.ForeColor = SystemColors.ActiveCaptionText;
            labelTheme.ForeColor = SystemColors.ActiveCaptionText;
        }
    }
}
