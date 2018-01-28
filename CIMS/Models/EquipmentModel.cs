using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CIMS.Models
{
    public class EquipmentModel
    {
        public int userID { get; set; }
        public int problemID { get; set; }
        public string ProblemType { get; set; }

        [Required(ErrorMessage = "Name/Number is required")]
        public string EquipNumber { get; set; }
        public string Problem { get; set; }
        [AllowHtml]
        public string Details { get; set; }
        public bool Corrected { get; set; }

        public string Solution { get; set; }
        public string Replacement { get; set; }
        public string StatusTime { get; set; }

        [Required(ErrorMessage = "Completed Date is required")]
        public string CompletedTime { get; set; }
        public List<EquipmentModel> EquipmentList = new List<EquipmentModel>();

    }
}