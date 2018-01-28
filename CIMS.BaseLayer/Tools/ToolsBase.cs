using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.BaseLayer.Tools
{
    public class ToolsBase
    {
        public string GroupName { get; set; }

        public string TableName { get; set; }

        public string ExecuteSql { get; set; }

        public int ReportID { get; set; }
        public string ReportName { get; set; }


        public string Role { get; set; }

        public string ReportLayout { get; set; }
        public string WholeLayout { get; set; }


    }
}
