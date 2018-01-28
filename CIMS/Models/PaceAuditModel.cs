using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace CIMS.Models
{
    public class PaceAuditModel
    {
        public int ID { get; set; }

        [Required]
        public string Game { get; set; }

        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public int HandsPerHour { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}