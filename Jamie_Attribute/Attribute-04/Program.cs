using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Attribute_04
{

    [Serializable]
    class Cow
    {
        public string Name;
        public int Weight;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var besty = new Cow {Name = "Besty" , Weight=500};
            var formatter = new BinaryFormatter();
            var memoryStream = new MemoryStream();
            formatter.Serialize(memoryStream, besty);
            memoryStream.Seek(0, SeekOrigin.Begin);
            var bestyClone = formatter.Deserialize(memoryStream) as Cow;
            Console.WriteLine("bestyClone.Name: {0}", bestyClone.Name);
            Console.WriteLine("bestyClone.Weight: {0}", bestyClone.Weight);
        }
    }
}
