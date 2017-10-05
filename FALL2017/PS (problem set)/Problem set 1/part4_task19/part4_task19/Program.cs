using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part4_task19
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Convert.ToInt32(Console.ReadLine());
            int divider = 1;
            int a = 1;

            while (a < number)
            {
                if (number % a == 0)
                {
                    divider = a;
                }
                a++;
            }

            Console.WriteLine(divider);
            Console.Read();
        }
    }
}
