using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percents
{
    class Program
    {
        public static double Calculate(string userInput)
        {
            double[] amount = userInput.Split().Select(double.Parse).ToArray();
            double contribution = amount[0], percent = amount[1], time = amount[2];
            for (int a = 0; a < time; a++)
                contribution += contribution * ((percent / 12) / 100);
            return contribution;
        }
        static void Main(string[] args)
        {
            string userInput = Console.ReadLine();
            Console.WriteLine(Calculate(userInput));
            Console.ReadLine();
        }

    }
}
