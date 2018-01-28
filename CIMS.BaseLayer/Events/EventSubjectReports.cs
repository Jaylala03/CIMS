using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.BaseLayer.Events
{
    public class EventSubjectReports
    {
        [Required]
        public int eventid { get; set; }
        public List<subjectreport> subjectreports { get; set; }

    }
    public class SubjectReportEvents
    {
        [Required]
        public int subjectid { get; set; }

        [Required]
        public int incidentid { get; set; }

        //[Required]
        public List<int> listeventid { get; set; }

    }
    public class subjectreport
    {
        [Required]
        public int subjectid { get; set; }

        [Required]
        public int incidentid { get; set; }
    }
    public class eventsubjectreport
    {
        [Required]
        public int eventid { get; set; }

        [Required]
        public int subjectid { get; set; }

        [Required]
        public int incidentid { get; set; }
    }
}
