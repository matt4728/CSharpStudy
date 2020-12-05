﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary
{
    class DiaryData
    {
        public DateTime Date;
        public string Title;
        public string Content;
        public List<string> Tags = new List<string>();
        public bool Encrypted;
    }
}
