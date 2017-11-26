using System.Collections.Generic;
using System;

namespace Recognizer
{
    public static class ThresholdFilterTask
    {
        public static double[,] ThresholdFilter(double[,] original, double threshold)
        {
            List<double> listOfPixels = new List<double>();
            int xLenght = original.GetLength(0);
            int yLenght = original.GetLength(1);
            int n = original.Length;

            for (int i = 0; i < n; i++)
                listOfPixels.Add(original[i % xLenght, i % yLenght]);

            listOfPixels.Sort();

            int whitePixels = (int)(threshold * n);

            double t;
            if (whitePixels == 0)
                t = double.MaxValue;
            else
                t = listOfPixels[Math.Max(n - whitePixels, 0)];

            double[,] thresholdFilterArray = new double[xLenght, yLenght];

            for (int x = 0; x < xLenght; x++)
                for (int y = 0; y < yLenght; y++)
                {
                    if (original[x, y] >= t)
                    {
                        thresholdFilterArray[x, y] = 1;
                    }
                    else
                        thresholdFilterArray[x, y] = 0;
                }

            return thresholdFilterArray;
        }
    }
}