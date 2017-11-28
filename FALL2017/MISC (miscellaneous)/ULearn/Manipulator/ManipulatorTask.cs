using System;
namespace Manipulation
{
    public static class ManipulatorTask
    {
        static double xc = 0;
        static double yc = 0;
        public static double GetABAngle(double a, double b, double c)
        {
            if (CheckSides(a, b, c) < 0)
                return double.NaN;
            else
            {
                double angle = (Math.Pow(a, 2) + Math.Pow(b, 2) - Math.Pow(c, 2)) / (2 * a * b);
                return Math.Acos(angle);
            }
        }
        public static int CheckSides(double a, double b, double c)
        {
            if (b <= 0 || a <= 0 || c < 0 || (a > b + c) || (b > c + a) || (c > a + b) || (a == 0 && b == 0 && c == 0))
                return -1;
            else
                return 1;
        }
        public static double[] MoveManipulator(double x, double y, double angle)
        {
            double[] temp = new double[3];
            double elbow = CalculateElbow(x, y, angle);
            double shoulder = CalculateShoulder();
            double wrist = CalculateWrist(angle, elbow, shoulder);

            temp = new[] { shoulder, elbow, wrist };
            return temp;
        }
        public static double CalculateElbow(double x, double y, double angle)
        {
            double ac = CalculateShoulderWrist(x, y, angle);
            double elbow = GetABAngle(Manipulator.UpperArm, Manipulator.Forearm, ac);
            double[] i = GetPoints(0, 0, Manipulator.UpperArm, xc, yc, Manipulator.Forearm);
            if ((i[0] >= 0 && i[1] >= 0) || (i[0] <= 0 && i[1] <= 0))
                return elbow;
            return -elbow;
        }
        public static double CalculateShoulderWrist(double x, double y, double angle)
        {
            if (x >= 0)
                xc = x - Math.Abs(Manipulator.Palm * Math.Cos(angle));
            else
                xc = x + Math.Abs(Manipulator.Palm * Math.Cos(angle));
            if (y >= 0)
                yc = Math.Abs(y) - Math.Abs(Manipulator.Palm * Math.Sin(angle));
            else
                yc = y + Math.Abs(Manipulator.Palm * Math.Sin(angle));
            if ((xc < 1e-12 && xc > 0) || (xc > -1e-12 && xc < 0)) xc = 0;
            if ((yc < 1e-12 && yc > 0) || (yc > -1e-12 && yc < 0)) yc = 0;

            return Math.Sqrt(Math.Pow(xc, 2) + Math.Pow(yc, 2));
        }
        public static double CalculateShoulder()
        {
            double[] i = GetPoints(0, 0, Manipulator.UpperArm, xc, yc, Manipulator.Forearm);
            double shoulder = Math.Acos(i[0] / Math.Sqrt(i[0] * i[0] + i[1] * i[1]));
            if (yc < 0)
                shoulder *= -1;
            return shoulder;
        }
        public static double[] GetPoints(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double d = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
            double a = (z1 * z1 - z2 * z2 + d * d) / (2 * d);
            double h = Math.Sqrt(Math.Pow(z1, 2) - Math.Pow(a, 2));
            double x0 = x1 + a * (x2 - x1) / d;
            double y0 = y1 + a * (y2 - y1) / d;
            double x20 = x0 + h * (y2 - y1) / d;
            double y20 = y0 - h * (x2 - x1) / d;
            if (a == z1)
                return new double[] { x20, y20 };
            double x10 = x0 - h * (y2 - y1) / d;
            double y10 = y0 + h * (x2 - x1) / d;
            if (x20 + y20 > x10 + y10)
                return new double[] { x20, y20 };
            else if (x20 + y20 < x10 + y10)
                return new double[] { x10, y10 };
            else
                return new double[] { Math.Min(x20, x10), Math.Max(y10, y20) };
        }
        public static double CalculateWrist(double angle, double elbow, double shoulder)
        {
            double wrist = -angle - elbow - shoulder;
            if (wrist >= -Math.PI - 1e-11 && wrist <= Math.PI + 1e-11)
                return wrist;
            wrist = wrist % Math.PI;
            double d = Math.Abs(Math.Abs(wrist) - Math.Abs(Math.PI));
            if ((wrist < 1e-12 && wrist > 0) || (wrist > -1e-12 && wrist < 0)) wrist = 0;
            else if (wrist < 0 && d > 1e-9)
                wrist = wrist + Math.PI;
            else if (wrist > 0 && d > 1e-9)
                wrist = wrist - Math.PI;
            return wrist;
        }
    }
}