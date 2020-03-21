using System;
using System.Linq;

namespace _17_groupby
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // var result2 = from c in DB.Customers
            //                 group c by c.Country;

            // var largestGroupFirst = from g in result2
            //                             let NumCustomers = g.Count()
            //                             orderby NumCustomers descending
            //                             select new {Country = g.Key, NumCustomers};
            
            
            var largestGroupFirst = from c in DB.Customers
                                    group c by c.Country into g
                                    let NumCustomers = g.Count()
                                    orderby NumCustomers descending
                                    select new {Country = g.Key, NumCustomers};


            foreach (var result in largestGroupFirst)
            {
                Console.WriteLine(result);
            }
        }
    }
}
