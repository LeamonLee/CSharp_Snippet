using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using XxlJob.Core.Biz;
using XxlJob.Core.Biz.Client;
using XxlJob.Core.Biz.Impl;
using XxlJob.Core.Config;
using XxlJob.Core.Handlers;
using XxlJob.Core.Queue;
using XxlJob.Core.TaskExecutors;

namespace XxlJob.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddXxlJobExecutor(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddLogging();
            services.AddOptions<XxlJobExecutorOptions>().Configure(options =>
            {
                configuration.GetSection("xxlJob").Bind(options);
            });
            services.AddXxlJobExecutorServiceDependency();

            return services;
        }
        public static IServiceCollection AddXxlJobExecutor(this IServiceCollection services, Action<XxlJobExecutorOptions> configAction)
        {
            services.AddLogging();
            services.AddOptions();
            services.Configure(configAction).AddXxlJobExecutorServiceDependency();
            return services;
        }

        public static IServiceCollection AddDefaultXxlJobHandlers(this IServiceCollection services)
        {
            services.AddSingleton<IJobHandler, SimpleHttpJobHandler>();
            return services;
        }

        public static IServiceCollection AddAutoRegistry(this IServiceCollection services)
        {
            services.AddSingleton<IExecutorRegistry, ExecutorRegistry>()
                .AddSingleton<IHostedService, JobsExecuteHostedService>();

            return services;
        }

        public static IServiceCollection AddXxlJobExecutorServiceDependency(this IServiceCollection services)
        {
            //可在外部提前注册对应实现，并替换默认实现
            services.TryAddSingleton<IJobLogger, JobLogger>();
            services.TryAddSingleton<IJobHandlerFactory, DefaultJobHandlerFactory>();
            services.TryAddSingleton<IExecutorRegistry, ExecutorRegistry>();

            services.AddHttpClient("DotXxlJobClient");
            services.AddSingleton<JobDispatcher>();
            services.AddSingleton<TaskExecutorFactory>();
            services.AddSingleton<CallbackTaskQueue>();
            services.AddSingleton<IAdminBiz, AdminBizClient>();
            services.AddSingleton<IExecutorBiz, ExecutorBizImpl>();
            services.AddSingleton<ITaskExecutor, BeanTaskExecutor>();

            return services;
        }
    }
}
