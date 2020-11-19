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

namespace Diary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var date = dateTimePicker1.Value;
            var text = richTextBox1.Text;

            var path = @"C:\Users\matt\Desktop\diary";

            var fileName0 = date.ToString("yyyyMMdd") + ".txt";
            var fileName = $"{date:yyyyMMdd}.txt";

            var diaryPath = Path.Combine(path, fileName);

            File.WriteAllText(diaryPath, text);
        }
    }
}
