using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.UI;

namespace AspnetCompilationMode
{
    public sealed class ActionControl : Control
    {
        public ActionControl()
        {
            EnableViewState = false;
        }

        public string Controller { get; set; }

        public string Action { get; set; }


        protected override void Render(HtmlTextWriter writer)
        {
            ViewPage page = (ViewPage)this.Page;
            page.Html.RenderAction(Action, Controller);            
            base.Render(writer);
        }


    }
}