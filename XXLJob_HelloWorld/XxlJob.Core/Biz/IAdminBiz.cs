using System.Collections.Generic;
using System.Threading.Tasks;
using XxlJob.Core.Biz.Model;

namespace XxlJob.Core.Biz
{
    public interface IAdminBiz
    {
        /// <summary>
        /// 任务回调
        /// </summary>
        /// <param name="callbackParamList"></param>
        /// <returns></returns>
        Task<ReturnT> Callback(List<HandleCallbackParam> callbackParamList);

        /// <summary>
        /// 执行器注册
        /// </summary>
        /// <param name="registryParam"></param>
        /// <returns></returns>
        Task<ReturnT> Registry(RegistryParam registryParam);

        /// <summary>
        /// 执行器注册摘除
        /// </summary>
        /// <param name="registryParam"></param>
        /// <returns></returns>
        Task<ReturnT> RegistryRemove(RegistryParam registryParam);

        /// <summary>
        /// 更新任务参数
        /// </summary>
        /// <param name="updateExecutorParamParam"></param>
        /// <returns></returns>
        Task<ReturnT> UpdateExecutorParam(UpdateExecutorParamParam updateExecutorParamParam);
    }
}
