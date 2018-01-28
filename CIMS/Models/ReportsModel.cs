using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CIMS.Models
{
    public class ReportsModel
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
        public string TypeOfBan { get; set; }
        public string SortOrder { get; set; }
        public string EmailDate { get; set; }
        public string EmailTime { get; set; }
        public string FromUserName { get; set; }
        public string ToEmail { get; set; }
        public string CCEmail { get; set; }
        public string EmailSubject { get; set; }
        public string WatchList { get; set; }

        public string EmployeeId { get; set; }
        public string ObservationCount { get; set; }
        public string IncidentCount { get; set; }

        public string PaceAuditsHandsPerHour { get; set; }

        public string Postions { get; set; }

        public string ShuffleTime { get; set; }
        public string ShoeTime { get; set; }

        //Dispatch_print
        public string CallID { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }


        public List<BanType> BanTypeList = new List<BanType>();
        public List<ReportsModel> reportsList = new List<ReportsModel>();

        public List<EmployeeModel> EmployeeList = new List<EmployeeModel>();
    }

    public class ReportsWatchListModel
    {
        public string WatchName { get; set; }
        public List<SelectListItem> WatchList { get; set; }

        public List<ReportsWatchListModel> reportsWatchList = new List<ReportsWatchListModel>();

        public List<ReportsModel> reportsList = new List<ReportsModel>();
    }

    public class ReportsStatisticsModel
    {
        public string Type { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string ShortLocation { get; set; }
        public string ShortDescriptor { get; set; }
        public string Location { get; set; }
        public string IncidentCount { get; set; }
        public string SumAmount { get; set; }
        public string Employee { get; set; }
        public string results { get; set; }

        public List<ReportsStatisticsModel> reportsStatisticsList = new List<ReportsStatisticsModel>();
    }
}