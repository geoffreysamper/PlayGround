using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Security.Application;

namespace Example.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            string sql = "select * from dbo.Company";

            return View(DbHelper.GetCompanies(sql));
        }

        public ActionResult Detail(string id)
        {
            return View(DbHelper.GetCompanyByIsn(id));
        }
      
        public ActionResult Xss()
        {
            return View();
        }
        public ActionResult SqlInjection()
        {
            return View();
        }


      
        public ActionResult AntiXss()
        {
            var dic = new Dictionary<string, string>();

            string javascript = "'this is a string in javas\"cript' ";

            dic.Add("no encoding javascript", javascript);
            dic.Add("Anti Xss encode Javascript", Encoder.JavaScriptEncode(javascript));
            dic.Add("HttpUtilty encode javascript", HttpUtility.JavaScriptStringEncode(javascript));
            dic.Add("no css encode", "/*comment in css*/");
            dic.Add("Anti Css Encode", Encoder.CssEncode("/*comment in css*/"));



            return View(dic);

        }
    }






}
