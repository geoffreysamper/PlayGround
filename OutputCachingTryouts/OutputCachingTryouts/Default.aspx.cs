using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OutputCachingTryouts
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.AddValidationCallback(CacheValidationCallback, null);
            
        }

        private  static void CacheValidationCallback(HttpContext context, object data, ref  HttpValidationStatus status)
        {
            if (!string.IsNullOrEmpty(context.Request.QueryString["ignore"]))
            {
                status = HttpValidationStatus.IgnoreThisRequest;
               
                
            }

        }    
    }
}
