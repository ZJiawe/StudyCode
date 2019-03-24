using FlowerLauage2018_8_17.Entity;
using FlowerLauage2018_8_17.Entity.JsonObject;
using FlowerLauage2018_8_17.IService;
using FlowerLauage2018_8_17.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlowerLauage2018_8_17.Controllers
{
    public class ChatController : Controller
    {
        #region 视图功能
        public ActionResult talk()
        {
            return View();
        }
        public ActionResult response()
        {
            return View();
        }

        public ActionResult voice()
        {
            return View();
        }
        #endregion

        #region 客服聊天

        #region 获取数据
        /// <summary>
        /// 获取最近十条数据
        /// </summary>
        /// <param name="qureystring">对话框ID</param>
        /// <returns></returns>
        public JsonResult GetChat(string qureystring)
        {
            var ChatDatas= ChatIService.Chat.HistoryChart(qureystring);
            return JsonIService.jsonService.SendChats(ChatDatas);
        }

        /// <summary>
        /// 查询最近聊天记录
        /// </summary>
        public JsonResult GetHistoryChat(string querystring)
        {
            SearchObject rb = JsonIService.jsonService.SearchToObject(querystring);
            DateTime StartTime = Convert.ToDateTime(rb.histroyTime.StartTime);
            DateTime EndTime = Convert.ToDateTime(rb.histroyTime.EndTime);
            List<ChatData> ChatDatas = ChatIService.Chat.FindHistoryChart(StartTime, EndTime);
            return JsonIService.jsonService.SendChats(ChatDatas);
        }

        /// <summary>
        /// 获取用户聊天记录     ：客服界面调用
        /// </summary>
        /// <returns></returns>
        public JsonResult GetCustomerChat()
        {
            var EmptyData = new ChatData();
            var Data = ChatIService.Chat.NewChatData(ConfigurationManager.AppSettings["UserID"]);
            string Correct = ConfirmIService.Confirm.ChatCorrect( Data); //验证是否是重复消息
            if (Correct != "信息重复" && Data.Role == "用户")
                return JsonIService.jsonService.SendChat( Data, Data.Role);
            else
                return JsonIService.jsonService.SendChat( EmptyData, "");
        }

        /// <summary>
        /// 获取客服聊天记录     ： 用户界面调用
        /// </summary>
        /// <returns></returns>
        public JsonResult GetServiceChat()
        {
            var EmptyData = new ChatData();
            var Data = ChatIService.Chat.NewChatData(ConfigurationManager.AppSettings["UserID"]);
            string Correct = ConfirmIService.Confirm.ChatCorrect(Data); //验证是否是重复消息
            if (Correct != "信息重复"&&Data.Role=="客服")
                    return JsonIService.jsonService.SendChat(Data, Data.Role);
            else
                return JsonIService.jsonService.SendChat(EmptyData, "");
        }

        #endregion

        #region 存储数据
        /// <summary>
        /// 保存聊天记录
        /// </summary>
        public void SaveChat(string querystring)
        {
            var rb = JsonIService.jsonService.ChatToObj(querystring);
            ChatIService.Chat.SaveChat(rb.chatData);
        }
        #endregion

        #endregion

        #region  与花聊天
        /// <summary>
        /// 获取花的回答
        /// </summary>
        /// <param name="querystring"></param>
        /// <returns></returns>
        public JsonResult GetAnswer(string querystring)
        {
            CommonObject rb = JsonIService.jsonService.GetMsg(querystring);
            string Msg = ChatIService.FlowerChat.Answer(rb.MsgData.Msg);
            return JsonIService.jsonService.SendMsg(Msg);
        }

        /// <summary>
        /// 插入用户指定对答
        /// </summary>
        /// <param name="querystring"></param>
        public void SaveAns(string querystring)
        {
            ChatObject rb = JsonIService.jsonService.ChatToObj(querystring);
            ChatIService.FlowerChat.InsertData(rb.answerData);
        }
        #endregion
    }
}