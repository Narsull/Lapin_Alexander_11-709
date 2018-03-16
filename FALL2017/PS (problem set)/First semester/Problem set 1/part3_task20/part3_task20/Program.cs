/* Лапин Александр
 * Группа 11-709
 * Задание 20 из третьей части первых семистровок */

using System;

namespace part3_task20
{
    class Program
    {
        static void Main(string[] args)
        {
            int amount2 = 0;
            int amount1 = 0;
            int i = 1;
            int i2 = 0;
            int i1 = 0;
            Console.WriteLine("Введите последовательность чисел.");
            for (int a = 1; i != 0; a++)
            {
                i = Convert.ToInt32(Console.ReadLine());
                if (i != 0)
                {
                    if (i % 2 == 0)

                    {
                        amount2 = amount2 + i;
                        i2 = i2 + 1;
                    }
                    else
                    {
                        amount1 = amount1 + i;
                        i1 = i1 + 1;
                    }
                }
            }
            if (i1 >= i2)
            {
                if (i1 > i2)
                {
                    Console.WriteLine("Сумма нечётных чисел равна " + amount1);
                }
                else
                {
                    Console.WriteLine("Ошибка.");
                    Console.WriteLine("Количество введённых чётных и нечётных чисел равно между собой или равно нулю.");
                }
            }
            else Console.WriteLine("Сумма чётных чисел равна " + amount2);
            Console.Read();
        }
    }
}

