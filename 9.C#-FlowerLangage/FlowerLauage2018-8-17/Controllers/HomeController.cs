using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Text;
using System.Net;
using FlowerLauage2018_8_17.IService;
using FlowerLauage2018_8_17.Service;

namespace WebApplication2.Controllers
{

   
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public class MsMultiPartFormData
        {
            private List<byte> formData;
            public String Boundary = "---------------" + DateTime.Now.Ticks.ToString("x");
            private String fieldName = "Content-Disposition: form-data; name=\"{0}\"";
            private String fileContentType = "Content-Type: {0}";
            private String fileField = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"";
            private Encoding encode = Encoding.GetEncoding("UTF-8");
            public MsMultiPartFormData()
            {
                formData = new List<byte>();
            }
            public void AddFormField(String FieldName, String FieldValue)
            {
                String newFieldName = fieldName;
                newFieldName = string.Format(newFieldName, FieldName);
                formData.AddRange(encode.GetBytes("--" + Boundary + "\r\n"));
                formData.AddRange(encode.GetBytes(newFieldName + "\r\n\r\n"));
                formData.AddRange(encode.GetBytes(FieldValue + "\r\n"));
            }
            public void AddFile(String FieldName, String FileName, byte[] FileContent, String ContentType)
            {
                String newFileField = fileField;
                String newFileContentType = fileContentType;
                newFileField = string.Format(newFileField, FieldName, FileName);
                newFileContentType = string.Format(newFileContentType, ContentType);
                formData.AddRange(encode.GetBytes("--" + Boundary + "\r\n"));
                formData.AddRange(encode.GetBytes(newFileField + "\r\n"));
                formData.AddRange(encode.GetBytes(newFileContentType + "\r\n\r\n"));
                formData.AddRange(FileContent);
                formData.AddRange(encode.GetBytes("\r\n"));
            }
            public void AddStreamFile(String FieldName, String FileName, byte[] FileContent)
            {
                AddFile(FieldName, FileName, FileContent, "application/octet-stream");
            }
            public void PrepareFormData()
            {
                formData.AddRange(encode.GetBytes("--" + Boundary + "--"));
            }
            public List<byte> GetFormData()
            {
                return formData;
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public static string HttpPostData(string url, MsMultiPartFormData form, string filePath, string fileKeyName = "file", int timeOut = 360000)
        {
            string result = "";
            WebRequest request = WebRequest.Create(url);
            request.Timeout = timeOut;
            FileStream file = new FileStream(filePath, FileMode.Open);
            byte[] bb = new byte[file.Length];
            file.Read(bb, 0, (int)file.Length);
            file.Close();
            string fileName = Path.GetFileName(filePath);
            form.AddStreamFile(fileKeyName, fileName, bb);
            form.PrepareFormData();
            request.ContentType = "multipart/form-data; boundary=" + form.Boundary;
            request.Method = "POST";
            Stream stream = request.GetRequestStream();
            foreach (var b in form.GetFormData())
            {
                stream.WriteByte(b);
            }
            stream.Close();
            WebResponse response = request.GetResponse();

            using (var httpStreamReader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8")))
            {
                result = httpStreamReader.ReadToEnd();
            }
            response.Close();
            request.Abort();
            return result;
        }

        [HttpPost]
        public JsonResult Upload()
        {
            Stream s = System.Web.HttpContext.Current.Request.InputStream;
            byte[] b = new byte[s.Length];
            s.Read(b, 0, (int)s.Length);
            //return Encoding.UTF8.GetString(b);
            //FileStream file = new FileStream(Server.MapPath("/output.wav"), FileMode.Open);
            //byte[] bb = new byte[file.Length];
            //file.Read(bb, 0, (int)file.Length);
            //file.Close();

            //string fileName = Path.GetFileName(Server.MapPath("/output.wav"));

            //Stream stream = context.Request.GetBufferedInputStream();
            ////stream.WriteByte
            //stream.Close();


            // 设置APPID/AK/SK
            var APP_ID = "14571590";
            var API_KEY = "5ZmBLIqMtOIWhsESUQdRWxAx";
            var SECRET_KEY = "N1LjTmyy1P5hCcK8uNPGIQ7r32ucVTpU";

            var client = new Baidu.Aip.Speech.Asr(API_KEY, SECRET_KEY);
            client.Timeout = 60000;  // 修改超时时间

            //var data = System.IO.File.ReadAllBytes(Server.MapPath("/output.wav"));
            client.Timeout = 1200000; // 若语音较长，建议设置更大的超时时间. ms
            var result = client.Recognize(b, "wav", 8000);

            string Msg = ChatIService.FlowerChat.Answer(result.GetValue("result").ToString());
            

            if (result.GetValue("err_no").ToString() == "0")
            {
                //return Json(result.GetValue("result").ToString());
                 return JsonIService.jsonService.SendMsg(Msg);
            }
            else
            {
                return Json(result.GetValue("err_no").ToString());
            }
        }
    }
}