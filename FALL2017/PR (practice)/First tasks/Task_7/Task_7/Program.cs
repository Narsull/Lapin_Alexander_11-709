using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("x1=");
            double x1 = Convert.ToDouble(Console.Read());
            Console.WriteLine("y1=");
            double y1 = Convert.ToDouble(Console.Read());
            Console.WriteLine("x2=");
            double x2 = Convert.ToDouble(Console.Read());
            Console.WriteLine("y2=");
            double y2 = Convert.ToDouble(Console.Read());
            Console.WriteLine((x2 - x1) + ';' + (y2 - y1));
            Console.WriteLine((y2 - y1) + ';' + (-1) * (x2 - x1));
            Console.Read();
        }
    }
}
