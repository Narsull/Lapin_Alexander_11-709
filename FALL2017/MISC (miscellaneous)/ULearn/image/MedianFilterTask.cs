using System.Collections.Generic;

namespace Recognizer
{
    internal static class MedianFilterTask
    {
        public static double[,] MedianFilter(double[,] original)
        {
            int xLenght = original.GetLength(0);
            int yLenght = original.GetLength(1);
            double[,] medianFilter = new double[xLenght, yLenght];

            for (int x = 0; x < xLenght; x++)
                for (int y = 0; y < yLenght; y++)
                {
                    List<double> pixel = new List<double>();

                    for (int i = -1; i < 2; i++)
                        for (int j = -1; j < 2; j++)
                        {
                            if (x + i != xLenght && x + i != -1 && y + j != yLenght && y + j != -1)
                                pixel.Add(original[x + i, y + j]);
                        }

                    pixel.Sort();

                    if (pixel.Count % 2 == 1)
                        medianFilter[x, y] = pixel[pixel.Count / 2];
                    else
                        medianFilter[x, y] = (pixel[pixel.Count / 2] + pixel[pixel.Count / 2 - 1]) / 2;
                }

            return medianFilter;
        }
    }
}