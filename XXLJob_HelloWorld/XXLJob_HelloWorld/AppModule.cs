using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using XxlJob.Executor;

namespace XXLJob_HelloWorld
{
    [DependsOn(typeof(AbpAutofacModule))]
    [DependsOn(typeof(XxlJobExecutorModule))]
    class AppModule : AbpModule
    {
        #region ConfigureServices
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            base.ConfigureServices(context);

            //配置AppContextOptions
            ConfigureAppContextOptions(context.Services);

            //配置Serillog
            ConfigureSerilogService(context.Services);
        }
        #endregion

        #region ConfigureAppContextOptions
        /// <summary>
        /// 配置AppContext
        /// </summary>
        /// <param name="services"></param>
        private static void ConfigureAppContextOptions(IServiceCollection services)
        {
            services.Configure<AppContextOptions>(options =>
            {
                try
                {
                    var configurationRoot = services.GetConfiguration();
                    options.JobName = configurationRoot.GetSection("JobName").Value;
                    options.MesApiBaseUrl = configurationRoot.GetSection("MesApiBaseUrl").Value;
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("全局配置文件解析失败：{0}", ex.Message));
                }
            });
        }
        #endregion

        #region ConfigureSerilogService
        /// <summary>
        /// 配置Serillog
        /// </summary>
        /// <param name="services"></param>
        private static void ConfigureSerilogService(IServiceCollection services)
        {
            var configurationRoot = services.GetConfiguration();

            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configurationRoot)
                .WriteTo.Console()
                .WriteTo.File("Log/.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            services.AddLogging(configure =>
            {
                configure.AddSerilog(logger, true);
            });
        }
        #endregion
    }
}
