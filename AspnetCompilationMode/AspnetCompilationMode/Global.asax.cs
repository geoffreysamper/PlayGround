using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspnetCompilationMode
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ViewEngines.Engines.Clear();
            
            ViewEngines.Engines.Add(new MyWebFormViewEngine());
        }

        protected void Application_End()
        {
         
            var a = HostingEnvironment.ShutdownReason;
            

            File.WriteAllText("c:\\temp\\" +typeof(MvcApplication).FullName + " " + a.ToString() +" " + DateTime.Now.Ticks + "txt", a.ToString());

        }

    }

}