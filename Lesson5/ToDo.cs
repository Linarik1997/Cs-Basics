using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Lesson5
{
    class ToDo
    {
        public string title { get; set; }
        public bool isDone { get; set; }

        public ToDo(string title, bool isDone)
        {
            this.title = title;
            this.isDone = isDone;
        }
        public ToDo()
        {

        }
    }
}
