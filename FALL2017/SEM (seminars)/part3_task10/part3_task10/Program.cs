using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part3_task10
{
    class Program
    {
        static void Main(string[] args)
        {
            Double x = Convert.ToDouble(Console.Read());
            Double y = Convert.ToDouble(Console.Read());
            Double z = 2 * x * 134 * y - Math.Pow(x, 2);
            Console.WriteLine(z);
        }
    }
}
