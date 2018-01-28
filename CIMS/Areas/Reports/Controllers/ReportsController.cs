using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using CIMS.ActionLayer.Reports;
using CIMS.Models;
using CIMS.BaseLayer.Reports;
using CIMS.Helpers;
using CIMS.Utility;
using System.IO;
using Newtonsoft.Json;
using System.Web.Script.Serialization;


namespace CIMS.Areas.Reports.Controllers
{
    public class ReportsController : Controller
    {
        DataSet dsResult = new DataSet();
        DataTable dtResult = new DataTable();
        ReportsAction reportsAction = new ReportsAction();
        CIMS.BaseLayer.ActionResult actionResult = new CIMS.BaseLayer.ActionResult();

        // GET: Reports/Reports
        public ActionResult Index()
        {
            return View();
        }

        // GET: Reports/Reports/Events

        public ActionResult EventsReports()
        {
            return View();
        }

        // GET: Reports/Reports/BannedPictures
        public ActionResult BannedPictures()
        {
            ReportsModel model = new ReportsModel();
            // List<ReportsModel> reportsList = new List<ReportsModel>();
            List<BanType> BanTypeList = new List<BanType>();
            actionResult = reportsAction.Ban_Types();

            if (actionResult.IsSuccess)
            {
                BanTypeList = (from DataRow row in actionResult.dtResult.Rows
                               select new BanType
                               {
                                   Text = row["Description"] != DBNull.Value ? row["Description"].ToString() : "",
                                   Value = row["Description"] != DBNull.Value ? row["Description"].ToString() : ""
                               }).ToList();
            }
            model.BanTypeList = BanTypeList;

            return View(model);
        }
        //#region LoadPartialPaceAudit
        //public PartialViewResult _PartialReports()
        //{
        //    ReportsModel model = new ReportsModel();
        //    // List<ReportsModel> reportsList = new List<ReportsModel>();
        //    List<BanType> BanTypeList = new List<BanType>();
        //    actionResult = reportsAction.Ban_Types();

        //    if (actionResult.IsSuccess)
        //    {
        //        BanTypeList = (from DataRow row in actionResult.dtResult.Rows
        //                       select new BanType
        //                       {
        //                           Text = row["Description"] != DBNull.Value ? row["Description"].ToString() : "",
        //                           Value = row["Description"] != DBNull.Value ? row["Description"].ToString() : ""
        //                       }).ToList();
        //    }
        //    model.BanTypeList = BanTypeList;

        //    return PartialView(model);
        //}
        //#endregion


        #region Method BannedPictures_print

