using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.BaseLayer.Events
{
    public class EventEmployeeReports
    {
        [Required]
        public int eventid { get; set; }
        public List<employeereport> employeereports { get; set; }

    }
    public class EmployeeReportEvents
    {
        [Required]
        public int employeeid { get; set; }

        [Required]
        public int incidentid { get; set; }

        //[Required]
        public List<int> listeventid { get; set; }

    }
    public class employeereport
    {
        [Required]
        public int employeeid { get; set; }

        [Required]
        public int incidentid { get; set; }
    }
    public class eventemployeereport
    {
        [Required]
        public int eventid { get; set; }

        [Required]
        public int employeeid { get; set; }

        [Required]
        public int incidentid { get; set; }
    }
}
