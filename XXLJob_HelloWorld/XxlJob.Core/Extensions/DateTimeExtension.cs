using System;

namespace XxlJob.Core
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// UNIX开始时间
        /// </summary>
        private static DateTime ORIGINAL = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// DateTime -> UnixMilliseconds
        /// </summary>
        /// <param name="dateTime">DateTime对象</param>
        /// <returns>UnixMilliseconds</returns>
        public static long ToUnixMilliseconds(this DateTime dateTime)
        {
            TimeSpan diff = dateTime.ToUniversalTime() - ORIGINAL;
            return (long)diff.TotalMilliseconds;
        }

        /// <summary>
        /// UnixMilliseconds -> DateTime
        /// </summary>
        /// <param name="unixMilliseconds">UnixMilliseconds</param>
        /// <returns>DateTime对象</returns>
        public static DateTime UnixMillisecondsToDateTime(this long unixMilliseconds)
        {
            DateTime result = ORIGINAL.AddMilliseconds(unixMilliseconds);
            return result;
        }
    }
}
