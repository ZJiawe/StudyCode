using FlowerLauage2018_8_17.Entity.JsonObject;
using FlowerLauage2018_8_17.IService;
using FlowerLauage2018_8_17.Service;
using System.Web.Mvc;

namespace FlowerLauage2018_8_17.Controllers
{
    public class FlowerChatController : Controller
    {
        // GET: FlowerChat
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 植物回复信息
        /// </summary>
        /// <param name="querystring"></param>
        /// <returns></returns>
        public JsonResult Answer(string querystring)
        {
            CommonObject rb= JsonIService.jsonService.GetMsg(querystring);
            string Msg = FlowerChatIService.Service.Answer(rb.MsgData.Msg);
            return JsonIService.jsonService.SendMsg(Msg);
        }
    }
}