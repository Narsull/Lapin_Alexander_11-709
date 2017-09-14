using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part1_task9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("a * x^2 + b * x + c");
            Console.Write("a=");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("b=");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.Write("c=");
            int c = Convert.ToInt32(Console.ReadLine());
            String Formula = null;
            if (a != 0)
            {
                Formula = a + " * x^2 ";
            }
            if (b != 0)
            {
                if (b < 0 | a == 0)
                {
                    Formula = Formula + b + " * x ";
                }
                else
                    Formula = Formula + " + " + b + " * x ";
            }
            if (c != 0)
            {
             if (c < 0 | b == 0 & a == 0)
                {
                Formula = Formula + " " + c;
                }
                else
                    Formula = Formula + " + " + c;
            }
            if (Formula == null)
            {
                Console.Write("Любое число является решением уравнения.");
            }
            else
                Console.Write(Formula);
            Console.Read();
        }
    }
}
