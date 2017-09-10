using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Double Chas;
            Double Gradus;
            Console.WriteLine("Введите час");
            Chas = Convert.ToDouble(Console.ReadLine());
            if (Chas > 12)
            {
                Chas = Chas - 12;
            }
            Gradus = Chas * 30;
            if (Gradus > 360)
                {
                Gradus = Gradus - 360;
            }
            if (Chas % 12 == 0)
            {
                Gradus = 0;
            }
            Console.WriteLine("Угол между минутной и часовой стрелками равен " + Gradus);
            Console.Read();
        }
    }
}
