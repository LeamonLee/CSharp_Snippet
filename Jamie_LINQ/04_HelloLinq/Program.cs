using System;
using System.Linq;

namespace _04_HelloLinq
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] numbers = new int[] { 2, 4, 7, 1, 9, 2, 0, 3, 4, 2 };
            var result =
                from n in numbers
                where n < 5
                select n;
            
            foreach(var i in numbers)
                Console.WriteLine(i);

            // ====================================
			Console.WriteLine("===================");
			
            char[] chars = new[]{'c', 'p', 'o', 't', 'i'};
            var vowels = from c in chars
                        where c == 'a' || c=='e' || c=='i' ||
                                c =='o' || c == 'u'
                        select c;
            
            foreach(var i in vowels)
                Console.WriteLine(i);
        }
    }
}
