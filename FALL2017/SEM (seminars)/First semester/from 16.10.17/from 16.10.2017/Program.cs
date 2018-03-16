using System;

namespace from_16._10._2017
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Maximum(number));
            Console.WriteLine();

            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            int c = Convert.ToInt32(Console.ReadLine());
            Numbers(a, b, c);
            Console.WriteLine();

            Table();

            Console.Read();
        }

        public static int Maximum(int number)
        {
            int max = 0;
            string numberString = Convert.ToString(number);
            char[] numberChar = new char[numberString.Length];

            for (int i = 0; i < numberString.Length; i++)
            {
                int a = Convert.ToInt32(numberChar[i]);
                if (a > max)
                    max = a;
            }
            return max;
        }

        public static void Numbers(int a, int b, int c)
        {
            int number = c - a;
            while (number < b)
            {
                number = number + a;
                Console.WriteLine(number);
            }
        }

        public static void Table()
        {
            for (int a = 1; a < 10; a++)
            {
                for (int b = 1; b < 10; b++)
                {
                    Console.Write(a * b + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
