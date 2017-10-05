using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_World
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            Console.WriteLine("Say your name, please.");
            Console.WriteLine();
            name = Convert.ToString(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Hello , " + name + "!");
            Console.Read();
        }
    }
}
