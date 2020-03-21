using System;
using System.Collections.Generic;
using System.Linq;

namespace _14_projections
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = from c in DB.Customers
                            select new {c.ContactName, c.CompanyName};
            
            foreach (var item in result)
            {
                Console.WriteLine(item.ContactName);
            }
        }
    }
}
