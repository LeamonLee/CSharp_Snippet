using Newtonsoft.Json;

namespace XxlJob.Core.Biz.Model
{
    public class ReturnT
    {
        public static readonly int SUCCESS_CODE = 200;
        public static readonly int FAIL_CODE = 500;

        public static readonly ReturnT SUCCESS = new ReturnT(null);
        public static readonly ReturnT FAIL = new ReturnT(FAIL_CODE, null);

        public ReturnT() { }

        public ReturnT(int code, string msg)
        {
            Code = code;
            Msg = msg;
        }

        public ReturnT(object content)
        {
            Code = SUCCESS_CODE;
            Content = content;
        }

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("msg")]
        public string Msg { get; set; }

        [JsonProperty("content")]
        public object Content { get; set; }

        public static ReturnT Failed(string msg)
        {
            return new ReturnT(FAIL_CODE, msg);
        }
        public static ReturnT Success(string msg)
        {
            return new ReturnT(SUCCESS_CODE, msg);
        }

        public override string ToString()
        {
            return $"ReturnT [code={Code},msg={Msg},content={Content}]";
        }
    }
}
