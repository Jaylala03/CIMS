using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.BaseLayer.GeneralReports
{
    public class GeneralReportsBase
    {
        public int ReportID { get; set; }
        public string ReportNumber { get; set; }
        public string NatureOfEvent { get; set; }
        public string ShortDescriptor { get; set; }
        public bool ActiveStatus { get; set; }
        public string Status { get; set; }
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
        public int InvolvedID { get; set; }
        public bool IsEmployee { get; set; }
        public string ReportAccessType { get; set; }
        public bool ReportAccessPermission { get; set; }
        public int ReportAccessID { get; set; }
        public int ReportAccessRole { get; set; }
    }


}
