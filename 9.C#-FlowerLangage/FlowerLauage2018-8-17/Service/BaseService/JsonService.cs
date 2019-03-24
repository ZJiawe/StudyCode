using FlowerLauage2018_8_17.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlowerLauage2018_8_17.Entity.JsonObject;

namespace FlowerLauage2018_8_17.Fuctions
{
    public class JsonService : Controller
    {
        #region 用户Json
        /// <summary>
        /// 登陆Json字符串
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="Confirm"></param>
        /// <returns></returns>
        public JsonResult LoginJson(Login Data,int Confirm,string ErrMessage)
        {
            var sendJson = new
            {
                code = Confirm,
                msg = ErrMessage,
                rows = Data
            };
            return Json(sendJson, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 用户Json字符串反序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public UserObject UserToObj(string obj)        
        {
            UserObject rb = JsonConvert.DeserializeObject<UserObject>(obj);
            return rb;
        }
        #endregion

        #region 花种类Json
        /// <summary>
        /// 花品种Json字符串反序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public FlowerObject FlowerToObj(string obj)
        {
            FlowerObject rb = JsonConvert.DeserializeObject<FlowerObject>(obj);
            return rb;
        }
        /// <summary>
        /// 发送多条花品种数据
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public JsonResult SendFlowerData(List<FlowerData> Data)
        {
            var sendJson = new
            {
                rows = Data,
            };
            return Json(sendJson, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 花状态Json
        /// <summary>
        /// 最新花的状态数据
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public JsonResult SendFlowerDataDetail(FlowerDataDetail Data)
        {
            var sendJson = new
            {
                rows = Data,
            };
            return Json(sendJson, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 发送多条花状态详细数据
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public JsonResult SendDetailDatas(List<FlowerDataDetail> Data)
        {
            var sendJson = new
            {
                rows = Data,
            };
            return Json(sendJson, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 聊天Json

        /// <summary>
        /// 聊天数据Json字符串反序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public ChatObject ChatToObj(string obj)
        {
            ChatObject rb = JsonConvert.DeserializeObject<ChatObject>(obj);
            return rb;
        }

        /// <summary>
        /// 多条聊天消息发送
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public JsonResult SendChats(List<ChatData> Data)
        {
            var sendJson = new
            {
                rows = Data,
            };
            return Json(sendJson,JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 单条聊天记录
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public JsonResult SendChat(ChatData Data,string Role)
        {
            var sendJson = new
            {
                rows = Data,
                role=Role
            };
            return Json(sendJson, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 历史Json
        /// <summary>
        /// 起始时间终止时间,历史条件Json字符串反序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public SearchObject SearchToObject(string obj)
        {
            SearchObject rb = JsonConvert.DeserializeObject<SearchObject>(obj);
            return rb;
        }

        /// <summary>
        /// 聊天历史数据
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public SearchObject SearchChatData(string obj)
        {
            SearchObject rb = JsonConvert.DeserializeObject<SearchObject>(obj);
            return rb;
        }
        #endregion

        #region 传感器Json
        /// <summary>
        /// 传感器数据反序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public SensorObject SensorToObj(string obj)
        {
            SensorObject rb = JsonConvert.DeserializeObject<SensorObject>(obj);
            return rb;
        }
        #endregion

        #region 植物信息
        /// <summary>
        /// 植物信息反序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public PlantObject PlantToObject(string obj)
        {
            PlantObject rb = JsonConvert.DeserializeObject<PlantObject>(obj);
            return rb;
        }

        /// <summary>
        /// 发送PlantData
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public JsonResult SendPlantData(List<PlantData> Data)
        {
            var sendJson = new
            {
                rows = Data,
            };
            return Json(sendJson, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region  通用
        /// <summary>
        /// 解析字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public CommonObject GetMsg(string obj)
        {
            CommonObject rb = JsonConvert.DeserializeObject<CommonObject>(obj);
            return rb;
        }

        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="ErrMessage"></param>
        /// <returns></returns>
        public JsonResult SendMsg(string Msg)
        {
            var sendJson = new
            {
                msg = Msg,
            };
            return Json(sendJson, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}