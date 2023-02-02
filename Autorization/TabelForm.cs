using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;

namespace Autorization
{
    public partial class TabelForm : Form
    {
        public TabelForm()
        {
            InitializeComponent();
        }

        private void TabelForm_Load(object sender, EventArgs e)
        {
            chromiumWebBrowser1.JavascriptMessageReceived += OnBrowserJavascriptMessageReceived;
        }

        int year;
        int month;

        private void OnBrowserJavascriptMessageReceived(object sender, JavascriptMessageReceivedEventArgs e)
        {
             var windowSelection = (string)e.Message;
            ChangeTabelForm edit = new ChangeTabelForm(windowSelection, year, month);
            edit.ShowDialog();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            month = DateTime.Now.Month;
            year = DateTime.Now.Year;
            TimeSheetGenerator generator = new TimeSheetGenerator(year, month);
            ClassForTabel loader = new ClassForTabel();
            loader.LoadDataFromBD(DateTime.Now);
            loader.LoadAllIntoBuilder(generator);
            string html  = generator.GenCode();
            File.WriteAllText("tmp.html", html);
            string formater = Directory.GetCurrentDirectory();

            formater = formater.Replace('\\', '/');

            chromiumWebBrowser1.Load($"file://{formater}/tmp.html");
        }
    }
}
