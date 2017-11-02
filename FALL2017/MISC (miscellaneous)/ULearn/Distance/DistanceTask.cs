using System;

namespace DistanceTask
{
    public static class DistanceTask
    {
        // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
        {
            double ak = Math.Sqrt((x - ax) * (x - ax) + (y - ay) * (y - ay));
            double kb = Math.Sqrt((x - bx) * (x - bx) + (y - by) * (y - by));
            double ab = Math.Sqrt((ax - bx) * (ax - bx) + (ay - by) * (ay - by));

            double ScalarA = (x - ax) * (bx - ax) + (y - ay) * (by - ay);
            double ScalarB = (x - bx) * (-bx + ax) + (y - by) * (-by + ay);

            if (ab == 0)
                return ak;
            else if (ScalarA >= 0 && ScalarB >= 0)
            {
                double p = (ak + kb + ab) / 2.0;
                double s = Math.Sqrt(Math.Abs((p * (p - ak) * (p - kb) * (p - ab))));
                return (2.0 * s) / ab;
            }
            else if (ScalarA < 0 || ScalarB < 0)
            {
                return Math.Min(ak, kb);
            }
            else return 0;
        }
    }
}

