using FlowerLauage2018_8_17.Entity;
using FlowerLauage2018_8_17.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlowerLauage2018_8_17.Fuctions
{
    public class LoginService
    {
        /// <summary>
        /// 创建与修改用户资料
        /// </summary>
        /// <param name="KeyValue"></param>
        /// <param name="flowerData"></param>
        public void SaveAccount(string KeyValue, Login flowerData)
        {
            if (KeyValue != "")       //更改信息
            {
                var Data = new Login();
                Data.ID = KeyValue;
                Data.Account = flowerData.Account;
                Data.Password = flowerData.Password;
                Data.UserName = flowerData.UserName;
                SqlIService.LoginService.UpdateLoginData(Data);
            }
            else                        //注册
            {
                var Data = new Login();
                Data.ID = BaseIService.creatID.CreatKey();
                Data.Account = flowerData.Account;
                Data.Password = flowerData.Password;
                Data.UserName = flowerData.UserName;
                Data.Role = "用户";
                SqlIService.LoginService.InsertLoginData(Data);
            }
        }
        /// <summary>
        /// 注销用户
        /// </summary>
        /// <param name="KeyValue"></param>
        public void DeleteAccount(string KeyValue)
        {
            SqlIService.LoginService.DeleteAccount(KeyValue);
        }
        /// <summary>
        /// 获取所有用户数据
        /// </summary>
        /// <returns></returns>
        public List<Login> FindUsers()
        {
            return SqlIService.LoginService.FindUsers();
        }
        /// <summary>
        /// 获取指定用户数据
        /// </summary>
        /// <returns></returns>
        public Login FindUser(string KeyValue)
        {
            return SqlIService.LoginService.FindUser(KeyValue);
        }
    }
}
