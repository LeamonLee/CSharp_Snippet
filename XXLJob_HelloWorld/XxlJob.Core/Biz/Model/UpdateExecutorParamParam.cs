using Newtonsoft.Json;

namespace XxlJob.Core.Biz.Model
{
    public class UpdateExecutorParamParam
    {
        /// <summary>
        /// 任务ID
        /// </summary>
        [JsonProperty("jobId")]
        public int JobId { get; set; }

        /// <summary>
        /// 任务参数
        /// </summary>
        [JsonProperty("executorParams")]
        public string ExecutorParams { get; set; }

        public override string ToString()
        {
            return "UpdateExecutorParamParam{" +
                "jobId=" + JobId +
                ", executorParams='" + ExecutorParams + '\'' +
                '}';
        }
    }
}
