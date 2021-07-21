using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using XxlJob.Core.Biz.Model;
using XxlJob.Core.Handlers;

namespace XxlJob.Executor
{
    /// <summary>
    /// Job Handler基类
    /// </summary>
    public abstract class JobHandlerBase : IJobHandler, ITransientDependency
    {
        public virtual void Dispose() { }

        public abstract Task<ReturnT> Execute(JobExecuteContext context);
    }
}