using FlowerLauage2018_8_17.Entity;
using FlowerLauage2018_8_17.Entity.JsonObject;
using FlowerLauage2018_8_17.IService;
using FlowerLauage2018_8_17.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FlowerLauage2018_8_17.Controllers
{
    public class FlowerDataController : Controller
    {
        #region 视图功能
        // GET: Flower
        public ActionResult index3()
        {
            return View();
        }
        public ActionResult index()
        {
            return View();
        }
        public ActionResult ggl()
        {
            return View();
        }

        public ActionResult message()
        {
            return View();
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 获取所有花的数据
        /// </summary>
        /// <param name="querystring"></param>
        /// <returns></returns>
        public JsonResult GetAllFlowerDatas()
        {
            List<FlowerData> flowerDatas = FlowerDataIService.flowerDataService.AllFlowerData();
            return JsonIService.jsonService.SendFlowerData(flowerDatas);
        }
        /// <summary>
        /// 获取指定花的品种
        /// </summary>
        /// <param name="querystring"></param>
        /// <returns></returns>
        public JsonResult GetFlowerDatas(string querystring)
        {
            FlowerObject rb = JsonIService.jsonService.FlowerToObj(querystring);
            string Qstring =rb.flowerData.Alias;
            List<FlowerData> flowerDatas = FlowerDataIService.flowerDataService.FindFlowerData(Qstring);
            return JsonIService.jsonService.SendFlowerData(flowerDatas);
        }
        /// <summary>
        /// 获取花的最新数据
        /// </summary>
        /// <param name="querystring"></param>
        /// <returns></returns>
        public JsonResult GetNewData(string querystring)
        {
            FlowerObject rb = JsonIService.jsonService.FlowerToObj(querystring);
            var EmptyData = new FlowerDataDetail();
            FlowerDataDetail flowerData = FlowerDataIService.flowerDataService.GetNewData(ConfigurationManager.AppSettings["UserID"],rb.flowerDataDetail.FlowerName);
            //添加实时监控数据，达到灌溉的目的  测试专用
            // SensorIService.sensorService.Server(GetAddressIP(), 8080);   //配置基本信息    
           // SensorIService.sensorService.Server(GetAddressIP(), 8080);

            var key = ConfirmIService.Confirm.FlowerDataDetailCorrect(flowerData);
            if (key == 1)                        //判断数据是否重复
                return JsonIService.jsonService.SendFlowerDataDetail(flowerData);
            else
                return JsonIService.jsonService.SendFlowerDataDetail(EmptyData);
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
        /// <summary>
        /// 获取历史数据
        /// </summary>
        /// <param name="querystring"></param>
        /// <returns></returns>
        public JsonResult GetHistoryData(string querystring)
        {
            SearchObject rb = JsonIService.jsonService.SearchToObject(querystring);
            DateTime StartTime = Convert.ToDateTime(rb.histroyTime.StartTime);
            DateTime EndTime = Convert.ToDateTime(rb.histroyTime.EndTime);
            List<FlowerDataDetail> flowerDetailDatas = FlowerDataIService.flowerDataService.GetHistoryData(StartTime, EndTime, ConfigurationManager.AppSettings["UserID"],rb.histroyTime.FlowerName);
            return JsonIService.jsonService.SendDetailDatas(flowerDetailDatas);
        }
        /// <summary>
        /// 检测花的状态上传公告栏
        /// </summary>
        /// <param name="querystring"></param>
        /// <returns></returns>
        public JsonResult DetectFlowerDetailData()
        {
            FlowerDataDetail flowerData = FlowerDataIService.flowerDataService.GetNewData();
            string Msg = ConfirmIService.Confirm.DetectFlower (flowerData);
            string CorrectMsg = ConfirmIService.Confirm.AnnouncementCorrect(Msg);   //公告栏信息验证是否重复
            return JsonIService.jsonService.SendMsg(CorrectMsg);  //信息重复返回:"信息重复"字符串,不重复返回正常的警告信息
        }
        #endregion

        #region 数据验证

        #endregion
    }
}