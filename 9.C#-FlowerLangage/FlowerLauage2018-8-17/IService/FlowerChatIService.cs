using FlowerLauage2018_8_17.Fuctions;
using FlowerLauage2018_8_17.Fuctions.SQL;
using FlowerLauage2018_8_17.Service.ModelService;
using FlowerLauage2018_8_17.Service.SQLService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlowerLauage2018_8_17.IService
{
    public class FlowerChatIService
    {
        public static FlowerChatService Service
        {
            get { return new FlowerChatService(); }
        }
    }
}