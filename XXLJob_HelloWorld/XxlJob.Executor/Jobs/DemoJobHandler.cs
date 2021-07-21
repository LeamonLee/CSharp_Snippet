using System.Threading.Tasks;
using XxlJob.Core;
using XxlJob.Core.Biz.Model;

namespace XxlJob.Executor
{
    /// <summary>
    /// 示例Job，只是写个日志
    /// </summary>
    [JobHandler("demoJobHandler")]
    public class DemoJobHandler : JobHandlerBase
    {
        public override Task<ReturnT> Execute(JobExecuteContext context)
        {
            context.JobLogger.Log("111111111111111111receive demo job handler,parameter:{0}", context.JobParameter);

            return Task.FromResult(ReturnT.SUCCESS);
        }
    }
}