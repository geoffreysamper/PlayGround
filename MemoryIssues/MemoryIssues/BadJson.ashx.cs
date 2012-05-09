using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace MemoryIssues
{
    /// <summary>
    /// Summary description for BadJson
    /// </summary>
    public class BadJson : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
         
            StringBuilder builder= new StringBuilder();


            JavaScriptSerializer js = new JavaScriptSerializer();

           string content=  js.Serialize(GetAll());

          context.Response.Write(content);



        }

        public static IEnumerable<City> GetAll()
        {
            for(int index =0; index <10000;index++)
            {
                yield return new City(index, "cityname");
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

    public class City
    {
        private int _id;
        private string _name;

        public City(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }

}