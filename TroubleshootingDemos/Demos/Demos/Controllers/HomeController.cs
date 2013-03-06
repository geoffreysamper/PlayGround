using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demos.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult FiddlerDemo()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        
    


        public ActionResult GetNumbers() {
           var range = Enumerable.Range(1,10);

           return Json(range,JsonRequestBehavior.AllowGet);
        }

    }
}
