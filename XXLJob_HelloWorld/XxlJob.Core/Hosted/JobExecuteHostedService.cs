using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace XxlJob.Core
{
    /// <summary>
    ///  NOTE: 负责启动Executor服务，和进行服务注册的宿主服务
    /// </summary>
    public class JobsExecuteHostedService : BackgroundService
    {
        private readonly IExecutorRegistry _registry;

        public JobsExecuteHostedService(IExecutorRegistry registry)
        {
            _registry = registry;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return _registry.RegistryAsync(stoppingToken);
        }
    }
}
