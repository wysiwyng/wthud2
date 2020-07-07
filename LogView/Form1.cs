using System;
using System.Windows.Forms;
using WtLogging;

namespace LogView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            var res = dlg.ShowDialog();

            if (res != DialogResult.OK) return;

            LogReader.ReadLog(dlg.FileName);
        }
    }
}
