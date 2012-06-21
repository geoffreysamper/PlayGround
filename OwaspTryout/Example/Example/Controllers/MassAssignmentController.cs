using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Example.Models;

namespace Example.Controllers
{
    public class MassAssignmentController : Controller
    {
        //
        // GET: /MassAssignment/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BadGuy()
        {
            return View();
        }


        [HttpPost]

        public ActionResult Edit(MassAssignmentModel model)
        {

            return View(model);
        }

    }
}
