using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part4_task9
{
    class Program
    {
        static void Main(string[] args)
        {
            int amountOfNumbers = 0;

            for (int number = 10000; number != 99999; number++)
            {
                int a = (number / 10000); //12345
                int b = (number / 1000) - (a * 10);
                int c = (number / 100) - (a * 100 + b * 10);
                int d = ((number % 100) - (number % 10)) / 10;
                int e = number % 10;
                double amount = Math.Pow(a, 5) + Math.Pow(b, 5) + Math.Pow(c, 5) + Math.Pow(d, 5) + Math.Pow(e, 5);

                if (amount == number)
                    amountOfNumbers++;
            }

            Console.WriteLine(amountOfNumbers);
            Console.Read();
        }
    }
}
