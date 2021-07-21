using System;
using XxlJob.Core.Biz.Model;

namespace XxlJob.Core.Biz.Impl
{
    public class ExecutorBizImpl : IExecutorBiz
    {
        private readonly JobDispatcher _jobDispatcher;
        private readonly IJobLogger _jobLogger;

        public ExecutorBizImpl(
            JobDispatcher jobDispatcher,
            IJobLogger jobLogger)
        {
            _jobDispatcher = jobDispatcher;
            _jobLogger = jobLogger;
        }

        public ReturnT Beat()
        {
            return ReturnT.SUCCESS;
        }

        public ReturnT IdleBeat(IdleBeatParam idleBeatParam)
        {
            return _jobDispatcher.IdleBeat(idleBeatParam.JobId);
        }

        public ReturnT Kill(KillParam killParam)
        {
            return _jobDispatcher.TryRemoveJobTask(killParam.JobId) ?
                ReturnT.SUCCESS : ReturnT.Success("job thread already killed.");
        }

        public ReturnT Log(LogParam logParam)
        {
            LogResult logResult = _jobLogger.ReadLog(logParam.LogDateTim, logParam.LogId, logParam.FromLineNum);
            return new ReturnT(logResult);
        }

        public ReturnT Run(TriggerParam triggerParam)
        {
            var result = _jobDispatcher.Execute(triggerParam);
            Console.WriteLine("ExecutorBizImpl: " + result);
            return result;
        }
    }
}
