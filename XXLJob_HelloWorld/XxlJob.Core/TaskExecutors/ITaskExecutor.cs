using System.Threading.Tasks;
using XxlJob.Core.Biz.Model;

namespace XxlJob.Core.TaskExecutors
{
    public interface ITaskExecutor
    {
        string GlueType { get; }

        Task<ReturnT> Execute(TriggerParam triggerParam);
    }
}
