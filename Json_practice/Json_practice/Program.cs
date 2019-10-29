using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student()
            {
                nId = 1,
                strName = "Leamon",
                strDegree = "Bachelor",
                Hobbies = new List<string>()
                {
                    "C#",
                    "Python"
                }
            };

            string strResultJson = JsonConvert.SerializeObject(student1);
            File.WriteAllText(@"student.json", strResultJson);
            Console.WriteLine("strResultJson: {0}", strResultJson);

            // ===========================================

            strResultJson = String.Empty;
            strResultJson = File.ReadAllText(@"student.json");
            Student resultStudent = JsonConvert.DeserializeObject<Student>(strResultJson);
            Console.WriteLine("resultStudent: {0}", resultStudent.ToString());

            // ===========================================

            strResultJson = String.Empty;
            strResultJson = File.ReadAllText(@"student.json");
            var resultDictionary = JsonConvert.DeserializeObject<IDictionary>(strResultJson);
            foreach (DictionaryEntry entry in resultDictionary)
            {
                Console.WriteLine(entry.Key + ":" + entry.Value);
            }

            Console.ReadKey();



        }
    }
}
