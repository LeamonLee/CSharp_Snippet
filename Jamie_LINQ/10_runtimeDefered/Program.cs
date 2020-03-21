using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_runtimeDefered
{
    class Program
    {
        static Random rand = new Random();
        static bool RandomBool
        {
            get {return rand.Next() % 2 == 0;}
        }
        static void Main(string[] args)
        {
            int[] numbers = {4,13,8,1,9};
            IEnumerable<int> result1 = numbers;

            // The Linq expression will be determined in runtime
            for (int idx = 0; idx < 3; idx++)
            {
                if(RandomBool)
                    result1 = result1.Where(i => i < 8);
                if(RandomBool)
                    result1 = result1.Where(i => i > 2);
                if(RandomBool)
                    result1 = result1.Select(i => i * 2);
                if(RandomBool)
                    result1 = result1.Select(i => i + 9);    
            }
            
            foreach (var item in result1)
            {
                Console.WriteLine(item);
            }

        }
    }
}
