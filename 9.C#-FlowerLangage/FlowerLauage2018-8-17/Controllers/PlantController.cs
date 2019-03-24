using FlowerLauage2018_8_17.Entity;
using FlowerLauage2018_8_17.Entity.JsonObject;
using FlowerLauage2018_8_17.IService;
using FlowerLauage2018_8_17.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlowerLauage2018_8_17.Controllers
{
    public class PlantController : Controller
    {
        // GET: Plant
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public JsonResult GetList()
        {
            var Datas = PlantIService.plantService.GetList();
            return JsonIService.jsonService.SendPlantData(Datas);
        }

        /// <summary>
        /// 保存、更改数据
        /// </summary>
        /// <param name="querystring"></param>
        public void SaveData(string querystring)
        {
            PlantObject rb = JsonIService.jsonService.PlantToObject(querystring);
            var keyValue = rb.plantData.PlantID;
            PlantIService.plantService.SaveData(keyValue, rb.plantData);
        }
    }
}