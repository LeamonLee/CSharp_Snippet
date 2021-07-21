using System;
using XxlJob.Core.Biz.Model;

namespace XxlJob.Core
{
    public interface IJobLogger
    {

        void SetLogFile(long logTime, long logId);

        void Log(string pattern, params object[] format);

        void LogError(Exception ex);

        LogResult ReadLog(long logTime, long logId, int fromLine);

        void LogSpecialFile(long logTime, long logId, string pattern, params object[] format);
    }
}
