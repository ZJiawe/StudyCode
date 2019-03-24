using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlowerLauage2018_8_17.Entity.FindData
{
    public class HistroyTime
    {
        //private DateTime startTime = Convert.ToDateTime("2000-1-1 10:00:00");
        //private DateTime endTime = DateTime.Now;
        /// <summary>
        /// 查询起始时间
        /// </summary>
        public DateTime StartTime { set; get; }
        /// <summary>
        /// 查询终止时间
        /// </summary>
        public DateTime EndTime { set; get; }

        public string FlowerName { set; get; }
    }
}