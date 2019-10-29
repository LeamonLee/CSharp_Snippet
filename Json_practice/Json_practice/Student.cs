using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json_practice
{
    public class Student
    {
        public int nId { get; set; }
        public string strName { get; set; }
        public string strDegree { get; set; }
        public List<string> Hobbies { get; set; }

        public override string ToString()
        {
            return string.Format("Studnet Information:\n\t Id:{0}\n\t, Name:{1}\n\t, Degree:{2}\n\t, " +
                "Hobbies: {3}", nId, strName, strDegree, string.Join(",", Hobbies.ToArray())
            );
        }
    }
}
