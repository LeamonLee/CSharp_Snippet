using Newtonsoft.Json;

namespace XxlJob.Core.Utils
{
    /// <summary>
    /// Json序列化帮助类
    /// </summary>
    public class JsonSerializationHelper
    {
        private static JsonSerializerSettings _jsonSerializerSettings;

        static JsonSerializationHelper()
        {
            _jsonSerializerSettings = new JsonSerializerSettings()
            {
            };
        }

        #region Serialize
        /// <summary>
        /// 将对象序列化为JSON字符串
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="obj">对象实例</param>
        /// <returns>JSON字符串</returns>
        public static string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj, _jsonSerializerSettings);
        }
        #endregion

        #region Deserialize
        /// <summary>
        /// 将JSON字符串反序列化为对象实体
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">JSON字符串</param>
        /// <returns>对象实体</returns>
        public static T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, _jsonSerializerSettings);
        }
        #endregion
    }
}
