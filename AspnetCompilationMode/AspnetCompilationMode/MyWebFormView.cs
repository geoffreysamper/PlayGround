using System;
using System.Globalization;
using System.IO;
using System.Web.Mvc;

namespace AspnetCompilationMode
{
    public class MyWebFormView : MyBuildManagerView
    {
        // Methods
        public MyWebFormView (ControllerContext controllerContext, string viewPath) : this(controllerContext, viewPath, null, null)
        {
        }

        public MyWebFormView (ControllerContext controllerContext, string viewPath, string masterPath) : this(controllerContext, viewPath, masterPath, null)
        {
        }

        public MyWebFormView(ControllerContext controllerContext, string viewPath, string masterPath, IViewPageActivator viewPageActivator)
            : base(controllerContext, viewPath, viewPageActivator)
        {
            this.MasterPath = masterPath ?? string.Empty;
        }

        protected override void RenderView(ViewContext viewContext, TextWriter writer, object instance)
        {
            ViewPage page = instance as ViewPage;
            if (page != null)
            {
                this.RenderViewPage(viewContext, page);
            }
            else
            {
                ViewUserControl control = instance as ViewUserControl;
                if (control == null)
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "MvcResources.WebFormViewEngine_WrongViewBase", new object[] { base.ViewPath }));
                }
                this.RenderViewUserControl(viewContext, control);
            }
        }

        private void RenderViewPage(ViewContext context, ViewPage page)
        {
            if (!string.IsNullOrEmpty(this.MasterPath))
            {
                page.MasterLocation = this.MasterPath;
            }
            page.ViewData = context.ViewData;
            page.RenderView(context);
        }

        private void RenderViewUserControl(ViewContext context, ViewUserControl control)
        {
            if (!string.IsNullOrEmpty(this.MasterPath))
            {
                //throw new InvalidOperationException(MvcResources.WebFormViewEngine_UserControlCannotHaveMaster);
            }
            control.ViewData = context.ViewData;
            control.RenderView(context);
        }

        // Properties
        public string MasterPath { get; private set; }

     
    }
}

 

 


