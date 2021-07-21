namespace XxlJob.Core.Handlers
{
    public interface IJobHandlerFactory
    {
        IJobHandler GetJobHandler(string handlerName);
    }
}
