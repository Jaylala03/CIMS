using System.Web.Mvc;

namespace CIMS.Areas.IncidentList
{
    public class IncidentListAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "IncidentList";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "IncidentList_default",
                "IncidentList/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}