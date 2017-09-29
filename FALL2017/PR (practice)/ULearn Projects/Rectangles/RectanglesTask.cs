using System;

namespace Rectangles
{
    public static class RectanglesTask
    {
        // Пересекаются ли прямоугольники
        public static bool AreIntersected(Rectangle r1, Rectangle r2)
        {
            bool a = (r1.Right >= r2.Left && r1.Left <= r2.Right && r1.Top <= r2.Bottom && r1.Bottom >= r2.Top);
            bool b = (r1.Left >= r2.Right && r1.Right <= r2.Bottom && r1.Bottom <= r2.Top && r1.Top >= r2.Bottom);
            return (a || b);
        }
        // Площадь пересечения прямоугольников
        public static int IntersectionSquare(Rectangle r1, Rectangle r2)
        {
            int square;
            int x1 = Math.Max(Math.Min(r1.Right, r1.Left), Math.Min(r2.Right, r2.Left));
            int x2 = Math.Min(Math.Max(r1.Right, r1.Left), Math.Max(r2.Right, r2.Left));
            int y1 = Math.Max(Math.Min(r1.Top, r1.Bottom), Math.Min(r2.Top, r2.Bottom));
            int y2 = Math.Min(Math.Max(r1.Top, r1.Bottom), Math.Max(r2.Top, r2.Bottom));
            if (x2 - x1 > 0 && y2 - y1 > 0)
            {
                square = (x2 - x1) * (y2 - y1);
            }
            else
                square = 0;
            return square;

        }
        // Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
        // Иначе вернуть -1
        // Если прямоугольники совпадают, можно вернуть номер любого из них.
        public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
        {
            if (r1.Right <= r2.Right && r1.Left >= r2.Left && r1.Top >= r2.Top && r1.Bottom <= r2.Bottom)
            {
                return 0;
            }
            else if (r2.Right <= r1.Right && r2.Left >= r1.Left && r2.Top >= r1.Top && r2.Bottom <= r1.Bottom)
            {
                return 1;
            }
            else return -1;
        }

    }
}