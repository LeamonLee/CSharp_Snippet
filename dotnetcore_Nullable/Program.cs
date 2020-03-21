using System;

namespace dotnetcore_Nullable
{
    class Program
    {
        static void Main(string[] args)
        {
            int? i = null;
            double? d = 3.14;
            if (i.HasValue)
            {
                Console.WriteLine("i 的值为{0}", i);
            }
            else
            {
                Console.WriteLine("i 的值为空！");
            }
            if (d.HasValue)
            {
                Console.WriteLine("d 的值为{0}", d);
            }
            else
            {
                Console.WriteLine("d 的值为空！");
            }
        }
    }
}
