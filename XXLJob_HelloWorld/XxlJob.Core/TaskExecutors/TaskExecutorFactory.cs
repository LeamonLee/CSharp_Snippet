using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace XxlJob.Core.TaskExecutors
{
    /// <summary>
    /// 负责响应RPC请求，调度任务执行器的工厂类
    /// </summary>
    public class TaskExecutorFactory
    {
        private readonly IServiceProvider _provider;

        private readonly Dictionary<string, ITaskExecutor> _cache = new Dictionary<string, ITaskExecutor>();
        public TaskExecutorFactory(IServiceProvider provider)
        {
            _provider = provider;
            Initialize();
        }

        private void Initialize()
        {
            var executors = this._provider.GetServices<ITaskExecutor>();

            var taskExecutors = executors as ITaskExecutor[] ?? executors.ToArray();
            if (executors == null || !taskExecutors.Any()) return;

            foreach (var item in taskExecutors)
            {
                _cache.Add(item.GlueType, item);
            }
        }

        public ITaskExecutor GetTaskExecutor(string glueType)
        {
            return _cache.TryGetValue(glueType, out var executor) ? executor : null;
        }
    }
}
