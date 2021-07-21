using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XxlJob.Core.Config;
using XxlJob.Core.Biz.Model;
using XxlJob.Core.Utils;

namespace XxlJob.Core.Biz.Client
{
    public class AdminBizClient : IAdminBiz
    {
        private string _accessToken;
        private int _timeout = 5;
        private List<AddressEntry> _adminAddresses;

        private readonly XxlJobExecutorOptions _options;
        private readonly ILogger<AdminBizClient> _logger;

        public AdminBizClient(IOptions<XxlJobExecutorOptions> optionsAccessor,
            ILogger<AdminBizClient> logger)
        {
            Preconditions.CheckNotNull(optionsAccessor?.Value, "XxlJobExecutorOptions");
            Preconditions.CheckNotNull(optionsAccessor?.Value.AdminAddresses, "XxlJobExecutorOptions.AdminAddresses");

            _options = optionsAccessor?.Value;
            _logger = logger;

            _accessToken = _options.AccessToken;
            _adminAddresses = ParseAdminAddress(_options.AdminAddresses);
        }

        #region ParseAdminAddress
        private List<AddressEntry> ParseAdminAddress(string adminAddresses)
        {
            string API = "api";
            var result = new List<AddressEntry>();
            foreach (var item in adminAddresses.Split(','))
            {
                try
                {
                    string adminAddress = item;
                    if (!adminAddress.EndsWith("/"))
                    {
                        adminAddress = adminAddress + "/";
                    }
                    var uri = new Uri(adminAddress + API);
                    var entry = new AddressEntry { RequestUri = uri };
                    result.Add(entry);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Init admin address error.");
                }
            }

            return result;
        }
        #endregion

        private string GetRequestBaseUrl(List<AddressEntry> adminAddresses)
        {
            var baseUrl = adminAddresses[0].RequestUri.AbsoluteUri;
            return baseUrl;
        }

        public Task<ReturnT> Callback(List<HandleCallbackParam> callbackParamList)
        {
            return XxlJobRemotingUtil.PostBody(GetRequestBaseUrl(_adminAddresses), "callback", _accessToken, _timeout, callbackParamList);
        }

        public Task<ReturnT> Registry(RegistryParam registryParam)
        {
            return XxlJobRemotingUtil.PostBody(GetRequestBaseUrl(_adminAddresses), "registry", _accessToken, _timeout, registryParam);
        }

        public Task<ReturnT> RegistryRemove(RegistryParam registryParam)
        {
            return XxlJobRemotingUtil.PostBody(GetRequestBaseUrl(_adminAddresses), "registryRemove", _accessToken, _timeout, registryParam);
        }

        public Task<ReturnT> UpdateExecutorParam(UpdateExecutorParamParam updateExecutorParamParam)
        {
            return XxlJobRemotingUtil.PostBody(GetRequestBaseUrl(_adminAddresses), "updateExecutorParam", _accessToken, _timeout, updateExecutorParamParam);
        }
    }
}
