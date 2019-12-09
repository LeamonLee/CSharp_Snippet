using System;

namespace _22_groupbyMultipleFields
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = from c in DB.Customers
                            orderby c.Country, c.City
                            group c by new {c.Country, c.City};     // group multiple fields by using anonymous class
            
            foreach (var countryCityGroup in result)
            {
                Console.WriteLine(countryCityGroup.Key + ":");
                foreach (Customer c in countryCityGroup)
                    Console.WriteLine("\t" + c.ContactName);
            }
        }
    }
}
