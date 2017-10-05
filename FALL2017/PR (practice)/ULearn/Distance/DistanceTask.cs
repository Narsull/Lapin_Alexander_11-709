using System;

namespace DistanceTask
{
    public static class DistanceTask
    {
        // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
        {
            double aPoint = Math.Sqrt(((x - ax) * (x - ax)) + ((y - ay) * (y - ay)));
            double bPoint = Math.Sqrt(((x - bx) * (x - bx)) + ((y - by) * (y - by)));
            double ab = Math.Sqrt(((ax - bx) * (ax - bx)) + ((ay - by) * (ay - by)));
            double a = Math.Acos((Math.Pow(bPoint, 2) - Math.Pow(aPoint, 2) + Math.Pow(ab, 2)) / (2 * aPoint * bPoint));
            double b = Math.Acos((Math.Pow(aPoint, 2) - Math.Pow(bPoint, 2) + Math.Pow(ab, 2)) / (2 * aPoint * ab));
            double point = Math.Acos((Math.Pow(aPoint, 2) - Math.Pow(bPoint, 2) + Math.Pow(ab, 2)) / (2 * aPoint * ab));
            if (((x - ax) * (by - ay) - (y - ay) * (bx - ax) == 0) && (ax < x && x < bx) || (bx < x && x < ax))
            {
                return 0;
            }
            else if ( && ab != 0)
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