using Newtonsoft.Json;

namespace XxlJob.Core.Biz.Model
{
    public class RegistryParam
    {
        /// <summary>
        /// 固定值EXECUTOR
        /// </summary>
        [JsonProperty("registryGroup")]
        public string RegistryGroup { get; set; }

        /// <summary>
        /// 执行器AppName
        /// </summary>
        [JsonProperty("registryKey")]
        public string RegistryKey { get; set; }

        /// <summary>
        /// 执行器地址
        /// </summary>
        [JsonProperty("registryValue")]
        public string RegistryValue { get; set; }

        public RegistryParam() { }

        public RegistryParam(string registryGroup, string registryKey, string registryValue)
        {
            RegistryGroup = registryGroup;
            RegistryKey = registryKey;
            RegistryValue = registryValue;
        }

        public override string ToString()
        {
            return $"RegistryParam{{registryGroup='{RegistryGroup}', registryKey='{RegistryKey}', registryValue='{RegistryValue}'}}";
        }
    }
}
