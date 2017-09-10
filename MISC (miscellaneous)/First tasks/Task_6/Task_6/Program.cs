using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Double x1;
            Double x2;
            Double y1;
            Double y2;
            Double XY;
            Console.WriteLine("Напишите координаты двух точек");
            Console.WriteLine();
            Console.Write("x1=");
            x1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("y1=");
            y1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("x2=");
            x2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("y2=");
            y2 = Convert.ToDouble(Console.ReadLine());

            {
                XY = Math.Sqrt(((x1 - x2) * (x1 - x2)) + ((y1 - y2) * (y1 - y2)));
                Console.WriteLine("Расстояние между точками равно " + XY);
                Console.ReadLine();

            }
        }
    }
        }
