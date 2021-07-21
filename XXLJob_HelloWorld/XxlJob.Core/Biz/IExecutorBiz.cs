using XxlJob.Core.Biz.Model;

namespace XxlJob.Core.Biz
{
    public interface IExecutorBiz
    {
        /// <summary>
        /// 心跳检测
        /// </summary>
        /// <returns></returns>
        ReturnT Beat();

        /// <summary>
        /// 忙碌检测
        /// </summary>
        /// <param name="idleBeatParam"></param>
        /// <returns></returns>
        ReturnT IdleBeat(IdleBeatParam idleBeatParam);

        /// <summary>
        /// 触发任务
        /// </summary>
        /// <param name="triggerParam"></param>
        /// <returns></returns>
        ReturnT Run(TriggerParam triggerParam);

        /// <summary>
        /// 终止任务
        /// </summary>
        /// <param name="killParam"></param>
        /// <returns></returns>
        ReturnT Kill(KillParam killParam);

        /// <summary>
        /// 查看执行日志
        /// </summary>
        /// <param name="logParam"></param>
        /// <returns></returns>
        ReturnT Log(LogParam logParam);
    }
}
