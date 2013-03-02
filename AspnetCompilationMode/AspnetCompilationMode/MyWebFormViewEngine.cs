using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspnetCompilationMode
{
    public class MyWebFormViewEngine : System.Web.Mvc.WebFormViewEngine
    {
        protected override System.Web.Mvc.IView CreateView(System.Web.Mvc.ControllerContext controllerContext, string viewPath, string masterPath)
        {
            return new MyWebFormView(controllerContext,viewPath,masterPath);

        }
        protected override System.Web.Mvc.IView CreatePartialView(System.Web.Mvc.ControllerContext controllerContext, string partialPath)
        {
            return new MyWebFormView(controllerContext, partialPath, null, base.ViewPageActivator);

        }
    }
}