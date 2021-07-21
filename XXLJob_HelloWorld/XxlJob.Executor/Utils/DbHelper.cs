using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Extensions.Configuration;

namespace XxlJob.Executor
{
    /// <summary>
    /// Database Access Helper.
    /// </summary>
    public class DbHelper : IDisposable
    {
        private bool isCompleted = false;
        private DbProviderFactory providerFactory = null;
        private DbConnection connection = null;
        private DbCommand command = null;
        private DbDataAdapter dataAdapter = null;
        private DbTransaction transaction = null;
        private int commandTimeout = 300;

        /// <summary>
        /// 数据库连接对象
        /// </summary>
        public DbConnection Connection
        {
            get { return connection; }
        }

        /// <summary>
        /// 事务对象
        /// </summary>
        public DbTransaction Transaction
        {
            get { return transaction; }
        }

        #region Constructors
        static DbHelper()
        {
            //.NET Core需手动注册DbProviderFactories
            RegisterProviderFactories();
        }

        public DbHelper()
            : this(string.Empty)
        {
        }

        public DbHelper(string databaseName)
        {
            ProviderInfo provider = FindProvider(databaseName);
            providerFactory = DbProviderFactories.GetFactory(provider.ProviderName);
            dataAdapter = providerFactory.CreateDataAdapter();
            connection = providerFactory.CreateConnection();
            connection.ConnectionString = provider.ConnectionString;

            connection.Open();
            transaction = connection.BeginTransaction();
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            if (isCompleted)
            {
                if (transaction != null)
                {
                    transaction.Commit();
                }
            }
            else
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
            }

            if (connection != null)
            {
                connection.Close();
            }
        }
        #endregion

        #region Complete
        public void Complete()
        {
            isCompleted = true;
        }
        #endregion

