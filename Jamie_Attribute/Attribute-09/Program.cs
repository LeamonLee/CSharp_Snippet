#define DEBUGGING
using System;
using System.Diagnostics;

namespace Attribute_09
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TraceDebugging("We're debugging here");
        }

        // If we did #define DEBUGGING, then TraceDebugging function is able to use. 
        // Otherwise, Compiler will vaporize the calling site of this function.
        [Conditional("DEBUGGING")]
        static void TraceDebugging(string message)
        {
            Console.WriteLine("Debugging: " + message);
        }
    }
}
