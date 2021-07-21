using System.Threading;
using System.Threading.Tasks;

namespace XxlJob.Core
{
    public interface IExecutorRegistry
    {
        Task RegistryAsync(CancellationToken cancellationToken);
    }
}
