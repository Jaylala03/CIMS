using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web.Mvc;
using CIMS.Models;
using System.Web;

namespace CIMS.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class CheckRoleAttribute : ActionFilterAttribute
    {


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (System.Web.HttpContext.Current.Session["AdminId"] == null && System.Web.HttpContext.Current.Session["RoleName"].ToString() != "Super Admin")
            {
                string url = "~/Home/NoPermission";
                filterContext.Result = new RedirectResult(url);
                return;
            }
        }


    }
}
