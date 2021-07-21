using System.Collections.Concurrent;
using System.Collections.Generic;

namespace XxlJob.Core
{
    public static class QueueExtensions
    {
        public static int DequeueAll<T>(this ConcurrentQueue<T> concurrentQueue, List<T> list)
        {
            list = new List<T>();
            if (concurrentQueue != null)
            {
                while (concurrentQueue.Count > 0)
                {
                    if(concurrentQueue.TryDequeue(out var result))
                    {
                        list.Add(result);
                    }
                }
            }

            return list.Count;
        }
    }
}
