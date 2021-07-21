using System;

namespace XxlJob.Core.Biz.Model
{
    public class JobExecuteContext
    {
        public IServiceProvider ServiceProvider { get; }

        public Type JobType { get; }

        public int JobId { get; }

        public string JobParameter { get; }

        public IJobLogger JobLogger { get; }

        public JobExecuteContext(IServiceProvider serviceProvider, Type jobType,  IJobLogger jobLogger, int jobId, string jobParameter)
        {
            ServiceProvider = serviceProvider;
            JobType = jobType;
            JobLogger = jobLogger;
            JobId = jobId;
            JobParameter = jobParameter;
        }
    }
}
