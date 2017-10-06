using System;

namespace DistanceTask
{
    public static class DistanceTask
    {
        // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
        {
            double aPoint = Math.Sqrt(Math.Pow(x - ax, 2) + Math.Pow(y - ay, 2));
            double bPoint = Math.Sqrt(Math.Pow(x - bx, 2) + Math.Pow(y - by, 2));
            double ab = Math.Sqrt(Math.Pow(ax - bx, 2) + Math.Pow(ay - by, 2));

            double cosPoint = (Math.Pow(aPoint, 2) + Math.Pow(bPoint, 2) - Math.Pow(ab, 2)) / (2 * aPoint * bPoint);

            if ((ax - x) / (bx - x) == (ay - y) / (by - y) && (aPoint + bPoint == ab))
            {
                return 0;
            }
            else if (cosPoint > 0)
            {
                double perimeter = (aPoint + bPoint + ab) / 2;
                double square = Math.Sqrt((perimeter * (perimeter - aPoint) * (perimeter - bPoint) * (perimeter - ab)));
                return (2 * square) / ab;
            }
            else
            {
                return Math.Min(aPoint, bPoint);
            }
        }
    }
}