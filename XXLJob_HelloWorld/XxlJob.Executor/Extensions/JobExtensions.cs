using System;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XxlJob.Core.Biz;
using XxlJob.Core.Biz.Model;
using XxlJob.Core.Handlers;
using XxlJob.Core.Utils;

namespace XxlJob.Executor
{
    public static class JobExtensions
    {
        static readonly string DEFAULT_JOB_HANDLER_CONFIG_DIR = "Configs";

        #region GetJobConfig
        /// <summary>
        /// 获取Job的配置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="job"></param>
        /// <returns></returns>
        public static T GetJobConfig<T>(this IJobHandler job, IServiceProvider serviceProvider) where T : IJobHandlerConfig
        {
            string jobName = job.GetType().Name;
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string configPath = Path.Combine(baseDirectory, $"{DEFAULT_JOB_HANDLER_CONFIG_DIR}/{jobName}.json");
            return GetJobConfig<T>(job, serviceProvider, configPath);
        }

        /// <summary>
        /// 获取Job的配置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="job"></param>
        /// <param name="configPath"></param>
        /// <returns></returns>
        public static T GetJobConfig<T>(this IJobHandler job, IServiceProvider serviceProvider, string configPath) where T : IJobHandlerConfig
        {
            if (File.Exists(configPath))
            {
                string jobName = job.GetType().Name;

                var jobConfig = serviceProvider.GetServices<T>()
                        .Where(o => o.GetType().Name.Equals(jobName + "Config"))
                        .FirstOrDefault();

                var builder = new ConfigurationBuilder();
                builder.AddJsonFile(configPath);
                var configurationRoot = builder.Build();
                configurationRoot.Bind(jobConfig);

                return jobConfig;
            }
            else
            {
                return default;
            }
        }

        public static T GetJobConfig<T>(this JobExecuteContext context)
        {
            string jobParameter = context.JobParameter;
            return JsonSerializationHelper.Deserialize<T>(jobParameter);
        }
        #endregion

        #region SaveJobConfig

        public static void SaveJobConfig<T>(this JobExecuteContext jobExecuteContext, T configuration) where T : IJobHandlerConfig
        {
            if (jobExecuteContext.JobId > 0)
            {
                //保存至XxlJob-Admin
                jobExecuteContext.SaveJobConfigToXxlJobAdmin(configuration);
            }
            else
            {
                //保存至本地json文档
                jobExecuteContext.SaveJobConfigToLocalJson(configuration);
            }
        }

        /// <summary>
        /// 保存任务参数，to XxlJob Admin
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jobExecuteContext"></param>
        private static void SaveJobConfigToXxlJobAdmin<T>(this JobExecuteContext jobExecuteContext, T configuration) where T : IJobHandlerConfig
        {
            var jobId = jobExecuteContext.JobId;
            var adminClient = jobExecuteContext.ServiceProvider.GetRequiredService<IAdminBiz>();
            var updateExecutorParam = new UpdateExecutorParamParam
            {
                JobId = jobId,
                ExecutorParams = configuration.ToString()
            };
            adminClient.UpdateExecutorParam(updateExecutorParam);
        }

        /// <summary>
        /// 保存任务参数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="job"></param>
        /// <param name="configuration"></param>
        private static void SaveJobConfigToLocalJson<T>(this JobExecuteContext context, T configuration) where T : IJobHandlerConfig
        {
            string jobName = context.JobType.Name;
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string configPath = Path.Combine(baseDirectory, $"{DEFAULT_JOB_HANDLER_CONFIG_DIR}/{jobName}.json");

            SaveJobConfigToLocalJson(configuration, configPath);
        }

        /// <summary>
        /// 保存任务参数
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="configPath"></param>
        private static void SaveJobConfigToLocalJson(object configuration, string configPath)
        {
            if (File.Exists(configPath))
            {
                using (var sw = File.CreateText(configPath))
                {
                    string jsonResult = configuration.ToString();
                    sw.Write(jsonResult);
                }
            }
        }
        #endregion
    }
}
