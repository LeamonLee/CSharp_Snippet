using System;
using System.Linq;

namespace _17_groupby
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var result2 = DB.Customers.GroupBy(c => c.Country);

            var largestGroupFirst = from g in result2
                                        let NumCustomers = g.Count()
                                        orderby NumCustomers descending
                                        select new {Country = g.Key, NumCustomers};
            
            var largestGroupFirst2 = // from g in result2
                                        result2
                                        .Select(g => new{g, NumCustomers = g.Count()})
                                        .OrderByDescending(at => at.NumCustomers)                   // at means anonymous type
                                        .Select(at => new {Country = at.g.Key, at.NumCustomers});

            foreach (var result in largestGroupFirst)
            {
                Console.WriteLine(result);
            }
        }
    }
}
