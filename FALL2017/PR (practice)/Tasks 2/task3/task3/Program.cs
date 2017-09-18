using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Convert.ToInt32(Console.ReadLine());
            int a = (number / 1000);
            int b = (number / 100) - (a * 10);
            int c = (number / 10) - (a * 100) - (b * 10);
            int d = (number % 10);
            int amount = a + b + c + d;
            Console.WriteLine(amount);
            Console.Read();
        }
    }
}
