using System;

namespace TimezoneConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
            DateTime datetime = new DateTime();
            DateTime tokyo = TimeZoneInfo.ConvertTimeFromUtc(datetime, tzi);
            Console.WriteLine("datetime: {0}", datetime);
            Console.WriteLine("tokyo: {0}", tokyo);
            Console.WriteLine();
            //=========================================================
            TimeZoneInfo JpZone = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
            DateTime utcTimeNow = DateTime.UtcNow;
            var utcNow2localTime = utcTimeNow.ToLocalTime();
            DateTime JpLocalTime = TimeZoneInfo.ConvertTimeFromUtc(utcTimeNow, JpZone);
            Console.WriteLine("utcTimeNow: {0}", utcTimeNow);
            Console.WriteLine("utcNow2localTime: {0}", utcNow2localTime);
            Console.WriteLine("JpLocalTime: {0}", JpLocalTime);
            Console.WriteLine();

            //=========================================================

            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Taipei Standard Time");

            DateTime now = DateTime.Now;
            var Now2localTime = now.ToLocalTime();
            var Now2LocalTimeZone = TimeZoneInfo.ConvertTime(now, timeZone);
            Console.WriteLine("Now: {0}", now);
            Console.WriteLine("Now2localTime: {0}", Now2localTime);
            Console.WriteLine("Now2LocalTimeZone: {0}", Now2LocalTimeZone);
            Console.WriteLine();

            //=========================================================

            var timeZone2 = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");

            DateTime now2 = DateTime.Now;
            var Now2localTime2 = now.ToLocalTime();
            var Now2LocalTimeZone2 = TimeZoneInfo.ConvertTime(now2, timeZone2);
            Console.WriteLine("Now2: {0}", now2);
            Console.WriteLine("Now2localTime2: {0}", Now2localTime2);
            Console.WriteLine("Now2LocalTimeZone2: {0}", Now2LocalTimeZone2);
            Console.WriteLine();

            //=========================================================

            Console.WriteLine("Local time zone is '{0}'.", TimeZoneInfo.Local.Id);
            var utcTime = new DateTime(2013, 03, 02, 01, 00, 00, DateTimeKind.Utc);
            var localTime = new DateTime(2013, 03, 02, 01, 00, 00, DateTimeKind.Local);
            var unspecifiedTime = new DateTime(2013, 03, 02, 01, 00, 00);

            var utcTimeConverted = TimeZoneInfo.ConvertTime(utcTime, timeZone); 
            var localTimeConverted = TimeZoneInfo.ConvertTime(localTime, timeZone); 
            var unspecifiedTimeConverted = TimeZoneInfo.ConvertTime(unspecifiedTime, timeZone);

            Console.WriteLine("Converting GMT         to Taipei Time: {0}", utcTimeConverted);
            Console.WriteLine("Converting Local       to Taipei Time: {0}", localTimeConverted);
            Console.WriteLine("Converting Unspecified to Taipei Time: {0}", unspecifiedTimeConverted);
            Console.WriteLine();
            //=========================================================

            // convert UTC time from the database to japanese time
            DateTime databaseUtcTime = new DateTime(2020, 5, 6, 11, 30, 00);
            var japaneseTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
            var japaneseTime = TimeZoneInfo.ConvertTimeFromUtc(databaseUtcTime, japaneseTimeZone);
            // convert japanese time to UTC for database save
            var databaseUtcTime1 = TimeZoneInfo.ConvertTimeToUtc(japaneseTime, japaneseTimeZone);

            Console.WriteLine("databaseUtcTime: {0}", databaseUtcTime);
            Console.WriteLine("japaneseTime: {0}", japaneseTime);
            Console.WriteLine("databaseUtcTime1: {0}", databaseUtcTime1);
            Console.WriteLine();
            // ========================================================

            // convert UTC time from the database to the machine's time
            DateTime databaseUtcTime2 = new DateTime(2020, 5, 6, 11, 35, 00);
            var localTime2 = databaseUtcTime2.ToLocalTime();
            // convert local time to UTC for database save
            var databaseUtcTime3 = localTime2.ToUniversalTime();

            Console.WriteLine("databaseUtcTime2: {0}", databaseUtcTime2);
            Console.WriteLine("localTime2: {0}", localTime2);
            Console.WriteLine("databaseUtcTime3: {0}", databaseUtcTime3);

            // ========================================================

            //foreach (TimeZoneInfo z in TimeZoneInfo.GetSystemTimeZones())
            //    Console.WriteLine(z.Id);
        }
    }
}
