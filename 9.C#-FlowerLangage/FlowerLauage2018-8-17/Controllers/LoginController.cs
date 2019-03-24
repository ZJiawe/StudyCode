using FlowerLauage2018_8_17.Entity;
using FlowerLauage2018_8_17.Entity.JsonObject;
using FlowerLauage2018_8_17.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlowerLauage2018_8_17.Controllers
{
    public class LoginController : Controller
    {
        #region 视图功能
        /// <summary>
        /// 登陆界面
        /// </summary>
        /// <returns></returns>
        public ActionResult index()
        {
            return View();
        }
        /// <summary>
        /// 注册界面
        /// </summary>
        /// <returns></returns>
        public ActionResult reg()
        {
            return View();
        }
        #endregion

        #region 信息验证
        /// <summary>
        /// 登陆信息验证
        /// </summary>
        /// <param name="JsonMessage"></param>
        /// <returns></returns>
        public JsonResult UserLoginConfirm(string querystring)
        {
            UserObject rb = JsonIService.jsonService.UserToObj(querystring);
            Login Data = SqlIService.LoginService.UserLogin(rb.LoginData.Account, rb.LoginData.Password);
            int key = ConfirmIService.Confirm.LoginConfirm(Data);
            string LoginMsg = ConfirmIService.Confirm.ErrorMessage(key);
            if (LoginMsg == "登陆成功")
            {
                ConfigurationManager.AppSettings["UserID"] = Data.ID;
                ConfigurationManager.AppSettings["UserName"] = Data.UserName;
             }
            return JsonIService.jsonService.LoginJson(Data, key, LoginMsg);
        }
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="querystring"></param>
        /// <returns></returns>
        public JsonResult CreatAccount(string querystring)
        {
            UserObject rb = JsonIService.jsonService.UserToObj(querystring);
            string Error = ConfirmIService.Confirm.AccountCorrect(rb.LoginData.Account);
            var keyValue = "";
            if(Error== "账号未注册")
                LoginIService.loginService.SaveAccount(keyValue, rb.LoginData);
            return JsonIService.jsonService.SendMsg(Error);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 更改用户资料
        /// </summary>
        /// <param name="querystring"></param>
        public void UpDateAccount(string querystring)
        {
            UserObject rb = JsonIService.jsonService.UserToObj(querystring);
            var keyValue = rb.LoginData.ID;
            LoginIService.loginService.SaveAccount(keyValue, rb.LoginData);
        }
        #endregion

    }
}