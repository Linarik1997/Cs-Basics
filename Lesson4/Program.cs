using System;

namespace Lesson4
{
    class Program
    {
        #region Task1
        static string GetFulName(string firstName,string lastName, string patronymic)
        {
            var res = $"{lastName} {firstName} {patronymic}";
            return res;
        }
        static void Task1()
        {
            Random rnd = new Random();
            string[] names = { "Михаил", "Алексей", "Сергей", "Дмитрий", "Евгений" };
            string[] surnames = { "Смирнов", "Иванов", "Петров", "Алексеев", "Игнатьев" };
            string[] patrons = { "Александрович", "Артемович", "Никитич", "Вячеславович", "Павлович" };
            Console.WriteLine("Введите Имя");
            var name = Console.ReadLine();
            Console.WriteLine("Введите Фамилию");
            var surname = Console.ReadLine();
            Console.WriteLine("Введите Отчество");
            var patron = Console.ReadLine();
            Console.WriteLine($"Результат работы метода:{GetFulName(name, surname, patron)}");
            Console.WriteLine("Остальные ФИО будут выбраны и сформированы случайно");
            for(int i = 0; i <= 3; i++)
            {
                name = names[rnd.Next(0, names.Length)];
                surname = surnames[rnd.Next(0, surnames.Length)];
                patron = patrons[rnd.Next(0, patrons.Length)];
                Console.WriteLine(GetFulName(name, surname, patron));
            }
        }
        #endregion
        #region Task2
        static double SummLine(string s)
        {
            char[] div = { ' ', ',', '.', ':', '\t' };
            string[] lines = s.Split(div, StringSplitOptions.RemoveEmptyEntries);
            double summ = 0;
            foreach (var line in lines)
            {
                if (double.TryParse(line, out double res))
                {
                    summ += res;
                }
                else
                {
                    Console.WriteLine($"Не удается преобразовать {line} в число");
                }
            }
            return summ;
        }
        
        static void Task2()
        {
            Console.WriteLine("Введите последовательность чисел через пробел или пробелы.\nПрограмма отфильтрует лишние разделители и не числовые данные");
            var line = Console.ReadLine();
            var summ = SummLine(line);
            Console.WriteLine(summ);
            Console.ReadLine();
        }
        #endregion
        #region Task3
        enum Seasons
        {
            Winter = 1,
            Spring,
            Summer,
            Autumn,
            NaN
        }
        enum Months
        {
            Январь = 1,
            Февраль,
            Март,
            Апрель,
            Май,
            Июнь,
            Июль,
            Август,
            Сентябрь,
            Октябрь,
            Ноябрь,
            Декабрь
        }
        static Seasons SeasonByMonth(int number, out string mistake)
        {
            mistake = "";
            if (Enum.IsDefined(typeof(Months), number))
            {
                switch (Enum.ToObject(typeof(Months),number))
                {
                    case Months.Декабрь:
                    case Months.Январь:
                    case Months.Февраль:
                        return Seasons.Winter;
                    case Months.Март:
                    case Months.Апрель:
                    case Months.Май:
                        return Seasons.Spring;
                    case Months.Июнь:
                    case Months.Июль:
                    case Months.Август:
                        return Seasons.Summer;
                    default:
                        return Seasons.Autumn;
                            
                }
            }
            else
            {
                mistake = $"Месяц с порядковым номером {number} не определен";
                return Seasons.NaN;
            }
        }
        static void Task3()
        {
            Console.WriteLine("Введите порядковый номер месяца");
            var n = Console.ReadLine();
            int.Parse(n);
            var season = SeasonByMonth(int.Parse(n), out string mistake);
            if (season == Seasons.NaN)
            {
                Console.WriteLine(mistake);
            }
            else
            {
                Console.WriteLine($"месяц {(Months)int.Parse(n)}, сезон {season}");
            }
            Console.ReadLine();
        }
        #endregion
        #region Task4
        static int Fibonacci(int number)
        {
            if (number <= 1)
                return number;
            else
                return Fibonacci(number - 1) + Fibonacci(number - 2);
        }
        static void Task4()
        {
            Console.WriteLine("Введите номер в последовательности Фибоначчи, а программа вернет значение");
            var fib = Console.ReadLine();
            if(int.TryParse(fib,out int result))
            {
                Console.WriteLine($"Число {result} в последовательности Фибоначчи = {Fibonacci(result)}");
            }
            else
            {
                Console.WriteLine($"Не удается преобразовать {fib} в целое число");
            }
        }
        #endregion
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Здравствуйте! Вас приветствует мастер проверки домашнего задания 2\nВведите номер задания для проверки: \n1. " +
                "Метод GetFullName\n2. Возврат суммы всех чисел в строке\n3. Метод определения времени года по порядковому номеру месяца\n" +
                "4. Рекурсия Фибоначчи\nДля выхода нажмите 0");
                var choice = Console.ReadLine();
                if (int.TryParse(choice, out int res))
                {
                    switch (res)
                    {
                        case 1:
                            Console.Clear();
                            Task1();
                            Console.Clear();
                            break;
                        case 2:
                            Console.Clear();
                            Task2();
                            Console.Clear();
                            break;
                        case 3:
                            Console.Clear();
                            Task3();
                            Console.Clear();
                            break;
                        case 4:
                            Console.Clear();
                            Task4();
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
