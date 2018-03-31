using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.BaseLayer.Employee
{
    public class EmployeeBase
    {
        public int EmpID { get; set; }
        public int UserID { get; set; }
        public string EmpNumber { get; set; }
        public string EmployeeNumber { get; set; }
        public Decimal Age { get; set; }
        public string Sex { get; set; }
        public string Race { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Height { get; set; }
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
        public int EmployeeID { get; set; }

        public DateTime ModifiedDate { get; set; }
        public string Apartment { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int CountryID { get; set; }
        public string ProvState { get; set; }
        public string PostalZip { get; set; }
        public string AddressType { get; set; }
        public string Phone { get; set; }

        public int LicenseID { get; set; }
        public DateTime DateOfHire { get; set; }
        public DateTime? TerminationDate { get; set; }
        public DateTime LicenseExpirationDate { get; set; }
        public string Department { get; set; }
        public string LicenseType { get; set; }
        public string LicenseStatus { get; set; }
        public string ReasonForLeaving { get; set; }

        //IDType1, IDNumber1, IDDefault1

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

        // Linked

        public string FilePath { get; set; }
        public string Description { get; set; }
        public int ID { get; set; }

        public int InvolvedId { get; set; }
        public int EmployeeInvolvedId { get; set; }

        public string IncidentDate { get; set; }
        public string NatureOfIncident { get; set; }
        public string ShortDescription { get; set; }
        public string OverallStatus { get; set; }

        public int CreatedBy { get; set; }
        public string SubjectVIP { get; set; }
        public int RoleID { get; set; }

        public string EmployeeDepartment { get; set; }

        public int EmployeeStatusID { get; set; }
    }


    public class EmployeeIncidentBase
    {
        public int IncidentID { get; set; }

        public int EmployeeId { get; set; }

        public string IncidentNumber { get; set; }

        public string NatureOfIncident { get; set; }

        public string ShortDescription { get; set; }

        public DateTime IncidentDate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public bool ActiveStatus { get; set; }

        public string Status { get; set; }

        public string Location { get; set; }

        public string IncidentRole { get; set; }


        public string Description { get; set; }

        public string UD27 { get; set; }

        public string UD34 { get; set; }


        public string UD35 { get; set; }

        public string Notes { get; set; }

        public string IPVRDescription { get; set; }
        public string VarianceType { get; set; }

        public string Resolution { get; set; }

        public float Amount { get; set; }

        public string VarianceDescription { get; set; }

        public int AmountType { get; set; }

        public int InvolvedId { get; set; }
        public string Game { get; set; }

        public string ShuffleShoe { get; set; }

        public string TimeTaken { get; set; }

        public string DisplayName { get; set; }

        public string PaceStartTime { get; set; }
        public string PaceEndTime { get; set; }

        public string PaceDescription { get; set; }
        public int PaceAuditPositionsPlayed { get; set; }
        public int PaceAuditHandsPlayed { get; set; }
        public int PaceAuditHandsPerHour { get; set; }
        public string AuditType { get; set; }

        public int Observation { get; set; }

        public int QuestionId { get; set; }

        public string AuditScore { get; set; }

        public string AuditComment { get; set; }

        public int AuditID { get; set; }
        public string AnswerOrScore { get; set; }
        public string Comment { get; set; }

        public int CreatedBy { get; set; }

        public int ReportAccessBy { get; set; }
        public bool ReportView { get; set; }
        public bool ReportDelete { get; set; }
        public bool ReportEdit { get; set; }
        public int RepPerID { get; set; }
        public int UserID { get; set; }
        public string FetchDetailsBy { get; set; }
        public DataTable InvolveTable { get; set; }

        public int ReportAccessID { get; set; }
        public string ReportAccessType { get; set; }
        public bool ReportAccessPermission { get; set; }
        public int ReportAccessRole { get; set; }
        public bool ReportProofread { get; set; }
        public int ProofreadID { get; set; }
        public int AllReport { get; set; }
        public bool ReportCreatorView { get; set; }
        public bool ReportCreatorEdit { get; set; }
        public bool ReportCreatorDelete { get; set; }
        public int EventId { get; set; }
    }


    //public class EmployeeIncidentBaseNew
    //{
    //    public int IncidentID { get; set; }

    //    public int EmployeeId { get; set; }

    //    public string IncidentNumber { get; set; }

    //    public string NatureOfIncident { get; set; }

    //    public string ShortDescription { get; set; }

    //    public DateTime? IncidentDate { get; set; }

    //    public string StartTime { get; set; }

    //    public bool ActiveStatus { get; set; }

    //    public string Status { get; set; }

    //    public string Location { get; set; }

    //    public string IncidentRole { get; set; }


    //    public string Description { get; set; }

    //    public string UD27 { get; set; }

    //    public string UD34 { get; set; }


    //    public string UD35 { get; set; }

    //    public string Notes { get; set; }

    //    public string IPVRDescription { get; set; }
    //    public string VarianceType { get; set; }

    //    public string Resolution { get; set; }

    //    public float Amount { get; set; }

    //    public string VarianceDescription { get; set; }

    //    public int AmountType { get; set; }

    //    public int InvolvedId { get; set; }
    //    public string Game { get; set; }

    //    public string ShuffleShoe { get; set; }

    //    public string TimeTaken { get; set; }

    //    public string DisplayName { get; set; }

    //    public string PaceStartTime { get; set; }
    //    public string PaceEndTime { get; set; }

    //    public string PaceDescription { get; set; }
    //    public int PaceAuditPositionsPlayed { get; set; }
    //    public int PaceAuditHandsPlayed { get; set; }
    //    public int PaceAuditHandsPerHour { get; set; }

    //    public int AuditID { get; set; }
    //    public int Observation { get; set; }
    //    public int QuestionId { get; set; }
    //    public string AnswerOrScore { get; set; }
    //    public string Comment { get; set; }

    //    public int CreatedBy { get; set; }

    //    public int ReportAccessBy { get; set; }
    //    public bool ReportView { get; set; }
    //    public bool ReportDelete { get; set; }
    //    public bool ReportEdit { get; set; }
    //    public int RepPerID { get; set; }
    //    public int UserID { get; set; }
    //    public string FetchDetailsBy { get; set; }
    //    public DataTable InvolveTable { get; set; }

    //    public int ReportAccessID { get; set; }
    //    public string ReportAccessType { get; set; }
    //    public bool ReportAccessPermission { get; set; }
    //    public int ReportAccessRole { get; set; }
    //    public bool ReportProofread { get; set; }
    //    public int ProofreadID { get; set; }
    //    public int AllReport { get; set; }
    //    public bool ReportCreatorView { get; set; }
    //    public bool ReportCreatorEdit { get; set; }
    //    public bool ReportCreatorDelete { get; set; }

    //}
}
