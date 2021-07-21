using Dapper;
using System.Collections.Generic;

namespace XxlJob.Executor
{
    public static class DbHelperExtensions
    {
        public static IEnumerable<T> Query<T>(this DbHelper dbHelper, string sql)
        {
            return dbHelper.Connection.Query<T>(sql, transaction: dbHelper.Transaction);
        }
    }
}
