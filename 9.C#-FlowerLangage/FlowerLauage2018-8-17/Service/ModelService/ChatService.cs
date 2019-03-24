using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using FlowerLauage2018_8_17.Entity;
using System.Configuration;
using FlowerLauage2018_8_17.Service;
using FlowerLauage2018_8_17.Entity.JsonObject;

namespace FlowerLauage2018_8_17.Service.ModelService
{
    public class ChatService
    {
        /// <summary>
        /// 保存聊天记录
        /// </summary>
        /// <param name="Data">聊天数据</param>
        public void SaveChat(ChatData ChatData)
        {
            var Data = ChatData;
            Data.ID = BaseIService.creatID.CreatKey();
            if (Data.Role == "客服")
                Data.DialogID = ChatData.ChatRoleID + ChatData.RoleID;
            else
                Data.DialogID = ChatData.RoleID + ChatData.ChatRoleID;
            Data.Date = DateTime.Now;
            SqlIService.ChatService.SaveChat(Data);        //保存聊天记录
        }

        /// <summary>
        /// 获取最近聊天数据
        /// </summary>
        /// <returns></returns>
        public ChatData NewChatData(string UserID)
        {
            var data= SqlIService.ChatService.NewChatData(UserID);
            return data;
        }
        /// <summary>
        /// 验证对话框是否存在
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public int ConfirmChat(ChatData Data)
        {
            string KeyValue = Data.DialogID;
            int num = SqlIService.ChatService.ConfirmChat(KeyValue);
            return num;      //为0存在不为0则不存在
        }
        /// <summary>
        /// 获取进10条数据历史记录
        /// </summary>
        /// <param name="DialogID">对话框ID</param>
        /// <returns></returns>
        public List<ChatData> HistoryChart(string DialogID)
        {
            var Data= SqlIService.ChatService.HistoryData(DialogID);
            return Data;
        }

        /// <summary>
        /// 查询指定时间的历史聊天记录
        /// </summary>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
        public List<ChatData> FindHistoryChart(DateTime StartTime, DateTime EndTime)
        {
            var Data = SqlIService.ChatService.FindHistoryData(StartTime, EndTime);
            return Data;
        }
    }
}