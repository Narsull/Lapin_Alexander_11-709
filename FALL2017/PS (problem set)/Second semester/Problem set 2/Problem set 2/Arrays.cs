using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Problem_set_2
{
    class Arrays
    {
        static public void Generation()
        {
            Random random = new Random();

            int lenght = random.Next(51, 99);
            string[][] firstArray = new string[lenght][];

            for (int i = 0; i < lenght; i++)
            {
                firstArray[i] = new string[random.Next(101, 9999)];
            }

            for (int i = 0; i < lenght; i++)
                for (int j = 0; j < firstArray[i].Length; j++)
                {
                    firstArray[i][j] = random.Next().ToString();
                }

            string[] secondArray = new string[lenght];
            for (int i = 0; i < lenght; i++)
            {
                secondArray[i] = string.Join(" ", firstArray[i]);
            }
            string array = string.Join("\n", secondArray);

            File.Create("C:\\arrays.txt").Close();
            File.AppendAllText("C:\\arrays.txt", array);
        }

        static public int[][] ReadingToArray()
        {
            string[] arraysString = File.ReadAllLines("C:\\arrays.txt");
            int length = arraysString.Length;
            int[][] arraysInt = new int[length][];
            for (int i = 0; i < length; i++)
            {
                string[] arrayString = arraysString[i].Split(' ');
                arraysInt[i] = new int[arrayString.Length];
                for (int j = 0; j < arrayString.Length; j++)
                {
                    arraysInt[i][j] = Convert.ToInt32(arrayString[j]);
                }
            }
            return arraysInt;
        }

        static public int[] RandomArray(int length)
        {
            Random random = new Random();
            int[] array = new int[length];

            for (int i = 0; i < length; i++)
            {
                array[i] = random.Next();
            }

            return array;
        }
    }
}
