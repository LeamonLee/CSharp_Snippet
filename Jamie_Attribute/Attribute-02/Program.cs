using System;
using System.Reflection;
using System.Linq;

namespace Jamie_Attribute
{

    class TestAttribute : Attribute{}
    class TestMethodAttribute : Attribute{}

    //[Test]    Compilier will append Attribute for you.
    [TestAttribute]
    class MyTestSuite
    {
        public void HelperMethod()
        {
            // That helps out tests het their job done
        }

        [TestMethod]
        public void testFunc1()
        {
            HelperMethod();
            Console.WriteLine("Doing test1...");
        }

        [TestMethod]
        public void testFunc2()
        {
            HelperMethod();
            Console.WriteLine("Doing test2...");
        }
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
            {
                Console.WriteLine(t.Name);
                var testMethods =
                    from m in t.GetMethods()
                    where m.GetCustomAttributes(false).Any(a => a is TestMethodAttribute)
                    select m;
                
                object objTestSuite = Activator.CreateInstance(t);
                foreach (MethodInfo mInfo in testMethods)
                {
                    mInfo.Invoke(objTestSuite, new Object[0]);
                }
            }

        }
    }
}
