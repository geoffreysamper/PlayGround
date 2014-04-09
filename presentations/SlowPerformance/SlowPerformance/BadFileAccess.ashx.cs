using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlowPerformance
{
    /// <summary>
    /// Summary description for BadFileAccess
    /// </summary>
    public class BadFileAccess : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
            for (int i = 0; i < 100; i++)
            {
                System.IO.File.ReadAllText(context.Server.MapPath("~/app_data/cities.json"));
            }
            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}