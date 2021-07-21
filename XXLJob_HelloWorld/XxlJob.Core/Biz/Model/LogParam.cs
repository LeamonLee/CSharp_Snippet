using Newtonsoft.Json;

namespace XxlJob.Core.Biz.Model
{
    public class LogParam
    {
        /// <summary>
        /// 本次调度日志时间
        /// </summary>
        [JsonProperty("logDateTim")]
        public long LogDateTim { get; set; }

        /// <summary>
        /// 本次调度日志ID
        /// </summary>
        [JsonProperty("logId")]
        public long LogId { get; set; }

        /// <summary>
        /// 日志开始行号，滚动加载日志
        /// </summary>
        [JsonProperty("fromLineNum")]
        public int FromLineNum { get; set; }

        public LogParam() { }

        public LogParam(long logDateTime, long logId, int fromLineNum)
        {
            LogDateTim = logDateTime;
            LogId = logId;
            FromLineNum = fromLineNum;
        }
    }
}
