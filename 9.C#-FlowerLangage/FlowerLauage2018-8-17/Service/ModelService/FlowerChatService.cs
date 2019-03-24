using FlowerLauage2018_8_17.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FlowerLauage2018_8_17.Service.ModelService
{
    public class FlowerChatService
    {
        /// <summary>
        /// 植物回复信息
        /// </summary>
        /// <param name="Str">问句</param>
        /// <returns></returns>
        public string Answer(string Str)
        {
            Dictionary<string, string> Answers = new Dictionary<string, string>();
            List<AnswerData> UserData = SqlIService.ChatService.GetAnswerUserList(ConfigurationManager.AppSettings["UserID"]);
            List<AnswerData> SysData = SqlIService.ChatService.GetAnswerSysList();
            string AnswerKey = "";





        //                           添加字典元素            手动                     */

        //Answers.Add("你好", "你好呀，主人教我打招呼时候要懂礼貌");
        //Answers.Add("早上好", "嗯，又是充满活力的一天呐！");
        //Answers.Add("中午好", "不要忘记午休呀，否者下午会没精神的呢");
        //Answers.Add("晚安", "晚安，愿你一晚好梦");
        Answers.Add("NoFind", "人类的语言真难懂吖");
        Answers.Add("天气", "福州10月28日天气晴，早晚温度12至26度，白天到夜间东北风，中南部沿海6到7级阵风");
            //                          添加字典元素            手动                       */

            //自动添加字典元素      用户
            foreach (var item in UserData)
            {
                Answers.Add(item.AnsKey, item.AnsValue);
            }

            //自动添加字典元素      系统
            foreach (var item in SysData)
            {
                Answers.Add(item.AnsKey, item.AnsValue);
            }

            //遍历字典
            foreach (var key in Answers.Keys)
            {
                if (Str.Contains(key))
                    AnswerKey = key;               //找到对应的语句
            }

            if (AnswerKey != "")
                return Answers[AnswerKey];
            else
                return Answers["NoFind"];

        }

        /// <summary>
        /// 添加用户指定对话
        /// </summary>
        /// <param name="Data"></param>
        public void InsertData(AnswerData Data)
        {
            Data.ID = BaseIService.creatID.CreatKey();
            if (ConfigurationManager.AppSettings["UserID"] == "123456")
                Data.Role = "系统";
            else
                Data.Role = "用户";
            Data.UserID = ConfigurationManager.AppSettings["UserID"];
            SqlIService.ChatService.InsertAns(Data);
        }


    }
}