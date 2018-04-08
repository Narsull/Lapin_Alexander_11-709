using System;
using System.Collections.Generic;

namespace Problem_set_2
{
    class Algorithm
    {
        static public void StoogeSort(List<int> list, int left, int right)
        {
            if (list[left] > list[right])
            {
                list[left] = list[left] + list[right];
                list[right] = list[left] - list[right];
                list[left] = list[left] - list[right];
            }

            if (left + 1 >= right)
                return;
            else
            {
                int third = (right - left + 1) / 3;
                StoogeSort(list, left, right - third);
                StoogeSort(list, left + third, right);
                StoogeSort(list, left, right - third);
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

        static public void StoogeSort(LinkedList<int> linkedList, int left, int right)
        {
            int length = linkedList.Count;
            int[] array = new int[length];
            linkedList.CopyTo(array, 0);
            linkedList.Clear();
            StoogeSort(array, left, right);
            foreach (int e in array)
                linkedList.AddLast(e);
        }
    }
}
