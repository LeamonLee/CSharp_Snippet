using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Closure
{
    class Program
    {
        static void Main(string[] args)
        {
            Action a = giveMeAction();
            Action b = giveMeAction();
            a(); b(); a(); a(); b();

            Console.ReadKey();
        }

        static Action giveMeAction()
        {
            Action actRet = null;
            int i = 2;
            int j = 3;
            actRet += () => i++;
            actRet += () => j++;
            actRet += () => { i++; j++; };

            return actRet;
        }
    }
}
