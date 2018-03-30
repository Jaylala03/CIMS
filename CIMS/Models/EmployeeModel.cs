using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CIMS.Models
{
    public class EmployeeModel
    {
        //[Required]
        [Display(Name = "Number")]
        public string EmpNumber { get; set; }
        public string EmployeeNumber { get; set; }
        public int UserID { get; set; }
        public decimal Age { get; set; }
        public string Sex { get; set; }
        public string Race { get; set; }
       // [Required]
        [Display(Name = "Last")]
        public string LastName { get; set; }
      //  [Required]
        [Display(Name = "First")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Height { get; set; }

     //   [Required]
        public DateTime? DateOfBirth { get; set; }
        public string Weight { get; set; }
        public string StaffPosition { get; set; }
        public string Eyes { get; set; }
        public string Complexion { get; set; }
        public string Build { get; set; }
        public string Glasses { get; set; }
        public bool Restricted { get; set; }
        public string Status { get; set; }
        public string RoleName { get; set; }
        public string UD9 { get; set; }

        public int AddressID { get; set; }
        public int IncidentID { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Apartment { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ProvState { get; set; }
        public string PostalZip { get; set; }
     //   [Required]
        [Display(Name = "Address Type")]
        public string AddressType { get; set; }
        public int EmployeeID { get; set; }

        public string Day { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public bool ConvertSubject { get; set; }
        public bool EditPermission { get; set; }
        public bool DeletePermission { get; set; }
        public int EmployeeInvolvedId { get; set; }
        public int InvolvedId { get; set; }
        public int RoleID { get; set; }

        public string LogoLastName { get; set; }
        public string LogoFirstName { get; set; }
        public string LogoMiddleName { get; set; }

        public List<EmployeeModel> EmployeeList = new List<Models.EmployeeModel>();
        public List<EmployeeLinkedList> EmployeeLinkedList { get; set; }

        public List<SelectListItem> DepartmentTypeList = new List<SelectListItem>();
        public List<SelectListItem> LicenseTypeList = new List<SelectListItem>();
        public List<SelectListItem> LicenseStatusList = new List<SelectListItem>();
        public List<SelectListItem> AddressTypeList = new List<SelectListItem>();

        public List<SelectListItem> EmployeeDepartmentList = new List<SelectListItem>();

        public List<SelectListItem> SubjectStatusList = new List<SelectListItem>();

        // license
        public string DateOfHire { get; set; }
        public string TerminationDate { get; set; }
        public string LicenseExpirationDate { get; set; }
        public string Department { get; set; }
        public string EmployeeDepartment { get; set; }
        public string SubjectStatus { get; set; }
        public string LicenseType { get; set; }
        public string LicenseStatus { get; set; }
        public string ReasonForLeaving { get; set; }
        public string UD16 { get; set; }
        public string UD17 { get; set; }
        public string UD18 { get; set; }
        public string UD19 { get; set; }
        public int LicenseID { get; set; }


        //personal
        public string UD10 { get; set; }
        public string UD11 { get; set; }
        public string UD12 { get; set; }
        public string UD13 { get; set; }
        public string UD14 { get; set; }
        public string UD15 { get; set; }
        public string IDType1 { get; set; }
        public string IDNumber1 { get; set; }
        public bool? IDDefault1 { get; set; }
        public string IDType2 { get; set; }
        public string IDNumber2 { get; set; }
        public bool? IDDefault2 { get; set; }
        public string IDType3 { get; set; }
        public string IDNumber3 { get; set; }
        public bool? IDDefault3 { get; set; }

        ///////////////////

        public string IncidentDate { get; set; }
        public string NatureOfincident { get; set; }
        public string ShortDescription { get; set; }
        public string OverallStatus { get; set; }

        //////////////////

        public string FilePath { get; set; }

        /// <summary>
        /// Dashboard 
        /// </summary>
        /// 
        //CreatedByUser
        public string CreatedByUser { get; set; }
        public string CreatedDate { get; set; }
        public string CreatorFirstName { get; set; }
        public string CreatorLastName { get; set; }
        public string TotalEmployees { get; set; }
        public EmployeeModel employeeNewModel { get; set; }
        public VisitorModel visitorNewModel { get; set; }
        public SubjectModel subjectNewModel { get; set; }



    }

    public class EmployeeLinkedList
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public string Description { get; set; }
    }
    public class EmployeeIncidentProofRead
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ReportProofread { get; set; }
    }
    public class EmployeeIncidentModel
    {
        public int EmployeeInvolvedId { get; set; }
        public int IncidentID { get; set; }
        public int EmployeeId { get; set; }
        public string IncidentNumber { get; set; }

        public string NatureOfIncident { get; set; }

       // [Required(ErrorMessage = "Short Description is required")]
        public string ShortDescription { get; set; }
        public string ShortDescriptionName { get; set; }

        //    [Required(ErrorMessage = "Incident Date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat( DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime IncidentDate { get; set; }

        public string StartTime { get; set; }
        public string EndTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat( DataFormatString = "{0:MM/dd/yyyy}")]
        public string StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat( DataFormatString = "{0:MM/dd/yyyy}")]
        public string EndDate { get; set; }

        public bool ActiveStatus { get; set; }

        public string Status { get; set; }

        public string Location { get; set; }

        public string IncidentRole { get; set; }

        [AllowHtml]
        public string Description { get; set; }

        public string UD27 { get; set; }

        public string UD34 { get; set; }


        public string UD35 { get; set; }

     //   [Required(ErrorMessage = "Notes is required")]
        [AllowHtml]
        public string Notes { get; set; }

     //   [Required(ErrorMessage = "IPVR Description is required")]
        [AllowHtml]
        public string IPVRDescription { get; set; }

        public List<EmployeeLinkedList> EmployeeLinkedList { get; set; }

        public string VarianceType { get; set; }

        public string Resolution { get; set; }

        public float Amount { get; set; }

        [AllowHtml]
        public string VarianceDescription { get; set; }

        public int AmountType { get; set; }

        public int InvolvedId { get; set; }

        public EmployeeModel EmployeeModel { get; set; }

        public List<EmployeeModel> EmployeeList = new List<Models.EmployeeModel>();
        public List<SelectListItem> DisplayNameList = new List<SelectListItem>();
        public List<SelectListItem> AuditTypeList = new List<SelectListItem>();
        public string Game { get; set; }

        public string ShuffleShoe { get; set; }

        public string TimeTaken { get; set; }

        public string DisplayName { get; set; }

        public string PaceStartTime { get; set; }
        public string PaceEndTime { get; set; }
        [AllowHtml]
        public string PaceDescription { get; set; }
        public int PaceAuditPositionsPlayed { get; set; }
        public int PaceAuditHandsPlayed { get; set; }
        public int PaceAuditHandsPerHour { get; set; }

        public List<EmployeeIncidentModel> EmployeeIncidentList { get; set; }

        public string AuditType { get; set; }
        public int Observation { get; set; }
        public int QuestionId { get; set; }
        public string AuditScore { get; set; }
        public string AuditComment { get; set; }
        public int AuditID { get; set; }
        public string AnswerOrScore { get; set; }
        public string Comment { get; set; }

        public List<QuestionList> QuestionList = new List<QuestionList>();
        public List<QuestionListNew> QuestionListNew = new List<QuestionListNew>();
        

        public int ReportAccessBy { get; set; }
        public bool ReportView { get; set; }
        public bool ReportDelete { get; set; }
        public bool ReportEdit { get; set; }
        public bool isLinkedEvent { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ReportCreatorUser { get; set; }
        public string ReportCreatorFirstName { get; set; }
        public string ReportCreatorLastName { get; set; }
        public string ReportCreateDate { get; set; }
        public bool ReportCreatorView { get; set; }
        public bool ReportCreatorEdit { get; set; }
        public bool ReportCreatorDelete { get; set; }
        public int UserID { get; set; }
        public int RepPerID { get; set; }

        public string ImagePath { get; set; }
        public string DefaultImage { get; set; }
        public bool LinkWithReport { get; set; }
        public int LinkByEmpID { get; set; }
        public string LinkEmployeeName { get; set; }
        public string LinkFile { get; set; }
        public int CheckPermissionID { get; set; }
        public int ProofreadID { get; set; }
        public bool ReportProofread { get; set; }
        public string ProofreadByFirstName { get; set; }
        public string ProofreadByLastName { get; set; }
        public string ProofreadByUserName { get; set; }
        public string DateProofread { get; set; }

        public List<EmployeeIncidentProofRead> EmployeeIncidentProofReadList { get; set; }

        public bool ViewPermission { get; set; }
        public bool EditPermission { get; set; }
        public bool DeletePermission { get; set; }

        public List<EmployeeIncidentModel> empIncidentList = new List<EmployeeIncidentModel>();

        public List<SelectListItem> LocationList = new List<SelectListItem>();

        public List<SelectListItem> TemplateCategoryList = new List<SelectListItem>();
        public string TemplateCategory { get; set; }

        public List<SelectListItem> TemplateCategoryTypeList = new List<SelectListItem>();
        public string TemplateCategoryType { get; set; }

    }

    //public class EmployeeIncidentModelNew
    //{
    //    public int EmployeeInvolvedId { get; set; }
    //    public int IncidentID { get; set; }
    //    public int EmployeeId { get; set; }
    //    public string IncidentNumber { get; set; }

    //    public string NatureOfIncident { get; set; }

    //    // [Required(ErrorMessage = "Short Description is required")]
    //    public string ShortDescription { get; set; }
    //    public string ShortDescriptionName { get; set; }

    //    //    [Required(ErrorMessage = "Incident Date is required")]
    //    public DateTime? IncidentDate { get; set; }

    //    public string StartTime { get; set; }

    //    public bool ActiveStatus { get; set; }

    //    public string Status { get; set; }

    //    public string Location { get; set; }

    //    public string IncidentRole { get; set; }

    //    [AllowHtml]
    //    public string Description { get; set; }

    //    public string UD27 { get; set; }

    //    public string UD34 { get; set; }


    //    public string UD35 { get; set; }

    //    //   [Required(ErrorMessage = "Notes is required")]
    //    [AllowHtml]
    //    public string Notes { get; set; }

    //    //   [Required(ErrorMessage = "IPVR Description is required")]
    //    [AllowHtml]
    //    public string IPVRDescription { get; set; }

    //    public List<EmployeeLinkedList> EmployeeLinkedList { get; set; }

    //    public string VarianceType { get; set; }

    //    public string Resolution { get; set; }

    //    public float Amount { get; set; }

    //    [AllowHtml]
    //    public string VarianceDescription { get; set; }

    //    public int AmountType { get; set; }

    //    public int InvolvedId { get; set; }

    //    public EmployeeModel EmployeeModel { get; set; }

    //    public List<EmployeeModel> EmployeeList = new List<Models.EmployeeModel>();
    //    public List<SelectListItem> DisplayNameList = new List<SelectListItem>();
    //    public List<SelectListItem> AuditTypeList = new List<SelectListItem>();
    //    public string Game { get; set; }

    //    public string ShuffleShoe { get; set; }

    //    public string TimeTaken { get; set; }

    //    public string DisplayName { get; set; }

    //    public string PaceStartTime { get; set; }
    //    public string PaceEndTime { get; set; }
    //    [AllowHtml]
    //    public string PaceDescription { get; set; }
    //    public int PaceAuditPositionsPlayed { get; set; }
    //    public int PaceAuditHandsPlayed { get; set; }
    //    public int PaceAuditHandsPerHour { get; set; }

    //    public List<EmployeeIncidentModelNew> EmployeeIncidentList { get; set; }

    //    public int AuditID { get; set; }

    //    public int Observation { get; set; }

    //    public int QuestionId { get; set; }

    //    public string AnswerOrScore { get; set; }



    //    public string Comment { get; set; }

    //    public List<QuestionListNew> QuestionList = new List<QuestionListNew>();

    //    public int ReportAccessBy { get; set; }
    //    public bool ReportView { get; set; }
    //    public bool ReportDelete { get; set; }
    //    public bool ReportEdit { get; set; }

    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string ReportCreatorUser { get; set; }
    //    public string ReportCreatorFirstName { get; set; }
    //    public string ReportCreatorLastName { get; set; }
    //    public string ReportCreateDate { get; set; }
    //    public bool ReportCreatorView { get; set; }
    //    public bool ReportCreatorEdit { get; set; }
    //    public bool ReportCreatorDelete { get; set; }
    //    public int UserID { get; set; }
    //    public int RepPerID { get; set; }

    //    public string ImagePath { get; set; }
    //    public string DefaultImage { get; set; }
    //    public bool LinkWithReport { get; set; }
    //    public int LinkByEmpID { get; set; }
    //    public string LinkEmployeeName { get; set; }
    //    public string LinkFile { get; set; }
    //    public int CheckPermissionID { get; set; }
    //    public int ProofreadID { get; set; }
    //    public bool ReportProofread { get; set; }
    //    public string ProofreadByFirstName { get; set; }
    //    public string ProofreadByLastName { get; set; }
    //    public string ProofreadByUserName { get; set; }
    //    public string DateProofread { get; set; }

    //    public List<EmployeeIncidentModel> empIncidentList = new List<EmployeeIncidentModel>();

    //    public List<SelectListItem> LocationList = new List<SelectListItem>();

    //}

    public class QuestionList
    {
        public int QuestionID { get; set; }
        public string QuestionGroup { get; set; }
        public string Question { get; set; }
        public string AuditScore { get; set; }
        public string AuditComment { get; set; }
        public bool ScoreType { get; set; }
       
    }
    public class QuestionListNew
    {
        public int AuditID { get; set; }
        public int QuestionID { get; set; }
        public byte QuestionType { get; set; }
        public string Question { get; set; }
        public string AnswerOrScore { get; set; }
        public string Comment { get; set; }
        public List<SelectListItem> AnswerList = new List<SelectListItem>();
    }
    public class Lincence
    {
        public string DateOfHire { get; set; }
        public string TerminationDate { get; set; }
        public string LicenseExpirationDate { get; set; }
        public string Department { get; set; }
        public string LicenseType { get; set; }
        public string LicenseStatus { get; set; }
        public string ReasonForLeaving { get; set; }
    }

    public class Addresses
    {
        public string Apartment { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ProvState { get; set; }
        public string PostalZip { get; set; }
        public string AddressType { get; set; }
    }

}