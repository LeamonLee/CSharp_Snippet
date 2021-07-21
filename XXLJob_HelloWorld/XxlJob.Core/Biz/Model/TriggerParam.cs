using Newtonsoft.Json;

namespace XxlJob.Core.Biz.Model
{
    public class TriggerParam
    {
        /// <summary>
        /// Job ID
        /// </summary>
        [JsonProperty("jobId")]
        public int JobId { get; set; }

        /// <summary>
        /// Job Handler名称
        /// </summary>
        [JsonProperty("executorHandler")]
        public string ExecutorHandler { get; set; }

        /// <summary>
        /// 任务参数
        /// </summary>
        [JsonProperty("executorParams")]
        public string ExecutorParams { get; set; }

        /// <summary>
        /// 阻塞策略
        /// </summary>
        [JsonProperty("executorBlockStrategy")]
        public string ExecutorBlockStrategy { get; set; }

        /// <summary>
        /// 超时时间
        /// </summary>
        [JsonProperty("executorTimeout")]
        public int ExecutorTimeout { get; set; }

        /// <summary>
        /// 任务日志ID
        /// </summary>
        [JsonProperty("logId")]
        public long LogId { get; set; }

        /// <summary>
        /// 任务调度时间
        /// </summary>
        [JsonProperty("logDateTime")]
        public long LogDateTime { get; set; }

        [JsonProperty("glueType")]
        public string GlueType { get; set; }

        [JsonProperty("glueSource")]
        public string GlueSource { get; set; }

        [JsonProperty("glueUpdatetime")]
        public long GlueUpdatetime { get; set; }

        [JsonProperty("broadcastIndex")]
        public int BroadcastIndex { get; set; }

        [JsonProperty("broadcastTotal")]
        public int BroadcastTotal { get; set; }

        public override string ToString()
        {
            return "TriggerParam{" +
                "jobId=" + JobId +
                ", executorHandler='" + ExecutorHandler + '\'' +
                ", executorParams='" + ExecutorParams + '\'' +
                ", executorBlockStrategy='" + ExecutorBlockStrategy + '\'' +
                ", executorTimeout=" + ExecutorTimeout +
                ", logId=" + LogId +
                ", logDateTime=" + LogDateTime +
                ", glueType='" + GlueType + '\'' +
                ", glueSource='" + GlueSource + '\'' +
                ", glueUpdatetime=" + GlueUpdatetime +
                ", broadcastIndex=" + BroadcastIndex +
                ", broadcastTotal=" + BroadcastTotal +
                '}';
        }
    }
}
