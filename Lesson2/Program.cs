using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    class Program
    {
        #region Task1
        public enum Month
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
        
        public static string Season (Month month)
        {
            string season = "";
            switch (month)
            {
                case Month.Декабрь:
                case Month.Январь:
                case Month.Февраль:
                    season = "Зима";
                    break;
                case Month.Март:
                case Month.Апрель:
                case Month.Май:
                    season = "Весна";
                    break;
                case Month.Июнь:
                case Month.Июль:
                case Month.Август:
                    season = "Лето";
                    break;
                case Month.Сентябрь:
                case Month.Октябрь:
                case Month.Ноябрь:
                    season = "Осень";
                    break;
            }
            return season;
        }


        public static void Task1()
        {
            float average; //Средняя температура
            Month month; // Текущий месяц

            while (true)
            {
                Console.WriteLine("Здравствуйте!\nПроверка заданий 1,2,5\nВведите минимальную суточную температуру");
                var minDegreeStr = Console.ReadLine();
                Console.WriteLine("Введите максимальную суточную температуру");
                var maxDegreeStr = Console.ReadLine();
                if (float.TryParse(minDegreeStr, out float minDegree) && float.TryParse(maxDegreeStr, out float maxDegree))
                {
                    average = (minDegree + maxDegree) / 2;
                    Console.WriteLine($"Среднесуточная температура:{average}");
                    break;
                }
                else
                {
                    Console.WriteLine("Не удалось конвертировать введенные данные.\nПопробуйте заново");
                }
            }

            while (true)
            {
                Console.WriteLine("Введите порядковый номер текущего месяца");
                var curMonth = Console.ReadLine();
                if (Enum.TryParse(curMonth, out Month res) && Enum.IsDefined(typeof(Month),res))
                {
                    month = res;
                    Console.WriteLine($"Текущий месяц: {month}");
                    break;
                }
                else
                {
                    Console.WriteLine("Не удалось конвертировать введенные данные.\nПопробуйте заново");
                }
            }
            
            if(Season(month) == "Зима" && average > 0)
            {
                Console.WriteLine("Дождливая Зима");
            }
            else
            {
                Console.WriteLine($"Не дождливая Зима, сейчас:{Season(month)}");
            }
            
        }
        #endregion
        #region Task2
        public static void Task2()
        {
            while (true)
            {
                Console.WriteLine("Проверка задания 3 на четность числа.\nВведите число");
                var userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int res))
                {
                    if (isEven(res))
                    {
                        Console.WriteLine($"{res} - четное число");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{res} - нечетное число");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Не удалось конвертировать введенные данные.\nПопробуйте заново");
                }
            }  
        }

    public static bool isEven(int x)
        {
            bool isEven = x % 2 == 0 ? true : false;
            return isEven;
        }
        #endregion
        #region Task3
        public static void Task3()
        {
            Cheque cheque = new Cheque("OOO Лента", "г.Москва ул.Островитянова, 53", 1835032854, 0022201);
            goods good1 = new goods("Вода пит. BONAQUA н/газ", 29.99, 5);
            goods good2 = new goods("Пакет лента майка 12кг", 5.49, 3);
            goods good3 = new goods("Малина 4 сезона с/м 300г", 249.59, 3);
            cheque.goodsList.Add(good1);
            cheque.goodsList.Add(good2);
            cheque.goodsList.Add(good3);
            cheque.Draw();
            Console.ReadLine();
        }
        #endregion
        #region Task4
        public struct Office
        {
            public WorkingDays schedule;
            public string officeName;

            public Office(WorkingDays work, string name)
            {
                schedule = work;
                officeName = name;
            }
        }
        [Flags]
        public enum WorkingDays
        {
            Понедельник = 0b_0000001,
            Вторник = 0b_0000010,
            Среда = 0b_0000100,
            Четверг = 0b_0001000,
            Пятница = 0b_0010000,
            Суббота = 0b_0100000,
            Воскресенье = 0b_1000000
        }
        public static bool isFiveDays(WorkingDays office)
        {
            WorkingDays FiveDaysMask = WorkingDays.Понедельник | WorkingDays.Вторник | WorkingDays.Среда | WorkingDays.Четверг | WorkingDays.Пятница;
            WorkingDays FiveDays = office & FiveDaysMask;
            return FiveDays == office;
        }
        public static bool isSevenDays(WorkingDays office)
        {
            WorkingDays SevenDaysMask = WorkingDays.Понедельник | WorkingDays.Вторник | WorkingDays.Среда | WorkingDays.Четверг | WorkingDays.Пятница | WorkingDays.Суббота | WorkingDays.Воскресенье;
            WorkingDays SevenDays = office & SevenDaysMask;
            return SevenDays == SevenDaysMask;
        }
        
        public static void Task4()
        {

            Office BackOffice = new Office((WorkingDays)0b_0011111, "BackOffice");
            Office HomeOffice = new Office((WorkingDays)0b_1111111, "HomeOffice");
            Office RemoteOffice = new Office((WorkingDays)0b_0111110, "RemoteOffice");

            Office [] offices = { BackOffice, HomeOffice, RemoteOffice };
            foreach(var office in offices)
            {
                if (isFiveDays(office.schedule))
                {
                    Console.WriteLine($"Оффис {office.officeName} работает с Понедельника по Пятницу");
                }
                if (isSevenDays(office.schedule))
                {
                    Console.WriteLine($"Оффис {office.officeName} работает с Понедельника по Воскресенье");
                }
                if(!isFiveDays(office.schedule)&& !isSevenDays(office.schedule))
                {
                    Console.WriteLine($"Оффис {office.officeName} работает по следующим дням {office.schedule}");
                }
            }
        }
        #endregion

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Здравствуйте! Вас приветствует мастер проверки домашнего задания 2\nВведите номер задания для проверки: \n1. " +
                "Температура и месяцы (задания 1,2 и 5 из методички)\n2. Проверка четности числа (задание 3 из методички)\n3. Чек (задание 4 из методички)\n" +
                "4. Задача на битовые маски (задание 6 из методички)\nДля выхода нажмите 0");
                var choice = Console.ReadLine();
                if(int.TryParse(choice,out int res))
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
