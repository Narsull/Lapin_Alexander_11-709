using System;

namespace from_09._10._17
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int count = 0;

            if (n > 0 && n < 28)
            {
                for (int i = 100; i < 1000; i++)
                {
                    string iString = Convert.ToString(i);
                    int number0 = Convert.ToInt32(iString.Substring(0, 1));
                    int number1 = Convert.ToInt32(iString.Substring(1, 1));
                    int number2 = Convert.ToInt32(iString.Substring(2, 1));

                    if (number0 + number1 + number2 == n)
                        count++;
                }
                Console.WriteLine(count);
            }
            else Console.WriteLine("Error");
            Console.Read();
        }
    }
}