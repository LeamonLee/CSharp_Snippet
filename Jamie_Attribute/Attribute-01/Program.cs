using System;
using System.Reflection;
using System.Linq;

namespace Jamie_Attribute
{

    class TestAttribute : Attribute{}


    [TestAttribute]
    class MyTestSuite
    {
    }

    [TestAttribute]
    class YourTestSuite{}

    class Program
    {
        static void Main(string[] args)
        {

            var testSuites = 
                from t in Assembly.GetExecutingAssembly().GetTypes()
                where t.GetCustomAttributes(false).Any(a => a is TestAttribute)
                select t;

            foreach (var t in testSuites)
                Console.WriteLine(t.Name);
            

            System.Console.WriteLine("==================================");

            foreach (Type t in Assembly.GetExecutingAssembly().GetTypes())
            {
                Console.WriteLine(t.Name);
                foreach (Attribute a in t.GetCustomAttributes(false))
                {
                    if(a is TestAttribute)
                        System.Console.WriteLine("\t" + t.Name + " is a test Suite!");
                }
            }
        }
    }
}
