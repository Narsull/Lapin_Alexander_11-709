using System;

namespace part3_task14
{
    class Program
    { 
        static void Main(string[] args)
        {
            Console.WriteLine(LeftRectangles(0, 1.2, 100));
            Console.WriteLine(RightRectangles(0, 1.2, 100));
            Console.WriteLine(Trapezoid(0, 1.2, 30));
            Console.WriteLine(Simpson(0, 1.2, 12));
            Console.WriteLine(MonteCarlo(0, 1.2, 999999));
            Console.ReadKey();
        }

        public static double Function(double x)
        {
            return Math.Sin(Math.Tan(x));
        }

        public static double LeftRectangles(double a, double b, int n)
        {
            double step = (b - a) / n;
            double result = 0;

            for (int i = 0; i < n; i++)
                result += Function(a + step * i);
            return result * step;
        }

        public static double RightRectangles(double a, double b, int n)
        {
            double step = (b - a) / n;
            double result = 0;

            for (int i = 1; i <= n; i++)
                result += Function(a + step * i);
            return result * step;
        }

        public static double Trapezoid(double a, double b, double n)
        {
            double step = (b - a) / n;
            double result = 0;

            for (int i = 1; i < n; i++)
                result += Function(a + step * i);
            result += (Function(a) + Function(b)) / 2;
            return result * step;
        }

        public static double Simpson(double a, double b, double n)
        {
            double evenIndex = 0;
            double oddIndex = 0;
            double result = 0;
            double step = (b - a) / (2 * n);

            for (int i = 1; i < 2 * n; i++)
            {
                if (i % 2 == 0)
                    evenIndex += Function(a + step * i);
                else
                    oddIndex += Function(a + step * i);
            }
            result += Function(a) + Function(b);
            return (step / 3) * (result + 2 * evenIndex + 4 * oddIndex);
        }

        public static double MonteCarlo(double a, double b, int n)
        {
            double result = 0;
            double x;
            int y = 0;

            for (int i = 0; i < n; i++)
            {
                x = GetRandom(a, b);
                {
                    if (x <= b && x >= a)
                    {
                        result += Function(x);
                        y++;
                    }
                }
            }
            return (result / y) * (b - a);
        }

        public static double GetRandom(double b, double a)
        {
            Random random = new Random();
            return a + (b - a) * random.NextDouble();
        }
    }
}
