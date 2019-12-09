using System;
using System.Linq;

namespace _05_Translation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new[]{2,4,9,4,2};
            var result1 = from n in numbers
                            where n < 5
                            select n;
            
            var result2 = //from n in numbers
                            numbers
                            .Where(n => n < 5) 
                            .Select(n => n);
            
            var result3 = 
                            Enumerable.Select(
                                Enumerable.Where(numbers, n => n < 5),
                                n => n);

            foreach(var i in result1){
                Console.WriteLine(i);
            }
            Console.WriteLine("===============");

            foreach(var i in result2){
                Console.WriteLine(i);
            }
            Console.WriteLine("===============");

            foreach(var i in result3){
                Console.WriteLine(i);
            }
        }
    }
}
