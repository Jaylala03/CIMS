using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CIMS.Models
{

    public class EventModel
    {
        public int EventID { get; set; }

        [Required(ErrorMessage = "Event Date is required")]
        public string EventDate { get; set; }
        public int EventNumber { get; set; }
        public int AttachedEvent { get; set; }

        [Required(ErrorMessage = "Event Time is required")]
        public string EventTime { get; set; }
        public string FromCode { get; set; }
        public string NatureCode { get; set; }

        public string NatureCodeName { get; set; }
        public string NatureDesc { get; set; }
        public string Comments { get; set; }
        public string DutyDesc { get; set; }
        public string UserID { get; set; }
        public int CreatedBy { get; set; }
        public string Camera { get; set; }

        public bool KeyEvent { get; set; }
        public string FromForm { get; set; }
        public string FromNumber { get; set; }
        public string RoleName { get; set; }

        public string UD20 { get; set; }

        public string Location { get; set; }
        //[Required(ErrorMessage = "End Time is required")]
        public string EndTime { get; set; }

        public string Site { get; set; }

        public string UD25 { get; set; }

        public string UD24 { get; set; }

        public string UD23 { get; set; }

        public string UD22 { get; set; }
        public PictureModel PictureModel { get; set; }
        public EventDescription EventDescription { get; set; }
        public string UD21 { get; set; }
        public AtachEvent AtachEvent { get; set; }
        public Dispatcher Dispatcher { get; set; }
        public EventReviewModel EventReviewModel { get; set; }
        public EventCopyModel EventCopyModel { get; set; }
        public List<EventModel> ListSotrEventModel = new List<EventModel>();
        public List<EventModel> ListEventModel = new List<EventModel>();
        public List<PictureModel> ListPictureModel = new List<PictureModel>();
        public List<SelectListItem> InitiatedByList = new List<SelectListItem>();
        public List<SelectListItem> EventCodeList = new List<SelectListItem>();
        public List<SelectListItem> LocationList = new List<SelectListItem>();
        public List<EventDescription> EventDescriptionList = new List<EventDescription>();
        public List<EventReviewModel> EventDescriptionList1 = new List<EventReviewModel>();
        public List<SelectListItem> DispatchList = new List<SelectListItem>();
        public List<SelectListItem> DispatchUnitCodesList = new List<SelectListItem>();
        public List<SelectListItem> DispatchPriorityList = new List<SelectListItem>();
        public List<SelectListItem> AttachedEventList = new List<SelectListItem>();

        public string FilePath { get; set; }
        public bool isLinkedEvent { get; set; }
    }
    public class PictureModel
    {
        public int EventMediaID { get; set; }


        public int EventID { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        public string Details { get; set; }

    }
    public class EventDescription
    {
        public int Id { get; set; }
        public string DescriptionEvent { get; set; }

    }
    public class EventCopyModel
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

    public class EventReviewModel
    {
        public int EventID { get; set; }
        public int EventReviewID { get; set; }

        public int ItemNumber { get; set; }
        public string Replaced { get; set; }
        public string Reason { get; set; }
        public string Description { get; set; }
        public string ReviewFrom { get; set; }

        public string ReviewTo { get; set; }

    }

    public class EventReviewTableModel
    {
        public int EventID { get; set; }
        public int EventReviewID { get; set; }

        public int Number { get; set; }
        public string Replaced { get; set; }
        public string Reason { get; set; }
        public string Description { get; set; }
        public string ReviewFrom { get; set; }

        public string ReviewTo { get; set; }

    }

    public class Dispatcher
    {
        public int EventID { get; set; }

        public int CallID { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string DispatcherID { get; set; }
        public string CallTakerID { get; set; }
        [Required(ErrorMessage = "Area is required")]
        public string Area { get; set; }
        [Required(ErrorMessage = "Scheduled Time is required")]
        public string ScheduledTime { get; set; }
        [Required(ErrorMessage = "Priority is required")]
        public string Priority { get; set; }
        [Required(ErrorMessage = "Units is required")]
        public string Units { get; set; }


    }

    public class AtachEvent
    {
        public int EventID { get; set; }
        [Required(ErrorMessage = "Event Number is required")]
        public string EventNumber { get; set; }
        [Required(ErrorMessage = "Attached Event is required")]
        public string AttachedEvent { get; set; }
    }

    public class EventPermissionViewModel
    {
        public int EventID { get; set; }
        public int CreatedBy { get; set; }
        public string EventCreatorUser { get; set; }
        public string EventCreatorFirstName { get; set; }
        public string EventCreatorLastName { get; set; }
        public string EventCreateDate { get; set; }
        public bool EventCreatorView { get; set; }
        public bool EventCreatorEdit { get; set; }
        public bool EventCreatorDelete { get; set; }
        public string LogoFirstName { get; set; }
        public string LogoMiddleName { get; set; }
        public string LogoLastName { get; set; }
    }

    
}