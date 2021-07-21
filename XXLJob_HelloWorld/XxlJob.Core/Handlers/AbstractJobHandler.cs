using System.Threading.Tasks;
using XxlJob.Core.Biz.Model;

namespace XxlJob.Core.Handlers
{
    public abstract class AbstractJobHandler : IJobHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public abstract Task<ReturnT> Execute(JobExecuteContext context);

        public virtual void Dispose()
        {
        }
    }
}
