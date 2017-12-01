using System;

namespace GeometryTasks
{
    class Vector
    {
        public double X;
        public double Y;
    }

    class Geometry
    {
        static double GetLenght(double x, double y)
        {
            return Math.Sqrt(x * x + y * y);
        }

        static double Add(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt((x1 + x2) * (x1 + x2) + (y1 + y2) * (y1 + y2));
        }
    }
}
