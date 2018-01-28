using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.BaseLayer.Admin
{
    public class AdminBase
    {


    }
    public class RoleBase
    {
        #region Declaration
        private int _id { get; set; }
        private string _roleName { get; set; }
        private int _events { get; set; }
        private int _occurrence { get; set; }
        private int _eventsMedia { get; set; }
        private int _mediaReview { get; set; }
        private int _mediaCopy { get; set; }
        private int _visitors { get; set; }
        private int _occurrenceWrite { get; set; }
        private int _occurrenceAdministration { get; set; }
        private int _accessCards { get; set; }
        private int _equipment { get; set; }
        private int _subjects { get; set; }
        private int _address { get; set; }
        private int _alias { get; set; }
        private int _features { get; set; }
        private int _identification { get; set; }
        private int _lCTTotals { get; set; }
        private int _watchList { get; set; }
        private int _watchListEdit { get; set; }
        private int _restrictedSubjects { get; set; }
        private int _incidentDetails { get; set; }
        private int _incidentDescription { get; set; }
        private int _incidentProtection { get; set; }
        private int _cashTransactions { get; set; }
        private int _lCTDetails { get; set; }
        private int _vehicles { get; set; }
        private int _involved { get; set; }
        private int _banned { get; set; }
        private int _disputeOffense { get; set; }
        private int _services { get; set; }
        private int _combineSubjects { get; set; }
        private int _users { get; set; }
        private int _permissions { get; set; }
        private int _mediaCapture { get; set; }
        private int _mediaCaptureOptions { get; set; }
        private int _applicationOptions { get; set; }
        private int _databaseOptions { get; set; }
        private int _natureofCallCodes { get; set; }
        private int _natureofIncidentCodes { get; set; }
        private int _dropdownCodes { get; set; }
        private int _gameLocations { get; set; }
        private int _servicesCodes { get; set; }
        private int _reportOptions { get; set; }
        private int _emails { get; set; }
        private int _employee { get; set; }
        private int _employeeIncidentDetails { get; set; }
        private int _employeeInvolved { get; set; }
        private int _employeeGameAudit { get; set; }
        private int _employeePaceAudit { get; set; }
        private int _employeeIPVR { get; set; }
        private int _auditQuestions { get; set; }
        private int _employeeNotes { get; set; }
        private int _labelNames { get; set; }
        private int _employeeVariance { get; set; }
        private int _badges { get; set; }
        private int _foreignRates { get; set; }
        private int _quickIncident { get; set; }
        private int _subjectLinked { get; set; }
        private int _employeeLinked { get; set; }
        private int _employeeAddress { get; set; }
        private int _employeeLicense { get; set; }
        private int _employeePersonal { get; set; }
        private int _transactionLog { get; set; }
        private int _messages { get; set; }
        private int _messageGroups { get; set; }
        private int _dispatchAdministration { get; set; }
        private int _dispatchDispatchers { get; set; }
        private int _dispatchCallTakers { get; set; }
        private int _sharedInformation { get; set; }
        private int _sharedEmails { get; set; }
        private int _changeRoles { get; set; }
        private int _customReports { get; set; }
        private int _multipleAuthorReports { get; set; }
        private int _messageAlerts { get; set; }
        #endregion

        #region Properties
        public int ID { get { return _id; } set { _id = value; } }
        public string RoleName { get { return _roleName; } set { _roleName = value; } }
        public int WatchListEdit { get { return _watchListEdit; } set { _watchListEdit = value; } }
        public int WatchList { get { return _watchList; } set { _watchList = value; } }
        public int Visitors { get { return _visitors; } set { _visitors = value; } }
        public int Vehicles { get { return _vehicles; } set { _vehicles = value; } }
        public int Users { get { return _users; } set { _users = value; } }
        public int TransactionLog { get { return _transactionLog; } set { _transactionLog = value; } }
        public int Subjects { get { return _subjects; } set { _subjects = value; } }
        public int SubjectLinked { get { return _subjectLinked; } set { _subjectLinked = value; } }
        public int SharedInformation { get { return _sharedInformation; } set { _sharedInformation = value; } }
        public int SharedEmails { get { return _sharedEmails; } set { _sharedEmails = value; } }
        public int ServicesCodes { get { return _servicesCodes; } set { _servicesCodes = value; } }
        public int Services { get { return _services; } set { _services = value; } }
        public int RestrictedSubjects { get { return _restrictedSubjects; } set { _restrictedSubjects = value; } }
        public int ReportOptions { get { return _reportOptions; } set { _reportOptions = value; } }
        public int QuickIncident { get { return _quickIncident; } set { _quickIncident = value; } }
        public int Permissions { get { return _permissions; } set { _permissions = value; } }
        public int OccurrenceWrite { get { return _occurrenceWrite; } set { _occurrenceWrite = value; } }
        public int OccurrenceAdministration { get { return _occurrenceAdministration; } set { _occurrenceAdministration = value; } }
        public int Occurrence { get { return _occurrence; } set { _occurrence = value; } }
        public int NatureofIncidentCodes { get { return _natureofIncidentCodes; } set { _natureofIncidentCodes = value; } }
        public int NatureofCallCodes { get { return _natureofCallCodes; } set { _natureofCallCodes = value; } }
        public int MultipleAuthorReports { get { return _multipleAuthorReports; } set { _multipleAuthorReports = value; } }
        public int Messages { get { return _messages; } set { _messages = value; } }
        public int MessageGroups { get { return _messageGroups; } set { _messageGroups = value; } }
        public int MessageAlerts { get { return _messageAlerts; } set { _messageAlerts = value; } }
        public int MediaReview { get { return _mediaReview; } set { _mediaReview = value; } }
        public int MediaCopy { get { return _mediaCopy; } set { _mediaCopy = value; } }
        public int MediaCaptureOptions { get { return _mediaCaptureOptions; } set { _mediaCaptureOptions = value; } }
        public int MediaCapture { get { return _mediaCapture; } set { _mediaCapture = value; } }
        public int LCTTotals { get { return _lCTTotals; } set { _lCTTotals = value; } }
        public int LCTDetails { get { return _lCTDetails; } set { _lCTDetails = value; } }
        public int LabelNames { get { return _labelNames; } set { _labelNames = value; } }
        public int Involved { get { return _involved; } set { _involved = value; } }
        public int IncidentProtection { get { return _incidentProtection; } set { _incidentProtection = value; } }
        public int IncidentDetails { get { return _incidentDetails; } set { _incidentDetails = value; } }
        public int IncidentDescription { get { return _incidentDescription; } set { _incidentDescription = value; } }
        public int Identification { get { return _identification; } set { _identification = value; } }
        public int GameLocations { get { return _gameLocations; } set { _gameLocations = value; } }
        public int ForeignRates { get { return _foreignRates; } set { _foreignRates = value; } }
        public int Features { get { return _features; } set { _features = value; } }
        public int EventsMedia { get { return _eventsMedia; } set { _eventsMedia = value; } }
        public int Events { get { return _events; } set { _events = value; } }
        public int Equipment { get { return _equipment; } set { _equipment = value; } }
        public int EmployeeVariance { get { return _employeeVariance; } set { _employeeVariance = value; } }
        public int EmployeePersonal { get { return _employeePersonal; } set { _employeePersonal = value; } }
        public int EmployeePaceAudit { get { return _employeePaceAudit; } set { _employeePaceAudit = value; } }
        public int EmployeeNotes { get { return _employeeNotes; } set { _employeeNotes = value; } }
        public int EmployeeLinked { get { return _employeeLinked; } set { _employeeLinked = value; } }
        public int EmployeeLicense { get { return _employeeLicense; } set { _employeeLicense = value; } }
        public int EmployeeIPVR { get { return _employeeIPVR; } set { _employeeIPVR = value; } }
        public int EmployeeInvolved { get { return _employeeInvolved; } set { _employeeInvolved = value; } }
        public int EmployeeIncidentDetails { get { return _employeeIncidentDetails; } set { _employeeIncidentDetails = value; } }
        public int EmployeeGameAudit { get { return _employeeGameAudit; } set { _employeeGameAudit = value; } }
        public int EmployeeAddress { get { return _employeeAddress; } set { _employeeAddress = value; } }
        public int Employee { get { return _employee; } set { _employee = value; } }
        public int Emails { get { return _emails; } set { _emails = value; } }
        public int DropdownCodes { get { return _dropdownCodes; } set { _dropdownCodes = value; } }
        public int DisputeOffense { get { return _disputeOffense; } set { _disputeOffense = value; } }
        public int DispatchDispatchers { get { return _dispatchDispatchers; } set { _dispatchDispatchers = value; } }
        public int DispatchCallTakers { get { return _dispatchCallTakers; } set { _dispatchCallTakers = value; } }
        public int DispatchAdministration { get { return _dispatchAdministration; } set { _dispatchAdministration = value; } }
        public int DatabaseOptions { get { return _databaseOptions; } set { _databaseOptions = value; } }
        public int CustomReports { get { return _customReports; } set { _customReports = value; } }
        public int CombineSubjects { get { return _combineSubjects; } set { _combineSubjects = value; } }
        public int ChangeRoles { get { return _changeRoles; } set { _changeRoles = value; } }
        public int CashTransactions { get { return _cashTransactions; } set { _cashTransactions = value; } }
        public int Banned { get { return _banned; } set { _banned = value; } }
        public int Badges { get { return _badges; } set { _badges = value; } }
        public int AuditQuestions { get { return _auditQuestions; } set { _auditQuestions = value; } }
        public int ApplicationOptions { get { return _applicationOptions; } set { _applicationOptions = value; } }
        public int Alias { get { return _alias; } set { _alias = value; } }
        public int Address { get { return _address; } set { _address = value; } }
        public int AccessCards { get { return _accessCards; } set { _accessCards = value; } }

        public DataTable permissionTable { get; set; }

        public string MenuName { get; set; }
        public int UserId { get; set; }
        #endregion

    }

    public class UserBase
    {
        #region Declaration
        private string _userID = string.Empty;
        private string _skills = string.Empty;
        private string _regNumber = string.Empty;

        private string _password = string.Empty;
        private string _lastName = string.Empty;
        private string _initials = string.Empty;
        private string _firstName = string.Empty;
        private string _eMail = string.Empty;
        private int _unitID = 0;
        private int _iD = 0;
        private bool _userCanChangePassword = false;
        private bool _isDispatchable = false;
        private string _userName = string.Empty;
        #endregion

        #region Properties
        public string UserID { get { return _userID; } set { _userID = value; } }
        public string Skills { get { return _skills; } set { _skills = value; } }
        public string RegNumber { get { return _regNumber; } set { _regNumber = value; } }
        public DateTime PasswordDate { get; set; }
        public string Password { get { return _password; } set { _password = value; } }
        public string LastName { get { return _lastName; } set { _lastName = value; } }
        public string Initials { get { return _initials; } set { _initials = value; } }
        public string FirstName { get { return _firstName; } set { _firstName = value; } }
        public string EMail { get { return _eMail; } set { _eMail = value; } }
        public int UnitID { get { return _unitID; } set { _unitID = value; } }
        public int ID { get { return _iD; } set { _iD = value; } }
        public bool UserCanChangePassword { get { return _userCanChangePassword; } set { _userCanChangePassword = value; } }
        public bool IsDispatchable { get { return _isDispatchable; } set { _isDispatchable = value; } }
        public string UserName { get { return _userName; } set { _userName = value; } }

        public int? Country { get; set; }

        public int? State { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }

        public string Phone { get; set; }

        public DateTime? LicenseExpiryDate { get; set; }

        public string CustomerLogo { get; set; }

        public string UserGuid { get; set; }
        public string CustomerRoles { get; set; }
        public DataTable Roles { get; set; }
        public int? RoleType { get; set; }
        #endregion

    }

    public class SubMenuBase
    {
        public int RoleID { get; set; }
        public int ParentID { get; set; }
        public string Roles { get; set; }
    }


    // *DN
    public class CorporateBase
    {
        public int Corporate_id { get; set; }
        public string Corporate_logo { get; set; }
        //AB New
        public string Customer_logo { get; set; }
        public string Corporate_background { get; set; }
        public string Corporate_back_type { get; set; }
        public string Corporate_action { get; set; }
    }
}
