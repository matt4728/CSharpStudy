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
        private DiaryData diary;
        public Form1()
        {
            InitializeComponent();
            diary = new DiaryData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var date = dateTimePicker1.Value;

            diary.Title = textBox1.Text;
            diary.Content = richTextBox1.Text;
            diary.Date = dateTimePicker1.Value;

            var jsonText = JsonConvert.SerializeObject(diary, Formatting.Indented);
            
            var path = @"C:\Users\vios\Desktop\diary";

            var fileName0 = date.ToString("yyyyMMdd") + ".txt";
            var fileName = $"{date:yyyyMMdd}.json";

            var diaryPath = Path.Combine(path, fileName);

            File.WriteAllText(diaryPath, jsonText);
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var y = 203;

                var newTagLabel = new Label();
                
                newTagLabel.Text = textBox2.Text;
                newTagLabel.SetBounds(
                    textBox2.Left, y, 100, 20);

                textBox2.Left += 100;
                textBox2.Text = "";

                diary.Tags.Add(textBox2.Text);

                this.Controls.Add(newTagLabel);
            }
        }
    }
}
