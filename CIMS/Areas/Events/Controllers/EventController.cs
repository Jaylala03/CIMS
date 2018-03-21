using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CIMS.ActionLayer.Events;
using CIMS.BaseLayer.Events;
using CIMS.Filters;
using CIMS.Helpers;
using CIMS.Models;
using CIMS.Utility;
using System.Data;
using System.IO;
using System.Text;

namespace CIMS.Areas.Events.Controllers
{
    [CheckLogin]
    [CheckPermissionAttribute]
    public class EventController : Controller
    {
        #region Declaration
        EventBase EventBase = new EventBase();
        EventAction EventAction = new EventAction();
        CIMS.BaseLayer.ActionResult actionResult = new CIMS.BaseLayer.ActionResult();
        List<SelectListItem> LocationList = new List<SelectListItem>();
        List<SelectListItem> EventCodeList = new List<SelectListItem>();
        List<SelectListItem> InitiatedByList = new List<SelectListItem>();
        List<SelectListItem> DispatchList = new List<SelectListItem>();
        List<SelectListItem> DispatchUnitCodesList = new List<SelectListItem>();
        List<SelectListItem> DispatchPriorityList = new List<SelectListItem>();
        List<SelectListItem> AttachedEventList = new List<SelectListItem>();
        #endregion
        public List<EventModel> GetEventList()
        {
            List<EventModel> lstEventModel = new List<Models.EventModel>();
            EventBase model = new EventBase();
            model.UserID = Convert.ToString(Session["UserID"]);
            model.RoleID = Convert.ToInt32(Session["RoleId"]);

            actionResult = EventAction.Event_LoadById(model);

            if (actionResult.IsSuccess)
            {
                lstEventModel = (from DataRow row in actionResult.dtResult.Rows
                                 select new EventModel
                                 {
                                     FilePath = row["FilePath"] != DBNull.Value ? Convert.ToString(row["FilePath"]) : null,
                                     EventID = row["EventID"] != DBNull.Value ? Convert.ToInt32(row["EventID"]) : 0,
                                     AttachedEvent = row["AttachedEvent"] != DBNull.Value ? Convert.ToInt32(row["AttachedEvent"]) : 0,
                                     EventNumber = row["EventNumber"] != DBNull.Value ? Convert.ToInt32(row["EventNumber"]) : 0,
                                     Camera = row["Camera"] != DBNull.Value ? row["Camera"].ToString() : "",
                                     DutyDesc = row["DutyDesc"] != DBNull.Value ? row["DutyDesc"].ToString() : "",
                                     EndTime = row["EndTime"] != DBNull.Value ? row["EndTime"].ToString() : "",

                                     EventDate = row["EventDate"] != DBNull.Value ? row["EventDate"].ToString() : "",
                                     UD21 = row["UD21"] != DBNull.Value ? row["UD21"].ToString() : "",
                                     EventTime = row["EventTime"] != DBNull.Value ? row["EventTime"].ToString() : "",
                                     FromCode = row["Initiated"] != DBNull.Value ? row["Initiated"].ToString() : "",
                                     FromForm = row["FromForm"] != DBNull.Value ? row["FromForm"].ToString() : "",
                                     FromNumber = row["FromNumber"] != DBNull.Value ? row["FromNumber"].ToString() : "",

                                     KeyEvent = row["KeyEvent"] != DBNull.Value ? Convert.ToBoolean(row["KeyEvent"]) : false,
                                     Location = row["Location"] != DBNull.Value ? row["Location"].ToString() : "",
                                     NatureCode = row["NatureOfCode"] != DBNull.Value ? row["NatureOfCode"].ToString() : "",
                                     NatureDesc = row["NatureDesc"] != DBNull.Value ? row["NatureDesc"].ToString() : "",
                                     RoleName = row["RoleName"] != DBNull.Value ? row["RoleName"].ToString() : "",
                                     Site = row["Site"] != DBNull.Value ? row["Site"].ToString() : "",
                                     UD20 = row["UD20"] != DBNull.Value ? row["UD20"].ToString() : "",
                                     UD22 = row["UD22"] != DBNull.Value ? row["UD22"].ToString() : "",
                                     UD23 = row["UD23"] != DBNull.Value ? row["UD23"].ToString() : "",
                                     UD24 = row["UD24"] != DBNull.Value ? row["UD24"].ToString() : "",
                                     UD25 = row["UD25"] != DBNull.Value ? row["UD25"].ToString() : "",
                                     UserID = row["UserID"] != DBNull.Value ? row["UserID"].ToString() : ""

                                 }).ToList();

            }
            return lstEventModel;
        }
        public JsonResult JSONEventList(DataTableAjaxPostModel model)
        {
            var result = GetEventList();
            return Json(new
            {
                // this is what datatables wants sending back
                draw = model.draw,
                recordsTotal = result.Count,
                recordsFiltered = result.Count,
                data = result
            });
            //// action inside a standard controller
            //int filteredResultsCount;
            //int totalResultsCount;
            //var res = YourCustomSearchFunc(model, out filteredResultsCount, out totalResultsCount);

            //var result = new List<YourCustomSearchClass>(res.Count);
            //foreach (var s in res)
            //{
            //    // simple remapping adding extra info to found dataset
            //    result.Add(new YourCustomSearchClass
            //    {
            //        EmployerId = User.ClaimsUserId(),
            //        Id = s.Id,
            //        Pin = s.Pin,
            //        Firstname = s.Firstname,
            //        Lastname = s.Lastname,
            //        RegistrationStatusId = DoSomethingToGetIt(s.Id),
            //        Address3 = s.Address3,
            //        Address4 = s.Address4
            //    });
            //};

            //return Json(new
            //{
            //    // this is what datatables wants sending back
            //    draw = model.draw,
            //    recordsTotal = totalResultsCount,
            //    recordsFiltered = filteredResultsCount,
            //    data = result
            //});
        }

