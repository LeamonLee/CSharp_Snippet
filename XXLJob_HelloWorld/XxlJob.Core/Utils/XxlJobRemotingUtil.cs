using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;

using XxlJob.Core.Biz.Model;

namespace XxlJob.Core.Utils
{
    public class XxlJobRemotingUtil
    {
        public static readonly string XXL_JOB_ACCESS_TOKEN = "XXL-JOB-ACCESS-TOKEN";

        #region PostBody
        public async static Task<ReturnT> PostBody(string baseUrl, string resourceName, string accessToken, int timeout, object requestObj)
        {
            string apiUrl = $"{baseUrl}/{resourceName}";

            try
            {
                var client = new RestClient(baseUrl);
                var request = new RestRequest(resourceName, Method.POST, DataFormat.Json);
                request.Timeout = timeout * 1000;
                request.ReadWriteTimeout = timeout * 1000;

                if (!string.IsNullOrWhiteSpace(accessToken))
                {
                    request.AddHeader(XXL_JOB_ACCESS_TOKEN, accessToken);
                }

                string jsonObject = JsonSerializationHelper.Serialize(requestObj);
                request.AddJsonBody(jsonObject);

                var response = await client.ExecuteAsync(request);
                var statusCode = response.StatusCode;
                var resultJson = response.Content;

                if (statusCode != HttpStatusCode.OK)
                {
                    return new ReturnT(ReturnT.SUCCESS_CODE, $"xxl-rpc remoting fail, StatusCode({statusCode}) invalid. for url : {apiUrl}");
                }

                try
                {
                    ReturnT returnT = JsonSerializationHelper.Deserialize<ReturnT>(resultJson);
                    return returnT;
                }
                catch (Exception ex)
                {
                    return new ReturnT(ReturnT.FAIL_CODE, $"xxl-rpc remoting (url={apiUrl}) response content invalid({resultJson}). Exception: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                return new ReturnT(ReturnT.FAIL_CODE, $"xxl-rpc remoting error({ ex.Message }), for url : {apiUrl}");
            }
        }
        #endregion
    }
}
