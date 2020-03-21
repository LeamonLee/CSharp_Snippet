using System;
using System.Linq;
using System.Collections.Generic;


namespace _15_orderby
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = from c in DB.Customers
                            orderby c.Country descending, c.ContactName         // ascending is the default if you don't specify explicitly
                            select c;
            
            var result2 = DB.Customers
                            .OrderByDescending(c => c.Country)                  // There's no OrderByAscending. Just OrderBy. Because Ascending is assuming.
                            .ThenBy(c => c.ContactName);                        // Must put ThenBy instead of OrderBy if this is not the first OrderBy already
                            

            foreach (var item in result)
            {
                Console.WriteLine(c.Country + " " + c.ContactName);
            }

            // ===========================================

            var rand = new Random();
            var ContactNames = DB.Customers.OrderBy(c => rand.Next()).Select(c => c.ContactName);       // Everytime the order of the result will be different.
            foreach (var name in ContactNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
