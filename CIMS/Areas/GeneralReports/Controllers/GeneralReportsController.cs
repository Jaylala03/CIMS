using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

using CIMS.BaseLayer.GeneralReports;
using CIMS.ActionLayer.GeneralReports;
using CIMS.Models;
using CIMS.Utility;
using CIMS.Filters;
using CIMS.Helpers;
using System.IO;
using CIMS.BaseLayer.Events;
using CIMS.ActionLayer.Events;

namespace CIMS.Areas.GeneralReports.Controllers
{
    [CheckLogin]
    [CheckPermissionAttribute]
    public class GeneralReportsController : Controller
    {
        #region Declaration
        GeneralReportsAction reportsAction = new GeneralReportsAction();
        EventAction EventAction = new EventAction();
        CIMS.BaseLayer.ActionResult actionResult = new CIMS.BaseLayer.ActionResult();
        #endregion

        // GET: GeneralReports/GeneralReports
        public ActionResult Index(int? Id = 0)
        {
            GeneralReportsBase generalReportsBase = new GeneralReportsBase();
            GeneralReportsModel generalReportsModel = new GeneralReportsModel();

            CIMS.ActionLayer.Setting.SettingAction settingAction = new CIMS.ActionLayer.Setting.SettingAction();

            List<SelectListItem> lstShortDescription = new List<SelectListItem>();
            lstShortDescription.Add(new SelectListItem { Text = "Select", Value = "Select" });
            ViewBag.lstShortDescription = lstShortDescription;

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

            CIMS.BaseLayer.Subject.SubjectIncidentsBase subject = new CIMS.BaseLayer.Subject.SubjectIncidentsBase();
            CIMS.ActionLayer.Subject.SubjectAction subjectAction = new CIMS.ActionLayer.Subject.SubjectAction();

            List<SelectListItem> LocationList = new List<SelectListItem>();
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
            generalReportsModel.LocationList = LocationList;

            List<SelectListItem> lstNatureOfIncident = new List<SelectListItem>();
            lstNatureOfIncident.Add(new SelectListItem { Text = "Select", Value = "Select" });
            CIMS.BaseLayer.Setting.NatureofIncidentBase natureBase = new CIMS.BaseLayer.Setting.NatureofIncidentBase();
            natureBase.NatureType = 3;
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

            subject.Part = "Status";
            actionResult = subjectAction.Codes_LoadByPart(subject);
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

            if (Id > 0)
            {
                generalReportsBase.ReportID = Id.Value;
                actionResult = reportsAction.GeneralReport_LoadByReportID(generalReportsBase);
                if (actionResult.IsSuccess)
                {

                    DataRow dr = actionResult.dtResult.Rows[0];
                    generalReportsModel.ReportID = dr["ReportID"] != DBNull.Value ? Convert.ToInt32(dr["ReportID"]) : 0;
                    generalReportsModel.ReportNumber = dr["ReportNumber"] != DBNull.Value ? dr["ReportNumber"].ToString() : "";
                    generalReportsModel.NatureOfEvent = dr["NatureOfEvent"] != DBNull.Value ? dr["NatureOfEvent"].ToString() : "";
                    generalReportsModel.ShortDescriptor = dr["ShortDescriptor"] != DBNull.Value ? dr["ShortDescriptor"].ToString() : "";
                    generalReportsModel.ActiveStatus = dr["ActiveStatus"] != DBNull.Value ? Convert.ToBoolean(dr["ActiveStatus"]) : false;
                    generalReportsModel.Status = dr["Status"] != DBNull.Value ? dr["Status"].ToString() : "";
                    if (dr["IncidentDate"] != DBNull.Value)
                    {
                        generalReportsModel.IncidentDate = Convert.ToDateTime(dr["IncidentDate"]).Date;
                    }

                    generalReportsModel.Description = dr["Description"] != DBNull.Value ? dr["Description"].ToString() : "";
                    generalReportsModel.Location = dr["Location"] != DBNull.Value ? dr["Location"].ToString() : "";
                    generalReportsModel.IncidentRole = dr["IncidentRole"] != DBNull.Value ? dr["IncidentRole"].ToString() : "";
                    generalReportsModel.IncidentTime = dr["IncidentTime"] != DBNull.Value ? dr["IncidentTime"].ToString() : "";
                    generalReportsModel.UD51 = dr["UD51"] != DBNull.Value ? dr["UD51"].ToString() : "";
                    generalReportsModel.UD52 = dr["UD52"] != DBNull.Value ? dr["UD52"].ToString() : "";
                    generalReportsModel.UD53 = dr["UD53"] != DBNull.Value ? dr["UD53"].ToString() : "";
                    generalReportsModel.CheckPermissionID = dr["CreatedBy"] != DBNull.Value ? Convert.ToInt32(dr["CreatedBy"]) : 0;
                    generalReportsModel.UserName = dr["UserName"] != DBNull.Value ? dr["UserName"].ToString() : "";
                    //generalReportsModel.ReportCreatorUser = dr["ReportCreatorUser"] != DBNull.Value ? dr["ReportCreatorUser"].ToString() : "";
                    generalReportsModel.ReportCreatorFirstName = dr["ReportCreatorFirstName"] != DBNull.Value ? dr["ReportCreatorFirstName"].ToString() : "";
                    generalReportsModel.ReportCreatorLastName = dr["ReportCreatorLastName"] != DBNull.Value ? dr["ReportCreatorLastName"].ToString() : "";
                    generalReportsModel.ReportCreateDate = dr["CreatedDate"] != DBNull.Value ? dr["CreatedDate"].ToString() : "";
                }                
            }
            else
            {
                actionResult = reportsAction.GeneralReportsMax_Load();
                if (actionResult.IsSuccess)
                {
                    generalReportsModel.ReportNumber = actionResult.dtResult.Rows[0][0] != DBNull.Value ? actionResult.dtResult.Rows[0][0].ToString() : " ";
                }
            }

            generalReportsBase.ReportID = generalReportsModel.ReportID;
            actionResult = reportsAction.GenRepLCTPitTransactions_LoadById(generalReportsBase);
            List<LCTPitTransactionsModel> lstLCTPitTransactionsBase = new List<LCTPitTransactionsModel>();
            if (actionResult.IsSuccess)
            {
                lstLCTPitTransactionsBase = (from DataRow row in actionResult.dtResult.Rows
                                             select new LCTPitTransactionsModel
                                             {
                                                 ID = row["ID"] != DBNull.Value ? Convert.ToInt32(row["ID"]) : 0,
                                                 IncidentID = row["ReportID"] != DBNull.Value ? Convert.ToInt32(row["ReportID"]) : 0,
                                                 BuyInType = row["BuyInType"] != DBNull.Value ? row["BuyInType"].ToString() : "",
                                                 Pit = row["Pit"] != DBNull.Value ? row["Pit"].ToString() : "",
                                                 GameName = row["GameName"] != DBNull.Value ? row["GameName"].ToString() : "",
                                                 BuyInTime = row["BuyInTime"] != DBNull.Value ? row["BuyInTime"].ToString() : "",
                                                 Amount = row["Amount"] != DBNull.Value ? Convert.ToDecimal(row["Amount"]) : 0

                                             }).ToList();
            }
            generalReportsModel.LCTPitTransactionsModelList = lstLCTPitTransactionsBase;

            actionResult = reportsAction.GenRepLCTCashOuts_LoadById(generalReportsBase);
            List<LCTCashOutsModel> lstLCTCashOutsModel = new List<LCTCashOutsModel>();
            if (actionResult.IsSuccess)
            {
                lstLCTCashOutsModel = (from DataRow row in actionResult.dtResult.Rows
                                       select new LCTCashOutsModel
                                       {
                                           ID = row["ID"] != DBNull.Value ? Convert.ToInt32(row["ID"]) : 0,
                                           IncidentID = row["ReportID"] != DBNull.Value ? Convert.ToInt32(row["ReportID"]) : 0,
                                           CashOutTime = row["CashOutTime"] != DBNull.Value ? row["CashOutTime"].ToString() : "",
                                           ChequeNo = row["ChequeNo"] != DBNull.Value ? row["ChequeNo"].ToString() : "",
                                           PaymentType = row["PaymentType"] != DBNull.Value ? row["PaymentType"].ToString() : "",
                                           TableNumber = row["TableNumber"] != DBNull.Value ? row["TableNumber"].ToString() : "",
                                           TypeOfWin = row["TypeOfWin"] != DBNull.Value ? row["TypeOfWin"].ToString() : "",

                                           Amount = row["Amount"] != DBNull.Value ? Convert.ToDecimal(row["Amount"]) : 0

                                       }).ToList();

            }
            generalReportsModel.LCTCashOutsModelList = lstLCTCashOutsModel;

            actionResult = reportsAction.GenRepLCTForeignExchange_LoadById(generalReportsBase);
            List<LCTForeignExchangeModel> lstLCTForeignExchangeModel = new List<LCTForeignExchangeModel>();
            if (actionResult.IsSuccess)
            {
                lstLCTForeignExchangeModel = (from DataRow row in actionResult.dtResult.Rows
                                              select new LCTForeignExchangeModel
                                              {
                                                  ID = row["ID"] != DBNull.Value ? Convert.ToInt32(row["ID"]) : 0,
                                                  IncidentID = row["ReportID"] != DBNull.Value ? Convert.ToInt32(row["ReportID"]) : 0,
                                                  Rate = row["Rate"] != DBNull.Value ? Convert.ToDecimal(row["Rate"]) : 0,
                                                  ForeignAmount = row["ForeignAmount"] != DBNull.Value ? Convert.ToDecimal(row["ForeignAmount"]) : 0,
                                                  ForeignCountry = row["ForeignCountry"] != DBNull.Value ? row["ForeignCountry"].ToString() : "",
                                                  ForeignCountryName = row["ForeignCountryName"] != DBNull.Value ? row["ForeignCountryName"].ToString() : "",
                                                  Amount = row["Amount"] != DBNull.Value ? Convert.ToDecimal(row["Amount"]) : 0

                                              }).ToList();

            }
            generalReportsModel.LCTForeignExchangeModelList = lstLCTForeignExchangeModel;
            actionResult = reportsAction.GenRepLCTCashCall_LoadById(generalReportsBase);
            List<LCTCashCallModel> lstLCTCashCallModel = new List<LCTCashCallModel>();
            if (actionResult.IsSuccess)
            {
                lstLCTCashCallModel = (from DataRow row in actionResult.dtResult.Rows
                                       select new LCTCashCallModel
                                       {
                                           ID = row["ID"] != DBNull.Value ? Convert.ToInt32(row["ID"]) : 0,
                                           IncidentID = row["ReportID"] != DBNull.Value ? Convert.ToInt32(row["ReportID"]) : 0,
                                           CashCallTime = row["CashCallTime"] != DBNull.Value ? row["CashCallTime"].ToString() : "",
                                           Cashier = row["Cashier"] != DBNull.Value ? row["Cashier"].ToString() : "",
                                           CashierName = row["CashierName"] != DBNull.Value ? row["CashierName"].ToString() : "",
                                           Amount = row["Amount"] != DBNull.Value ? Convert.ToDecimal(row["Amount"]) : 0
                                       }).ToList();

            }
            generalReportsModel.LCTCashCallModelList = lstLCTCashCallModel;

            actionResult = reportsAction.GenReportsVehicles_LoadById(generalReportsBase);
            List<VehiclesModel> lstVehiclesModel = new List<VehiclesModel>();
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
                                        VehicleYear = row["VehicleYear"] != DBNull.Value ? row["VehicleYear"].ToString() : ""
                                    }).ToList();
            }
            generalReportsModel.VehiclesModelList = lstVehiclesModel;            

            actionResult = reportsAction.GenReportsInvolved_LoadAll(generalReportsBase);
            List<SubjectInvolvedModel> lstSubjectInvolved = new List<SubjectInvolvedModel>();
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
            generalReportsModel.SubjectInvolvedModelList = lstSubjectInvolved;

            BannedModel BannedModel = new Models.BannedModel();
            generalReportsModel.BannedModel = BannedModel;
            subject.Part = "Ban Types";
            actionResult = subjectAction.Codes_LoadByPart(subject);
            List<BanType> BanTypeList = new List<BanType>();
            if (actionResult.IsSuccess)
            {
                BanTypeList = (from DataRow row in actionResult.dtResult.Rows
                               select new BanType
                               {
                                   Text = row["Description"] != DBNull.Value ? row["Description"].ToString() : "",
                                   Value = row["Description"] != DBNull.Value ? row["Description"].ToString() : ""
                               }).ToList();
            }
            BannedModel.BanTypeList = BanTypeList;

            actionResult = reportsAction.GeneralReportBanned_LoadByReportID(generalReportsBase);
            if (actionResult.IsSuccess)
            {

                DataRow dr = actionResult.dtResult.Rows[0];

                generalReportsModel.BannedModel.Description = dr["Description"] != DBNull.Value ? dr["Description"].ToString() : "";
                generalReportsModel.BannedModel.StartDate = dr["StartDate"] != DBNull.Value ? dr["StartDate"].ToString() : "";
                generalReportsModel.BannedModel.EndDate = dr["EndDate"] != DBNull.Value ? dr["EndDate"].ToString() : "";
                generalReportsModel.BannedModel.EntryDate = dr["EntryDate"] != DBNull.Value ? dr["EntryDate"].ToString() : "";
                generalReportsModel.BannedModel.AuthorizedBy = dr["AuthorizedBy"] != DBNull.Value ? dr["AuthorizedBy"].ToString() : "";
                generalReportsModel.BannedModel.BanDays = dr["BanDays"] != DBNull.Value ? Convert.ToInt32(dr["BanDays"]) : 0;
                generalReportsModel.BannedModel.BanMonths = dr["BanMonths"] != DBNull.Value ? Convert.ToInt32(dr["BanMonths"]) : 0;
                generalReportsModel.BannedModel.BanYears = dr["BanYears"] != DBNull.Value ? Convert.ToInt32(dr["BanYears"]) : 0;
            }
           
            actionResult = reportsAction.GeneralReportsBanType_LoadByReportID(generalReportsBase);
            List<BanType> BanTypesubList = new List<BanType>();
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
            BannedModel.BanTypesubList = BanTypesubList;

            actionResult = settingAction.MstBanType_Load();
            List<MSTBanType> MstBanTypeList = new List<MSTBanType>();
            if (actionResult.IsSuccess)
            {
                MstBanTypeList = (from DataRow row in actionResult.dtResult.Rows
                                  select new MSTBanType
                                  {
                                      Text = row["TypeOfBan"] != DBNull.Value ? row["TypeOfBan"].ToString() : "",
                                      Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                  }).ToList();
            }
            BannedModel.MSTBanTypeList = MstBanTypeList;
            List<SelectListItem> AuthorizedByList = new List<SelectListItem>();
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
            generalReportsModel.AuthorizedByList = AuthorizedByList;

           
            List<SelectListItem> ResolutionList = new List<SelectListItem>();
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
            generalReportsModel.ResolutionList = ResolutionList;

            List<SelectListItem> GameList = new List<SelectListItem>();
            actionResult = settingAction.MasterGame_Load();
            if (actionResult.IsSuccess)
            {
                GameList = (from DataRow row in actionResult.dtResult.Rows
                            select new SelectListItem
                            {
                                Text = row["Game"] != DBNull.Value ? row["Game"].ToString() : "",
                                Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                            }).ToList();
            }
            generalReportsModel.GameList = GameList;

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

            List<SelectListItem> DisputTypeList = new List<SelectListItem>();
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
            generalReportsModel.DisputTypeList = DisputTypeList;

            DisputeModel DisputeModel = new Models.DisputeModel();
            generalReportsModel.DisputeModel = DisputeModel;
            actionResult = reportsAction.GenReportsDisputes_LoadByID(generalReportsBase);
            if (actionResult.IsSuccess)
            {

                DataRow dr = actionResult.dtResult.Rows[0];
                generalReportsModel.ReportID = dr["ReportID"] != DBNull.Value ? Convert.ToInt32(dr["ReportID"]) : 0;
                generalReportsModel.DisputeModel.Description = dr["Description"] != DBNull.Value ? dr["Description"].ToString() : "";
                generalReportsModel.DisputeModel.RecoveredMoney = dr["RecoveredMoney"] != DBNull.Value ? Convert.ToBoolean(dr["RecoveredMoney"]) : false;
                generalReportsModel.DisputeModel.Resolution = dr["Resolution"] != DBNull.Value ? dr["Resolution"].ToString() : "";
                generalReportsModel.DisputeModel.Amount = dr["Amount"] != DBNull.Value ? dr["Amount"].ToString() : "";
                generalReportsModel.DisputeModel.DisputeType = dr["DisputeType"] != DBNull.Value ? dr["DisputeType"].ToString() : "";
            }

            actionResult = reportsAction.GenReportsServicesOffered_LoadbyReportID(generalReportsBase);
            List<ServiceModel> SubjectServicesmodellist = new List<ServiceModel>();
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
            generalReportsModel.ServiceSubjectModelList = SubjectServicesmodellist;

            ServiceModel service = new ServiceModel();
            generalReportsModel.ServiceModel = service;

            actionResult = reportsAction.GenReportServices_LoadbyReportID(generalReportsBase);
            if (actionResult.IsSuccess)
            {

                DataRow dr = actionResult.dtResult.Rows[0];
                generalReportsModel.ServiceModel.CallTime = dr["CallTime"] != DBNull.Value ? Convert.ToDateTime(dr["CallTime"].ToString()).ToString("hh:mm tt") : "";
                generalReportsModel.ServiceModel.Description = dr["Description"] != DBNull.Value ? dr["Description"].ToString() : "";
                generalReportsModel.ServiceModel.ServiceBy = dr["ServiceBy"] != DBNull.Value ? dr["ServiceBy"].ToString() : "";
                generalReportsModel.ServiceModel.ServiceFor = dr["ServiceFor"] != DBNull.Value ? dr["ServiceFor"].ToString() : "";
                generalReportsModel.ServiceModel.ArriveTime = dr["ArriveTime"] != DBNull.Value ? Convert.ToDateTime(dr["ArriveTime"].ToString()).ToString("hh:mm tt") : "";

            }
            actionResult = subjectAction.Services_LoadAll();
            List<ServiceModel> servicemodellist = new List<ServiceModel>();
            if (actionResult.IsSuccess)
            {
                servicemodellist = CommonMethods.ConvertTo<ServiceModel>(actionResult.dtResult);
            }
            generalReportsModel.ServiceModelList = servicemodellist;

            actionResult = reportsAction.GenReportLinked_LoadByReportID(generalReportsBase);
            List<IncidentLinkedModel> lstIncidentLinkedModel = new List<IncidentLinkedModel>();
            if (actionResult.IsSuccess)
            {
                lstIncidentLinkedModel = CommonMethods.ConvertTo<IncidentLinkedModel>(actionResult.dtResult);
            }
            generalReportsModel.IncidentLinkedModelList = lstIncidentLinkedModel;

            actionResult = subjectAction.GetAuthorName(Convert.ToInt32(Session["UserId"]), Convert.ToInt32(Id.Value));
            List<SelectListItem> AuthorNameList = new List<SelectListItem>();
            if (actionResult.IsSuccess)
            {
                AuthorNameList = (from DataRow row in actionResult.dtResult.Rows
                                  select new SelectListItem
                                  {
                                      Text = row["Column1"] != DBNull.Value ? row["Column1"].ToString() + "|" + row["UserName"].ToString() : "",
                                      Value = row["Column1"] != DBNull.Value ? row["Column1"].ToString() + "|" + row["UserName"].ToString() : ""
                                  }).ToList();
            }
            generalReportsModel.AuthorNameList = AuthorNameList;

            ReportModel ReportModel = new Models.ReportModel();
            generalReportsModel.ReportModel = ReportModel;
            actionResult = reportsAction.IncidentGenReports_LoadByReportID(generalReportsBase);
            if (actionResult.IsSuccess)
            {

                DataRow dr = actionResult.dtResult.Rows[0];
                generalReportsModel.ReportID = dr["ReportID"] != DBNull.Value ? Convert.ToInt32(dr["ReportID"]) : 0;
                generalReportsModel.ReportModel.ID = dr["ID"] != DBNull.Value ? Convert.ToInt32(dr["ID"]) : 0;
               generalReportsModel.ReportModel.Description = dr["Report"] != DBNull.Value ? dr["Report"].ToString() : "";
               generalReportsModel.ReportModel.ReportDate = dr["ReportDate"] != DBNull.Value ? dr["ReportDate"].ToString() : "";
               generalReportsModel.ReportModel.UserID = dr["UserId"] != DBNull.Value ? dr["UserId"].ToString() : "";
            }           

            generalReportsBase.UserID = Convert.ToInt32(Session["UserId"]);
            generalReportsBase.ReportID = generalReportsModel.ReportID;
            actionResult = reportsAction.UserGenReportsAccess_LoadAll(generalReportsBase);
            List<GeneralReportsModel> UsersList = new List<GeneralReportsModel>();
            if (actionResult.IsSuccess)
            {
                UsersList = (from DataRow row in actionResult.dtResult.Rows
                             select new GeneralReportsModel
                             {
                                 FirstName = row["FirstName"] != DBNull.Value ? row["FirstName"].ToString() : "",
                                 LastName = row["LastName"] != DBNull.Value ? row["LastName"].ToString() : "",
                                 UserName = row["UserName"] != DBNull.Value ? row["UserName"].ToString() : "",
                                 UserID = row["UserID"] != DBNull.Value ? Convert.ToInt32(row["UserID"]) : 0,
                                 RepPerID = row["RepPerID"] != DBNull.Value ? Convert.ToInt32(row["RepPerID"]) : 0,
                                 ReportID = row["ReportID"] != DBNull.Value ? Convert.ToInt32(row["ReportID"]) : 0,
                                 ReportAccessBy = row["ReportAccessBy"] != DBNull.Value ? Convert.ToInt32(row["ReportAccessBy"]) : 0,
                                 ReportView = row["ReportView"] != DBNull.Value ? Convert.ToBoolean(row["ReportView"]) : false,
                                 ReportEdit = row["ReportEdit"] != DBNull.Value ? Convert.ToBoolean(row["ReportEdit"]) : false,
                                 ReportDelete = row["ReportDelete"] != DBNull.Value ? Convert.ToBoolean(row["ReportDelete"]) : false
                             }).ToList();
            }
            generalReportsModel.GeneralReportsList = UsersList;

            return View(generalReportsModel);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Index(GeneralReportsModel model)
        {
            try
            {
                GeneralReportsBase generalReportsBase = new GeneralReportsBase();
                generalReportsBase.ReportID = model.ReportID;
                generalReportsBase.ActiveStatus = model.ActiveStatus;
                generalReportsBase.Description = model.Description;
                generalReportsBase.IncidentDate = model.IncidentDate;
                generalReportsBase.ReportNumber = model.ReportNumber;
                generalReportsBase.IncidentRole = model.IncidentRole;
                generalReportsBase.Location = model.Location;
                generalReportsBase.NatureOfEvent = model.NatureOfEvent;
                generalReportsBase.ShortDescriptor = model.ShortDescriptor;
                generalReportsBase.IncidentTime = model.IncidentTime;
                generalReportsBase.Status = model.Status;
                generalReportsBase.UD51 = model.UD51;
                generalReportsBase.UD52 = model.UD52;
                generalReportsBase.UD53 = model.UD53;
                generalReportsBase.CreatedBy = Convert.ToInt32(Session["UserId"]);
                actionResult = reportsAction.GeneralReport_AddEdit(generalReportsBase);
                if (actionResult.dtResult.Rows.Count > 0)
                {
                    int result = actionResult.dtResult.Rows[0][0] != DBNull.Value ? Convert.ToInt32(actionResult.dtResult.Rows[0][0]) : 0;
                    if (result > 0)
                    {
                        if (model.ReportID > 0)
                            TempData["SuccessMessage"] = "General Reports Updated Successfully.";
                        else
                        {
                            model.ReportID = result;
                            TempData["SuccessMessage"] = "General Reports Added Successfully.";
                        }
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Some error Occurred, please try again later.";
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Some error Occurred, please try again later.";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return RedirectToAction("Index", new { Id = model.ReportID });
        }

        [HttpGet]
        public ActionResult GeneralReportsList()
        {
            GeneralReportsBase reportsBase = new GeneralReportsBase();
            GeneralReportsModel model = new GeneralReportsModel();
            List<GeneralReportsModel> lstGeneralReports = new List<GeneralReportsModel>();

            reportsBase.CreatedBy = Convert.ToInt32(Session["UserId"]);
            reportsBase.ReportAccessRole = Convert.ToInt32(Session["RoleId"]);
            actionResult = reportsAction.GeneralReport_LoadByUser(reportsBase);
            if (actionResult.IsSuccess)
            {
                lstGeneralReports = (from DataRow row in actionResult.dtResult.Rows
                                     select new GeneralReportsModel
                                     {
                                         ReportID = row["ReportID"] != DBNull.Value ? Convert.ToInt32(row["ReportID"]) : 0,
                                         ReportNumber = row["ReportNumber"] != DBNull.Value ? row["ReportNumber"].ToString() : "",
                                         ShortDescriptorName = row["ShortDescriptorName"] != DBNull.Value ? row["ShortDescriptorName"].ToString() : "",
                                         StatusName = row["StatusName"] != DBNull.Value ? row["StatusName"].ToString() : "",
                                         UserName = row["UserName"] != DBNull.Value ? row["UserName"].ToString() : "",
                                         DefaultImage = row["DefaultImage"] != DBNull.Value ? row["DefaultImage"].ToString() : ""
                                     }).ToList();
            }
            model.ListGeneralReports = lstGeneralReports;
            return View(model);
        }

        public PartialViewResult ALLGeneralReportsList(int EventId)
        {
            GeneralReportsBase reportsBase = new GeneralReportsBase();
            GeneralReportsModel model = new GeneralReportsModel();
            List<GeneralReportsModel> lstGeneralReports = new List<GeneralReportsModel>();

            reportsBase.CreatedBy = Convert.ToInt32(Session["UserId"]);
            reportsBase.EventID = EventId;
            reportsBase.ReportAccessRole = Convert.ToInt32(Session["RoleId"]);
            actionResult = reportsAction.GeneralReport_LoadALL(reportsBase);
            if (actionResult.IsSuccess)
            {
                lstGeneralReports = (from DataRow row in actionResult.dtResult.Rows
                                     select new GeneralReportsModel
                                     {
                                         ReportID = row["ReportID"] != DBNull.Value ? Convert.ToInt32(row["ReportID"]) : 0,
                                         ReportNumber = row["ReportNumber"] != DBNull.Value ? row["ReportNumber"].ToString() : "",
                                         ShortDescriptorName = row["ShortDescriptorName"] != DBNull.Value ? row["ShortDescriptorName"].ToString() : "",
                                         StatusName = row["StatusName"] != DBNull.Value ? row["StatusName"].ToString() : "",
                                         UserName = row["UserName"] != DBNull.Value ? row["UserName"].ToString() : "",
                                         DefaultImage = row["DefaultImage"] != DBNull.Value ? row["DefaultImage"].ToString() : "",
                                         NatureOfEvent = row["NatureOfEvent"] != DBNull.Value ? row["NatureOfEvent"].ToString() : "",
                                         isLinkedEvent = row["isLinkedEvent"].ToString() == "False" ? false : true
                                     }).ToList();
            }
            model.ListGeneralReports = lstGeneralReports;
            return PartialView(model);
        }
        #region DeleteGeneralReports
        public JsonResult DeleteGeneralReports(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                GeneralReportsBase reportsBase = new GeneralReportsBase();

                reportsBase.ReportID = ID;

                actionResult = reportsAction.DeleteGeneralReport_ByID(reportsBase);

                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "fail";
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
        public ActionResult GeneralReportsBuyIn(GeneralReportsModel model)
        {
            try
            {
                CIMS.BaseLayer.Subject.LCTPitTransactionsBase BuyIn = new CIMS.BaseLayer.Subject.LCTPitTransactionsBase();
                BuyIn.ID = model.LCTPitTransactionsModel.ID;
                BuyIn.IncidentID = model.ReportID;
                BuyIn.BuyInTime = model.LCTPitTransactionsModel.BuyInTime.ToString();
                BuyIn.BuyInType = model.LCTPitTransactionsModel.BuyInType;
                BuyIn.Amount = model.LCTPitTransactionsModel.Amount;
                BuyIn.Game = model.LCTPitTransactionsModel.Game;
                BuyIn.Pit = model.LCTPitTransactionsModel.Pit;
                
                actionResult = reportsAction.LCTPitTransactions_GeneralReport(BuyIn);
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
            return RedirectToAction("Index", new { Id = model.ReportID });
        }

        #region DeleteCashBuyIn
        [HttpPost]
        public JsonResult DeleteCashBuyIn(int? Id = 0)
        {
            string json = string.Empty;
            try
            {
                CIMS.BaseLayer.Subject.LCTPitTransactionsBase BuyIn = new CIMS.BaseLayer.Subject.LCTPitTransactionsBase();
                BuyIn.ID = Convert.ToInt32(Id);
                actionResult = reportsAction.GenRepLCTPitTransactions_Delete(BuyIn);
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
        public ActionResult GeneralReportsExchange(GeneralReportsModel model)
        {
            try
            {
                CIMS.BaseLayer.Subject.LCTForeignExchangeBase Exchanges = new CIMS.BaseLayer.Subject.LCTForeignExchangeBase();
                Exchanges.ID = model.LCTForeignExchangeModel.ID;
                Exchanges.IncidentID = model.ReportID;
                Exchanges.ForeignCountry = model.LCTForeignExchangeModel.ForeignCountry;
                Exchanges.ForeignAmount = model.LCTForeignExchangeModel.ForeignAmount;
                Exchanges.Amount = model.LCTForeignExchangeModel.Amount;
                Exchanges.Rate = model.LCTForeignExchangeModel.Rate;

                actionResult = reportsAction.LCTForeignExchange_GenReport(Exchanges);
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
            return RedirectToAction("Index", new { Id = model.ReportID });
        }

        #region DeleteExchange
        [HttpPost]
        public JsonResult DeleteExchange(int? Id = 0)
        {
            string json = string.Empty;
            try
            {
                CIMS.BaseLayer.Subject.LCTForeignExchangeBase Exchange = new CIMS.BaseLayer.Subject.LCTForeignExchangeBase();
                Exchange.ID = Convert.ToInt32(Id);
                actionResult = reportsAction.GenReportLCTForeignExchange_Delete(Exchange);
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
        public ActionResult GeneralReportsCashOuts(GeneralReportsModel model)
        {
            try
            {
                CIMS.BaseLayer.Subject.LCTCashOutsBase Cashout = new CIMS.BaseLayer.Subject.LCTCashOutsBase();
                Cashout.ID = model.LCTCashOutsModel.ID;
                Cashout.IncidentID = model.ReportID;
                Cashout.Amount = model.LCTCashOutsModel.Amount;
                Cashout.CashOutTime = model.LCTCashOutsModel.CashOutTime;
                Cashout.ChequeNo = model.LCTCashOutsModel.ChequeNo;
                Cashout.PaymentType = model.LCTCashOutsModel.PaymentType;
                Cashout.TableNumber = model.LCTCashOutsModel.TableNumber;
                Cashout.TypeOfWin = model.LCTCashOutsModel.TypeOfWin;

                actionResult = reportsAction.LCTCashOuts_GenReport(Cashout);
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
            return RedirectToAction("Index", new { Id = model.ReportID });
        }

        #region DeleteCashOuts
        [HttpPost]
        public JsonResult DeleteCashOuts(int? Id = 0)
        {
            string json = string.Empty;
            try
            {
                CIMS.BaseLayer.Subject.LCTCashOutsBase CashOuts = new CIMS.BaseLayer.Subject.LCTCashOutsBase();
                CashOuts.ID = Convert.ToInt32(Id);
                actionResult = reportsAction.GenRepLCTCashOuts_Delete(CashOuts);
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
        public ActionResult GeneralReportsCashCall(GeneralReportsModel model)
        {
            try
            {
                CIMS.BaseLayer.Subject.LCTCashCallBase CashCall = new CIMS.BaseLayer.Subject.LCTCashCallBase();
                CashCall.ID = model.LCTCashCallModel.ID;
                CashCall.IncidentID = model.ReportID;
                CashCall.Amount = model.LCTCashCallModel.Amount;
                CashCall.CashCallTime = model.LCTCashCallModel.CashCallTime;
                CashCall.Cashier = model.LCTCashCallModel.Cashier;

                actionResult = reportsAction.LCTCashCall_GenReports(CashCall);
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
            return RedirectToAction("Index", new { Id = model.ReportID });
        }

        #region DeleteExchange
        [HttpPost]
        public JsonResult DeleteCashCall(int? Id = 0)
        {
            string json = string.Empty;
            try
            {
                CIMS.BaseLayer.Subject.LCTCashCallBase CashCall = new CIMS.BaseLayer.Subject.LCTCashCallBase();
                CashCall.ID = Convert.ToInt32(Id);
                actionResult = reportsAction.GenRepLCTCashCall_Delete(CashCall);
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

        public ActionResult GeneralReportsVehicles(GeneralReportsModel model)
        {
            try
            {
                CIMS.BaseLayer.Subject.VehiclesBase Vehicles = new CIMS.BaseLayer.Subject.VehiclesBase();
                Vehicles.VehicleID = model.VehiclesModel.VehicleID;
                Vehicles.IncidentID = model.ReportID;
                Vehicles.VehicleColor = model.VehiclesModel.VehicleColor;
                Vehicles.IssuedIn = model.VehiclesModel.IssuedIn;
                Vehicles.LicensePlate = model.VehiclesModel.LicensePlate;
                Vehicles.VehicleYear = model.VehiclesModel.VehicleYear;
                Vehicles.VehicleVIN = model.VehiclesModel.VehicleVIN;
                Vehicles.VehicleModel = model.VehiclesModel.VehicleModel;
                Vehicles.VehicleMake = model.VehiclesModel.VehicleMake;



                actionResult = reportsAction.GenReportsVehicles_AddEdit(Vehicles);
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
            return RedirectToAction("Index", new { Id = model.ReportID });
        }

        #region DeleteVehicle
        [HttpPost]
        public JsonResult DeleteVehicle(int? Id = 0)
        {
            string json = string.Empty;
            try
            {
                CIMS.BaseLayer.Subject.VehiclesBase VehiclesBase = new CIMS.BaseLayer.Subject.VehiclesBase();
                VehiclesBase.VehicleID = Convert.ToInt32(Id);
                actionResult = reportsAction.GenReportsVehicles_Delete(VehiclesBase);
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
        public ActionResult GeneralReportsInvolved(GeneralReportsModel model)
        {
            try
            {
                CIMS.BaseLayer.Subject.SubjectInvolvedBase involved = new CIMS.BaseLayer.Subject.SubjectInvolvedBase();
                involved.CreatedBy = Convert.ToInt32(Session["UserID"]);

                involved.SubjectIncidentID = model.SubjectInvolvedModel.SubjectIncidentID;
                involved.InvolvedID = model.SubjectInvolvedModel.InvolvedID;

                involved.InvolvedID = model.SubjectInvolvedModel.InvolvedID;

                involved.InvolvedID = model.SubjectInvolvedModel.InvolvedID;
                involved.IncidentID = model.ReportID;

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

                actionResult = reportsAction.GenReportsInvolved_AddEdit(involved);
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
            return RedirectToAction("Index", new { Id = model.ReportID});
        }

        #region DeleteInvolved
        [HttpPost]
        public JsonResult DeleteInvolved(int? Id = 0, int? ReportID = 0)
        {
            string json = string.Empty;
            try
            {
                CIMS.BaseLayer.Subject.SubjectInvolvedBase SubjectInvolvedBase = new CIMS.BaseLayer.Subject.SubjectInvolvedBase();
                SubjectInvolvedBase.IncidentID = Convert.ToInt32(ReportID);
                SubjectInvolvedBase.InvolvedID = Convert.ToInt32(Id);
                actionResult = reportsAction.GenReportsInvolved_Delete(SubjectInvolvedBase);
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
        public ActionResult GeneralReportsDispute(GeneralReportsModel model)
        {
            try
            {
                CIMS.BaseLayer.Subject.DisputeBase DisputeBase = new CIMS.BaseLayer.Subject.DisputeBase();

                DisputeBase.IncidentID = model.ReportID;
                DisputeBase.Amount = model.DisputeModel.Amount;
                DisputeBase.Description = model.DisputeModel.Description;
                DisputeBase.RecoveredMoney = model.DisputeModel.RecoveredMoney;
                DisputeBase.DisputeType = model.DisputeModel.DisputeType;
                DisputeBase.Resolution = model.DisputeModel.Resolution;
                actionResult = reportsAction.GeneralReportsDisputes_IU(DisputeBase);
                if (actionResult.dtResult.Rows.Count > 0)
                {

                    TempData["SuccessMessage"] = "Dispute has been Saved Successfully";
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
            return RedirectToAction("Index", new { Id = model.ReportID });
        }

        [HttpPost]
        public ActionResult GenReportsLInkedFiles(HttpPostedFileBase FilePath, GeneralReportsModel model, FormCollection fc, int Maintab = 19)
        {
            try
            {
                if (!System.IO.Directory.Exists(Server.MapPath("~/Content/GeneralReports/LinkedFiles")))
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath("~/Content/GeneralReports/LinkedFiles"));
                }

                if (FilePath != null && FilePath.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(FilePath.FileName);
                    var path = Path.Combine(HttpContext.Server.MapPath("~/Content/GeneralReports/LinkedFiles/"), fileName);
                    FilePath.SaveAs(path);
                    model.IncidentLinkedModel.FilePath = "/Content/GeneralReports/LinkedFiles/" + fileName;
                }
                else
                {
                    model.IncidentLinkedModel.FilePath = Convert.ToString(fc["hdnFilePath"]);
                }
                CIMS.BaseLayer.Subject.IncidentLinkedBase IncidentLinkedBase = new CIMS.BaseLayer.Subject.IncidentLinkedBase();
                IncidentLinkedBase.ID = model.IncidentLinkedModel.ID;
                IncidentLinkedBase.IncidentID = model.ReportID;
                IncidentLinkedBase.Description = model.IncidentLinkedModel.Description;
                IncidentLinkedBase.FilePath = model.IncidentLinkedModel.FilePath;
                actionResult = reportsAction.GeneralReportLinked_IU(IncidentLinkedBase);
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
            return RedirectToAction("Index", new { Id = model.ReportID });
        }

        [HttpGet]
        public JsonResult GetGenReportsLinkById(int? Id = 0)
        {
            string json = "";

            List<IncidentLinkedModel> linkedListModel = new List<IncidentLinkedModel>();
            IncidentLinkedModel linkedModel = new IncidentLinkedModel();

            try
            {
                if (Id > 0)
                {
                    CIMS.BaseLayer.Subject.IncidentLinkedBase IncidentLinkedBase = new CIMS.BaseLayer.Subject.IncidentLinkedBase();
                    IncidentLinkedBase.ID = Convert.ToInt32(Id);
                    actionResult = reportsAction.GeneralReportLinked_LoadById(IncidentLinkedBase);
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

        #region Delete General Reports Linked
        [HttpPost]
        public JsonResult DeleteGenReportsLinked(int? Id = 0)
        {
            string json = string.Empty;
            try
            {
                CIMS.BaseLayer.Subject.IncidentLinkedBase IncidentLinkedBase = new CIMS.BaseLayer.Subject.IncidentLinkedBase();
                IncidentLinkedBase.ID = Convert.ToInt32(Id);
                actionResult = reportsAction.GeneralReportLinked_DeleteById(IncidentLinkedBase);
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
        public ActionResult IncidentGeneralReports(GeneralReportsModel model)
        {
            try
            {
                CIMS.BaseLayer.Subject.ReportBase Report = new CIMS.BaseLayer.Subject.ReportBase();

                Report.IncidentID = model.ReportID;
                Report.ReportDate = model.ReportModel.ReportDate;
                Report.UserID = model.ReportModel.UserID;
                Report.Description = model.ReportModel.Description;
                actionResult = reportsAction.IncidentGeneralReports_IU(Report);
                if (actionResult.dtResult.Rows.Count > 0)
                {
                    TempData["SuccessMessage"] = "Report has been Saved Successfully";
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
            return RedirectToAction("Index", new { Id = model.ReportID });
        }

        //#region General Reports Access Permission
        //[HttpPost]
        //public JsonResult GenReportsAccessPermission(int RepId, int UserId, int Id, string View, string Edit, string Delete)
        //{
        //    GeneralReportsBase reportsBase = new GeneralReportsBase();

        //    string json = string.Empty;
        //    try
        //    {
        //        reportsBase.RepPerID = Id;
        //        reportsBase.ReportID = RepId;
        //        reportsBase.ReportAccessBy = UserId;
        //        reportsBase.ReportView = Convert.ToBoolean(View);
        //        reportsBase.ReportEdit = Convert.ToBoolean(Edit);
        //        reportsBase.ReportDelete = Convert.ToBoolean(Delete);
        //        reportsBase.CreatedBy = Convert.ToInt32(Session["UserId"]);
        //        actionResult = reportsAction.GenReportsAccessPermission_AddEdit(reportsBase);
        //        if (actionResult.IsSuccess)
        //        {
        //            json = "success";
        //        }
        //        else
        //        {
        //            json = "fail";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        json = "-1";
        //        ErrorReporting.WebApplicationError(ex);
        //    }
        //    return Json(json, JsonRequestBehavior.AllowGet);
        //}
        //#endregion

        #region ReportPermissionCheck Get
        public JsonResult ReportPermissionCheck(int RepID)
        {
            GeneralReportsBase generalReportsBase = new GeneralReportsBase();
            GeneralReportsModel generalReportsModel = new GeneralReportsModel();

            List<GeneralReportsModel> generalReportList = new List<GeneralReportsModel>();

            string jsonString = string.Empty;
            try
            {
                generalReportsBase.ReportID = RepID;
                generalReportsBase.ReportAccessBy = Convert.ToInt32(Session["UserId"]);
                generalReportsBase.ReportAccessRole = Convert.ToInt32(Session["RoleId"]);

                actionResult = reportsAction.GenReportPermissionCheck_User(generalReportsBase);

                if (actionResult.IsSuccess)
                {
                    //generalReportList = CommonMethods.ConvertTo<GeneralReportsModel>(actionResult.dtResult);

                    if (actionResult.dtResult.Rows.Count > 0)
                    {
                        //generalReportsModel = generalReportList.FirstOrDefault();
                        generalReportsModel = new GeneralReportsModel();
                        generalReportsModel.ReportView = (int)actionResult.dtResult.Rows[0]["ReportView"] > 0 ? true: false;
                        generalReportsModel.ReportEdit = (int)actionResult.dtResult.Rows[0]["ReportEdit"] > 0 ? true : false;
                        generalReportsModel.ReportDelete = (int)actionResult.dtResult.Rows[0]["ReportDelete"] > 0 ? true : false;
                    }
                    //if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                    //{
                    //    jsonString += actionResult.dtResult.Rows[0]["ReportView"] != DBNull.Value ? actionResult.dtResult.Rows[0]["ReportView"].ToString() : "false";
                    //    jsonString += ",";
                    //    jsonString += actionResult.dtResult.Rows[0]["ReportEdit"] != DBNull.Value ? actionResult.dtResult.Rows[0]["ReportEdit"].ToString() : "false";
                    //    jsonString += ",";
                    //    jsonString += actionResult.dtResult.Rows[0]["ReportDelete"] != DBNull.Value ? actionResult.dtResult.Rows[0]["ReportDelete"].ToString() : "false";
                    //}
                    jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(generalReportsModel);
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
        [ValidateInput(false)]
        public ActionResult GeneralReportsBanned(GeneralReportsModel model, FormCollection fc)
        {
            try
            {
                var data = fc["Count"];
                int TotalCount = Convert.ToInt32(data);

                DataTable dt = new DataTable();

                dt.Columns.Add("BanName");

                for (int i = 0; i <= TotalCount; i++)
                {
                    var bantype = fc["BanTypeList[" + i + "].TypeOfBan"];
                    if (bantype == "on")
                    {
                        DataRow row;
                        row = dt.NewRow();

                        row["BanName"] = fc["BanTypeList[" + i + "].__Text"];
                        dt.Rows.Add(row);
                    }

                }

                CIMS.BaseLayer.Subject.BanTypeBase BanTypeBase = new CIMS.BaseLayer.Subject.BanTypeBase();
                BanTypeBase.BanTypeTable = dt;
                BanTypeBase.IncidentID = model.ReportID;

                actionResult = reportsAction.GeneralReportsBanType_I(BanTypeBase);
                if (actionResult.IsSuccess)
                {

                }
                CIMS.BaseLayer.Subject.BannedBase BannedBase = new CIMS.BaseLayer.Subject.BannedBase();

                BannedBase.IncidentID = model.ReportID;
                BannedBase.StartDate = model.BannedModel.StartDate;
                BannedBase.EndDate = model.BannedModel.EndDate;
                BannedBase.Currentdate = model.BannedModel.EntryDate;
                BannedBase.Day = model.BannedModel.BanDays;
                BannedBase.month = model.BannedModel.BanMonths;
                BannedBase.year = model.BannedModel.BanYears;
                BannedBase.Description = model.BannedModel.Description;
                BannedBase.AuthorizedBy = model.BannedModel.AuthorizedBy;


                actionResult = reportsAction.GeneralReportBanned_IU(BannedBase);
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
            return RedirectToAction("Index", new { Id = model.ReportID});
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult GeneralReportsServices(GeneralReportsModel model)
        {
            try
            {
                CIMS.BaseLayer.Subject.ServiceBase Service = new CIMS.BaseLayer.Subject.ServiceBase();
                Service.IncidentID = model.ReportID;
                Service.ArriveTime = model.ServiceModel.ArriveTime;
                Service.CallTime = model.ServiceModel.CallTime;
                Service.Description = model.ServiceModel.Description;
                Service.ServiceBy = model.ServiceModel.ServiceBy;
                Service.ServiceFor = model.ServiceModel.ServiceFor;
                actionResult = reportsAction.GenReportServices_IU(Service);
                if (actionResult.dtResult.Rows.Count > 0)
                {
                    TempData["SuccessMessage"] = "Service has been Saved Successfully";
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
            return RedirectToAction("Index", new { Id = model.ReportID });
        }

        #region SaveServiceOffered

        public JsonResult SaveServiceOffered(int ReportID, bool Offered, bool Declined, string ServiceName)
        {
            string json = string.Empty;
            try
            {

                CIMS.BaseLayer.Subject.ServiceBase Service = new CIMS.BaseLayer.Subject.ServiceBase();

                Service.IncidentID = ReportID;
                Service.Offered = Offered;
                Service.DeclinedAvailable = Declined;
                Service.ServiceName = ServiceName;
                actionResult = reportsAction.GenReportServicesOffered_I(Service);
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

        public JsonResult AdAsInvolved(string datacolumn, string IncidentID)
        {
            string json = string.Empty;
            var InvolvedId = datacolumn.Split(',');

            foreach (var item in InvolvedId)
            {
                if (item != null && item != string.Empty)
                {
                    GeneralReportsBase generalReportsBase = new GeneralReportsBase();
                    generalReportsBase.ReportID = Convert.ToInt32(IncidentID);
                    generalReportsBase.InvolvedID = Convert.ToInt32(item);
                    generalReportsBase.IsEmployee = false;
                    actionResult = reportsAction.GeneralReportInvolve_I(generalReportsBase);
                }
            }
            if (actionResult.IsSuccess)
            {
                TempData["SuccessMessage"] = "General Reprot has been Saved Successfully";
            }
            else
            {
                TempData["ErrorMessage"] = "Error in Saving record";
            }
            return Json(json, JsonRequestBehavior.AllowGet);

        }


        public JsonResult AddEmployeeInvolvedbutton(string datacolumn, string IncidentID)
        {
            string json = string.Empty;
            var InvolvedId = datacolumn.Split(',');

            foreach (var item in InvolvedId)
            {
                if (item != null && item != string.Empty)
                {
                    GeneralReportsBase generalReportsBase = new GeneralReportsBase();
                    generalReportsBase.ReportID = Convert.ToInt32(IncidentID);
                    generalReportsBase.InvolvedID = Convert.ToInt32(item);
                    generalReportsBase.IsEmployee = true;
                    actionResult = reportsAction.GeneralReportInvolve_I(generalReportsBase);
                }
            }
            if (actionResult.IsSuccess)
            {
                TempData["SuccessMessage"] = "General Reprot has been Saved Successfully";
            }
            else
            {
                TempData["ErrorMessage"] = "Error in Saving record";
            }
            return Json(json, JsonRequestBehavior.AllowGet);

        }


        #region Bind Users List Reports for Access
        public JsonResult UsersListReportsAccess(int ReportID)
        {
            string jsonString = string.Empty;
            try
            {
                GeneralReportsBase generalReportsBase = new GeneralReportsBase();
                generalReportsBase.UserID = Convert.ToInt32(Session["UserID"]);
                generalReportsBase.ReportID = ReportID;
                actionResult = reportsAction.UsersSubReportsAccess_Bind(generalReportsBase);
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
        public JsonResult AddUsersReportsAccess(string UserID, int ReportID)
        {
            string json = string.Empty;
            try
            {
                json = AddUsersReport(UserID, ReportID);
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
                GeneralReportsBase generalReportsBase = new GeneralReportsBase();
                generalReportsBase.ReportID = ReportID;
                generalReportsBase.CreatedBy = Convert.ToInt32(Session["UserID"]);
                actionResult = reportsAction.AddAll_UsersAndRoles_SubReportsAccess(generalReportsBase);
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
                return false;
            }
            return actionResult.IsSuccess;
        }

        public string AddUsersReport(string UserID,  int ReportID)
        {
            string json = string.Empty;

            if (UserID.Length > 0)
            {
                string[] UserIDList = UserID.Split(',');
                for (int i = 0; i <= UserIDList.Length - 1; i++)
                {
                    GeneralReportsBase generalReportsBase = new GeneralReportsBase();

                    generalReportsBase.ReportAccessBy = Convert.ToInt32(UserIDList[i]);
                    generalReportsBase.ReportID = ReportID;
                    generalReportsBase.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    actionResult = reportsAction.AddUsersSubReportsAccess(generalReportsBase);
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
                        GeneralReportsBase generalReportsBase = new GeneralReportsBase();
                        generalReportsBase.ReportAccessID = Convert.ToInt32(IDList[i]);
                        actionResult = reportsAction.RemoveUsersSubReportsAccess(generalReportsBase);
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
                GeneralReportsBase generalReportsBase = new GeneralReportsBase();
                generalReportsBase.UserID = Convert.ToInt32(Session["UserID"]);
                generalReportsBase.ReportID = ReportID;
                actionResult = reportsAction.SubReportsAccessUsers_Bind(generalReportsBase);
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
                    GeneralReportsBase generalReportsBase = new GeneralReportsBase();
                    generalReportsBase.ReportAccessID = Convert.ToInt32(ID);
                    generalReportsBase.ReportID = ReportID;
                    generalReportsBase.ReportAccessType = Type;
                    generalReportsBase.ReportAccessPermission = Convert.ToBoolean(Permission);
                    actionResult = reportsAction.SubReportAccessPermission(generalReportsBase);
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
                GeneralReportsBase generalReportsBase = new GeneralReportsBase();
                generalReportsBase.ReportAccessID = ID;
                generalReportsBase.ReportID = ReportID;
                actionResult = reportsAction.SubReportsAccessPermission_ByUser(generalReportsBase);
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
                GeneralReportsBase generalReportsBase = new GeneralReportsBase();
                generalReportsBase.ReportID = ReportID;
                actionResult = reportsAction.UsersSubReportsAccessRole(generalReportsBase);
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
                        GeneralReportsBase generalReportsBase = new GeneralReportsBase();

                        generalReportsBase.ReportAccessRole = Convert.ToInt32(RoleIDList[i]);
                        generalReportsBase.ReportID = Convert.ToInt32(ReportID);
                        generalReportsBase.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        actionResult = reportsAction.AddRolesSubReportsAccess(generalReportsBase);
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
                        GeneralReportsBase generalReportsBase = new GeneralReportsBase();
                        generalReportsBase.ReportAccessID = Convert.ToInt32(RoleIDList[i]);
                        actionResult = reportsAction.RemoveRolesSubReportsAccess(generalReportsBase);
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
                GeneralReportsBase generalReportsBase = new GeneralReportsBase();
                generalReportsBase.UserID = Convert.ToInt32(Session["UserID"]);
                generalReportsBase.ReportID = ReportID;
                actionResult = reportsAction.SubReportsAccessRoles_Bind(generalReportsBase);
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
                    GeneralReportsBase generalReportsBase = new GeneralReportsBase();
                    generalReportsBase.ReportAccessID = Convert.ToInt32(ID);
                    generalReportsBase.ReportID = ReportID;
                    generalReportsBase.ReportAccessType = Type;
                    generalReportsBase.ReportAccessPermission = Convert.ToBoolean(Permission);
                    actionResult = reportsAction.SubReportAccessPermissionByRole(generalReportsBase);
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
                GeneralReportsBase generalReportsBase = new GeneralReportsBase();
                generalReportsBase.ReportAccessID = ID;
                generalReportsBase.ReportID = ReportID;
                actionResult = reportsAction.SubReportsAccessPermission_ByRole(generalReportsBase);
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
        public ActionResult LinkEvents(GeneralReportEvents objs)
        {
            if (ModelState.IsValid)
            {
                //var customerid = repo.GetCurrentUserCustomerId(_webSecurity.CurrentUserId());
                //repo.ADDAdGroups(customerid, objs);
                actionResult = reportsAction.GeneralReportEventsLink_Delete(objs.reportid);
                if (objs.listeventid != null)
                {
                    foreach (var item in objs.listeventid)
                    {
                        if (item != 0)
                        {
                            eventgeneralreport objreport = new eventgeneralreport();
                            objreport.eventid = item;
                            objreport.reportid = objs.reportid;
                            actionResult = EventAction.Link_GeneralReport(objreport);
                        }
                    }
                }
                if (actionResult.IsSuccess)
                {
                    return Json("Events updated successfully.");
                }

                return Json("Error occurred while linking events.");

            }
            else
            {
                return Json("Error occurred while linking events.");
            }
        }

        public PartialViewResult EventListLink(int ReportID)
        {
            EventModel EventModel = new EventModel();
            List<EventModel> lstEventModel = new List<Models.EventModel>();
            EventBase model = new EventBase();
            model.UserID = Convert.ToString(Session["UserID"]);
            model.RoleID = Convert.ToInt32(Session["RoleId"]);
            model.ReportID = ReportID;

            actionResult = EventAction.EventGeneralReportsLink_Load(model);

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