using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlowerLauage2018_8_17.Fuctions
{
    public class CreatIDService
    {
        public string CreatKey()
        {
            Random R = new Random();
            string strDateTimeNumber = DateTime.Now.ToString("yyyyMMddHHmmssms");
            string strRandomResult = R.Next(1, 1000).ToString();
            return strDateTimeNumber + strRandomResult;
        }
    }
}