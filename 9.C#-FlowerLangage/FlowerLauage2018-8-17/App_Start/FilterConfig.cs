using System.Web;
using System.Web.Mvc;

namespace FlowerLauage2018_8_17
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
