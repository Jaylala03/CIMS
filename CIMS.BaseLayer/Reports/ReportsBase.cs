using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.BaseLayer.Reports
{
    public class ReportsBase
    {
        public string SubjectID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public string Race { get; set; }
        public string Status { get; set; }
        public string BanName { get; set; }
        public string Picture { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Game { get; set; }
        public string PaceAuditHandsPerHour { get; set; }
        public string TypeOfBan { get; set; }
        public string SortOrder { get; set; }
        public string EmailDate { get; set; }
        public string EmailTime { get; set; }
        public string FromUserName { get; set; }
        public string ToEmail { get; set; }
        public string CCEmail { get; set; }
        public string EmailSubject { get; set; }


        //Dispatch_print
        public string CallID { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }

    public class ReportsWatchListBase
    {
        public string WatchName { get; set; }
    }

    public class ReportsStatisticsBase
    {
        public string Type { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string ShortLocation { get; set; }
        public string ShortDescriptor { get; set; }
        public string Location { get; set; }
        public string IncidentCount { get; set; }
        public string Employee { get; set; }
        public string SumAmount { get; set; }
    }

}
