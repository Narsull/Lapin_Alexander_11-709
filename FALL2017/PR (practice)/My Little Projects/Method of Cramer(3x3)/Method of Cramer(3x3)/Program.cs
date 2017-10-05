using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method_of_Cramer_3x3_
{
    class Program
    {
        static void Main(string[] args)
        {
            Double a1;
            Double a2;
            Double a3;
            Double b1;
            Double b2;
            Double b3;
            Double c1;
            Double c2;
            Double c3;
            Double d1;
            Double d2;
            Double d3;
            Double delta;
            Double delta1;
            Double delta2;
            Double delta3;
            Double x1;
            Double x2;
            Double x3;
            Console.WriteLine("a1 b1 c1 | d1");
            Console.WriteLine("a2 b2 c2 | d2");
            Console.WriteLine("a3 b3 c3 | d3");
            Console.Write("a1 =");
            a1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("b1 =");
            b1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("c1 =");
            c1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("d1 =");
            d1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("a2 =");
            a2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("b2 =");
            b2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("c2 =");
            c2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("d2 =");
            d2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("a3 =");
            a3 = Convert.ToDouble(Console.ReadLine());
            Console.Write("b3 =");
            b3 = Convert.ToDouble(Console.ReadLine());
            Console.Write("c3 =");
            c3 = Convert.ToDouble(Console.ReadLine());
            Console.Write("d3 =");
            d3 = Convert.ToDouble(Console.ReadLine());
            delta = ((a1 * b2 * c3) + (a2 * b3 * c1) + (a3 * b1 * c2)) + (-(a3 * b2 * c1) - (a2 * b1 * c3) - (a1 * b3 * c2));
            delta1 = ((d1 * b2 * c3) + (d2 * b3 * c1) + (d3 * b1 * c2)) + (-(d3 * b2 * c1) - (d2 * b1 * c3) - (d1 * b3 * c2));
            delta2 = ((a1 * d2 * c3) + (a2 * d3 * c1) + (a3 * d1 * c2)) + (-(a3 * d2 * c1) - (a2 * d1 * c3) - (a1 * d3 * c2));
            delta3 = ((a1 * b2 * d3) + (a2 * b3 * d1) + (a3 * b1 * d2)) + (-(a3 * b2 * d1) - (a2 * b1 * d3) - (a1 * b3 * d2));
            x1 = delta1 / delta;
            x2 = delta2 / delta;
            x3 = delta3 / delta;
            Console.WriteLine("delta=" + delta);
            Console.WriteLine("delta1=" + delta1);
            Console.WriteLine("delta2=" + delta2);
            Console.WriteLine("delta3=" + delta3);
            Console.WriteLine("x1 =" + x1);
            Console.WriteLine("x2 =" + x2);
            Console.WriteLine("x3 =" + x3);
            Console.ReadLine();
        }
    }
}
