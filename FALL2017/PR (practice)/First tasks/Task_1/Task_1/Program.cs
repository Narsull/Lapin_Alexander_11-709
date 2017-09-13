using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Double A;
            Double B;
            Console.WriteLine("Напишите два числа");
            Console.WriteLine();
            Console.Write("A=");
            A = Convert.ToDouble(Console.ReadLine());
            Console.Write("B=");
            B = Convert.ToDouble(Console.ReadLine());
            A = A + B;
            B = A - B;
            A = A - B;
            Console.WriteLine("A=" + A);
            Console.WriteLine("B=" + B);
            Console.Read();
        }
    }
}
