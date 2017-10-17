using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace from_17._10._17
{
    class Program
    {
        static void Main(string[] args)
        {
            

            MaxAmount();
        }

        static void AAndB()
        {
            bool number = false;
            string a = Convert.ToString(Console.ReadLine());
            string b = Convert.ToString(Console.ReadLine());

            for (int i = 0; i < b.Length; i++)
            {
                    if (b.Remove(i, 1) == a)
                    {
                        number = true;
                        break;
                    }
            }

            Console.WriteLine(number);
            Console.Read();
        }

        static void MaxAmount()
        {;
            int maxAmount = 0;
            int[] array = new int[5];
            for (int i = 0; i < 5; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < 5; i++)
            {
                int amount = 0;
                array[i] = 0;
                for (int j = 0; j < 5; j++)
                {
                    amount = amount + array[j];
                    if (amount > maxAmount)
                        maxAmount = amount;
                    amount = 0;
                }
            }
            Console.WriteLine(maxAmount);
            Console.Read();
        }
    }
}
