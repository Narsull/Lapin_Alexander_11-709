using System;

namespace part1_task11
{
    class Program
    {
        static void Main(string[] args)
        {
            double e = Double.Parse(Console.ReadLine());

            Console.WriteLine(16 * Arctg(e, 1.0 / 5.0) - 4 * Arctg(e, 1.0 / 239.0));
            Console.ReadKey();
        }

        static double Arctg(double e, double x)
        {
            double result = 0;
            double result1 = 1;
            int k = 0;

            while (Math.Abs(result1 - result) > e)
            {
                result1 = result;
                k++;

                double dividend;
                if ((k - 1) % 2 == 0)
                    dividend = Math.Pow(x, 2 * k - 1);
                else
                    dividend = -Math.Pow(x, 2 * k - 1);

                result += dividend / (2 * k - 1);
            }

            return result;
        }
    }
}
