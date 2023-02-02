using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;

namespace Autorization
{
    public partial class ErrorForm : Form
    {

        public static void Show(string desc)
        {
            ErrorForm error = new ErrorForm("errors", desc);
            error.ShowDialog();
        }

        string errorFileName;
        string desc;
        public ErrorForm(string errorFileName, string desc)
        {
            InitializeComponent();
            this.errorFileName = errorFileName;
            this.desc = desc;
        }

        private void ErrorForm_Load(object sender, EventArgs e)
        {
            string formater = Directory.GetCurrentDirectory();

            formater = formater.Replace('\\', '/');

            chromiumWebBrowser1.Load($"file://{formater}/{errorFileName}.html");
            Desc.Text = desc;
        }
    }
}
