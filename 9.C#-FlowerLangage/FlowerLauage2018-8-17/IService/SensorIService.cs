using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlowerLauage2018_8_17.Fuctions;
using FlowerLauage2018_8_17.Fuctions.SQL;
using FlowerLauage2018_8_17.Service.SQLService;

namespace FlowerLauage2018_8_17.IService
{
    public class SensorIService
    {
        public static SensorService sensorService
        {
            get { return new SensorService(); }
        }
    }
}