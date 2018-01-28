using CIMS.ActionLayer.Events;
using CIMS.ActionLayer.Subject;
using CIMS.Areas.Events.Controllers;
using CIMS.BaseLayer.Events;
using CIMS.BaseLayer.Subject;
using CIMS.Filters;
using CIMS.Helpers;
using CIMS.Models;
using CIMS.Utility;

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CIMS.Areas.Subject.Controllers
{


    //[Authorize]
    [CheckLogin]
    [CheckPermissionAttribute]
    public class SubjectController : Controller
    {
        #region Declaration
        SubjectBase subjectBase = new SubjectBase();
        SubjectAddressBase subjectAddressBase = new SubjectAddressBase();
        SubjectAliasBase subjectAliasBase = new SubjectAliasBase();
        SubjectLinkedBase subjectLinkedBase = new SubjectLinkedBase();
        SubjectWatchListBase subjectWatchBase = new SubjectWatchListBase();
        SubjectFeaturesBase subjectFeatureBase = new SubjectFeaturesBase();
        WatchBase watchBase = new WatchBase();
        EventAction EventAction = new EventAction();
        SubjectIdentificationBase subjectIdentificationBase = new SubjectIdentificationBase();
        SubjectAction subjectAction = new SubjectAction();
        CIMS.BaseLayer.ActionResult actionResult = new CIMS.BaseLayer.ActionResult();
        List<SelectListItem> AuthorNameList = new List<SelectListItem>();
        List<SelectListItem> DisputTypeList = new List<SelectListItem>();
        List<SelectListItem> ResolutionList = new List<SelectListItem>();
        List<SelectListItem> AuthorizedByList = new List<SelectListItem>();
        List<SelectListItem> LocationList = new List<SelectListItem>();
        List<SelectListItem> GameList = new List<SelectListItem>();
        List<SelectListItem> BuyInTypePitList = new List<SelectListItem>();
        List<SelectListItem> CashoutTableNumberList = new List<SelectListItem>();
        List<SelectListItem> CashierNameList = new List<SelectListItem>();
        List<SelectListItem> ColorList = new List<SelectListItem>();

        #endregion

        #region Subject List
        [HttpGet]
        public ActionResult Index()
        {
            //Ankur New 1
            //subjectBase.CreatedBy = Convert.ToInt32(Session["UserId"]);
            if (TempData["SubjectIdList"] != null)
            {
                List<SubjectModel> model = new List<SubjectModel>();
                List<SubjectModel> lstSubjects = new List<SubjectModel>();
                List<SubjectModel> SubjectIdList = TempData["SubjectIdList"] as List<SubjectModel>;
                var subjectId = from item in SubjectIdList
                                select item;
                //model = TempData["SubjectIdList"];
                foreach (var id in subjectId)
                {
                    try
                    {
                        subjectBase.SubjectID = id.SubjectID;//(TempData["SubjectIdList"]).Items[0].SubjectID;
                        subjectBase.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        subjectBase.RoleID = Convert.ToInt32(Session["RoleId"]);
                        actionResult = subjectAction.Subject_LoadById(subjectBase);
                        if (actionResult.IsSuccess)
                        {
                            lstSubjects.AddRange(CommonMethods.ConvertTo<SubjectModel>(actionResult.dtResult)); //=CommonMethods.ConvertTo<SubjectModel>(actionResult.dtResult);
                        }
                        model = lstSubjects;
                    }
                    catch (Exception ex)
                    {
                        ErrorReporting.WebApplicationError(ex);
                    }
                }
                return View(model);
            }
            else if (TempData["SubjectIdListfromAddress"] != null)
            {
                List<SubjectModel> model = new List<SubjectModel>();
                List<SubjectModel> lstSubjects = new List<SubjectModel>();
                List<SubjectAddressModel> SubjectIdList = TempData["SubjectIdListfromAddress"] as List<SubjectAddressModel>;
                var subjectId = from item in SubjectIdList
                                select item;
                //model = TempData["SubjectIdList"];
                foreach (var id in subjectId)
                {
                    try
                    {
                        subjectBase.SubjectID = id.SubjectID;//(TempData["SubjectIdList"]).Items[0].SubjectID;
                        subjectBase.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        subjectBase.RoleID = Convert.ToInt32(Session["RoleId"]);
                        actionResult = subjectAction.Subject_LoadById(subjectBase);
                        if (actionResult.IsSuccess)
                        {
                            lstSubjects.AddRange(CommonMethods.ConvertTo<SubjectModel>(actionResult.dtResult)); //=CommonMethods.ConvertTo<SubjectModel>(actionResult.dtResult);
                        }
                        model = lstSubjects;
                    }
                    catch (Exception ex)
                    {
                        ErrorReporting.WebApplicationError(ex);
                    }
                }
                return View(model);
            }
            else if (TempData["SubjectIdListfromAliases"] != null)
            {
                List<SubjectModel> model = new List<SubjectModel>();
                List<SubjectModel> lstSubjects = new List<SubjectModel>();
                List<SubjectAliasModel> SubjectIdList = TempData["SubjectIdListfromAliases"] as List<SubjectAliasModel>;
                var subjectId = from item in SubjectIdList
                                select item;
                //model = TempData["SubjectIdList"];
                foreach (var id in subjectId)
                {
                    try
                    {
                        subjectBase.SubjectID = id.SubjectID;//(TempData["SubjectIdList"]).Items[0].SubjectID;
                        subjectBase.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        subjectBase.RoleID = Convert.ToInt32(Session["RoleId"]);
                        actionResult = subjectAction.Subject_LoadById(subjectBase);
                        if (actionResult.IsSuccess)
                        {
                            lstSubjects.AddRange(CommonMethods.ConvertTo<SubjectModel>(actionResult.dtResult)); //=CommonMethods.ConvertTo<SubjectModel>(actionResult.dtResult);
                        }
                        model = lstSubjects;
                    }
                    catch (Exception ex)
                    {
                        ErrorReporting.WebApplicationError(ex);
                    }
                }
                return View(model);
            }
            else if (TempData["SubjectIdListfromFeatures"] != null)
            {
                List<SubjectModel> model = new List<SubjectModel>();
                List<SubjectModel> lstSubjects = new List<SubjectModel>();
                List<SubjectMarkModel> SubjectIdList = TempData["SubjectIdListfromFeatures"] as List<SubjectMarkModel>;
                var subjectId = from item in SubjectIdList
                                select item;
                //model = TempData["SubjectIdList"];
                foreach (var id in subjectId)
                {
                    try
                    {
                        subjectBase.SubjectID = id.SubjectID;//(TempData["SubjectIdList"]).Items[0].SubjectID;
                        subjectBase.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        subjectBase.RoleID = Convert.ToInt32(Session["RoleId"]);
                        actionResult = subjectAction.Subject_LoadById(subjectBase);
                        if (actionResult.IsSuccess)
                        {
                            lstSubjects.AddRange(CommonMethods.ConvertTo<SubjectModel>(actionResult.dtResult)); //=CommonMethods.ConvertTo<SubjectModel>(actionResult.dtResult);
                        }
                        model = lstSubjects;
                    }
                    catch (Exception ex)
                    {
                        ErrorReporting.WebApplicationError(ex);
                    }
                }
                return View(model);
            }
            else
            {
                List<SubjectModel> model = new List<SubjectModel>();
                try
                {
                    if (TempData["SubjectList"] != null)
                    {
                        actionResult = (CIMS.BaseLayer.ActionResult)TempData["SubjectList"];
                    }
                    else
                    {

                        subjectBase.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        subjectBase.RoleID = Convert.ToInt32(Session["RoleId"]);

                        actionResult = subjectAction.Subjects_LoadAll(subjectBase);
                    }
                    if (actionResult.IsSuccess)
                    {
                        model = CommonMethods.ConvertTo<SubjectModel>(actionResult.dtResult);

                    }
                }
                catch (Exception ex)
                {
                    ErrorReporting.WebApplicationError(ex);
                }
                //AB
                CIMS.ActionLayer.Setting.SettingAction settingAction = new CIMS.ActionLayer.Setting.SettingAction();

                List<SelectListItem> lstGender = new List<SelectListItem>();
                actionResult = settingAction.MasterSex_Load();
                if (actionResult.IsSuccess)
                {
                    lstGender = (from DataRow row in actionResult.dtResult.Rows
                                 select new SelectListItem
                                 {
                                     Text = row["Sex"] != DBNull.Value ? row["Sex"].ToString() : "",
                                     Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                 }).ToList();
                }
                ViewBag.lstGender = lstGender;

                List<SelectListItem> lstRace = new List<SelectListItem>();
                actionResult = settingAction.MasterRace_Load();
                if (actionResult.IsSuccess)
                {
                    lstRace = (from DataRow row in actionResult.dtResult.Rows
                               select new SelectListItem
                               {
                                   Text = row["Race"] != DBNull.Value ? row["Race"].ToString() : "",
                                   Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                               }).ToList();
                }
                ViewBag.lstRace = lstRace;

                List<SelectListItem> lstEyes = new List<SelectListItem>();
                actionResult = settingAction.MasterEyes_Load();
                if (actionResult.IsSuccess)
                {
                    lstEyes = (from DataRow row in actionResult.dtResult.Rows
                               select new SelectListItem
                               {
                                   Text = row["Eyes"] != DBNull.Value ? row["Eyes"].ToString() : "",
                                   Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                               }).ToList();
                }
                ViewBag.lstEyes = lstEyes;

                List<SelectListItem> lstBuild = new List<SelectListItem>();
                actionResult = settingAction.Build_Load();
                if (actionResult.IsSuccess)
                {
                    lstBuild = (from DataRow row in actionResult.dtResult.Rows
                                select new SelectListItem
                                {
                                    Text = row["Build"] != DBNull.Value ? row["Build"].ToString() : "",
                                    Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                }).ToList();
                }
                ViewBag.lstBuild = lstBuild;

                List<SelectListItem> lstComplexion = new List<SelectListItem>();
                actionResult = settingAction.Complexion_Load();
                if (actionResult.IsSuccess)
                {
                    lstComplexion = (from DataRow row in actionResult.dtResult.Rows
                                     select new SelectListItem
                                     {
                                         Text = row["Complexion"] != DBNull.Value ? row["Complexion"].ToString() : "",
                                         Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                     }).ToList();
                }
                ViewBag.lstComplexion = lstComplexion;


                //List<SelectListItem> lstHairLength = new List<SelectListItem>();
                //actionResult = settingAction.HairLength_Load();
                //if (actionResult.IsSuccess)
                //{
                //    lstHairLength = (from DataRow row in actionResult.dtResult.Rows
                //                     select new SelectListItem
                //                     {
                //                         Text = row["HairLength"] != DBNull.Value ? row["HairLength"].ToString() : "",
                //                         Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : "",

                //                     }).ToList();
                //}
                //ViewBag.lstHairLength = lstHairLength;

                List<SelectedListItemModel> lstHairLength = new List<SelectedListItemModel>();
                actionResult = settingAction.HairLength_Load();
                if (actionResult.IsSuccess)
                {
                    lstHairLength = (from DataRow row in actionResult.dtResult.Rows
                                     select new SelectedListItemModel
                                     {
                                         Text = row["HairLength"] != DBNull.Value ? row["HairLength"].ToString() : "",
                                         Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : "",
                                         cssstyle = row["ImagePath"] != DBNull.Value ? row["ImagePath"].ToString() : "",
                                     }).ToList();
                }
                ViewBag.lstHairLength = lstHairLength;

                List<SelectListItem> lstHairColor = new List<SelectListItem>();
                actionResult = settingAction.HairColor_Load();
                if (actionResult.IsSuccess)
                {
                    lstHairColor = (from DataRow row in actionResult.dtResult.Rows
                                    select new SelectListItem
                                    {
                                        Text = row["HairColor"] != DBNull.Value ? row["HairColor"].ToString() : "",
                                        Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                    }).ToList();
                }
                ViewBag.lstHairColor = lstHairColor;

                List<SelectListItem> lstFacial = new List<SelectListItem>();
                actionResult = settingAction.FacialHair_Load();
                if (actionResult.IsSuccess)
                {
                    lstFacial = (from DataRow row in actionResult.dtResult.Rows
                                 select new SelectListItem
                                 {
                                     Text = row["FacialHair"] != DBNull.Value ? row["FacialHair"].ToString() : "",
                                     Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                 }).ToList();
                }
                ViewBag.lstFacial = lstFacial;

                List<SelectListItem> lstAliasNameType = new List<SelectListItem>();
                actionResult = settingAction.AliasNameType_Load();
                if (actionResult.IsSuccess)
                {
                    lstAliasNameType = (from DataRow row in actionResult.dtResult.Rows
                                        select new SelectListItem
                                        {
                                            Text = row["NameType"] != DBNull.Value ? row["NameType"].ToString() : "",
                                            Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                        }).ToList();
                }
                ViewBag.lstAliasNameType = lstAliasNameType;

                List<SelectListItem> lstAgeRange = new List<SelectListItem>();
                actionResult = settingAction.LU_AgeSearch_Load();
                if (actionResult.IsSuccess)
                {
                    lstAgeRange = (from DataRow row in actionResult.dtResult.Rows
                                   select new SelectListItem
                                   {
                                       Text = row["AgeRange"] != DBNull.Value ? row["AgeRange"].ToString() : "",
                                       Value = row["AgeRange"] != DBNull.Value ? row["AgeRange"].ToString() : ""
                                   }).ToList();
                }
                ViewBag.lstAgeRange = lstAgeRange;

                return View(model);
            }
        }

        //Ankur New 1
        //[HttpGet]
        //public ActionResult Index(SubjectModel model)
        //{
        //    //subjectBase.CreatedBy = Convert.ToInt32(Session["UserId"]);

        //    return View(1);
        //}
        #endregion

        #region AddSubject
        [HttpGet]
        public ActionResult AddSubject(int? id = 0)
        {
            SubjectModel model = new SubjectModel();
            List<SubjectModel> subjectList = new List<SubjectModel>();
            try
            {

                CIMS.ActionLayer.Setting.SettingAction settingAction = new CIMS.ActionLayer.Setting.SettingAction();
                CIMS.BaseLayer.Setting.SetMetricsBase setMetricsBase = new CIMS.BaseLayer.Setting.SetMetricsBase();
                setMetricsBase.Type = "Height";
                actionResult = settingAction.setmetrics_LoadBy(setMetricsBase);
                if (actionResult.IsSuccess)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        if (actionResult.dtResult.Rows[i]["ActiveMetrics"].ToString() == "True")
                        {
                            ViewBag.ActiveMetricsHeight = actionResult.dtResult.Rows[i]["metrics"].ToString();
                        }
                    }
                    if (ViewBag.ActiveMetricsHeight == null)
                    {
                        ViewBag.ActiveMetricsHeight = "";
                    }
                }

                CIMS.BaseLayer.Setting.WeightUnitBase setWeightUnitBase = new CIMS.BaseLayer.Setting.WeightUnitBase();
                setWeightUnitBase.IsDefault = true;
                actionResult = settingAction.setWeightUnit_LoadBy(setWeightUnitBase);
                if (actionResult.IsSuccess)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        if (actionResult.dtResult.Rows[i]["IsDefault"].ToString() == "True")
                        {
                            ViewBag.ActiveDefaultWeight = actionResult.dtResult.Rows[i]["WeightUnitName"].ToString();
                        }
                    }
                    if (ViewBag.ActiveDefaultWeight == null)
                    {
                        ViewBag.ActiveDefaultWeight = "";
                    }
                }

                CIMS.BaseLayer.Setting.HeightUnitBase setHeightUnitBase = new CIMS.BaseLayer.Setting.HeightUnitBase();
                setHeightUnitBase.IsDefault = true;
                actionResult = settingAction.setHeightUnit_LoadBy(setHeightUnitBase);

                if (actionResult.IsSuccess)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        if (actionResult.dtResult.Rows[i]["IsDefault"].ToString() == "True")
                        {
                            ViewBag.ActiveDefaultHeight = actionResult.dtResult.Rows[i]["HeightUnitName"].ToString();
                        }
                    }
                    if (ViewBag.ActiveDefaultHeight == null)
                    {
                        ViewBag.ActiveDefaultHeight = "";
                    }
                }

                List<SelectListItem> lstIdentification1 = new List<SelectListItem>();
                actionResult = settingAction.MasterTypeID1_Load();
                if (actionResult.IsSuccess)
                {
                    lstIdentification1 = (from DataRow row in actionResult.dtResult.Rows
                                          select new SelectListItem
                                          {
                                              Text = row["Value"] != DBNull.Value ? row["Value"].ToString() : "",
                                              Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                          }).ToList();
                }
                ViewBag.lstIdentification1 = lstIdentification1;

                //List<SelectListItem> lstIdentification2 = new List<SelectListItem>();
                //actionResult = settingAction.MasterTypeID2_Load();
                //if (actionResult.IsSuccess)
                //{
                //    lstIdentification2 = (from DataRow row in actionResult.dtResult.Rows
                //                          select new SelectListItem
                //                          {
                //                              Text = row["Value"] != DBNull.Value ? row["Value"].ToString() : "",
                //                              Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                //                          }).ToList();
                //}
                //ViewBag.lstIdentification2 = lstIdentification2;

                //List<SelectListItem> lstIdentification3 = new List<SelectListItem>();
                //actionResult = settingAction.MasterTypeID3_Load();
                //if (actionResult.IsSuccess)
                //{
                //    lstIdentification3 = (from DataRow row in actionResult.dtResult.Rows
                //                          select new SelectListItem
                //                          {
                //                              Text = row["Value"] != DBNull.Value ? row["Value"].ToString() : "",
                //                              Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                //                          }).ToList();
                //}
                //ViewBag.lstIdentification3 = lstIdentification3;

                setMetricsBase.Type = "Weight";
                actionResult = settingAction.setmetrics_LoadBy(setMetricsBase);
                if (actionResult.IsSuccess)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        if (actionResult.dtResult.Rows[i]["ActiveMetrics"].ToString() == "True")
                        {
                            ViewBag.ActiveMetricsWeight = actionResult.dtResult.Rows[i]["metrics"].ToString();
                        }
                    }
                    if (ViewBag.ActiveMetricsWeight == null)
                    {
                        ViewBag.ActiveMetricsWeight = "";
                    }
                }

                List<SelectListItem> lstGender = new List<SelectListItem>();
                actionResult = settingAction.MasterSex_Load();
                if (actionResult.IsSuccess)
                {
                    lstGender = (from DataRow row in actionResult.dtResult.Rows
                                 select new SelectListItem
                                 {
                                     Text = row["Sex"] != DBNull.Value ? row["Sex"].ToString() : "",
                                     Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                 }).ToList();
                }
                ViewBag.lstGender = lstGender;

                List<SelectListItem> lstRace = new List<SelectListItem>();
                actionResult = settingAction.MasterRace_Load();
                if (actionResult.IsSuccess)
                {
                    lstRace = (from DataRow row in actionResult.dtResult.Rows
                               select new SelectListItem
                               {
                                   Text = row["Race"] != DBNull.Value ? row["Race"].ToString() : "",
                                   Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                               }).ToList();
                }
                ViewBag.lstRace = lstRace;

                List<SelectListItem> lstEyes = new List<SelectListItem>();
                actionResult = settingAction.MasterEyes_Load();
                if (actionResult.IsSuccess)
                {
                    lstEyes = (from DataRow row in actionResult.dtResult.Rows
                               select new SelectListItem
                               {
                                   Text = row["Eyes"] != DBNull.Value ? row["Eyes"].ToString() : "",
                                   Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                               }).ToList();
                }
                ViewBag.lstEyes = lstEyes;

                List<SelectListItem> lstBuild = new List<SelectListItem>();
                actionResult = settingAction.Build_Load();
                if (actionResult.IsSuccess)
                {
                    lstBuild = (from DataRow row in actionResult.dtResult.Rows
                                select new SelectListItem
                                {
                                    Text = row["Build"] != DBNull.Value ? row["Build"].ToString() : "",
                                    Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                }).ToList();
                }
                ViewBag.lstBuild = lstBuild;

                List<SelectListItem> lstComplexion = new List<SelectListItem>();
                actionResult = settingAction.Complexion_Load();
                if (actionResult.IsSuccess)
                {
                    lstComplexion = (from DataRow row in actionResult.dtResult.Rows
                                     select new SelectListItem
                                     {
                                         Text = row["Complexion"] != DBNull.Value ? row["Complexion"].ToString() : "",
                                         Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                     }).ToList();
                }
                ViewBag.lstComplexion = lstComplexion;


                List<SelectedListItemModel> lstHairLength = new List<SelectedListItemModel>();
                actionResult = settingAction.HairLength_Load();
                if (actionResult.IsSuccess)
                {
                    lstHairLength = (from DataRow row in actionResult.dtResult.Rows
                                     select new SelectedListItemModel
                                     {
                                         Text = row["HairLength"] != DBNull.Value ? row["HairLength"].ToString() : "",
                                         Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : "",
                                         cssstyle = row["ImagePath"] != DBNull.Value ? row["ImagePath"].ToString() : "",
                                     }).ToList();
                }
                ViewBag.lstHairLength = lstHairLength;

                List<SelectListItem> lstHairColor = new List<SelectListItem>();
                actionResult = settingAction.HairColor_Load();
                if (actionResult.IsSuccess)
                {
                    lstHairColor = (from DataRow row in actionResult.dtResult.Rows
                                    select new SelectListItem
                                    {
                                        Text = row["HairColor"] != DBNull.Value ? row["HairColor"].ToString() : "",
                                        Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                    }).ToList();
                }
                ViewBag.lstHairColor = lstHairColor;

                List<SelectListItem> lstFacial = new List<SelectListItem>();
                actionResult = settingAction.FacialHair_Load();
                if (actionResult.IsSuccess)
                {
                    lstFacial = (from DataRow row in actionResult.dtResult.Rows
                                 select new SelectListItem
                                 {
                                     Text = row["FacialHair"] != DBNull.Value ? row["FacialHair"].ToString() : "",
                                     Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                 }).ToList();
                }
                ViewBag.lstFacial = lstFacial;



                if (id > 0)
                {
                    subjectBase.SubjectID = Convert.ToInt32(id);
                    subjectBase.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    subjectBase.RoleID = Convert.ToInt32(Session["RoleId"]);

                    actionResult = subjectAction.Subject_LoadById(subjectBase);
                    if (actionResult.IsSuccess)
                    {
                        subjectList = CommonMethods.ConvertTo<SubjectModel>(actionResult.dtResult);
                        if (subjectList.Count > 0)
                            model = subjectList.FirstOrDefault();
                        model.DateOfBirth = !String.IsNullOrEmpty(model.DateOfBirth) ? Convert.ToDateTime(model.DateOfBirth).ToShortDateString() : "";

                        DataRow dr = actionResult.dtResult.Rows[0];
                        model.EditPermission = dr["editpermission"] != DBNull.Value ? Convert.ToBoolean(dr["editpermission"]) : false;
                        model.DeletePermission = dr["deletepermission"] != DBNull.Value ? Convert.ToBoolean(dr["deletepermission"]) : false;

                        ViewBag.SelectedHairLength = Convert.ToString(model.HairLength);
                    }
                }
                else
                {
                    //actionResult = subjectAction.SubjectIDMax_Load();
                    //if (actionResult.IsSuccess)
                    //{
                    //    model.VIP = actionResult.dtResult.Rows[0][0] != DBNull.Value ? actionResult.dtResult.Rows[0][0].ToString() : " ";

                    //}
                    Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    model.VIP = unixTimestamp.ToString();
                }


            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult AddSubjectFromSearch(SubjectModel model)
        {
            //SubjectModel model = new SubjectModel();
            //List<SubjectModel> subjectList = new List<SubjectModel>();
            try
            {

                CIMS.ActionLayer.Setting.SettingAction settingAction = new CIMS.ActionLayer.Setting.SettingAction();
                CIMS.BaseLayer.Setting.SetMetricsBase setMetricsBase = new CIMS.BaseLayer.Setting.SetMetricsBase();
                setMetricsBase.Type = "Height";
                actionResult = settingAction.setmetrics_LoadBy(setMetricsBase);
                if (actionResult.IsSuccess)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        if (actionResult.dtResult.Rows[i]["ActiveMetrics"].ToString() == "True")
                        {
                            ViewBag.ActiveMetricsHeight = actionResult.dtResult.Rows[i]["metrics"].ToString();
                        }
                    }
                    if (ViewBag.ActiveMetricsHeight == null)
                    {
                        ViewBag.ActiveMetricsHeight = "";
                    }
                }

                CIMS.BaseLayer.Setting.WeightUnitBase setWeightUnitBase = new CIMS.BaseLayer.Setting.WeightUnitBase();
                setWeightUnitBase.IsDefault = true;
                actionResult = settingAction.setWeightUnit_LoadBy(setWeightUnitBase);
                if (actionResult.IsSuccess)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        if (actionResult.dtResult.Rows[i]["IsDefault"].ToString() == "True")
                        {
                            ViewBag.ActiveDefaultWeight = actionResult.dtResult.Rows[i]["WeightUnitName"].ToString();
                        }
                    }
                    if (ViewBag.ActiveDefaultWeight == null)
                    {
                        ViewBag.ActiveDefaultWeight = "";
                    }
                }

                CIMS.BaseLayer.Setting.HeightUnitBase setHeightUnitBase = new CIMS.BaseLayer.Setting.HeightUnitBase();
                setHeightUnitBase.IsDefault = true;
                actionResult = settingAction.setHeightUnit_LoadBy(setHeightUnitBase);
                if (actionResult.IsSuccess)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        if (actionResult.dtResult.Rows[i]["IsDefault"].ToString() == "True")
                        {
                            ViewBag.ActiveDefaultHeight = actionResult.dtResult.Rows[i]["HeightUnitName"].ToString();
                        }
                    }
                    if (ViewBag.ActiveDefaultHeight == null)
                    {
                        ViewBag.ActiveDefaultHeight = "";
                    }
                }

                List<SelectListItem> lstIdentification1 = new List<SelectListItem>();
                actionResult = settingAction.MasterTypeID1_Load();
                if (actionResult.IsSuccess)
                {
                    lstIdentification1 = (from DataRow row in actionResult.dtResult.Rows
                                          select new SelectListItem
                                          {
                                              Text = row["Value"] != DBNull.Value ? row["Value"].ToString() : "",
                                              Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                          }).ToList();
                }
                ViewBag.lstIdentification1 = lstIdentification1;

                //List<SelectListItem> lstIdentification2 = new List<SelectListItem>();
                //actionResult = settingAction.MasterTypeID2_Load();
                //if (actionResult.IsSuccess)
                //{
                //    lstIdentification2 = (from DataRow row in actionResult.dtResult.Rows
                //                          select new SelectListItem
                //                          {
                //                              Text = row["Value"] != DBNull.Value ? row["Value"].ToString() : "",
                //                              Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                //                          }).ToList();
                //}
                //ViewBag.lstIdentification2 = lstIdentification2;

                //List<SelectListItem> lstIdentification3 = new List<SelectListItem>();
                //actionResult = settingAction.MasterTypeID3_Load();
                //if (actionResult.IsSuccess)
                //{
                //    lstIdentification3 = (from DataRow row in actionResult.dtResult.Rows
                //                          select new SelectListItem
                //                          {
                //                              Text = row["Value"] != DBNull.Value ? row["Value"].ToString() : "",
                //                              Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                //                          }).ToList();
                //}
                //ViewBag.lstIdentification3 = lstIdentification3;
                setMetricsBase.Type = "Weight";
                actionResult = settingAction.setmetrics_LoadBy(setMetricsBase);
                if (actionResult.IsSuccess)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        if (actionResult.dtResult.Rows[i]["ActiveMetrics"].ToString() == "True")
                        {
                            ViewBag.ActiveMetricsWeight = actionResult.dtResult.Rows[i]["metrics"].ToString();
                        }
                    }
                    if (ViewBag.ActiveMetricsWeight == null)
                    {
                        ViewBag.ActiveMetricsWeight = "";
                    }
                }

                List<SelectListItem> lstGender = new List<SelectListItem>();
                actionResult = settingAction.MasterSex_Load();
                if (actionResult.IsSuccess)
                {
                    lstGender = (from DataRow row in actionResult.dtResult.Rows
                                 select new SelectListItem
                                 {
                                     Text = row["Sex"] != DBNull.Value ? row["Sex"].ToString() : "",
                                     Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                 }).ToList();
                }
                ViewBag.lstGender = lstGender;

                List<SelectListItem> lstRace = new List<SelectListItem>();
                actionResult = settingAction.MasterRace_Load();
                if (actionResult.IsSuccess)
                {
                    lstRace = (from DataRow row in actionResult.dtResult.Rows
                               select new SelectListItem
                               {
                                   Text = row["Race"] != DBNull.Value ? row["Race"].ToString() : "",
                                   Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                               }).ToList();
                }
                ViewBag.lstRace = lstRace;

                List<SelectListItem> lstEyes = new List<SelectListItem>();
                actionResult = settingAction.MasterEyes_Load();
                if (actionResult.IsSuccess)
                {
                    lstEyes = (from DataRow row in actionResult.dtResult.Rows
                               select new SelectListItem
                               {
                                   Text = row["Eyes"] != DBNull.Value ? row["Eyes"].ToString() : "",
                                   Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                               }).ToList();
                }
                ViewBag.lstEyes = lstEyes;

                List<SelectListItem> lstBuild = new List<SelectListItem>();
                actionResult = settingAction.Build_Load();
                if (actionResult.IsSuccess)
                {
                    lstBuild = (from DataRow row in actionResult.dtResult.Rows
                                select new SelectListItem
                                {
                                    Text = row["Build"] != DBNull.Value ? row["Build"].ToString() : "",
                                    Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                }).ToList();
                }
                ViewBag.lstBuild = lstBuild;

                List<SelectListItem> lstComplexion = new List<SelectListItem>();
                actionResult = settingAction.Complexion_Load();
                if (actionResult.IsSuccess)
                {
                    lstComplexion = (from DataRow row in actionResult.dtResult.Rows
                                     select new SelectListItem
                                     {
                                         Text = row["Complexion"] != DBNull.Value ? row["Complexion"].ToString() : "",
                                         Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                     }).ToList();
                }
                ViewBag.lstComplexion = lstComplexion;


                List<SelectedListItemModel> lstHairLength = new List<SelectedListItemModel>();
                actionResult = settingAction.HairLength_Load();
                if (actionResult.IsSuccess)
                {
                    lstHairLength = (from DataRow row in actionResult.dtResult.Rows
                                     select new SelectedListItemModel
                                     {
                                         Text = row["HairLength"] != DBNull.Value ? row["HairLength"].ToString() : "",
                                         Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : "",
                                         cssstyle = row["ImagePath"] != DBNull.Value ? row["ImagePath"].ToString() : "",
                                     }).ToList();
                }
                ViewBag.lstHairLength = lstHairLength;
                ViewBag.SelectedHairLength = Convert.ToString(model.HairLength);

                List<SelectListItem> lstHairColor = new List<SelectListItem>();
                actionResult = settingAction.HairColor_Load();
                if (actionResult.IsSuccess)
                {
                    lstHairColor = (from DataRow row in actionResult.dtResult.Rows
                                    select new SelectListItem
                                    {
                                        Text = row["HairColor"] != DBNull.Value ? row["HairColor"].ToString() : "",
                                        Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                    }).ToList();
                }
                ViewBag.lstHairColor = lstHairColor;

                List<SelectListItem> lstFacial = new List<SelectListItem>();
                actionResult = settingAction.FacialHair_Load();
                if (actionResult.IsSuccess)
                {
                    lstFacial = (from DataRow row in actionResult.dtResult.Rows
                                 select new SelectListItem
                                 {
                                     Text = row["FacialHair"] != DBNull.Value ? row["FacialHair"].ToString() : "",
                                     Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                 }).ToList();
                }
                ViewBag.lstFacial = lstFacial;
                //if (id > 0)
                //{
                //    subjectBase.SubjectID = Convert.ToInt32(id);
                //    actionResult = subjectAction.Subject_LoadById(subjectBase);
                //    if (actionResult.IsSuccess)
                //    {
                //        subjectList = CommonMethods.ConvertTo<SubjectModel>(actionResult.dtResult);
                //        if (subjectList.Count > 0)
                //            model = subjectList.FirstOrDefault();
                if (!String.IsNullOrEmpty(model.DateOfBirth))
                {
                    DateTime now = DateTime.Today;
                    DateTime bday = Convert.ToDateTime(model.DateOfBirth);
                    int age = now.Year - bday.Year;
                    if (bday > now.AddYears(-age))
                        age--;

                    model.Age = age;
                }

                //    }
                //}
                //else
                //{
                Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                model.VIP = unixTimestamp.ToString();
                model.EditPermission = true; ///For new subject do not disable controls
                model.DeletePermission = true; ///For new subject do not disable controls
                //}
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return View("AddSubject", model);
        }

        [HttpPost]
        public ActionResult AddSubject(SubjectModel model)
        {
            try
            {
                subjectBase.SubjectID = model.SubjectID;

                if (model.FirstName != null)
                {
                    subjectBase.FirstName = model.FirstName;
                }
                else
                {
                    subjectBase.FirstName = "Unknown";
                }

                if (model.LastName != null)
                {
                    subjectBase.LastName = model.LastName;
                }
                else
                {
                    subjectBase.LastName = "Unknown";
                }


                subjectBase.MiddleName = model.MiddleName;
                subjectBase.VIP = model.VIP;
                subjectBase.Age = model.Age;
                subjectBase.Sex = model.Sex;
                subjectBase.Race = model.Race;
                subjectBase.Height = model.Height;
                subjectBase.Weight = model.Weight;
                subjectBase.DateOfBirth = model.DateOfBirth;
                subjectBase.Eyes = model.Eyes;
                subjectBase.Build = model.Build;
                subjectBase.FacialHair = model.FacialHair;
                subjectBase.HairColor = model.HairColor;
                subjectBase.HairLength = model.HairLength;
                subjectBase.Complexion = model.Complexion;
                subjectBase.Glasses = Convert.ToString(model.Glasses);
                subjectBase.Restricted = model.Restricted;
                subjectBase.Status = model.Status;
                subjectBase.RoleName = model.RoleName;
                subjectBase.CIDSubject = model.CIDSubject;
                subjectBase.CIDPersonID = model.CIDPersonID;
                subjectBase.CreatedBy = Convert.ToInt32(Session["UserId"]);
                actionResult = subjectAction.Subject_IU(subjectBase);
                if (actionResult.IsSuccess)
                {
                    int result = actionResult.dtResult.Rows[0][0] != DBNull.Value ? Convert.ToInt32(actionResult.dtResult.Rows[0][0]) : 0;
                    if (result > 0)
                    {
                        if (model.SubjectID > 0)
                        {
                            TempData["SuccessMessage"] = "Subject Updated Successfully.";
                            TempData["SaveSuccess"] = "";
                            return RedirectToAction("SubjectAddress", new { Type = "Subject", id = model.SubjectID });
                        }
                        else
                        {
                            model.SubjectID = result;
                            AddALLUsersRolesSubjectAccess(model.SubjectID);
                            TempData["SuccessMessage"] = "Subject Added Successfully.";
                            TempData["SaveSuccess"] = "Success";
                            return RedirectToAction("AddSubject", new { Type = "Subject", id = model.SubjectID });
                        }

                    }
                    else
                        TempData["ErrorMessage"] = "Some error Occurred, please try again later.";

                }
                else
                    TempData["ErrorMessage"] = "Some error Occurred, please try again later.";
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            //return RedirectToAction("SubjectAddress", new { Type = "Subject", id = model.SubjectID });
            return RedirectToAction("AddSubject", new { Type = "Subject", id = model.SubjectID });
            //return RedirectToAction("SubjectPermission", new { Type = "Subject", id = model.SubjectID });
        }
        #endregion

        #region Delete Subject
        [HttpPost]
        public JsonResult DeleteSubject(int? Id = 0)
        {
            string json = string.Empty;
            try
            {
                subjectBase.SubjectID = Convert.ToInt32(Id);
                actionResult = subjectAction.Subject_DeleteById(subjectBase);
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

        #region SubjectAddress
        [HttpGet]
        public ActionResult SubjectAddress(int? id = 0)
        {
            bool permission = (Session["Admin"] == null ? CIMS.Models.CheckPermissions.permissionMenu("Subject Addresses", Convert.ToInt32(Session["UserId"])) : CIMS.Models.CheckAdminPermissions.permissionMenu("Subject"));
            if (!permission)
            {
                return Redirect("~/Home/NoPermission");
            }
            ManageSubjectAddressModel model = new ManageSubjectAddressModel();
            List<SubjectAddressModel> addressListModel = new List<SubjectAddressModel>();
            SubjectAddressModel addressModel = new SubjectAddressModel();
            model.subAddressList = addressListModel;
            model.subAddressModel = addressModel;
            try
            {
                if (id > 0)
                {
                    model.subAddressModel.SubjectID = Convert.ToInt32(id);
                    subjectAddressBase.SubjectID = Convert.ToInt32(id);
                    actionResult = subjectAction.SubjectAddress_LoadBySubjectId(subjectAddressBase);
                    if (actionResult.IsSuccess)
                    {
                        addressListModel = CommonMethods.ConvertTo<SubjectAddressModel>(actionResult.dtResult);
                    }
                    model.subAddressList = addressListModel;

                    subjectBase.SubjectID = Convert.ToInt32(id);
                    subjectBase.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    subjectBase.RoleID = Convert.ToInt32(Session["RoleId"]);

                    actionResult = subjectAction.Subject_LoadById(subjectBase);
                    if (actionResult.IsSuccess)
                    {
                        DataRow dr = actionResult.dtResult.Rows[0];
                        model.subAddressModel.LogoFirstName = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : "";
                        model.subAddressModel.LogoLastName = dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : "";
                        model.subAddressModel.LogoMiddleName = dr["MiddleName"] != DBNull.Value ? dr["MiddleName"].ToString() : "";
                        model.subAddressModel.CreatedBy = dr["CreatedBy"] != DBNull.Value ? Convert.ToInt32(dr["CreatedBy"]) : 0;
                        model.subAddressModel.EditPermission = dr["editpermission"] != DBNull.Value ? Convert.ToBoolean(dr["editpermission"]) : false;
                        model.subAddressModel.DeletePermission = dr["deletepermission"] != DBNull.Value ? Convert.ToBoolean(dr["deletepermission"]) : false;
                    }
                    model.subAddressModel = model.subAddressModel;
                }
                else
                {
                    return RedirectToAction("AddSubject");
                }

                CIMS.ActionLayer.Employee.EmployeeAction employeeAction = new CIMS.ActionLayer.Employee.EmployeeAction();
                EmployeeModel employeeModel = new EmployeeModel();
                List<SelectListItem> AddressTypeList = new List<SelectListItem>();
                actionResult = employeeAction.MasterAddressType_Load();
                if (actionResult.IsSuccess)
                {
                    AddressTypeList = (from DataRow row in actionResult.dtResult.Rows
                                       select new SelectListItem
                                       {
                                           Text = row["AddressType"] != DBNull.Value ? row["AddressType"].ToString() : "",
                                           Value = row["id"] != DBNull.Value ? row["id"].ToString() : ""
                                       }).ToList();
                }
                employeeModel.AddressTypeList = AddressTypeList;
                model.EmployeeModel = employeeModel;

            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return View(model);
        }

        public ActionResult SubjectPermission(int? id = 0)
        {
            //bool permission = (Session["Admin"] == null ? CIMS.Models.CheckPermissions.permissionMenu("Subject Addresses", Convert.ToInt32(Session["UserId"])) : CIMS.Models.CheckAdminPermissions.permissionMenu("Subject"));
            //if (!permission)
            //{
            //    return Redirect("~/Home/NoPermission");
            //}
            //ManageSubjectAddressModel model = new ManageSubjectAddressModel();
            //List<SubjectAddressModel> addressListModel = new List<SubjectAddressModel>();
            SubjectPermissionModel model = new SubjectPermissionModel();
            //model.subAddressList = addressListModel;
            //model.subAddressModel = addressModel;
            try
            {
                if (id > 0)
                {
                    model.SubjectID = Convert.ToInt32(id);
                    subjectAddressBase.SubjectID = Convert.ToInt32(id);
                    actionResult = subjectAction.SubjectPermission_LoadBySubjectID(model.SubjectID);
                    if (actionResult.IsSuccess)
                    {
                        DataRow dr = actionResult.dtResult.Rows[0];
                        model.CreatedBy = dr["CreatedBy"] != DBNull.Value ? Convert.ToInt32(dr["CreatedBy"]) : 0;
                        model.ReportCreatorUser = dr["ReportCreatorUser"] != DBNull.Value ? dr["ReportCreatorUser"].ToString() : "";
                        model.ReportCreatorFirstName = dr["ReportCreatorFirstName"] != DBNull.Value ? dr["ReportCreatorFirstName"].ToString() : "";
                        model.ReportCreatorLastName = dr["ReportCreatorLastName"] != DBNull.Value ? dr["ReportCreatorLastName"].ToString() : "";
                        model.ReportCreateDate = dr["createddate"] != DBNull.Value ? dr["createddate"].ToString() : "";
                        model.LogoFirstName = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : "";
                        model.LogoLastName = dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : "";
                        model.LogoMiddleName = dr["MiddleName"] != DBNull.Value ? dr["MiddleName"].ToString() : "";
                    }

                    //actionResult = subjectAction.SubjectAddress_LoadBySubjectId(subjectAddressBase);
                    //if (actionResult.IsSuccess)
                    //{
                    //    addressListModel = CommonMethods.ConvertTo<SubjectAddressModel>(actionResult.dtResult);
                    //}
                    //model.subAddressList = addressListModel;

                    //subjectBase.SubjectID = Convert.ToInt32(id);
                    //actionResult = subjectAction.Subject_LoadById(subjectBase);
                    //if (actionResult.IsSuccess)
                    //{
                    //    DataRow dr = actionResult.dtResult.Rows[0];
                    //    model.subAddressModel.LogoFirstName = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : "";
                    //    model.subAddressModel.LogoLastName = dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : "";
                    //    model.subAddressModel.LogoMiddleName = dr["MiddleName"] != DBNull.Value ? dr["MiddleName"].ToString() : "";
                    //}
                    //model.subAddressModel = model.subAddressModel;
                }
                else
                {
                    return RedirectToAction("AddSubject");
                }

                //CIMS.ActionLayer.Employee.EmployeeAction employeeAction = new CIMS.ActionLayer.Employee.EmployeeAction();
                //EmployeeModel employeeModel = new EmployeeModel();
                //List<SelectListItem> AddressTypeList = new List<SelectListItem>();
                //actionResult = employeeAction.MasterAddressType_Load();
                //if (actionResult.IsSuccess)
                //{
                //    AddressTypeList = (from DataRow row in actionResult.dtResult.Rows
                //                       select new SelectListItem
                //                       {
                //                           Text = row["AddressType"] != DBNull.Value ? row["AddressType"].ToString() : "",
                //                           Value = row["id"] != DBNull.Value ? row["id"].ToString() : ""
                //                       }).ToList();
                //}
                //employeeModel.AddressTypeList = AddressTypeList;
                //model.EmployeeModel = employeeModel;

            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return View(model);
        }

        //Ankur New
        [HttpGet]
        public ActionResult SearchInSubjectAddress()
        {
            bool permission = (Session["Admin"] == null ? CIMS.Models.CheckPermissions.permissionMenu("Subject Addresses", Convert.ToInt32(Session["UserId"])) : CIMS.Models.CheckAdminPermissions.permissionMenu("Subject"));
            if (!permission)
            {
                return Redirect("~/Home/NoPermission");
            }
            ManageSubjectAddressModel model = new ManageSubjectAddressModel();
            List<SubjectAddressModel> addressListModel = new List<SubjectAddressModel>();
            SubjectAddressModel addressModel = new SubjectAddressModel();
            model.subAddressList = addressListModel;
            model.subAddressModel = addressModel;

            CIMS.ActionLayer.Employee.EmployeeAction employeeAction = new CIMS.ActionLayer.Employee.EmployeeAction();
            EmployeeModel employeeModel = new EmployeeModel();
            List<SelectListItem> AddressTypeList = new List<SelectListItem>();
            actionResult = employeeAction.MasterAddressType_Load();
            if (actionResult.IsSuccess)
            {
                AddressTypeList = (from DataRow row in actionResult.dtResult.Rows
                                   select new SelectListItem
                                   {
                                       Text = row["AddressType"] != DBNull.Value ? row["AddressType"].ToString() : "",
                                       Value = row["id"] != DBNull.Value ? row["id"].ToString() : ""
                                   }).ToList();
            }
            employeeModel.AddressTypeList = AddressTypeList;
            model.EmployeeModel = employeeModel;

            return View(model);
        }

        //Ankur New 1
        [HttpGet]
        public ActionResult SearchInSubjectFeatures(int? id = 0)
        {
            bool permission = (Session["Admin"] == null ? CIMS.Models.CheckPermissions.permissionMenu("Subject Features", Convert.ToInt32(Session["UserId"])) : CIMS.Models.CheckAdminPermissions.permissionMenu("Subject"));
            if (!permission)
            {
                return Redirect("~/Home/NoPermission");
            }
            ManageSubjectMarkModel model = new ManageSubjectMarkModel();
            List<SubjectMarkModel> featureListModel = new List<SubjectMarkModel>();
            SubjectMarkModel featureModel = new SubjectMarkModel();
            model.subFeatureList = featureListModel;
            model.subFeatureModel = featureModel;
            try
            {
                List<SelectListItem> lstFType = new List<SelectListItem>();
                CIMS.ActionLayer.Setting.SettingAction settingAction = new CIMS.ActionLayer.Setting.SettingAction();
                actionResult = settingAction.FeatureType_Load();
                if (actionResult.IsSuccess)
                {
                    lstFType = (from DataRow row in actionResult.dtResult.Rows
                                select new SelectListItem
                                {
                                    Text = row["FeatureType"] != DBNull.Value ? row["FeatureType"].ToString() : "",
                                    Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                }).ToList();
                }
                ViewBag.lstFType = lstFType;

                List<SelectListItem> lstFLocation = new List<SelectListItem>();
                actionResult = settingAction.FeatureLocation_Load();
                if (actionResult.IsSuccess)
                {
                    lstFLocation = (from DataRow row in actionResult.dtResult.Rows
                                    select new SelectListItem
                                    {
                                        Text = row["FLocation"] != DBNull.Value ? row["FLocation"].ToString() : "",
                                        Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                    }).ToList();
                }
                ViewBag.lstFLocation = lstFLocation;

                //if (id > 0)
                //{
                //    model.subFeatureModel.SubjectID = Convert.ToInt32(id);
                //    subjectFeatureBase.SubjectID = Convert.ToInt32(id);
                //    actionResult = subjectAction.SubjectMarks_LoadBySubjectId(subjectFeatureBase);
                //    if (actionResult.IsSuccess)
                //    {
                //        featureListModel = CommonMethods.ConvertTo<SubjectMarkModel>(actionResult.dtResult);
                //    }
                //    model.subFeatureList = featureListModel;

                //    subjectBase.SubjectID = Convert.ToInt32(id);
                //    actionResult = subjectAction.Subject_LoadById(subjectBase);
                //    if (actionResult.IsSuccess)
                //    {
                //        DataRow dr = actionResult.dtResult.Rows[0];
                //        model.subFeatureModel.LogoFirstName = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : "";
                //        model.subFeatureModel.LogoLastName = dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : "";
                //        model.subFeatureModel.LogoMiddleName = dr["MiddleName"] != DBNull.Value ? dr["MiddleName"].ToString() : "";
                //    }
                //    model.subFeatureModel = model.subFeatureModel;

                //}
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return View(model);
        }

        //Ankur New 1
        [HttpPost]
        public ActionResult SearchinSubjectFeatures(ManageSubjectMarkModel model)
        {
            List<SubjectMarkModel> subjectList = new List<SubjectMarkModel>();
            try
            {
                // employee.EmpID = 1;

                actionResult = subjectAction.AdvancedSearchSubjectFeatures(model.subFeatureModel.FeatureType, model.subFeatureModel.FeatureLocation, null, null);

                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    subjectList = (from DataRow dr in actionResult.dtResult.Rows
                                   select new SubjectMarkModel
                                   {
                                       SubjectID = dr["SubjectID"] != DBNull.Value ? Convert.ToInt32(dr["SubjectID"]) : 0,
                                       FirstName = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : "",
                                       LastName = dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : "",
                                       VIP = dr["VIP"] != DBNull.Value ? dr["VIP"].ToString() : "",
                                       ModifiedDate = dr["ModifiedDate"] != DBNull.Value ? dr["ModifiedDate"].ToString() : "",

                                   }).ToList();

                    model.subFeatureList = subjectList;

                }


                List<SelectListItem> lstFType = new List<SelectListItem>();
                CIMS.ActionLayer.Setting.SettingAction settingAction = new CIMS.ActionLayer.Setting.SettingAction();
                actionResult = settingAction.FeatureType_Load();
                if (actionResult.IsSuccess)
                {
                    lstFType = (from DataRow row in actionResult.dtResult.Rows
                                select new SelectListItem
                                {
                                    Text = row["FeatureType"] != DBNull.Value ? row["FeatureType"].ToString() : "",
                                    Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                }).ToList();
                }
                ViewBag.lstFType = lstFType;

                List<SelectListItem> lstFLocation = new List<SelectListItem>();
                actionResult = settingAction.FeatureLocation_Load();
                if (actionResult.IsSuccess)
                {
                    lstFLocation = (from DataRow row in actionResult.dtResult.Rows
                                    select new SelectListItem
                                    {
                                        Text = row["FLocation"] != DBNull.Value ? row["FLocation"].ToString() : "",
                                        Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                    }).ToList();
                }
                ViewBag.lstFLocation = lstFLocation;
                //TempData["SubjectIdListfromFeatures"] = subjectList;
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }

            //TempData["SubjectIdListfromFeatures"] = subjectList;
            //return RedirectToAction("Index");
            return View(model);
        }

        [HttpGet]
        public JsonResult GetSubjectAddressByAddressId(int? Id = 0)
        {
            string json = "";
            ManageSubjectAddressModel model = new ManageSubjectAddressModel();
            List<SubjectAddressModel> addressListModel = new List<SubjectAddressModel>();
            SubjectAddressModel addressModel = new SubjectAddressModel();
            model.subAddressList = addressListModel;
            model.subAddressModel = addressModel;
            try
            {
                if (Id > 0)
                {

                    subjectAddressBase.AddressID = Convert.ToInt32(Id);
                    actionResult = subjectAction.SubjectAddress_LoadById(subjectAddressBase);
                    if (actionResult.IsSuccess)
                    {
                        addressListModel = CommonMethods.ConvertTo<SubjectAddressModel>(actionResult.dtResult);
                        if (addressListModel.Count > 0)
                            addressModel = addressListModel.FirstOrDefault();
                        json = Newtonsoft.Json.JsonConvert.SerializeObject(addressModel);
                    }
                }

            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult SubjectAddress(ManageSubjectAddressModel model, FormCollection fc)
        {
            try
            {
                subjectAddressBase.AddressType = model.subAddressModel.AddressType;
                subjectAddressBase.Address = model.subAddressModel.Address;
                subjectAddressBase.AddressID = model.subAddressModel.AddressID;
                subjectAddressBase.Apartment = model.subAddressModel.Apartment;
                subjectAddressBase.SubjectID = model.subAddressModel.SubjectID;
                subjectAddressBase.CountryID = model.subAddressModel.CountryID;
                subjectAddressBase.ProvState = model.subAddressModel.ProvState;
                subjectAddressBase.PostalZip = model.subAddressModel.PostalZip;
                subjectAddressBase.IncidentID = model.subAddressModel.IncidentID;
                subjectAddressBase.City = model.subAddressModel.City;
                actionResult = subjectAction.SubjectAddress_InsertUpdate(subjectAddressBase);
                if (actionResult.IsSuccess)
                {
                    int result = Convert.ToInt32(actionResult.dtResult.Rows[0][0]);
                    if (result > 0)
                    {
                        if (model.subAddressModel.AddressID > 0)
                            TempData["SuccessMessage"] = "Subject Address Updated Successfully.";
                        else
                            TempData["SuccessMessage"] = "Subject Address Added Successfully.";
                    }
                    else
                        TempData["ErrorMessage"] = "Some error Occurred, please try again later.";

                }
                else
                    TempData["ErrorMessage"] = "Some error Occurred, please try again later.";

            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return RedirectToAction("SubjectAlias", new { Type = "Subject", @id = model.subAddressModel.SubjectID });
        }

        #region Delete Subject Address
        [HttpPost]
        public JsonResult DeleteSubjectAddress(int? Id = 0)
        {
            string json = string.Empty;
            try
            {
                subjectAddressBase.AddressID = Convert.ToInt32(Id);
                actionResult = subjectAction.SubjectAddress_DeleteById(subjectAddressBase);
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
        #endregion

        #region SubjectAlias
        [HttpGet]
        public ActionResult SubjectAlias(int? id = 0)
        {
            bool permission = (Session["Admin"] == null ? CIMS.Models.CheckPermissions.permissionMenu("Subject Aliases", Convert.ToInt32(Session["UserId"])) : CIMS.Models.CheckAdminPermissions.permissionMenu("Subject"));
            if (!permission)
            {
                return Redirect("~/Home/NoPermission");
            }

            List<SelectListItem> lstAliasNameType = new List<SelectListItem>();
            CIMS.ActionLayer.Setting.SettingAction settingAction = new CIMS.ActionLayer.Setting.SettingAction();
            actionResult = settingAction.AliasNameType_Load();
            if (actionResult.IsSuccess)
            {
                lstAliasNameType = (from DataRow row in actionResult.dtResult.Rows
                                    select new SelectListItem
                                    {
                                        Text = row["NameType"] != DBNull.Value ? row["NameType"].ToString() : "",
                                        Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                    }).ToList();
            }
            ViewBag.lstAliasNameType = lstAliasNameType;

            ManageSubjectAliasModel model = new ManageSubjectAliasModel();
            List<SubjectAliasModel> aliasListModel = new List<SubjectAliasModel>();
            SubjectAliasModel aliasModel = new SubjectAliasModel();
            model.subAliasList = aliasListModel;
            model.subAliasModel = aliasModel;
            try
            {
                if (id > 0)
                {
                    model.subAliasModel.SubjectID = Convert.ToInt32(id);
                    subjectAliasBase.SubjectID = Convert.ToInt32(id);
                    actionResult = subjectAction.SubjectAlias_LoadBySubjectId(subjectAliasBase);
                    if (actionResult.IsSuccess)
                    {
                        aliasListModel = CommonMethods.ConvertTo<SubjectAliasModel>(actionResult.dtResult);
                    }
                    model.subAliasList = aliasListModel;

                    subjectBase.SubjectID = Convert.ToInt32(id);
                    subjectBase.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    subjectBase.RoleID = Convert.ToInt32(Session["RoleId"]);
                    actionResult = subjectAction.Subject_LoadById(subjectBase);
                    if (actionResult.IsSuccess)
                    {
                        DataRow dr = actionResult.dtResult.Rows[0];
                        model.subAliasModel.LogoFirstName = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : "";
                        model.subAliasModel.LogoLastName = dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : "";
                        model.subAliasModel.LogoMiddleName = dr["MiddleName"] != DBNull.Value ? dr["MiddleName"].ToString() : "";
                        model.subAliasModel.CreatedBy = dr["CreatedBy"] != DBNull.Value ? Convert.ToInt32(dr["CreatedBy"]) : 0;
                        model.subAliasModel.EditPermission = dr["editpermission"] != DBNull.Value ? Convert.ToBoolean(dr["editpermission"]) : false;
                        model.subAliasModel.DeletePermission = dr["deletepermission"] != DBNull.Value ? Convert.ToBoolean(dr["deletepermission"]) : false;
                    }
                    model.subAliasModel = model.subAliasModel;

                }
                else
                {
                    return RedirectToAction("AddSubject");
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return View(model);
        }

        //Ankur New
        [HttpGet]
        public ActionResult SearchInSubjectAlias()
        {
            bool permission = (Session["Admin"] == null ? CIMS.Models.CheckPermissions.permissionMenu("Subject Aliases", Convert.ToInt32(Session["UserId"])) : CIMS.Models.CheckAdminPermissions.permissionMenu("Subject"));
            if (!permission)
            {
                return Redirect("~/Home/NoPermission");
            }

            List<SelectListItem> lstAliasNameType = new List<SelectListItem>();
            CIMS.ActionLayer.Setting.SettingAction settingAction = new CIMS.ActionLayer.Setting.SettingAction();
            actionResult = settingAction.AliasNameType_Load();
            if (actionResult.IsSuccess)
            {
                lstAliasNameType = (from DataRow row in actionResult.dtResult.Rows
                                    select new SelectListItem
                                    {
                                        Text = row["NameType"] != DBNull.Value ? row["NameType"].ToString() : "",
                                        Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                    }).ToList();
            }
            ViewBag.lstAliasNameType = lstAliasNameType;

            return View();
        }

        //Ankur New
        [HttpPost]
        public JsonResult FirstNameList(string Prefix)
        {
            var WordsArray = Prefix.Split();
            Prefix = WordsArray[0];

            actionResult = subjectAction.Subjects_FirstNameSearch(Prefix);

            var FirstName = (from DataRow row in actionResult.dtResult.Rows
                             select new
                             {
                                 FirstName = row["FirstName"] != DBNull.Value ? row["FirstName"].ToString().ToUpper() : "",
                                 SubjectID = row["SubjectID"] != DBNull.Value ? row["SubjectID"].ToString() : ""
                             }).ToList();


            return Json(FirstName, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public JsonResult SelectionList(string Prefix)
        //{
        //    SubjectBase subject = new SubjectBase();
        //    SubjectAction subjectAction = new SubjectAction();
        //    List<SubjectModel> subjectList = new List<SubjectModel>();
        //    subject.FirstName = Prefix;

        //    actionResult = subjectAction.Subjects_AdvancedSearch(subject);

        //    string jsonString = string.Empty;


        //    if (actionResult.dtResult.Rows.Count > 0)
        //    {

        //        subjectList = (from DataRow row in actionResult.dtResult.Rows
        //                       select new SubjectModel
        //                       {
        //                           SubjectID = row["SubjectID"] != DBNull.Value ? Convert.ToInt32(row["SubjectID"]) : 0,
        //                           FilePath = row["FilePath"] != DBNull.Value ? Convert.ToString(row["FilePath"]) : null,
        //                           VIP = row["VIP"] != DBNull.Value ? Convert.ToString(row["VIP"]) : null,
        //                           FirstName = row["FirstName"] != DBNull.Value ? row["FirstName"].ToString() : "",
        //                           LastName = row["LastName"] != DBNull.Value ? row["LastName"].ToString() : "",
        //                           ModifiedDate = row["ModifiedDate"] != DBNull.Value ? row["ModifiedDate"].ToString() : "",
        //                           MiddleName = row["MiddleName"] != DBNull.Value ? Convert.ToString(row["MiddleName"]) : null,
        //                           Sex = row["Sex"] != DBNull.Value ? Convert.ToString(row["Sex"]) : null,
        //                       }).ToList();

        //        jsonString += "" + actionResult.dtResult.Rows[0]["FirstName"].ToString() + "/" + actionResult.dtResult.Rows[0]["LastName"].ToString() + "/" + actionResult.dtResult.Rows[0]["MiddleName"].ToString() + "/" + actionResult.dtResult.Rows[0]["VIP"].ToString() + "/" + actionResult.dtResult.Rows[0]["sex"].ToString();

        //    }


        //    return Json(jsonString, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        public JsonResult SelectionList(string Prefix)
        {
            SubjectBase subject = new SubjectBase();
            SubjectAction subjectAction = new SubjectAction();
            List<SubjectModel> subjectList = new List<SubjectModel>();

            subject.FirstName = Prefix;

            actionResult = subjectAction.Subjects_AdvancedSearch(subject);

            string jsonString = string.Empty;

            if (actionResult.dtResult.Rows.Count > 0)
            {

                subjectList = (from DataRow row in actionResult.dtResult.Rows
                               select new SubjectModel
                               {
                                   SubjectID = row["SubjectID"] != DBNull.Value ? Convert.ToInt32(row["SubjectID"]) : 0,
                                   FilePath = row["FilePath"] != DBNull.Value ? Convert.ToString(row["FilePath"]) : null,
                                   VIP = row["VIP"] != DBNull.Value ? Convert.ToString(row["VIP"]) : null,
                                   FirstName = row["FirstName"] != DBNull.Value ? row["FirstName"].ToString() : "",
                                   LastName = row["LastName"] != DBNull.Value ? row["LastName"].ToString() : "",
                                   ModifiedDate = row["ModifiedDate"] != DBNull.Value ? row["ModifiedDate"].ToString() : "",
                                   MiddleName = row["MiddleName"] != DBNull.Value ? Convert.ToString(row["MiddleName"]) : null,
                                   Sex = row["Sex"] != DBNull.Value ? Convert.ToString(row["Sex"]) : null,
                               }).ToList();

                jsonString += "" + actionResult.dtResult.Rows[0]["FirstName"].ToString() + "/" + actionResult.dtResult.Rows[0]["LastName"].ToString() + "/" + actionResult.dtResult.Rows[0]["MiddleName"].ToString() + "/" + actionResult.dtResult.Rows[0]["VIP"].ToString() + "/" + actionResult.dtResult.Rows[0]["sex"].ToString();

            }


            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }

        //Ankur New
        //[HttpPost]
        //public JsonResult LastNameList(string Prefix, string FirstNameGet)
        //{
        //    //Note : you can bind same list from database
        //    List<SubjectModel> ObjList = new List<SubjectModel>();
        //    SubjectModel subjectModel = new SubjectModel();
        //    //actionResult = subjectAction.Subjects_LoadAll();
        //    SubjectInvolvedBase involve = new SubjectInvolvedBase();
        //    involve.FirstName = Prefix.Trim();
        //    involve.LastName = string.Empty;
        //    involve.Sex = string.Empty;
        //    involve.Race = string.Empty;
        //    actionResult = subjectAction.Subjects_Search(involve);

        //    ObjList = (from DataRow row in actionResult.dtResult.Rows
        //               select new SubjectModel
        //               {
        //                   //FirstName = row["FirstName"] != DBNull.Value ? row["FirstName"].ToString().ToUpper() : "",
        //                   //LastName = row["LastName"] != DBNull.Value ? row["LastName"].ToString().ToUpper() : "",
        //                   FirstName = row["FirstName"] != DBNull.Value ? row["FirstName"].ToString().ToUpper() : "",
        //                   LastName = row["LastName"] != DBNull.Value ? row["LastName"].ToString().ToUpper() : "",

        //               }).ToList();

        //    subjectModel.SubjectModelList = ObjList;

        //    //Searching records from list using LINQ query  
        //    var LastName = (from N in ObjList
        //                    where N.LastName.Contains(Prefix.ToUpper())
        //                    select new { N.LastName });
        //    return Json(LastName, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        public JsonResult LastNameList(string Prefix, string FirstNameGet)
        {
            //Note : you can bind same list from database
            actionResult = subjectAction.Subjects_LastNameSearch(FirstNameGet.Trim(), Prefix.Trim());

            var LastName = (from DataRow row in actionResult.dtResult.Rows
                            select new
                            {
                                LastName = row["LastName"] != DBNull.Value ? row["LastName"].ToString().ToUpper() : ""
                            }).ToList();


            //Searching records from list using LINQ query  

            return Json(LastName, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetSubjectAliasByAliasId(int? Id = 0)
        {
            string json = "";
            ManageSubjectAliasModel model = new ManageSubjectAliasModel();
            List<SubjectAliasModel> aliasListModel = new List<SubjectAliasModel>();
            SubjectAliasModel aliasModel = new SubjectAliasModel();
            model.subAliasList = aliasListModel;
            model.subAliasModel = aliasModel;
            try
            {
                if (Id > 0)
                {

                    subjectAliasBase.AliasID = Convert.ToInt32(Id);
                    actionResult = subjectAction.SubjectAlias_LoadById(subjectAliasBase);
                    if (actionResult.IsSuccess)
                    {
                        aliasListModel = CommonMethods.ConvertTo<SubjectAliasModel>(actionResult.dtResult);
                        if (aliasListModel.Count > 0)
                            aliasModel = aliasListModel.FirstOrDefault();
                        json = Newtonsoft.Json.JsonConvert.SerializeObject(aliasModel);
                    }
                }

            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SubjectAlias(ManageSubjectAliasModel model)
        {
            try
            {
                subjectAliasBase.SubjectID = model.subAliasModel.SubjectID;
                subjectAliasBase.AliasID = model.subAliasModel.AliasID;
                subjectAliasBase.NameType = model.subAliasModel.NameType;
                subjectAliasBase.FirstName = model.subAliasModel.FirstName;
                subjectAliasBase.MiddleName = model.subAliasModel.MiddleName;
                subjectAliasBase.LastName = model.subAliasModel.LastName;
                actionResult = subjectAction.SubjectAlias_InsertUpdate(subjectAliasBase);
                if (actionResult.IsSuccess)
                {
                    int result = Convert.ToInt32(actionResult.dtResult.Rows[0][0]);
                    if (result > 0)
                    {
                        if (model.subAliasModel.AliasID > 0)
                            TempData["SuccessMessage"] = "Subject Alias Updated Successfully.";
                        else
                            TempData["SuccessMessage"] = "Subject Alias Added Successfully.";
                    }
                    else
                        TempData["ErrorMessage"] = "Some error Occurred, please try again later.";

                }
                else
                    TempData["ErrorMessage"] = "Some error Occurred, please try again later.";

            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return RedirectToAction("SubjectFeatures", new { Type = "Subject", @id = model.subAliasModel.SubjectID });
        }

        #region Delete Subject Alias
        [HttpPost]
        public JsonResult DeleteSubjectAlias(int? Id = 0)
        {
            string json = string.Empty;
            try
            {
                subjectAliasBase.AliasID = Convert.ToInt32(Id);
                actionResult = subjectAction.SubjectAlias_DeleteById(subjectAliasBase);
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
        #endregion

        #region Subject Features
        [HttpGet]
        public ActionResult SubjectFeatures(int? id = 0)
        {
            bool permission = (Session["Admin"] == null ? CIMS.Models.CheckPermissions.permissionMenu("Subject Features", Convert.ToInt32(Session["UserId"])) : CIMS.Models.CheckAdminPermissions.permissionMenu("Subject"));
            if (!permission)
            {
                return Redirect("~/Home/NoPermission");
            }
            ManageSubjectMarkModel model = new ManageSubjectMarkModel();
            List<SubjectMarkModel> featureListModel = new List<SubjectMarkModel>();
            SubjectMarkModel featureModel = new SubjectMarkModel();
            model.subFeatureList = featureListModel;
            model.subFeatureModel = featureModel;
            try
            {
                List<SelectListItem> lstFType = new List<SelectListItem>();
                CIMS.ActionLayer.Setting.SettingAction settingAction = new CIMS.ActionLayer.Setting.SettingAction();
                actionResult = settingAction.FeatureType_Load();
                if (actionResult.IsSuccess)
                {
                    lstFType = (from DataRow row in actionResult.dtResult.Rows
                                select new SelectListItem
                                {
                                    Text = row["FeatureType"] != DBNull.Value ? row["FeatureType"].ToString() : "",
                                    Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                }).ToList();
                }
                ViewBag.lstFType = lstFType;

                List<SelectListItem> lstFLocation = new List<SelectListItem>();
                actionResult = settingAction.FeatureLocation_Load();
                if (actionResult.IsSuccess)
                {
                    lstFLocation = (from DataRow row in actionResult.dtResult.Rows
                                    select new SelectListItem
                                    {
                                        Text = row["FLocation"] != DBNull.Value ? row["FLocation"].ToString() : "",
                                        Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                    }).ToList();
                }
                ViewBag.lstFLocation = lstFLocation;

                if (id > 0)
                {
                    model.subFeatureModel.SubjectID = Convert.ToInt32(id);
                    subjectFeatureBase.SubjectID = Convert.ToInt32(id);
                    actionResult = subjectAction.SubjectMarks_LoadBySubjectId(subjectFeatureBase);
                    if (actionResult.IsSuccess)
                    {
                        featureListModel = CommonMethods.ConvertTo<SubjectMarkModel>(actionResult.dtResult);
                    }
                    model.subFeatureList = featureListModel;

                    subjectBase.SubjectID = Convert.ToInt32(id);
                    subjectBase.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    subjectBase.RoleID = Convert.ToInt32(Session["RoleId"]);
                    actionResult = subjectAction.Subject_LoadById(subjectBase);
                    if (actionResult.IsSuccess)
                    {
                        DataRow dr = actionResult.dtResult.Rows[0];
                        model.subFeatureModel.LogoFirstName = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : "";
                        model.subFeatureModel.LogoLastName = dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : "";
                        model.subFeatureModel.LogoMiddleName = dr["MiddleName"] != DBNull.Value ? dr["MiddleName"].ToString() : "";
                        model.subFeatureModel.CreatedBy = dr["CreatedBy"] != DBNull.Value ? Convert.ToInt32(dr["CreatedBy"]) : 0;
                        model.subFeatureModel.EditPermission = dr["editpermission"] != DBNull.Value ? Convert.ToBoolean(dr["editpermission"]) : false;
                        model.subFeatureModel.DeletePermission = dr["deletepermission"] != DBNull.Value ? Convert.ToBoolean(dr["deletepermission"]) : false;
                    }
                    model.subFeatureModel = model.subFeatureModel;

                }
                else
                {
                    return RedirectToAction("AddSubject");
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return View(model);
        }

        [HttpGet]
        public JsonResult GetSubjectFeatureById(int? Id = 0)
        {
            string json = "";
            ManageSubjectMarkModel model = new ManageSubjectMarkModel();
            List<SubjectMarkModel> featureListModel = new List<SubjectMarkModel>();
            SubjectMarkModel featureModel = new SubjectMarkModel();
            model.subFeatureList = featureListModel;
            model.subFeatureModel = featureModel;
            try
            {
                if (Id > 0)
                {
                    subjectFeatureBase.MarkID = Convert.ToInt32(Id);
                    actionResult = subjectAction.SubjectMarks_LoadById(subjectFeatureBase);
                    if (actionResult.IsSuccess)
                    {
                        featureListModel = CommonMethods.ConvertTo<SubjectMarkModel>(actionResult.dtResult);
                        if (featureListModel.Count > 0)
                            featureModel = featureListModel.FirstOrDefault();
                        json = Newtonsoft.Json.JsonConvert.SerializeObject(featureModel);
                    }
                }

            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SubjectFeatures(ManageSubjectMarkModel model)
        {
            try
            {
                subjectFeatureBase.SubjectID = model.subFeatureModel.SubjectID;
                subjectFeatureBase.MarkID = model.subFeatureModel.MarkID;
                subjectFeatureBase.MediaID = model.subFeatureModel.MediaID;
                subjectFeatureBase.Description = model.subFeatureModel.Description;
                subjectFeatureBase.FeatureLocation = model.subFeatureModel.FeatureLocation;
                subjectFeatureBase.FeatureType = model.subFeatureModel.FeatureType;
                actionResult = subjectAction.SubjectMark_InsertUpdate(subjectFeatureBase);
                if (actionResult.IsSuccess)
                {
                    int result = Convert.ToInt32(actionResult.dtResult.Rows[0][0]);
                    if (result > 0)
                    {
                        if (model.subFeatureModel.MarkID > 0)
                            TempData["SuccessMessage"] = "Subject Feature Updated Successfully.";
                        else
                            TempData["SuccessMessage"] = "Subject Feature Added Successfully.";
                    }
                    else
                        TempData["ErrorMessage"] = "Some error Occurred, please try again later.";

                }
                else
                    TempData["ErrorMessage"] = "Some error Occurred, please try again later.";

            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return RedirectToAction("SubjectIdentification", new { Type = "Subject", @id = model.subFeatureModel.SubjectID });
        }

        #region Delete Subject Feature
        [HttpPost]
        public JsonResult DeleteSubjectFeature(int? Id = 0)
        {
            string json = string.Empty;
            try
            {
                subjectFeatureBase.MarkID = Convert.ToInt32(Id);
                actionResult = subjectAction.SubjectMarks_DeleteById(subjectFeatureBase);
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

        #endregion

        #region Subject Identification
        [HttpGet]
        public ActionResult SubjectIdentification(int? id = 0)
        {
            CIMS.ActionLayer.Setting.SettingAction settingAction = new CIMS.ActionLayer.Setting.SettingAction();
            bool permission = (Session["Admin"] == null ? CIMS.Models.CheckPermissions.permissionMenu("Subject Identification", Convert.ToInt32(Session["UserId"])) : CIMS.Models.CheckAdminPermissions.permissionMenu("Subject"));
            if (!permission)
            {
                return Redirect("~/Home/NoPermission");
            }
            SubjectIdentificationModel model = new SubjectIdentificationModel();
            List<SubjectIdentificationModel> identidicationList = new List<SubjectIdentificationModel>();
            model.SubjectID = Convert.ToInt32(id);
            try
            {
                if (id > 0)
                {
                    subjectIdentificationBase.SubjectID = model.SubjectID;
                    actionResult = subjectAction.SubjectIdentification_LoadBySubjectId(subjectIdentificationBase);
                    if (actionResult.IsSuccess)
                    {
                        identidicationList = CommonMethods.ConvertTo<SubjectIdentificationModel>(actionResult.dtResult);
                        model = identidicationList.FirstOrDefault();
                    }

                    subjectBase.SubjectID = Convert.ToInt32(id);
                    subjectBase.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    subjectBase.RoleID = Convert.ToInt32(Session["RoleId"]);
                    actionResult = subjectAction.Subject_LoadById(subjectBase);
                    if (actionResult.IsSuccess)
                    {
                        DataRow dr = actionResult.dtResult.Rows[0];
                        model.LogoFirstName = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : "";
                        model.LogoLastName = dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : "";
                        model.LogoMiddleName = dr["MiddleName"] != DBNull.Value ? dr["MiddleName"].ToString() : "";
                        model.CreatedBy = dr["CreatedBy"] != DBNull.Value ? Convert.ToInt32(dr["CreatedBy"]) : 0;
                        model.EditPermission = dr["editpermission"] != DBNull.Value ? Convert.ToBoolean(dr["editpermission"]) : false;
                        model.DeletePermission = dr["deletepermission"] != DBNull.Value ? Convert.ToBoolean(dr["deletepermission"]) : false;
                    }
                    List<SelectListItem> lstIdentification1 = new List<SelectListItem>();
                    actionResult = settingAction.MasterTypeID1_Load();
                    if (actionResult.IsSuccess)
                    {
                        lstIdentification1 = (from DataRow row in actionResult.dtResult.Rows
                                              select new SelectListItem
                                              {
                                                  Text = row["Value"] != DBNull.Value ? row["Value"].ToString() : "",
                                                  Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                              }).ToList();

                    }
                    model.lstIdentification1 = lstIdentification1;
                    ViewBag.lstIdentification1 = lstIdentification1;

                    //List<SelectListItem> lstIdentification2 = new List<SelectListItem>();
                    //actionResult = settingAction.MasterTypeID2_Load();
                    //if (actionResult.IsSuccess)
                    //{
                    //    lstIdentification2 = (from DataRow row in actionResult.dtResult.Rows
                    //                          select new SelectListItem
                    //                          {
                    //                              Text = row["Value"] != DBNull.Value ? row["Value"].ToString() : "",
                    //                              Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                    //                          }).ToList();
                    //}
                    //model.lstIdentification2 = lstIdentification2;
                    //ViewBag.lstIdentification2 = lstIdentification2;

                    //List<SelectListItem> lstIdentification3 = new List<SelectListItem>();
                    //actionResult = settingAction.MasterTypeID3_Load();

                    //if (actionResult.IsSuccess)
                    //{
                    //    lstIdentification3 = (from DataRow row in actionResult.dtResult.Rows
                    //                          select new SelectListItem
                    //                          {
                    //                              Text = row["Value"] != DBNull.Value ? row["Value"].ToString() : "",
                    //                              Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                    //                          }).ToList();
                    //}
                    //model.lstIdentification3 = lstIdentification3;
                    //ViewBag.lstIdentification3 = lstIdentification3;
                }
                else
                {
                    return RedirectToAction("AddSubject");
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return View(model);
        }

        public JsonResult Get_NextLCTIDSequential()
        {
            string json = "";
            try
            {
                actionResult = subjectAction.Get_NextLCTIDSequential();
                if (actionResult.IsSuccess)
                {
                    int result = Convert.ToInt32(actionResult.dtResult.Rows[0][0]);
                    json = Newtonsoft.Json.JsonConvert.SerializeObject(result);
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        public string Get_NextLCTIDSequentialString()
        {
            string strjson = "";
            try
            {
                actionResult = subjectAction.Get_NextLCTIDSequential();
                if (actionResult.IsSuccess)
                {
                    int result = Convert.ToInt32(actionResult.dtResult.Rows[0][0]);

                    //int result = Convert.ToInt32(actionResult.dtResult.Rows[0][0]);
                    strjson = Newtonsoft.Json.JsonConvert.SerializeObject(result).ToString();
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return strjson;
        }

        [HttpPost]
        public ActionResult SubjectIdentification(SubjectIdentificationModel model)
        {
            try
            {
                subjectIdentificationBase.SubjectID = model.SubjectID;
                subjectIdentificationBase.ID = model.Idss;
                subjectIdentificationBase.BusinessName = model.BusinessName;
                subjectIdentificationBase.LCTID = model.LCTID;
                subjectIdentificationBase.Occupation = model.Occupation;
                subjectIdentificationBase.IDType1 = model.IDType1;
                subjectIdentificationBase.IDType2 = model.IDType2;
                subjectIdentificationBase.IDType3 = model.IDType3;
                subjectIdentificationBase.IDDefault1 = Convert.ToBoolean(model.IDDefault1);
                subjectIdentificationBase.IDDefault2 = Convert.ToBoolean(model.IDDefault2);
                subjectIdentificationBase.IDDefault3 = Convert.ToBoolean(model.IDDefault3);
                subjectIdentificationBase.IDNumber1 = model.IDNumber1;
                subjectIdentificationBase.IDNumber2 = model.IDNumber2;
                subjectIdentificationBase.IDNumber3 = model.IDNumber3;
                actionResult = subjectAction.SubjectIdentification_InsertUpdate(subjectIdentificationBase);
                if (actionResult.IsSuccess)
                {
                    int result = Convert.ToInt32(actionResult.dtResult.Rows[0][0]);
                    if (result > 0)
                    {
                        if (model.Idss > 0)
                            TempData["SuccessMessage"] = "Subject Identification Updated Successfully.";
                        else
                            TempData["SuccessMessage"] = "Subject Identification Added Successfully.";
                    }
                    else
                        TempData["ErrorMessage"] = "Some error Occurred, please try again later.";
                }
                else
                    TempData["ErrorMessage"] = "Some error Occurred, please try again later.";

            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return RedirectToAction("SubjectIdentification", new { Type = "Subject", @id = model.SubjectID });
        }


        #endregion

        #region Subject LCT Totals
        [HttpGet]
        public ActionResult SubjectLCTTotals(int id = 0)
        {
            bool permission = (Session["Admin"] == null ? CIMS.Models.CheckPermissions.permissionMenu("Subject LCT Totals", Convert.ToInt32(Session["UserId"])) : CIMS.Models.CheckAdminPermissions.permissionMenu("Subject"));
            if (!permission)
            {
                return Redirect("~/Home/NoPermission");
            }
            if (id > 0)
            {
                LCTIdentificationModel model = new LCTIdentificationModel();

                subjectBase.SubjectID = Convert.ToInt32(id);
                subjectBase.CreatedBy = Convert.ToInt32(Session["UserID"]);
                subjectBase.RoleID = Convert.ToInt32(Session["RoleId"]);
                actionResult = subjectAction.Subject_LoadById(subjectBase);
                if (actionResult.IsSuccess)
                {
                    DataRow dr = actionResult.dtResult.Rows[0];
                    model.LogoFirstName = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : "";
                    model.LogoLastName = dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : "";
                    model.LogoMiddleName = dr["MiddleName"] != DBNull.Value ? dr["MiddleName"].ToString() : "";
                    model.EditPermission = dr["editpermission"] != DBNull.Value ? Convert.ToBoolean(dr["editpermission"]) : false;
                    model.DeletePermission = dr["deletepermission"] != DBNull.Value ? Convert.ToBoolean(dr["deletepermission"]) : false;
                }

                model.SubjectID = id;
                return View(model);
            }
            else
            {
                return RedirectToAction("AddSubject");
            }

        }
        #endregion

        #region Method IncidentList_print

        // [HttpPost]
        public JsonResult IncidentList_print(int value, string startDate, string endDate)
        {
            LCTIdentificationModel incidentListModel = new LCTIdentificationModel();
            string jsonString = string.Empty;
            List<LCTIdentificationModel> lctIdentificationList = new List<LCTIdentificationModel>();
            LCTIdentificationBase lctIdentificationBase = new LCTIdentificationBase();
            try
            {
                lctIdentificationBase.SubjectID = value;
                lctIdentificationBase.StartDate = startDate;
                lctIdentificationBase.EndDate = endDate;

                actionResult = subjectAction.LCTTotals_Load(lctIdentificationBase);

                if (actionResult.IsSuccess && actionResult.dsResult.Tables[0].Rows.Count > 0 && actionResult.dsResult.Tables[1].Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dsResult.Tables[0].Rows.Count; i++)
                    {
                        jsonString += "<tr><td class='td-border'>" + actionResult.dsResult.Tables[0].Rows[i]["IncidentNumber"]
                            + "</td><td class='td-border'>" + Convert.ToDateTime(actionResult.dsResult.Tables[0].Rows[i]["IncidentDate"]).ToShortDateString()
                            + "</td><td class='td-border'>" + actionResult.dsResult.Tables[0].Rows[i]["Amount"]
                            + "</td><td class='td-border'>" + actionResult.dsResult.Tables[0].Rows[i]["TransactionType"];
                        jsonString += "</td></tr>";
                    }
                    if (actionResult.dsResult.Tables[1].Rows.Count > 0)
                    {

                        lctIdentificationList = (from DataRow row in actionResult.dsResult.Tables[1].Rows
                                                 select new LCTIdentificationModel
                                                 {
                                                     JsonString = jsonString,
                                                     BuyInCash = row["BuyInCash"] != DBNull.Value ? Convert.ToDecimal(row["BuyInCash"]) : 0,
                                                     BuyInMarker = row["BuyInMarker"] != DBNull.Value ? Convert.ToDecimal(row["BuyInMarker"]) : 0,
                                                     CashOutCash = row["CashOutCash"] != DBNull.Value ? Convert.ToDecimal(row["CashOutCash"]) : 0,
                                                     CashOutMarker = row["CashoutMarker"] != DBNull.Value ? Convert.ToDecimal(row["CashoutMarker"]) : 0,
                                                     CashCall = row["CashCall"] != DBNull.Value ? Convert.ToDecimal(row["CashCall"]) : 0,
                                                     ForeignExchange = row["ForeignExchange"] != DBNull.Value ? Convert.ToDecimal(row["ForeignExchange"]) : 0
                                                 }).ToList();

                    }
                    incidentListModel.LCTIdentificationList = lctIdentificationList;
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
            return Json(lctIdentificationList, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Subject Watch
        [HttpGet]
        public ActionResult SubjectWatchList(int? id = 0)
        {
            bool permission = (Session["Admin"] == null ? CIMS.Models.CheckPermissions.permissionMenu("Subject Watch List", Convert.ToInt32(Session["UserId"])) : CIMS.Models.CheckAdminPermissions.permissionMenu("Subject"));
            if (!permission)
            {
                return Redirect("~/Home/NoPermission");
            }
            if (id > 0)
            {
                ViewBag.SubjectId = id;

                subjectBase.SubjectID = Convert.ToInt32(id);
                subjectBase.CreatedBy = Convert.ToInt32(Session["UserID"]);
                subjectBase.RoleID = Convert.ToInt32(Session["RoleId"]);
                actionResult = subjectAction.Subject_LoadById(subjectBase);
                if (actionResult.IsSuccess)
                {
                    DataRow dr = actionResult.dtResult.Rows[0];
                    ViewBag.LogoFirstName = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : "";
                    ViewBag.LogoLastName = dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : "";
                    ViewBag.LogoMiddleName = dr["MiddleName"] != DBNull.Value ? dr["MiddleName"].ToString() : "";
                    ViewBag.CreatedBy = dr["CreatedBy"] != DBNull.Value ? Convert.ToInt32(dr["CreatedBy"]) : 0;
                    ViewBag.EditPermission = dr["editpermission"] != DBNull.Value ? Convert.ToBoolean(dr["editpermission"]) : false;
                    ViewBag.DeletePermission = dr["deletepermission"] != DBNull.Value ? Convert.ToBoolean(dr["deletepermission"]) : false;
                }

                return View();
            }
            else
            {
                return RedirectToAction("AddSubject");
            }

        }

        public JsonResult GetWatchListBySubjectId(int? SubjectId = 0)
        {
            string json = "";
            List<SubjectWatchListModel> watchListModel = new List<SubjectWatchListModel>();
            try
            {
                if (SubjectId > 0)
                {

                    subjectWatchBase.SubjectID = Convert.ToInt32(SubjectId);
                    actionResult = subjectAction.SubjectWatch_LoadBySubjectId(subjectWatchBase);
                    if (actionResult.IsSuccess)
                    {
                        watchListModel = CommonMethods.ConvertTo<SubjectWatchListModel>(actionResult.dtResult);
                        json = Newtonsoft.Json.JsonConvert.SerializeObject(watchListModel);
                    }
                }

            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SubjectWatchList(FormCollection fc)
        {
            int SubjectId = !String.IsNullOrEmpty(fc["hdnSubject"]) ? Convert.ToInt32(fc["hdnSubject"]) : 0;
            try
            {
                string xml = !String.IsNullOrEmpty(fc["hdnXml"]) ? Convert.ToString(fc["hdnXml"]) : "<root></root>";

                if (xml == "<root></root>")
                    subjectWatchBase.IsDelete = true;
                else
                    subjectWatchBase.IsDelete = false;
                subjectWatchBase.Xml = xml;
                subjectWatchBase.SubjectID = SubjectId;
                actionResult = subjectAction.SubjectWatch_InsertUpdate(subjectWatchBase);
                if (actionResult.IsSuccess)
                {
                    TempData["SuccessMessage"] = "Subject Watch Saved Successfully.";
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return RedirectToAction("SubjectWatchList", new { Type = "Subject", @id = SubjectId });
        }



        public JsonResult GetWatchList()
        {
            string json = "";
            List<WatchModel> watchList = new List<WatchModel>();
            try
            {

                actionResult = subjectAction.WatchList_LoadAll();
                if (actionResult.IsSuccess)
                {
                    watchList = CommonMethods.ConvertTo<WatchModel>(actionResult.dtResult);
                    json = Newtonsoft.Json.JsonConvert.SerializeObject(watchList);
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveWatchName(string WatchName, int? WatchID = 0)
        {
            string json = "";
            List<WatchModel> watchList = new List<WatchModel>();
            try
            {
                watchBase.WatchID = Convert.ToInt32(WatchID);
                watchBase.WatchName = WatchName;
                actionResult = subjectAction.WatchName_InsertUpdate(watchBase);
                if (actionResult.IsSuccess)
                {
                    int result = actionResult.dtResult.Rows[0][0] != DBNull.Value ? Convert.ToInt32(actionResult.dtResult.Rows[0][0]) : 0;
                    if (result > 0)
                        json = "1";
                    else
                        json = "0";
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetWatchNameByWatchId(int? WatchID = 0)
        {
            string json = "";
            List<WatchModel> watchList = new List<WatchModel>();
            WatchModel model = new WatchModel();
            try
            {
                watchBase.WatchID = Convert.ToInt32(WatchID);
                actionResult = subjectAction.WatchName_LoadById(watchBase);
                if (actionResult.IsSuccess)
                {
                    watchList = CommonMethods.ConvertTo<WatchModel>(actionResult.dtResult);
                    model = watchList.FirstOrDefault();
                    json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        #region Delete Watch
        [HttpPost]
        public JsonResult DeleteWatch(int? Id = 0)
        {
            string json = string.Empty;
            try
            {
                watchBase.WatchID = Convert.ToInt32(Id);
                actionResult = subjectAction.WatchName_DeleteById(watchBase);
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
        #endregion

        #region Subject Linked
        [HttpGet]
        public ActionResult SubjectLinked(int? id = 0)
        {
            bool permission = (Session["Admin"] == null ? CIMS.Models.CheckPermissions.permissionMenu("Subject Linked", Convert.ToInt32(Session["UserId"])) : CIMS.Models.CheckAdminPermissions.permissionMenu("Subject"));
            if (!permission)
            {
                return Redirect("~/Home/NoPermission");
            }
            ManageSubjectLinkedModel model = new ManageSubjectLinkedModel();
            List<SubjectLinkedModel> linkedListModel = new List<SubjectLinkedModel>();
            SubjectLinkedModel linkedModel = new SubjectLinkedModel();
            model.subLinkedList = linkedListModel;
            model.subLinkedModel = linkedModel;
            try
            {
                if (id > 0)
                {
                    model.subLinkedModel.SubjectID = Convert.ToInt32(id);
                    subjectLinkedBase.SubjectID = Convert.ToInt32(id);
                    actionResult = subjectAction.SubjectLinked_LoadBySubjectId(subjectLinkedBase);
                    if (actionResult.IsSuccess)
                    {
                        linkedListModel = CommonMethods.ConvertTo<SubjectLinkedModel>(actionResult.dtResult);
                    }
                    model.subLinkedList = linkedListModel;

                    subjectBase.SubjectID = Convert.ToInt32(id);
                    subjectBase.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    subjectBase.RoleID = Convert.ToInt32(Session["RoleId"]);
                    actionResult = subjectAction.Subject_LoadById(subjectBase);
                    if (actionResult.IsSuccess)
                    {
                        DataRow dr = actionResult.dtResult.Rows[0];
                        model.subLinkedModel.LogoFirstName = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : "";
                        model.subLinkedModel.LogoLastName = dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : "";
                        model.subLinkedModel.LogoMiddleName = dr["MiddleName"] != DBNull.Value ? dr["MiddleName"].ToString() : "";
                        model.subLinkedModel.CreatedBy = dr["CreatedBy"] != DBNull.Value ? Convert.ToInt32(dr["CreatedBy"]) : 0;
                        model.subLinkedModel.EditPermission = dr["editpermission"] != DBNull.Value ? Convert.ToBoolean(dr["editpermission"]) : false;
                        model.subLinkedModel.DeletePermission = dr["deletepermission"] != DBNull.Value ? Convert.ToBoolean(dr["deletepermission"]) : false;
                    }
                    model.subLinkedModel = model.subLinkedModel;

                }
                else
                {
                    return RedirectToAction("AddSubject");
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return View(model);
        }

        [HttpGet]
        public JsonResult GetSubjectLinkById(int? Id = 0)
        {
            string json = "";
            ManageSubjectLinkedModel model = new ManageSubjectLinkedModel();
            List<SubjectLinkedModel> linkedListModel = new List<SubjectLinkedModel>();
            SubjectLinkedModel linkedModel = new SubjectLinkedModel();
            model.subLinkedList = linkedListModel;
            model.subLinkedModel = linkedModel;
            try
            {
                if (Id > 0)
                {

                    subjectLinkedBase.ID = Convert.ToInt32(Id);
                    actionResult = subjectAction.SubjectLinked_LoadById(subjectLinkedBase);
                    if (actionResult.IsSuccess)
                    {
                        linkedListModel = CommonMethods.ConvertTo<SubjectLinkedModel>(actionResult.dtResult);
                        if (linkedListModel.Count > 0)
                            linkedModel = linkedListModel.FirstOrDefault();
                        json = Newtonsoft.Json.JsonConvert.SerializeObject(linkedModel);
                    }
                }

            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSubjectIncidentLinkById(int? Id = 0)
        {
            string json = "";

            List<IncidentLinkedModel> linkedListModel = new List<IncidentLinkedModel>();
            IncidentLinkedModel linkedModel = new IncidentLinkedModel();

            try
            {
                if (Id > 0)
                {
                    IncidentLinkedBase IncidentLinkedBase = new IncidentLinkedBase();
                    IncidentLinkedBase.ID = Convert.ToInt32(Id);
                    actionResult = subjectAction.SubjectLinked_LoadByIncidentId(IncidentLinkedBase);
                    if (actionResult.IsSuccess)
                    {
                        linkedListModel = CommonMethods.ConvertTo<IncidentLinkedModel>(actionResult.dtResult);
                        if (linkedListModel.Count > 0)
                            linkedModel = linkedListModel.FirstOrDefault();
                        json = Newtonsoft.Json.JsonConvert.SerializeObject(linkedModel);
                    }
                }

            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SubjectLinked(HttpPostedFileBase FilePath, ManageSubjectLinkedModel model, FormCollection fc)
        {
            try
            {
                if (!System.IO.Directory.Exists(Server.MapPath("~/Content/Subject/LinkedFiles")))
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath("~/Content/Subject/LinkedFiles"));
                }

                if (FilePath != null && FilePath.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(FilePath.FileName);
                    var path = Path.Combine(HttpContext.Server.MapPath("~/Content/Subject/LinkedFiles/"), fileName);
                    FilePath.SaveAs(path);
                    model.subLinkedModel.FilePath = "/Content/Subject/LinkedFiles/" + fileName;
                }
                else
                {
                    model.subLinkedModel.FilePath = Convert.ToString(fc["hdnFilePath"]);
                }

                subjectLinkedBase.SubjectID = model.subLinkedModel.SubjectID;
                subjectLinkedBase.ID = model.subLinkedModel.ID;
                subjectLinkedBase.IncidentID = model.subLinkedModel.IncidentID;
                subjectLinkedBase.Description = model.subLinkedModel.Description;
                subjectLinkedBase.FilePath = model.subLinkedModel.FilePath;
                actionResult = subjectAction.SubjectLinked_InsertUpdate(subjectLinkedBase);
                if (actionResult.IsSuccess)
                {
                    int result = Convert.ToInt32(actionResult.dtResult.Rows[0][0]);
                    if (result > 0)
                    {
                        if (model.subLinkedModel.ID > 0)
                            TempData["SuccessMessage"] = "Subject Link Updated Successfully.";
                        else
                            TempData["SuccessMessage"] = "Subject Link Added Successfully.";
                    }
                    else
                        TempData["ErrorMessage"] = "Some error Occurred, please try again later.";

                }
                else
                    TempData["ErrorMessage"] = "Some error Occurred, please try again later.";

            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return RedirectToAction("SubjectLinked", new { Type = "Subject", @id = model.subLinkedModel.SubjectID });
        }

        #region Delete Subject Linked
        [HttpPost]
        public JsonResult DeleteSubjectLinked(int? Id = 0)
        {
            string json = string.Empty;
            try
            {
                subjectLinkedBase.ID = Convert.ToInt32(Id);
                actionResult = subjectAction.SubjectLinked_DeleteById(subjectLinkedBase);
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
        #endregion

        #region Delete Subject Linked
        [HttpPost]
        public JsonResult DeleteSubjectIncidentLinked(int? Id = 0)
        {
            string json = string.Empty;
            try
            {
                IncidentLinkedBase IncidentLinkedBase = new IncidentLinkedBase();
                IncidentLinkedBase.ID = Convert.ToInt32(Id);
                actionResult = subjectAction.SubjectIncidentLinked_DeleteById(IncidentLinkedBase);
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
        #region SearchSubject
        public ActionResult SearchSubject(int? id = 0)
        {
            if (id > 0)
            {
                SubjectModel model = new SubjectModel();
                List<SelectListItem> codesList = new List<SelectListItem>();
                List<SelectListItem> incidentTypeList = new List<SelectListItem>();
                List<SelectListItem> incidentDescriptionList = new List<SelectListItem>();
                actionResult = subjectAction.Codes_LoadAll();
                if (actionResult.IsSuccess)
                {
                    codesList = actionResult.dtResult.AsEnumerable().Select(v => new SelectListItem
                    {
                        Text = Convert.ToString(v["Description"]),
                        Value = Convert.ToString(v["Description"])
                    }).ToList();
                    ViewBag.StatusList = codesList;
                }
                CIMS.BaseLayer.ActionResult actinResultResult = new BaseLayer.ActionResult();
                actinResultResult = subjectAction.IncidentNatureOfEvent_LoadAll();
                if (actinResultResult.IsSuccess)
                {
                    incidentTypeList = actinResultResult.dtResult.AsEnumerable().Select(v => new SelectListItem
                    {
                        Text = Convert.ToString(v["NatureOfEvent"]),
                        Value = Convert.ToString(v["NatureOfEvent"])
                    }).ToList();
                    ViewBag.NOIList = incidentTypeList;
                }


                ViewBag.DescriptionList = incidentDescriptionList;
                ViewBag.SubjectID = id;
                return View(model);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        #endregion

        #region GetIncidentDescriptionByNOIId
        public JsonResult GetIncidentDescriptionByNOIId(string Event)
        {
            string json = "";
            List<SelectListItem> descriptionList = new List<SelectListItem>();
            try
            {
                if (!String.IsNullOrEmpty(Event))
                {
                    subjectBase.NatureOfIncident = Event;
                    actionResult = subjectAction.IncidentTypeDescription_LoadByEventName(subjectBase);
                    if (actionResult.IsSuccess)
                    {
                        descriptionList = actionResult.dtResult.AsEnumerable().Select(v => new SelectListItem
                        {
                            Text = Convert.ToString(v["ShortDescriptor"]),
                            Value = Convert.ToString(v["ShortDescriptor"])
                        }).ToList();
                        json = Newtonsoft.Json.JsonConvert.SerializeObject(descriptionList);
                    }
                }

            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region GetSubjectSearchResult
        [HttpGet]
        public JsonResult GetSubjectSearchResult(string FirstName, string LastName, string Sex, string Race, string DateOfBirth, string IncidentDate, string NatureOfIncident, string Description, string OverallStatus, int CurrentSubjectId = 0)
        {
            List<SubjectModel> model = new List<SubjectModel>();
            string json = "";
            subjectBase.FirstName = FirstName;
            subjectBase.LastName = LastName;
            subjectBase.Sex = Sex;
            subjectBase.Race = Race;
            subjectBase.DateOfBirth = DateOfBirth;
            subjectBase.IncidentDate = IncidentDate;
            subjectBase.NatureOfIncident = NatureOfIncident;
            subjectBase.ShortDescription = Description;
            subjectBase.OverallStatus = OverallStatus;
            actionResult = subjectAction.SearchSubject(subjectBase);
            if (actionResult.IsSuccess)
            {
                model = CommonMethods.ConvertTo<SubjectModel>(actionResult.dtResult);
                model = model.Where(v => v.SubjectID != CurrentSubjectId).ToList();
                json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region SearchSubject
        [HttpPost]
        public ActionResult SearchSubject(FormCollection fc)
        {
            string CombineSubjectIDs = !String.IsNullOrEmpty(fc["hdnSubjectID"]) ? Convert.ToString(fc["hdnSubjectID"]) : "";
            int subjectId = !String.IsNullOrEmpty(fc["hdnCurrentSubjectID"]) ? Convert.ToInt32(fc["hdnCurrentSubjectID"]) : 0;
            if (CombineSubjectIDs != "")
            {
                string[] splitCombineSub = CombineSubjectIDs.Trim(',').Split(',');
                if (splitCombineSub.Length > 0)
                {
                    for (int i = 0; i < splitCombineSub.Length; i++)
                    {
                        subjectBase.SubjectID = subjectId;
                        subjectBase.CIDPersonID = Convert.ToInt32(splitCombineSub[i]);
                        actionResult = subjectAction.CombineSubject(subjectBase);
                        if (actionResult.IsSuccess)
                        {
                            continue;
                        }
                    }
                }
                TempData["SuccessMessage"] = "Subject Combined Successfully.";
            }
            return RedirectToAction("Index");
        }
        #endregion

        public ActionResult SubjectIncidentsList(int SubId)
        {
            bool permission = (Session["Admin"] == null ? CIMS.Models.CheckPermissions.permissionMenu("Subject Incident Details", Convert.ToInt32(Session["UserId"])) : CIMS.Models.CheckAdminPermissions.permissionMenu("Subject"));
            if (!permission)
            {
                return Redirect("~/Home/NoPermission");
            }
            SubjectIncidentsBase subject = new SubjectIncidentsBase();
            SubjectIncidentsModel model = new SubjectIncidentsModel();
            List<SubjectIncidentsModel> lstSubjectIncident = new List<SubjectIncidentsModel>();
            model.SubjectID = SubId;
            subject.UserID = Convert.ToInt32(Session["UserId"]);
            subject.SubjectID = SubId;
            subject.ReportAccessRole = Convert.ToInt32(Session["RoleId"]);
            subject.AllReport = Convert.ToInt32(Session["ReportProofreadCheck"]);
            actionResult = subjectAction.Incidents_LoadBySubjectId(subject);
            if (actionResult.IsSuccess)
            {
                lstSubjectIncident = (from DataRow row in actionResult.dtResult.Rows
                                      select new SubjectIncidentsModel
                                      {
                                          IncidentID = row["IncidentID"] != DBNull.Value ? Convert.ToInt32(row["IncidentID"]) : 0,
                                          IncidentNumber = row["IncidentNumber"] != DBNull.Value ? row["IncidentNumber"].ToString() : "",
                                          ShortDescriptionName = row["ShortDescriptorName"] != DBNull.Value ? row["ShortDescriptorName"].ToString() : "",
                                          StatusName = row["StatusName"] != DBNull.Value ? row["StatusName"].ToString() : "",
                                          ReportCreatorUser = row["ReportCreatorUser"] != DBNull.Value ? row["ReportCreatorUser"].ToString() : "",
                                          DefaultImage = row["DefaultImage"] != DBNull.Value ? row["DefaultImage"].ToString() : "",
                                          LinkWithReport = row["LinkWithReport"] != DBNull.Value ? Convert.ToBoolean(row["LinkWithReport"]) : false,
                                          LinkEmployeeName = row["LinkEmployeeName"] != DBNull.Value ? row["LinkEmployeeName"].ToString() : "",
                                          LinkByEmpID = row["LinkByEmpID"] != DBNull.Value ? Convert.ToInt32(row["LinkByEmpID"]) : 0,
                                          LinkFile = row["LinkFile"] != DBNull.Value ? row["LinkFile"].ToString() : "",
                                          NatureOfEvent = row["noi"] != DBNull.Value ? row["noi"].ToString() : "",
                                          Description = row["textdesc"] != DBNull.Value ? row["textdesc"].ToString() : "",
                                          ReportCreateDate = row["CreatedDate"] != DBNull.Value ? row["CreatedDate"].ToString() : "",
                                      }).ToList();
            }
            model.SubjectIncidentList = lstSubjectIncident;

            subjectBase.SubjectID = Convert.ToInt32(SubId);
            subjectBase.CreatedBy = Convert.ToInt32(Session["UserID"]);
            subjectBase.RoleID = Convert.ToInt32(Session["RoleId"]);
            actionResult = subjectAction.Subject_LoadById(subjectBase);

            if (actionResult.IsSuccess)
            {
                DataRow dr = actionResult.dtResult.Rows[0];
                model.LogoFirstName = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : "";
                model.LogoLastName = dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : "";
                model.LogoMiddleName = dr["MiddleName"] != DBNull.Value ? dr["MiddleName"].ToString() : "";
                model.CreatedBy = dr["CreatedBy"] != DBNull.Value ? Convert.ToInt32(dr["CreatedBy"]) : 0;
                model.EditPermission = dr["editpermission"] != DBNull.Value ? Convert.ToBoolean(dr["editpermission"]) : false;
                model.DeletePermission = dr["deletepermission"] != DBNull.Value ? Convert.ToBoolean(dr["deletepermission"]) : false;
            }
            return View(model);
        }

        public PartialViewResult ALLSubjectIncidentsList(int EventId)
        {
            //bool permission = (Session["Admin"] == null ? CIMS.Models.CheckPermissions.permissionMenu("Subject Incident Details", Convert.ToInt32(Session["UserId"])) : CIMS.Models.CheckAdminPermissions.permissionMenu("Subject"));
            //if (!permission)
            //{
            //    return Redirect("~/Home/NoPermission");
            //}

            SubjectIncidentsBase subject = new SubjectIncidentsBase();
            SubjectIncidentsModel model = new SubjectIncidentsModel();
            List<SubjectIncidentsModel> lstSubjectIncident = new List<SubjectIncidentsModel>();
            //model.SubjectID = SubId;
            subject.UserID = Convert.ToInt32(Session["UserId"]);
            //subject.SubjectID = SubId;
            subject.EventId = EventId;
            subject.ReportAccessRole = Convert.ToInt32(Session["RoleId"]);
            subject.AllReport = Convert.ToInt32(Session["ReportProofreadCheck"]);
            actionResult = subjectAction.Incidents_LoadAll(subject);

            if (actionResult.IsSuccess)
            {
                lstSubjectIncident = (from DataRow row in actionResult.dtResult.Rows
                                      select new SubjectIncidentsModel
                                      {
                                          SubjectID = row["SubjectID"] != DBNull.Value ? Convert.ToInt32(row["SubjectID"]) : 0,
                                          IncidentID = row["IncidentID"] != DBNull.Value ? Convert.ToInt32(row["IncidentID"]) : 0,
                                          IncidentNumber = row["IncidentNumber"] != DBNull.Value ? row["IncidentNumber"].ToString() : "",
                                          ShortDescriptionName = row["ShortDescriptorName"] != DBNull.Value ? row["ShortDescriptorName"].ToString() : "",
                                          StatusName = row["StatusName"] != DBNull.Value ? row["StatusName"].ToString() : "",
                                          ReportCreatorUser = row["ReportCreatorUser"] != DBNull.Value ? row["ReportCreatorUser"].ToString() : "",
                                          DefaultImage = row["DefaultImage"] != DBNull.Value ? row["DefaultImage"].ToString() : "",
                                          //LinkWithReport = row["LinkWithReport"] != DBNull.Value ? Convert.ToBoolean(row["LinkWithReport"]) : false,
                                          //LinkEmployeeName = row["LinkEmployeeName"] != DBNull.Value ? row["LinkEmployeeName"].ToString() : "",
                                          //LinkByEmpID = row["LinkByEmpID"] != DBNull.Value ? Convert.ToInt32(row["LinkByEmpID"]) : 0,
                                          //LinkFile = row["LinkFile"] != DBNull.Value ? row["LinkFile"].ToString() : "",
                                          NatureOfEvent = row["noi"] != DBNull.Value ? row["noi"].ToString() : "",
                                          Description = row["textdesc"] != DBNull.Value ? row["textdesc"].ToString() : "",
                                          ReportCreateDate = row["CreatedDate"] != DBNull.Value ? row["CreatedDate"].ToString() : "",
                                          FirstName = row["FirstName"] != DBNull.Value ? row["FirstName"].ToString() : "",
                                          LastName = row["LastName"] != DBNull.Value ? row["LastName"].ToString() : "",
                                          isLinkedEvent = row["isLinkedEvent"].ToString() == "False" ? false : true,
                                      }).ToList();
            }
            model.SubjectIncidentList = lstSubjectIncident;

            //subjectBase.SubjectID = Convert.ToInt32(SubId);
            //subjectBase.CreatedBy = Convert.ToInt32(Session["UserID"]);
            //subjectBase.RoleID = Convert.ToInt32(Session["RoleId"]);
            //actionResult = subjectAction.Subject_LoadById(subjectBase);

            //if (actionResult.IsSuccess)
            //{
            //    DataRow dr = actionResult.dtResult.Rows[0];
            //    model.LogoFirstName = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : "";
            //    model.LogoLastName = dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : "";
            //    model.LogoMiddleName = dr["MiddleName"] != DBNull.Value ? dr["MiddleName"].ToString() : "";
            //    model.CreatedBy = dr["CreatedBy"] != DBNull.Value ? Convert.ToInt32(dr["CreatedBy"]) : 0;
            //    model.EditPermission = dr["editpermission"] != DBNull.Value ? Convert.ToBoolean(dr["editpermission"]) : false;
            //    model.DeletePermission = dr["deletepermission"] != DBNull.Value ? Convert.ToBoolean(dr["deletepermission"]) : false;
            //}
            return PartialView(model);
        }

        #region DeleteIncidents
        public JsonResult DeleteIncidents(int ID, int SubID, int RepID)
        {
            string jsonString = string.Empty;
            string jsonProofread = "false";
            string jsonDelete = "DeleteFalse";
            try
            {
                SubjectIncidentsBase subject = new SubjectIncidentsBase();
                subject.IncidentID = ID;

                subject.SubjectID = SubID;
                subject.IncidentID = RepID;
                if (Session["ReportProofreadCheck"].ToString() == "1")
                {
                    actionResult = subjectAction.Incidents_Delete(subject);

                    if (actionResult.IsSuccess)
                    {
                        jsonString = "success";
                    }
                    else
                    {
                        jsonString = "fail";
                    }
                }
                else
                {
                    actionResult = subjectAction.SubReportProofread_Check(subject);
                    if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                    {
                        jsonProofread = actionResult.dtResult.Rows[0]["ReportProofread"] != DBNull.Value ? actionResult.dtResult.Rows[0]["ReportProofread"].ToString() : "false";
                    }
                    if (jsonProofread.ToLower() == "false")
                    {
                        actionResult = subjectAction.SubjectIncident_Edit(subject);
                        if (actionResult.IsSuccess)
                        {
                            jsonDelete = actionResult.dtResult.Rows[0]["ReportDelete"] != DBNull.Value ? actionResult.dtResult.Rows[0]["ReportDelete"].ToString() : "true";
                        }
                        if (jsonDelete.ToLower() == "true")
                        {
                            actionResult = subjectAction.Incidents_Delete(subject);

                            if (actionResult.IsSuccess)
                            {
                                jsonString = "success";
                            }
                            else
                            {
                                jsonString = "fail";
                            }
                        }
                        else
                        {
                            jsonString = "DeleteFalse";
                        }
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

        public ActionResult SujectIncident(int SubId, int? Id)
        {
            CIMS.ActionLayer.Setting.SettingAction settingAction = new CIMS.ActionLayer.Setting.SettingAction();

            List<BanType> BanTypesubList = new List<BanType>();
            List<BanType> BanTypeList = new List<BanType>();
            SubjectIncidentsModel model = new SubjectIncidentsModel();
            SubjectIncidentsBase subject = new SubjectIncidentsBase();
            ReportModel ReportModel = new Models.ReportModel();
            model.ReportModel = ReportModel;
            DisputeModel DisputeModel = new Models.DisputeModel();
            model.DisputeModel = DisputeModel;
            BannedModel BannedModel = new Models.BannedModel();
            model.BannedModel = BannedModel;
            subject.IncidentID = Convert.ToInt32(Id);
            LCTForeignExchangeModel LCTForeignExchangeModel = new LCTForeignExchangeModel();
            List<LCTForeignExchangeModel> lstForeignRatesModel = new List<LCTForeignExchangeModel>();
            List<LCTForeignExchangeModel> lstLCTForeignExchangeModel = new List<LCTForeignExchangeModel>();
            List<LCTPitTransactionsModel> lstLCTPitTransactionsBase = new List<LCTPitTransactionsModel>();
            List<LCTCashOutsModel> lstLCTCashOutsModel = new List<LCTCashOutsModel>();
            List<LCTCashCallModel> lstLCTCashCallModel = new List<LCTCashCallModel>();
            List<VehiclesModel> lstVehiclesModel = new List<VehiclesModel>();
            List<IncidentLinkedModel> lstIncidentLinkedModel = new List<IncidentLinkedModel>();
            List<SubjectIncidentProofRead> SubjectIncidentProofReadList = new List<SubjectIncidentProofRead>();

            model.SubjectID = SubId;
            model.IncidentID = Convert.ToInt32(Id);
            LCTForeignExchangeBase exchange = new LCTForeignExchangeBase();
            exchange.SubjectID = SubId;
            exchange.IncidentID = Convert.ToInt32(Id);
            LCTPitTransactionsBase buyIn = new LCTPitTransactionsBase();
            buyIn.SubjectID = SubId;
            buyIn.IncidentID = Convert.ToInt32(Id);
            LCTCashOutsBase cashouts = new LCTCashOutsBase();
            cashouts.SubjectID = SubId;
            cashouts.IncidentID = Convert.ToInt32(Id);
            LCTCashCallBase cashCall = new LCTCashCallBase();
            cashCall.SubjectID = SubId;
            cashCall.IncidentID = Convert.ToInt32(Id);
            VehiclesBase VehiclesBase = new VehiclesBase();
            VehiclesBase.SubjectID = SubId;
            VehiclesBase.IncidentID = Convert.ToInt32(Id);
            IncidentLinkedBase IncidentLinkedBase = new IncidentLinkedBase();
            IncidentLinkedBase.SubjectID = SubId;
            IncidentLinkedBase.IncidentID = Convert.ToInt32(Id);
            ReportBase ReportBase = new ReportBase();
            ReportBase.IncidentID = Convert.ToInt32(Id);
            BannedBase BannedBase = new BannedBase();
            BannedBase.IncidentID = Convert.ToInt32(Id);
            DisputeBase DisputeBase = new DisputeBase();
            DisputeBase.IncidentID = Convert.ToInt32(Id);
            ServiceModel service = new ServiceModel();
            ServiceBase servicebase = new ServiceBase();
            List<ServiceModel> servicemodellist = new List<ServiceModel>();
            List<ServiceModel> SubjectServicesmodellist = new List<ServiceModel>();
            servicebase.SubjectID = SubId;
            servicebase.IncidentID = Convert.ToInt32(Id);
            model.ServiceModel = service;
            BanTypeBase BanTypeBase = new BanTypeBase();
            BanTypeBase.SubjectID = SubId;
            BanTypeBase.IncidentID = Convert.ToInt32(Id);
            actionResult = subjectAction.SubjectServicesOffered_LoadbyIncidentSubjectID(servicebase);
            if (actionResult.IsSuccess)
            {
                SubjectServicesmodellist = (from DataRow row in actionResult.dtResult.Rows
                                            select new ServiceModel
                                            {

                                                ServiceName = row["ServiceName"] != DBNull.Value ? row["ServiceName"].ToString() : "",
                                                Offered = row["Offered"] != DBNull.Value ? row["Offered"].ToString() : "",
                                                DeclinedAvailable = row["Declined"] != DBNull.Value ? row["Declined"].ToString() : ""
                                            }).ToList();
            }
            actionResult = subjectAction.SubjectServices_LoadbyIncidentSubjectID(servicebase);
            if (actionResult.IsSuccess)
            {

                DataRow dr = actionResult.dtResult.Rows[0];
                model.ServiceModel.CallTime = dr["CallTime"] != DBNull.Value ? Convert.ToDateTime(dr["CallTime"].ToString()).ToString("hh:mm tt") : "";
                model.ServiceModel.Description = dr["Description"] != DBNull.Value ? dr["Description"].ToString() : "";
                model.ServiceModel.ServiceBy = dr["ServiceBy"] != DBNull.Value ? dr["ServiceBy"].ToString() : "";
                model.ServiceModel.ServiceFor = dr["ServiceFor"] != DBNull.Value ? dr["ServiceFor"].ToString() : "";
                model.ServiceModel.ArriveTime = dr["ArriveTime"] != DBNull.Value ? Convert.ToDateTime(dr["ArriveTime"].ToString()).ToString("hh:mm tt") : "";

            }
            actionResult = subjectAction.Services_LoadAll();
            if (actionResult.IsSuccess)
            {
                servicemodellist = CommonMethods.ConvertTo<ServiceModel>(actionResult.dtResult);
            }
            //actionResult = subjectAction.ForeignRates_LoadAll();
            //if (actionResult.IsSuccess)
            //{
            //    lstForeignRatesModel = (from DataRow row in actionResult.dtResult.Rows
            //                      select new LCTForeignExchangeModel
            //                      {
            //                          Text = row["Column1"] != DBNull.Value ? row["Column1"].ToString() + "|" + row["UserName"].ToString() : "",
            //                          Value = row["Column1"] != DBNull.Value ? row["Column1"].ToString() + "|" + row["UserName"].ToString() : ""
            //                      }).ToList();

            //}
            actionResult = subjectAction.SubjectLinked_LoadBySubjectId_IncidentID(IncidentLinkedBase);
            if (actionResult.IsSuccess)
            {
                lstIncidentLinkedModel = CommonMethods.ConvertTo<IncidentLinkedModel>(actionResult.dtResult);
            }


            actionResult = subjectAction.Vehicles_LoadById(VehiclesBase);
            if (actionResult.IsSuccess)
            {
                lstVehiclesModel = (from DataRow row in actionResult.dtResult.Rows
                                    select new VehiclesModel
                                    {
                                        VehicleID = row["VehicleID"] != DBNull.Value ? Convert.ToInt32(row["VehicleID"]) : 0,

                                        IssuedIn = row["IssuedIn"] != DBNull.Value ? row["IssuedIn"].ToString() : "",
                                        VehicleColor = row["VehicleColor"] != DBNull.Value ? row["VehicleColor"].ToString() : "",
                                        LicensePlate = row["LicensePlate"] != DBNull.Value ? row["LicensePlate"].ToString() : "",
                                        VehicleMake = row["VehicleMake"] != DBNull.Value ? row["VehicleMake"].ToString() : "",
                                        VehicleVIN = row["VehicleVIN"] != DBNull.Value ? row["VehicleVIN"].ToString() : "",
                                        VehicleModel = row["VehicleModel"] != DBNull.Value ? row["VehicleModel"].ToString() : "",
                                        VehicleYear = row["VehicleYear"] != DBNull.Value ? row["VehicleYear"].ToString() : "",
                                        ImagePath = row["ImagePath"] != DBNull.Value ? Convert.ToString(row["ImagePath"]) : null,

                                    }).ToList();

            }

            actionResult = subjectAction.LCTCashCall_LoadById(cashCall);
            if (actionResult.IsSuccess)
            {
                lstLCTCashCallModel = (from DataRow row in actionResult.dtResult.Rows
                                       select new LCTCashCallModel
                                       {
                                           ID = row["ID"] != DBNull.Value ? Convert.ToInt32(row["ID"]) : 0,
                                           IncidentID = row["IncidentID"] != DBNull.Value ? Convert.ToInt32(row["IncidentID"]) : 0,
                                           SubjectID = row["SubjectID"] != DBNull.Value ? Convert.ToInt32(row["SubjectID"]) : 0,
                                           CashCallTime = row["CashCallTime"] != DBNull.Value ? row["CashCallTime"].ToString() : "",
                                           Cashier = row["Cashier"] != DBNull.Value ? row["Cashier"].ToString() : "",
                                           CashierName = row["CashierName"] != DBNull.Value ? row["CashierName"].ToString() : "",
                                           Amount = row["Amount"] != DBNull.Value ? Convert.ToDecimal(row["Amount"]) : 0
                                       }).ToList();
            }
            actionResult = subjectAction.LCTCashOuts_LoadById(cashouts);
            if (actionResult.IsSuccess)
            {
                lstLCTCashOutsModel = (from DataRow row in actionResult.dtResult.Rows
                                       select new LCTCashOutsModel
                                       {
                                           ID = row["ID"] != DBNull.Value ? Convert.ToInt32(row["ID"]) : 0,
                                           IncidentID = row["IncidentID"] != DBNull.Value ? Convert.ToInt32(row["IncidentID"]) : 0,
                                           SubjectID = row["SubjectID"] != DBNull.Value ? Convert.ToInt32(row["SubjectID"]) : 0,
                                           CashOutTime = row["CashOutTime"] != DBNull.Value ? row["CashOutTime"].ToString() : "",
                                           ChequeNo = row["ChequeNo"] != DBNull.Value ? row["ChequeNo"].ToString() : "",
                                           PaymentType = row["PaymentType"] != DBNull.Value ? row["PaymentType"].ToString() : "",
                                           TableNumber = row["TableNumber"] != DBNull.Value ? row["TableNumber"].ToString() : "",
                                           TypeOfWin = row["TypeOfWin"] != DBNull.Value ? row["TypeOfWin"].ToString() : "",
                                           // = row["ForeignAmount"] != DBNull.Value ? Convert.ToDecimal(row["ForeignAmount"]) : 0,
                                           //PaymentType = row["ForeignCountry"] != DBNull.Value ? row["ForeignCountry"].ToString() : "",

                                           Amount = row["Amount"] != DBNull.Value ? Convert.ToDecimal(row["Amount"]) : 0

                                       }).ToList();

            }
            actionResult = subjectAction.LCTForeignExchange_LoadById(exchange);
            if (actionResult.IsSuccess)
            {
                lstLCTForeignExchangeModel = (from DataRow row in actionResult.dtResult.Rows
                                              select new LCTForeignExchangeModel
                                              {
                                                  ID = row["ID"] != DBNull.Value ? Convert.ToInt32(row["ID"]) : 0,
                                                  IncidentID = row["IncidentID"] != DBNull.Value ? Convert.ToInt32(row["IncidentID"]) : 0,
                                                  SubjectID = row["SubjectID"] != DBNull.Value ? Convert.ToInt32(row["SubjectID"]) : 0,
                                                  Rate = row["Rate"] != DBNull.Value ? Convert.ToDecimal(row["Rate"]) : 0,
                                                  ForeignAmount = row["ForeignAmount"] != DBNull.Value ? Convert.ToDecimal(row["ForeignAmount"]) : 0,
                                                  ForeignCountry = row["ForeignCountry"] != DBNull.Value ? row["ForeignCountry"].ToString() : "",
                                                  ForeignCountryName = row["ForeignCountryName"] != DBNull.Value ? row["ForeignCountryName"].ToString() : "",
                                                  Amount = row["Amount"] != DBNull.Value ? Convert.ToDecimal(row["Amount"]) : 0

                                              }).ToList();

            }
            actionResult = subjectAction.LCTPitTransactions_LoadById(buyIn);
            if (actionResult.IsSuccess)
            {
                lstLCTPitTransactionsBase = (from DataRow row in actionResult.dtResult.Rows
                                             select new LCTPitTransactionsModel
                                             {
                                                 ID = row["ID"] != DBNull.Value ? Convert.ToInt32(row["ID"]) : 0,
                                                 IncidentID = row["IncidentID"] != DBNull.Value ? Convert.ToInt32(row["IncidentID"]) : 0,
                                                 SubjectID = row["SubjectID"] != DBNull.Value ? Convert.ToInt32(row["SubjectID"]) : 0,
                                                 BuyInGameID = row["BuyInGameID"] != DBNull.Value ? Convert.ToInt32(row["BuyInGameID"]) : 0,
                                                 BuyInTypePitID = row["BuyInTypePitID"] != DBNull.Value ? Convert.ToInt32(row["BuyInTypePitID"]) : 0,
                                                 BuyInPitType = row["BuyInPitType"] != DBNull.Value ? row["BuyInPitType"].ToString() : "",
                                                 BuyInType = row["BuyInType"] != DBNull.Value ? row["BuyInType"].ToString() : "",
                                                 Pit = row["Pit"] != DBNull.Value ? row["Pit"].ToString() : "",
                                                 Game = row["Game"] != DBNull.Value ? row["Game"].ToString() : "",
                                                 GameName = row["GameName"] != DBNull.Value ? row["GameName"].ToString() : "",
                                                 BuyInTime = row["BuyInTime"] != DBNull.Value ? row["BuyInTime"].ToString() : "",
                                                 Amount = row["Amount"] != DBNull.Value ? Convert.ToDecimal(row["Amount"]) : 0

                                             }).ToList();

            }

            List<SelectListItem> lstForeignExchangeRates = new List<SelectListItem>();
            actionResult = settingAction.ForeignExchangeRates_Load();
            if (actionResult.IsSuccess)
            {
                lstForeignExchangeRates = (from DataRow row in actionResult.dtResult.Rows
                                           select new SelectListItem
                                           {
                                               Text = row["Country"] != DBNull.Value ? row["Country"].ToString() : "",
                                               Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                           }).ToList();
            }
            ViewBag.lstForeignExchangeRates = lstForeignExchangeRates;

            subject.ReportAccessRole = Convert.ToInt32(Session["RoleId"]);
            subject.UserID = Convert.ToInt32(Session["UserID"]);

            if (Id > 0)
            {
                actionResult = subjectAction.Incidents_LoadByIncidentID(subject);
                if (actionResult.IsSuccess)
                {

                    DataRow dr = actionResult.dtResult.Rows[0];
                    model.IncidentID = dr["IncidentID"] != DBNull.Value ? Convert.ToInt32(dr["IncidentID"]) : 0;
                    model.IncidentNumber = dr["IncidentNumber"] != DBNull.Value ? dr["IncidentNumber"].ToString() : "";
                    model.NatureOfEvent = dr["NatureOfEvent"] != DBNull.Value ? dr["NatureOfEvent"].ToString() : "";
                    model.ShortDescription = dr["ShortDescriptor"] != DBNull.Value ? dr["ShortDescriptor"].ToString() : "";
                    model.ActiveStatus = dr["ActiveStatus"] != DBNull.Value ? Convert.ToBoolean(dr["ActiveStatus"]) : false;
                    model.Status = dr["Status"] != DBNull.Value ? dr["Status"].ToString() : "";
                    if (dr["IncidentDate"] != DBNull.Value)
                    {
                        model.IncidentDate = Convert.ToDateTime(dr["IncidentDate"]).ToShortDateString();
                    }
                    else
                    {
                        model.IncidentDate = DateTime.Now.Date.ToShortDateString();
                    }
                    if (dr["EndDate"] != DBNull.Value)
                    {
                        model.EndDate = Convert.ToDateTime(dr["EndDate"]).ToShortDateString();
                    }
                    else
                    {
                        model.EndDate = DateTime.Now.Date.ToShortDateString();
                    }
                    model.Description = dr["Description"] != DBNull.Value ? dr["Description"].ToString() : "";
                    model.Location = dr["Location"] != DBNull.Value ? dr["Location"].ToString() : "";
                    model.IncidentRole = dr["IncidentRole"] != DBNull.Value ? dr["IncidentRole"].ToString() : "";
                    model.IncidentTime = dr["IncidentTime"] != DBNull.Value ? dr["IncidentTime"].ToString() : DateTime.Now.ToString("hh:mm tt");
                    model.EndTime = dr["EndTime"] != DBNull.Value ? dr["EndTime"].ToString() : DateTime.Now.ToString("hh:mm tt");
                    model.UD26 = dr["UD26"] != DBNull.Value ? dr["UD26"].ToString() : "";
                    model.UD32 = dr["UD32"] != DBNull.Value ? dr["UD32"].ToString() : "";
                    model.UD33 = dr["UD33"] != DBNull.Value ? dr["UD33"].ToString() : "";
                    model.CheckPermissionID = dr["CreatedBy"] != DBNull.Value ? Convert.ToInt32(dr["CreatedBy"]) : 0;
                    model.ReportCreatorUser = dr["ReportCreatorUser"] != DBNull.Value ? dr["ReportCreatorUser"].ToString() : "";
                    model.ReportCreatorFirstName = dr["ReportCreatorFirstName"] != DBNull.Value ? dr["ReportCreatorFirstName"].ToString() : "";
                    model.ReportCreatorLastName = dr["ReportCreatorLastName"] != DBNull.Value ? dr["ReportCreatorLastName"].ToString() : "";
                    model.ReportCreateDate = dr["CreatedDate"] != DBNull.Value ? dr["CreatedDate"].ToString() : "";
                    model.ReportCreatorView = dr["ReportView"] != DBNull.Value ? Convert.ToBoolean(dr["ReportView"]) : true;
                    model.ReportCreatorEdit = dr["ReportEdit"] != DBNull.Value ? Convert.ToBoolean(dr["ReportEdit"]) : true;
                    model.ReportCreatorDelete = dr["ReportDelete"] != DBNull.Value ? Convert.ToBoolean(dr["ReportDelete"]) : true;

                    model.ViewPermission = dr["viewpermission"] != DBNull.Value ? Convert.ToBoolean(dr["viewpermission"]) : true;
                    model.EditPermission = dr["editpermission"] != DBNull.Value ? Convert.ToBoolean(dr["editpermission"]) : true;
                    model.DeletePermission = dr["deletepermission"] != DBNull.Value ? Convert.ToBoolean(dr["deletepermission"]) : true;
                }

                subjectBase.SubjectID = Convert.ToInt32(SubId);
                subjectBase.CreatedBy = Convert.ToInt32(Session["UserID"]);
                subjectBase.RoleID = Convert.ToInt32(Session["RoleId"]);

                actionResult = subjectAction.Subject_LoadById(subjectBase);
                if (actionResult.IsSuccess)
                {
                    DataRow dr = actionResult.dtResult.Rows[0];
                    model.LogoFirstName = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : "";
                    model.LogoLastName = dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : "";
                    model.LogoMiddleName = dr["MiddleName"] != DBNull.Value ? dr["MiddleName"].ToString() : "";
                    //model.EditPermission = dr["editpermission"] != DBNull.Value ? Convert.ToBoolean(dr["editpermission"]) : false;
                    //model.DeletePermission = dr["deletepermission"] != DBNull.Value ? Convert.ToBoolean(dr["deletepermission"]) : false;
                }
            }
            else
            {
                Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                model.IncidentNumber = unixTimestamp.ToString();
                //actionResult = subjectAction.SubjectIncidentsMax_Load();
                //if (actionResult.IsSuccess)
                //{
                //    model.IncidentNumber = actionResult.dtResult.Rows[0][0] != DBNull.Value ? actionResult.dtResult.Rows[0][0].ToString() : " ";

                //}
                model.IncidentDate = DateTime.Now.Date.ToShortDateString();
                model.EndDate = DateTime.Now.Date.ToShortDateString();
                model.IncidentTime = DateTime.Now.ToString("hh:mm tt");
                model.EndTime = DateTime.Now.ToString("hh:mm tt");
            }
            if (model.IncidentID > 0)
            {
                subject.SubjectID = model.SubjectID;
                subject.IncidentID = model.IncidentID;
                actionResult = subjectAction.SubReportProofread_Bind(subject);
                if (actionResult.IsSuccess)
                {
                    DataRow dr = actionResult.dtResult.Rows[0];
                    model.ProofreadID = dr["ID"] != DBNull.Value ? Convert.ToInt32(dr["ID"]) : 0;
                    model.ProofreadByFirstName = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : "";
                    model.ProofreadByLastName = dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : "";
                    model.ProofreadByUserName = dr["UserName"] != DBNull.Value ? dr["UserName"].ToString() : "";
                    model.DateProofread = dr["CreatedDate"] != DBNull.Value ? dr["CreatedDate"].ToString() : "";
                    model.ReportProofread = dr["ReportProofread"] != DBNull.Value ? Convert.ToBoolean(dr["ReportProofread"]) : false;
                }


                actionResult = subjectAction.SubjectIncidentProofRead_LoadBySubjectID(subject);

                if (actionResult.IsSuccess)
                {
                    SubjectIncidentProofReadList = (from DataRow row in actionResult.dtResult.Rows
                                                    select new SubjectIncidentProofRead
                                                    {
                                                        UserName = row["UserName"] != DBNull.Value ? row["UserName"].ToString() : "",
                                                        FirstName = row["FirstName"] != DBNull.Value ? row["FirstName"].ToString() : "",
                                                        LastName = row["LastName"] != DBNull.Value ? row["LastName"].ToString() : "",
                                                        ReportProofread = row["ReportProofread"] != DBNull.Value ? row["ReportProofread"].ToString() : "",
                                                        CreatedDate = Convert.ToDateTime(row["CreatedDate"])
                                                    }).ToList();
                }

            }

            actionResult = subjectAction.Reports_LoadByIncidentID(ReportBase);
            if (actionResult.IsSuccess)
            {

                DataRow dr = actionResult.dtResult.Rows[0];
                model.IncidentID = dr["IncidentID"] != DBNull.Value ? Convert.ToInt32(dr["IncidentID"]) : 0;
                model.ReportModel.Description = dr["Report"] != DBNull.Value ? dr["Report"].ToString() : "";
                model.ReportModel.ReportDate = dr["ReportDate"] != DBNull.Value ? dr["ReportDate"].ToString() : "";
                model.ReportModel.UserID = dr["UserID"] != DBNull.Value ? dr["UserID"].ToString() : "";
            }
            actionResult = subjectAction.Disputes_LoadByIncidentID(DisputeBase);
            if (actionResult.IsSuccess)
            {

                DataRow dr = actionResult.dtResult.Rows[0];
                model.IncidentID = dr["IncidentID"] != DBNull.Value ? Convert.ToInt32(dr["IncidentID"]) : 0;
                model.DisputeModel.Description = dr["Description"] != DBNull.Value ? dr["Description"].ToString() : "";
                model.DisputeModel.RecoveredMoney = dr["RecoveredMoney"] != DBNull.Value ? Convert.ToBoolean(dr["RecoveredMoney"]) : false;
                model.DisputeModel.Resolution = dr["Resolution"] != DBNull.Value ? dr["Resolution"].ToString() : "";
                model.DisputeModel.Amount = dr["Amount"] != DBNull.Value ? dr["Amount"].ToString() : "";
                model.DisputeModel.DisputeType = dr["DisputeType"] != DBNull.Value ? dr["DisputeType"].ToString() : "";
            }

            // LCT Start
            LCTIdentificationModel LCTIdentificationModel = new LCTIdentificationModel();
            LCTIdentificationBase LCTIdentificationBase = new LCTIdentificationBase();
            LCTIdentificationBase.SubjectID = SubId;
            LCTIdentificationBase.IncidentID = Convert.ToInt32(Id);
            actionResult = subjectAction.LCTIdentification_ByID(LCTIdentificationBase);
            if (actionResult.IsSuccess)
            {
                DataRow dr = actionResult.dtResult.Rows[0];
                //LCTIdentificationModel.SubjectID = Convert.ToInt32(SubId);
                //LCTIdentificationModel.IncidentID = Convert.ToInt32(Id);
                model.IncidentID = Convert.ToInt32(Id);
                LCTIdentificationModel.LCTIDNumber = dr["LCTIDNumber"] != DBNull.Value ? dr["LCTIDNumber"].ToString() : "";
                LCTIdentificationModel.FirstName = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : "";
                LCTIdentificationModel.MiddleName = dr["MiddleName"] != DBNull.Value ? dr["MiddleName"].ToString() : "";
                LCTIdentificationModel.LastName = dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : "";
                LCTIdentificationModel.Apartment = dr["Apartment"] != DBNull.Value ? dr["Apartment"].ToString() : "";
                LCTIdentificationModel.Address = dr["Address"] != DBNull.Value ? dr["Address"].ToString() : "";
                LCTIdentificationModel.City = dr["City"] != DBNull.Value ? dr["City"].ToString() : "";
                LCTIdentificationModel.ProvState = dr["ProvState"] != DBNull.Value ? dr["ProvState"].ToString() : "";
                LCTIdentificationModel.PostalZip = dr["PostalZip"] != DBNull.Value ? dr["PostalZip"].ToString() : "";
                LCTIdentificationModel.TransactionDate = dr["TransactionDate"] != DBNull.Value ? Convert.ToDateTime(dr["TransactionDate"]).ToShortDateString() : "";
                LCTIdentificationModel.Occupation = dr["Occupation"] != DBNull.Value ? dr["Occupation"].ToString() : "";
                LCTIdentificationModel.BusinessName = dr["BusinessName"] != DBNull.Value ? dr["BusinessName"].ToString() : "";
                LCTIdentificationModel.TypeOfID = dr["TypeOfID"] != DBNull.Value ? dr["TypeOfID"].ToString() : "";
                LCTIdentificationModel.IDNumber = dr["IDNumber"] != DBNull.Value ? dr["IDNumber"].ToString() : "";
                LCTIdentificationModel.DateOfBirth = dr["DateOfBirth"] != DBNull.Value ? dr["DateOfBirth"].ToString() : "";
                LCTIdentificationModel.IDType1 = dr["IDType1"] != DBNull.Value ? dr["IDType1"].ToString() : "";
                LCTIdentificationModel.IDNumber1 = dr["IDNumber1"] != DBNull.Value ? dr["IDNumber1"].ToString() : "";
                LCTIdentificationModel.IDDefault1 = dr["IDDefault1"] != DBNull.Value ? dr["IDDefault1"].ToString() : "";
                LCTIdentificationModel.IDType2 = dr["IDType2"] != DBNull.Value ? dr["IDType2"].ToString() : "";
                LCTIdentificationModel.IDNumber2 = dr["IDNumber2"] != DBNull.Value ? dr["IDNumber2"].ToString() : "";
                LCTIdentificationModel.IDDefault2 = dr["IDDefault2"] != DBNull.Value ? dr["IDDefault2"].ToString() : "";
                LCTIdentificationModel.IDType3 = dr["IDType3"] != DBNull.Value ? dr["IDType3"].ToString() : "";
                LCTIdentificationModel.IDNumber3 = dr["IDNumber3"] != DBNull.Value ? dr["IDNumber3"].ToString() : "";
                LCTIdentificationModel.IDDefault3 = dr["IDDefault3"] != DBNull.Value ? dr["IDDefault3"].ToString() : "";
                LCTIdentificationModel.EmployeeName = dr["EmployeeName"] != DBNull.Value ? dr["EmployeeName"].ToString() : "";
                LCTIdentificationModel.EmployeeTitle = dr["EmployeeTitle"] != DBNull.Value ? dr["EmployeeTitle"].ToString() : "";
                LCTIdentificationModel.EmployeeGPEB = dr["EmployeeGPEB"] != DBNull.Value ? dr["EmployeeGPEB"].ToString() : "";
                LCTIdentificationModel.CashierName = dr["CashierName"] != DBNull.Value ? dr["CashierName"].ToString() : "";
                LCTIdentificationModel.CashierTitle = dr["CashierTitle"] != DBNull.Value ? dr["CashierTitle"].ToString() : "";
                LCTIdentificationModel.CashierGPEB = dr["CashierGPEB"] != DBNull.Value ? dr["CashierGPEB"].ToString() : "";
                LCTIdentificationModel.Notes = dr["Notes"] != DBNull.Value ? dr["Notes"].ToString() : "";
            }

            actionResult = subjectAction.LCTTotalsSubject_Load(LCTIdentificationBase);
            if (actionResult.IsSuccess)
            {
                DataRow dr = actionResult.dtResult.Rows[0];
                model.IncidentID = Convert.ToInt32(Id);
                LCTIdentificationModel.TotalPit = dr["TotalPit"] != DBNull.Value ? Convert.ToDecimal(dr["TotalPit"]) : 0;
                LCTIdentificationModel.BuyInMarker = dr["BuyInMarker"] != DBNull.Value ? Convert.ToDecimal(dr["BuyInMarker"]) : 0;
                LCTIdentificationModel.TotalCashOut = dr["TotalCashOut"] != DBNull.Value ? Convert.ToDecimal(dr["TotalCashOut"]) : 0;
                LCTIdentificationModel.CashOutMarker = dr["CashOutMarker"] != DBNull.Value ? Convert.ToDecimal(dr["CashOutMarker"]) : 0;
                LCTIdentificationModel.TotalExchange = dr["TotalExchange"] != DBNull.Value ? Convert.ToDecimal(dr["TotalExchange"]) : 0;
            }
            model.LCTIdentificationModel = LCTIdentificationModel;
            // LCT End

            actionResult = subjectAction.Banned_LoadByIncidentID(BannedBase);
            if (actionResult.IsSuccess)
            {
                model.BannedModelList = CommonMethods.ConvertTo<BannedModel>(actionResult.dtResult);

                //DataRow dr = actionResult.dtResult.Rows[0];

                //model.BannedModel.Description = dr["Description"] != DBNull.Value ? dr["Description"].ToString() : "";
                //model.BannedModel.StartDate = dr["StartDate"] != DBNull.Value ? Convert.ToDateTime(dr["StartDate"]).ToString("MM/dd/yyyy") : "";
                //model.BannedModel.EndDate = dr["EndDate"] != DBNull.Value ? Convert.ToDateTime(dr["EndDate"]).ToString("MM/dd/yyyy") : "";
                //model.BannedModel.Currentdate = dr["EntryDate"] != DBNull.Value ? dr["EntryDate"].ToString() : "";
                //model.BannedModel.AuthorizedBy = dr["AuthorizedBy"] != DBNull.Value ? dr["AuthorizedBy"].ToString() : "";
                //model.BannedModel.Day = dr["BanDays"] != DBNull.Value ? Convert.ToInt32(dr["BanDays"]) : 0;
                //model.BannedModel.month = dr["BanMonths"] != DBNull.Value ? Convert.ToInt32(dr["BanMonths"]) : 0;
                //model.BannedModel.year = dr["BanYears"] != DBNull.Value ? Convert.ToInt32(dr["BanYears"]) : 0;
            }

            BanType BanType = new Models.BanType();
            actionResult = subjectAction.SubjectBanType_LoadByIncidentID(BanTypeBase);
            if (actionResult.IsSuccess)
            {
                BanTypesubList = (from DataRow row in actionResult.dtResult.Rows
                                  select new BanType
                                  {
                                      Text = row["BanName"] != DBNull.Value ? row["BanName"].ToString() : "",
                                      Value = row["BanName"] != DBNull.Value ? row["BanName"].ToString() : ""
                                  }).ToList();

                //DataRow dr = actionResult.dtResult.Rows[0];

                //BannedModel.BanType.Text = dr["BanName"] != DBNull.Value ? dr["BanName"].ToString() : "";

            }

            actionResult = subjectAction.GetAuthorName(Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Id));
            //Convert.ToInt32(Id)

            if (actionResult.IsSuccess)
            {
                AuthorNameList = (from DataRow row in actionResult.dtResult.Rows
                                  select new SelectListItem
                                  {
                                      Text = row["Column1"] != DBNull.Value ? row["Column1"].ToString() + "|" + row["UserName"].ToString() : "",
                                      Value = row["Column1"] != DBNull.Value ? row["Column1"].ToString() + "|" + row["UserName"].ToString() : ""
                                  }).ToList();



            }
            //subject.Part = "Dispute Resolution";
            //actionResult = subjectAction.Codes_LoadByPart(subject);

            actionResult = settingAction.DisputeResolution_Load();
            if (actionResult.IsSuccess)
            {
                ResolutionList = (from DataRow row in actionResult.dtResult.Rows
                                  select new SelectListItem
                                  {
                                      Text = row["Resolution"] != DBNull.Value ? row["Resolution"].ToString() : "",
                                      Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                  }).ToList();
            }

            //subject.Part = "Cashier Names";
            //actionResult = subjectAction.Codes_LoadByPart(subject);
            //if (actionResult.IsSuccess)
            //{
            //    CashierNameList = (from DataRow row in actionResult.dtResult.Rows
            //                       select new SelectListItem
            //                       {
            //                           Text = row["Description"] != DBNull.Value ? row["Description"].ToString() : "",
            //                           Value = row["Description"] != DBNull.Value ? row["Description"].ToString() : ""
            //                       }).ToList();
            //}

            actionResult = settingAction.CashierName_Load();
            if (actionResult.IsSuccess)
            {
                CashierNameList = (from DataRow row in actionResult.dtResult.Rows
                                   select new SelectListItem
                                   {
                                       Text = row["CashierName"] != DBNull.Value ? row["CashierName"].ToString() : "",
                                       Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                   }).ToList();
            }

            actionResult = settingAction.VehicleColor_Load();
            if (actionResult.IsSuccess)
            {
                ColorList = (from DataRow row in actionResult.dtResult.Rows
                             select new SelectListItem
                             {
                                 Text = row["Color"] != DBNull.Value ? row["Color"].ToString() : "",
                                 Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                             }).ToList();
            }


            //subject.Part = "Vehicle Colors";
            //actionResult = subjectAction.Codes_LoadByPart(subject);
            //if (actionResult.IsSuccess)
            //{
            //    ColorList = (from DataRow row in actionResult.dtResult.Rows
            //                 select new SelectListItem
            //                 {
            //                     Text = row["Description"] != DBNull.Value ? row["Description"].ToString() : "",
            //                     Value = row["Description"] != DBNull.Value ? row["Description"].ToString() : ""
            //                 }).ToList();
            //}
            //subject.Part = "Game";
            //actionResult = subjectAction.Codes_LoadByPart(subject);


            //if (actionResult.IsSuccess)
            //{
            //    GameList = (from DataRow row in actionResult.dtResult.Rows
            //                select new SelectListItem
            //                {
            //                    Text = row["Description"] != DBNull.Value ? row["Description"].ToString() : "",
            //                    Value = row["Description"] != DBNull.Value ? row["Description"].ToString() : ""
            //                }).ToList();
            //}

            actionResult = settingAction.MasterBuyInGame_Load();
            if (actionResult.IsSuccess)
            {
                GameList = (from DataRow row in actionResult.dtResult.Rows
                            select new SelectListItem
                            {
                                Text = row["Game"] != DBNull.Value ? row["Game"].ToString() : "",
                                Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                            }).ToList();
            }
            actionResult = settingAction.MasterBuyInPitType_Load();
            if (actionResult.IsSuccess)
            {
                BuyInTypePitList = (from DataRow row in actionResult.dtResult.Rows
                                    select new SelectListItem
                                    {
                                        Text = row["BuyInPitType"] != DBNull.Value ? row["BuyInPitType"].ToString() : "",
                                        Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                    }).ToList();
            }

            actionResult = settingAction.MasterCashoutTableNumber_Load();
            if (actionResult.IsSuccess)
            {
                CashoutTableNumberList = (from DataRow row in actionResult.dtResult.Rows
                                          select new SelectListItem
                                          {
                                              Text = row["TableNumber"] != DBNull.Value ? row["TableNumber"].ToString() : "",
                                              Value = row["TableNumber"] != DBNull.Value ? row["TableNumber"].ToString() : ""
                                          }).ToList();
            }
            ViewBag.lstCashoutTableNumbers = CashoutTableNumberList;
            //subject.Part = "Dispute Type";
            //actionResult = subjectAction.Codes_LoadByPart(subject);
            //if (actionResult.IsSuccess)
            //{
            //    DisputTypeList = (from DataRow row in actionResult.dtResult.Rows
            //                      select new SelectListItem
            //                      {
            //                          Text = row["Description"] != DBNull.Value ? row["Description"].ToString() : "",
            //                          Value = row["Description"] != DBNull.Value ? row["Description"].ToString() : ""
            //                      }).ToList();
            //}

            actionResult = settingAction.MasterDisputeType_Load();
            if (actionResult.IsSuccess)
            {
                DisputTypeList = (from DataRow row in actionResult.dtResult.Rows
                                  select new SelectListItem
                                  {
                                      Text = row["DisputeType"] != DBNull.Value ? row["DisputeType"].ToString() : "",
                                      Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                  }).ToList();
            }

            actionResult = settingAction.BanAuthorizedBy_Load();
            if (actionResult.IsSuccess)
            {
                AuthorizedByList = (from DataRow row in actionResult.dtResult.Rows
                                    select new SelectListItem
                                    {
                                        Text = row["AuthorizedBy"] != DBNull.Value ? row["AuthorizedBy"].ToString() : "",
                                        Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                    }).ToList();
            }

            //subject.Part = "Ban Authorized By";
            //actionResult = subjectAction.Codes_LoadByPart(subject);
            //if (actionResult.IsSuccess)
            //{
            //    AuthorizedByList = (from DataRow row in actionResult.dtResult.Rows
            //                        select new SelectListItem
            //                        {
            //                            Text = row["Description"] != DBNull.Value ? row["Description"].ToString() : "",
            //                            Value = row["Description"] != DBNull.Value ? row["Description"].ToString() : ""
            //                        }).ToList();
            //}

            //subject.Part = "Location";
            //actionResult = subjectAction.Codes_LoadByPart(subject);
            //if (actionResult.IsSuccess)
            //{
            //    LocationList = (from DataRow row in actionResult.dtResult.Rows
            //                    select new SelectListItem
            //                    {
            //                        Text = row["Description"] != DBNull.Value ? row["Description"].ToString() : "",
            //                        Value = row["Description"] != DBNull.Value ? row["Description"].ToString() : ""
            //                    }).ToList();
            //}

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

            subject.Part = "Ban Types";
            actionResult = settingAction.MstBanType_Load(); //subjectAction.Codes_LoadByPart(subject);


            if (actionResult.IsSuccess)
            {
                BannedModel.bantypelist =
                    (from DataRow row in actionResult.dtResult.Rows
                     select new SelectListItem
                     {
                         Text = row["TypeOfBan"] != DBNull.Value ? row["TypeOfBan"].ToString() : "",
                         Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : "",
                     }).ToList();
                //BanTypeList = (from DataRow row in actionResult.dtResult.Rows
                //               select new BanType
                //               {
                //                   Text = row["Description"] != DBNull.Value ? row["Description"].ToString() : "",
                //                   Value = row["Description"] != DBNull.Value ? row["Description"].ToString() : ""
                //               }).ToList();

            }

            subject.UserID = Convert.ToInt32(Session["UserId"]);
            subject.IncidentID = model.IncidentID;
            actionResult = subjectAction.UsersSubjectReportsAccess_LoadAll(subject);
            List<SubjectIncidentsModel> UsersList = new List<SubjectIncidentsModel>();
            if (actionResult.IsSuccess)
            {
                UsersList = (from DataRow row in actionResult.dtResult.Rows
                             select new SubjectIncidentsModel
                             {
                                 SubjectID = row["SubjectID"] != DBNull.Value ? Convert.ToInt32(row["SubjectID"]) : 0,
                                 FirstName = row["FirstName"] != DBNull.Value ? row["FirstName"].ToString() : "",
                                 LastName = row["LastName"] != DBNull.Value ? row["LastName"].ToString() : "",
                                 UserName = row["UserName"] != DBNull.Value ? row["UserName"].ToString() : "",
                                 UserID = row["UserID"] != DBNull.Value ? Convert.ToInt32(row["UserID"]) : 0,
                                 RepPerID = row["RepPerID"] != DBNull.Value ? Convert.ToInt32(row["RepPerID"]) : 0,
                                 IncidentID = row["ReportID"] != DBNull.Value ? Convert.ToInt32(row["ReportID"]) : 0,
                                 ReportAccessBy = row["ReportAccessBy"] != DBNull.Value ? Convert.ToInt32(row["ReportAccessBy"]) : 0,
                                 ReportView = row["ReportView"] != DBNull.Value ? Convert.ToBoolean(row["ReportView"]) : false,
                                 ReportEdit = row["ReportEdit"] != DBNull.Value ? Convert.ToBoolean(row["ReportEdit"]) : false,
                                 ReportDelete = row["ReportDelete"] != DBNull.Value ? Convert.ToBoolean(row["ReportDelete"]) : false
                             }).ToList();
            }
            model.SubjectIncidentList = UsersList;


            List<SubjectInvolvedModel> lstSubjectInvolved = new List<SubjectInvolvedModel>();
            SubjectInvolvedBase involved = new SubjectInvolvedBase();
            involved.SubjectID = SubId;
            involved.IncidentID = Convert.ToInt32(Id);

            actionResult = subjectAction.SubjectInvolved_LoadAll(involved);
            if (actionResult.IsSuccess)
            {
                lstSubjectInvolved = (from DataRow row in actionResult.dtResult.Rows
                                      select new SubjectInvolvedModel
                                      {
                                          SubjectIncidentID = row["ID"] != DBNull.Value ? Convert.ToInt32(row["ID"]) : 0,
                                          InvolvedID = row["InvolvedID"] != DBNull.Value ? Convert.ToInt32(row["InvolvedID"]) : 0,
                                          FirstName = row["FirstName"] != DBNull.Value ? Convert.ToString(row["FirstName"]) : "",
                                          LastName = row["LastName"] != DBNull.Value ? Convert.ToString(row["LastName"]) : "",
                                          Sex = row["Sex"] != DBNull.Value ? row["Sex"].ToString() : "",
                                          Race = row["Race"] != DBNull.Value ? row["Race"].ToString() : "",
                                          RoleID = row["RoleID"] != DBNull.Value ? Convert.ToInt32(row["RoleID"]) : 0,
                                          InvolvedRole = row["RoleName"] != DBNull.Value ? row["RoleName"].ToString() : "",
                                          IsEmployee = row["IsEmployee"] != DBNull.Value ? Convert.ToBoolean(row["IsEmployee"]) : false
                                      }).ToList();

            }
            List<SelectListItem> lstGender = new List<SelectListItem>();
            actionResult = settingAction.MasterSex_Load();
            if (actionResult.IsSuccess)
            {
                lstGender = (from DataRow row in actionResult.dtResult.Rows
                             select new SelectListItem
                             {
                                 Text = row["Sex"] != DBNull.Value ? row["Sex"].ToString() : "",
                                 Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                             }).ToList();
            }
            ViewBag.lstGender = lstGender;

            List<SelectListItem> lstRace = new List<SelectListItem>();
            actionResult = settingAction.MasterRace_Load();
            if (actionResult.IsSuccess)
            {
                lstRace = (from DataRow row in actionResult.dtResult.Rows
                           select new SelectListItem
                           {
                               Text = row["Race"] != DBNull.Value ? row["Race"].ToString() : "",
                               Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                           }).ToList();
            }
            ViewBag.lstRace = lstRace;

            List<SelectListItem> lstOverAllStaus = new List<SelectListItem>();
            actionResult = settingAction.MasterStatus_Load();
            if (actionResult.IsSuccess)
            {
                lstOverAllStaus = (from DataRow row in actionResult.dtResult.Rows
                                   select new SelectListItem
                                   {
                                       Text = row["Status"] != DBNull.Value ? row["Status"].ToString() : "",
                                       Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                   }).ToList();
            }
            ViewBag.lstOverAllStaus = lstOverAllStaus;


            List<SelectListItem> lstNatureOfIncident = new List<SelectListItem>();
            CIMS.BaseLayer.Setting.NatureofIncidentBase natureBase = new CIMS.BaseLayer.Setting.NatureofIncidentBase();
            natureBase.NatureType = 1;
            actionResult = settingAction.MasterNatureofIncident_Load(natureBase);
            if (actionResult.IsSuccess)
            {
                lstNatureOfIncident = (from DataRow row in actionResult.dtResult.Rows
                                       select new SelectListItem
                                       {
                                           Text = row["Nature"] != DBNull.Value ? row["Nature"].ToString() : "",
                                           Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                       }).ToList();
            }
            ViewBag.lstNatureOfIncident = lstNatureOfIncident;

            List<SelectListItem> lstShortDescription = new List<SelectListItem>();
            ViewBag.lstShortDescription = lstShortDescription;

            List<SelectListItem> lstRole = new List<SelectListItem>();
            actionResult = settingAction.MasterRole_Load();
            if (actionResult.IsSuccess)
            {
                lstRole = (from DataRow row in actionResult.dtResult.Rows
                           select new SelectListItem
                           {
                               Text = row["Role"] != DBNull.Value ? row["Role"].ToString() : "",
                               Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                           }).ToList();
            }
            ViewBag.lstRole = lstRole;

            model.CashierNameList = CashierNameList;
            model.ColorList = ColorList;
            model.GameList = GameList;
            model.BuyInTypePitList = BuyInTypePitList;
            model.lstForeignRatesModel = lstForeignRatesModel;
            model.LocationList = LocationList;
            BannedModel.BanTypesubList = BanTypesubList;
            BannedModel.BanTypeList = BanTypeList;
            model.AuthorizedByList = AuthorizedByList;
            model.ResolutionList = ResolutionList;
            model.DisputTypeList = DisputTypeList;
            model.ServiceSubjectModelList = SubjectServicesmodellist;
            model.ServiceModelList = servicemodellist;
            model.AuthorNameList = AuthorNameList;
            model.LCTPitTransactionsModelList = lstLCTPitTransactionsBase;
            model.LCTForeignExchangeModelList = lstLCTForeignExchangeModel;
            model.LCTCashOutsModelList = lstLCTCashOutsModel;
            model.LCTCashCallModelList = lstLCTCashCallModel;
            model.VehiclesModelList = lstVehiclesModel;
            model.IncidentLinkedModelList = lstIncidentLinkedModel;
            model.SubjectInvolvedModelList = lstSubjectInvolved;
            model.SubjectIncidentProofReadList = SubjectIncidentProofReadList;
            return View(model);
        }

        [HttpPost]
        public ActionResult SujectIncident(SubjectIncidentsModel model)
        {
            try
            {
                SubjectIncidentsBase subject = new SubjectIncidentsBase();
                subject.SubjectID = model.SubjectID;
                subject.IncidentID = model.IncidentID;
                //Ab 26/2
                if (model.IncidentID > 0)
                {
                    TempData["SaveSuccess"] = "";
                }
                else
                {
                    TempData["SaveSuccess"] = "Success";
                }
                subject.ActiveStatus = model.ActiveStatus;
                subject.Description = model.Description;
                subject.IncidentDate = Convert.ToDateTime(model.IncidentDate).ToShortDateString();
                subject.EndDate = Convert.ToDateTime(model.EndDate).ToShortDateString();
                subject.IncidentNumber = model.IncidentNumber;
                subject.IncidentRole = model.IncidentRole;
                subject.Location = model.Location;
                subject.NatureOfEvent = model.NatureOfEvent;
                subject.ShortDescriptor = model.ShortDescription;
                subject.IncidentTime = model.IncidentTime;
                subject.EndTime = model.EndTime;
                subject.Status = model.Status;
                subject.UD26 = model.UD26;
                subject.UD32 = model.UD32;
                subject.UD33 = model.UD33;
                subject.CreatedBy = Convert.ToInt32(Session["UserId"]);
                subject.ReportCreatorView = true;
                subject.ReportCreatorEdit = true;
                subject.ReportCreatorDelete = true;
                actionResult = subjectAction.Incidents_InsertUpdate(subject);
                if (actionResult.dtResult.Rows.Count > 0)
                {
                    TempData["SuccessMessage"] = "Incident Detail has been Saved Successfully";
                    model.IncidentID = Convert.ToInt32(actionResult.dtResult.Rows[0][0]);

                    AddALLUsersRolesReportsAccess(model.SubjectID, model.IncidentID);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("SujectIncident", new { Id = model.IncidentID, SubId = model.SubjectID });
        }

        [HttpPost]
        public ActionResult LCTIdentification(SubjectIncidentsModel model)
        {
            try
            {
                LCTIdentificationBase LCTBase = new LCTIdentificationBase();
                LCTBase.SubjectID = model.SubjectID;
                LCTBase.IncidentID = model.IncidentID;
                LCTBase.FirstName = model.LCTIdentificationModel.FirstName;
                LCTBase.MiddleName = model.LCTIdentificationModel.MiddleName;
                LCTBase.LastName = model.LCTIdentificationModel.LastName;
                LCTBase.Apartment = model.LCTIdentificationModel.Apartment;
                LCTBase.Address = model.LCTIdentificationModel.Address;
                LCTBase.City = model.LCTIdentificationModel.City;
                LCTBase.ProvState = model.LCTIdentificationModel.ProvState;
                LCTBase.PostalZip = model.LCTIdentificationModel.PostalZip;
                LCTBase.TransactionDate = model.LCTIdentificationModel.TransactionDate;
                LCTBase.LCTIDNumber = model.LCTIdentificationModel.LCTIDNumber;
                LCTBase.Occupation = model.LCTIdentificationModel.Occupation;
                LCTBase.BusinessName = model.LCTIdentificationModel.BusinessName;
                LCTBase.TypeOfID = model.LCTIdentificationModel.TypeOfID;
                LCTBase.IDNumber = model.LCTIdentificationModel.IDNumber;
                LCTBase.DateOfBirth = model.LCTIdentificationModel.DateOfBirth;
                actionResult = subjectAction.LCTIdentification_AddEdit(LCTBase);
                if (actionResult.dtResult.Rows.Count > 0)
                {
                    TempData["SuccessMessage"] = "LCT Identification has been Saved Successfully";
                }
                else
                {
                    TempData["ErrorMessage"] = "Error in Saving record";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("SujectIncident", new { Id = model.IncidentID, SubId = model.SubjectID });
        }

        [HttpPost]
        public ActionResult LCTAttestation(SubjectIncidentsModel model)
        {
            try
            {
                LCTIdentificationBase LCTBase = new LCTIdentificationBase();
                LCTBase.SubjectID = model.SubjectID;
                LCTBase.IncidentID = model.IncidentID;
                LCTBase.EmployeeName = model.LCTIdentificationModel.EmployeeName;
                LCTBase.EmployeeTitle = model.LCTIdentificationModel.EmployeeTitle;
                LCTBase.EmployeeGPEB = model.LCTIdentificationModel.EmployeeGPEB;
                LCTBase.CashierName = model.LCTIdentificationModel.CashierName;
                LCTBase.CashierTitle = model.LCTIdentificationModel.CashierTitle;
                LCTBase.CashierGPEB = model.LCTIdentificationModel.CashierGPEB;
                LCTBase.Notes = model.LCTIdentificationModel.Notes;
                actionResult = subjectAction.LCTAttestation_AddEdit(LCTBase);
                if (actionResult.dtResult.Rows.Count > 0)
                {
                    TempData["SuccessMessage"] = "Incident Detail has been Saved Successfully";
                }
                else
                {
                    TempData["ErrorMessage"] = "Error in Saving record";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("SujectIncident", new { Id = model.IncidentID, SubId = model.SubjectID });
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult LCTNotes(SubjectIncidentsModel model)
        {
            try
            {
                LCTIdentificationBase LCTBase = new LCTIdentificationBase();
                LCTBase.SubjectID = model.SubjectID;
                LCTBase.IncidentID = model.IncidentID;
                LCTBase.Notes = model.LCTIdentificationModel.Notes;
                actionResult = subjectAction.LCTNotes_AddEdit(LCTBase);
                if (actionResult.dtResult.Rows.Count > 0)
                {
                    TempData["SuccessMessage"] = "Incident Detail has been Saved Successfully";
                }
                else
                {
                    TempData["ErrorMessage"] = "Error in Saving record";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("SujectIncident", new { Id = model.IncidentID, SubId = model.SubjectID });
        }

        [HttpPost]
        public ActionResult LCTSubjectTotals(SubjectIncidentsModel model)
        {
            try
            {
                LCTIdentificationBase LCTBase = new LCTIdentificationBase();
                LCTBase.SubjectID = model.SubjectID;
                LCTBase.IncidentID = model.IncidentID;
                LCTBase.TotalPit = model.LCTIdentificationModel.TotalPit;
                LCTBase.BuyInMarker = model.LCTIdentificationModel.BuyInMarker;
                LCTBase.TotalCashOut = model.LCTIdentificationModel.TotalCashOut;
                LCTBase.CashOutMarker = model.LCTIdentificationModel.CashOutMarker;
                LCTBase.TotalExchange = model.LCTIdentificationModel.TotalExchange;
                actionResult = subjectAction.LCTSubjectTotals_Add(LCTBase);
                if (actionResult.dtResult.Rows.Count > 0)
                {
                    TempData["SuccessMessage"] = "Incident Detail has been Saved Successfully";
                }
                else
                {
                    TempData["ErrorMessage"] = "Error in Saving record";
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return RedirectToAction("SujectIncident", new { Id = model.IncidentID, SubId = model.SubjectID });
        }


        [HttpPost]
        public ActionResult SubjectBuyIn(SubjectIncidentsModel model)
        {
            try
            {
                LCTPitTransactionsBase BuyIn = new LCTPitTransactionsBase();
                BuyIn.ID = model.LCTPitTransactionsModel.ID;
                BuyIn.SubjectID = model.SubjectID;
                BuyIn.IncidentID = model.IncidentID;
                BuyIn.BuyInTime = model.LCTPitTransactionsModel.BuyInTime.ToString();
                BuyIn.BuyInType = model.LCTPitTransactionsModel.BuyInType;
                BuyIn.Amount = model.LCTPitTransactionsModel.Amount;
                BuyIn.Game = model.LCTPitTransactionsModel.Game;
                BuyIn.Pit = model.LCTPitTransactionsModel.Pit;
                BuyIn.BuyInGameID = model.LCTPitTransactionsModel.BuyInGameID;
                BuyIn.BuyInTypePitID = model.LCTPitTransactionsModel.BuyInTypePitID;

                actionResult = subjectAction.BuyIn_InsertUpdate(BuyIn);
                if (actionResult.IsSuccess)
                {
                    TempData["SuccessMessage"] = "Buy In has been Saved Successfully";
                }
                else
                {
                    TempData["ErrorMessage"] = "Error in Saving record";
                }
            }
            catch
            {


            }
            return RedirectToAction("SujectIncident", new { Id = model.IncidentID, SubId = model.SubjectID });
        }

        #region DeleteCasheBuyIn
        [HttpPost]
        public JsonResult DeleteCasheBuyIn(int? Id = 0)
        {
            string json = string.Empty;
            try
            {
                LCTPitTransactionsBase BuyIn = new LCTPitTransactionsBase();
                BuyIn.ID = Convert.ToInt32(Id);
                actionResult = subjectAction.LCTPitTransactions_Delete(BuyIn);
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

        [HttpPost]
        public ActionResult SubjectExchange(SubjectIncidentsModel model)
        {
            try
            {
                LCTForeignExchangeBase Exchanges = new LCTForeignExchangeBase();
                Exchanges.ID = model.LCTForeignExchangeModel.ID;
                Exchanges.SubjectID = model.SubjectID;
                Exchanges.IncidentID = model.IncidentID;
                Exchanges.ForeignCountry = model.LCTForeignExchangeModel.ForeignCountry;
                Exchanges.ForeignAmount = model.LCTForeignExchangeModel.ForeignAmount;
                Exchanges.Amount = model.LCTForeignExchangeModel.Amount;
                Exchanges.Rate = model.LCTForeignExchangeModel.Rate;



                actionResult = subjectAction.LCTForeignExchange_IU(Exchanges);
                if (actionResult.IsSuccess)
                {
                    TempData["SuccessMessage"] = "Exchange has been Saved Successfully";
                }
                else
                {
                    TempData["ErrorMessage"] = "Error in Saving record";
                }
            }
            catch
            {


            }
            return RedirectToAction("SujectIncident", new { Id = model.IncidentID, SubId = model.SubjectID });
        }

        #region DeleteExchange
        [HttpPost]
        public JsonResult DeleteExchange(int? Id = 0)
        {
            string json = string.Empty;
            try
            {
                LCTForeignExchangeBase Exchange = new LCTForeignExchangeBase();
                Exchange.ID = Convert.ToInt32(Id);
                actionResult = subjectAction.LCTForeignExchange_Delete(Exchange);
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


        [HttpPost]
        public ActionResult SubjectCashOuts(SubjectIncidentsModel model)
        {
            try
            {
                LCTCashOutsBase Cashout = new LCTCashOutsBase();
                Cashout.ID = model.LCTCashOutsModel.ID;
                Cashout.SubjectID = model.SubjectID;
                Cashout.IncidentID = model.IncidentID;
                Cashout.Amount = model.LCTCashOutsModel.Amount;
                Cashout.CashOutTime = model.LCTCashOutsModel.CashOutTime;
                Cashout.ChequeNo = model.LCTCashOutsModel.ChequeNo;
                Cashout.PaymentType = model.LCTCashOutsModel.PaymentType;
                Cashout.TableNumber = model.LCTCashOutsModel.TableNumber;
                Cashout.TypeOfWin = model.LCTCashOutsModel.TypeOfWin;




                actionResult = subjectAction.LCTCashOuts_IU(Cashout);
                if (actionResult.IsSuccess)
                {
                    TempData["SuccessMessage"] = "Cash Outs has been Saved Successfully";
                }
                else
                {
                    TempData["ErrorMessage"] = "Error in Saving record";
                }
            }
            catch
            {


            }
            return RedirectToAction("SujectIncident", new { Id = model.IncidentID, SubId = model.SubjectID });
        }

        #region DeleteExchange
        [HttpPost]
        public JsonResult DeleteCashOuts(int? Id = 0)
        {
            string json = string.Empty;
            try
            {
                LCTCashOutsBase CashOuts = new LCTCashOutsBase();
                CashOuts.ID = Convert.ToInt32(Id);
                actionResult = subjectAction.LCTCashOuts_Delete(CashOuts);
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


        #region DeleteInvolved
        [HttpPost]
        public JsonResult DeleteInvolved(int? Id = 0, int? RepId = 0)
        {
            string json = string.Empty;
            try
            {
                SubjectInvolvedBase SubjectInvolvedBase = new SubjectInvolvedBase();
                SubjectInvolvedBase.SubjectIncidentID = Convert.ToInt32(Id);
                SubjectInvolvedBase.IncidentID = Convert.ToInt32(RepId);
                actionResult = subjectAction.SubjectInvolved_Delete(SubjectInvolvedBase);
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
        [HttpPost]
        public ActionResult SubjectCashCall(SubjectIncidentsModel model)
        {
            try
            {
                LCTCashCallBase CashCall = new LCTCashCallBase();
                CashCall.ID = model.LCTCashCallModel.ID;
                CashCall.SubjectID = model.SubjectID;
                CashCall.IncidentID = model.IncidentID;
                CashCall.Amount = model.LCTCashCallModel.Amount;
                CashCall.CashCallTime = model.LCTCashCallModel.CashCallTime;
                CashCall.Cashier = model.LCTCashCallModel.Cashier;





                actionResult = subjectAction.LCTCashCall_IU(CashCall);
                if (actionResult.IsSuccess)
                {
                    TempData["SuccessMessage"] = "Cash Call has been Saved Successfully";
                }
                else
                {
                    TempData["ErrorMessage"] = "Error in Saving record";
                }
            }
            catch
            {


            }
            return RedirectToAction("SujectIncident", new { Id = model.IncidentID, SubId = model.SubjectID });
        }

        #region DeleteExchange
        [HttpPost]
        public JsonResult DeleteCashCall(int? Id = 0)
        {
            string json = string.Empty;
            try
            {
                LCTCashCallBase CashCall = new LCTCashCallBase();
                CashCall.ID = Convert.ToInt32(Id);
                actionResult = subjectAction.LCTCashCall_Delete(CashCall);
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
        public ActionResult SubjectVehicles(SubjectIncidentsModel model)
        {
            try
            {
                VehiclesBase Vehicles = new VehiclesBase();
                Vehicles.VehicleID = model.VehiclesModel.VehicleID;
                Vehicles.SubjectID = model.SubjectID;
                Vehicles.IncidentID = model.IncidentID;
                Vehicles.VehicleColor = model.VehiclesModel.VehicleColor;
                Vehicles.IssuedIn = model.VehiclesModel.IssuedIn;
                Vehicles.LicensePlate = model.VehiclesModel.LicensePlate;
                Vehicles.VehicleYear = model.VehiclesModel.VehicleYear;
                Vehicles.VehicleVIN = model.VehiclesModel.VehicleVIN;
                Vehicles.VehicleModel = model.VehiclesModel.VehicleModel;
                Vehicles.VehicleMake = model.VehiclesModel.VehicleMake;



                actionResult = subjectAction.Vehicles_IU(Vehicles);
                if (actionResult.IsSuccess)
                {
                    TempData["SuccessMessage"] = "Vehicle has been Saved Successfully";
                }
                else
                {
                    TempData["ErrorMessage"] = "Error in Saving record";
                }
            }
            catch
            {


            }
            return RedirectToAction("SujectIncident", new { Id = model.IncidentID, SubId = model.SubjectID });
        }

        #region DeleteVehicle
        [HttpPost]
        public JsonResult DeleteVehicle(int? Id = 0)
        {
            string json = string.Empty;
            try
            {
                VehiclesBase VehiclesBase = new VehiclesBase();
                VehiclesBase.VehicleID = Convert.ToInt32(Id);
                actionResult = subjectAction.Vehicles_Delete(VehiclesBase);
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



        [HttpPost]
        public ActionResult SubjectIncidentLInkedFiles(HttpPostedFileBase FilePath, SubjectIncidentsModel model, FormCollection fc, int Maintab = 19)
        {
            try
            {
                if (!System.IO.Directory.Exists(Server.MapPath("~/Content/Subject/LinkedFiles")))
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath("~/Content/Subject/LinkedFiles"));
                }

                if (FilePath != null && FilePath.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(FilePath.FileName);
                    var path = Path.Combine(HttpContext.Server.MapPath("~/Content/Subject/LinkedFiles/"), fileName);
                    FilePath.SaveAs(path);
                    model.IncidentLinkedModel.FilePath = "/Content/Subject/LinkedFiles/" + fileName;
                }
                else
                {
                    model.IncidentLinkedModel.FilePath = Convert.ToString(fc["hdnFilePath"]);
                }
                IncidentLinkedBase IncidentLinkedBase = new IncidentLinkedBase();
                IncidentLinkedBase.SubjectID = model.SubjectID;
                IncidentLinkedBase.ID = model.IncidentLinkedModel.ID;
                IncidentLinkedBase.IncidentID = model.IncidentID;
                IncidentLinkedBase.Description = model.IncidentLinkedModel.Description;
                IncidentLinkedBase.FilePath = model.IncidentLinkedModel.FilePath;
                actionResult = subjectAction.SubjectLinked_IU(IncidentLinkedBase);
                if (actionResult.IsSuccess)
                {
                    int result = Convert.ToInt32(actionResult.dtResult.Rows[0][0]);
                    if (result > 0)
                    {
                        if (model.IncidentLinkedModel.ID > 0)
                            TempData["SuccessMessage"] = "Subject Link Updated Successfully.";
                        else
                            TempData["SuccessMessage"] = "Subject Link Added Successfully.";
                    }
                    else
                        TempData["ErrorMessage"] = "Some error Occurred, please try again later.";

                }
                else
                    TempData["ErrorMessage"] = "Some error Occurred, please try again later.";

            }
            catch (Exception ex)
            {
                //ErrorReporting.WebApplicationError(ex);
            }
            return RedirectToAction("SujectIncident", new { Id = model.IncidentID, SubId = model.SubjectID });
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SujectReports(SubjectIncidentsModel model)
        {
            try
            {
                ReportBase Report = new ReportBase();

                Report.IncidentID = model.IncidentID;
                Report.ReportDate = model.ReportModel.ReportDate;
                Report.UserID = model.ReportModel.UserID;
                Report.Description = model.ReportModel.Description;
                actionResult = subjectAction.IncidentReports_IU(Report);
                if (actionResult.dtResult.Rows.Count > 0)
                {
                    TempData["SuccessMessage"] = "Report has been Saved Successfully";
                }
                else
                {
                    TempData["ErrorMessage"] = "Some error Occurred, please try again later.";
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return RedirectToAction("SujectIncident", new { Id = model.IncidentID, SubId = model.SubjectID });
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SujectServices(SubjectIncidentsModel model)
        {
            try
            {
                ServiceBase Service = new ServiceBase();
                Service.SubjectID = model.SubjectID;
                Service.IncidentID = model.IncidentID;
                Service.ArriveTime = model.ServiceModel.ArriveTime;
                Service.CallTime = model.ServiceModel.CallTime;
                Service.Description = model.ServiceModel.Description;
                Service.ServiceBy = model.ServiceModel.ServiceBy;
                Service.ServiceFor = model.ServiceModel.ServiceFor;
                actionResult = subjectAction.Subject_IncidentServices_IU(Service);
                if (actionResult.dtResult.Rows.Count > 0)
                {
                    //SaveServiceOffered(Service.IncidentID);
                    TempData["SuccessMessage"] = "Service has been Saved Successfully";
                }
                else
                {
                    TempData["ErrorMessage"] = "Some error Occurred, please try again later.";
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return RedirectToAction("SujectIncident", new { Id = model.IncidentID, SubId = model.SubjectID });
        }

        #region SaveServiceOffered

        public JsonResult SaveServiceOffered(int SubjectID, int IncidentID, bool Offered, bool Declined, string ServiceName)
        {
            string json = string.Empty;
            try
            {

                ServiceBase Service = new ServiceBase();

                Service.IncidentID = IncidentID;
                Service.SubjectID = SubjectID;
                Service.Offered = Offered;
                Service.DeclinedAvailable = Declined;
                Service.ServiceName = ServiceName;
                actionResult = subjectAction.SubjectServicesOffered_I(Service);
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

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SubjectDispute(SubjectIncidentsModel model)
        {
            try
            {
                DisputeBase DisputeBase = new DisputeBase();

                DisputeBase.IncidentID = model.IncidentID;
                DisputeBase.Amount = model.DisputeModel.Amount;
                DisputeBase.Description = model.DisputeModel.Description;
                DisputeBase.RecoveredMoney = model.DisputeModel.RecoveredMoney;
                DisputeBase.DisputeType = model.DisputeModel.DisputeType;
                DisputeBase.Resolution = model.DisputeModel.Resolution;
                actionResult = subjectAction.Disputes_IU(DisputeBase);
                if (actionResult.dtResult.Rows.Count > 0)
                {

                    TempData["SuccessMessage"] = "Dispute has been Saved Successfully";
                }
                else
                {
                    TempData["ErrorMessage"] = "Some error Occurred, please try again later.";
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return RedirectToAction("SujectIncident", new { Id = model.IncidentID, SubId = model.SubjectID });
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SubjectInvolved(SubjectIncidentsModel model)
        {
            try
            {
                SubjectInvolvedBase involved = new SubjectInvolvedBase();
                involved.CreatedBy = Convert.ToInt32(Session["UserID"]);
                involved.SubjectIncidentID = model.SubjectIncidentID;
                involved.InvolvedID = model.SubjectInvolvedModel.InvolvedID;
                involved.SubjectID = model.SubjectID;
                involved.IncidentID = model.IncidentID;

                if (model.SubjectInvolvedModel.FirstName != null && model.SubjectInvolvedModel.FirstName != "")
                {
                    involved.FirstName = model.SubjectInvolvedModel.FirstName;
                }
                else
                {
                    involved.FirstName = "Unknown";
                }
                if (model.SubjectInvolvedModel.LastName != null && model.SubjectInvolvedModel.LastName != "")
                {
                    involved.LastName = model.SubjectInvolvedModel.LastName;
                }
                else
                {
                    involved.LastName = "Involved";
                }

                involved.Sex = model.SubjectInvolvedModel.Sex;
                involved.Race = model.SubjectInvolvedModel.Race;
                involved.RoleName = model.SubjectInvolvedModel.InvolvedRole;
                involved.MediaID = 0;


                actionResult = subjectAction.SubjectInvolved_Insert(involved);
                if (actionResult.IsSuccess)
                {
                    TempData["SuccessMessage"] = "Involved has been Saved Successfully";
                }
                else
                {
                    TempData["ErrorMessage"] = "Error in Saving record";
                }
            }
            catch
            {


            }
            return RedirectToAction("SujectIncident", new { Id = model.IncidentID, SubId = model.SubjectID });
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SubjectBanned(SubjectIncidentsModel model, FormCollection fc)
        {
            try
            {
                //var data = fc["Count"];
                //int TotalCount = Convert.ToInt32(data);

                //DataTable dt = new DataTable();

                //dt.Columns.Add("BanName");

                //for (int i = 0; i <= TotalCount; i++)
                //{
                //    var bantype = fc["BanTypeList[" + i + "].TypeOfBan"];
                //    if (bantype == "on")
                //    {
                //        DataRow row;
                //        row = dt.NewRow();

                //        row["BanName"] = fc["BanTypeList[" + i + "].__Text"];
                //        dt.Rows.Add(row);
                //    }

                //}

                //BanTypeBase BanTypeBase = new BanTypeBase();
                //BanTypeBase.BanTypeTable = dt;

                //BanTypeBase.IncidentID = model.IncidentID;
                //BanTypeBase.SubjectID = model.SubjectID;
                //actionResult = subjectAction.IncidentBanType_I(BanTypeBase);
                //if (actionResult.IsSuccess)
                //{

                //}
                BannedBase BannedBase = new BannedBase();
                BannedBase.BannedID = model.BannedModel.BannedID;
                BannedBase.IncidentID = model.IncidentID;
                BannedBase.StartDate = model.BannedModel.StartDate;
                BannedBase.EndDate = model.BannedModel.EndDate;
                BannedBase.Currentdate = model.BannedModel.EntryDate;
                BannedBase.Day = model.BannedModel.BanDays;
                BannedBase.month = model.BannedModel.BanMonths;
                BannedBase.year = model.BannedModel.BanYears;
                BannedBase.Description = model.BannedModel.Description;
                BannedBase.AuthorizedBy = model.BannedModel.AuthorizedBy;
                BannedBase.BanTypeId = model.BannedModel.BanTypeId;


                actionResult = subjectAction.IncidentBanned_IU(BannedBase);
                if (actionResult.IsSuccess)
                {
                    TempData["SuccessMessage"] = "Banned has been Saved Successfully";
                }
                else
                {
                    TempData["ErrorMessage"] = "Error in Saving record";
                }
            }
            catch
            {


            }
            return RedirectToAction("SujectIncident", new { Id = model.IncidentID, SubId = model.SubjectID });
        }
        public JsonResult SearchSubject_Filter(string FirstName, string LastName, string Sex, string Race)
        {
            SubjectInvolvedModel model = new SubjectInvolvedModel();
            List<SubjectInvolvedModel> subjectList = new List<SubjectInvolvedModel>();
            SubjectInvolvedBase involve = new SubjectInvolvedBase();

            involve.FirstName = FirstName.Trim();
            involve.LastName = LastName.Trim();
            involve.Sex = Sex.Trim();
            involve.Race = Race.Trim();

            actionResult = subjectAction.Subjects_Search(involve);

            if (actionResult.IsSuccess)
            {
                subjectList = (from DataRow row in actionResult.dtResult.Rows
                               select new SubjectInvolvedModel
                               {

                                   SubjectID = row["SubjectID"] != DBNull.Value ? Convert.ToInt32(row["SubjectID"]) : 0,
                                   FirstName = row["FirstName"] != DBNull.Value ? row["FirstName"].ToString() : "",
                                   LastName = row["LastName"] != DBNull.Value ? row["LastName"].ToString() : "",
                                   Status = row["Status"] != DBNull.Value ? row["Status"].ToString() : ""
                               }).ToList();
            }

            model.ShortDescriptionList = subjectList;
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BindShortDescription(int SelectedText)
        {
            SubjectInvolvedModel model = new SubjectInvolvedModel();
            // SubjectIncidentsBase subject = new SubjectIncidentsBase();
            // List<SubjectInvolvedModel> shortDescriptionList = new List<SubjectInvolvedModel>();
            // SubjectInvolvedModel involved = new SubjectInvolvedModel();

            // subject.NatureOfEvent = SelectedText;
            // actionResult = subjectAction.IncidentType_LoadByNatureOfEvent(subject);
            // if (actionResult.IsSuccess)
            // {
            //     if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
            //     {
            //         foreach (DataRow row in actionResult.dtResult.Rows)
            //         {
            //             involved.ShortDescription = Convert.ToString(row["ShortDescriptor"]);
            //             shortDescriptionList.Add(involved);
            //             involved = new SubjectInvolvedModel();
            //             //lstNatureOfIncident.Add(new SelectListItem { Text = Convert.ToString(row["NatureOFEvent"]), Value = Convert.ToString(row["NatureOFEvent"]) });
            //         }
            //     }
            // }

            string jsonString = string.Empty;

            CIMS.ActionLayer.Setting.SettingAction settingAction = new CIMS.ActionLayer.Setting.SettingAction();
            CIMS.BaseLayer.Setting.ShortDescriptorBase shortBase = new CIMS.BaseLayer.Setting.ShortDescriptorBase();

            List<SelectListItem> shortDescriptionList = new List<SelectListItem>();
            shortBase.NatureID = SelectedText;
            actionResult = settingAction.MasterShortDescriptor_Load(shortBase);
            if (actionResult.IsSuccess)
            {
                shortDescriptionList = (from DataRow row in actionResult.dtResult.Rows
                                        select new SelectListItem
                                        {
                                            Text = row["Descriptor"] != DBNull.Value ? row["Descriptor"].ToString() : "",
                                            Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                        }).ToList();
            }

            model.ShortDescriptList = shortDescriptionList;
            return Json(model, JsonRequestBehavior.AllowGet);

        }


        public JsonResult AdAsInvolved(string datacolumn, string SubjectID, string IncidentID)
        {
            string json = string.Empty;
            var InvolvedId = datacolumn.Split(',');

            foreach (var item in InvolvedId)
            {
                if (item != null && item != string.Empty)
                {
                    SubjectInvolvedBase subjectInvolvedBase = new SubjectInvolvedBase();
                    subjectInvolvedBase.IncidentID = Convert.ToInt32(IncidentID);
                    subjectInvolvedBase.SubjectID = Convert.ToInt32(SubjectID);
                    subjectInvolvedBase.InvolvedID = Convert.ToInt32(item);
                    subjectInvolvedBase.IsEmployee = false;
                    subjectInvolvedBase.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    actionResult = subjectAction.SubjectInvolve_I(subjectInvolvedBase);
                }
            }

            if (actionResult.IsSuccess)
            {
                TempData["SuccessMessage"] = "Involved has been Saved Successfully";
            }
            else
            {
                TempData["ErrorMessage"] = "Error in Saving record";
            }
            return Json(json, JsonRequestBehavior.AllowGet);

        }


        public JsonResult AddEmployeeInvolvedbutton(string datacolumn, string SubjectID, string IncidentID)
        {
            string json = string.Empty;
            var InvolvedId = datacolumn.Split(',');

            foreach (var item in InvolvedId)
            {
                if (item != null && item != string.Empty)
                {
                    SubjectInvolvedBase subjectInvolvedBase = new SubjectInvolvedBase();
                    subjectInvolvedBase.IncidentID = Convert.ToInt32(IncidentID);
                    subjectInvolvedBase.SubjectID = Convert.ToInt32(SubjectID);
                    subjectInvolvedBase.InvolvedID = Convert.ToInt32(item);
                    subjectInvolvedBase.IsEmployee = true;
                    subjectInvolvedBase.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    actionResult = subjectAction.SubjectInvolve_I(subjectInvolvedBase);
                }
            }
            if (actionResult.IsSuccess)
            {
                TempData["SuccessMessage"] = "";
            }
            else
            {
                TempData["ErrorMessage"] = "";
            }
            return Json(json, JsonRequestBehavior.AllowGet);

        }


        public JsonResult SearchEmployee_Filter(string FirstName, string LastName, string Sex, string Race)
        {
            SubjectInvolvedModel model = new SubjectInvolvedModel();
            List<SubjectInvolvedModel> subjectList = new List<SubjectInvolvedModel>();
            SubjectInvolvedBase involve = new SubjectInvolvedBase();

            involve.FirstName = FirstName.Trim();
            involve.LastName = LastName.Trim();
            involve.Sex = Sex.Trim();
            involve.Race = Race.Trim();

            actionResult = subjectAction.Employee_Search(involve);

            if (actionResult.IsSuccess)
            {
                subjectList = (from DataRow row in actionResult.dtResult.Rows
                               select new SubjectInvolvedModel
                               {

                                   EmployeeID = row["EmployeeID"] != DBNull.Value ? Convert.ToInt32(row["EmployeeID"]) : 0,
                                   FirstName = row["FirstName"] != DBNull.Value ? row["FirstName"].ToString() : "",
                                   LastName = row["LastName"] != DBNull.Value ? row["LastName"].ToString() : "",
                                   Status = row["Status"] != DBNull.Value ? row["Status"].ToString() : ""
                               }).ToList();
            }

            model.ShortDescriptionList = subjectList;
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        //Ankur New 1
        [HttpPost]
        public ActionResult SearchinSubjectAddress(ManageSubjectAddressModel model)
        {
            List<SubjectAddressModel> subjectList = new List<SubjectAddressModel>();
            try
            {
                // employee.EmpID = 1;
                string country = Convert.ToString(model.subAddressModel.CountryID);
                actionResult = subjectAction.AdvancedSearchSubjectAddress(model.subAddressModel.AddressType, model.subAddressModel.Apartment, model.subAddressModel.Address, country, model.subAddressModel.City, model.subAddressModel.ProvState, model.subAddressModel.PostalZip);

                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    subjectList = (from DataRow dr in actionResult.dtResult.Rows
                                   select new SubjectAddressModel
                                   {
                                       SubjectID = dr["SubjectID"] != DBNull.Value ? Convert.ToInt32(dr["SubjectID"]) : 0,
                                       FirstName = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : "",
                                       LastName = dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : "",
                                       MiddleName = dr["MiddleName"] != DBNull.Value ? dr["MiddleName"].ToString() : "",
                                       VIP = dr["VIP"] != DBNull.Value ? dr["VIP"].ToString() : "",
                                       ModifiedDate = dr["ModifiedDate"] != DBNull.Value ? dr["ModifiedDate"].ToString() : "",

                                   }).ToList();

                    model.subAddressList = subjectList;
                }
                //  TempData["SubjectIdListfromAddress"] = subjectList;
                //  return RedirectToAction("Index");

                //List<SubjectAddressModel> addressListModel = new List<SubjectAddressModel>();
                //SubjectAddressModel addressModel = new SubjectAddressModel();
                //model.subAddressList = addressListModel;
                //model.subAddressModel = addressModel;

                CIMS.ActionLayer.Employee.EmployeeAction employeeAction = new CIMS.ActionLayer.Employee.EmployeeAction();
                EmployeeModel employeeModel = new EmployeeModel();
                List<SelectListItem> AddressTypeList = new List<SelectListItem>();
                actionResult = employeeAction.MasterAddressType_Load();
                if (actionResult.IsSuccess)
                {
                    AddressTypeList = (from DataRow row in actionResult.dtResult.Rows
                                       select new SelectListItem
                                       {
                                           Text = row["AddressType"] != DBNull.Value ? row["AddressType"].ToString() : "",
                                           Value = row["id"] != DBNull.Value ? row["id"].ToString() : ""
                                       }).ToList();
                }
                employeeModel.AddressTypeList = AddressTypeList;
                model.EmployeeModel = employeeModel;
                // TempData["SubjectIdListfromAddress"] = subjectList;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return View(model);


            // return RedirectToAction("Index");

        }

        //Ankur New 1
        //public JsonResult SearchSubjectAddress(string AddressType, string Apartment, string Address, string country, string city, string state, string zipCode)
        //{

        //    string jsonString = string.Empty;
        //    try
        //    {
        //        // employee.EmpID = 1;
        //        actionResult = subjectAction.AdvancedSearchSubjectAddress(AddressType, Apartment, Address, country, city, state, zipCode);

        //        if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
        //        {
        //            jsonString += "<tr >";
        //            jsonString += "<td>Address Type</td>";
        //            jsonString += "<td>Apartment</td>";
        //            jsonString += "<td>Address</td>";
        //            jsonString += "<td>country</td>";
        //            jsonString += "<td>city</td>";
        //            jsonString += "<td>state</td>";
        //            jsonString += "<td>zipCode</td>";

        //            jsonString += "</tr>";

        //            for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
        //            {



        //                jsonString += "<tr >";
        //                jsonString += "<td>" + (actionResult.dtResult.Rows[i]["AddressType"]) + "</td>";
        //                jsonString += "<td >" + actionResult.dtResult.Rows[i]["Apartment"].ToString() + "</td>";
        //                jsonString += "<td>" + actionResult.dtResult.Rows[i]["Address"].ToString() + "</td>";
        //                jsonString += "<td>" + actionResult.dtResult.Rows[i]["Country"].ToString() + "</td>";
        //                jsonString += "<td>" + actionResult.dtResult.Rows[i]["City"].ToString() + "</td>";
        //                jsonString += "<td>" + actionResult.dtResult.Rows[i]["ProvState"].ToString() + "</td>";
        //                jsonString += "<td>" + actionResult.dtResult.Rows[i]["PostalZip"].ToString() + "</td>";

        //                jsonString += "</tr>";
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        jsonString += "<tr >";
        //        jsonString += "<td>Address Type</td>";
        //        jsonString += "<td>Apartment</td>";
        //        jsonString += "<td>Address</td>";
        //        jsonString += "<td>country</td>";
        //        jsonString += "<td>city</td>";
        //        jsonString += "<td>state</td>";
        //        jsonString += "<td>zipCode</td>";

        //        jsonString += "</tr>";
        //        return Json(jsonString, JsonRequestBehavior.AllowGet);


        //    }

        //    return Json(jsonString, JsonRequestBehavior.AllowGet);

        //}

        //Ankur New 1
        public ActionResult SearchinSubjectAlias(ManageSubjectAliasModel model)
        {
            List<SubjectAliasModel> subAliasList = new List<SubjectAliasModel>();
            try
            {
                // employee.EmpID = 1;
                //string country = Convert.ToString(model.subAliasModel.CountryID);
                actionResult = subjectAction.AdvancedSearchSubjectAliases(model.subAliasModel.NameType, model.subAliasModel.FirstName, model.subAliasModel.MiddleName, model.subAliasModel.LastName);

                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    subAliasList = (from DataRow dr in actionResult.dtResult.Rows
                                    select new SubjectAliasModel
                                    {
                                        SubjectID = dr["SubjectID"] != DBNull.Value ? Convert.ToInt32(dr["SubjectID"]) : 0,
                                        FirstName = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : "",
                                        LastName = dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : "",
                                        MiddleName = dr["MiddleName"] != DBNull.Value ? dr["MiddleName"].ToString() : "",
                                        VIP = dr["VIP"] != DBNull.Value ? dr["VIP"].ToString() : "",
                                        ModifiedDate = dr["ModifiedDate"] != DBNull.Value ? dr["ModifiedDate"].ToString() : "",
                                    }).ToList();

                    model.subAliasList = subAliasList;
                    //for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    //{
                    //    SubjectID = row["SubjectID"] != DBNull.Value ? Convert.ToInt32(row["SubjectID"]) : 0,
                    //    jsonString += "<td>" + (actionResult.dtResult.Rows[i]["AddressType"]) + "</td>";
                    //    jsonString += "<td >" + actionResult.dtResult.Rows[i]["Apartment"].ToString() + "</td>";
                    //    jsonString += "<td>" + actionResult.dtResult.Rows[i]["Address"].ToString() + "</td>";
                    //    jsonString += "<td>" + actionResult.dtResult.Rows[i]["Country"].ToString() + "</td>";
                    //    jsonString += "<td>" + actionResult.dtResult.Rows[i]["City"].ToString() + "</td>";
                    //    jsonString += "<td>" + actionResult.dtResult.Rows[i]["ProvState"].ToString() + "</td>";
                    //    jsonString += "<td>" + actionResult.dtResult.Rows[i]["PostalZip"].ToString() + "</td>";

                    //    jsonString += "</tr>";
                    //}
                }

                List<SelectListItem> lstAliasNameType = new List<SelectListItem>();
                CIMS.ActionLayer.Setting.SettingAction settingAction = new CIMS.ActionLayer.Setting.SettingAction();
                actionResult = settingAction.AliasNameType_Load();
                if (actionResult.IsSuccess)
                {
                    lstAliasNameType = (from DataRow row in actionResult.dtResult.Rows
                                        select new SelectListItem
                                        {
                                            Text = row["NameType"] != DBNull.Value ? row["NameType"].ToString() : "",
                                            Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                        }).ToList();
                }
                ViewBag.lstAliasNameType = lstAliasNameType;


                //TempData["SubjectIdListfromAliases"] = subAliasList;
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }

            //TempData["SubjectIdListfromAliases"] = subAliasList;
            //return RedirectToAction("Index");
            return View(model);
        }

        [HttpGet]
        public ActionResult SearchinWatchList()
        {

            return View();
        }

        public ActionResult SearchinWatchList(ManageWatchListModel model, string op1)
        {

            List<SubjectWatchListModel> subjectwatchList = new List<SubjectWatchListModel>();
            try
            {
                // employee.EmpID = 1;
                actionResult = subjectAction.AdvancedSearchSubjectFeatures(null, null, "W", op1);


                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    subjectwatchList = (from DataRow dr in actionResult.dtResult.Rows
                                        select new SubjectWatchListModel
                                        {
                                            SubjectID = dr["SubjectID"] != DBNull.Value ? Convert.ToInt32(dr["SubjectID"]) : 0,
                                            FirstName = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : "",
                                            LastName = dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : "",
                                            MiddleName = dr["MiddleName"] != DBNull.Value ? dr["MiddleName"].ToString() : "",
                                            VIP = dr["VIP"] != DBNull.Value ? dr["VIP"].ToString() : "",
                                            ModifiedDate = dr["ModifiedDate"] != DBNull.Value ? dr["ModifiedDate"].ToString() : "",

                                        }).ToList();

                    model.subsubwatchlist = subjectwatchList;
                }

            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return View(model);

        }

        ////Ankur New 1
        //public JsonResult SearchSubjectAliases(string NameType, string FirstName, string MiddleName, string LastName)
        //{

        //    string jsonString = string.Empty;
        //    try
        //    {
        //        // employee.EmpID = 1;
        //        actionResult = subjectAction.AdvancedSearchSubjectAliases(NameType, FirstName, MiddleName, LastName);

        //        if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
        //        {
        //            jsonString += "<tr >";
        //            jsonString += "<td>NameType</td>";
        //            jsonString += "<td>FirstName</td>";
        //            jsonString += "<td>MiddleName</td>";
        //            jsonString += "<td>LastName</td>";

        //            jsonString += "</tr>";

        //            for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
        //            {



        //                jsonString += "<tr >";
        //                jsonString += "<td>" + (actionResult.dtResult.Rows[i]["NameType"]) + "</td>";
        //                jsonString += "<td >" + actionResult.dtResult.Rows[i]["FirstName"].ToString() + "</td>";
        //                jsonString += "<td>" + actionResult.dtResult.Rows[i]["MiddleName"].ToString() + "</td>";
        //                jsonString += "<td>" + actionResult.dtResult.Rows[i]["LastName"].ToString() + "</td>";

        //                jsonString += "</tr>";
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        jsonString += "<tr >";
        //        jsonString += "<td>NameType</td>";
        //        jsonString += "<td>FirstName</td>";
        //        jsonString += "<td>MiddleName</td>";
        //        jsonString += "<td>LastName</td>";

        //        jsonString += "</tr>";
        //        return Json(jsonString, JsonRequestBehavior.AllowGet);


        //    }

        //    return Json(jsonString, JsonRequestBehavior.AllowGet);

        //}


        public ActionResult uploadPartial()
        {
            var appData = Server.MapPath("~/Content/uploads");
            var images = Directory.GetFiles(appData).Select(x => new imagesviewmodel
            {
                Url = Url.Content("~/Content/uploads/" + Path.GetFileName(x))
            });
            return View(images);
        }
        public void uploadnow(HttpPostedFileWrapper upload)
        {
            if (upload != null)
            {
                string ImageName = upload.FileName;
                string path = System.IO.Path.Combine(Server.MapPath("~/Content/uploads"), ImageName);
                upload.SaveAs(path);
            }

        }

        #region Subject Reports Access Permission
        [HttpPost]
        public JsonResult SubjectReportsAccessPermission(int SubId, int RepId, int UserId, int Id, string View, string Edit, string Delete)
        {
            SubjectIncidentsBase subjectIncidentBase = new SubjectIncidentsBase();

            string json = string.Empty;
            try
            {
                subjectIncidentBase.RepPerID = Id;
                subjectIncidentBase.SubjectID = SubId;
                subjectIncidentBase.IncidentID = RepId;
                subjectIncidentBase.ReportAccessBy = UserId;
                subjectIncidentBase.ReportView = Convert.ToBoolean(View);
                subjectIncidentBase.ReportEdit = Convert.ToBoolean(Edit);
                subjectIncidentBase.ReportDelete = Convert.ToBoolean(Delete);
                subjectIncidentBase.CreatedBy = Convert.ToInt32(Session["UserId"]);
                actionResult = subjectAction.SubReportsAccessPermission_AddEdit(subjectIncidentBase);
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

        #region ReportPermissionCheck Get
        public JsonResult ReportPermissionCheck(int SubID, int RepID)
        {
            SubjectIncidentsModel subjectIncidentsModel = new SubjectIncidentsModel();
            SubjectIncidentsBase subjectIncidentsBase = new SubjectIncidentsBase();
            List<SubjectIncidentsModel> subjectIncidentList = new List<SubjectIncidentsModel>();

            string jsonString = string.Empty;
            string jsonProofread = "false";
            try
            {
                subjectIncidentsBase.SubjectID = SubID;
                subjectIncidentsBase.IncidentID = RepID;
                subjectIncidentsBase.ReportAccessBy = Convert.ToInt32(Session["UserId"]);
                subjectIncidentsBase.ReportAccessRole = Convert.ToInt32(Session["RoleId"]);

                actionResult = subjectAction.SubReportProofread_Check(subjectIncidentsBase);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    jsonProofread = actionResult.dtResult.Rows[0]["ReportProofread"] != DBNull.Value ? actionResult.dtResult.Rows[0]["ReportProofread"].ToString() : "false";
                }
                if (jsonProofread.ToLower() == "false")
                {
                    actionResult = subjectAction.SubjectReportPermissionCheck_User(subjectIncidentsBase);
                    if (actionResult.IsSuccess)
                    {
                        if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                        {
                            jsonString += actionResult.dtResult.Rows[0]["ViewReport"] != DBNull.Value ? actionResult.dtResult.Rows[0]["ViewReport"].ToString() : "false";
                            jsonString += ",";
                            jsonString += actionResult.dtResult.Rows[0]["EditReport"] != DBNull.Value ? actionResult.dtResult.Rows[0]["EditReport"].ToString() : "false";
                            jsonString += ",";
                            jsonString += actionResult.dtResult.Rows[0]["DeleteReport"] != DBNull.Value ? actionResult.dtResult.Rows[0]["DeleteReport"].ToString() : "false";
                        }
                    }
                }
                else
                {
                    jsonString = "ReportProfread";
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

        #region Country ForeignExchangeRate
        [HttpPost]
        public JsonResult ForeignExchangeRates(int ID)
        {
            CIMS.BaseLayer.Setting.ForeignExchangeRatesBase exchangeBase = new CIMS.BaseLayer.Setting.ForeignExchangeRatesBase();

            string json = string.Empty;
            try
            {
                exchangeBase.ID = ID;
                actionResult = subjectAction.ForeignExchangeRates_LoadByID(exchangeBase);
                if (actionResult.IsSuccess)
                {
                    json = actionResult.dtResult.Rows[0]["Rate"] != DBNull.Value ? actionResult.dtResult.Rows[0]["Rate"].ToString() : "0";
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


        #region Advanced Search Subject
        [HttpGet]
        public ActionResult AdvancedSearchSubject()
        {
            SubjectModel model = new SubjectModel();
            try
            {

                CIMS.ActionLayer.Setting.SettingAction settingAction = new CIMS.ActionLayer.Setting.SettingAction();

                List<SelectListItem> lstGender = new List<SelectListItem>();
                actionResult = settingAction.MasterSex_Load();
                if (actionResult.IsSuccess)
                {
                    lstGender = (from DataRow row in actionResult.dtResult.Rows
                                 select new SelectListItem
                                 {
                                     Text = row["Sex"] != DBNull.Value ? row["Sex"].ToString() : "",
                                     Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                 }).ToList();
                }
                ViewBag.lstGender = lstGender;

                List<SelectListItem> lstRace = new List<SelectListItem>();
                actionResult = settingAction.MasterRace_Load();
                if (actionResult.IsSuccess)
                {
                    lstRace = (from DataRow row in actionResult.dtResult.Rows
                               select new SelectListItem
                               {
                                   Text = row["Race"] != DBNull.Value ? row["Race"].ToString() : "",
                                   Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                               }).ToList();
                }
                ViewBag.lstRace = lstRace;

                List<SelectListItem> lstEyes = new List<SelectListItem>();
                actionResult = settingAction.MasterEyes_Load();
                if (actionResult.IsSuccess)
                {
                    lstEyes = (from DataRow row in actionResult.dtResult.Rows
                               select new SelectListItem
                               {
                                   Text = row["Eyes"] != DBNull.Value ? row["Eyes"].ToString() : "",
                                   Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                               }).ToList();
                }
                ViewBag.lstEyes = lstEyes;

                List<SelectListItem> lstBuild = new List<SelectListItem>();
                actionResult = settingAction.Build_Load();
                if (actionResult.IsSuccess)
                {
                    lstBuild = (from DataRow row in actionResult.dtResult.Rows
                                select new SelectListItem
                                {
                                    Text = row["Build"] != DBNull.Value ? row["Build"].ToString() : "",
                                    Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                }).ToList();
                }
                ViewBag.lstBuild = lstBuild;

                List<SelectListItem> lstComplexion = new List<SelectListItem>();
                actionResult = settingAction.Complexion_Load();
                if (actionResult.IsSuccess)
                {
                    lstComplexion = (from DataRow row in actionResult.dtResult.Rows
                                     select new SelectListItem
                                     {
                                         Text = row["Complexion"] != DBNull.Value ? row["Complexion"].ToString() : "",
                                         Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                     }).ToList();
                }
                ViewBag.lstComplexion = lstComplexion;


                List<SelectListItem> lstHairLength = new List<SelectListItem>();
                actionResult = settingAction.HairLength_Load();
                if (actionResult.IsSuccess)
                {
                    lstHairLength = (from DataRow row in actionResult.dtResult.Rows
                                     select new SelectListItem
                                     {
                                         Text = row["HairLength"] != DBNull.Value ? row["HairLength"].ToString() : "",
                                         Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                     }).ToList();
                }
                ViewBag.lstHairLength = lstHairLength;

                List<SelectListItem> lstHairColor = new List<SelectListItem>();
                actionResult = settingAction.HairColor_Load();
                if (actionResult.IsSuccess)
                {
                    lstHairColor = (from DataRow row in actionResult.dtResult.Rows
                                    select new SelectListItem
                                    {
                                        Text = row["HairColor"] != DBNull.Value ? row["HairColor"].ToString() : "",
                                        Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                    }).ToList();
                }
                ViewBag.lstHairColor = lstHairColor;

                List<SelectListItem> lstFacial = new List<SelectListItem>();
                actionResult = settingAction.FacialHair_Load();
                if (actionResult.IsSuccess)
                {
                    lstFacial = (from DataRow row in actionResult.dtResult.Rows
                                 select new SelectListItem
                                 {
                                     Text = row["FacialHair"] != DBNull.Value ? row["FacialHair"].ToString() : "",
                                     Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                 }).ToList();
                }
                ViewBag.lstFacial = lstFacial;
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return View(model);
        }

        //AnkurNew
        [HttpGet]
        public ActionResult SearchInSubject()
        {
            SubjectModel model = new SubjectModel();
            try
            {

                CIMS.ActionLayer.Setting.SettingAction settingAction = new CIMS.ActionLayer.Setting.SettingAction();

                List<SelectListItem> lstGender = new List<SelectListItem>();
                actionResult = settingAction.MasterSex_Load();
                if (actionResult.IsSuccess)
                {
                    lstGender = (from DataRow row in actionResult.dtResult.Rows
                                 select new SelectListItem
                                 {
                                     Text = row["Sex"] != DBNull.Value ? row["Sex"].ToString() : "",
                                     Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                 }).ToList();
                }
                ViewBag.lstGender = lstGender;

                List<SelectListItem> lstRace = new List<SelectListItem>();
                actionResult = settingAction.MasterRace_Load();
                if (actionResult.IsSuccess)
                {
                    lstRace = (from DataRow row in actionResult.dtResult.Rows
                               select new SelectListItem
                               {
                                   Text = row["Race"] != DBNull.Value ? row["Race"].ToString() : "",
                                   Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                               }).ToList();
                }
                ViewBag.lstRace = lstRace;

                List<SelectListItem> lstEyes = new List<SelectListItem>();
                actionResult = settingAction.MasterEyes_Load();
                if (actionResult.IsSuccess)
                {
                    lstEyes = (from DataRow row in actionResult.dtResult.Rows
                               select new SelectListItem
                               {
                                   Text = row["Eyes"] != DBNull.Value ? row["Eyes"].ToString() : "",
                                   Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                               }).ToList();
                }
                ViewBag.lstEyes = lstEyes;

                List<SelectListItem> lstBuild = new List<SelectListItem>();
                actionResult = settingAction.Build_Load();
                if (actionResult.IsSuccess)
                {
                    lstBuild = (from DataRow row in actionResult.dtResult.Rows
                                select new SelectListItem
                                {
                                    Text = row["Build"] != DBNull.Value ? row["Build"].ToString() : "",
                                    Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                }).ToList();
                }
                ViewBag.lstBuild = lstBuild;

                List<SelectListItem> lstComplexion = new List<SelectListItem>();
                actionResult = settingAction.Complexion_Load();
                if (actionResult.IsSuccess)
                {
                    lstComplexion = (from DataRow row in actionResult.dtResult.Rows
                                     select new SelectListItem
                                     {
                                         Text = row["Complexion"] != DBNull.Value ? row["Complexion"].ToString() : "",
                                         Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                     }).ToList();
                }
                ViewBag.lstComplexion = lstComplexion;


                List<SelectListItem> lstHairLength = new List<SelectListItem>();
                actionResult = settingAction.HairLength_Load();
                if (actionResult.IsSuccess)
                {
                    lstHairLength = (from DataRow row in actionResult.dtResult.Rows
                                     select new SelectListItem
                                     {
                                         Text = row["HairLength"] != DBNull.Value ? row["HairLength"].ToString() : "",
                                         Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                     }).ToList();
                }
                ViewBag.lstHairLength = lstHairLength;

                List<SelectListItem> lstHairColor = new List<SelectListItem>();
                actionResult = settingAction.HairColor_Load();
                if (actionResult.IsSuccess)
                {
                    lstHairColor = (from DataRow row in actionResult.dtResult.Rows
                                    select new SelectListItem
                                    {
                                        Text = row["HairColor"] != DBNull.Value ? row["HairColor"].ToString() : "",
                                        Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                    }).ToList();
                }
                ViewBag.lstHairColor = lstHairColor;

                List<SelectListItem> lstFacial = new List<SelectListItem>();
                actionResult = settingAction.FacialHair_Load();
                if (actionResult.IsSuccess)
                {
                    lstFacial = (from DataRow row in actionResult.dtResult.Rows
                                 select new SelectListItem
                                 {
                                     Text = row["FacialHair"] != DBNull.Value ? row["FacialHair"].ToString() : "",
                                     Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                 }).ToList();
                }
                ViewBag.lstFacial = lstFacial;

                List<SelectListItem> lstAliasNameType = new List<SelectListItem>();
                actionResult = settingAction.AliasNameType_Load();
                if (actionResult.IsSuccess)
                {
                    lstAliasNameType = (from DataRow row in actionResult.dtResult.Rows
                                        select new SelectListItem
                                        {
                                            Text = row["NameType"] != DBNull.Value ? row["NameType"].ToString() : "",
                                            Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                        }).ToList();
                }
                ViewBag.lstAliasNameType = lstAliasNameType;

            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return View(model);
        }

        //AB
        [HttpPost]
        public ActionResult SearchInSubjectIndex(SubjectModel model)
        {
            try
            {

                List<SubjectModel> subjectList = new List<SubjectModel>();

                subjectBase.FirstName = Request.Params["FirstName"];//model.FirstName;
                subjectBase.MiddleName = Request.Params["MiddleName"];//model.MiddleName;
                subjectBase.LastName = Request.Params["LastName"];//model.LastName;
                subjectBase.VIP = Request.Params["VIP"];//model.VIP;
                subjectBase.Sex = Request.Params["Sex"];//model.Sex;
                subjectBase.Race = Request.Params["Race"];//model.Race;
                subjectBase.DateOfBirth = Request.Params["DateOfBirth"];//model.DateOfBirth;
                subjectBase.Eyes = Request.Params["Eyes"];//model.Eyes;
                subjectBase.Build = Request.Params["Build"];//model.Build;
                subjectBase.FacialHair = Request.Params["FacialHair"];//model.FacialHair;
                subjectBase.HairColor = Request.Params["HairColor"];//model.HairColor;
                subjectBase.HairLength = Request.Params["HairLength"];//model.HairLength;
                subjectBase.Complexion = Request.Params["Complexion"];//model.Complexion;
                subjectBase.AgeRange = Request.Params["AgeRange"];//model.AgeRange;
                actionResult = subjectAction.Subjects_AdvancedSearch(subjectBase);
                if (actionResult.IsSuccess == true)
                {
                    TempData["SubjectList"] = actionResult;
                    return RedirectToAction("Index");
                }


            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            //Ankur New 1
            // return RedirectToAction("Index", new { ViewBag.SubjectIdList });
            TempData["SubjectList"] = actionResult;
            return RedirectToAction("Index");
        }

        //AnkurNew
        [HttpPost]
        public ActionResult SearchInSubject(SubjectModel model)
        {
            try
            {

                List<SubjectModel> subjectList = new List<SubjectModel>();

                subjectBase.FirstName = model.FirstName;
                subjectBase.MiddleName = model.MiddleName;
                subjectBase.LastName = model.LastName;
                subjectBase.VIP = model.VIP;
                subjectBase.Sex = model.Sex;
                subjectBase.Race = model.Race;
                subjectBase.DateOfBirth = model.DateOfBirth;
                subjectBase.Eyes = model.Eyes;
                subjectBase.Build = model.Build;
                subjectBase.FacialHair = model.FacialHair;
                subjectBase.HairColor = model.HairColor;
                subjectBase.HairLength = model.HairLength;
                subjectBase.Complexion = model.Complexion;
                actionResult = subjectAction.Subjects_AdvancedSearch(subjectBase);
                if (actionResult.IsSuccess)
                {
                    if (actionResult.IsSuccess)
                    {
                        subjectList = (from DataRow row in actionResult.dtResult.Rows
                                       select new SubjectModel
                                       {
                                           SubjectID = row["SubjectID"] != DBNull.Value ? Convert.ToInt32(row["SubjectID"]) : 0,
                                           FilePath = row["FilePath"] != DBNull.Value ? Convert.ToString(row["FilePath"]) : null,
                                           VIP = row["VIP"] != DBNull.Value ? Convert.ToString(row["VIP"]) : null,
                                           FirstName = row["FirstName"] != DBNull.Value ? row["FirstName"].ToString() : "",
                                           LastName = row["LastName"] != DBNull.Value ? row["LastName"].ToString() : "",
                                           ModifiedDate = row["ModifiedDate"] != DBNull.Value ? row["ModifiedDate"].ToString() : "",
                                           //MiddleName = row["MiddleName"] != DBNull.Value ? Convert.ToString(row["MiddleName"]) : null,
                                           //Sex = row["Sex"] != DBNull.Value ? Convert.ToString(row["Sex"]) : null,
                                           //Race = row["Race"] != DBNull.Value ? row["Race"].ToString() : "",
                                           //DateOfBirth = row["DateOfBirth"] != DBNull.Value ? row["DateOfBirth"].ToString() : "",
                                           //Eyes = row["Eyes"] != DBNull.Value ? row["Eyes"].ToString() : "",
                                           //Build = row["Build"] != DBNull.Value ? row["Build"].ToString() : "",
                                           //Complexion = row["Complexion"] != DBNull.Value ? row["Complexion"].ToString() : "",
                                       }).ToList();

                        model.SubjectList = subjectList;
                    }
                }

                CIMS.ActionLayer.Setting.SettingAction settingAction = new CIMS.ActionLayer.Setting.SettingAction();

                List<SelectListItem> lstGender = new List<SelectListItem>();
                actionResult = settingAction.MasterSex_Load();
                if (actionResult.IsSuccess)
                {
                    lstGender = (from DataRow row in actionResult.dtResult.Rows
                                 select new SelectListItem
                                 {
                                     Text = row["Sex"] != DBNull.Value ? row["Sex"].ToString() : "",
                                     Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                 }).ToList();
                }
                ViewBag.lstGender = lstGender;

                List<SelectListItem> lstRace = new List<SelectListItem>();
                actionResult = settingAction.MasterRace_Load();
                if (actionResult.IsSuccess)
                {
                    lstRace = (from DataRow row in actionResult.dtResult.Rows
                               select new SelectListItem
                               {
                                   Text = row["Race"] != DBNull.Value ? row["Race"].ToString() : "",
                                   Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                               }).ToList();
                }
                ViewBag.lstRace = lstRace;

                List<SelectListItem> lstEyes = new List<SelectListItem>();
                actionResult = settingAction.MasterEyes_Load();
                if (actionResult.IsSuccess)
                {
                    lstEyes = (from DataRow row in actionResult.dtResult.Rows
                               select new SelectListItem
                               {
                                   Text = row["Eyes"] != DBNull.Value ? row["Eyes"].ToString() : "",
                                   Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                               }).ToList();
                }
                ViewBag.lstEyes = lstEyes;

                List<SelectListItem> lstBuild = new List<SelectListItem>();
                actionResult = settingAction.Build_Load();
                if (actionResult.IsSuccess)
                {
                    lstBuild = (from DataRow row in actionResult.dtResult.Rows
                                select new SelectListItem
                                {
                                    Text = row["Build"] != DBNull.Value ? row["Build"].ToString() : "",
                                    Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                }).ToList();
                }
                ViewBag.lstBuild = lstBuild;

                List<SelectListItem> lstComplexion = new List<SelectListItem>();
                actionResult = settingAction.Complexion_Load();
                if (actionResult.IsSuccess)
                {
                    lstComplexion = (from DataRow row in actionResult.dtResult.Rows
                                     select new SelectListItem
                                     {
                                         Text = row["Complexion"] != DBNull.Value ? row["Complexion"].ToString() : "",
                                         Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                     }).ToList();
                }
                ViewBag.lstComplexion = lstComplexion;


                List<SelectListItem> lstHairLength = new List<SelectListItem>();
                actionResult = settingAction.HairLength_Load();
                if (actionResult.IsSuccess)
                {
                    lstHairLength = (from DataRow row in actionResult.dtResult.Rows
                                     select new SelectListItem
                                     {
                                         Text = row["HairLength"] != DBNull.Value ? row["HairLength"].ToString() : "",
                                         Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                     }).ToList();
                }
                ViewBag.lstHairLength = lstHairLength;

                List<SelectListItem> lstHairColor = new List<SelectListItem>();
                actionResult = settingAction.HairColor_Load();
                if (actionResult.IsSuccess)
                {
                    lstHairColor = (from DataRow row in actionResult.dtResult.Rows
                                    select new SelectListItem
                                    {
                                        Text = row["HairColor"] != DBNull.Value ? row["HairColor"].ToString() : "",
                                        Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                    }).ToList();
                }
                ViewBag.lstHairColor = lstHairColor;

                List<SelectListItem> lstFacial = new List<SelectListItem>();
                actionResult = settingAction.FacialHair_Load();
                if (actionResult.IsSuccess)
                {
                    lstFacial = (from DataRow row in actionResult.dtResult.Rows
                                 select new SelectListItem
                                 {
                                     Text = row["FacialHair"] != DBNull.Value ? row["FacialHair"].ToString() : "",
                                     Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                 }).ToList();
                }
                ViewBag.lstFacial = lstFacial;

                List<SelectListItem> lstAliasNameType = new List<SelectListItem>();
                actionResult = settingAction.AliasNameType_Load();
                if (actionResult.IsSuccess)
                {
                    lstAliasNameType = (from DataRow row in actionResult.dtResult.Rows
                                        select new SelectListItem
                                        {
                                            Text = row["NameType"] != DBNull.Value ? row["NameType"].ToString() : "",
                                            Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                        }).ToList();
                }
                ViewBag.lstAliasNameType = lstAliasNameType;

                //Ankur New 1
                // TempData["SubjectIdList"] = subjectList;
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            //Ankur New 1
            // return RedirectToAction("Index", new { ViewBag.SubjectIdList });
            return View(model);
        }
        #endregion

        #region Advanced Search Subject
        [HttpPost]
        public ActionResult AdvancedSearchSubject(SubjectModel model)
        {
            try
            {

                List<SubjectModel> subjectList = new List<SubjectModel>();

                subjectBase.FirstName = model.FirstName;
                subjectBase.MiddleName = model.MiddleName;
                subjectBase.LastName = model.LastName;
                subjectBase.VIP = model.VIP;
                subjectBase.Sex = model.Sex;
                subjectBase.Race = model.Race;
                subjectBase.DateOfBirth = model.DateOfBirth;
                subjectBase.Eyes = model.Eyes;
                subjectBase.Build = model.Build;
                subjectBase.FacialHair = model.FacialHair;
                subjectBase.HairColor = model.HairColor;
                subjectBase.HairLength = model.HairLength;
                subjectBase.Complexion = model.Complexion;
                actionResult = subjectAction.Subjects_AdvancedSearch(subjectBase);
                if (actionResult.IsSuccess)
                {
                    if (actionResult.IsSuccess)
                    {
                        subjectList = (from DataRow row in actionResult.dtResult.Rows
                                       select new SubjectModel
                                       {
                                           SubjectID = row["SubjectID"] != DBNull.Value ? Convert.ToInt32(row["SubjectID"]) : 0,
                                           FilePath = row["FilePath"] != DBNull.Value ? Convert.ToString(row["FilePath"]) : null,
                                           VIP = row["VIP"] != DBNull.Value ? Convert.ToString(row["VIP"]) : null,
                                           FirstName = row["FirstName"] != DBNull.Value ? row["FirstName"].ToString() : "",
                                           LastName = row["LastName"] != DBNull.Value ? row["LastName"].ToString() : "",
                                       }).ToList();

                        model.SubjectList = subjectList;
                    }
                }

                CIMS.ActionLayer.Setting.SettingAction settingAction = new CIMS.ActionLayer.Setting.SettingAction();

                List<SelectListItem> lstGender = new List<SelectListItem>();
                actionResult = settingAction.MasterSex_Load();
                if (actionResult.IsSuccess)
                {
                    lstGender = (from DataRow row in actionResult.dtResult.Rows
                                 select new SelectListItem
                                 {
                                     Text = row["Sex"] != DBNull.Value ? row["Sex"].ToString() : "",
                                     Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                 }).ToList();
                }
                ViewBag.lstGender = lstGender;

                List<SelectListItem> lstRace = new List<SelectListItem>();
                actionResult = settingAction.MasterRace_Load();
                if (actionResult.IsSuccess)
                {
                    lstRace = (from DataRow row in actionResult.dtResult.Rows
                               select new SelectListItem
                               {
                                   Text = row["Race"] != DBNull.Value ? row["Race"].ToString() : "",
                                   Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                               }).ToList();
                }
                ViewBag.lstRace = lstRace;

                List<SelectListItem> lstEyes = new List<SelectListItem>();
                actionResult = settingAction.MasterEyes_Load();
                if (actionResult.IsSuccess)
                {
                    lstEyes = (from DataRow row in actionResult.dtResult.Rows
                               select new SelectListItem
                               {
                                   Text = row["Eyes"] != DBNull.Value ? row["Eyes"].ToString() : "",
                                   Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                               }).ToList();
                }
                ViewBag.lstEyes = lstEyes;

                List<SelectListItem> lstBuild = new List<SelectListItem>();
                actionResult = settingAction.Build_Load();
                if (actionResult.IsSuccess)
                {
                    lstBuild = (from DataRow row in actionResult.dtResult.Rows
                                select new SelectListItem
                                {
                                    Text = row["Build"] != DBNull.Value ? row["Build"].ToString() : "",
                                    Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                }).ToList();
                }
                ViewBag.lstBuild = lstBuild;

                List<SelectListItem> lstComplexion = new List<SelectListItem>();
                actionResult = settingAction.Complexion_Load();
                if (actionResult.IsSuccess)
                {
                    lstComplexion = (from DataRow row in actionResult.dtResult.Rows
                                     select new SelectListItem
                                     {
                                         Text = row["Complexion"] != DBNull.Value ? row["Complexion"].ToString() : "",
                                         Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                     }).ToList();
                }
                ViewBag.lstComplexion = lstComplexion;


                List<SelectListItem> lstHairLength = new List<SelectListItem>();
                actionResult = settingAction.HairLength_Load();
                if (actionResult.IsSuccess)
                {
                    lstHairLength = (from DataRow row in actionResult.dtResult.Rows
                                     select new SelectListItem
                                     {
                                         Text = row["HairLength"] != DBNull.Value ? row["HairLength"].ToString() : "",
                                         Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                     }).ToList();
                }
                ViewBag.lstHairLength = lstHairLength;

                List<SelectListItem> lstHairColor = new List<SelectListItem>();
                actionResult = settingAction.HairColor_Load();
                if (actionResult.IsSuccess)
                {
                    lstHairColor = (from DataRow row in actionResult.dtResult.Rows
                                    select new SelectListItem
                                    {
                                        Text = row["HairColor"] != DBNull.Value ? row["HairColor"].ToString() : "",
                                        Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                    }).ToList();
                }
                ViewBag.lstHairColor = lstHairColor;

                List<SelectListItem> lstFacial = new List<SelectListItem>();
                actionResult = settingAction.FacialHair_Load();
                if (actionResult.IsSuccess)
                {
                    lstFacial = (from DataRow row in actionResult.dtResult.Rows
                                 select new SelectListItem
                                 {
                                     Text = row["FacialHair"] != DBNull.Value ? row["FacialHair"].ToString() : "",
                                     Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                 }).ToList();
                }
                ViewBag.lstFacial = lstFacial;

            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return View(model);
        }
        #endregion

        #region SubjectLCT_CheckAddress
        [HttpPost]
        public JsonResult SubjectLCT_CheckAddress(int SubID)
        {
            string json = string.Empty;
            try
            {
                SubjectBase subjectbase = new SubjectBase();
                subjectbase.SubjectID = Convert.ToInt32(SubID);
                actionResult = subjectAction.SubjectLCT_CheckAddress(subjectbase);
                if (actionResult.IsSuccess)
                {
                    if (actionResult.dsResult.Tables[0].Rows.Count > 0)
                    {
                        if (actionResult.dsResult.Tables[1].Rows.Count > 0)
                        {
                            json = "success";
                        }
                        else
                        {
                            json = "fail2";
                        }
                    }
                    else
                    {
                        json = "fail1";
                    }
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


        #region Bind Users List Reports for Access
        public JsonResult UsersListReportsAccess(int ReportID)
        {
            string jsonString = string.Empty;
            try
            {
                SubjectIncidentsBase incidentBase = new SubjectIncidentsBase();
                incidentBase.UserID = Convert.ToInt32(Session["UserID"]);
                incidentBase.IncidentID = ReportID;
                actionResult = subjectAction.UsersSubReportsAccess_Bind(incidentBase);
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

        #region Add Add UsersReports Access
        [HttpPost]
        public JsonResult AddUsersReportsAccess(string UserID, int SubjectID, int ReportID)
        {
            string json = string.Empty;
            try
            {
                json = AddUsersReport(UserID, SubjectID, ReportID);
            }
            catch (Exception ex)
            {
                json = "-1";
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public bool AddALLUsersRolesReportsAccess(int SubjectID, int ReportID)
        {
            try
            {
                SubjectIncidentsBase incidentBase = new SubjectIncidentsBase();
                incidentBase.SubjectID = SubjectID;
                incidentBase.IncidentID = ReportID;
                incidentBase.CreatedBy = Convert.ToInt32(Session["UserID"]);
                actionResult = subjectAction.AddAll_UsersAndRoles_SubReportsAccess(incidentBase);
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
                return false;
            }
            return actionResult.IsSuccess;
        }

        public string AddUsersReport(string UserID, int SubjectID, int ReportID)
        {
            string json = string.Empty;

            if (UserID.Length > 0)
            {
                string[] UserIDList = UserID.Split(',');
                for (int i = 0; i <= UserIDList.Length - 1; i++)
                {
                    SubjectIncidentsBase incidentBase = new SubjectIncidentsBase();

                    incidentBase.ReportAccessBy = Convert.ToInt32(UserIDList[i]);
                    incidentBase.SubjectID = SubjectID;
                    incidentBase.IncidentID = ReportID;
                    incidentBase.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    actionResult = subjectAction.AddUsersSubReportsAccess(incidentBase);
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

        #region Remove UsersReports Access 
        [HttpPost]
        public JsonResult RemoveUsersReportsAccess(string ID)
        {
            string json = string.Empty;
            try
            {
                if (ID.Length > 0)
                {
                    string[] IDList = ID.Split(',');
                    for (int i = 0; i <= IDList.Length - 1; i++)
                    {
                        SubjectIncidentsBase incidentBase = new SubjectIncidentsBase();
                        incidentBase.ReportAccessID = Convert.ToInt32(IDList[i]);
                        actionResult = subjectAction.RemoveUsersSubReportsAccess(incidentBase);
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

        #region Bind ReportsAccess Users
        public JsonResult ReportsAccessUsers_Bind(int ReportID)
        {
            string jsonString = string.Empty;
            try
            {
                SubjectIncidentsBase incidentBase = new SubjectIncidentsBase();
                incidentBase.UserID = Convert.ToInt32(Session["UserID"]);
                incidentBase.IncidentID = ReportID;
                actionResult = subjectAction.SubReportsAccessUsers_Bind(incidentBase);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += " <option value = " + actionResult.dtResult.Rows[i]["ID"] + "  onclick = \"ReportsAccessPermission('" + actionResult.dtResult.Rows[i]["ID"] + "',this); \"> " + actionResult.dtResult.Rows[i]["FullName"] + " - " + actionResult.dtResult.Rows[i]["UserName"] + " </ option >";
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

        #region Save Report Access Permission
        [HttpPost]
        public JsonResult SubReportAccessPermission(int ID, int ReportID, string Type, string Permission)
        {
            string json = string.Empty;
            try
            {
                if (ID > 0)
                {
                    SubjectIncidentsBase incidentBase = new SubjectIncidentsBase();
                    incidentBase.ReportAccessID = Convert.ToInt32(ID);
                    incidentBase.IncidentID = ReportID;
                    incidentBase.ReportAccessType = Type;
                    incidentBase.ReportAccessPermission = Convert.ToBoolean(Permission);
                    actionResult = subjectAction.SubReportAccessPermission(incidentBase);
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

        #region Bind ReportsAccess Permission ByUsers
        public JsonResult ReportsAccessPermission_ByUser(int ID, int ReportID)
        {
            string jsonString = string.Empty;
            try
            {
                SubjectIncidentsBase incidentBase = new SubjectIncidentsBase();
                incidentBase.ReportAccessID = ID;
                incidentBase.IncidentID = ReportID;
                actionResult = subjectAction.SubReportsAccessPermission_ByUser(incidentBase);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    jsonString += actionResult.dtResult.Rows[0]["ViewReport"] != DBNull.Value ? actionResult.dtResult.Rows[0]["ViewReport"].ToString() : "false";
                    jsonString += ",";
                    jsonString += actionResult.dtResult.Rows[0]["EditReport"] != DBNull.Value ? actionResult.dtResult.Rows[0]["EditReport"].ToString() : "false";
                    jsonString += ",";
                    jsonString += actionResult.dtResult.Rows[0]["DeleteReport"] != DBNull.Value ? actionResult.dtResult.Rows[0]["DeleteReport"].ToString() : "false";
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

        #region Bind Users ReportsAccess Role
        public JsonResult UsersReportsAccessRole(int ReportID)
        {
            string jsonString = string.Empty;
            try
            {
                SubjectIncidentsBase incidentBase = new SubjectIncidentsBase();
                incidentBase.IncidentID = ReportID;
                actionResult = subjectAction.UsersSubReportsAccessRole(incidentBase);
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

        #region Add Roles ReportsAccess
        [HttpPost]
        public JsonResult AddRolesReportsAccess(string RoleID, string SubjectID, string ReportID)
        {
            string json = string.Empty;
            try
            {
                if (RoleID.Length > 0)
                {
                    string[] RoleIDList = RoleID.Split(',');
                    for (int i = 0; i <= RoleIDList.Length - 1; i++)
                    {
                        SubjectIncidentsBase incidentBase = new SubjectIncidentsBase();

                        incidentBase.ReportAccessRole = Convert.ToInt32(RoleIDList[i]);
                        incidentBase.SubjectID = Convert.ToInt32(SubjectID);
                        incidentBase.IncidentID = Convert.ToInt32(ReportID);
                        incidentBase.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        actionResult = subjectAction.AddRolesSubReportsAccess(incidentBase);
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

        #region Remove Roles ReportsAccess 
        [HttpPost]
        public JsonResult RemoveRolesReportsAccess(string ID)
        {
            string json = string.Empty;
            try
            {
                if (ID.Length > 0)
                {
                    string[] RoleIDList = ID.Split(',');
                    for (int i = 0; i <= RoleIDList.Length - 1; i++)
                    {
                        SubjectIncidentsBase incidentBase = new SubjectIncidentsBase();
                        incidentBase.ReportAccessID = Convert.ToInt32(RoleIDList[i]);
                        actionResult = subjectAction.RemoveRolesSubReportsAccess(incidentBase);
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

        #region Bind ReportsAccess Roles
        public JsonResult ReportsAccessRoles_Bind(int ReportID)
        {
            string jsonString = string.Empty;
            try
            {
                SubjectIncidentsBase incidentBase = new SubjectIncidentsBase();
                incidentBase.UserID = Convert.ToInt32(Session["UserID"]);
                incidentBase.IncidentID = ReportID;
                actionResult = subjectAction.SubReportsAccessRoles_Bind(incidentBase);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += " <option value = " + actionResult.dtResult.Rows[i]["ID"] + "  onclick = \"ReportsAccessPermissionByRole('" + actionResult.dtResult.Rows[i]["ID"] + "',this); \"> " + actionResult.dtResult.Rows[i]["RoleName"] + " </ option >";
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

        #region Save Report Access Permission By Role
        [HttpPost]
        public JsonResult SubReportAccessPermissionByRole(int ID, int ReportID, string Type, string Permission)
        {
            string json = string.Empty;
            try
            {
                if (ID > 0)
                {
                    SubjectIncidentsBase incidentBase = new SubjectIncidentsBase();
                    incidentBase.ReportAccessID = Convert.ToInt32(ID);
                    incidentBase.IncidentID = ReportID;
                    incidentBase.ReportAccessType = Type;
                    incidentBase.ReportAccessPermission = Convert.ToBoolean(Permission);
                    actionResult = subjectAction.SubReportAccessPermissionByRole(incidentBase);
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

        #region Bind ReportsAccess Permission By Roles
        public JsonResult ReportsAccessPermission_ByRole(int ID, int ReportID)
        {
            string jsonString = string.Empty;
            try
            {
                SubjectIncidentsBase incidentBase = new SubjectIncidentsBase();
                incidentBase.ReportAccessID = ID;
                incidentBase.IncidentID = ReportID;
                actionResult = subjectAction.SubReportsAccessPermission_ByRole(incidentBase);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    jsonString += actionResult.dtResult.Rows[0]["ViewReport"] != DBNull.Value ? actionResult.dtResult.Rows[0]["ViewReport"].ToString() : "false";
                    jsonString += ",";
                    jsonString += actionResult.dtResult.Rows[0]["EditReport"] != DBNull.Value ? actionResult.dtResult.Rows[0]["EditReport"].ToString() : "false";
                    jsonString += ",";
                    jsonString += actionResult.dtResult.Rows[0]["DeleteReport"] != DBNull.Value ? actionResult.dtResult.Rows[0]["DeleteReport"].ToString() : "false";
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

        #region SubjectReportProofread
        [HttpPost]
        public ActionResult SubjectReportProofread(SubjectIncidentsModel model)
        {
            SubjectIncidentsBase reportBase = new SubjectIncidentsBase();
            reportBase.ProofreadID = model.ProofreadID;
            reportBase.SubjectID = model.SubjectID;
            reportBase.IncidentID = model.IncidentID;
            reportBase.ReportProofread = model.ReportProofread;
            reportBase.UserID = Convert.ToInt32(Session["UserID"]);
            actionResult = subjectAction.SubReportProofread_add(reportBase);
            if (actionResult.IsSuccess)
            {
                TempData["SuccessMessage"] = "Report Proofread has been Saved Successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Some error Occurred, please try again later.";
            }
            return RedirectToAction("SujectIncident", new { Id = model.IncidentID, SubId = model.SubjectID });
        }
        #endregion

        #region Save Report Access Permission By Admin
        [HttpPost]
        public JsonResult SubReportCreatorPermission(int ReportID, string Type, string Permission)
        {
            string json = string.Empty;
            try
            {
                if (ReportID > 0)
                {
                    SubjectIncidentsBase reportBase = new SubjectIncidentsBase();
                    reportBase.IncidentID = ReportID;
                    reportBase.ReportAccessType = Type;
                    reportBase.ReportAccessPermission = Convert.ToBoolean(Permission);
                    actionResult = subjectAction.SubReportCreatorPermission(reportBase);
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

        #region EditIncidents
        public JsonResult EditIncidents(int ID, int SubID, int RepID)
        {
            string jsonString = string.Empty;
            string jsonProofread = "false";
            try
            {
                SubjectIncidentsBase reportBase = new SubjectIncidentsBase();
                reportBase.IncidentID = ID;
                reportBase.SubjectID = SubID;
                reportBase.IncidentID = RepID;
                actionResult = subjectAction.SubReportProofread_Check(reportBase);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    jsonProofread = actionResult.dtResult.Rows[0]["ReportProofread"] != DBNull.Value ? actionResult.dtResult.Rows[0]["ReportProofread"].ToString() : "false";
                }
                if (jsonProofread.ToLower() == "false")
                {
                    actionResult = subjectAction.SubjectIncident_Edit(reportBase);

                    if (actionResult.IsSuccess)
                    {
                        jsonString = actionResult.dtResult.Rows[0]["ReportEdit"] != DBNull.Value ? actionResult.dtResult.Rows[0]["ReportEdit"].ToString() : "true";
                    }
                    else
                    {
                        jsonString = "fail";
                    }
                }
                else
                {
                    jsonString = "ReportProfread";
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

        #region Subject Report Banned
        [HttpGet]
        public JsonResult GetBannedById(int Id)
        {
            BannedModelVM BannedModel = new Models.BannedModelVM();
            string json = "";

            try
            {
                if (Id > 0)
                {
                    actionResult = subjectAction.Banned_LoadByID(Id);

                    if (actionResult.IsSuccess)
                    {
                        BannedModel = CommonMethods.ConvertTo<BannedModelVM>(actionResult.dtResult)[0];
                        json = Newtonsoft.Json.JsonConvert.SerializeObject(BannedModel);
                        //DataRow dr = actionResult.dtResult.Rows[0];

                        //model.BannedModel.Description = dr["Description"] != DBNull.Value ? dr["Description"].ToString() : "";
                        //model.BannedModel.StartDate = dr["StartDate"] != DBNull.Value ? Convert.ToDateTime(dr["StartDate"]).ToString("MM/dd/yyyy") : "";
                        //model.BannedModel.EndDate = dr["EndDate"] != DBNull.Value ? Convert.ToDateTime(dr["EndDate"]).ToString("MM/dd/yyyy") : "";
                        //model.BannedModel.Currentdate = dr["EntryDate"] != DBNull.Value ? dr["EntryDate"].ToString() : "";
                        //model.BannedModel.AuthorizedBy = dr["AuthorizedBy"] != DBNull.Value ? dr["AuthorizedBy"].ToString() : "";
                        //model.BannedModel.Day = dr["BanDays"] != DBNull.Value ? Convert.ToInt32(dr["BanDays"]) : 0;
                        //model.BannedModel.month = dr["BanMonths"] != DBNull.Value ? Convert.ToInt32(dr["BanMonths"]) : 0;
                        //model.BannedModel.year = dr["BanYears"] != DBNull.Value ? Convert.ToInt32(dr["BanYears"]) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteBannedById(int? Id = 0)
        {
            string json = string.Empty;
            try
            {
                actionResult = subjectAction.Banneds_DeleteById(Convert.ToInt32(Id));
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


        #region Bind Users List Subject for Access
        public JsonResult UsersListSubjectAccess(int SubjectID)
        {
            string jsonString = string.Empty;
            try
            {
                SubjectIncidentsBase incidentBase = new SubjectIncidentsBase();
                incidentBase.UserID = Convert.ToInt32(Session["UserID"]);
                incidentBase.SubjectID = SubjectID;
                actionResult = subjectAction.UsersSubjectAccess_Bind(incidentBase);
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

        #region Add Add UsersSubject Access
        [HttpPost]
        public JsonResult AddUsersSubjectAccess(string UserID, int SubjectID)
        {
            string json = string.Empty;
            try
            {
                json = AddUsersSubject(UserID, SubjectID);
            }
            catch (Exception ex)
            {
                json = "-1";
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public bool AddALLUsersRolesSubjectAccess(int SubjectID)
        {
            try
            {
                SubjectIncidentsBase incidentBase = new SubjectIncidentsBase();
                incidentBase.SubjectID = SubjectID;
                incidentBase.CreatedBy = Convert.ToInt32(Session["UserID"]);
                actionResult = subjectAction.AddAll_UsersAndRoles_SubjectAccess(incidentBase);
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
                return false;
            }
            return actionResult.IsSuccess;
        }

        public string AddUsersSubject(string UserID, int SubjectID)
        {
            string json = string.Empty;

            if (UserID.Length > 0)
            {
                string[] UserIDList = UserID.Split(',');
                for (int i = 0; i <= UserIDList.Length - 1; i++)
                {
                    SubjectIncidentsBase incidentBase = new SubjectIncidentsBase();

                    incidentBase.ReportAccessBy = Convert.ToInt32(UserIDList[i]);
                    incidentBase.SubjectID = SubjectID;
                    incidentBase.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    actionResult = subjectAction.AddUsersSubjectAccess(incidentBase);
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

        #region Remove UsersSubject Access 
        [HttpPost]
        public JsonResult RemoveUsersSubjectAccess(string ID)
        {
            string json = string.Empty;
            try
            {
                if (ID.Length > 0)
                {
                    string[] IDList = ID.Split(',');
                    for (int i = 0; i <= IDList.Length - 1; i++)
                    {
                        SubjectIncidentsBase incidentBase = new SubjectIncidentsBase();
                        incidentBase.ReportAccessID = Convert.ToInt32(IDList[i]);
                        actionResult = subjectAction.RemoveUsersSubjectAccess(incidentBase);
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

        #region Bind SubjectAccess Users
        public JsonResult SubjectAccessUsers_Bind(int SubjectID)
        {
            string jsonString = string.Empty;
            try
            {
                SubjectIncidentsBase incidentBase = new SubjectIncidentsBase();
                incidentBase.UserID = Convert.ToInt32(Session["UserID"]);
                incidentBase.SubjectID = SubjectID;
                actionResult = subjectAction.SubjectAccessUsers_Bind(incidentBase);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += " <option value = " + actionResult.dtResult.Rows[i]["ID"] + "  onclick = \"SubjectAccessPermission('" + actionResult.dtResult.Rows[i]["ID"] + "'); \"> " + actionResult.dtResult.Rows[i]["FullName"] + " - " + actionResult.dtResult.Rows[i]["UserName"] + " </ option >";
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

        #region Save Subject Access Permission
        [HttpPost]
        public JsonResult SubjectAccessPermission(int ID, int SubjectID, string Type, string Permission)
        {
            string json = string.Empty;
            try
            {
                if (ID > 0)
                {
                    SubjectIncidentsBase incidentBase = new SubjectIncidentsBase();
                    incidentBase.ReportAccessID = Convert.ToInt32(ID);
                    incidentBase.SubjectID = SubjectID;
                    incidentBase.ReportAccessType = Type;
                    incidentBase.ReportAccessPermission = Convert.ToBoolean(Permission);
                    actionResult = subjectAction.SubjectAccessPermission(incidentBase);
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

        #region Bind SubjectAccess Permission ByUsers
        public JsonResult SubjectAccessPermission_ByUser(int ID, int SubjectID)
        {
            string jsonString = string.Empty;
            try
            {
                SubjectIncidentsBase incidentBase = new SubjectIncidentsBase();
                incidentBase.ReportAccessID = ID;
                incidentBase.SubjectID = SubjectID;
                actionResult = subjectAction.SubjectAccessPermission_ByUser(incidentBase);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    jsonString += actionResult.dtResult.Rows[0]["ViewReport"] != DBNull.Value ? actionResult.dtResult.Rows[0]["ViewReport"].ToString() : "false";
                    jsonString += ",";
                    jsonString += actionResult.dtResult.Rows[0]["EditReport"] != DBNull.Value ? actionResult.dtResult.Rows[0]["EditReport"].ToString() : "false";
                    jsonString += ",";
                    jsonString += actionResult.dtResult.Rows[0]["DeleteReport"] != DBNull.Value ? actionResult.dtResult.Rows[0]["DeleteReport"].ToString() : "false";
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

        #region Bind Users SubjectAccess Role
        public JsonResult UsersSubjectAccessRole(int SubjectID)
        {
            string jsonString = string.Empty;
            try
            {
                SubjectIncidentsBase incidentBase = new SubjectIncidentsBase();
                incidentBase.SubjectID = SubjectID;
                actionResult = subjectAction.UsersSubjectAccessRole(incidentBase);
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

        #region Add Roles SubjectAccess
        [HttpPost]
        public JsonResult AddRolesSubjectAccess(string RoleID, string SubjectID)
        {
            string json = string.Empty;
            try
            {
                if (RoleID.Length > 0)
                {
                    string[] RoleIDList = RoleID.Split(',');
                    for (int i = 0; i <= RoleIDList.Length - 1; i++)
                    {
                        SubjectIncidentsBase incidentBase = new SubjectIncidentsBase();

                        incidentBase.ReportAccessRole = Convert.ToInt32(RoleIDList[i]);
                        incidentBase.SubjectID = Convert.ToInt32(SubjectID);

                        incidentBase.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        actionResult = subjectAction.AddRolesSubjectAccess(incidentBase);
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

        #region Remove Roles SubjectAccess 
        [HttpPost]
        public JsonResult RemoveRolesSubjectAccess(string ID)
        {
            string json = string.Empty;
            try
            {
                if (ID.Length > 0)
                {
                    string[] RoleIDList = ID.Split(',');
                    for (int i = 0; i <= RoleIDList.Length - 1; i++)
                    {
                        SubjectIncidentsBase incidentBase = new SubjectIncidentsBase();
                        incidentBase.ReportAccessID = Convert.ToInt32(RoleIDList[i]);
                        actionResult = subjectAction.RemoveRolesSubjectAccess(incidentBase);
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

        #region Bind SubjectAccess Roles
        public JsonResult SubjectAccessRoles_Bind(int SubjectID)
        {
            string jsonString = string.Empty;
            try
            {
                SubjectIncidentsBase incidentBase = new SubjectIncidentsBase();
                incidentBase.UserID = Convert.ToInt32(Session["UserID"]);
                incidentBase.SubjectID = SubjectID;
                actionResult = subjectAction.SubjectAccessRoles_Bind(incidentBase);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += " <option value = " + actionResult.dtResult.Rows[i]["ID"] + "  onclick = \"SubjectAccessPermissionByRole('" + actionResult.dtResult.Rows[i]["ID"] + "'); \"> " + actionResult.dtResult.Rows[i]["RoleName"] + " </ option >";
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

        #region Save Subject Access Permission By Role
        [HttpPost]
        public JsonResult SubjectAccessPermissionByRole(int ID, int SubjectID, string Type, string Permission)
        {
            string json = string.Empty;
            try
            {
                if (ID > 0)
                {
                    SubjectIncidentsBase incidentBase = new SubjectIncidentsBase();
                    incidentBase.ReportAccessID = Convert.ToInt32(ID);
                    incidentBase.SubjectID = SubjectID;
                    incidentBase.ReportAccessType = Type;
                    incidentBase.ReportAccessPermission = Convert.ToBoolean(Permission);
                    actionResult = subjectAction.SubjectAccessPermissionByRole(incidentBase);
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

        #region Bind SubjectAccess Permission By Roles
        public JsonResult SubjectAccessPermission_ByRole(int ID, int SubjectID)
        {
            string jsonString = string.Empty;
            try
            {
                SubjectIncidentsBase incidentBase = new SubjectIncidentsBase();
                incidentBase.ReportAccessID = ID;
                incidentBase.SubjectID = SubjectID;
                actionResult = subjectAction.SubjectAccessPermission_ByRole(incidentBase);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    jsonString += actionResult.dtResult.Rows[0]["ViewReport"] != DBNull.Value ? actionResult.dtResult.Rows[0]["ViewReport"].ToString() : "false";
                    jsonString += ",";
                    jsonString += actionResult.dtResult.Rows[0]["EditReport"] != DBNull.Value ? actionResult.dtResult.Rows[0]["EditReport"].ToString() : "false";
                    jsonString += ",";
                    jsonString += actionResult.dtResult.Rows[0]["DeleteReport"] != DBNull.Value ? actionResult.dtResult.Rows[0]["DeleteReport"].ToString() : "false";
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
        //[ValidateAntiForgeryToken]
        public ActionResult LinkEvents(SubjectReportEvents objs)
        {
            if (ModelState.IsValid)
            {
                //var customerid = repo.GetCurrentUserCustomerId(_webSecurity.CurrentUserId());
                //repo.ADDAdGroups(customerid, objs);
                actionResult = subjectAction.SubjectReportEventsLink_Delete(objs.subjectid, objs.incidentid);

                if (objs.listeventid != null)
                {
                    foreach (var item in objs.listeventid)
                    {
                        if (item != 0)
                        {
                            eventsubjectreport objreport = new eventsubjectreport();
                            objreport.eventid = item;
                            objreport.incidentid = objs.incidentid;
                            objreport.subjectid = objs.subjectid;
                            actionResult = EventAction.Link_SubjectReport(objreport);
                        }
                    }
                }
                if (actionResult.IsSuccess)
                {
                    return Json("Events updated successfully.");
                }

                return Json("Error occurred while updating events.");

            }
            else
            {
                return Json("Error occurred while linking events.");
            }
        }

        public PartialViewResult EventListLink(int SubjectID, int IncidentID)
        {
            EventModel EventModel = new EventModel();
            List<EventModel> lstEventModel = new List<Models.EventModel>();
            EventBase model = new EventBase();
            model.UserID = Convert.ToString(Session["UserID"]);
            model.RoleID = Convert.ToInt32(Session["RoleId"]);
            model.SubjectID = SubjectID;
            model.IncidentID = IncidentID;

            actionResult = EventAction.EventSubjectLink_Load(model);

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
                                     UserID = row["UserID"] != DBNull.Value ? row["UserID"].ToString() : "",
                                     isLinkedEvent = row["isLinkedEvent"].ToString() == "False" ? false : true
                                 }).ToList();

            }
            EventModel.ListEventModel = lstEventModel;
            return PartialView(EventModel);
        }
    }
}