        public ActionResult EventList(int EventID = 0)
        {
            EventModel EventModel = new EventModel();
            List<EventModel> lstEventModel = new List<Models.EventModel>();
            EventBase model = new EventBase();
            model.UserID = Convert.ToString(Session["UserID"]);
            model.RoleID = Convert.ToInt32(Session["RoleId"]);

            actionResult = EventAction.Event_LoadById(model);

            if (actionResult.IsSuccess)
            {
                lstEventModel = (from DataRow row in actionResult.dtResult.Rows
                                 select new EventModel
                                 {
                                     FilePath = row["FilePath"] != DBNull.Value ? Convert.ToString(row["FilePath"]) : null,
                                     EventID = row["EventID"] != DBNull.Value ? Convert.ToInt32(row["EventID"]) : 0,
                                     AttachedEvent = row["AttachedEvent"] != DBNull.Value ? Convert.ToInt32(row["AttachedEvent"]) : 0,
                                     EventNumber = row["EventNumber"] != DBNull.Value ? Convert.ToInt32(row["EventNumber"]) : 0,
                                     Camera = row["Camera"] != DBNull.Value ? row["Camera"].ToString() : "",
                                     DutyDesc = row["DutyDesc"] != DBNull.Value ? row["DutyDesc"].ToString() : "",
                                     EndTime = row["EndTime"] != DBNull.Value ? row["EndTime"].ToString() : "",

                                     EventDate = row["EventDate"] != DBNull.Value ? row["EventDate"].ToString() : "",
                                     UD21 = row["UD21"] != DBNull.Value ? row["UD21"].ToString() : "",
                                     EventTime = row["EventTime"] != DBNull.Value ? row["EventTime"].ToString() : "",
                                     FromCode = row["Initiated"] != DBNull.Value ? row["Initiated"].ToString() : "",
                                     FromForm = row["FromForm"] != DBNull.Value ? row["FromForm"].ToString() : "",
                                     FromNumber = row["FromNumber"] != DBNull.Value ? row["FromNumber"].ToString() : "",

                                     KeyEvent = row["KeyEvent"] != DBNull.Value ? Convert.ToBoolean(row["KeyEvent"]) : false,
                                     Location = row["Location"] != DBNull.Value ? row["Location"].ToString() : "",
                                     NatureCode = row["NatureOfCode"] != DBNull.Value ? row["NatureOfCode"].ToString() : "",
                                     NatureDesc = row["NatureDesc"] != DBNull.Value ? row["NatureDesc"].ToString() : "",
                                     RoleName = row["RoleName"] != DBNull.Value ? row["RoleName"].ToString() : "",
                                     Site = row["Site"] != DBNull.Value ? row["Site"].ToString() : "",
                                     UD20 = row["UD20"] != DBNull.Value ? row["UD20"].ToString() : "",
                                     UD22 = row["UD22"] != DBNull.Value ? row["UD22"].ToString() : "",
                                     UD23 = row["UD23"] != DBNull.Value ? row["UD23"].ToString() : "",
                                     UD24 = row["UD24"] != DBNull.Value ? row["UD24"].ToString() : "",
                                     UD25 = row["UD25"] != DBNull.Value ? row["UD25"].ToString() : "",
                                     UserID = row["UserID"] != DBNull.Value ? row["UserID"].ToString() : ""

                                 }).ToList();

            }
            EventModel.ListEventModel = lstEventModel;
            return View(EventModel);
        }

        

