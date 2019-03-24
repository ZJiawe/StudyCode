using FlowerLauage2018_8_17.Entity;
using FlowerLauage2018_8_17.Fuctions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FlowerLauage2018_8_17.Service.ModelService
{
    public class PlantService
    {
        /// <summary>
        /// 获取用户植物资料
        /// </summary>
        /// <returns></returns>
        public List<PlantData> GetList()
        {
            return SqlIService.PlantService.GetList(ConfigurationManager.AppSettings["UserID"]);
        }

        /// <summary>
        /// 保存更改用户植物资料
        /// </summary>
        /// <param name="Data"></param>
        public void SaveData(string KeyValue, PlantData Data)
        {
            if (KeyValue != null)
            {
                Data.Date = DateTime.Now;
                SqlIService.PlantService.Update(Data);
            }
            else
            {
                Data.PlantID= BaseIService.creatID.CreatKey();
                Data.Date = DateTime.Now;
                Data.UserID = ConfigurationManager.AppSettings["UserID"];
                SqlIService.PlantService.Insert(Data);
            }
        }
    }
}