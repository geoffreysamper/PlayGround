using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SlowPerformance.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {

            return View();
        }

        public async Task<ActionResult> AsyncAwaitBad()
        {
            var result = await DownloadPageAsync();

            return Content(result);
        }

        private Task<string> DownloadPageAsync()
        {
            var task = new Task<string>(() =>
            {
                var client = new WebClient();
                var result = client.DownloadString("http://api.duckduckgo.com/?q=DuckDuckGo&format=json&pretty=1");

                return result;
            });

            return task;
        }


        public async Task<ActionResult> AsyncAwaitGood()
        {
            var client = new System.Net.Http.HttpClient();
            string result = await client.GetStringAsync("http://api.duckduckgo.com/?q=DuckDuckGo&format=json&pretty=1");
            return Content(result);
        }




    }
}
