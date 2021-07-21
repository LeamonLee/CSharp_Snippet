using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using XxlJob.Core.Biz;
using XxlJob.Core.Biz.Model;
using XxlJob.Core.Utils;

namespace XxlJob.Core
{
    public class XxlJobExecutorMiddleware
    {
        private readonly IServiceProvider _provider;
        private readonly RequestDelegate _next;
        private readonly IExecutorBiz _executorBiz;

        public XxlJobExecutorMiddleware(IServiceProvider provider, RequestDelegate next)
        {
            _provider = provider;
            _next = next;
            _executorBiz = _provider.GetRequiredService<IExecutorBiz>();
        }

        #region Invoke
        public async Task Invoke(HttpContext context)
        {
            if (MatchXxlJobExecutorRoute(context, out var executorRouteMatched))
            {
                using (var streamReader = new StreamReader(context.Request.Body))
                {
                    string param = await streamReader.ReadToEndAsync();
                    ReturnT returnT = ReturnT.FAIL;

                    switch (executorRouteMatched)
                    {
                        case ExecutorRoute.Beat:
                            returnT = _executorBiz.Beat();
                            break;
                        case ExecutorRoute.IdleBeat:
                            var idleBeatParam = JsonSerializationHelper.Deserialize<IdleBeatParam>(param);
                            returnT = _executorBiz.IdleBeat(idleBeatParam);
                            break;
                        case ExecutorRoute.Run:
                            var triggerParam = JsonSerializationHelper.Deserialize<TriggerParam>(param);
                            returnT = _executorBiz.Run(triggerParam);
                            break;
                        case ExecutorRoute.Kill:
                            var killParam = JsonSerializationHelper.Deserialize<KillParam>(param);
                            returnT = _executorBiz.Kill(killParam);
                            break;
                        case ExecutorRoute.Log:
                            var logParam = JsonSerializationHelper.Deserialize<LogParam>(param);
                            returnT = _executorBiz.Log(logParam);
                            break;
                    }

                    string result = JsonSerializationHelper.Serialize(returnT);
                    var resultBytes = Encoding.UTF8.GetBytes(result);

                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    context.Response.ContentType = "application/json";
                    await context.Response.Body.WriteAsync(resultBytes, 0, resultBytes.Length);
                    return;
                }
            }

            await _next.Invoke(context);
        }
        #endregion

        /// <summary>
        /// 执行器路由
        /// </summary>
        public enum ExecutorRoute
        {
            /// <summary>
            /// 心跳检测
            /// </summary>
            Beat,
            /// <summary>
            /// 忙碌检测
            /// </summary>
            IdleBeat,
            /// <summary>
            /// 触发任务
            /// </summary>
            Run,
            /// <summary>
            /// 终止任务
            /// </summary>
            Kill,
            /// <summary>
            /// 查看执行日志
            /// </summary>
            Log
        }

        private string ParseExecutorRoute(string path)
        {
            string result = string.Empty;

            if(path.StartsWith("/"))
            {
                result = path.Remove(0, 1).ToLower();
            }

            return result;
        }

        #region MatchXxlJobExecutorRoute
        public bool MatchXxlJobExecutorRoute(HttpContext context, out ExecutorRoute executorRouteMatched)
        {
            bool result = false;

            //匹配路由地址
            executorRouteMatched = 0;
            bool routeMatched = false;
            string currentRoute = ParseExecutorRoute(context.Request.Path);
            var routeList = Enum.GetNames(typeof(ExecutorRoute))
                .Select(o=> { return o.ToLower(); });
            if (routeList.Contains(currentRoute.ToLower()))
            {
                routeMatched = true;
                Enum.TryParse(currentRoute, true, out executorRouteMatched);
            }

            if ("POST".Equals(context.Request.Method, StringComparison.OrdinalIgnoreCase)
                && routeMatched)
            {
                result = true;
            }

            return result;
        }
        #endregion
    }
}
