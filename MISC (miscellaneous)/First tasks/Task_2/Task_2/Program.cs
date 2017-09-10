using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Double A;
            Double B;
            Double C;
            Console.WriteLine("Введите трёхзначное число");
            A = Convert.ToDouble(Console.ReadLine());
            B = A % 100;
            A = A - B;
            A = A / 100;
            C = B % 10;
            B = B - C;
            B = B / 10;
            A = C * 100 + B * 10 + A;
            Console.WriteLine(A);
            Console.Read();
        }
    }
}
