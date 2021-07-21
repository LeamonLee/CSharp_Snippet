using System;
using System.Threading.Tasks;
using XxlJob.Core.Biz.Model;

namespace XxlJob.Core.Handlers
{
    public interface IJobHandler : IDisposable
    {
        Task<ReturnT> Execute(JobExecuteContext context);
    }
}
