using FlowerLauage2018_8_17.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlowerLauage2018_8_17.Service.ModelService
{
    public class FlowerDataService
    {
        /// <summary>
        /// 获取所有花的品种信息
        /// </summary>
        /// <returns></returns>
        public List<FlowerData> AllFlowerData()
        {
            var Data = SqlIService.FlowerDataService.FindAllDatas();
            return Data;
        }
        /// <summary>
        /// 获取花品种信息
        /// </summary>
        /// <returns></returns>
        public List<FlowerData> FindFlowerData(string querystring)
        {
            List<FlowerData> Data = SqlIService.FlowerDataService.FindFlowerDatas(querystring);
            return Data;
        }
        /// <summary>
        /// 获取花实时数据
        /// </summary>
        /// <returns></returns>
        public FlowerDataDetail GetNewData(string UserID,string FlowerName)
        {
            FlowerDataDetail Data = SqlIService.FlowerDataService.NewDetailData(UserID, FlowerName);
            return Data;
        }

        /// <summary>
        /// 获取花实时数据
        /// </summary>
        /// <returns></returns>
        public FlowerDataDetail GetNewData()
        {
            FlowerDataDetail Data = SqlIService.FlowerDataService.NewDetailData();
            return Data;
        }

        /// <summary>
        /// 获取花历史数据
        /// </summary>
        /// <returns></returns>
        public List<FlowerDataDetail> GetHistoryData(DateTime StartTime, DateTime EndTime,string UserID ,string FlowerName)
        {
            List<FlowerDataDetail> Data = SqlIService.FlowerDataService.GetHistoryData(StartTime,EndTime, UserID, FlowerName);
            return Data;
        }
    }
}