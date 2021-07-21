using System;

namespace XxlJob.Core
{
    public class Constants
    {
        public const string RpcRequestJavaFullName = "com.xxl.rpc.remoting.net.params.XxlRpcRequest";
        public const string RpcResponseJavaFullName = "com.xxl.rpc.remoting.net.params.XxlRpcResponse";

        public const string XxlJobRetryLogsFile = "xxl-job-retry.log";
        public const string HandleLogsDirectory = "JobHandler";

        public const string DefaultHttpClientName = "DotXxlJobHttpClient";

        public const int DefaultLogRetentionDays = 30;
        public static TimeSpan RpcRequestExpireTimeSpan = TimeSpan.FromMinutes(3);

        /// <summary>
        /// 自动注册间隔
        /// </summary>
        public static TimeSpan RegistryInterval = TimeSpan.FromSeconds(30);

        public const int MaxCallbackRetryTimes = 10;
        //每次回调最多发送几条记录
        public const int MaxCallbackRecordsPerRequest = 5;
        public static TimeSpan CallbackRetryInterval = TimeSpan.FromSeconds(600);

        //Admin集群中的某台机器熔断后间隔多长时间再重试
        public static TimeSpan AdminServerReconnectInterval = TimeSpan.FromMinutes(3);
        //Admin集群中的某台机器请求失败多少次后熔断
        public const int AdminServerCircuitFailedTimes = 3;

        public static class GlueType
        {
            public const string BEAN = "BEAN";
        }

        public static class ExecutorBlockStrategy
        {
            public const string SERIAL_EXECUTION = "SERIAL_EXECUTION";
            public const string DISCARD_LATER = "DISCARD_LATER";
            public const string COVER_EARLY = "COVER_EARLY";
        }
    }
}
