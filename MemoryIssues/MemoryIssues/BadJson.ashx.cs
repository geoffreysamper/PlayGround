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
        static Lazy<IEnumerable<City>> _lazy = new Lazy<IEnumerable<City>>(CreateGetAll);

        public void ProcessRequest(HttpContext context)
        {
         
            StringBuilder builder= new StringBuilder();


            JavaScriptSerializer js = new JavaScriptSerializer();

           string content=  js.Serialize(GetAll());

          context.Response.Write(content);



        }

        public static IEnumerable<City> GetAll() { return _lazy.Value; }
        private static IEnumerable<City> CreateGetAll()
        {
            for(int index =0; index <2000;index++)
            {
                yield return new City(index, "cit".PadRight(1000,'a'));
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