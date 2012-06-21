using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Example.Models
{
    #region hidden
    // [Bind(Include = "Name")]
    #endregion
    public class MassAssignmentModel
    {
        public string Name { get; set; }
        public string Secret { get; set; }
    }
}