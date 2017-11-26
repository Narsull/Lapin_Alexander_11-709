using System;

/* Лапин Александр
 * Группа 11-709
 * Задание 11 из первой части вторых семистровок */

namespace part1_task11
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = Double.Parse(Console.ReadLine());
            if (Math.Abs(x) <= 1)
            {
                double e = Double.Parse(Console.ReadLine());

                Console.WriteLine(CountOfSteps(e, x));
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Error");
                Console.ReadKey();
            }
        }

        static int CountOfSteps(double e, double x)
        {
            double result = 0;
            double result1 = 1;
            int k = -1;

            while (Math.Abs(result1 - result) > e)
            {
                result1 = result;
                k++;

                result += Dividend(k, x) / Divider(k, x);
            }

            return k;
        }

        static double Dividend(double k, double x)
        {
            double firstElement;
            if (k % 2 == 0)
                firstElement = 1;
            else firstElement = -1;

            double secondElement = 1;
            for (int i = 1; i < 2 * k; i++)
            {
                secondElement *= i;
            }

            double thirdElement = Math.Pow(x, k);

            return firstElement * secondElement * thirdElement;
        }

        static double Divider(double k, double x)
        {
            double firstElement = 1 - 2 * k;

            double secondElement = 1;
            for (int i = 1; i < k; i++)
            {
                secondElement *= i;
            }
            secondElement = Math.Pow(secondElement, 2);

            double thirdElement = Math.Pow(4, k);

            return firstElement * secondElement * thirdElement;
        }
    }
}
