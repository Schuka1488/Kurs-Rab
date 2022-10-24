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
        static public void ThemeMethod(Panel panel1, Panel panel2, Label label2, Label label3, Button buttonLoginPass, TextBox loginName)
        {
            panel1.BackColor = SystemColors.WindowFrame;
            panel2.BackColor = SystemColors.GrayText;
            label2.ForeColor = SystemColors.ControlLightLight;
            label3.ForeColor = SystemColors.ControlLightLight;
            buttonLoginPass.ForeColor = SystemColors.ControlLightLight;
            loginName.BackColor= SystemColors.ScrollBar;
        }
        static public void ThemeMethodLight(Panel panel1, Panel panel2, Label label2, Label label3, Button buttonLoginPass)
        {
            panel1.BackColor = Color.Lavender;
            panel2.BackColor = Color.DeepSkyBlue;
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label3.ForeColor = SystemColors.ActiveCaptionText;
            buttonLoginPass.ForeColor = SystemColors.ActiveCaptionText;
        }
    }
}
