using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspnetCompilationMode.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Help/

        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult WidgetAction()
        {
            return this.View();
        }

        public ActionResult HtmlAction()
        {
            var html = "<h2>this is text that we have set via the database.</h2>";
            return View("Html", new HtmlModel(){Html = html});
        }


    }

    public class HtmlModel
    {
        public string Html { get; set; }
    }
}