        //
        // GET: /Events/Event/
        public ActionResult EventDetail(int EventID = 0, int EventPictureID = 0)
        {
            CIMS.ActionLayer.Setting.SettingAction settingAction = new CIMS.ActionLayer.Setting.SettingAction();
            ViewBag.EventPictureID = EventPictureID;
            EventModel EventModel = new EventModel();
            EventReviewModel EventReviewModel = new Models.EventReviewModel();
            List<EventModel> lstEventModel = new List<Models.EventModel>();
            EventReviewBase EventReviewBase = new EventReviewBase();
            EventCopyModel EventCopyModel = new Models.EventCopyModel();
            EventCopyBase EventCopyBase = new EventCopyBase();
            PictureBase PictureBase = new BaseLayer.Events.PictureBase();
            List<EventReviewModel> ListEventReviewTableModel = new List<EventReviewModel>();
            PictureModel PictureModel = new PictureModel();
            List<PictureModel> ListPictureModel = new List<PictureModel>();
            EventCopyBase.EventID = EventID;
            PictureBase.EventID = EventID;
            EventReviewBase.EventID = EventID;
            EventBase.Part = "Initiated By";
            EventBase.EventID = EventID;
            actionResult = EventAction.EventData_LoadById(EventBase);

            if (actionResult.IsSuccess)
            {
                DataRow dr = actionResult.dtResult.Rows[0];

                EventModel.EventID = dr["EventID"] != DBNull.Value ? Convert.ToInt32(dr["EventID"]) : 0;
                EventModel.AttachedEvent = dr["AttachedEvent"] != DBNull.Value ? Convert.ToInt32(dr["AttachedEvent"]) : 0;
                EventModel.EventNumber = dr["EventNumber"] != DBNull.Value ? Convert.ToInt32(dr["EventNumber"]) : 0;
                EventModel.Camera = dr["Camera"] != DBNull.Value ? dr["Camera"].ToString() : "";
                EventModel.DutyDesc = dr["DutyDesc"] != DBNull.Value ? dr["DutyDesc"].ToString() : "";
                EventModel.EndTime = dr["EndTime"] != DBNull.Value ? dr["EndTime"].ToString() : "";
                EventModel.EventDate = dr["EventDate"] != DBNull.Value ? Convert.ToDateTime(dr["EventDate"]).ToShortDateString(): "";
                
                EventModel.UD21 = dr["UD21"] != DBNull.Value ? dr["UD21"].ToString() : "";
                EventModel.EventTime = dr["EventTime"] != DBNull.Value ? dr["EventTime"].ToString() : "";
                EventModel.FromCode = dr["FromCode"] != DBNull.Value ? dr["FromCode"].ToString() : "";
                EventModel.FromForm = dr["FromForm"] != DBNull.Value ? dr["FromForm"].ToString() : "";
                EventModel.FromNumber = dr["FromNumber"] != DBNull.Value ? dr["FromNumber"].ToString() : "";
                EventModel.KeyEvent = dr["KeyEvent"] != DBNull.Value ? Convert.ToBoolean(dr["KeyEvent"]) : false;
                EventModel.Location = dr["Location"] != DBNull.Value ? dr["Location"].ToString() : "";
                EventModel.NatureCode = dr["NatureCode"] != DBNull.Value ? dr["NatureCode"].ToString() : "";
                EventModel.NatureDesc = dr["NatureDesc"] != DBNull.Value ? dr["NatureDesc"].ToString() : "";
                EventModel.Comments = dr["Comments"] != DBNull.Value ? dr["Comments"].ToString() : "";
                EventModel.RoleName = dr["RoleName"] != DBNull.Value ? dr["RoleName"].ToString() : "";
                EventModel.Site = dr["Site"] != DBNull.Value ? dr["Site"].ToString() : "";
                EventModel.UD20 = dr["UD20"] != DBNull.Value ? dr["UD20"].ToString() : "";
                EventModel.UD22 = dr["UD22"] != DBNull.Value ? dr["UD22"].ToString() : "";
                EventModel.UD23 = dr["UD23"] != DBNull.Value ? dr["UD23"].ToString() : "";
                EventModel.UD24 = dr["UD24"] != DBNull.Value ? dr["UD24"].ToString() : "";
                EventModel.UD25 = dr["UD25"] != DBNull.Value ? dr["UD25"].ToString() : "";
                EventModel.UserID = dr["UserID"] != DBNull.Value ? dr["UserID"].ToString() : "";
                EventModel.EventNumber = dr["EventNumber"] != DBNull.Value ? Convert.ToInt32(dr["EventNumber"]) : 0;
            }
            else
            {
                EventModel.EventDate = DateTime.Now.Date.ToShortDateString(); //DateTime.Now.Date.ToString();
                EventModel.EventTime = DateTime.Now.ToString("hh:mm tt");
                //EventModel.EndTime = DateTime.Now.ToString("hh:mm tt");
            }
            actionResult = EventAction.MediaCopy_LoadByID(EventCopyBase);
            if (actionResult.IsSuccess)
            {
                DataRow dr = actionResult.dtResult.Rows[0];

                EventCopyModel.Media = dr["MediaNumbers"] != DBNull.Value ? dr["MediaNumbers"].ToString() : "";
                EventCopyModel.MediaLabledAs = dr["MediaLabel"] != DBNull.Value ? dr["MediaLabel"].ToString() : "";
                EventCopyModel.OriginalHeldBy = dr["OriginalsHeldBy"] != DBNull.Value ? dr["OriginalsHeldBy"].ToString() : "";
                EventCopyModel.OriginalSaved = dr["OriginalsSaved"] != DBNull.Value ? dr["OriginalsSaved"].ToString() : "";
                EventCopyModel.Other = dr["SentToOther"] != DBNull.Value ? dr["SentToOther"].ToString() : "";
                EventCopyModel.IncidentNumber = dr["IncidentNumber"] != DBNull.Value ? dr["IncidentNumber"].ToString() : "";
            }
            actionResult = EventAction.EventPicture_LoadByEventID(PictureBase);
            if (actionResult.IsSuccess)
            {
                ListPictureModel = (from DataRow row in actionResult.dtResult.Rows
                                    select new PictureModel
                                    {
                                        EventMediaID = row["EventMediaID"] != DBNull.Value ? Convert.ToInt32(row["EventMediaID"]) : 0,
                                        Description = row["Description"] != DBNull.Value ? row["Description"].ToString() : "",
                                        Details = row["Details"] != DBNull.Value ? row["Details"].ToString() : "",
                                    }).ToList();
            }

            actionResult = EventAction.Review_LoadById(EventReviewBase);
            if (actionResult.IsSuccess)
            {
                ListEventReviewTableModel = (from DataRow row in actionResult.dtResult.Rows
                                             select new EventReviewModel
                                             {
                                                 EventReviewID = row["ReviewID"] != DBNull.Value ? Convert.ToInt32(row["ReviewID"]) : 0,
                                                 ItemNumber = row["ItemNumber"] != DBNull.Value ? Convert.ToInt32(row["ItemNumber"]) : 0,
                                                 Reason = row["Reason"] != DBNull.Value ? row["Reason"].ToString() : "",
                                                 Replaced = row["ReplacedBy"] != DBNull.Value ? row["ReplacedBy"].ToString() : "",
                                                 ReviewFrom = row["FromHoursMinutes"] != DBNull.Value ? row["FromHoursMinutes"].ToString() : "",
                                                 ReviewTo = row["ToHoursMinutes"] != DBNull.Value ? row["ToHoursMinutes"].ToString() : "",
                                                 Description = row["Description"] != DBNull.Value ? row["Description"].ToString() : ""
                                             }).ToList();

                DataRow dr = actionResult.dtResult.Rows[0];

                ////EventReviewModel.EventID = dr["EventID"] != DBNull.Value ? Convert.ToInt32(dr["EventID"]) : 0;
                ////EventReviewModel.ItemNumber = dr["ItemNumber"] != DBNull.Value ? Convert.ToInt32(dr["ItemNumber"]) : 0;
                //EventReviewModel.Reason = dr["Reason"] != DBNull.Value ? dr["Reason"].ToString() : "";
                //EventReviewModel.Replaced = dr["ReplacedBy"] != DBNull.Value ? dr["ReplacedBy"].ToString() : "";
                //EventReviewModel.ReviewFrom = dr["FromHoursMinutes"] != DBNull.Value ? dr["FromHoursMinutes"].ToString() : "";
                //EventReviewModel.ReviewTo = dr["ToHoursMinutes"] != DBNull.Value ? dr["ToHoursMinutes"].ToString() : "";

                EventReviewModel.Description = dr["Description"] != DBNull.Value ? dr["Description"].ToString() : "";
            }

            EventModel.EventDescriptionList1 = ListEventReviewTableModel;

            actionResult = settingAction.InitiatedBy_Load();
            if (actionResult.IsSuccess)
            {
                InitiatedByList = (from DataRow row in actionResult.dtResult.Rows
                                   select new SelectListItem
                                   {
                                       Text = row["Initiated"] != DBNull.Value ? row["Initiated"].ToString() : "",
                                       Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                   }).ToList();
            }

            actionResult = EventAction.NatureCodes_LoadAll();
            if (actionResult.IsSuccess)
            {
                EventCodeList = (from DataRow row in actionResult.dtResult.Rows
                                 select new SelectListItem
                                 {
                                     //Text = row["Code"] != DBNull.Value ? row["Code"].ToString() + "|" + row["Description"].ToString() : "",
                                     Text = row["Code"] != DBNull.Value ? row["Code"].ToString() : "",
                                     Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                 }).ToList();
            }

            actionResult = EventAction.EventNumber_LoadAll();
            if (actionResult.IsSuccess)
            {
                AttachedEventList = (from DataRow row in actionResult.dtResult.Rows
                                     select new SelectListItem
                                     {
                                         Text = row["EventNumber"] != DBNull.Value ? row["EventNumber"].ToString() : "",
                                         Value = row["EventNumber"] != DBNull.Value ? row["EventNumber"].ToString() : ""
                                     }).ToList();
            }
            actionResult = EventAction.DispatchAreas_LoadAll();
            DispatchList.Add(new SelectListItem { Text = "Select", Value = "Select" });

            if (actionResult.IsSuccess)
            {
                DispatchList = (from DataRow row in actionResult.dtResult.Rows
                                select new SelectListItem
                                {
                                    Text = row["AreaDescription"] != DBNull.Value ? row["AreaDescription"].ToString() : "",
                                    Value = row["AreaID"] != DBNull.Value ? row["AreaID"].ToString() : ""
                                }).ToList();
            }
            actionResult = EventAction.DispatchUnitCodes_LoadAll();

            DispatchUnitCodesList.Add(new SelectListItem { Text = "Select", Value = "Select" });
            if (actionResult.IsSuccess)
            {
                DispatchUnitCodesList = (from DataRow row in actionResult.dtResult.Rows
                                         select new SelectListItem
                                         {
                                             Text = row["UnitDescription"] != DBNull.Value ? row["UnitDescription"].ToString() : "",
                                             Value = row["UnitCode"] != DBNull.Value ? row["UnitCode"].ToString() : ""
                                         }).ToList();
            }
            actionResult = settingAction.Location_Load();
            if (actionResult.IsSuccess)
            {
                LocationList = (from DataRow row in actionResult.dtResult.Rows
                                select new SelectListItem
                                {
                                    Text = row["Location"] != DBNull.Value ? row["Location"].ToString() : "",
                                    Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                }).ToList();
            }

            EventBase.Part = "Dispatch Priority";
            actionResult = EventAction.Codes_LoadByPart(EventBase);
            DispatchPriorityList.Add(new SelectListItem { Text = "Select", Value = "Select" });

            if (actionResult.IsSuccess)
            {
                DispatchPriorityList = (from DataRow row in actionResult.dtResult.Rows
                                        select new SelectListItem
                                        {
                                            Text = row["Description"] != DBNull.Value ? row["Description"].ToString() : "",
                                            Value = row["Description"] != DBNull.Value ? row["Description"].ToString() : ""
                                        }).ToList();
            }
            EventModel.AttachedEventList = AttachedEventList;
            EventModel.DispatchPriorityList = DispatchPriorityList;
            EventModel.DispatchUnitCodesList = DispatchUnitCodesList;
            EventModel.DispatchList = DispatchList;
            EventModel.ListPictureModel = ListPictureModel;
            EventBase.EventID = EventID;
            EventModel.EventReviewModel = EventReviewModel;
            EventModel.EventCopyModel = EventCopyModel;
            EventModel.LocationList = LocationList;
            EventModel.EventCodeList = EventCodeList;
            if (EventModel.NatureCode != null)
            {
                var codename = EventCodeList.Where(i => i.Value == EventModel.NatureCode.ToString()).FirstOrDefault();
                if (codename != null)
                    EventModel.NatureCodeName = codename.Text;
                else
                    EventModel.NatureCodeName = "";
            }
            EventModel.InitiatedByList = InitiatedByList;
            return View(EventModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EventDetail(EventModel EventModel)
        {

            try
            {
                string userId = Convert.ToString(Session["UserName"]);
                string RoleName = Convert.ToString(Session["RoleName"]);

                EventBase EventBase = new EventBase();

                EventBase.EventID = EventModel.EventID;
                EventBase.EventDate = EventModel.EventDate;


                EventBase.Camera = EventModel.Camera;
                EventBase.DutyDesc = EventModel.DutyDesc;
                EventBase.EndTime = EventModel.EndTime;

                EventBase.EventTime = EventModel.EventTime;
                EventBase.FromCode = EventModel.FromCode;
                EventBase.FromForm = EventModel.FromForm;
                EventBase.FromNumber = EventModel.FromNumber;
                EventBase.KeyEvent = (EventModel.KeyEvent == false ? false : true);
                EventBase.UserID = userId.ToString();
                EventBase.CreatedBy = Convert.ToInt32(Session["UserID"]);
                EventBase.UD25 = EventModel.UD25;
                EventBase.UD24 = EventModel.UD24;
                EventBase.UD23 = EventModel.UD23;
                EventBase.UD22 = EventModel.UD22;
                EventBase.UD21 = EventModel.UD21;
                EventBase.UD20 = EventModel.UD20;
                EventBase.Site = EventModel.Site;
                EventBase.RoleName = RoleName;
                EventBase.NatureDesc = EventModel.NatureDesc;
                EventBase.Comments = EventModel.Comments;
                EventBase.NatureCode = EventModel.NatureCode;
                EventBase.Location = EventModel.Location;

                actionResult = EventAction.Events_IU(EventBase);
                if (actionResult.dtResult.Rows.Count > 0)
                {
                    int IsInsertEvent = EventModel.EventID;
                    EventModel.EventID = Convert.ToInt32(actionResult.dtResult.Rows[0][0]);
                    TempData["SuccessMessage"] = "Event has been Saved Successfully";
                    
                    if (IsInsertEvent == 0)
                    {
                        TempData["SaveSuccess"] = "Success";
                        AddALLUsersRolesEventAccess(EventModel.EventID);
                    }
                    else
                        TempData["SaveSuccess"] = "";
                }
                else
                {
                    TempData["SaveSuccess"] = "";
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return RedirectToAction("EventDetail", new { Type = "Event", EventID = EventModel.EventID });
        }

        #region Delete Event
        [HttpPost]
        public JsonResult DeleteEvent(int? Id = 0)
        {
            string json = string.Empty;
            try
            {
                EventBase.EventID = Convert.ToInt32(Id);
                actionResult = EventAction.Event_DeleteById(EventBase);
                if (actionResult.IsSuccess)
                {
                    json = "success";
                }
                else
                {
                    json = "fail";
                }
            }
            catch (Exception ex)
            {
                json = "-1";
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Delete Picture
        [HttpPost]
        public JsonResult DeletePicture(int? Id = 0)
        {
            string json = string.Empty;
            try
            {
                PictureBase PictureBase = new PictureBase();
                PictureBase.EventMediaID = Convert.ToInt32(Id);
                actionResult = EventAction.EventPicture_DeleteById(PictureBase);
                if (actionResult.IsSuccess)
                {
                    json = "success";
                }
                else
                {
                    json = "fail";
                }
            }
            catch (Exception ex)
            {
                json = "-1";
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region Delete Review
        [HttpPost]
        public JsonResult DeleteReview(int? Id = 0)
        {
            string json = string.Empty;
            try
            {
                EventReviewBase PictureBase = new EventReviewBase();
                PictureBase.EventReviewID = Convert.ToInt32(Id);
                actionResult = EventAction.EventReview_DeleteById(PictureBase);
                if (actionResult.IsSuccess)
                {
                    json = "success";
                }
                else
                {
                    json = "fail";
                }
            }
            catch (Exception ex)
            {
                json = "-1";
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region Delete SelectColumnFromEventLog
        [HttpPost]
        public JsonResult SelectColumnFromEventLog(string datacolumn = null, string sortValue = null, string EventID = null)
        {
            EventModel EventModel = new Models.EventModel();
            string json = string.Empty;
            List<EventModel> ListEventModel = new List<EventModel>();
            try
            {

                EventBase PictureBase = new EventBase();
                PictureBase.EventID = Convert.ToInt32(EventID);
                PictureBase.sortValue = sortValue;
                PictureBase.datacolumn = datacolumn;
                ViewBag.datacolumn = datacolumn;
                actionResult = EventAction.EventFilter_print(PictureBase);

                if (actionResult.IsSuccess)
                {
                    ListEventModel = CommonMethods.ConvertTo<EventModel>(actionResult.dtResult);
                }
                else
                {
                    json = "fail";
                }
                EventModel.ListSotrEventModel = ListEventModel;
            }
            catch (Exception ex)
            {
                json = "-1";
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(ListEventModel, JsonRequestBehavior.AllowGet);
        }
        #endregion



        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EventPictures(EventModel EventModel, FormCollection fc)
        {
            try
            {
                var data = fc["TotalCount"];
                int TotalCount = Convert.ToInt32(data);

                DataTable dt = new DataTable();

                dt.Columns.Add("Description", typeof(string));

                for (int i = 0; i < TotalCount; i++)
                {

                    DataRow row;
                    row = dt.NewRow();

                    row["Description"] = fc["EventDescriptionList[" + i + "].DescriptionEvent"];
                    dt.Rows.Add(row);


                }

                PictureBase PictureBase = new PictureBase();
                PictureBase.BanTypeTable = dt;
                PictureBase.EventMediaID = EventModel.PictureModel.EventMediaID;
                PictureBase.EventID = EventModel.EventID;
                PictureBase.Media = -1;
                PictureBase.Details = EventModel.PictureModel.Details;



                actionResult = EventAction.EventMedia_IU(PictureBase);
                if (actionResult.IsSuccess)
                {
                    EventModel.PictureModel.EventMediaID = Convert.ToInt32(actionResult.dtResult.Rows[0][0]);
                    TempData["SuccessMessage"] = "Pictures has been Saved Successfully";
                }
                else
                {
                    TempData["ErrorMessage"] = "Error in Saving record";
                }
            }
            catch
            {


            }
            return RedirectToAction("EventDetail", new { EventID = EventModel.EventID, EventPictureID = EventModel.PictureModel.EventMediaID });
        }

        public JsonResult SendEmailData(FormCollection fc, string Attachment = null, string To = null, string Subject = null, string Desciption = null)
        {
            string json = string.Empty;

            //create pdf
            var pdfBinary = Convert.FromBase64String(Attachment);
            var dir = Server.MapPath("~/DataDump");
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            var fileName = dir + "\\PDFnMail-" + DateTime.Now.ToString("yyyyMMdd-HHMMss") + ".pdf";

            // write content to the pdf
            using (var fs = new FileStream(fileName, FileMode.Create))
            using (var writer = new BinaryWriter(fs))
            {
                writer.Write(pdfBinary, 0, pdfBinary.Length);
                writer.Close();
            }


            //string FilePath = "~/Content/Media/";
            //if (!Directory.Exists(Server.MapPath(FilePath)))
            //{
            //    Directory.CreateDirectory(Server.MapPath(FilePath));
            //}
            //string filename = "Record.png";
            //var fullpath = "";
            //int userId = Convert.ToInt32(Session["UserId"]);
            //var file = filename.Split('.');
            //file[0] = file[0] + userId;
            //string fileName = Convert.ToString(Guid.NewGuid()).Substring(0, 5);
            //string Pic_Path = HttpContext.Server.MapPath(FilePath + fileName + file[0] + "." + file[1]);
            //using (FileStream fs = new FileStream(Pic_Path, FileMode.Create))
            //{
            //    using (BinaryWriter bw = new BinaryWriter(fs))
            //    {
            //        byte[] data = Convert.FromBase64String(Attachment);
            //        bw.Write(data);
            //        bw.Close();
            //    }
            //    //Session["CapturedPath"] = Pic_Path;
            //     fullpath = Server.MapPath("/Content/Media/" + fileName + file[0] + "." + file[1]);

            //}


            if (To != null)
            {
                CIMS.Utility.SendMail.EventSendEmail(To, Subject, Desciption, true, fileName);
            }

            return Json(json, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EventCopy(EventModel EventModel, FormCollection fc)
        {
            try
            {

                EventCopyBase EventCopyBase = new EventCopyBase();
                EventCopyBase.OriginalHeldBy = EventModel.EventCopyModel.OriginalHeldBy;
                EventCopyBase.Media = EventModel.EventCopyModel.Media;
                EventCopyBase.EventID = EventModel.EventID;
                EventCopyBase.OriginalSaved = EventModel.EventCopyModel.OriginalSaved;
                EventCopyBase.IncidentNumber = EventModel.EventCopyModel.IncidentNumber;
                EventCopyBase.MediaLabledAs = EventModel.EventCopyModel.MediaLabledAs;
                EventCopyBase.Other = EventModel.EventCopyModel.Other;

                actionResult = EventAction.MediaCopy_IU(EventCopyBase);
                if (actionResult.IsSuccess)
                {
                    TempData["SuccessMessage"] = "Media Copy has been Saved Successfully";
                }
                else
                {
                    TempData["ErrorMessage"] = "Error in Saving record";
                }
            }
            catch
            {


            }
            return RedirectToAction("EventDetail", new { EventID = EventModel.EventID });
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EventReview(EventModel EventModel, FormCollection fc)
        {
            try
            {
                var data = fc["TotalReviewCount"];
                int TotalCount = Convert.ToInt32(data);

                DataTable dt = new DataTable();
                dt.Columns.Add("ItemNumber");
                dt.Columns.Add("ReplacedBy");
                dt.Columns.Add("FromHoursMinutes");
                dt.Columns.Add("ToHoursMinutes");
                dt.Columns.Add("Reason");

                for (int i = 0; i < TotalCount; i++)
                {
                    DataRow row;
                    row = dt.NewRow();
                    row["ItemNumber"] = fc["EventDescriptionList1[" + i + "].ItemNumber"];
                    row["ReplacedBy"] = fc["EventDescriptionList1[" + i + "].Replaced"];
                    row["FromHoursMinutes"] = fc["EventDescriptionList1[" + i + "].ReviewFrom"];
                    row["ToHoursMinutes"] = fc["EventDescriptionList1[" + i + "].ReviewTo"];
                    row["Reason"] = fc["EventDescriptionList1[" + i + "].Reason"];
                    dt.Rows.Add(row);
                }

                EventReviewBase EventReviewBase = new EventReviewBase();
                EventReviewBase.ReviewTable = dt;
                EventReviewBase.Description = EventModel.EventReviewModel.Description;
                EventReviewBase.ItemNumber = EventModel.EventReviewModel.ItemNumber;
                EventReviewBase.Reason = EventModel.EventReviewModel.Reason;
                EventReviewBase.Replaced = EventModel.EventReviewModel.Replaced;
                EventReviewBase.ReviewFrom = EventModel.EventReviewModel.ReviewFrom;
                EventReviewBase.ReviewTo = EventModel.EventReviewModel.ReviewTo;
                EventReviewBase.EventID = EventModel.EventID;
                EventReviewBase.EventReviewID = EventModel.EventReviewModel.EventReviewID;

                actionResult = EventAction.EventReview_I(EventReviewBase);
                if (actionResult.IsSuccess)
                {
                    TempData["SuccessMessage"] = "Media Review has been Saved Successfully";
                }
                else
                {
                    TempData["ErrorMessage"] = "Error in Saving record";
                }
            }
            catch
            {


            }
            return RedirectToAction("EventDetail", new { EventID = EventModel.EventID });
        }

        public JsonResult CreateDispatch(int EventID, string EndTime, string DispatcherArea, string EventTime, string ScheduledTime, string Priority, string Units)
        {
            EventModel EventModel = new Models.EventModel();
            string userId = Convert.ToString(Session["UserName"]);
            string json = string.Empty;
            DispatcherBase PictureBase = new DispatcherBase();
            PictureBase.EndTime = EndTime;
            PictureBase.StartTime = EventTime;
            PictureBase.ScheduledTime = ScheduledTime;
            PictureBase.Priority = Priority;
            PictureBase.Units = Units;
            PictureBase.CallTakerID = userId;
            PictureBase.DispatcherID = userId;
            PictureBase.EventID = EventID;
            PictureBase.Area = DispatcherArea;


            actionResult = EventAction.Dispatch_IU(PictureBase);
            if (actionResult.IsSuccess)
            {
                json = "success";

            }
            else
            {
                json = "fail";
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }


        public JsonResult AttachEvent(int EventID, string EventNumberData, string AttachedEventData)
        {
            EventModel EventModel = new Models.EventModel();

            string json = string.Empty;
            AtachEventBase PictureBase = new AtachEventBase();
            PictureBase.EventNumber = EventNumberData;
            PictureBase.AttachedEvent = AttachedEventData;
            PictureBase.EventID = EventID;

            actionResult = EventAction.AttachEvent_U(PictureBase);
            if (actionResult.IsSuccess)
            {
                json = "success";

            }
            else
            {
                json = "fail";
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        // Reports
        //Events
        #region Method Events_print

        [HttpPost]
        public JsonResult Events_print(string datacolumn = null, string sortValue = null)
        {
            EventModel EventModel = new Models.EventModel();
            string json = string.Empty;
            List<EventModel> ListEventModel = new List<EventModel>();
            try
            {

                EventBase PictureBase = new EventBase();
                PictureBase.sortValue = sortValue;
                PictureBase.datacolumn = datacolumn;
                ViewBag.datacolumn = datacolumn;
                actionResult = EventAction.Events_print(PictureBase);

                if (actionResult.IsSuccess)
                {
                    ListEventModel = CommonMethods.ConvertTo<EventModel>(actionResult.dtResult);
                }
                else
                {
                    json = "fail";
                }
                EventModel.ListSotrEventModel = ListEventModel;
            }
            catch (Exception ex)
            {
                json = "-1";
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(ListEventModel, JsonRequestBehavior.AllowGet);
        }
        #endregion

        public JsonResult NatureCodesLoadByID(int ID)
        {
            string json = string.Empty;
            try
            {
                CIMS.BaseLayer.Setting.NatureEventBase eventBase = new CIMS.BaseLayer.Setting.NatureEventBase();

                eventBase.ID = ID;

                actionResult = EventAction.NatureCodes_LoadByID(eventBase);
                if (actionResult.IsSuccess)
                {
                    json = "{\"Description\":\"" + actionResult.dtResult.Rows[0]["Description"].ToString() + "\",\"DefaultAction\":\"" + actionResult.dtResult.Rows[0]["DefaultAction"].ToString() + "\",\"DefaultCamera\":\"" + actionResult.dtResult.Rows[0]["DefaultCamera"].ToString() + "\"}";
                }
            }
            catch (Exception)
            {
                json = "-1";
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult LinkSubjectReports(EventSubjectReports objs)
        {
            if (ModelState.IsValid)
            {
                //var customerid = repo.GetCurrentUserCustomerId(_webSecurity.CurrentUserId());
                //repo.ADDAdGroups(customerid, objs);
                actionResult = EventAction.Link_SubjectReportDelete(objs.eventid);
                if (objs.subjectreports != null)
                {
                    foreach (var item in objs.subjectreports)
                    {
                        if (item != null)
                        {
                            eventsubjectreport objreport = new eventsubjectreport();
                            objreport.eventid = objs.eventid;
                            objreport.incidentid = item.incidentid;
                            objreport.subjectid = item.subjectid;
                            actionResult = EventAction.Link_SubjectReport(objreport);
                        }
                    }
                }
                if (actionResult.IsSuccess)
                {
                    return Json("Reports linked/unlinked successfully.");
                }

                return Json("Error occurred while linking reports.");

            }
            else
            {
                return Json(ModelState.Values.SelectMany(x => x.Errors));
            }
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult LinkEmployeeReports(EventEmployeeReports objs)
        {
            if (ModelState.IsValid)
            {
                //var customerid = repo.GetCurrentUserCustomerId(_webSecurity.CurrentUserId());
                //repo.ADDAdGroups(customerid, objs);
                actionResult = EventAction.Link_EmployeeReportDelete(objs.eventid);
                if (objs.employeereports != null)
                {
                    foreach (var item in objs.employeereports)
                    {
                        if (item != null)
                        {
                            eventemployeereport objreport = new eventemployeereport();
                            objreport.eventid = objs.eventid;
                            objreport.incidentid = item.incidentid;
                            objreport.employeeid = item.employeeid;
                            actionResult = EventAction.Link_EmployeeReport(objreport);
                        }
                    }
                }

                if (actionResult.IsSuccess)
                {
                    return Json("Reports linked/unlinked successfully.");
                }

                return Json("Error occurred while linking reports.");

            }
            else
            {
                return Json(ModelState.Values.SelectMany(x => x.Errors));
            }
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult LinkGeneralReports(EventGeneralReports objs)
        {
            if (ModelState.IsValid)
            {
                //var customerid = repo.GetCurrentUserCustomerId(_webSecurity.CurrentUserId());
                //repo.ADDAdGroups(customerid, objs);
                actionResult = EventAction.Link_GeneralReportDelete(objs.eventid);
                if (objs.generalreports != null)
                {
                    foreach (var item in objs.generalreports)
                    {
                        if (item != null)
                        {
                            eventgeneralreport objreport = new eventgeneralreport();
                            objreport.eventid = objs.eventid;
                            objreport.reportid = item.reportid;
                            actionResult = EventAction.Link_GeneralReport(objreport);
                        }
                    }
                }
                if (actionResult.IsSuccess)
                {
                    return Json("Reports linked/unlinked successfully.");
                }

                return Json("Error occurred while linking reports.");

            }
            else
            {
                return Json(ModelState.Values.SelectMany(x => x.Errors));
            }
        }

        public PartialViewResult Permissions(int? EventId = 0)
        {
            EventPermissionViewModel model = new EventPermissionViewModel();

            try
            {
                if (EventId > 0)
                {
                    model.EventID = Convert.ToInt32(EventId);
                    actionResult = EventAction.Permission_LoadByEventID(model.EventID);

                    if (actionResult.IsSuccess)
                    {
                        DataRow dr = actionResult.dtResult.Rows[0];
                        model.CreatedBy = dr["CreatedBy"] != DBNull.Value ? Convert.ToInt32(dr["CreatedBy"]) : 0;
                        model.EventCreatorUser = dr["EventCreatorUser"] != DBNull.Value ? dr["EventCreatorUser"].ToString() : "";
                        model.EventCreatorFirstName = dr["EventCreatorFirstName"] != DBNull.Value ? dr["EventCreatorFirstName"].ToString() : "";
                        model.EventCreatorLastName = dr["EventCreatorLastName"] != DBNull.Value ? dr["EventCreatorLastName"].ToString() : "";
                        model.EventCreateDate = dr["createddate"] != DBNull.Value ? dr["createddate"].ToString() : "";
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return PartialView(model);
        }

        #region Bind Users List Events for Access
        public JsonResult UsersListEventAccess(int EventID)
        {
            string jsonString = string.Empty;
            try
            {
                EventPermissionModel model = new EventPermissionModel();
                model.UserID = Convert.ToInt32(Session["UserID"]);
                model.EventID = EventID;
                actionResult = EventAction.UsersEventsAccess_Bind(model);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += " <option value = " + actionResult.dtResult.Rows[i]["UserID"] + " > " + actionResult.dtResult.Rows[i]["FullName"] + " - " + actionResult.dtResult.Rows[i]["UserName"] + " </ option >";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }

            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Add Users Events Access
        [HttpPost]
        public JsonResult AddUsersEventAccess(string UserID, int EventID)
        {
            string json = string.Empty;
            try
            {
                json = AddUsersEvent(UserID, EventID);
            }
            catch (Exception ex)
            {
                json = "-1";
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public bool AddALLUsersRolesEventAccess(int EventID)
        {
            try
            {
                EventPermissionModel model = new EventPermissionModel();
                model.EventID = EventID;
                model.CreatedBy = Convert.ToInt32(Session["UserID"]);
                actionResult = EventAction.AddAll_UsersAndRoles_EventsAccess(model);
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
                return false;
            }
            return actionResult.IsSuccess;
        }

        public string AddUsersEvent(string UserID, int EventID)
        {
            string json = string.Empty;

            if (UserID.Length > 0)
            {
                string[] UserIDList = UserID.Split(',');
                for (int i = 0; i <= UserIDList.Length - 1; i++)
                {
                    EventPermissionModel model = new EventPermissionModel();

                    model.UserID = Convert.ToInt32(UserIDList[i]);
                    model.EventID = EventID;
                    model.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    actionResult = EventAction.AddUsersEventsAccess(model);
                }
            }

            if (actionResult.IsSuccess)
            {
                json = "success";
            }
            else
            {
                json = "fail";
            }

            return json;
        }
        #endregion

        #region Remove UsersEvents Access 
        [HttpPost]
        public JsonResult RemoveUsersEventAccess(string ID)
        {
            string json = string.Empty;
            try
            {
                if (ID.Length > 0)
                {
                    string[] IDList = ID.Split(',');
                    for (int i = 0; i <= IDList.Length - 1; i++)
                    {
                        EventPermissionModel model = new EventPermissionModel();
                        model.ID = Convert.ToInt32(IDList[i]);
                        actionResult = EventAction.RemoveUsersEventsAccess(model);
                    }
                }
                if (actionResult.IsSuccess)
                {
                    json = "success";
                }
                else
                {
                    json = "fail";
                }
            }
            catch (Exception ex)
            {
                json = "-1";
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Bind EventsAccess Users
        public JsonResult EventAccessUsers_Bind(int EventID)
        {
            string jsonString = string.Empty;
            try
            {
                EventPermissionModel model = new EventPermissionModel();
                model.UserID = Convert.ToInt32(Session["UserID"]);
                model.EventID = EventID;
                actionResult = EventAction.EventsAccessUsers_Bind(model);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += " <option value = " + actionResult.dtResult.Rows[i]["ID"] + "  onclick = \"EventAccessPermission('" + actionResult.dtResult.Rows[i]["ID"] + "',this); \"> " + actionResult.dtResult.Rows[i]["FullName"] + " - " + actionResult.dtResult.Rows[i]["UserName"] + " </ option >";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }

            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Save Event Access Permission
        [HttpPost]
        public JsonResult EventAccessPermission(int ID, int EventID, string Type, string Permission)
        {
            string json = string.Empty;
            try
            {
                if (ID > 0)
                {
                    EventPermissionModel model = new EventPermissionModel();
                    model.ID = Convert.ToInt32(ID);
                    model.EventID = EventID;
                    model.EventAccessType = Type;
                    model.EventAccessPermission = Convert.ToBoolean(Permission);
                    actionResult = EventAction.EventsAccessPermission(model);
                }
                if (actionResult.IsSuccess)
                {
                    json = "success";
                }
                else
                {
                    json = "fail";
                }

            }
            catch (Exception ex)
            {
                json = "-1";
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Bind EventsAccess Permission ByUsers
        public JsonResult EventAccessPermission_ByUser(int ID, int EventID)
        {
            string jsonString = string.Empty;
            try
            {
                EventPermissionModel model = new EventPermissionModel();
                model.ID = ID;
                model.EventID = EventID;
                actionResult = EventAction.EventsAccessPermission_ByUser(model);

                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    jsonString += actionResult.dtResult.Rows[0]["ViewEvent"] != DBNull.Value ? actionResult.dtResult.Rows[0]["ViewEvent"].ToString() : "false";
                    jsonString += ",";
                    jsonString += actionResult.dtResult.Rows[0]["EditEvent"] != DBNull.Value ? actionResult.dtResult.Rows[0]["EditEvent"].ToString() : "false";
                    jsonString += ",";
                    jsonString += actionResult.dtResult.Rows[0]["DeleteEvent"] != DBNull.Value ? actionResult.dtResult.Rows[0]["DeleteEvent"].ToString() : "false";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }

            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Bind Users EventsAccess Role
        public JsonResult UsersEventAccessRole(int EventID)
        {
            string jsonString = string.Empty;
            try
            {
                EventPermissionModel model = new EventPermissionModel();
                model.EventID = EventID;
                actionResult = EventAction.UsersEventsAccessRole(model);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += " <option value = " + actionResult.dtResult.Rows[i]["RoleId"] + " > " + actionResult.dtResult.Rows[i]["RoleName"] + " </ option >";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }

            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Add Roles EventsAccess
        [HttpPost]
        public JsonResult AddRolesEventAccess(string RoleID, string EventID)
        {
            string json = string.Empty;
            try
            {
                if (RoleID.Length > 0)
                {
                    string[] RoleIDList = RoleID.Split(',');
                    for (int i = 0; i <= RoleIDList.Length - 1; i++)
                    {
                        EventPermissionModel model = new EventPermissionModel();

                        model.RoleID = Convert.ToInt32(RoleIDList[i]);
                        model.EventID = Convert.ToInt32(EventID);
                        model.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        actionResult = EventAction.AddRolesEventsAccess(model);
                    }
                }

                if (actionResult.IsSuccess)
                {
                    json = "success";
                }
                else
                {
                    json = "fail";
                }

            }
            catch (Exception ex)
            {
                json = "-1";
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Remove Roles EventsAccess 
        [HttpPost]
        public JsonResult RemoveRolesEventAccess(string ID)
        {
            string json = string.Empty;
            try
            {
                if (ID.Length > 0)
                {
                    string[] RoleIDList = ID.Split(',');
                    for (int i = 0; i <= RoleIDList.Length - 1; i++)
                    {
                        EventPermissionModel model = new EventPermissionModel();
                        model.ID = Convert.ToInt32(RoleIDList[i]);
                        actionResult = EventAction.RemoveRolesEventsAccess(model);
                    }
                }
                if (actionResult.IsSuccess)
                {
                    json = "success";
                }
                else
                {
                    json = "fail";
                }
            }
            catch (Exception ex)
            {
                json = "-1";
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Bind EventsAccess Roles
        public JsonResult EventAccessRoles_Bind(int EventID)
        {
            string jsonString = string.Empty;
            try
            {
                EventPermissionModel model = new EventPermissionModel();
                model.UserID = Convert.ToInt32(Session["UserID"]);
                model.EventID = EventID;
                actionResult = EventAction.EventsAccessRoles_Bind(model);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += " <option value = " + actionResult.dtResult.Rows[i]["ID"] + "  onclick = \"EventAccessPermissionByRole('" + actionResult.dtResult.Rows[i]["ID"] + "',this); \"> " + actionResult.dtResult.Rows[i]["RoleName"] + " </ option >";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }

            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Save Event Access Permission By Role
        [HttpPost]
        public JsonResult EventAccessPermissionByRole(int ID, int EventID, string Type, string Permission)
        {
            string json = string.Empty;
            try
            {
                if (ID > 0)
                {
                    EventPermissionModel model = new EventPermissionModel();
                    model.ID = Convert.ToInt32(ID);
                    model.EventID = EventID;
                    model.EventAccessType = Type;
                    model.EventAccessPermission = Convert.ToBoolean(Permission);
                    actionResult = EventAction.EventsAccessPermissionByRole(model);
                }
                if (actionResult.IsSuccess)
                {
                    json = "success";
                }
                else
                {
                    json = "fail";
                }

            }
            catch (Exception ex)
            {
                json = "-1";
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Bind EventsAccess Permission By Roles
        public JsonResult EventAccessPermission_ByRole(int ID, int EventID)
        {
            string jsonString = string.Empty;
            try
            {
                EventPermissionModel model = new EventPermissionModel();
                model.ID = ID;
                model.EventID = EventID;
                actionResult = EventAction.EventsAccessPermission_ByRole(model);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    jsonString += actionResult.dtResult.Rows[0]["ViewEvent"] != DBNull.Value ? actionResult.dtResult.Rows[0]["ViewEvent"].ToString() : "false";
                    jsonString += ",";
                    jsonString += actionResult.dtResult.Rows[0]["EditEvent"] != DBNull.Value ? actionResult.dtResult.Rows[0]["EditEvent"].ToString() : "false";
                    jsonString += ",";
                    jsonString += actionResult.dtResult.Rows[0]["DeleteEvent"] != DBNull.Value ? actionResult.dtResult.Rows[0]["DeleteEvent"].ToString() : "false";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }

            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region EventPermissionCheck Get
        public JsonResult EventPermissionCheck(int EventID)
        {
            EventPermissionModel eventmodel = new EventPermissionModel();

            string jsonString = string.Empty;

            try
            {
                eventmodel.EventID = EventID;
                eventmodel.UserID = Convert.ToInt32(Session["UserId"]);
                eventmodel.RoleID = Convert.ToInt32(Session["RoleId"]);

                actionResult = EventAction.EventPermissionCheck_User(eventmodel);

                if (actionResult.IsSuccess)
                {

                    if (actionResult.dtResult.Rows.Count > 0)
                    {
                        eventmodel = new EventPermissionModel();
                        eventmodel.EventView = (int)actionResult.dtResult.Rows[0]["EventView"] > 0 ? true : false;
                        eventmodel.EventEdit = (int)actionResult.dtResult.Rows[0]["EventEdit"] > 0 ? true : false;
                        eventmodel.EventDelete = (int)actionResult.dtResult.Rows[0]["EventDelete"] > 0 ? true : false;
                    }
                    jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(eventmodel);
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        [HttpPost]
        public JsonResult EventCode()
        {
            CIMS.ActionLayer.Setting.SettingAction settingAction = new CIMS.ActionLayer.Setting.SettingAction();
            
            actionResult = EventAction.NatureCodes_LoadAll();
            if (actionResult.IsSuccess)
            {
                EventCodeList = (from DataRow row in actionResult.dtResult.Rows
                                 select new SelectListItem
                                 {
                                     //Text = row["Code"] != DBNull.Value ? row["Code"].ToString() + "|" + row["Description"].ToString() : "",
                                     Text = row["Code"] != DBNull.Value ? row["Code"].ToString() : "",
                                     Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                 }).ToList();
            }

            return Json(EventCodeList, JsonRequestBehavior.AllowGet);
        }
    }
}