        #region SingleExecuteDataSet
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sql">查询SQL</param>
        /// <returns>DataSet</returns>
        public static DataSet SingleExecuteDataSet(string sql)
        {
            return SingleExecuteDataSet(sql, string.Empty);
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sql">查询SQL</param>
        /// <param name="databaseName">数据库名称</param>
        /// <returns>DataSet</returns>
        public static DataSet SingleExecuteDataSet(string sql, string databaseName)
        {
            DataSet dataSet = null;
            using (DbHelper dbHelper = new DbHelper(databaseName))
            {
                dataSet = dbHelper.ExecuteDataSet(sql);
                dbHelper.Complete();
            }

            return dataSet;
        }
        #endregion

        #region SingleExecuteScalar
        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。 忽略其他列或行。
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>查询结果（object）</returns>
        public static object SingleExecuteScalar(string sql)
        {
            return SingleExecuteScalar(sql, string.Empty);
        }

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。 忽略其他列或行。
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="databaseName">数据库名称</param>
        /// <returns>查询结果（object）</returns>
        public static object SingleExecuteScalar(string sql, string databaseName)
        {
            object result = null;
            using (DbHelper dbHelper = new DbHelper(databaseName))
            {
                result = dbHelper.ExecuteScalar(sql);
                dbHelper.Complete();
            }

            return result;
        }
        #endregion

        #region SingleExecuteNonQuery
        /// <summary>
        /// 操作数据库(不含事务)
        /// </summary>
        /// <param name="sql">操作SQL</param>
        /// <returns></returns>
        public static int SingleExecuteNonQuery(string sql)
        {
            return SingleExecuteNonQuery(sql, string.Empty);
        }

        /// <summary>
        /// 操作数据库(不含事务)
        /// </summary>
        /// <param name="sql">操作SQL</param>
        /// <param name="databaseName">数据库名称</param>
        /// <returns></returns>
        public static int SingleExecuteNonQuery(string sql, string databaseName)
        {
            int result = -1;
            using (DbHelper dbHelper = new DbHelper(databaseName))
            {
                result = dbHelper.ExecuteNonQuery(sql);
                dbHelper.Complete();
            }
            return result;
        }
        #endregion

        #region ExecuteDataSet
        /// <summary>
        /// 执行SQL语句，并返回查询结果集。
        /// </summary>
        /// <param name="sql">SQL语句。</param>
        /// <returns>查询结果（DataSet）。</returns>
        public DataSet ExecuteDataSet(string sql)
        {
            command = connection.CreateCommand();
            command.CommandText = sql;
            command.CommandTimeout = commandTimeout;
            DataSet dataSet = new DataSet();
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(dataSet);
            command.Parameters.Clear();

            return dataSet;
        }
        #endregion

        #region ExecuteReader
        /// <summary>
        /// 执行SQL语句，并返回IDataReader接口。
        /// </summary>
        /// <param name="sql">SQL语句。</param>
        /// <returns>查询结果（IDataReader接口）。</returns>
        public IDataReader ExecuteReader(string sql)
        {
            command = connection.CreateCommand();
            command.CommandText = sql;
            command.CommandTimeout = commandTimeout;
            IDataReader result = command.ExecuteReader();
            command.Parameters.Clear();
            return result;
        }
        #endregion

        #region ExecuteScalar
        /// <summary>
        /// 执行SQL语句，并返回查询所返回的结果集中第一行的第一列，忽略其他列或行。
        /// </summary>
        /// <param name="sql">SQL语句。</param>
        /// <returns>查询结果（object）。</returns>
        public object ExecuteScalar(string sql)
        {
            command = connection.CreateCommand();
            command.CommandText = sql;
            command.CommandTimeout = commandTimeout;
            object result = command.ExecuteScalar();
            command.Parameters.Clear();
            return result;
        }
        #endregion

        #region ExecuteNonQuery
        /// <summary>
        /// 执行SQL语句，返回受影响的记录行数。
        /// </summary>
        /// <param name="sql">SQL语句。</param>
        /// <returns>受影响的记录行数。</returns>
        public int ExecuteNonQuery(string sql)
        {
            command = connection.CreateCommand();
            command.CommandText = sql;
            command.CommandTimeout = commandTimeout;
            int result = command.ExecuteNonQuery();
            command.Parameters.Clear();
            return result;
        }
        #endregion

        #region FindProvider
        /// <summary>
        /// 根据名称，查找ProviderInfo
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private ProviderInfo FindProvider(string name)
        {
            string DefaultName = "Default";
            string toFindName = name;
            if (string.IsNullOrEmpty(toFindName))
            {
                toFindName = DefaultName;
            }

            ProviderInfo findedProvider = null;
            var providerList = LoadConnectionStrings();

            foreach (var provider in providerList)
            {
                if (provider.Name == toFindName)
                {
                    findedProvider = provider;
                }
            }

            if (findedProvider == null)
            {
                throw new Exception($"无法找到名称为{toFindName}的数据库连接字串");
            }

            return findedProvider;
        }
        #endregion

        #region LoadConnectionStrings
        /// <summary>
        /// 从配置档反序列化数据库连接参数
        /// </summary>
        /// <returns></returns>
        private IList<ProviderInfo> LoadConnectionStrings()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json");
            var configurationRoot = builder.Build();

            var providerInfoList = new List<ProviderInfo>();
            IConfigurationSection config = configurationRoot.GetSection("ConnectionStrings");
            config.Bind(providerInfoList);

            return providerInfoList;
        }
        #endregion

        #region RegisterProviderFactories
        /// <summary>
        /// 注册Provider Factories
        /// </summary>
        private static void RegisterProviderFactories()
        {
            DbProviderFactories.RegisterFactory("Npgsql", "Npgsql.NpgsqlFactory, Npgsql");
            DbProviderFactories.RegisterFactory("Oracle.ManagedDataAccess.Client", "Oracle.ManagedDataAccess.Client.OracleClientFactory, Oracle.ManagedDataAccess");
            DbProviderFactories.RegisterFactory("System.Data.SqlClient", "System.Data.SqlClient.SqlClientFactory, System.Data");
            DbProviderFactories.RegisterFactory("MySql.Data.MySqlClient", "MySql.Data.MySqlClient.MySqlClientFactory, MySql.Data");
        }
        #endregion

        #region private class ProviderInfo
        private class ProviderInfo
        {
            /// <summary>
            /// 名称
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// 连接字串
            /// </summary>
            public string ConnectionString { get; set; }
            /// <summary>
            /// 提供者名称
            /// </summary>
            public string ProviderName { get; set; }
        }
        #endregion
    }
}
