using System;

namespace DistanceTask
{
    public static class DistanceTask
    {
        // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
        {
            double distance = 1;
            double aPoint = Math.Sqrt(((x - ax) * (x - ax)) + ((y - ay) * (y - ay)));
            double bPoint = Math.Sqrt(((x - bx) * (x - bx)) + ((y - by) * (y - by)));
            double ab = Math.Sqrt(((ax - bx) * (ax - bx)) + ((ay - by) * (ay - by)));
            if (ax == bx)
            {
                if (((y >= by) && (y <= by)) || ((y <= ay) && (y >= by)))
                {
                    distance = 0;
                }
            }
            else
            {
                double a = (ay - by) / (ax - bx);
                double b = ((ay + by) - a * (ax + bx)) / 2;
                if (((y == a * x + b) && (x > ax) && (x < bx)) || ((y == a * x + b) && (bx > ax) && (x < ax)))
                    distance = 0;
            }
            if (distance != 0)
            {
                if (x <= bx && x >= ax && ab != 0)
                {
                    double perimeter = (aPoint + bPoint + ab) / 2;
                    double square = Math.Sqrt((perimeter * (perimeter - aPoint) * (perimeter - bPoint) * (perimeter - ab)));
                    distance = (2 * square) / ab;
                }
                else
                {
                    distance = Math.Min(aPoint, bPoint);
                }
            }
            return distance;
        }
    }
}