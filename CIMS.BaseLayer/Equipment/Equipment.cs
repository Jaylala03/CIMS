using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.BaseLayer
{
    public class Equipment
    {
        public int userID { get; set; }
        public int problemID { get; set; }
        public string ProblemType { get; set; }
        public string EquipNumber { get; set; }
        public string Problem { get; set; }
        public string Details { get; set; }
        public bool Corrected { get; set; }
        public string Solution { get; set; }
        public string Replacement { get; set; }
        public string StatusTime { get; set; }
        public string CompletedTime { get; set; }
        public int ProblemID { get; set; }
    }
}
