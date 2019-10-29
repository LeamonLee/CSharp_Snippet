using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protected
{
    class Program
    {
        class BaseTest

        {

            public int a = 10;

            protected int b = 2;

            public void printTest()

            {

                Console.WriteLine(this.b);

            }

        }



        class ChildTest : BaseTest

        {

            int c;

            int d;



            public void printTest()
            {

                BaseTest basetest = new BaseTest();

                this.a = basetest.a;
                this.b = 50;

                //this.c = basetest.b;              // This will throw an error
                Console.WriteLine(this.b);

            }
        }

            static void Main(string[] args)
        {
            BaseTest basetest = new BaseTest();

            ChildTest childTest = new ChildTest();

            //Console.WriteLine(childTest.b);         // This will also throw an error
            basetest.printTest();
            childTest.printTest();

            Console.ReadKey();

        }
    }
}
