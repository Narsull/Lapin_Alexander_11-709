using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[n];
            int max = 0;
            for (int a = 0; a != n; a++)
            {
                array[a] = Convert.ToInt32(Console.ReadLine());
                if (array[a] > max)
                    max = array[a];
            }
            Console.WriteLine(max);
            Console.Read();
        }
    }
}
