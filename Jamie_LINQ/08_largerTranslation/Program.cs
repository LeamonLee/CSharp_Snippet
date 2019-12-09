using System;
using System.Linq;
using System.Collections.Generic;

namespace _07_degenerateSelect
{
    static class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new[]{2,4,9,4,2};
            var result1 = from n in numbers
                            orderby 8
                            where n < 5
                            where n > 0
                            where new Random().Next() == 23
                            orderby n
                            orderby n * 2 + 3
                            orderby 5
                            select n;
            
            var result2 = 
                            numbers
                            .OrderBy(n => 8) 
                            .Where(n => n < 5) 
                            .Where(n => n > 0) 
                            .Where(n => new Random().Next() == 23)
                            .OrderBy(n => n)
                            .OrderBy(n => n * 2 + 3) 
                            .OrderBy(n => 5)
                            .Select(n => n);
            
            var result3 = 
                        Enumerable.OrderBy(
                            Enumerable.OrderBy(
                                Enumerable.OrderBy(
                                    Enumerable.Where(
                                        Enumerable.Where(
                                            Enumerable.Where(
                                                Enumerable.OrderBy(numbers, n => 8) , 
                                                n => n < 5), 
                                            n => n > 0), 
                                        n => new Random().Next() == 23), 
                                    n => n), 
                                n => n * 2 + 3), 
                            n => 5);
                            

            foreach(var i in result1){
                Console.WriteLine(i);
            }
            Console.WriteLine("===============");

            foreach(var i in result2){
                Console.WriteLine(i);
            }
        }
    }
}
