using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CIMS.Models
{

    public class ManageRolemodel
    {
        public List<RoleModel> RoleList { get; set; }

        public RoleModel roleModel { get; set; }
    }
    public class RoleModel
    {
        public string RoleName { get; set; }
        public int WatchListEdit { get; set; }
        public int WatchList { get; set; }
        public int Visitors { get; set; }
        public int Vehicles { get; set; }
        public int Users { get; set; }
        public int TransactionLog { get; set; }
        public int Subjects { get; set; }
        public int SubjectLinked { get; set; }
        public int SharedInformation { get; set; }
        public int SharedEmails { get; set; }
        public int ServicesCodes { get; set; }
        public int Services { get; set; }
        public int RestrictedSubjects { get; set; }
        public int ReportOptions { get; set; }
        public int QuickIncident { get; set; }
        public int Permissions { get; set; }
        public int OccurrenceWrite { get; set; }
        public int OccurrenceAdministration { get; set; }
        public int Occurrence { get; set; }
        public int NatureofIncidentCodes { get; set; }
        public int NatureofCallCodes { get; set; }
        public int MultipleAuthorReports { get; set; }
        public int Messages { get; set; }
        public int MessageGroups { get; set; }
        public int MessageAlerts { get; set; }
        public int MediaReview { get; set; }
        public int MediaCopy { get; set; }
        public int MediaCaptureOptions { get; set; }
        public int MediaCapture { get; set; }
        public int LCTTotals { get; set; }
        public int LCTDetails { get; set; }
        public int LabelNames { get; set; }
        public int Involved { get; set; }
        public int IncidentProtection { get; set; }
        public int IncidentDetails { get; set; }
        public int IncidentDescription { get; set; }
        public int Identification { get; set; }
        public int GameLocations { get; set; }
        public int ForeignRates { get; set; }
        public int Features { get; set; }
        public int EventsMedia { get; set; }
        public int Events { get; set; }
        public int Equipment { get; set; }
        public int EmployeeVariance { get; set; }
        public int EmployeePersonal { get; set; }
        public int EmployeePaceAudit { get; set; }
        public int EmployeeNotes { get; set; }
        public int EmployeeLinked { get; set; }
        public int EmployeeLicense { get; set; }
        public int EmployeeIPVR { get; set; }
        public int EmployeeInvolved { get; set; }
        public int EmployeeIncidentDetails { get; set; }
        public int EmployeeGameAudit { get; set; }
        public int EmployeeAddress { get; set; }
        public int Employee { get; set; }
        public int Emails { get; set; }
        public int DropdownCodes { get; set; }
        public int DisputeOffense { get; set; }
        public int DispatchDispatchers { get; set; }
        public int DispatchCallTakers { get; set; }
        public int DispatchAdministration { get; set; }
        public int DatabaseOptions { get; set; }
        public int CustomReports { get; set; }
        public int CombineSubjects { get; set; }
        public int ChangeRoles { get; set; }
        public int CashTransactions { get; set; }
        public int Banned { get; set; }
        public int Badges { get; set; }
        public int AuditQuestions { get; set; }
        public int ApplicationOptions { get; set; }
        public int Alias { get; set; }
        public int Address { get; set; }
        public int AccessCards { get; set; }

    }

    public class Roles
    {
        public int RoleId { get; set; }

      

        [Required(ErrorMessage = "Role Name is required")]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }      
       
        public List<Roles> RolesList { get; set; }

        public List<Menus> MenusList { get; set; }

        public SubMenus SubMenusModel { get; set; }
        public List<SubMenus> SubMenusList { get; set; }
       
       


    }

    public class Menus
    {
        public int Row { get; set; }
        public int Id { get; set; }

        public string MenuName { get; set; }

        public int ParentId {get;set; }

        public int PermissionType { get; set; }

        public bool Permission { get; set; }

        public int RoleId { get; set; }
    }

    public class SubMenus
    {
        public int SubMenuID { get; set; }
        public string MenuName { get; set; }
        public int ParentID { get; set; }
        public int RoleID { get; set; }
        public int SubMenuPermission { get; set; }
    }
}