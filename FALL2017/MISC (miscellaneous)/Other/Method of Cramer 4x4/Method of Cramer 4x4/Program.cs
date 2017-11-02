using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method_of_Cramer_4x4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = Matrix();
        }

        static int[,] Matrix()
        {
            int[,] inputData = new int[5, 4];
            for (int a = 0; a < 5; a++)
            {
                for (int b = 0; b < 4; b++)
                {
                    inputData[a, b] = int.Parse(Console.ReadLine());
                }
            }
            return inputData;
        }


    }
}
