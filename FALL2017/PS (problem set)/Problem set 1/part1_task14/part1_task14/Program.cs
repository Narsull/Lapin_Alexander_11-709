/* Лапин Александр
 * Группа 11-709
 * Задание 14 из первой части первых семистровок */

using System;

namespace part1_task14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Напишите номер билета");
            int ticket = Convert.ToInt32(Console.ReadLine());
            string ticketString = (ticket.ToString());
                if (ticketString.Length == 6)
            {
                int number1 = Convert.ToInt32(ticketString.Substring(0, 1));
                int number2 = Convert.ToInt32(ticketString.Substring(1, 1));
                int number3 = Convert.ToInt32(ticketString.Substring(2, 1));
                int number4 = Convert.ToInt32(ticketString.Substring(3, 1));
                int number5 = Convert.ToInt32(ticketString.Substring(4, 1));
                int number6 = Convert.ToInt32(ticketString.Substring(5, 1));

                int amount1 = number1 + number2 + number3; 
                int amount2 = number4 + number5 + number6;

                if (amount1 == amount2)
                {
                    Console.WriteLine("Поздравляем!");
                    Console.WriteLine("Ваш билет счастливый!");
                }
                else
                    Console.WriteLine("К сожалению, ваш билет не является счастливым.");
            }
            else
                Console.WriteLine("Допущена ошибка при написании номера билета.");
            Console.Read();
        }
    }
}
