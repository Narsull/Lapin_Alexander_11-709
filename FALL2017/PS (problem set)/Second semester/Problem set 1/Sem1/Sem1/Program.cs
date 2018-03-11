using System;
using System.Collections;
using System.Collections.Generic;

namespace Sem1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList2 list = new MyLinkedList2();
            list.Insert(6);
            list.Insert(13);
            list.Insert(13);
            list.Insert(7);
            list.Insert(13);
            list.Delete(4);
            foreach (int e in list)
                Console.WriteLine(e);
            Console.WriteLine(list.MaxNum());
            Console.ReadKey();
        }

        class Node
        {
            public Node(int value)
            {
                Value = value;
                Previous = null;
                Next = null;
            }

            public Node(int value, Node node)
            {
                Value = value;
                node.Next = this;
                Previous = node;
            }

            public Node Previous { get; set; }
            public Node Next { get; set; }
            public int Value { get; set; }
        }

        class MyLinkedList2 : IEnumerable
        {
            private Node foot;

            public int Count { get; private set; }

            public MyLinkedList2() { }

            public void Insert(int value) // Вставка элемента в конец списка.
            {
                if (foot == null)
                    foot = new Node(value);
                else
                    foot = new Node(value, foot);
                Count++;
            }

            public void Delete(int index) // Удаление i-ого элемента.
            {
                Check(index);
                if (Count > 1)
                {
                    if (index == Count - 1)
                    {
                        foot = foot.Previous;
                        foot.Next = null;
                    }
                    else
                    {
                        Node node = GetNode(index);
                        if (index == 0)
                            node.Next.Previous = null;
                        else
                        {
                            node.Previous.Next = node.Next;
                            node.Next.Previous = node.Previous;
                        }
                    }
                    Count--;
                }
                else
                    Clear();
            }

            public void Clear() // Очистка списка.
            {
                foot = null;
                Count = 0;
            }

            public int MaxNum() // Число максимально повторяющихся чисел.
            {
                int maxCount = 0;
                for (int i = 0; i < Count; i++)
                {
                    int count = 0;
                    for (int j = 0; j < Count; j++)
                    {
                        if (GetNode(i).Value == GetNode(j).Value)
                            count++;
                    }
                    if (count > maxCount)
                        maxCount = count;
                }
                return maxCount;
            }

            public List<int>[] Divide() // Разделение списка на два. В первом кратные 3, во втором остальные.
            {
                Node node = foot;
                List<int>[] lists = new List<int>[2];
                lists[0] = new List<int>();
                lists[1] = new List<int>();
                for (int i = Count; i > -1; i--)
                {
                    if (node.Value % 3 == 0)
                        lists[0].Add(node.Value);
                    else lists[1].Add(node.Value);
                    node = node.Previous;
                }
                if (lists[0] == null)
                    throw new Exception("Нет чисел кратных трём.");
                else
                    return lists;
            }

            private void Check(int index) // Проверка на существование элемента.
            {
                if (index < 0 || index >= Count)
                    throw new Exception("Выход за границы списка.");
            }

            private Node GetNode(int index) // Получение Node i-ого элемента.
            {
                Check(index);
                Node node = foot;
                for (int i = 0, count = Count - index - 1; i < count; i++)
                    node = node.Previous;
                return node;
            }

            public int this[int index] // Позволяет обращаться к i-ому элементу через квадратные скобки.
            {
                get { return GetNode(index).Value; }
                set { GetNode(index).Value = value; }
            }

            public IEnumerator GetEnumerator() // Позволяет использовать foreach в списке.
            {
                if (Count == 0)
                    yield break;
                Node node = GetNode(0);
                for (; node != null; node = node.Next)
                    yield return node.Value;
            }
        }
    }
}