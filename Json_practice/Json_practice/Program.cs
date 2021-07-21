using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

            // ===========================================

            string rootPath = Directory.GetCurrentDirectory();
            string filePath = Path.GetFullPath(Path.Combine(rootPath, @"test.json"));
            Console.WriteLine("{0}, {1}", rootPath, filePath); 
            JsonSerialize(student1, filePath);
            Student obj = JsonDeserialize(typeof(Student), filePath) as Student;

            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(obj);
                Console.WriteLine("{0}={1}", name, value);
            }

            // ===========================================

            JObject obj2 = (JObject)JToken.FromObject(student1);
            Console.WriteLine("obj2: {0}", obj2.ToString());

            Console.ReadKey();

            

        }

        public static void JsonSerialize(object data, string filePath)
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            if (File.Exists(filePath)) File.Delete(filePath);
            StreamWriter sw = new StreamWriter(filePath);
            JsonWriter jw = new JsonTextWriter(sw);

            jsonSerializer.Serialize(jw, data);
            jw.Close();
            sw.Close();
        }

        public static object JsonDeserialize(Type dataType, string filePath)
        {
            JObject obj = null;
            JsonSerializer jsonSerializer = new JsonSerializer();
            if (File.Exists(filePath))
            { 
                StreamReader sr = new StreamReader(filePath);
                JsonReader jr = new JsonTextReader(sr);

                obj = jsonSerializer.Deserialize(jr) as JObject;
                jr.Close();
                sr.Close();
            }
            return obj.ToObject(dataType);
        }
    }
}
