using CIMS.BaseLayer;
using CIMS.BaseLayer.Events;
using CIMS.DataLayer.Events;
using CIMS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.ActionLayer.Events
{
    public class EventAction
    {
        #region Declaration
        EventDL EventDL = new EventDL();
        ActionResult actionResult = new ActionResult();
        #endregion

        #region Method Codes_LoadByPart
        public ActionResult Codes_LoadByPart(EventBase EventBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.Codes_LoadByPart(EventBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion

        #region Method EventFilter_print
        public ActionResult EventFilter_print(EventBase EventBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.EventFilter_print(EventBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion
        #region Method EventData_LoadById
        public ActionResult EventData_LoadById(EventBase EventBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.EventData_LoadById(EventBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion
        #region Method MediaCopy_LoadByID
        public ActionResult MediaCopy_LoadByID(EventCopyBase EventBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.MediaCopy_LoadByID(EventBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion
        #region Method EventPicture_LoadByEventID
        public ActionResult EventPicture_LoadByEventID(PictureBase EventBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.EventPicture_LoadByEventID(EventBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion
        #region Method Review_LoadById
        public ActionResult Review_LoadById(EventReviewBase EventBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.Review_LoadById(EventBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion
        #region Method NatureCodes_LoadAll
        public ActionResult NatureCodes_LoadAll()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.NatureCodes_LoadAll();
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion
        #region Method EventNumber_LoadAll
        public ActionResult EventNumber_LoadAll()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.EventNumber_LoadAll();
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion
        #region Method DispatchAreas_LoadAll
        public ActionResult DispatchAreas_LoadAll()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.DispatchAreas_LoadAll();
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion
        #region Method DispatchUnitCodes_LoadAll
        public ActionResult DispatchUnitCodes_LoadAll()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.DispatchUnitCodes_LoadAll();
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion
        #region Method Events_IU
        public ActionResult Events_IU(EventBase EventBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.Events_IU(EventBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion
        #region Method Event_LoadById
        public ActionResult Event_LoadById(EventBase model)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.Event_LoadById(model);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }

        public ActionResult EventSubjectLink_Load(EventBase model)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.EventSubjectLink_Load(model);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }

        public ActionResult EventEmployeeLink_Load(EventBase model)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.EventEmployeeLink_Load(model);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }

        public ActionResult EventGeneralReportsLink_Load(EventBase model)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.EventGeneralReportsLink_Load(model);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }

        #endregion
        #region Event_DeleteById
        public ActionResult Event_DeleteById(EventBase EventBase)
        {
            try
            {
                actionResult.dtResult = EventDL.Event_DeleteById(EventBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion
        #region EventPicture_DeleteById
        public ActionResult EventPicture_DeleteById(PictureBase EventBase)
        {
            try
            {
                actionResult.dtResult = EventDL.EventPicture_DeleteById(EventBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion
        #region EventReview_DeleteById
        public ActionResult EventReview_DeleteById(EventReviewBase EventBase)
        {
            try
            {
                actionResult.dtResult = EventDL.EventReview_DeleteById(EventBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion
        #region Method EventMedia_IU
        public ActionResult EventMedia_IU(PictureBase PictureBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.EventMedia_IU(PictureBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion

        #region Method EventReview_I
        public ActionResult EventReview_I(EventReviewBase PictureBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.EventReview_I(PictureBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion

        #region Method MediaCopy_IU
        public ActionResult MediaCopy_IU(EventCopyBase PictureBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.MediaCopy_IU(PictureBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion
        #region Method Dispatch_IU
        public ActionResult Dispatch_IU(DispatcherBase PictureBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.Dispatch_IU(PictureBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion

        #region Method AttachEvent_U
        public ActionResult AttachEvent_U(AtachEventBase PictureBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.AttachEvent_U(PictureBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion

        // Reports
        //Events
        #region Method Events_print
        public ActionResult Events_print(EventBase EventBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.Events_print(EventBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion

        #region NatureCodes_LoadByID
        public ActionResult NatureCodes_LoadByID(CIMS.BaseLayer.Setting.NatureEventBase eventBase)
        {
            try
            {
                actionResult.dtResult = EventDL.NatureCodes_LoadByID(eventBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion

        #region Method Link_SubjectReport
        public ActionResult Link_SubjectReport(eventsubjectreport objreport)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.Link_SubjectReport(objreport);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        public ActionResult Link_SubjectReportDelete(int EventID)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.Link_SubjectReportDelete(EventID);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion

        #region Method Link_EmployeeReport
        public ActionResult Link_EmployeeReport(eventemployeereport objreport)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.Link_EmployeeReport(objreport);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        public ActionResult Link_EmployeeReportDelete(int EventID)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.Link_EmployeeReportDelete(EventID);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion

        #region Method Link_GeneralReport
        public ActionResult Link_GeneralReport(eventgeneralreport objreport)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.Link_GeneralReport(objreport);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        public ActionResult Link_GeneralReportDelete(int EventID)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.Link_GeneralReportDelete(EventID);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion

        #region Method permission load by eventid
        public ActionResult Permission_LoadByEventID(int EventID)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.Permission_LoadByEventID(EventID);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion

        #region Method UsersEventsAccess_Bind

        public ActionResult UsersEventsAccess_Bind(EventPermissionModel model)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.UsersEventsAccess_Bind(model);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }

        #endregion

        #region Method AddUsersEventsAccess
        public ActionResult AddUsersEventsAccess(EventPermissionModel model)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.AddUsersEventsAccess(model);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        public ActionResult AddAll_UsersAndRoles_EventsAccess(EventPermissionModel model)
        {
            actionResult = new ActionResult();

            try
            {
                actionResult.IsSuccess = EventDL.AddAll_UsersAndRoles_EventsAccess(model);
            }
            catch (Exception ex)
            {
                actionResult.IsSuccess = false;
                throw ex;
            }
            return actionResult;
        }
        #endregion

        #region Method RemoveUsersEventsAccess
        public ActionResult RemoveUsersEventsAccess(EventPermissionModel model)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.RemoveUsersEventsAccess(model);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion

        #region Method EventsAccessUsers_Bind
        public ActionResult EventsAccessUsers_Bind(EventPermissionModel model)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.EventsAccessUsers_Bind(model);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion

        #region Method EventsAccessPermission
        public ActionResult EventsAccessPermission(EventPermissionModel model)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.EventsAccessPermission(model);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return actionResult;
        }
        #endregion

        #region Method EventsAccessPermission_ByUser
        public ActionResult EventsAccessPermission_ByUser(EventPermissionModel model)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.EventsAccessPermission_ByUser(model);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return actionResult;
        }
        #endregion

        #region Method UsersEventsAccessRole
        public ActionResult UsersEventsAccessRole(EventPermissionModel model)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.UsersEventsAccessRole(model);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return actionResult;
        }
        #endregion

        #region Method AddRolesEventsAccess
        public ActionResult AddRolesEventsAccess(EventPermissionModel model)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.AddRolesEventsAccess(model);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion

        #region Method RemoveRolesEventsAccess
        public ActionResult RemoveRolesEventsAccess(EventPermissionModel model)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.RemoveRolesEventsAccess(model);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion

        #region Method EventsAccessRoles_Bind
        public ActionResult EventsAccessRoles_Bind(EventPermissionModel model)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.EventsAccessRoles_Bind(model);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion

        #region Method EventsAccessPermissionByRole
        public ActionResult EventsAccessPermissionByRole(EventPermissionModel model)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.EventsAccessPermissionByRole(model);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return actionResult;
        }
        #endregion

        #region Method EventsAccessPermission_ByRole
        public ActionResult EventsAccessPermission_ByRole(EventPermissionModel model)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = EventDL.EventsAccessPermission_ByRole(model);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return actionResult;
        }
        #endregion

        #region EventPermissionCheck_User
        public ActionResult EventPermissionCheck_User(EventPermissionModel reportsBase)
        {
            try
            {
                actionResult.dtResult = EventDL.EventPermissionCheck_User(reportsBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
                else
                {
                    actionResult.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion
    }
}
