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
            
            
            // var largestGroupFirst = from c in DB.Customers
            //                         group c by c.Country into g
            //                         let NumCustomers = g.Count()
            //                         orderby NumCustomers descending
            //                         select new {Country = g.Key, NumCustomers};

            var largestGroupFirst = 
                                    from g in
                                        from c in DB.Customers
                                        group c by c.Country
                                    let NumCustomers = g.Count()
                                    orderby NumCustomers descending
                                    select new {Country = g.Key, NumCustomers};

            var largestGroupFirst2 = 
                                    // from g in
                                    //     //from c in DB.Customers
                                    //     DB.Customers
                                    //     .GroupBy(c => c.Country)
                                    DB.Customers
                                    .GroupBy(c => c.Country)
                                    .Select(g => new {g, NumCustomers = g.Count()})
                                    .OrderByDescending(at => at.NumCustomers)
                                    .Select(at => new {Country = at.g.Key, at.NumCustomers}); 

            foreach (var result in largestGroupFirst)
            {
                Console.WriteLine(result);
            }
        }
    }
}
