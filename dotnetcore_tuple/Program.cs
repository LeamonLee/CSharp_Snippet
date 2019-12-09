using System;

namespace C_Exercise
{
    class Program
    {
        
        static void Main(string[] args)
        {
            showEmpInfo();
            
        }

        public (string strName, int nAge) getEmpInfo(){
            return ("Leamon", 28);
        }

        public void showEmpInfo(){
            var info = getEmpInfo();
            Console.WriteLine($"{info.strName}, {info.nAge}");
        }
    }
}
