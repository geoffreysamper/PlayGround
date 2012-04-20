using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OutputCachingTryouts
{
    public partial class Cacheview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CustomOutputCacheProvider c = null;


            if (OutputCache.Providers == null)
            {
                return;
            }

            foreach (OutputCacheProvider p in OutputCache.Providers)
            {
                     if (OutputCache.DefaultProviderName.Equals(p.Name, StringComparison.OrdinalIgnoreCase))
                     {
                         c = (CustomOutputCacheProvider)p;
                     }
            }
            if (c != null)
            {
                rpt.DataSource = c.Content;
                rpt.DataBind();
            }
            


        }
    }
}