using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = 0;
            int second = 0;
            int third = 0;
            Console.WriteLine("Напишите три числа.");
            int x = Convert.ToInt32(Console.ReadLine());
            int y = Convert.ToInt32(Console.ReadLine());
            int z = Convert.ToInt32(Console.ReadLine());
            if (x > z && x > y)
            {
                first = x;
                if (y > z)
                {
                    second = y;
                    third = z;
                }
                else
                {
                    second = z;
                    third = y;
                }
            }
            if (y > z && y > x)
            {
                first = y;
                if (z > x)
                {
                    second = z;
                    third = x;
                }
                else
                {
                    second = x;
                    third = z;
                }
            }
            if (z > x && z > y)
            {
                first = z;
                if (y > x)
                {
                    second = y;
                    third = x;
                }
                else
                {
                    second = x;
                    third = y;
                }
            }
            Console.WriteLine(first);
            Console.WriteLine(second);
            Console.WriteLine(third);
            Console.Read();
        }
    }
}
