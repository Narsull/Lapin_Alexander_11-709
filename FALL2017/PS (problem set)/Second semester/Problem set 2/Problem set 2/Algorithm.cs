using System;
using System.Collections.Generic;

namespace Problem_set_2
{
    class Algorithm
    {
        static int Iterations;

        static public void StoogeSort(List<int> list, int left, int right)
        {
            Iterations = 1;
            if (list[left] > list[right])
            {
                list[left] = list[left] + list[right];
                list[right] = list[left] - list[right];
                list[left] = list[left] - list[right];
                Iterations = Iterations + 3;
            }

            Iterations++;
            if (left + 1 >= right)
            {
                Console.WriteLine("{0} - {1}", list.Count, Iterations);
                return;
            }

            else
            {
                int third = (right - left + 1) / 3;
                StoogeSort(list, left, right - third);
                StoogeSort(list, left + third, right);
                StoogeSort(list, left, right - third);
                Iterations = Iterations + 4;
            }
        }

        static public void StoogeSort(int[] array, int left, int right)
        {
            if (array[left] > array[right])
            {
                array[left] = array[left] + array[right];
                array[right] = array[left] - array[right];
                array[left] = array[left] - array[right];
            }

            if (left + 1 >= right)
                return;
            else
            {
                int third = (right - left + 1) / 3;
                StoogeSort(array, left, right - third);
                StoogeSort(array, left + third, right);
                StoogeSort(array, left, right - third);
            }
        }
    }
}
