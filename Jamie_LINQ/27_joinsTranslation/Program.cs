using System;
using System.Linq;

namespace _25_joins
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var results1 = 
                from c in DB.Customers
                join o in DB.Orders
                    on c.CustomerID equals o.CustomerID
                orderby c.ContactName
                select new {c.ContactName, o.OrderDate};
            
            var results2 = 
                // from c in DB.Customers
                DB.Customers.Join(DB.Orders, c => c.CustomerID, o => o.CustomerID, 
                                    (c, o) => new {c, o})
                            .OrderBy(tp => tp.c.ContactName)
                            .Select(tp => new {tp.c.ContactName, tp.o.OrderDate});
                
            foreach (var result in results2)
            {
                Console.WriteLine(result.ContactName + " " + result.OrderDate);
            }
        }
    }
}
