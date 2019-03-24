using FlowerLauage2018_8_17.Fuctions;
using FlowerLauage2018_8_17.Service.ModelService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlowerLauage2018_8_17.IService
{
    public class FlowerDataIService
    {
        public static FlowerDataService flowerDataService
        {
            get { return new FlowerDataService(); }
        }
    }
}