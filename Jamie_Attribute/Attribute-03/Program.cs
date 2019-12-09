using System;


namespace Attribute_03
{

    class MeAttribute:Attribute
    {
        public MeAttribute(int nValue1, string strValue2)
        {
            Console.WriteLine("MeAttribute() executed");
            Console.WriteLine("nValue1: {0}", nValue1);
            Console.WriteLine("strValue2: {0}", strValue2);
        }

        public int someIntProperty {get; set;}
        public char someCharProperty {get;set;}
    }

    // [Me]
    [Me(25, "Jamie King")]
    class Program
    {
        static void Main(string[] args)
        {
            typeof(Program).GetCustomAttributes(false);
        }
    }
}
