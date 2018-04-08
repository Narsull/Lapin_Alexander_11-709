using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Problem_set_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Arrays.RandomArray(8321);
            Stopwatch stopwatch = Stopwatch.StartNew();
            Algorithm.StoogeSort(array, 0, 8320);
            stopwatch.Stop();
            Console.WriteLine("8321 " + stopwatch.ElapsedMilliseconds);
            Console.Read();
        }
    }
}
