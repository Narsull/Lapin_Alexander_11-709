// Вариант 1
// 11-709 
// Лапин Александр

using System;
using System.Linq;
using System.Collections.Generic;

namespace ControlTask
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public IEnumerable<string> FirstTask(int k, int a, List<string> array)
        {
            var firstArray = array.Select((item, index) => new { Item = item, Index = index })
                     .Where(n => n.Index % 2 != 0)
                     .Take(k)
                     .Select(n => n.Item);

            var secondArray = array.Select((item, index) => new { Item = item, Index = index })
                     .Where(n => n.Index % 2 == 0)
                     .Skip(k)
                     .Select(n => n.Item);

            var result = firstArray.Union(secondArray).Reverse();

            return result;
        }

        public int ThirdTask()
        {
            return 0;
        }
    }

    static class Dekart
    {
        static IEnumerable<IEnumerable<T>> SecondTask<T>(this IEnumerable<IEnumerable<T>> sequences)
        {
            IEnumerable<IEnumerable<T>> result = new[] { Enumerable.Empty<T>() };

            foreach (var sequence in sequences)
            {
                var s = sequence;
                result =
                  from r in result
                  from item in s
                  select r.Concat(new[] { item });
            }

            return result;
        }
    }
}
