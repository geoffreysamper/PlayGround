using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using log4net;
using log4net.Appender;

namespace Log4NetAndAspNetCustomProperties.Controllers
{
    public class HomeController : Controller
    {
        public static readonly ILog Logger = LogManager.GetLogger(typeof (HomeController));
        
        public ActionResult Index()
        {
            Logger.Info("this is logged from the index");

            return View();
        }

        [HttpGet]
        public JsonResult GetLogs()
        {
            var appender = (MemoryAppender) Logger.Logger.Repository.GetAppenders().First(x => x.GetType() == typeof (MemoryAppender));

            var events = appender.GetEvents().OrderByDescending(x => x.TimeStamp);

            List<string> result = new List<string>();


            foreach (var e in events)
            {
                
                StringWriter sw = new StringWriter();
                appender.Layout.Format(sw, e);
                result.Add(sw.ToString());

            }

            return Json(result,JsonRequestBehavior.AllowGet);
        }

        public ActionResult FormatXml()
        {
            StringWriter wr = new StringWriter();

            string filename = System.Web.HttpContext.Current.Server.MapPath("~/Logs/log-file.xml");
            
            StringBuilder orignal = new StringBuilder();
            orignal.Append("<logs xmlns:log4net=\"http://log4net.apache.org\">");
            orignal.Append(System.IO.File.ReadAllText(filename));
            orignal.Append("</logs>");


            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(orignal.ToString());

            var sb = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = " ";
            settings.NewLineChars = "\n";
            settings.NewLineHandling = NewLineHandling.Replace;
            using (XmlWriter writer = XmlWriter.Create(sb, settings))
            {
                xdoc.Save(writer);
            }

            return Content(sb.Replace(">", "&gt;").Replace("<", "&lt;").Replace("\n", "<br>").Insert(0,"<pre>").Append("</pre>").ToString());

        }




    }
}
