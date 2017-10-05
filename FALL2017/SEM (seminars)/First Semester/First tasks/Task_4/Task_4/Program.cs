using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expr4
{
    class Program
    {
        static void Main(string[] args)
        {
            Double N;
            Double X;
            Double Y;
            Double K;
            Console.Write("N =");
            N = Convert.ToDouble(Console.ReadLine());
            Console.Write("X =");
            X = Convert.ToDouble(Console.ReadLine());
            Console.Write("Y =");
            Y = Convert.ToDouble(Console.ReadLine());
            K = (N - 1) / Y + (N - 1)/X - (N - 1) / (Y * X);
            Console.Write(K);
            Console.ReadLine();
        }
    }
}
