using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Log4NetAndAspNetCustomProperties.Log4NetImpl
{
    public class UrlProperty
    {
        public override string ToString()
        {
            if (null != HttpContext.Current)
            {
                return HttpContext.Current.Request.Url.AbsoluteUri;
            }

            return null;
        }
    }
}