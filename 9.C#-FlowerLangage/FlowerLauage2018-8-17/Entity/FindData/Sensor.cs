using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlowerLauage2018_8_17.Entity.FindData
{
    public class Sensor
    {
        /// <summary>
        /// WiFi名称
        /// </summary>
        public string WiFiName { set; get; }
        /// <summary>
        /// WiFi密码
        /// </summary>
        public string WiFiPassword { set; get; }
        /// <summary>
        /// 网络IP地址
        /// </summary>
        public string IP { set; get; }
        /// <summary>
        /// 网络端口号
        /// </summary>
        public int Port { set; get; }
    }
}