using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.BaseLayer.Events
{
    public class EventBase
    {
        public int EventID { get; set; }

        public string EventDate { get; set; }
        public int EventNumber { get; set; }
        public int AttachedEvent { get; set; }
        public string EventTime { get; set; }
        public string FromCode { get; set; }
        public string NatureCode { get; set; }
        public string NatureDesc { get; set; }
        public string Comments { get; set; }
        public string DutyDesc { get; set; }
        public string UserID { get; set; }
        public int CreatedBy { get; set; }
        public int RoleID { get; set; }

        public string Camera { get; set; }

        public bool KeyEvent { get; set; }
        public string FromForm { get; set; }
        public string FromNumber { get; set; }
        public string RoleName { get; set; }

        public string UD20 { get; set; }

        public string sortValue { get; set; }
        public string Location { get; set; }

        public string EndTime { get; set; }

        public string Site { get; set; }

        public string UD25 { get; set; }

        public string UD24 { get; set; }

        public string UD23 { get; set; }
        public string datacolumn { get; set; }

        public string UD22 { get; set; }

        public string UD21 { get; set; }

        public string Part { get; set; }

        public int SubjectID { get; set; }
        public int EmployeeID { get; set; }
        public int IncidentID { get; set; }
        public int ReportID { get; set; }

    }

    public class EventCopyBase
    {
        public int EventID { get; set; }
        public int EventCopyID { get; set; }

        public string Media { get; set; }
        public string MediaLabledAs { get; set; }
        public string IncidentNumber { get; set; }
        public string OriginalHeldBy { get; set; }
        public string OriginalSaved { get; set; }

        public string Other { get; set; }

    }
    public class PictureBase
    {
        public int EventMediaID { get; set; }

        public int Media { get; set; }
        public int EventID { get; set; }
        public DataTable BanTypeTable { get; set; }
        public string Description { get; set; }

        public string Details { get; set; }

    }
    public class EventReviewBase
    {
        public int EventID { get; set; }
        public int EventReviewID { get; set; }

        public int ItemNumber { get; set; }
        public string Replaced { get; set; }
        public string Reason { get; set; }
        public string Description { get; set; }
        public string ReviewFrom { get; set; }
        public DataTable ReviewTable { get; set; }
        public string ReviewTo { get; set; }

    }
    public class DispatcherBase
    {
        public int EventID { get; set; }
        public int CallID { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string DispatcherID { get; set; }
        public string CallTakerID { get; set; }
     
        public string Area { get; set; }
  
        public string ScheduledTime { get; set; }
     
        public string Priority { get; set; }
     
        public string Units { get; set; }


    }
    public class AtachEventBase
    {
        public int EventID { get; set; }
   
        public string EventNumber { get; set; }
 
        public string AttachedEvent { get; set; }
    }

    public class EventPermissionModel
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public int EventID { get; set; }
        public int CreatedBy { get; set; }
        public string EventAccessType { get; set; }
        public bool EventAccessPermission { get; set; }
        public bool EventView { get; set; }
        public bool EventDelete { get; set; }
        public bool EventEdit { get; set; }
    }
}
