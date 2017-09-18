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
            int chislo = Convert.ToInt32(Console.ReadLine());
            int a = (chislo / 1000);
            int b = (chislo / 100) - (a * 10);
            int c = (chislo / 10) - (a * 100) - (b * 10);
            int d = (chislo % 10);
            int amount = a + b + c + d;
            Console.WriteLine(amount);
            Console.Read();
        }
    }
}
