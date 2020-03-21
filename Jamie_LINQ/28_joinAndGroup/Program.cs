using System;
using System.Linq;

namespace _28_joinAndGroup
{
    class Program
    {
        static void Main(string[] args)
        {
            var results = 
                    from c in DB.Customers
                    join o in DB.Orders
                        on c.CustomerID equals o.CustomerID
                    group o by c into g
                    let NumOrders = g.Count()
                    orderby NumOrders descending
                    select new {g.key.ContactName, NumOrders};

            foreach (var result in results)
            {
                Console.WriteLine(result.ContactName + ": " + result.NumOrders);
            }
        }
    }
}
