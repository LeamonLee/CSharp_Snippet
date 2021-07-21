using System;
using System.Collections.Generic;
using System.Text;

namespace XXLJob_HelloWorld
{
    public class AppContextOptions
    {
        /// <summary>
        /// Job名称
        /// </summary>
        public string JobName { get; set; }

        /// <summary>
        /// MES API基本入口
        /// </summary>
        public string MesApiBaseUrl { get; set; }
    }
}
