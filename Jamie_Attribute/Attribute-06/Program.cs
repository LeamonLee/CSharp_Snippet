using System;


namespace Attribute_06
{
    // AttributeUsage 可以限制 此Attribute只能用在哪些地方
    // AllowMultiple allows the Attribute to be applied on the same tag more than once.
    // [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field, AllowMultiple=true)]
    [AttributeUsage(AttributeTargets.All, AllowMultiple=true)]
    class MeAttribute : Attribute
    {
        public MeAttribute()
		{
			Console.WriteLine("MeAttribute()");
		}
    }

    // [Me, Me] is the same syntax as the below one.
    [Me] // if AllowMultiple = true, then this behavior is valid.
    [Me]
    class Victim
    {
        [Me]
        public string MeField;
        [Me]
        public int MeProperty {[Me] get {return 5;}}
        [Me]
        public event Action meEvent;

        [Me]
        [return: Me]
        int MeMethod([Me] int meParameter)
        {
            return meParameter;
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            typeof(Victim).GetCustomAttributes(false);  // Should see the constructor of MeAttribute being called twice.
        }
    }
}
