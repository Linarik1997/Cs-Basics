using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте! Как вас зовут?");
            var userName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Приятно познакомиться {userName}, дата нашего знакомства: {DateTime.Now}");
            Console.ReadLine();
        }
    }
}
