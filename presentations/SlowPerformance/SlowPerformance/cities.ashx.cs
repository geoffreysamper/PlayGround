using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace SlowPerformance
{
    public class City2 {
    public string postcode{get;set;}
    public string gemeente{get;set;}
    public string postcode_hg{get;set;}
    public string hoofdgemeente{get;set;}
    }

    /// <summary>
    /// Summary description for BadJson
    /// </summary>
    public class Cities: IHttpHandler
    {
   
        public void ProcessRequest(HttpContext context)
        {
            string dumstring = "";
            for (int index = 0; index < 10000; index++)
            {
                dumstring += index;
            }


            string content  = System.IO.File.ReadAllText(context.Server.MapPath("~/app_data/cities.json"));

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var list = serializer.Deserialize<IEnumerable<City2>>(content);

            context.Response.Write(serializer.Serialize(list));

            context.Response.ContentType = "application/json";



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