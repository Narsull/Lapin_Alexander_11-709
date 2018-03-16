using System;

/* Лапин Александр
 * Группа 11-709
 * Задание 16 из первой части вторых семистровок */

namespace part1_task16
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = Double.Parse(Console.ReadLine());
            double e = Double.Parse(Console.ReadLine());

            Console.WriteLine(CountOfSteps(x, e));
            Console.ReadKey();
        }

        static int CountOfSteps(double x, double e)
        {
            double result = 0;
            double result1 = 1;
            int n = -1;

            while (Math.Abs(result1 - result) > e)
            {
                result1 = result;
                n++;

                double divider = 1;
                for (int i = 1; i < 2 * n; i++)
                {
                    divider *= i;
                }

                double dividend;
                if (n != 0 && n != 1)
                    dividend = Math.Pow(x, n) * Math.Log(3, n);
                else
                    dividend = Math.Pow(x, n);

                result += dividend / divider;
            }

            return n;

        }
    }
}
