using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part3_task10
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 1;
            int number1 = 1;
            int i = 0;
            Console.WriteLine("Напишите последовательнось положительных и отрицетльных чисел.");
            Console.WriteLine("Напишите ноль, если ваша последовательность закончена.");
            while (number != 0)
            {
                number = Convert.ToInt32(Console.ReadLine());
                if (number > 0 && number1 < 0 || number < 0 && number1 > 0)
                    i = i + 1;
                number1 = number;
            }
            Console.WriteLine("Произошло " + i + " изменений(ия) знака");
            Console.Read();
        }
    }
}