        [HttpPost]
        public JsonResult BannedPictures_print(string startDate, string endDate, string datacolumn)
        {
            ReportsModel reportModel = new ReportsModel();
            string json = string.Empty;
            List<ReportsModel> reportsList = new List<ReportsModel>();
            try
            {

                ReportsBase reportsBase = new ReportsBase();
                reportsBase.StartDate = startDate;
                reportsBase.EndDate = endDate;
                reportsBase.TypeOfBan = datacolumn;
                ViewBag.datacolumn = datacolumn;

                actionResult = reportsAction.Banned_Pictures(reportsBase);

                if (actionResult.IsSuccess)
                {
                    reportsList = CommonMethods.ConvertTo<ReportsModel>(actionResult.dtResult);
                }
                else
                {
                    json = "fail";
                }
                reportModel.reportsList = reportsList;
            }
            catch (Exception ex)
            {
                json = "-1";
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(reportsList, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // GET: Reports/Reports/EmailLog
        public ActionResult EmailLog()
        {
            return View();
        }

        #region Method EmailLog_print

        [HttpPost]
        public JsonResult EmailLog_print(string startDate, string endDate, string sortValue)
        {
            ReportsModel reportModel = new ReportsModel();
            string json = string.Empty;
            List<ReportsModel> reportsList = new List<ReportsModel>();
            try
            {

                ReportsBase reportsBase = new ReportsBase();
                reportsBase.StartDate = startDate;
                reportsBase.EndDate = endDate;
                reportsBase.SortOrder = sortValue;

                actionResult = reportsAction.EmailLog_Print(reportsBase);

                if (actionResult.IsSuccess)
                {
                    reportsList = CommonMethods.ConvertTo<ReportsModel>(actionResult.dtResult);
                }
                else
                {
                    json = "fail";
                }
                reportModel.reportsList = reportsList;
            }
            catch (Exception ex)
            {
                json = "-1";
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(reportsList, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // GET: Reports/Reports/WatchList
        public ActionResult WatchList()
        {
            ReportsWatchListModel model = new ReportsWatchListModel();
            //List<ReportsWatchListModel> watchList = new List<ReportsWatchListModel>();
            //actionResult = reportsAction.WatchNames_Load();

            //if (actionResult.IsSuccess)
            //{
            //    watchList = (from DataRow row in actionResult.dtResult.Rows
            //                   select new ReportsWatchListModel
            //                   {
            //                       Text = row["Description"] != DBNull.Value ? row["Description"].ToString() : "",
            //                       Value = row["Description"] != DBNull.Value ? row["Description"].ToString() : ""
            //                   }).ToList();
            //}
            //model.ReportsWatchList = watchList;

            //return View(model);

            model.WatchList =
                    new List<SelectListItem>();

            actionResult = reportsAction.WatchNames_Load();

            if (actionResult.IsSuccess)
            {
                DataRow row = actionResult.dtResult.Rows[0];
                model.WatchList.Add(
                        new SelectListItem
                        {
                            Text = row["WatchName"] != DBNull.Value ? row["WatchName"].ToString() : "",
                            Value = row["WatchID"] != DBNull.Value ? row["WatchID"].ToString() : ""
                        });
            }
            return View(model);
        }

        #region Method WatchList_Print

        [HttpPost]
        public JsonResult WatchList_Print(string watchName)
        {
            ReportsWatchListModel reportWatchListModel = new ReportsWatchListModel();
            string json = string.Empty;
            List<ReportsModel> reportsList = new List<ReportsModel>();
            try
            {

                ReportsWatchListBase reportsWatchListBase = new ReportsWatchListBase();
                reportsWatchListBase.WatchName = watchName;

                actionResult = reportsAction.WatchList_Print(reportsWatchListBase);

                if (actionResult.IsSuccess)
                {
                    reportsList = CommonMethods.ConvertTo<ReportsModel>(actionResult.dtResult);
                }
                else
                {
                    json = "fail";
                }
                reportWatchListModel.reportsList = reportsList;
            }
            catch (Exception ex)
            {
                json = "-1";
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(reportsList, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // GET: Reports/Reports/LicenseExpiry
        public ActionResult LicenseExpiry()
        {
            return View();
        }

        #region Method LicenseExpiry_print

        [HttpPost]
        public JsonResult LicenseExpiry_print(string startDate, string endDate, string sortValue)
        {
            ReportsModel reportModel = new ReportsModel();
            string json = string.Empty;
            List<EmployeeModel> employeeList = new List<EmployeeModel>();
            try
            {

                ReportsBase reportsBase = new ReportsBase();
                reportsBase.StartDate = startDate;
                reportsBase.EndDate = endDate;
                reportsBase.SortOrder = sortValue;

                actionResult = reportsAction.LicenseExpiry_print(reportsBase);

                if (actionResult.IsSuccess)
                {
                    employeeList = CommonMethods.ConvertTo<EmployeeModel>(actionResult.dtResult);
                }
                else
                {
                    json = "fail";
                }
                reportModel.EmployeeList = employeeList;
            }
            catch (Exception ex)
            {
                json = "-1";
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(employeeList, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // GET: Reports/Reports/Dispatch
        public ActionResult Dispatch()
        {
            return View();
        }

        #region Method Dispatch_print

        [HttpPost]
        public JsonResult Dispatch_print(string startDate, string endDate, string startTime, string endTime, string sortValue)
        {
            ReportsModel reportsModel = new ReportsModel();
            string json = string.Empty;
            List<ReportsModel> reportsList = new List<ReportsModel>();
            try
            {

                ReportsBase reportsBase = new ReportsBase();
                reportsBase.StartDate = startDate;
                reportsBase.EndDate = endDate;
                reportsBase.StartTime = startTime;
                reportsBase.EndTime = endTime;
                reportsBase.SortOrder = sortValue;

                actionResult = reportsAction.Dispatch_print(reportsBase);

                if (actionResult.IsSuccess)
                {
                    reportsList = CommonMethods.ConvertTo<ReportsModel>(actionResult.dtResult);
                }
                else
                {
                    json = "fail";
                }
                reportsModel.reportsList = reportsList;
            }
            catch (Exception ex)
            {
                json = "-1";
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(reportsList, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Method PaceAudit
        public ActionResult PaceAudit()
        {
            List<SelectListItem> gameList = new List<SelectListItem>();
            List<SelectListItem> handsperHourList = new List<SelectListItem>();
            /*Bind DropDown GameList*/
            gameList.Add(new SelectListItem
            {
                Value = "-Select Game-",
                Text = "-Select Game-"
            });
            gameList.Add(new SelectListItem
            {
                Value = "Blackjack",
                Text = "Blackjack"
            });
            gameList.Add(new SelectListItem
            {
                Value = "Roulette",
                Text = "Roulette"
            });
            gameList.Add(new SelectListItem
            {
                Value = "Pai Gow",
                Text = "Pai Gow"
            });
            gameList.Add(new SelectListItem
            {
                Value = "Baccarat",
                Text = "Baccarat"
            });


            /*Bind Dropdown For HandsPerHour*/
            handsperHourList.Add(new SelectListItem
            {
                Value = "-Select Hands Per Hour-",
                Text = "-Select Hands Per Hour-"
            });

            handsperHourList.Add(new SelectListItem
            {
                Value = "All",
                Text = "All"
            });
            handsperHourList.Add(new SelectListItem
            {
                Value = "Less Than",
                Text = "Less Than"
            });
            handsperHourList.Add(new SelectListItem
            {
                Value = "Greater Than",
                Text = "Greater Than"
            });

            ViewBag.GameList = gameList;
            ViewBag.handsperHourList = handsperHourList;
            return View();
        }
        #endregion

        #region Method PaceAudit_print

        [HttpPost]
        public JsonResult PaceAudit_print(string Game, string startDate, string endDate, string SortOrder)
        {
            ReportsModel reportModel = new ReportsModel();
            string json = string.Empty;
            List<ReportsModel> reportsList = new List<ReportsModel>();
            try
            {

                ReportsBase reportsBase = new ReportsBase();
                reportsBase.Game = Game;
                reportsBase.StartDate = startDate;
                reportsBase.EndDate = endDate;
                reportsBase.SortOrder = SortOrder;
                actionResult = reportsAction.PaceAudit_print(reportsBase);

                if (actionResult.IsSuccess)
                {
                    reportsList = CommonMethods.ConvertTo<ReportsModel>(actionResult.dtResult);
                }
                else
                {
                    json = "fail";
                }
                reportModel.reportsList = reportsList;
            }
            catch (Exception ex)
            {
                json = "-1";
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(reportsList, JsonRequestBehavior.AllowGet);
        }
        #endregion

        public JsonResult SendEmailData(FormCollection fc, string Attachment = null, string To = null, string Subject = null, string Desciption = null)
        {
            string json = string.Empty;



            string FilePath = "~/Content/Media/";
            if (!Directory.Exists(Server.MapPath(FilePath)))
            {
                Directory.CreateDirectory(Server.MapPath(FilePath));
            }
            string filename = "Record.png";
            var fullpath = "";
            int userId = Convert.ToInt32(Session["UserId"]);
            var file = filename.Split('.');
            file[0] = file[0] + userId;
            string fileName = Convert.ToString(Guid.NewGuid()).Substring(0, 5);
            string Pic_Path = HttpContext.Server.MapPath(FilePath + fileName + file[0] + "." + file[1]);
            using (FileStream fs = new FileStream(Pic_Path, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    byte[] data = Convert.FromBase64String(Attachment);
                    bw.Write(data);
                    bw.Close();
                }
                //Session["CapturedPath"] = Pic_Path;
                fullpath = Server.MapPath("/Content/Media/" + fileName + file[0] + "." + file[1]);

            }


            if (To != null)
            {
                CIMS.Utility.SendMail.EventSendEmail(To, Subject, Desciption, true, fullpath);
            }

            return Json(json, JsonRequestBehavior.AllowGet);
        }


        /// Statistics
        // GET: Reports/Reports/IncidentCount
        public ActionResult IncidentCount()
        {
            return View();
        }

        #region Method IncidentCount_print

        [HttpPost]
        public JsonResult IncidentCount_print(string type, string startDate, string endDate, string shortLocation)
        {
            ReportsStatisticsModel reportsModel = new ReportsStatisticsModel();
            string json = string.Empty;
            List<ReportsStatisticsModel> reportsList = new List<ReportsStatisticsModel>();
            try
            {

                ReportsStatisticsBase reportsBase = new ReportsStatisticsBase();
                reportsBase.Type = type;
                reportsBase.StartDate = startDate;
                reportsBase.EndDate = endDate;
                reportsBase.ShortLocation = shortLocation;

                actionResult = reportsAction.IncidentCount_print(reportsBase);

                if (actionResult.IsSuccess)
                {
                    reportsList = CommonMethods.ConvertTo<ReportsStatisticsModel>(actionResult.dtResult);
                }
                else
                {
                    json = "fail";
                }
                reportsModel.reportsStatisticsList = reportsList;
            }
            catch (Exception ex)
            {
                json = "-1";
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(reportsList, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // GET: Reports/Reports/MoneyRecovered
        public ActionResult MoneyRecovered()
        {
            return View();
        }

        #region Method MoneyRecovered_print

        [HttpPost]
        public JsonResult MoneyRecovered_print(string startDate, string endDate, string shortLocation)
        {
            ReportsStatisticsModel reportsModel = new ReportsStatisticsModel();
            string json = string.Empty;
            List<ReportsStatisticsModel> reportsList = new List<ReportsStatisticsModel>();
            try
            {

                ReportsStatisticsBase reportsBase = new ReportsStatisticsBase();
                reportsBase.StartDate = startDate;
                reportsBase.EndDate = endDate;
                reportsBase.ShortLocation = shortLocation;

                actionResult = reportsAction.MoneyRecovered_print(reportsBase);

                if (actionResult.IsSuccess)
                {
                    reportsList = CommonMethods.ConvertTo<ReportsStatisticsModel>(actionResult.dtResult);
                }
                else
                {
                    json = "fail";
                }
                reportsModel.reportsStatisticsList = reportsList;
            }
            catch (Exception ex)
            {
                json = "-1";
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(reportsList, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // GET: Reports/Reports/VarianceByLocation
        public ActionResult VarianceByLocation()
        {
            return View();
        }

        #region Method VarianceByLocation_print

        [HttpPost]
        public JsonResult VarianceByLocation_print(string type, string startDate, string endDate, string shortLocation)
        {
            ReportsStatisticsModel reportsModel = new ReportsStatisticsModel();
            string json = string.Empty;
            List<ReportsStatisticsModel> reportsList = new List<ReportsStatisticsModel>();
            try
            {

                ReportsStatisticsBase reportsBase = new ReportsStatisticsBase();
                reportsBase.Type = type;
                reportsBase.StartDate = startDate;
                reportsBase.EndDate = endDate;
                reportsBase.ShortLocation = shortLocation;

                actionResult = reportsAction.VarianceByLocation_print(reportsBase);

                if (actionResult.IsSuccess)
                {
                    reportsList = CommonMethods.ConvertTo<ReportsStatisticsModel>(actionResult.dtResult);
                }
                else
                {
                    json = "fail";
                }
                reportsModel.reportsStatisticsList = reportsList;
            }
            catch (Exception ex)
            {
                json = "-1";
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(reportsList, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // GET: Reports/Reports/EmployeeVariance
        public ActionResult EmployeeVariance()
        {
            return View();
        }

        #region Method EmployeeVariance_print

        [HttpPost]
        public JsonResult EmployeeVariance_print(string type, string startDate, string endDate)
        {
            ReportsStatisticsModel reportsModel = new ReportsStatisticsModel();
            string json = string.Empty;
            List<ReportsStatisticsModel> reportsList = new List<ReportsStatisticsModel>();
            try
            {

                ReportsStatisticsBase reportsBase = new ReportsStatisticsBase();
                reportsBase.Type = type;
                reportsBase.StartDate = startDate;
                reportsBase.EndDate = endDate;

                actionResult = reportsAction.EmployeeVariance_print(reportsBase);

                if (actionResult.IsSuccess)
                {
                    reportsList = CommonMethods.ConvertTo<ReportsStatisticsModel>(actionResult.dtResult);
                }
                else
                {
                    json = "fail";
                }
                reportsModel.reportsStatisticsList = reportsList;
            }
            catch (Exception ex)
            {
                json = "-1";
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(reportsList, JsonRequestBehavior.AllowGet);
        }
        #endregion


        public ActionResult ShortDescriptionCount()
        {
            return View();

        }

        #region Method ShortDescriptor_Graph
        [HttpPost]
        public JsonResult GetShortDescriptionData(string type, string startDate, string endDate)
        {
            string json = string.Empty;
            ReportsStatisticsModel reportsModel = new ReportsStatisticsModel();
            List<ReportsStatisticsModel> reportsList = new List<ReportsStatisticsModel>();
            ReportsStatisticsBase reportsBase = new ReportsStatisticsBase();
            reportsBase.Type = type;
            reportsBase.StartDate = startDate;
            reportsBase.EndDate = endDate;
            actionResult = reportsAction.ShortDescriptor_Graph(reportsBase);
            if (actionResult.IsSuccess)
            {
                json += "{\"SubjectIncidentCount\":[ ";

                foreach (DataRow dr in actionResult.dtResult.Rows)
                {
                    json += "{\"results\":\"" + dr["results"].ToString() + "\",\"ShortDescriptor\":\"" + dr["ShortDescriptor"].ToString() + "\"},";
                }

                json = json.TrimEnd(',') + "]}";

            }

            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #endregion

        public ActionResult LocationCount()
        {
            return View();

        }

        [HttpPost]
        public JsonResult GetLocationData(string type, string startDate, string endDate)
        {
            string json = string.Empty;
            ReportsStatisticsModel reportsModel = new ReportsStatisticsModel();
            List<ReportsStatisticsModel> reportsList = new List<ReportsStatisticsModel>();
            ReportsStatisticsBase reportsBase = new ReportsStatisticsBase();
            reportsBase.Type = type;
            reportsBase.StartDate = startDate;
            reportsBase.EndDate = endDate;
            actionResult = reportsAction.LocationCount_Graph(reportsBase);
            if (actionResult.IsSuccess)
            {
                json += "{\"LocationCount\":[ ";

                foreach (DataRow dr in actionResult.dtResult.Rows)
                {
                    json += "{\"results\":\"" + dr["results"].ToString() + "\",\"ShortLocation\":\"" + dr["Location"].ToString() + "\"},";
                }

                json = json.TrimEnd(',') + "]}";

            }

            return Json(json, JsonRequestBehavior.AllowGet);
        }


    }
}