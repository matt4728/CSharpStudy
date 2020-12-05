using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
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
            SaveDiary(
                title: textBox1.Text,
                date: dateTimePicker1.Value,
                text: richTextBox1.Text,
                tags: _tagData
                .Select(x => x.TagText)
                .ToList()
            );
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

        private void SaveDiary(string title, DateTime date, string text, List<string> tags, bool encrypted = false)
        {

            diary.Title = title;
            diary.Content = text;
            diary.Date = date;
            diary.Tags = tags;
            diary.Encrypted = encrypted;

            var jsonText = JsonConvert.SerializeObject(diary, Formatting.Indented);

            var path = @"C:\Users\vios\Desktop\diary";

            var fileName0 = date.ToString("yyyyMMdd") + ".txt";
            var fileName = $"{date:yyyyMMdd}.json";

            var diaryPath = Path.Combine(path, fileName);

            File.WriteAllText(diaryPath, jsonText);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var password = textBox3.Text;
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("암호를 확인하세요.");
                return;
            }

            while (password.Length < 32)
            {
                password = password.Trim() + password.Trim();
            }

            byte[] key = password
                .Select(x => (byte)x)
                .Take(32)
                .ToArray();
            byte[] iv = key.Take(16).ToArray();

            var encrypted = Encryptor.EncryptStringToBytes(richTextBox1.Text, key, iv);

            String text = String.Join(",", encrypted);
            SaveDiary(
                title: textBox1.Text,
                date: dateTimePicker1.Value,
                text: text,
                tags: _tagData
                .Select(x => x.TagText)
                .ToList(),
                encrypted: true
            );
        }
    }
}