using Newtonsoft.Json;
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
            var diary = new DiaryData();

            diary.Title = textBox1.Text;
            diary.Content = richTextBox1.Text;
            diary.Date = dateTimePicker1.Value;

            var jsonText = JsonConvert.SerializeObject(diary, Formatting.Indented);
            
            var path = @"C:\Users\matt\Desktop\diary";

            var fileName0 = date.ToString("yyyyMMdd") + ".txt";
            var fileName = $"{date:yyyyMMdd}.json";

            var diaryPath = Path.Combine(path, fileName);

            File.WriteAllText(diaryPath, jsonText);
        }
    }
}
