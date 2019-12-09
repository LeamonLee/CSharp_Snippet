using System;
using System.Linq;

namespace _25_joins
{
    class Program
    {
        static void Main(string[] args)
        {
            // Two from statement is not efficient. 
            var results = 
                from c in DB.Customers
                from o in DB.Orders
                where c.CustomerID == o.CustomerID
                select new {Customer = c, Order = o};
            
            foreach (var result in results)
            {
                Console.WriteLine(result.Customer.ContactName + " " + result.Order.OrderDate);
            }

            // =====================================

            var results2 = 
                from c in DB.Customers
                join o in DB.Orders
                on c.CustomerID equals o.CustomerID
                // select new {Customer = c, Order = o};
                select new {c.ContactName, o.OrderDate};
            
            var results3 = 
                // from c in DB.Customers
                DB.Customers.Join(DB.Orders, c => c.CustomerID, o => o.CustomerID, 
                                    (c, o) => new {c.ContactName, o.OrderDate});
                

            foreach (var result in results2)
            {
                Console.WriteLine(result.ContactName + " " + result.OrderDate);
            }
        }
    }
}
