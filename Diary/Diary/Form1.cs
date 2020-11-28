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
        public class TagControlData
        {
            public int Index { get; set; }
            public string TagText { get; set; }
            public Label Control { get; set; }
            public Button DeleteButton { get; set; }
        }

        private DiaryData diary;

        private List<TagControlData> _tagData = new List<TagControlData>();

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
                var tagText = textBox2.Text;
                var y = 203;

                var newTagLabel = new Label();

                newTagLabel.Text = tagText;
                
                var deleteButton = new Button();
                deleteButton.Text = "X";
                
                deleteButton.Click += (_, __) =>
                {
                    TagControlData removedData = null;
                    foreach (var tagData in _tagData)
                    {
                        if (tagData.Control == newTagLabel)
                        {
                            removedData = tagData;
                        }
                    }

                    _tagData.Remove(removedData);
                    this.Controls.Remove(removedData.Control);
                    this.Controls.Remove(removedData.DeleteButton);
                    UpdateTagList();
                };

                var tagControlData = new TagControlData
                {
                    TagText = tagText,
                    Control = newTagLabel,
                    DeleteButton = deleteButton,
                };


                diary.Tags.Add(textBox2.Text);
                this.Controls.Add(newTagLabel);
                _tagData.Add(tagControlData);

                textBox2.Text = "";

                UpdateTagList();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void UpdateTagList()
        {
            int x = 10;

            foreach (var TagItem in _tagData)
            {
                TagItem.Control.SetBounds(
                    x,
                    203,
                    70,
                    20);
                TagItem.DeleteButton.SetBounds(
                    x + 70,
                    203,
                    20,
                    20
                    );
                x += 100;
            }

            textBox2.Left = x;
        }
    }
}