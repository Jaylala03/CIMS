using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web.Mvc;

using  CIMS.Models;
using System.Web;

namespace CIMS.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class CheckLoginAttribute : ActionFilterAttribute
    {


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var httpContext = new HttpContextWrapper(HttpContext.Current);
            string originalPath = HttpContext.Current.Request.Url.PathAndQuery;
            // string originalPath = HttpContext.Current.Request.Path;
            string url ="~/Account/Login?returnUrl="+HttpUtility.UrlEncode(originalPath);
            if (System.Web.HttpContext.Current.Session["UserName"] == null)
            {

                

                filterContext.Result = new RedirectResult(url);
                return;


            }
        }

    }


}

