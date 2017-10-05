using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part2_task11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите двоичное число.");
            int paskal = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите десятичное натуральное число.");
            int k = Convert.ToInt32(Console.ReadLine());
            string str = Convert.ToString(paskal, 2);
            int laksap = Convert.ToInt32(str, 2);
            if (laksap % k == 0)
            {
                Console.WriteLine("Ввведённое двоичное число делится на число k нацело.");
            }
            else Console.WriteLine("Ввведённое двоичное число не делится на число k нацело.");
            Console.Read();
        }
    }
}
