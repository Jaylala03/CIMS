using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CIMS.Models
{
    public class VisitorModel
    {
        public int VisitorID { get; set; }
        [Required]
        public string VisitorName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string FromHoursMinutes { get; set; }
        [Required]
        public string ToHoursMinutes { get; set; }
        public int EventID { get; set; }
        [Required]
        public string VisitorDate { get; set; }
        public string GroupIdentifier { get; set; }

        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public int CreatedBy { get; set; }
        public string CreatedByUser { get; set; }
        public string CreatedDate { get; set; }
        public string TotalVisit { get; set; }

        public string ImagePath { get; set; }

        public List<VisitorModel> VisitorList = new List<VisitorModel>();
    }
}