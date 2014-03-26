using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using log4net;
using Log4NetAndAspNetCustomProperties.Log4NetImpl;

namespace Log4NetAndAspNetCustomProperties
{
 
    
    
    public class MvcApplication : System.Web.HttpApplication
    {
        
        private static ILog Logger = LogManager.GetLogger("backgroundlogger");

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalContext.Properties["Url"] = new UrlProperty();
        }

        protected void Application_BeginRequest()
        {
            
        }




        

    }
}

