using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SeaBattle
{
    
    class Program
    {
        public static string GenerateMail(string name)
        {
            Random rnd = new Random();
            Regex eMail = new Regex(@"[A-Za-z]+[\.A-Za-z0-9_-]*[A-Za-z0-9]+@[A-Za-z]+\.[A-Za-z]+");
            string[] domen = { "@gmail.com", "@outlook.com", "@mail.ru", "@yandex.ru" };
            string mail = $"{name}{rnd.Next(0, 100)}{domen[rnd.Next(0, domen.Length)]}";
            if (eMail.IsMatch(mail))
            {
                return mail;
            }
            else
            {
                throw new Exception("Doesn't match RegEx");
            }
        }
        public static char[] Reverse(string message)
        {
            char[] letters = message.ToCharArray();
            char[] reversed = new char[letters.Length];
            for(int i = 0; i < reversed.Length; i++)
            {
                reversed[i] = letters[reversed.Length - i  - 1];
            }
            return reversed;
        }
        
        public static void Diagonal(int [,] array, int offset)
        {
            if (array.GetLength(0) != array.GetLength(1))
            {
                Console.WriteLine("Измерения массивы должны быть соразмерны");
            }
            else
            {
                Random rnd = new Random();
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        if (i == j || j == array.GetLength(1) - (i + 1))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            Console.ResetColor();
                        }
                        array[i, j] = rnd.Next(0, 100);
                        if (array[i, j].ToString().Length < 2)
                        {
                            Console.Write(array[i, j] + "  ");
                        }
                        else
                            Console.Write(array[i, j] + " ");
                    }
                    Console.WriteLine("");
                }
                Console.ResetColor();
                Console.WriteLine("");

                for (int i = 0; i < array.GetLength(1); i++)
                {
                    Console.SetCursorPosition(i * offset, Console.CursorTop);
                    Console.Write(array[i, i]);
                    Console.SetCursorPosition(array.GetLength(1) * offset - ((i + 1) * offset), Console.CursorTop);
                    Console.Write(array[i, array.GetLength(1) - (i + 1)]);
                    Console.WriteLine("");
                }
            }
        }
        public static void Task1()
        {
            Console.WriteLine("Вывод диагонали квадртаного массива");
            Console.ReadLine();
            Random rnd = new Random();
            int[,] array = new int[10, 10];
            Diagonal(array, 3);
            Console.ReadLine();
        }
        public static void Task2()
        {
            Console.WriteLine("Введите набор текста, а программа напишет его в обратном направлении");
            var input = Console.ReadLine();
            var word = Reverse(input);
            foreach (var letter in word)
            {
                Console.Write(letter);
            }
            Console.ReadLine();
        }
        public static void Task3()
        {
            Console.WriteLine("Массив имен и электронных адрессов");
            string[] names = { "Linar", "Ivan", "Nikolai", "Alena", "Katya" };
            string[,] mailBook = new string[5, 2];
            for (int i = 0; i < mailBook.GetLength(0); i++)
            {
                mailBook[i, 0] = names[i];
                mailBook[i, 1] = GenerateMail(names[i]);
            }
            for (int i = 0; i < mailBook.GetLength(0); i++)
            {
                Console.WriteLine($"{mailBook[i, 0]}: {mailBook[i, 1]}");
            }
        }
        public static void Task4()
        {
            Console.WriteLine("Случайное расположение кораблей в игре Морской Бой");
            Console.ReadLine();
            var now = DateTime.Now;
            Map map = new Map();
            List<Ship> ships = new List<Ship>();
            ships = Ship.defShips();
            foreach (var ship in ships)
            {
                map.PlaceShip(ship);
            }
            map.DrawMap('0', 'X');
            var end = DateTime.Now;
            Console.WriteLine($"Время выполнения программы:{end - now}; Количество попыток:{map.Attemp}");
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Здравствуйте! Вас приветствует мастер проверки домашнего задания 3\nВведите номер задания для проверки: \n1. " +
                "Вывод диагонали\n2. Вывод текста в обратном направлении\n3. Массив имен и электронных адрессов\n" +
                "4. Случайное расположение кораблей в игре Морской Бой\nДля выхода нажмите 0");
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
        }
    }
}
