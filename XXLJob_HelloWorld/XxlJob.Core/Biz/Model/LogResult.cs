using Newtonsoft.Json;

namespace XxlJob.Core.Biz.Model
{
    public class LogResult
    {
        /// <summary>
        /// 日志开始行号
        /// </summary>
        [JsonProperty("fromLineNum")]
        public int FromLineNum { get; set; }

        /// <summary>
        /// 日志结束行号
        /// </summary>
        [JsonProperty("toLineNum")]
        public int ToLineNum { get; set; }

        /// <summary>
        /// 日志内容
        /// </summary>
        [JsonProperty("logContent")]
        public string LogContent { get; set; }

        /// <summary>
        /// 是否结束
        /// </summary>
        [JsonProperty("isEnd")]
        public bool IsEnd { get; set; }

        public LogResult() { }

        public LogResult(int fromLineNum, int toLineNum, string logContent, bool isEnd)
        {
            FromLineNum = fromLineNum;
            ToLineNum = toLineNum;
            LogContent = logContent;
            IsEnd = isEnd;
        }
    }
}
