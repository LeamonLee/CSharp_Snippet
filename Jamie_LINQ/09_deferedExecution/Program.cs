using System;
using System.Linq;
using System.Collections.Generic;

namespace _07_degenerateSelect
{
    static class Program
    {

        static IEnumerable<T> Where<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            Console.WriteLine("My Where()");
            foreach (T item in items)
            {
                if(predicate(item))
                    yield return item;
            }
        }

        static IEnumerable<R> Select<T, R>(this IEnumerable<T> items, Func<T, R> transform)
        {
            Console.WriteLine("My Select()");
            foreach (T item in items)
            {
                yield return transform(item);
            }
        }

        public static void Main(string[] args)
        {
            int[] numbers = new[]{2,4,9,4,2, 8};
            IEnumerable<int> result =
                from i in numbers
                where i < 5
                select i + 6;
            
            Console.WriteLine("So far we haven't get any data because we haven't consume it.");

            IEnumerator<int> rator = result.GetEnumerator();
            while(rator.MoveNext())
                Console.WriteLine(rator.Current);
            
            Console.WriteLine("Now we get the datas.");

            // ==========================================

            IEnumerable<string> result2 = numbers
                                            .Where(i => i < 10).Where(i => i > 4).Select(i => i * 3)
                                            .Where(i => i % 2 == 0).Select(i => i + "Jamie");
            IEnumerator<string> rator2 = result2.GetEnumerator();
            while(rator2.MoveNext())
                Console.WriteLine(rator2.Current);
        }
    }
}
