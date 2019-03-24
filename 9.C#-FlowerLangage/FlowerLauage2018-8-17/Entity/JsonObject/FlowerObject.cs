using FlowerLauage2018_8_17.Entity.FindData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlowerLauage2018_8_17.Entity.JsonObject
{
    public class FlowerObject
    {
        public FlowerData flowerData { get; set; }
        public List<FlowerData> flowerDataList { get; set; }
        public FlowerDataDetail flowerDataDetail { get; set; }
        public List<FlowerDataDetail> flowerDataDetailList { get; set; }

    }
}