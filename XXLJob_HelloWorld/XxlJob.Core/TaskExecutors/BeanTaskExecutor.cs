using System;
using System.Threading.Tasks;
using XxlJob.Core.Biz.Model;
using XxlJob.Core.Handlers;

namespace XxlJob.Core.TaskExecutors
{
    /// <summary>
    /// 实现 IJobHandler的执行器
    /// </summary>
    public class BeanTaskExecutor : ITaskExecutor
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IJobHandlerFactory _handlerFactory;
        private readonly IJobLogger _jobLogger;

        public BeanTaskExecutor(
            IServiceProvider serviceProvider, 
            IJobHandlerFactory handlerFactory, 
            IJobLogger jobLogger)
        {
            _serviceProvider = serviceProvider;
            _handlerFactory = handlerFactory;
            _jobLogger = jobLogger;
        }

        public string GlueType { get; } = Constants.GlueType.BEAN;

        public Task<ReturnT> Execute(TriggerParam triggerParam)
        {
            var handler = _handlerFactory.GetJobHandler(triggerParam.ExecutorHandler);

            if (handler == null)
            {
                return Task.FromResult(ReturnT.Failed($"job handler [{triggerParam.ExecutorHandler} not found."));
            }
            var context = new JobExecuteContext(_serviceProvider, handler.GetType(), _jobLogger, triggerParam.JobId, triggerParam.ExecutorParams);
            return handler.Execute(context);
        }
    }
}
