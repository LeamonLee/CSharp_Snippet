using Newtonsoft.Json;

namespace XxlJob.Core.Biz.Model
{
    public class IdleBeatParam
    {
        /// <summary>
        /// 任务ID
        /// </summary>
        [JsonProperty("jobId")]
        public int JobId { get; set; }

        public IdleBeatParam() { }

        public IdleBeatParam(int jobId)
        {
            JobId = jobId;
        }
    }
}
