using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.BaseLayer.Events
{
    public class EventGeneralReports
    {
        [Required]
        public int eventid { get; set; }
        public List<generalreport> generalreports { get; set; }

    }
    public class GeneralReportEvents
    {

        [Required]
        public int reportid { get; set; }

        //[Required]
        public List<int> listeventid { get; set; }

    }
    public class generalreport
    {
        [Required]
        public int reportid { get; set; }
    }
    public class eventgeneralreport
    {
        [Required]
        public int eventid { get; set; }

        [Required]
        public int reportid { get; set; }
    }
}
