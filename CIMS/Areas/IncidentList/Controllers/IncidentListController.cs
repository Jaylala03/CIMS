using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using CIMS.ActionLayer.IncidentList;
using CIMS.Models;
using CIMS.BaseLayer.IncidentList;
using CIMS.Helpers;
using CIMS.Utility;

namespace CIMS.Areas.IncidentList.Controllers
{
    public class IncidentListController : Controller
    {
        DataSet dsResult = new DataSet();
        DataTable dtResult = new DataTable();
        IncidentListAction incidentListAction = new IncidentListAction();
        CIMS.BaseLayer.ActionResult actionResult = new CIMS.BaseLayer.ActionResult();

        // GET: IncidentList/IncidentList
        public ActionResult Index()
        {
            return View();
        }

        #region Method IncidentList_print

       // [HttpPost]
        public JsonResult IncidentList_print(string type, string startDate, string endDate)
        {
            IncidentListModel incidentListModel = new IncidentListModel();
            string jsonString = string.Empty;
            List<IncidentListModel> incidentList = new List<IncidentListModel>();
            try
            {

                IncidentListBase incidentListBase = new IncidentListBase();
                incidentListBase.Type = type;
                incidentListBase.StartDate = startDate;
                incidentListBase.EndDate = endDate;

                actionResult = incidentListAction.IncidentList_print(incidentListBase);

                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr><td class='td-border'>" + actionResult.dtResult.Rows[i]["IncidentDate"]
                            + "</td><td class='td-border'>" + actionResult.dtResult.Rows[i]["Name"] + "</td><td class='td-border'>" + actionResult.dtResult.Rows[i]["NatureOfEvent"]
                            + "</td><td class='td-border'>" + actionResult.dtResult.Rows[i]["ShortDescriptor"] + "</td><td class='td-border'>" + actionResult.dtResult.Rows[i]["Status"]
                            + "</td><td class='td-border'>" + actionResult.dtResult.Rows[i]["Location"];
                        jsonString += "</tr>";
                    }
                }
                else
                {
                    jsonString = "fail";
                }
            }
            catch (Exception ex)
            {
                jsonString = "-1";
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}