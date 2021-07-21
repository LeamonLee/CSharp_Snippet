using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Volo.Abp.DependencyInjection;

namespace XxlJob.Executor
{
    public abstract class JobHandlerConfigBase : IJobHandlerConfig, ITransientDependency
    {
        public override string ToString()
        {
            return SerializeObjectWithJsonComment(this);
        }

        #region SerializeObjectWithJsonComment
        /// <summary>
        /// 序列化对象，包含JsonComment备注
        /// </summary>
        /// <param name="configuration"></param>
        private static string SerializeObjectWithJsonComment(object configuration)
        {
            string jsonParam = string.Empty;

            if (configuration != null)
            {
                var properties = configuration.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
                if (properties.Count() > 0)
                {
                    using (var sw = new StringWriter())
                    {
                        using (var writer = new JsonTextWriter(sw))
                        {
                            writer.Formatting = Formatting.Indented;
                            writer.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                            writer.WriteStartObject();
                            foreach (var property in properties)
                            {
                                writer.WritePropertyName(property.Name);

                                #region GetValue
                                object value = null;
                                if (property.PropertyType.FullName == typeof(string).FullName)
                                {
                                    value = (string)property.GetValue(configuration);
                                }
                                else if (property.PropertyType.FullName == typeof(DateTime).FullName)
                                {
                                    value = (DateTime)property.GetValue(configuration);
                                }
                                else if (property.PropertyType.FullName == typeof(DateTime?).FullName)
                                {
                                    value = (DateTime?)property.GetValue(configuration);
                                }
                                else if (property.PropertyType.FullName == typeof(int).FullName)
                                {
                                    value = (int)property.GetValue(configuration);
                                }
                                else if (property.PropertyType.FullName == typeof(double).FullName)
                                {
                                    value = (double)property.GetValue(configuration);
                                }
                                else if (property.PropertyType.FullName == typeof(float).FullName)
                                {
                                    value = (float)property.GetValue(configuration);
                                }
                                else if (property.PropertyType.FullName == typeof(bool).FullName)
                                {
                                    value = (bool)property.GetValue(configuration);
                                }
                                #endregion

                                writer.WriteValue(value);

                                var attribute = property.GetCustomAttributes(typeof(JsonCommentAttribute)).FirstOrDefault();
                                if (attribute != null)
                                {
                                    writer.WriteComment(((JsonCommentAttribute)attribute).Comment);
                                }
                            }
                            writer.WriteEndObject();
                        }
                        jsonParam = sw.ToString();
                    }
                }
            }

            return jsonParam;
        }
        #endregion
    }
}
