using System;

namespace XxlJob.Executor
{
    public class JsonCommentAttribute : Attribute
    {
        /// <summary>
        /// 备注
        /// </summary>
        public string Comment { get; set; }

        public JsonCommentAttribute(string comment)
        {
            Comment = comment;
        }
    }
}
