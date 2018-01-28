using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.BaseLayer
{
    public class VisitorBase
    {
        public int VisitorID { get; set; }
        public string VisitorName { get; set; }
        public string Description { get; set; }
        public string FromHoursMinutes { get; set; }
        public string ToHoursMinutes { get; set; }
        public string VisitorDate { get; set; }
        public string GroupIdentifier { get; set; }

        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByUser { get; set; }
        public string CreatedDate { get; set; }
    }
}
