using System;
using System.Collections.Generic;
using System.IO;

namespace Lesson5
{
    class Program
    {
        #region Task1
        static void SaveText(string filename, string message)
        {
            string dir = @"C:\TestDir";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            var fileDir = Path.Combine(dir, filename);
            File.WriteAllText(fileDir, message);
        }
        static void Task1()
        {
            Console.WriteLine("Введите произвальный набор данных");
            var data = Console.ReadLine();
            Console.WriteLine("Введите название файла, она будет сохранен в директории C:\\TestDir (она будет создана)");
            var name = Console.ReadLine();
            try
            {
                SaveText(name, data);
                Console.WriteLine("Успех!");
            }
            catch 
            {
                Console.WriteLine("Не удалось сохранить файл с таким названием");
                Console.ReadLine();
            }
        }
        #endregion
        #region Task2
        static void SaveTime()
        {
            string dir = @"C:\TestDir";
            string fileName = "startup.txt";
            var filDir = Path.Combine(dir, fileName);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            var now = DateTime.Now.ToString();
            File.AppendAllText(filDir, "\n"+now);
        }
        static void Task2()
        {
            try
            {
                SaveTime();
                Console.WriteLine("startup.txt в директории C:\\TestDir дописал текущее время");
            }
            catch
            {
                Console.WriteLine("Не удалось дописать текущее время в файл startup.txt в директории C:\\TestDir");
                Console.ReadLine();
            }
        }
        #endregion
        #region Task3
        static void SaveBytes(byte[] bytes)
        {
            string dir = @"C:\TestDir";
            string fileName = "bytes.bin";
            var fileDir = Path.Combine(dir, fileName);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            File.WriteAllBytes(fileDir, bytes);
        }
        static void ReadBytes()
        {
            string dir = @"C:\TestDir";
            string fileName = "bytes.bin";
            var fileDir = Path.Combine(dir, fileName);
            var bytes = File.ReadAllBytes(fileDir);
            foreach(var el in bytes)
            {
                Console.Write(el + " ");
            }

        }
        static byte[] LineToByteArray(string input)
        {
            char[] div = { ' ', ',', '.', ':', '\t' };
            string[] lines = input.Split(div, StringSplitOptions.RemoveEmptyEntries);
            int count = 0;
            foreach (var line in lines)
            {
                if (byte.TryParse(line, out byte result))
                {
                    count++;
                }
            }
            if (count > 0)
            {
                byte[] bytes = new byte[count];
                int i = 0;
                foreach (var line in lines)
                {
                    if (byte.TryParse(line, out byte result))
                    {
                        bytes[i] = result;
                        i++;
                    }
                }
                return bytes;
            }
            else
            {
                throw new Exception("No bytes in Input");
            }
        }
        static void Task3()
        {
            Console.WriteLine("Введите с клавиатуры произвольный набор чисел (0...255)");
            var input = Console.ReadLine();
            try
            {
                var arr = LineToByteArray(input);
                SaveBytes(arr);
                Console.WriteLine($"Прочитаем файл:");
                ReadBytes();
                Console.ReadLine();
            }
            catch
            {
                Console.WriteLine($"Не удалось преобразовать {input} в массив байт");
                Console.ReadLine();
            }
        }
        #endregion
        #region Task4
        static void Task4()
        {
            Console.WriteLine("Введите директорию, а программа запишет дерево каталогов и файлов в текстовый файл");
            var path = Console.ReadLine();
            if (Directory.Exists(path))
            {
                try
                {
                    FileSystemSearch.Save("RootInfo.txt", @$"{path}");
                    Console.WriteLine("Файл RootInfo.txt с деревом файлов и каталогов сохранен в директории C:\\TestDir");
                }
                catch
                {
                    Console.WriteLine("Не удалось сохранить файл RootInfo.txt в директории C:\\TestDir");
                }
            }
            else
            {
                Console.WriteLine("Указанной вами директории не существует");
            }
        }
        #endregion
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Здравствуйте! Вас приветствует мастер проверки домашнего задания 5\nВведите номер задания для проверки: \n1. " +
              "Сохранить произвольный набор данных в клавиатуру\n2. Дописать текущее время в файл startup.txt\n3. Запись бинарного файла\n" +
              "4. Сохранение дерева каталогов и файлов по заданному пути в текстовый файл\nДля выхода нажмите 0");
                var choice = Console.ReadLine();
                if (int.TryParse(choice, out int res))
                {
                    switch (res)
                    {
                        case 1:
                            Console.Clear();
                            Task1();
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 2:
                            Console.Clear();
                            Task2();
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 3:
                            Console.Clear();
                            Task3();
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 4:
                            Console.Clear();
                            Task4();
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 0:
                            return;
                        default:
                            Console.WriteLine("Упс, кажется вы промахнулись");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Вы ввели не число!");
                }
            }
            //SaveText("test.txt", "123!");
            //SaveTime();
            //Console.WriteLine("Введите последовательность байтов с разделителем");
            //var input = Console.ReadLine();
            //SaveBytes(LineToByteArray(input));
            //ReadBytes();
            //toDoList tdl = new toDoList(@"tasks.json");
            //ToDo task1 = new ToDo("Купить хлеб", false);
            //tdl.AddTask(task1);
            //ToDo task2 = new ToDo("Купить шоколад", true);
            //tdl.AddTask(task2);
            //tdl.SaveList();
            //tdl.LoadList();
            //tdl.Print();
        }
    }
}
