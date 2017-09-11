using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expr5

{
    class Program
    {
        static void Main(string[] args)
        {
            Double a;
            Double b;
            Double c;
            Console.WriteLine("Напишите временной отрезок от одного года до другого");
            a = Convert.ToDouble(Console.ReadLine());
            b = Convert.ToDouble(Console.ReadLine());
            c = b - a;
            c = c / 4 ;
            c = c - (c % 4);
            Console.WriteLine("Количество високосных лет равно " + c);
            Console.Read();
        }
    }
}
