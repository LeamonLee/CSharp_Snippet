using System;

namespace Attribute_07
{
    // Inherited option can prevent the class which uses this Attribute from letting its children inherit it.
    [AttributeUsage(AttributeTargets.All, Inherited=false)]
    class MeAttribute : Attribute
    {
        public MeAttribute()
		{
			Console.WriteLine("MeAttribute()");
		}
    }
    class Me2Attribute : Attribute
    {
        public Me2Attribute()
		{
			Console.WriteLine("Me2Attribute()");
		}
    }

    [Me]
    class Base{}
    [Me2]
    class Derived : Base {}

    class Program
    {
        static void Main(string[] args)
        {
            typeof(Derived).GetCustomAttributes(false).P();
            typeof(Derived).GetCustomAttributes(true).P();

            // If you want to know if the attribute is there instead of instantiaing it, use IsDefined()
            typeof(Derived).IsDefined(typeof(MeAttribute), true).P();
            typeof(Derived).IsDefined(typeof(MeAttribute), false).P();
        }
    }
}
