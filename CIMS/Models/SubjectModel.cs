using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CIMS.Models
{
    public class SubjectModel
    {
        public int SubjectID { get; set; }

        //  [Required]
        [Display(Name = "Subject identification number ")]
        public string VIP { get; set; }
        [Display(Name = "Subject number ")]
        public string SubjectNumber { get; set; }
        public decimal Age { get; set; }
        public string Sex { get; set; }
        public string Race { get; set; }


        // [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        // [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }

        [Display(Name = "Date Of Birth")]
        public string DateOfBirth { get; set; }

        [Display(Name = "Hair Color")]
        public string HairColor { get; set; }
        public string Eyes { get; set; }
        public string Complexion { get; set; }
        public string Build { get; set; }

        [Display(Name = "Facial Hair")]
        public string FacialHair { get; set; }

        public string SubjectStatus { get; set; }

        [Display(Name = "Hair Length")]
        public string HairLength { get; set; }
        public bool Glasses { get; set; }
        public bool Restricted { get; set; }
        public string Status { get; set; }

        [Display(Name = "Role Name")]
        public string RoleName { get; set; }

        [Display(Name = "CID Subject")]
        public bool CIDSubject { get; set; }
        public int CIDPersonID { get; set; }
        public string ModifiedDate { get; set; }


        /// ///////////// search

        [Display(Name = "Incident Date")]
        public string IncidentDate { get; set; }

        [Display(Name = "Nature Of incident")]
        public string NatureOfincident { get; set; }

        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [Display(Name = "Overall Status")]
        public string OverallStatus { get; set; }


        ///////////// Media

        public string FilePath { get; set; }

        //Dashboard
        public int CreatedBy { get; set; }
        public string CreatedByUser { get; set; }
        public string TotalSubjects { get; set; }

        public List<SubjectModel> SubjectModelList = new List<Models.SubjectModel>();

        public List<SubjectModel> SubjectList = new List<SubjectModel>();
        public string AgeRange { get; set; }
        public bool EditPermission { get; set; }
        public bool DeletePermission { get; set; }

    }

    public class SubjectAddressModel
    {
        public int AddressID { get; set; }
        public int SubjectID { get; set; }
        public int CreatedBy { get; set; }
        public int IncidentID { get; set; }
        public string Apartment { get; set; }
        public bool EditPermission { get; set; }
        public bool DeletePermission { get; set; }
        //  [Required]
        public string Address { get; set; }

        [Display(Name = "Country")]
        public int CountryID { get; set; }
        public string City { get; set; }

        [Display(Name = "Province/State")]
        public string ProvState { get; set; }

        [Display(Name = "Postal/ZIP code")]
        public string PostalZip { get; set; }

        //  [Required]
        [Display(Name = "Address Type")]
        public string AddressType { get; set; }
        public string AddressTypeName { get; set; }

        public string ModifiedDate { get; set; }

        public string LogoFirstName { get; set; }
        public string LogoMiddleName { get; set; }
        public string LogoLastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string FilePath { get; set; }

        public string VIP { get; set; }
    }

    public class ManageWatchListModel
    {
        public SubjectWatchListModel subwatchlistModel { get; set; }
        public List<SubjectWatchListModel> subsubwatchlist { get; set; }
    }

    public class ManageSubjectAddressModel
    {
        public SubjectAddressModel subAddressModel { get; set; }
        public List<SubjectAddressModel> subAddressList { get; set; }

        public EmployeeModel EmployeeModel { get; set; }

    }
    public class SubjectAliasModel
    {
        public int AliasID { get; set; }
        public int SubjectID { get; set; }
        public string DateEntered { get; set; }

        //  [Required]
        [Display(Name = "Name Type")]
        public string NameType { get; set; }
        public string ANameType { get; set; }

        //  [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        //  [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string LogoFirstName { get; set; }
        public string LogoMiddleName { get; set; }
        public string LogoLastName { get; set; }
        
        public string FilePath { get; set; }

        public string VIP { get; set; }

        public string ModifiedDate { get; set; }
        public int CreatedBy { get; set; }
        public bool EditPermission { get; set; }
        public bool DeletePermission { get; set; }
    }

    public class ManageSubjectAliasModel
    {
        public SubjectAliasModel subAliasModel { get; set; }
        public List<SubjectAliasModel> subAliasList { get; set; }
    }

    public class SubjectMarkModel
    {
        public int MarkID { get; set; }
        public int SubjectID { get; set; }
        public int CreatedBy { get; set; }
        public int FeatureID { get; set; }
        public int FLocationID { get; set; }

        [Display(Name = "Feature Type")]
        public string FeatureType { get; set; }

        [Display(Name = "Feature Location")]
        public string FeatureLocation { get; set; }
        public string Description { get; set; }
        public int MediaID { get; set; }
        public string ImagePath { get; set; }

        public string LogoFirstName { get; set; }
        public string LogoMiddleName { get; set; }
        public string LogoLastName { get; set; }

        public string FilePath { get; set; }

        public string VIP { get; set; }

        public string ModifiedDate { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public bool EditPermission { get; set; }
        public bool DeletePermission { get; set; }

        public string SubjectStatus { get; set; }
    }

    public class ManageSubjectMarkModel
    {
        public SubjectMarkModel subFeatureModel { get; set; }
        public List<SubjectMarkModel> subFeatureList { get; set; }
    }

    public class SubjectIdentificationModel
    {
        public int Idss { get; set; }
        public int SubjectID { get; set; }
        public int CreatedBy { get; set; }
        [Display(Name = "Occupation")]
        // [Required]
        public string Occupation { get; set; }

        [Display(Name = "Business Name")]
        // [Required]
        public string BusinessName { get; set; }
        public string IDType1 { get; set; }
        public string IDNumber1 { get; set; }
        public string IDDefault1 { get; set; }
        public string IDType2 { get; set; }
        public string IDNumber2 { get; set; }
        public string IDDefault2 { get; set; }
        public string IDType3 { get; set; }
        public string IDNumber3 { get; set; }
        public string IDDefault3 { get; set; }
        // [Required]
        public string LCTID { get; set; }

        public string LogoFirstName { get; set; }
        public string LogoMiddleName { get; set; }
        public string LogoLastName { get; set; }
        public bool EditPermission { get; set; }
        public bool DeletePermission { get; set; }

        public List<SelectListItem> lstIdentification1 { get; set; }
        public List<SelectListItem> lstIdentification2 { get; set; }
        public List<SelectListItem> lstIdentification3 { get; set; }
    }
    public class IdentificationType
    {
        public int ID { get; set; }
        public string Value { get; set; }
    }
    public class SubjectWatchListModel
    {
        public int ID { get; set; }
        public int SubjectID { get; set; }
        public string WatchName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string FilePath { get; set; }

        public string VIP { get; set; }
        public string ModifiedDate { get; set; }

    }

    public class SubjectLinkedModel
    {
        public int ID { get; set; }
        public int SubjectID { get; set; }
        public int CreatedBy { get; set; }
        public int IncidentID { get; set; }

        [Display(Name = "File Description")]
        public string Description { get; set; }

        //   [Required]
        [Display(Name = "File Path")]
        public string FilePath { get; set; }

        public string LogoFirstName { get; set; }
        public string LogoMiddleName { get; set; }
        public string LogoLastName { get; set; }
        public bool EditPermission { get; set; }
        public bool DeletePermission { get; set; }
    }

    public class ManageSubjectLinkedModel
    {
        public SubjectLinkedModel subLinkedModel { get; set; }
        public List<SubjectLinkedModel> subLinkedList { get; set; }
    }

    public class WatchModel
    {
        public int WatchID { get; set; }

        [Display(Name = "Watch Name")]
        public string WatchName { get; set; }

    }
    public class SubjectPermissionModel
    {
        public int SubjectID { get; set; }
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
        public class SubjectIncidentsModel
    {
        public int SubjectIncidentID { get; set; }
        public int IncidentID { get; set; }
        public int SubjectID { get; set; }
        public string IncidentNumber { get; set; }
        public string NatureOfEvent { get; set; }
        //  [Required(ErrorMessage = "Short Description is required")]
        public string ShortDescription { get; set; }
        public string ShortDescriptionName { get; set; }
        public bool ActiveStatus { get; set; }
        public string Status { get; set; }
        public string StatusName { get; set; }
        //   [Required(ErrorMessage = "Incident Date is required")]
        public string IncidentDate { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public string Location { get; set; }
        public string IncidentRole { get; set; }
        public bool Protected { get; set; }
        public string OccurrenceNumber { get; set; }
        public string IPVRDescription { get; set; }
        public string IncidentTime { get; set; }
        public string EndDate { get; set; }
        public string EndTime { get; set; }
        public string RoleName { get; set; }
        public string UD26 { get; set; }
        public string UD32 { get; set; }
        public string UD33 { get; set; }
        public int EventID { get; set; }
        public int CreatedBy { get; set; }
        public int ReportAccessBy { get; set; }
        public bool ReportView { get; set; }
        public bool ReportDelete { get; set; }
        public bool ReportEdit { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public int UserID { get; set; }
        public int RepPerID { get; set; }
        public int CheckPermissionID { get; set; }
        public bool ViewPermission { get; set; }
        public bool EditPermission { get; set; }
        public bool DeletePermission { get; set; }

        public string LogoFirstName { get; set; }
        public string LogoMiddleName { get; set; }
        public string LogoLastName { get; set; }
        public string DefaultImage { get; set; }
        public bool LinkWithReport { get; set; }
        public int LinkByEmpID { get; set; }
        public string LinkEmployeeName { get; set; }
        public string LinkFile { get; set; }
        public int ProofreadID { get; set; }
        public string ProofreadByFirstName { get; set; }
        public string ProofreadByLastName { get; set; }
        public string ProofreadByUserName { get; set; }
        public string DateProofread { get; set; }
        public bool ReportProofread { get; set; }
        public string ReportCreatorUser { get; set; }
        public string ReportCreatorFirstName { get; set; }
        public string ReportCreatorLastName { get; set; }
        public string ReportCreateDate { get; set; }

        public List<SubjectIncidentProofRead> SubjectIncidentProofReadList { get; set; }

        public bool ReportCreatorView { get; set; }
        public bool ReportCreatorEdit { get; set; }
        public bool ReportCreatorDelete { get; set; }
        public bool isLinkedEvent { get; set; }
        public DisputeModel DisputeModel { get; set; }
        public ReportModel ReportModel { get; set; }
        public IncidentLinkedModel IncidentLinkedModel { get; set; }
        public VehiclesModel VehiclesModel { get; set; }
        public LCTCashCallModel LCTCashCallModel { get; set; }
        public LCTPitTransactionsModel LCTPitTransactionsModel { get; set; }
        public LCTCashOutsModel LCTCashOutsModel { get; set; }
        public LCTForeignExchangeModel LCTForeignExchangeModel { get; set; }
        public List<LCTCashCallModel> LCTCashCallModelList { get; set; }
        public List<IncidentLinkedModel> IncidentLinkedModelList { get; set; }
        public List<LCTCashOutsModel> LCTCashOutsModelList { get; set; }
        public List<LCTForeignExchangeModel> LCTForeignExchangeModelList { get; set; }
        public List<LCTForeignExchangeModel> lstForeignRatesModel { get; set; }

        public List<LCTPitTransactionsModel> LCTPitTransactionsModelList { get; set; }
        public List<SubjectIncidentsModel> SubjectIncidentList { get; set; }

        public List<SubjectIncidentsModel> SubjectOfferedIncidentList { get; set; }
        public List<VehiclesModel> VehiclesModelList { get; set; }

        public List<SelectListItem> ResolutionList = new List<SelectListItem>();
        public List<SelectListItem> DisputTypeList = new List<SelectListItem>();
        public List<SelectListItem> AuthorNameList = new List<SelectListItem>();
        public List<SelectListItem> LocationList = new List<SelectListItem>();
        public List<SelectListItem> IncidentRoleList = new List<SelectListItem>();
        public List<SelectListItem> AuthorizedByList = new List<SelectListItem>();
        public List<SelectListItem> BanOfTypeList = new List<SelectListItem>();
        public List<SelectListItem> GameList = new List<SelectListItem>();
        public List<SelectListItem> BuyInTypePitList = new List<SelectListItem>();
        public List<SelectListItem> CashierNameList = new List<SelectListItem>();
        public List<SelectListItem> ColorList = new List<SelectListItem>();
        public List<ReportModel> ReportModelList { get; set; }
        public SubjectInvolvedModel SubjectInvolvedModel { get; set; }
        public List<SubjectInvolvedModel> SubjectInvolvedModelList { get; set; }

        public ServiceModel ServiceModel { get; set; }
        public List<ServiceModel> ServiceModelList { get; set; }
        public List<ServiceModel> ServiceSubjectModelList { get; set; }

        public BannedModel BannedModel { get; set; }
        public List<BannedModel> BannedModelList { get; set; }
        public LCTIdentificationModel LCTIdentificationModel { get; set; }

    }

    public class LCTCashCallModel
    {
        public int ID { get; set; }
        public int IncidentID { get; set; }
        public int SubjectID { get; set; }
        public string CashCallTime { get; set; }
        public string Cashier { get; set; }
        public string CashierName { get; set; }

        //  [Required(ErrorMessage = "Amount is required")]
        public decimal Amount { get; set; }
    }

    public class LCTCashOutsModel
    {
        public int ID { get; set; }
        public int IncidentID { get; set; }
        public int SubjectID { get; set; }

        //  [Required(ErrorMessage = "Amount is required")]
        public decimal Amount { get; set; }
        public string TypeOfWin { get; set; }
        public string PaymentType { get; set; }
        public string ChequeNo { get; set; }
        public string CashOutTime { get; set; }
        public string TableNumber { get; set; }
    }

    public class LCTForeignExchangeModel
    {
        public int ID { get; set; }
        public int IncidentID { get; set; }
        public int SubjectID { get; set; }
        public string ForeignCountry { get; set; }
        public string ForeignCountryName { get; set; }

        //   [Required(ErrorMessage = "Amount is required")]
        public decimal Amount { get; set; }
        public decimal ForeignAmount { get; set; }
        public decimal Rate { get; set; }
    }

    public class LCTPitTransactionsModel
    {
        public int ID { get; set; }
        public int IncidentID { get; set; }
        public int SubjectID { get; set; }
        public string Pit { get; set; }
        public string Game { get; set; }
        public string GameName { get; set; }
        public int BuyInTypePitID { get; set; }
        public int BuyInGameID { get; set; }
        public string BuyInPitType { get; set; }
        //   [Required(ErrorMessage = "Amount is required")]
        public decimal Amount { get; set; }
        public string BuyInType { get; set; }
        public string BuyInTime { get; set; }
    }
    public class VehiclesModel
    {
        public int VehicleID { get; set; }
        public int IncidentID { get; set; }
        public int SubjectID { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleYear { get; set; }
        public string LicensePlate { get; set; }
        public string IssuedIn { get; set; }
        public string VehicleColor { get; set; }

        public string VehicleVIN { get; set; }
        public string Picture { get; set; }
        public string ImagePath { get; set; }
    }
    public class IncidentLinkedModel
    {
        public int ID { get; set; }
        public int IncidentID { get; set; }
        public int SubjectID { get; set; }

        public string FilePath { get; set; }
        public string Description { get; set; }

    }

    public class ReportModel
    {
        public int ID { get; set; }
        public int IncidentID { get; set; }
        public int SubjectID { get; set; }

        public string ReportDate { get; set; }
        public string UserID { get; set; }

        public string Description { get; set; }
    }

    public class SubjectInvolvedModel
    {
        public int SubjectIncidentID { get; set; }
        public int IncidentID { get; set; }
        public int EmployeeID { get; set; }
        public int SubjectID { get; set; }
        public int InvolvedID { get; set; }
        public int MediaID { get; set; }
        public int RoleID { get; set; }
        public string InvolvedRole { get; set; }
        public bool IsEmployee { get; set; }
        // [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        //  [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        public string Sex { get; set; }
        public string Race { get; set; }
        public string ShortDescription { get; set; }
        public string Status { get; set; }

        public List<SubjectInvolvedModel> ShortDescriptionList { get; set; }
        public List<SelectListItem> ShortDescriptList = new List<SelectListItem>();
    }

    public class ServiceModel
    {
        public int IncidentID { get; set; }
        public int SubjectID { get; set; }
        public int ServiceID { get; set; }

        public string CallTime { get; set; }

        public string ServiceName { get; set; }

        public string Offered { get; set; }
        public string DeclinedAvailable { get; set; }

        //public string CallTime { get; set; }
        public string ArriveTime { get; set; }

        public string ServiceBy { get; set; }
        public string ServiceFor { get; set; }
        public string Description { get; set; }
    }

    public class DisputeModel
    {
        public int IncidentID { get; set; }
        public int SubjectID { get; set; }
        public int DisputeID { get; set; }

        public string DisputeType { get; set; }

        public string Resolution { get; set; }

        public string Amount { get; set; }
        public bool RecoveredMoney { get; set; }


        public string Description { get; set; }
    }

    public class BannedModel
    {
        public int IncidentID { get; set; }
        public int SubjectID { get; set; }
        public int BannedID { get; set; }

        public string EntryDate { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }
        public int BanDays { get; set; }

        public int BanMonths { get; set; }

        public int BanYears { get; set; }
        public int BanTypeId { get; set; }
        public string AuthorizedBy { get; set; }
        public string BanOfTypeList { get; set; }
        public List<BanType> BanTypesubList = new List<BanType>();
        public List<BanType> BanTypeList = new List<BanType>();
        public List<SelectListItem> bantypelist = new List<SelectListItem>();
        public List<MSTBanType> MSTBanTypeList = new List<MSTBanType>();
        public MSTBanType MstBanType { get; set; }
        public BanType BanType { get; set; }
        public string Description { get; set; }
        public string TypeOfBan { get; set; }
    }

    public class BannedModelVM
    {
        public int IncidentID { get; set; }
        public int SubjectID { get; set; }
        public int BannedID { get; set; }
        public int BanTypeId { get; set; }
        public string EntryDate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int BanDays { get; set; }
        public int BanMonths { get; set; }
        public int BanYears { get; set; }
        public string AuthorizedBy { get; set; }
        public string Description { get; set; }
        public string TypeOfBan { get; set; }
    }

    public class BanType
    {
        public int BannedID { get; set; }
        public int IncidentID { get; set; }
        public int SubjectID { get; set; }
        public bool TypeOfBan { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }

    }
    public class MSTBanType
    {
        public string Text { get; set; }
        public string Value { get; set; }

    }
    public class SubjectIncidentProofRead
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ReportProofread { get; set; }
    }
    public class LCTIdentificationModel
    {
        public int SubjectID { get; set; }
        public int IncidentID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Apartment { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        [Display(Name = "Province/State")]
        public string ProvState { get; set; }

        [Display(Name = "Postal/ZIP code")]
        public string PostalZip { get; set; }

        [Display(Name = "Occupation")]
        public string Occupation { get; set; }

        [Display(Name = "Business Name")]
        public string BusinessName { get; set; }

        [Display(Name = "Date Of Birth")]
        public string DateOfBirth { get; set; }
        public string IDType1 { get; set; }
        public string IDNumber1 { get; set; }
        public string IDDefault1 { get; set; }
        public string IDType2 { get; set; }
        public string IDNumber2 { get; set; }
        public string IDDefault2 { get; set; }
        public string IDType3 { get; set; }
        public string IDNumber3 { get; set; }
        public string IDDefault3 { get; set; }
        public string LCTID { get; set; }
        public string LCTIDNumber { get; set; }
        public string TypeOfID { get; set; }
        public string IDNumber { get; set; }
        public string TransactionDate { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeTitle { get; set; }
        public string EmployeeGPEB { get; set; }
        public string CashierName { get; set; }
        public string CashierTitle { get; set; }
        public string CashierGPEB { get; set; }
        public string Notes { get; set; }
        public decimal TotalPit { get; set; }
        public decimal BuyInMarker { get; set; }
        public decimal TotalCashOut { get; set; }
        public decimal CashOutMarker { get; set; }
        public decimal TotalExchange { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public decimal IncidentNumber { get; set; }
        public decimal IncidentDate { get; set; }
        public string Amount { get; set; }
        public string TransactionType { get; set; }
        public decimal BuyInCash { get; set; }
        public decimal CashOutCash { get; set; }
        public decimal CashCall { get; set; }
        public decimal ForeignExchange { get; set; }
        public string JsonString { get; set; }

        public string LogoFirstName { get; set; }
        public string LogoMiddleName { get; set; }
        public string LogoLastName { get; set; }
        public bool EditPermission { get; set; }
        public bool DeletePermission { get; set; }
        public List<LCTIdentificationModel> LCTIdentificationList = new List<LCTIdentificationModel>();
    }

    public class imagesviewmodel
    {
        public string Url { get; set; }
    }
}