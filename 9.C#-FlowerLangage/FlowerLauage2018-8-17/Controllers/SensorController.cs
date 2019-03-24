using FlowerLauage2018_8_17.Entity.JsonObject;
using FlowerLauage2018_8_17.IService;
using FlowerLauage2018_8_17.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FlowerLauage2018_8_17.Controllers
{
    public class SensorController : Controller
    {
        // GET: Sensor
        public ActionResult submit()
        {
            return View();
        }
        /// <summary>
        /// 导入数据库数据
        /// </summary>
        /// <param name="queryString"></param>
        public void InSertData(string querystring)
        {
            SensorObject rb = JsonIService.jsonService.SensorToObj(querystring);
          //  SensorIService.sensorService.Server(rb.SensorData.IP, rb.SensorData.Port);
            SensorIService.sensorService.Server(GetAddressIP(), 8080);
        }

        /// <summary>
        /// 获取本地IP
        /// </summary>
        /// <returns></returns>
        static string GetAddressIP()
        {
            string AddressIP = string.Empty;
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = _IPAddress.ToString();
                }
            }
            return AddressIP;
        }
    }
}