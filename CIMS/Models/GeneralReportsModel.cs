using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CIMS.Models
{
    public class GeneralReportsModel
    {
        public int ReportID { get; set; }
        public string ReportNumber { get; set; }
        public string NatureOfEvent { get; set; }
        public string ShortDescriptor { get; set; }
        public string ShortDescriptorName { get; set; }
        public bool ActiveStatus { get; set; }
        public string Status { get; set; }
        public string StatusName { get; set; }
        public DateTime? IncidentDate { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string IncidentRole { get; set; }
        public bool Protected { get; set; }
        public string OccurrenceNumber { get; set; }
        public string IPVRDescription { get; set; }
        public string IncidentTime { get; set; }
        public string RoleName { get; set; }
        public string UD51 { get; set; }
        public string UD52 { get; set; }
        public string UD53 { get; set; }
        public int EventID { get; set; }
        public string Part { get; set; }
        public int CreatedBy { get; set; }
        public int ReportAccessBy { get; set; }
        public bool ReportView { get; set; }
        public bool ReportDelete { get; set; }
        public bool ReportEdit { get; set; }
        public int RepPerID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CheckPermissionID { get; set; }
        public string DefaultImage { get; set; }
        public string ReportCreatorFirstName { get; set; }
        public string ReportCreatorLastName { get; set; }
        public string ReportCreateDate { get; set; }
        public bool isLinkedEvent { get; set; }

        public List<SelectListItem> LocationList = new List<SelectListItem>();
        public List<GeneralReportsModel> ListGeneralReports { get; set; }

        public List<LCTPitTransactionsModel> LCTPitTransactionsModelList { get; set; }
        public LCTPitTransactionsModel LCTPitTransactionsModel { get; set; }

        public List<SelectListItem> GameList = new List<SelectListItem>();
        
        public List<LCTForeignExchangeModel> LCTForeignExchangeModelList { get; set; }
        public LCTForeignExchangeModel LCTForeignExchangeModel { get; set; }

        public List<LCTCashOutsModel> LCTCashOutsModelList { get; set; }
        public LCTCashOutsModel LCTCashOutsModel { get; set; }

        public List<LCTCashCallModel> LCTCashCallModelList { get; set; }
        public LCTCashCallModel LCTCashCallModel { get; set; }

        public List<SelectListItem> CashierNameList = new List<SelectListItem>();

        public List<VehiclesModel> VehiclesModelList { get; set; }
        public VehiclesModel VehiclesModel { get; set; }

        public List<SelectListItem> ColorList = new List<SelectListItem>();

        public SubjectInvolvedModel SubjectInvolvedModel { get; set; }
        public List<SubjectInvolvedModel> SubjectInvolvedModelList { get; set; }

        public BannedModel BannedModel { get; set; }

        public List<SelectListItem> AuthorizedByList = new List<SelectListItem>();
        public List<SelectListItem> BanOfTypeList = new List<SelectListItem>();
        public DisputeModel DisputeModel { get; set; }
        public List<DisputeModel> DisputeModelList { get; set; }

        public List<SelectListItem> DisputTypeList = new List<SelectListItem>();
        public List<SelectListItem> ResolutionList = new List<SelectListItem>();

        public ServiceModel ServiceModel { get; set; }
        public List<ServiceModel> ServiceModelList { get; set; }
        public List<ServiceModel> ServiceSubjectModelList { get; set; }

        public IncidentLinkedModel IncidentLinkedModel { get; set; }
        public List<IncidentLinkedModel> IncidentLinkedModelList { get; set; }

        public ReportModel ReportModel { get; set; }

        public List<SelectListItem> AuthorNameList = new List<SelectListItem>();

        public List<GeneralReportsModel> GeneralReportsList { get; set; }
    }
    public class GeneralReportPermissionModel
    {
        public int ReportID { get; set; }
        public int CreatedBy { get; set; }
        public string ReportCreatorUser { get; set; }
        public string ReportCreatorFirstName { get; set; }
        public string ReportCreatorLastName { get; set; }
        public string ReportCreateDate { get; set; }
        public bool ReportCreatorView { get; set; }
        public bool ReportCreatorEdit { get; set; }
        public bool ReportCreatorDelete { get; set; }
        public string LogoFirstName { get; set; }
        public string LogoMiddleName { get; set; }
        public string LogoLastName { get; set; }
    }
}