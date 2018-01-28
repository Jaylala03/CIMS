using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CIMS.Models
{
    public class SettingModel
    {
        public EmployeeModel EmployeeModel { get; set; }
        public List<EmployeeModel> EmployeeList = new List<EmployeeModel>();
    }
    public class DepartmentType
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }
    public class AuditQuestions
    {
        public int QuestionID { get; set; }
        public string AuditType { get; set; }
        public string QuestionGroup { get; set; }
        public string Question { get; set; }
        public bool ScoreType { get; set; }
        public string ToolTip { get; set; }
    }
    public class AuditsQuestions
    {
        public int QuestionID { get; set; }
        public int AuditID { get; set; }

        public string Audit { get; set; }
        [Required]
        public string Question { get; set; }

        [Required]
        [Display(Name = "Question Type")]
        public byte QuestionType { get; set; }

        public string ToolTip { get; set; }
        public List<SelectListItem> QuestionTypeList = new List<SelectListItem>();
    }
    public class ManageAuditsQuestionsModel
    {
        public AuditsQuestions auditsQuestionModel { get; set; }
        public List<AuditsQuestions> auditsQuestionList { get; set; }

        public AuditQuestions AuditQuestions { get; set; }

    }
    
}