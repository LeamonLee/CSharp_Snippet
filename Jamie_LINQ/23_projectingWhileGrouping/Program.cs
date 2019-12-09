using System;
using System.Linq;

namespace _23_projectingWhileGrouping
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = from c in DB.Customers
                            group c.ContactName by new {c.Country, c.City};
            
            var result2 = //from c in DB.Customers
                            DB.Customers
                            .GroupBy(c => new {c.Country, c.City}, c => c.ContactName);

            foreach (var group in result2)
            {
                Console.WriteLine(group.Key + ":");
                foreach (string contactName in group)           // Because the selectName is contactName, the type is string
                {
                    Console.WriteLine("\t" + contactName);
                }
            }
        }
    }
}
