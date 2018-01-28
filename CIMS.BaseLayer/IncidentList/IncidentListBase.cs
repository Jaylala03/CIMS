using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.BaseLayer.IncidentList
{
    public class IncidentListBase
    {
        public string Type { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string IncidentDate { get; set; }
        public string Name { get; set; }
        public string NatureOfEvent { get; set; }
        public string ShortDescriptor { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }

    }
}
