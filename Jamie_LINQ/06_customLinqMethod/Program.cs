using System;
using System.Linq;
using System.Collections.Generic;

namespace _05_Translation
{
    static class Program
    {
        static IEnumerable<int> Where(
            this int[] ints, Func<int, bool> predicate)
        {
            System.Console.WriteLine("My Where()");
            foreach (var i in ints)
            {
                if(predicate(i))
                    yield return i;
            }
        }

        static void Main(string[] args)
        {
            int[] numbers = new[]{2,4,9,4,2};
            var result1 = from n in numbers
                            where n < 5
                            select n;
            
            foreach(var i in result1){
                Console.WriteLine(i);
            }
            Console.WriteLine("===============");

            
        }
    }
}
