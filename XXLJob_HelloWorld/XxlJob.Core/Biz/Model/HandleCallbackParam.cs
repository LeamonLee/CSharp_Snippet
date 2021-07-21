using Newtonsoft.Json;

namespace XxlJob.Core.Biz.Model
{
    public class HandleCallbackParam
    {
        /// <summary>
        /// 本次调度日志ID
        /// </summary>
        [JsonProperty("logId")]
        public long LogId { get; set; }

        /// <summary>
        /// 本次调度日志时间
        /// </summary>
        [JsonProperty("logDateTime")]
        public long LogDateTime { get; set; }

        /// <summary>
        /// 200 表示任务执行正常，500表示失败
        /// </summary>
        [JsonProperty("executeResult")]
        public ReturnT ExecuteResult { get; set; }

        [JsonProperty("callbackRetryTimes")]
        public int CallbackRetryTimes { get; set; }

        public HandleCallbackParam() { }

        public HandleCallbackParam(TriggerParam triggerParam, ReturnT executeResult)
        {
            LogId = triggerParam.LogId;
            LogDateTime = triggerParam.LogDateTime;
            ExecuteResult = executeResult;
        }

        public HandleCallbackParam(long logId, long logDateTime, ReturnT executeResult)
        {
            LogId = logId;
            LogDateTime = logDateTime;
            ExecuteResult = executeResult;
        }

        public override string ToString()
        {
            return "HandleCallbackParam{" +
                "logId=" + LogId +
                ", logDateTime=" + LogDateTime +
                ", executeResult=" + ExecuteResult +
                '}';
        }
    }
}
