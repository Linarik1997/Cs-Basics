using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

namespace Lesson5
{
    class toDoList

    {
        private string fileName { get; set; }
        private List<ToDo> list;

        public ToDo this[int index]
        {
            get { return list[index]; }
            set { this.list[index] = value; }
        }
        public toDoList(string name)
        {
            this.fileName = name;
            list = new List<ToDo>();
        }
        public toDoList()
        {

        }
        public void AddTask(ToDo task)
        {
            list.Add(task);
        }
        public void SetAsDone(int index)
        {
            if (index < 0 || index > list.Count)
                throw new IndexOutOfRangeException();
            list[index].isDone = true;
        }
        public void SaveList()
        {
            var dir = @"C:\ToDoList";
            var fileDir = Path.Combine(dir, fileName);
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;
            string json = JsonSerializer.Serialize(list, options);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            File.WriteAllText(fileDir, json);
        }
        private bool CanLoadList()
        {
            var dir = @"C:\ToDoList";
            var fileDir = Path.Combine(dir, fileName);
            if (File.Exists(fileDir))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void LoadList()
        {
            if (!CanLoadList())
            {
                return;
            }
            var dir = @"C:\ToDoList";
            var fileDir = Path.Combine(dir, fileName);
            string json = File.ReadAllText(fileDir);
            list = JsonSerializer.Deserialize<List<ToDo>>(json);
        }
        public void Print()
        {
            for(int i = 0; i < list.Count; i++)
            {
                Console.Write(i + 1 + "  ");
                Console.Write(list[i].title + "  ");
                if (list[i].isDone)
                {
                    Console.Write("«[x]»");
                }
                else
                {
                    Console.Write("«[ ]»");
                }
                Console.WriteLine("");
            }
        }
    }
}
