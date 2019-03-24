using FlowerLauage2018_8_17.Entity.FindData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlowerLauage2018_8_17.Entity.JsonObject
{
    public class SearchObject
    {
        /// <summary>
        /// 起始时间终止时间查询
        /// </summary>
        public HistroyTime histroyTime { get; set; }
        /// <summary>
        /// 对话框查询
        /// </summary>
        public HistroyTime chatHistory { get; set; }
        
    }
}