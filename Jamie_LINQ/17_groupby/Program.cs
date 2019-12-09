using System;
using System.Linq;

namespace _17_groupby
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = from c in DB.Customers
                            group c by c.Country;
            
            var result2 = DB.Customers.GroupBy(c => c.Country);

            // Because the key is the Country name, and the type of country name is string
            // The Eeement is Customer because "from c in DB.Customers", c is Customer
            foreach (IGrouping<string, Customer> group in result)
            {
                Console.WriteLine(group.Key + ":");
                foreach (Customer c in group)
                {
                    Console.WriteLine("   " + c.ContactName);
                }
                Console.WriteLine();
            }

            // ===============================================

            var largestGroupFirst = from g in result2
                                        orderby g.Count() descending
                                        select new {Country = g.Key, NumCustomers = g.Count()};
            
            foreach (var result in largestGroupFirst)
            {
                Console.WriteLine(result);
            }
        }
    }
}
