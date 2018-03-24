using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.BaseLayer.Subject
{
    public class SubjectBase
    {

        #region Declaration
        private string _weight = string.Empty;
        private string _vIP = string.Empty;
        private string _status = string.Empty;
        private decimal _age = 0;
        private string _sex = string.Empty;
        private string _roleName = string.Empty;
        private string _race = string.Empty;
        private string _modifiedDate = string.Empty;
        private string _middleName = string.Empty;
        private string _lastName = string.Empty;
        private string _height = string.Empty;
        private string _hairLength = string.Empty;
        private string _hairColor = string.Empty;
        private string _glasses = string.Empty;
        private string _firstName = string.Empty;
        private string _facialHair = string.Empty;
        private string _eyes = string.Empty;
        private string _dateOfBirth = string.Empty;
        private string _complexion = string.Empty;
        private string _build = string.Empty;
        private int _subjectID = 0;
        private int _cIDPersonID = 0;
        private bool _restricted = false;
        private bool _cIDSubject = false;
        private string _incidentDate = string.Empty;
        private string _natureOfIncident = string.Empty;
        private string _shortDescription = string.Empty;
        private string _overallStatus = string.Empty;
        public string _ageRange = string.Empty;
        private string _subjectNumber = string.Empty;
        #endregion

        #region Properties
        public string Weight { get { return _weight; } set { _weight = value; } }
        public string VIP { get { return _vIP; } set { _vIP = value; } }
        public string Status { get { return _status; } set { _status = value; } }
        public decimal Age { get { return _age; } set { _age = value; } }
        public string Sex { get { return _sex; } set { _sex = value; } }
        public string RoleName { get { return _roleName; } set { _roleName = value; } }
        public string Race { get { return _race; } set { _race = value; } }
        public string ModifiedDate { get { return _modifiedDate; } set { _modifiedDate = value; } }
        public string MiddleName { get { return _middleName; } set { _middleName = value; } }
        public string LastName { get { return _lastName; } set { _lastName = value; } }
        public string Height { get { return _height; } set { _height = value; } }
        public string HairLength { get { return _hairLength; } set { _hairLength = value; } }
        public string HairColor { get { return _hairColor; } set { _hairColor = value; } }
        public string Glasses { get { return _glasses; } set { _glasses = value; } }
        public string FirstName { get { return _firstName; } set { _firstName = value; } }
        public string FacialHair { get { return _facialHair; } set { _facialHair = value; } }
        public string Eyes { get { return _eyes; } set { _eyes = value; } }
        public string DateOfBirth { get { return _dateOfBirth; } set { _dateOfBirth = value; } }
        public string Complexion { get { return _complexion; } set { _complexion = value; } }
        public string Build { get { return _build; } set { _build = value; } }
        public int SubjectID { get { return _subjectID; } set { _subjectID = value; } }
        public int CIDPersonID { get { return _cIDPersonID; } set { _cIDPersonID = value; } }
        public bool Restricted { get { return _restricted; } set { _restricted = value; } }
        public bool CIDSubject { get { return _cIDSubject; } set { _cIDSubject = value; } }
        public string IncidentDate { get { return _incidentDate; } set { _incidentDate = value; } }
        public string NatureOfIncident { get { return _natureOfIncident; } set { _natureOfIncident = value; } }
        public string ShortDescription { get { return _shortDescription; } set { _shortDescription = value; } }
        public string OverallStatus { get { return _overallStatus; } set { _overallStatus = value; } }

        public int CreatedBy { get; set; }
        public int RoleID { get; set; }
        
        public string CreatedByUser { get; set; }
        public string AgeRange { get { return _ageRange; } set { _ageRange = value; } }

        public string SubjectNumber { get { return _subjectNumber; } set { _subjectNumber = value; } }
        #endregion
    }

    public class SubjectAddressBase
    {
        #region Declaration
        private string _provState = string.Empty;
        private string _postalZip = string.Empty;
        private string _city = string.Empty;
        private string _apartment = string.Empty;
        private string _addressType = string.Empty;
        private string _address = string.Empty;
        private int _subjectID = 0;
        private int _incidentID = 0;
        private int _addressID = 0;
        private int _countryID = 0;
        #endregion

        #region Properties
        public string ProvState { get { return _provState; } set { _provState = value; } }
        public string PostalZip { get { return _postalZip; } set { _postalZip = value; } }
        public string City { get { return _city; } set { _city = value; } }
        public string Apartment { get { return _apartment; } set { _apartment = value; } }
        public string AddressType { get { return _addressType; } set { _addressType = value; } }
        public string Address { get { return _address; } set { _address = value; } }
        public int SubjectID { get { return _subjectID; } set { _subjectID = value; } }
        public int IncidentID { get { return _incidentID; } set { _incidentID = value; } }
        public int AddressID { get { return _addressID; } set { _addressID = value; } }
        public int CountryID { get { return _countryID; } set { _countryID = value; } }
        #endregion

    }

    public class SubjectAliasBase
    {
        #region Declaration
        private string _nameType = string.Empty;
        private string _middleName = string.Empty;
        private string _lastName = string.Empty;
        private string _firstName = string.Empty;
        private string _dateEntered = string.Empty;
        private int _subjectID = 0;
        private int _aliasID = 0;
        #endregion

        #region Properties
        public string NameType { get { return _nameType; } set { _nameType = value; } }
        public string MiddleName { get { return _middleName; } set { _middleName = value; } }
        public string LastName { get { return _lastName; } set { _lastName = value; } }
        public string FirstName { get { return _firstName; } set { _firstName = value; } }
        public string DateEntered { get { return _dateEntered; } set { _dateEntered = value; } }
        public int SubjectID { get { return _subjectID; } set { _subjectID = value; } }
        public int AliasID { get { return _aliasID; } set { _aliasID = value; } }
        #endregion

    }

    public class SubjectLinkedBase
    {


        #region Declaration
        private string _filePath = string.Empty;
        private string _description = string.Empty;
        private int _subjectID = 0;
        private int _incidentID = 0;
        private int _iD = 0;
        #endregion

        #region Properties
        public string FilePath { get { return _filePath; } set { _filePath = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public int SubjectID { get { return _subjectID; } set { _subjectID = value; } }
        public int IncidentID { get { return _incidentID; } set { _incidentID = value; } }
        public int ID { get { return _iD; } set { _iD = value; } }
        #endregion
    }

    public class SubjectWatchListBase
    {
        #region Declaration
        private string _watchName = string.Empty;
        private int _subjectID = 0;
        private int _iD = 0;
        private string _xml = string.Empty;
        private bool _isDelete = false;
        #endregion

        #region Properties
        public string WatchName { get { return _watchName; } set { _watchName = value; } }
        public int SubjectID { get { return _subjectID; } set { _subjectID = value; } }
        public int ID { get { return _iD; } set { _iD = value; } }
        public string Xml { get { return _xml; } set { _xml = value; } }
        public bool IsDelete { get { return _isDelete; } set { _isDelete = value; } }
        #endregion
    }

    public class WatchBase
    {
        #region Declaration
        private string _watchName = string.Empty;
        private int _watchID = 0;
        #endregion

        #region Properties
        public string WatchName { get { return _watchName; } set { _watchName = value; } }
        public int WatchID { get { return _watchID; } set { _watchID = value; } }
        #endregion
    }
    public class SubjectIdentificationBase
    {
        #region Declaration
        private string _occupation = string.Empty;
        private string _lCTID = string.Empty;
        private string _iDType3 = string.Empty;
        private string _iDType2 = string.Empty;
        private string _iDType1 = string.Empty;
        private string _iDNumber3 = string.Empty;
        private string _iDNumber2 = string.Empty;
        private string _iDNumber1 = string.Empty;
        private string _businessName = string.Empty;
        private int _subjectID = 0;
        private bool _iDDefault3 = false;
        private bool _iDDefault2 = false;
        private bool _iDDefault1 = false;
        private int _iD = 0;
        #endregion

        #region Properties
        public int ID { get { return _iD; } set { _iD = value; } }
        public string Occupation { get { return _occupation; } set { _occupation = value; } }
        public string LCTID { get { return _lCTID; } set { _lCTID = value; } }
        public string IDType3 { get { return _iDType3; } set { _iDType3 = value; } }
        public string IDType2 { get { return _iDType2; } set { _iDType2 = value; } }
        public string IDType1 { get { return _iDType1; } set { _iDType1 = value; } }
        public string IDNumber3 { get { return _iDNumber3; } set { _iDNumber3 = value; } }
        public string IDNumber2 { get { return _iDNumber2; } set { _iDNumber2 = value; } }
        public string IDNumber1 { get { return _iDNumber1; } set { _iDNumber1 = value; } }
        public string BusinessName { get { return _businessName; } set { _businessName = value; } }
        public int SubjectID { get { return _subjectID; } set { _subjectID = value; } }
        public bool IDDefault3 { get { return _iDDefault3; } set { _iDDefault3 = value; } }
        public bool IDDefault2 { get { return _iDDefault2; } set { _iDDefault2 = value; } }
        public bool IDDefault1 { get { return _iDDefault1; } set { _iDDefault1 = value; } }
        #endregion
    }


    public class SubjectFeaturesBase
    {
        #region Declaration
        private string _featureType = string.Empty;
        private string _featureLocation = string.Empty;
        private string _description = string.Empty;
        private int _subjectID = 0;
        private int _mediaID = 0;
        private int _markID = 0;
        #endregion

        #region Properties
        public string FeatureType { get { return _featureType; } set { _featureType = value; } }
        public string FeatureLocation { get { return _featureLocation; } set { _featureLocation = value; } }
        public int SubjectID { get { return _subjectID; } set { _subjectID = value; } }
        public int MediaID { get { return _mediaID; } set { _mediaID = value; } }
        public int MarkID { get { return _markID; } set { _markID = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        #endregion
    }

    public class SubjectIncidentsBase
    {
        public int IncidentID { get; set; }
        public int SubjectID { get; set; }
        public string IncidentNumber { get; set; }
        public string NatureOfEvent { get; set; }
        public string ShortDescriptor { get; set; }
        public bool ActiveStatus { get; set; }
        public string Status { get; set; }
        public string IncidentDate { get; set; }
        public string EndDate { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string IncidentRole { get; set; }
        public bool Protected { get; set; }
        public string OccurrenceNumber { get; set; }
        public string IPVRDescription { get; set; }
        public string IncidentTime { get; set; }
        public string EndTime { get; set; }
        public string RoleName { get; set; }
        public string UD26 { get; set; }
        public string UD32 { get; set; }
        public string UD33 { get; set; }
        public int EventID { get; set; }
        public string Part { get; set; }
        public int CreatedBy { get; set; }       
        public bool ReportView { get; set; }
        public bool ReportDelete { get; set; }
        public bool ReportEdit { get; set; }
        public int RepPerID { get; set; }
        public int UserID { get; set; }

        public int ReportAccessID { get; set; }
        public string ReportAccessType { get; set; }
        public bool ReportAccessPermission { get; set; }
        public int ReportAccessRole { get; set; }
        public int ReportAccessBy { get; set; }
        public bool ReportProofread { get; set; }
        public int ProofreadID { get; set; }
        public bool ReportCreatorView { get; set; }
        public bool ReportCreatorEdit { get; set; }
        public bool ReportCreatorDelete { get; set; }
        public int AllReport { get; set; }
        public int EventId { get; set; }

    }

    public class LCTCashCallBase
    {
        public int ID { get; set; }
        public int IncidentID { get; set; }
        public int SubjectID { get; set; }
        public string CashCallTime { get; set; }
        public string Cashier { get; set; }
        public decimal Amount { get; set; }
    }

    public class LCTCashOutsBase
    {
        public int ID { get; set; }
        public int IncidentID { get; set; }
        public int SubjectID { get; set; }
        public decimal Amount { get; set; }
        public string TypeOfWin { get; set; }
        public string PaymentType { get; set; }
        public string ChequeNo { get; set; }
        public string CashOutTime { get; set; }
        public string TableNumber { get; set; }
    }

    public class LCTForeignExchangeBase
    {
        public int ID { get; set; }
        public int IncidentID { get; set; }
        public int SubjectID { get; set; }
        public string ForeignCountry { get; set; }
        public decimal Amount { get; set; }
        public decimal ForeignAmount { get; set; }
        public decimal Rate { get; set; }
    }

    public class LCTPitTransactionsBase
    {
        public int ID { get; set; }
        public int IncidentID { get; set; }
        public int SubjectID { get; set; }
        public string Pit { get; set; }
        public string Game { get; set; }
        public decimal Amount { get; set; }
        public string BuyInType { get; set; }
        public string BuyInTime { get; set; }
        public int BuyInGameID { get; set; }
        public int BuyInTypePitID { get; set; }
    }
    public class VehiclesBase
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

    }
    public class IncidentLinkedBase
    {
        public int ID { get; set; }
        public int IncidentID { get; set; }
        public int SubjectID { get; set; }

        public string FilePath { get; set; }
        public string Description { get; set; }

    }
    public class ReportBase
    {
        public int ID { get; set; }
        public int IncidentID { get; set; }
        public int SubjectID { get; set; }

        public string ReportDate { get; set; }
        public string UserID { get; set; }

        public string Description { get; set; }

    }

    public class SubjectInvolvedBase
    {
        public int SubjectIncidentID { get; set; }
        public int IncidentID { get; set; }
        public int SubjectID { get; set; }

        public int EmployeeID { get; set; }
        public int InvolvedID { get; set; }
        public int MediaID { get; set; }
        public string InvolvedRole { get; set; }
        public bool IsEmployee { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public string Race { get; set; }
        public string RoleName { get; set; }
        public string IsAll { get; set; }
        public string NatureOfEvent { get; set; }
        public string ShortDescriptor { get; set; }
        public string OverAllStatus { get; set; }
        public string IncidentDate { get; set; }
        public string DateOfBirth { get; set; }
        public int CreatedBy { get; set; }
        public DataTable InvolveTable { get; set; }
    }

    public class ServiceBase
    {
        public int IncidentID { get; set; }
        public int SubjectID { get; set; }
        public int ServiceID { get; set; }

        public string CallTime { get; set; }

        public string ArriveTime { get; set; }
        public string ServiceName { get; set; }

        public bool Offered { get; set; }
        public bool DeclinedAvailable { get; set; }
        public string ServiceBy { get; set; }
        public string ServiceFor { get; set; }
        public string Description { get; set; }
    }

    public class DisputeBase
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

    public class BannedBase
    {
        public int IncidentID { get; set; }
        public int SubjectID { get; set; }
        public int BannedID { get; set; }
        public int BanTypeId { get; set; }
        public string Currentdate { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }
        public int Day { get; set; }

        public int month { get; set; }

        public int year { get; set; }
        public string AuthorizedBy { get; set; }
        public string TypeOfBan { get; set; }


        public string Description { get; set; }
    }
    public class BanTypeBase
    {
        public int IncidentID { get; set; }
        public int SubjectID { get; set; }
        public DataTable BanTypeTable { get; set; }
        public bool TypeOfBan { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }

    }

    public class LCTIdentificationBase
    {
        public int IncidentID { get; set; }
        public int SubjectID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Apartment { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ProvState { get; set; }
        public string PostalZip { get; set; }
        public string Occupation { get; set; }
        public string BusinessName { get; set; }
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
        public decimal CashoutMarker { get; set; }
        public decimal CashCall { get; set; }
        public decimal ForeignExchange { get; set; }
    }

    
}
