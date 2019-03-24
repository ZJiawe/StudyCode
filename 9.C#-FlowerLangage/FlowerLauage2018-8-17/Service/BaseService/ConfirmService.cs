using FlowerLauage2018_8_17.Entity;
using FlowerLauage2018_8_17.Service;
using System;
using System.Configuration;

namespace FlowerLauage2018_8_17.Fuctions
{
    public class ConfirmService
    {
        string ConfirmFlowerData = ConfigurationManager.AppSettings["ConfirmFlowerData"];
        string Announcement= ConfigurationManager.AppSettings["Announcement"];
        string CustomerChatCorrect = ConfigurationManager.AppSettings["CustomerChatCorrect"];
        string ServiceChatCorrect = ConfigurationManager.AppSettings["ServiceChatCorrect"];
        int Count = Convert.ToInt32(ConfigurationManager.AppSettings["ChatCount"]);
        #region 账号验证
        /// <summary>
        /// 登陆结果
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public int LoginConfirm(Login Data)
        {
            if (Data.Account == "")
                return 1;                //账号不存在
            else if(Data.Account != "" && Data.Password == "")
                return 2;                //密码错误
            else
            return 0;                   //验证成功
        }
        /// <summary>
        /// 错误信息验证
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public string ErrorMessage(int Key)
        {
            if (Key == 0)
                return "登陆成功";          //账号不存在
            else if (Key == 1)
                return "账号错误";                //密码错误
            else
                return "密码错误";                   //验证成功
        }
        /// <summary>
        /// 账号重复验证
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public string AccountCorrect(string Data)
        {
            var li = SqlIService.LoginService.FindUser(Data);
            if (li.Account == "")
                return "账号未注册";
            else
                return "账号已注册";
        }
        #endregion

        #region 花信息验证
        /// <summary>
        /// 验证花信息是否重复
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int FlowerDataDetailCorrect(FlowerDataDetail data)
        { 
            if (ConfirmFlowerData != data.ID)
            {
                ConfigurationManager.AppSettings["ConfirmFlowerData"] = data.ID;
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 验证公告栏信息是否重复
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string AnnouncementCorrect(string Msg)
        {
            if (Announcement != Msg)
            {
                ConfigurationManager.AppSettings["Announcement"] = Msg;
                return Msg;
            }
            else
            {
                return "信息重复";
            }
        }
        
        /// <summary>
        /// 检测花的状态是否异常
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string DetectFlower(FlowerDataDetail data,string Condition="27~38;25~26")
        {
            string HumidityMsg = "";
            string TemperatureMsg = "";
            string LightMsg = "";
            string[] conditions = Condition.Split(new char[] { '~',';' }); //Condition转换成具体的Condition
            decimal[] Humidity = { Convert.ToDecimal(conditions[0]), Convert.ToDecimal(conditions[1]) };
            decimal[] Temperature = { Convert.ToDecimal(conditions[2]), Convert.ToDecimal(conditions[3]) };
            if (Convert.ToDecimal(data.Humidity) >= Humidity[1])   //湿度
                HumidityMsg= "花的水分过高!!!需要降低湿度!";
            else if (Convert.ToDecimal(data.Humidity) <= Humidity[0])
                HumidityMsg= "花的水分过低!!!需要提高湿度!";
            if (Convert.ToDecimal(data.Temperature) >= Temperature[1])  //温度
                TemperatureMsg= "花的温度过高!!!需要降低温度！";
            else if (Convert.ToDecimal(data.Temperature) <= Temperature[0])
                TemperatureMsg= "花的温度过低!!!需要提高温度！";
            if (Convert.ToDecimal(data.Light) >= 26)              //光照
                LightMsg= "花的光照度过高!!!需要降低瀑光度！";
            else if (Convert.ToDecimal(data.Light) <= 25)
                LightMsg= "花的光照度过高低!!!需要提高瀑光度！";
            if (HumidityMsg != "" || TemperatureMsg != "" || LightMsg != "")
                return HumidityMsg + ";" + TemperatureMsg + ";" + LightMsg;
            else
                return "一切正常";
        }
        #endregion

        #region 聊天信息验证
        /// <summary>
        /// 聊天信息重复验证
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string ChatCorrect(ChatData Data)
        {
            if (Data.Role == "客服" && CustomerChatCorrect != Data.ID && Count >0)
            {
                ConfigurationManager.AppSettings["CustomerChatCorrect"] = Data.ID;
                return "";
            }
            else if (Data.Role == "用户" && ServiceChatCorrect != Data.ID && Count > 0)
            {
                ConfigurationManager.AppSettings["ServiceChatCorrect"] = Data.ID;
                return "";
            }
            else
            {
                Count++;
                ConfigurationManager.AppSettings["ChatCount"] = Count.ToString();
                return "信息重复";
            }
        }
        #endregion
    }
}