using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_Exer
{
    class Program
    {
        static void Main(string[] args)
        {
            //var t1 = new Task(() => Func1(1,3000));
            //t1.Start();

            //var t2 = new Task(() => Func1(2, 2000));
            //t2.Start();

            //var t3 = new Task(() => Func1(3, 1000));
            //t3.Start();

            // ======================================

            //var t1 = Task.Factory.StartNew(() => Func1(1, 3000));
            //var t2 = Task.Factory.StartNew(() => Func1(2, 2000));
            //var t3 = Task.Factory.StartNew(() => Func1(3, 1000));

            // ======================================

            //var t1 = Task.Factory.StartNew(() => Func1(1, 1000)).ContinueWith((prevTask) => Func2(1, 2000));

            // ======================================

            //var t1 = Task.Factory.StartNew(() => Func1(1, 3000));
            //var t2 = Task.Factory.StartNew(() => Func1(2, 2000));
            //var t3 = Task.Factory.StartNew(() => Func1(3, 1000));

            //var taskList = new List<Task> { t1, t2, t3 };
            //Task.WaitAll(taskList.ToArray());

            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine("Main Thread is doing work {0}", i);
            //    Thread.Sleep(500);
            //}

            // ======================================

            //var intList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

            //Parallel.ForEach(intList, (i) => Console.WriteLine(i)); // Blocking operation
            //Console.WriteLine("===================");
            //Parallel.For(0, 10, (i) => Console.WriteLine(i));

            // ======================================

            var cts = new CancellationTokenSource();
            try
            {
                var t1 = Task.Factory.StartNew(() => Func1(1, 1000)).ContinueWith((prevTask) => Func3(1, 2000, cts.Token));

                Thread.Sleep(500);
                // Some error happened
                cts.Cancel();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType());
                
            }

            

            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
        }

        static void Func1(int id, int sleepTime)
        {
            Console.WriteLine("task{0} is beginning", id);
            Thread.Sleep(sleepTime);
            Console.WriteLine("task{0} has completed", id);
        }

        static void Func2(int id, int sleepTime)
        {
            Console.WriteLine("task{0} is beginning Func2", id);
            Thread.Sleep(sleepTime);
            Console.WriteLine("task{0} has completed Func2", id);
        }

        static void Func3(int id, int sleepTime, CancellationToken cToken)
        {
            if (cToken.IsCancellationRequested)
            {
                Console.WriteLine("Cancellation requested");
                cToken.ThrowIfCancellationRequested();
            }

            Console.WriteLine("task{0} is beginning Func2", id);
            Thread.Sleep(sleepTime);
            Console.WriteLine("task{0} has completed Func2", id);
        }
    }
}
