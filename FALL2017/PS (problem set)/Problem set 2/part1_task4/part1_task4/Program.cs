using System;

namespace part1_task4
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = Double.Parse(Console.ReadLine());
            double e = Double.Parse(Console.ReadLine());

            Console.WriteLine(CountOfSteps(e, x));
            Console.ReadKey();
        }

        static int CountOfSteps(double e, double x)
        {
            double result = 0;
            double result1 = 1;
            int k = -1;s

            while (Math.Abs(result1 - result) > e)
            {
                result1 = result;
                k++;

                double power;
                if (k % 2 == 0)
                    power = 1;
                else
                    power = -1;

                double dividend = power * Math.Pow(x, 2*k);

                double divider = 1;
                for (int i = 1; i < 2*k; i++)
                {
                    divider *= i;
                }

                result += dividend / divider;
            }

            return k;
        }
    }
}
