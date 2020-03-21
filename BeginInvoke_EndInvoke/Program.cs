using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BeginInvoke_EndInvoke
{
    public class Program
    {
        private delegate int NewTaskDelegate(int ms);
        private static void Completed_Callback(IAsyncResult asyncResult)
        {
            if (asyncResult == null) return;
            var result = (asyncResult.AsyncState as NewTaskDelegate).EndInvoke(asyncResult);
            Console.WriteLine("Completed_Callback Result: {0}", result);
        }

        private static int newTask(int ms)
		{
			Console.WriteLine("Task starts...");
			Thread.Sleep(ms);
			Random random = new Random();
			int n = random.Next(10000);
			Console.WriteLine("Task has Completed...");
			return n;
		}

        /*
            呼叫BeginInvoke方法時會建立一個執行緒來非同步執行newTask方法。
            如果不呼叫EndInvoke方法,程式會立即退出,這是由於使用BeginInvoke建立的執行緒都是後臺執行緒,
            這種執行緒一但所有的前臺執行緒都退出後(其中主執行緒就是一個前臺執行緒),
            不管後臺執行緒是否執行完畢,都會結束執行緒,並退出程式。
         */

		public static void Main(string[] args)
		{
			NewTaskDelegate task = newTask;
			// IAsyncResult asyncResult = task.BeginInvoke(2000, null, null);                   // Without Callback Method

            // 如果被呼叫的方法含有parameter的話,這些引數將作為BeginInvoke的前面一部分引數。
            // 如果沒有parameter, BeginInvoke就只需要傳兩個引數(Callback function, Delegate)。
            IAsyncResult asyncResult = task.BeginInvoke(3000, Completed_Callback, task);        // Pass a Callback Method
			Console.WriteLine("Main Thread EndInvoke Starts");

            // Check if it's completed Method1: 
            // 使用IAsyncResult asyncResult屬性來判斷非同步呼叫是否完成
            // while (!asyncResult.IsCompleted)
            // {
            //     Console.WriteLine("*** Main Thread waits for result ***");
            //     Thread.Sleep(100);
            // } // 由於非同步呼叫已經完成, 因此EndInvoke會立刻返回結果

            // Check if it's completed Method2:
            // 使用WaitOne方法等待非同步方法執行完成
            /*
            WaitOne的第一個引數表示要等待的毫秒數,在指定時間之內,WaitOne方法將一直等待,直到非同步呼叫完成並發出通知,WaitOne方法才返回true。
            當等待指定時間之後,非同步呼叫仍未完成,WaitOne方法返回false。
            如果指定時間為0,表示不等待。 如果為-1,表示永遠等待,直到非同步呼叫完成。
            */
            // while (!asyncResult.AsyncWaitHandle.WaitOne(100, false))
            // {
            //     Console.WriteLine("*** Main Thread waits for result ***");
            // }

            // int result = task.EndInvoke(asyncResult);	                // 如果方法尚未完成的話， EndInvoke方法會阻塞當前線程
			// Console.WriteLine("Main Thread EndInvoke has completed");
			// Console.WriteLine("Result: {0}", result);

            Console.ReadKey();
		}
    }
}
