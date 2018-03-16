using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massive
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[n];
            int amount = 0;
            for (int a = 0; a != n; a++)
            {
                array[a] = Convert.ToInt32(Console.ReadLine());
                amount = amount + array[a];
            }
            Console.WriteLine(amount);
            Console.Read();
        }
    }
}
