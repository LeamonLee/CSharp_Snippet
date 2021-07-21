using System;

namespace XxlJob.Executor
{
    public class DemoJobHandlerConfig : JobHandlerConfigBase
    {
        /// <summary>
        /// 开始时间，为空抓当前时间
        /// </summary>
        [JsonComment("开始时间，为空抓当前时间")]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 结束时间，为空抓当前时间
        /// </summary>
        [JsonComment("结束时间，为空抓当前时间")]
        public DateTime? EndTime { get; set; }
    }
}
