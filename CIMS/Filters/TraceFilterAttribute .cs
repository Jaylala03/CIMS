using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Linq;
using System.Web.Mvc;

using System.Globalization;
using System.Text;
using System.Web.Routing;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using CIMS.Models;


namespace CIMS.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class CheckPermissionAttribute : ActionFilterAttribute
    {
        
     
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
            int action = 0;
            bool status = false;
            if (filterContext.HttpContext.Session["Admin"] != null)
            {
                int userId = Convert.ToInt32(filterContext.HttpContext.Session["Admin"]);
                string[] permission = CheckAdminPermissions.permission(controller, userId);


                if (permission != null)
                {
                    action = Convert.ToInt32(permission[1]);
                    status = Convert.ToBoolean(permission[0]);
                }
            }

            else if (filterContext.HttpContext.Session["UserId"] != null)
            {
                int userId = Convert.ToInt32(filterContext.HttpContext.Session["UserId"]);
                string[] permission = CheckPermissions.permission(controller, userId);


                if (permission != null)
                {
                    action = Convert.ToInt32(permission[1]);
                    status = Convert.ToBoolean(permission[0]);
                }
            }
            if (status == false)
            {
                string url = "~/Home/NoPermission";
                filterContext.Result = new RedirectResult(url);
            }
            filterContext.Controller.ViewBag.Action = action;
            filterContext.Controller.ViewBag.Status = status;
        }
        

        
    }
}
