using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace MemoryIssues
{
    /// <summary>
    /// Summary description for GoodJson
    /// </summary>
    public class GoodJson : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var list  = BadJson.GetAll();

            JsonSerializer serializer = new JsonSerializer();


            serializer.Serialize(context.Response.Output, list);


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