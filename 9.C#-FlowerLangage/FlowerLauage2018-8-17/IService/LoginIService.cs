using FlowerLauage2018_8_17.Entity;
using FlowerLauage2018_8_17.Fuctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlowerLauage2018_8_17.Service
{
    public class LoginIService
    {
        public static LoginService loginService
        {
            get { return new LoginService(); }
        }
    }
}