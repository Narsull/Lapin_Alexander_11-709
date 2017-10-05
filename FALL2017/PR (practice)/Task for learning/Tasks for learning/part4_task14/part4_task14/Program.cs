using System;

namespace part4_task14
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Convert.ToInt32(Console.ReadLine());
            int factorial = 1;

            for (int a = number; a != 1; a--)
            {
                factorial = factorial * a;
            }

            int lastNumber = factorial;

            for (int a = 10; lastNumber > 9; a *= 10)
            {
                lastNumber = lastNumber % a;
            }

            Console.WriteLine(factorial);
            Console.WriteLine(lastNumber);
            Console.Read();
        }
    }
}
