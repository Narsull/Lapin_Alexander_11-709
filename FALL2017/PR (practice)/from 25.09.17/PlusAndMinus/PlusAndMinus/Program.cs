using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusAndMinus
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[n];
            int plus = 0;
            int minus = 0;
            for (int a = 0; a != n; a++)
            {
                array[a] = Convert.ToInt32(Console.ReadLine());
                if (array[a] > 0)
                    plus = plus + 1;
                if (array[a] < 0)
                    minus = minus + 1;
            }
            if (plus > minus)
                Console.WriteLine("Положительных элементов больше отрицательных.");
            if (plus < minus)
                Console.WriteLine("Отрицательных элементов больше положительных.");
            if (plus == minus)
                Console.WriteLine("Количество положительных элементов равно количеству отрицательных.");
            Console.Read();
        }
    }
}
