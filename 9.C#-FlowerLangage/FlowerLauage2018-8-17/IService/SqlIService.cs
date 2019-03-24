using FlowerLauage2018_8_17.Fuctions;
using FlowerLauage2018_8_17.Fuctions.SQL;
using FlowerLauage2018_8_17.Service.SQLService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlowerLauage2018_8_17.Service
{
    public class SqlIService
    {
        public static SqlLogin LoginService
        {
            get { return new SqlLogin(); }
        }
        public static SqlFlower FlowerDataService
        {
            get { return new SqlFlower(); }
        }
        public static SqlChat ChatService
        {
            get { return new SqlChat(); }
        }

        public static SqlPlant PlantService
        {
            get { return new SqlPlant(); }
        }
    }
}