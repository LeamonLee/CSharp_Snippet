using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using XxlJob.Core;

namespace XxlJob.Executor
{
    public class XxlJobExecutorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            base.ConfigureServices(context);

            //配置AppContextOptions
            ConfigureAppContextOptions(context.Services);

            //配置XxlJob
            ConfigureXxlJobService(context.Services);
        }

        #region ConfigureAppContextOptions
        /// <summary>
        /// 配置AppContext
        /// </summary>
        /// <param name="services"></param>
        private static void ConfigureAppContextOptions(IServiceCollection services)
        {
            services.Configure<XxlJobExecutorOptions>(options =>
            {
                try
                {
                    var configurationRoot = services.GetConfiguration();
                    options.MesApiBaseUrl = configurationRoot.GetSection("MesApiBaseUrl").Value;
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("全局配置文件解析失败：{0}", ex.Message));
                }
            });
        }
        #endregion

        #region ConfigureXxlJobService
        /// <summary>
        /// 配置XxlJob
        /// </summary>
        /// <param name="services"></param>
        private static void ConfigureXxlJobService(IServiceCollection services)
        {
            var configuration = services.GetConfiguration();
            services.AddXxlJobExecutor(configuration);
            services.AddAutoRegistry(); //自动注册
        }
        #endregion
    }
}
