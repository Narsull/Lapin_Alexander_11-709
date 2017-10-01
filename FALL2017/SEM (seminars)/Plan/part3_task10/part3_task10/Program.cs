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
            int number = 0;
            int number1 = 0;
            int i = 0;
            Console.WriteLine("Напишите последовательнось положительныч и отрицетльных чисел.");
            Console.WriteLine("Напишите ноль, если ваша последовательность закончена.");
            for (int a = 0; number == 0; a++)
            {
                number = Convert.ToInt32(Console.ReadLine());
                if (number > 0 && number1 < 0 || number < 0 && number1 > 0)
                    i = i + 1;
                number1 = number;
            }
            Console.WriteLine(i);
            Console.Read();
        }
    }
}
