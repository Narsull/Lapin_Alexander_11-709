using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part1_task14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Напишите номер билета"); //123456
            int ticket = Convert.ToInt32(Console.ReadLine());
            int a = (ticket / 100000); // Первая цифра
            int b = (ticket / 10000) - (a * 10); // Вторая цифра
            int c = (ticket / 1000) - (a * 100 + b * 10); // Третья цифра
            int d = ((ticket % 1000) - (ticket % 100)) / 100; // Четвёртая цифра
            int e = ((ticket % 100) - (ticket % 10)) / 10; // Пятая цифра
            int f = ticket % 10; // Шестая цифра
            int amount1 = a + b + c; // Сумма первых трёх цифр
            int amount2 = d + e + f; // Сумма последних трёх цифр
            if (amount1 == amount2)
            {
                Console.WriteLine("Поздравляем!");
                Console.WriteLine("Ваш билет счастливый!");
            }
            else 
            Console.WriteLine("К сожалению, ваш билет не является счастливым.");
            Console.Read();
        }
    }
}
