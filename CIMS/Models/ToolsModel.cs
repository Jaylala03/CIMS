using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CIMS.Models
{
    public class ToolsModel
    {
        public string GroupName { get; set; }
        public int ReportID { get; set; }
        public string TableName { get; set; }

        public string DisplayName { get; set; }
        public string ReportName { get; set; }
        public string RoleName { get; set; }
        public string ReportLayout { get; set; }
        public string WholeLayout { get; set; }
        public string column_name { get; set; }
        public string ExecuteSql { get; set; }
        public string QuerySQL { get; set; }
        public string data_type { get; set; }
        public List<ToolsModel> RoleNameList = new List<ToolsModel>();
        public List<ToolsModel> ReportNameList = new List<ToolsModel>();
        public List<ToolsModel> LoadTableColumnsTreeNodeList = new List<ToolsModel>();
        public List<ToolsModel> LoadDataTablesTreeList = new List<ToolsModel>();
        public List<ToolsModel> toolsList = new List<ToolsModel>();
        public List<ToolsModel> ExecuteSQlList = new List<ToolsModel>();
        public List<ToolsModel> ReportLayoutList = new List<ToolsModel>();
        public List<ToolsModel> QuerySQLList = new List<ToolsModel>();
    }
}