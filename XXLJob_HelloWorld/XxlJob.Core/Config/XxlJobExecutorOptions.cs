using System;
using System.IO;

namespace XxlJob.Core.Config
{
    public class XxlJobExecutorOptions
    {
        /// <summary>
        /// 管理端地址，多个以;分隔
        /// </summary>
        public string AdminAddresses { get; set; }

        /// <summary>
        /// appName自动注册时要去管理端配置一致
        /// </summary>
        public string AppName { get; set; } = "xxl-job-executor-netcore";

        /// <summary>
        /// 自动注册时提交的地址，为空会自动获取内网地址
        /// </summary>
        public string SpecialBindAddress { get; set; }

        /// <summary>
        /// 绑定端口
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 是否自动注册
        /// </summary>
        public bool AutoRegistry { get; set; }

        /// <summary>
        /// 认证票据
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 日志目录，默认为执行目录的Log子目录下，请配置绝对路径
        /// </summary>
        public string LogPath { get; set; } = Path.Combine(AppContext.BaseDirectory, "./Log");

        /// <summary>
        /// 日志保留天数
        /// </summary>
        public int LogRetentionDays { get; set; } = 30;

        /// <summary>
        /// 回调时间间隔 500毫秒
        /// </summary>
        public int CallBackInterval { get; set; } = 500; 
    }
}
