using Newtonsoft.Json;

namespace XxlJob.Core.Biz.Model
{
    public class KillParam
    {
        /// <summary>
        /// 任务ID
        /// </summary>
        [JsonProperty("jobId")]
        public int JobId { get; set; }

        public KillParam() { }

        public KillParam(int jobId)
        {
            JobId = jobId;
        }
    }
}
