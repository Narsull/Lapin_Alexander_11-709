using System;

namespace from_09._10._17
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int count = 0;

            if (n >= 1 && n <= 27)
            {
                for (int a = 100; a < 1000; a++)
                {
                    string aString = Convert.ToString(a);
                    int number0 = Convert.ToInt32(aString.Substring(0, 1));
                    int number1 = Convert.ToInt32(aString.Substring(1, 1));
                    int number2 = Convert.ToInt32(aString.Substring(2, 1));

                    int amount = number0 + number1 + number2;
                    if (amount == n)
                        count++;
                }
                Console.WriteLine(count);
            }
            else Console.WriteLine("Error");
            Console.Read();
        }
    }
}
