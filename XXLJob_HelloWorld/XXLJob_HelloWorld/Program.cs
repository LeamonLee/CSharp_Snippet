using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using Volo.Abp;
using XxlJob.Core;
using XxlJob.Core.Biz.Model;
using XxlJob.Core.Handlers;
using XxlJob.Executor;

namespace XXLJob_HelloWorld
{
    class Program
    {
        private static ILogger _logger;
        static void Main(string[] args)
        {
            using (var application = AbpApplicationFactory.Create<AppModule>())
            {
                application.Initialize();
                _logger = application.ServiceProvider.GetRequiredService<ILogger<Program>>();

                try
                {
                    var appContextOptions = application.ServiceProvider.GetRequiredService<IOptions<AppContextOptions>>().Value;

                    var jobHandler = application.ServiceProvider.GetServices<IJobHandler>()
                        .Where(o => o.GetType().Name.Equals(appContextOptions.JobName))
                        .FirstOrDefault();

                    if (jobHandler != null)
                    {
                        var jobLogger = application.ServiceProvider.GetRequiredService<IJobLogger>();
                        var config = jobHandler.GetJobConfig<IJobHandlerConfig>(application.ServiceProvider);
                        string executorParams = config.ToString();
                        var context = new JobExecuteContext(application.ServiceProvider, jobHandler.GetType(), jobLogger, -1, executorParams);
                        jobHandler.Execute(context);
                    }
                    else
                    {
                        throw new Exception("Job doesn't exist！");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            }
        }
    }
}
