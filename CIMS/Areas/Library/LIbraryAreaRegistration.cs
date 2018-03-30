using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CIMS.Areas.Library
{
    public class LibraryAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Library";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Library_default",
                "Library/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}