using CIMS.BaseLayer.Events;
using CIMS.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CIMS.DataLayer.Events
{
    public class EventDL
    {
        #region Declaration

        DataTable dtContainer;
        DataSet dsContainer;
        #endregion

        #region Method Codes_LoadByPart
        public DataTable Codes_LoadByPart(EventBase EventBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Part", EventBase.Part)
                                        };
                Common.Set_Procedures("Codes_LoadByPart");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion
        #region Method EventFilter_print
        public DataTable EventFilter_print(EventBase EventBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                             new MyParameter("@sortValue", EventBase.sortValue),
                                           new MyParameter("@datacolumn", EventBase.datacolumn),
                                            new MyParameter("@EventID", EventBase.EventID)
                                        };
                Common.Set_Procedures("EventFilter_print");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion
        #region Method EventData_LoadById
        public DataTable EventData_LoadById(EventBase EventBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@EventID", EventBase.EventID)
                                        };
                Common.Set_Procedures("EventData_LoadById");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion
        #region Method MediaCopy_LoadByID
        public DataTable MediaCopy_LoadByID(EventCopyBase EventBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@EventID", EventBase.EventID)
                                        };
                Common.Set_Procedures("MediaCopy_LoadByID");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion
        #region Method EventPicture_LoadByEventID
        public DataTable EventPicture_LoadByEventID(PictureBase EventBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@EventID", EventBase.EventID)
                                        };
                Common.Set_Procedures("EventPicture_LoadByEventID");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion
        #region Method Review_LoadById
        public DataTable Review_LoadById(EventReviewBase EventBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@EventID", EventBase.EventID)
                                        };
                Common.Set_Procedures("Review_LoadById");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion
        #region Method NatureCodes_LoadAll
        public DataTable NatureCodes_LoadAll()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={

                                        };
                Common.Set_Procedures("NatureCodes_LoadAll");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion
        #region Method EventNumber_LoadAll
        public DataTable EventNumber_LoadAll()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={

                                        };
                Common.Set_Procedures("EventNumber_LoadAll");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion
        #region Method DispatchUnitCodes_LoadAll
        public DataTable DispatchUnitCodes_LoadAll()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={

                                        };
                Common.Set_Procedures("DispatchUnitCodes_LoadAll");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method DispatchAreas_LoadAll
        public DataTable DispatchAreas_LoadAll()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={

                                        };
                Common.Set_Procedures("DispatchAreas_LoadAll");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion
        #region Method Events_IU
        public DataTable Events_IU(EventBase EventBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={   new MyParameter("@EventID", EventBase.EventID),
                                            new MyParameter("@EventDate", EventBase.EventDate),

                                           new MyParameter("@EventTime", EventBase.EventTime),
                                           new MyParameter("@FromCode", EventBase.FromCode),
                                           new MyParameter("@NatureCode", EventBase.NatureCode),
                                           new MyParameter("@NatureDesc", EventBase.NatureDesc),
                                             new MyParameter("@DutyDesc", EventBase.DutyDesc),
                                           new MyParameter("@Camera", EventBase.Camera),
                                           new MyParameter("@Comments", EventBase.Comments),
                                           new MyParameter("@UserID", EventBase.UserID),
                                           new MyParameter("@CreatedBy", EventBase.CreatedBy),
                                           new MyParameter("@KeyEvent", EventBase.KeyEvent),
                                           new MyParameter("@FromForm", EventBase.FromForm),
                                           new MyParameter("@FromNumber", EventBase.FromNumber),
                                           new MyParameter("@RoleName", EventBase.RoleName),
                                           new MyParameter("@UD20 ", EventBase.UD20),
                                           new MyParameter("@UD21", EventBase.UD21),
                                           new MyParameter("@UD22", EventBase.UD22),
                                           new MyParameter("@UD23", EventBase.UD23),
                                           new MyParameter("@UD24 ", EventBase.UD24),
                                           new MyParameter("@UD25", EventBase.UD25),
                                           new MyParameter("@Location", EventBase.Location),
                                           new MyParameter("@EndTime", EventBase.EndTime),
                                           new MyParameter("@Site", EventBase.Site)


                                        };
                Common.Set_Procedures("Events_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion
        #region Method Event_LoadById
        public DataTable Event_LoadById(EventBase model)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={

                     new MyParameter("@UserID", model.UserID)
                    ,new MyParameter("@ReportAccessRole", model.RoleID)
                                        };
                Common.Set_Procedures("Event_LoadById");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }

        public DataTable EventSubjectLink_Load(EventBase model)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={

                     new MyParameter("@UserID", model.UserID)
                     ,new MyParameter("@SubjectID", model.SubjectID)
                     ,new MyParameter("@IncidentID", model.IncidentID)
                    ,new MyParameter("@ReportAccessRole", model.RoleID)
                                        };
                Common.Set_Procedures("EventSubjectLink_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }

        public DataTable EventEmployeeLink_Load(EventBase model)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={

                     new MyParameter("@UserID", model.UserID)
                     ,new MyParameter("@EmployeeID", model.EmployeeID)
                     ,new MyParameter("@IncidentID", model.IncidentID)
                    ,new MyParameter("@ReportAccessRole", model.RoleID)
                                        };
                Common.Set_Procedures("EventEmployeeLink_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }

        public DataTable EventGeneralReportsLink_Load(EventBase model)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={

                     new MyParameter("@UserID", model.UserID)
                     ,new MyParameter("@ReportID", model.ReportID)
                    ,new MyParameter("@ReportAccessRole", model.RoleID)
                                        };
                Common.Set_Procedures("EventGeneralReportsLink_Load");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }

        #endregion
        #region Event_DeleteById
        public DataTable Event_DeleteById(EventBase EventBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@EventID", EventBase.EventID)
                                         };
                Common.Set_Procedures("Event_DeleteById");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion
        #region EventPicture_DeleteById
        public DataTable EventPicture_DeleteById(PictureBase EventBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@EventMediaID", EventBase.EventMediaID)
                                         };
                Common.Set_Procedures("EventPicture_DeleteById");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion
        #region EventReview_DeleteById
        public DataTable EventReview_DeleteById(EventReviewBase EventBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@EventReviewID", EventBase.EventReviewID)
                                         };
                Common.Set_Procedures("EventReview_DeleteById");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                ErrorReporting.DataLayerError(ex);
            }
            return dtContainer;
        }
        #endregion
        #region Method EventMedia_IU
        public DataTable EventMedia_IU(PictureBase PictureBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@EventMediaID", PictureBase.EventMediaID),
                                           new MyParameter("@EventID", PictureBase.EventID),
                                            new MyParameter("@Details", PictureBase.Details),
                                           new MyParameter("@BanTypeTable", PictureBase.BanTypeTable),
                                             new MyParameter("@MediaID", PictureBase.Media)

                                        };
                Common.Set_Procedures("EventMedia_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion
        #region Method EventReview_I
        public DataTable EventReview_I(EventReviewBase PictureBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={

                                           new MyParameter("@EventID", PictureBase.EventID),
                                            new MyParameter("@Description", PictureBase.Description),
                                           new MyParameter("@ReviewTable", PictureBase.ReviewTable),
                                             new MyParameter("@ReviewID", PictureBase.EventReviewID),
                                            new MyParameter("@ItemNumber", PictureBase.ItemNumber),
                                           new MyParameter("@ReplacedBy", PictureBase.Replaced),
                                              new MyParameter("@FromHoursMinutes", PictureBase.ReviewFrom),
                                            new MyParameter("@ToHoursMinutes", PictureBase.ReviewTo),
                                           new MyParameter("@Reason", PictureBase.Reason),

                                        };
                Common.Set_Procedures("EventReview_I");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion
        #region Method MediaCopy_IU
        public DataTable MediaCopy_IU(EventCopyBase PictureBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                  new MyParameter("@MediaNumbers", PictureBase.Media),
                                           new MyParameter("@MediaLabel", PictureBase.MediaLabledAs),
                                            new MyParameter("@IncidentNumber", PictureBase.IncidentNumber),
                                           new MyParameter("@OriginalsHeldBy", PictureBase.OriginalHeldBy),
                                             new MyParameter("@SentToOther", PictureBase.Other),
                  new MyParameter("@OriginalsSaved ", PictureBase.OriginalSaved),
                    new MyParameter("@EventID  ", PictureBase.EventID)

                                        };
                Common.Set_Procedures("MediaCopy_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion
        #region Method AttachEvent_U
        public DataTable AttachEvent_U(AtachEventBase PictureBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                  new MyParameter("@EventNumber", PictureBase.EventNumber),
                                           new MyParameter("@AttachedEvent", PictureBase.AttachedEvent),


                    new MyParameter("@EventID ", PictureBase.EventID)

                                        };
                Common.Set_Procedures("AttachEvent_U");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion
        #region Method Dispatch_IU
        public DataTable Dispatch_IU(DispatcherBase PictureBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                  new MyParameter("@EventID", PictureBase.EventID),
                                           new MyParameter("@StartTime", PictureBase.StartTime),
                                            new MyParameter("@EndTime", PictureBase.EndTime),
                                           new MyParameter("@AreaID ", PictureBase.Area),
                                             new MyParameter("@Priority", PictureBase.Priority),
                  new MyParameter("@HoldForUnit", PictureBase.Units),
                    new MyParameter("@CallTakerID", PictureBase.CallTakerID),
                      new MyParameter("@DispatcherID", PictureBase.DispatcherID),
                        new MyParameter("@ScheduledTime", PictureBase.ScheduledTime)

                                        };
                Common.Set_Procedures("Dispatch_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion


        // Reports
        //Events
        #region Method Events_print
        public DataTable Events_print(EventBase EventBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                             new MyParameter("@sortValue", EventBase.sortValue),
                                           new MyParameter("@datacolumn", EventBase.datacolumn)
                                        };
                Common.Set_Procedures("Events_print");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method NatureCodes_LoadByID
        public DataTable NatureCodes_LoadByID(CIMS.BaseLayer.Setting.NatureEventBase eventBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", eventBase.ID)
                                        };
                Common.Set_Procedures("NatureCodes_LoadByID");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method Event_SubjectReportLink
        public DataTable Link_SubjectReport(eventsubjectreport objreport)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@EventID", objreport.eventid),
                                           new MyParameter("@SubjectID", objreport.subjectid),
                                           new MyParameter("@IncidentID", objreport.incidentid),
                                        };
                Common.Set_Procedures("EventSubjectReportLink_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        public DataTable Link_SubjectReportDelete(int EventID)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={ new MyParameter("@EventID", EventID)};
                Common.Set_Procedures("EventSubjectReportLink_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method Event_EmployeeReportLink
        public DataTable Link_EmployeeReport(eventemployeereport objreport)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@EventID", objreport.eventid),
                                           new MyParameter("@EmployeeID", objreport.employeeid),
                                           new MyParameter("@IncidentID", objreport.incidentid),
                                        };
                Common.Set_Procedures("EventEmployeeReportLink_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        public DataTable Link_EmployeeReportDelete(int EventID)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = { new MyParameter("@EventID", EventID) };
                Common.Set_Procedures("EventEmployeeReportLink_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method Event_GeneralReportLink
        public DataTable Link_GeneralReport(eventgeneralreport objreport)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@EventID", objreport.eventid),
                                           new MyParameter("@ReportID", objreport.reportid),
                                        };
                Common.Set_Procedures("EventGeneralReportLink_IU");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        public DataTable Link_GeneralReportDelete(int EventID)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = { new MyParameter("@EventID", EventID) };
                Common.Set_Procedures("EventGeneralReportLink_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method permission load by eventid
        public DataTable Permission_LoadByEventID(int EventID)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@EventID", EventID)
                                        };
                Common.Set_Procedures("EventPermission_LoadById");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method UsersEventsAccess_Bind
        public DataTable UsersEventsAccess_Bind(EventPermissionModel model)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();

            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@UserID", model.UserID),
                                            new MyParameter("@EventID", model.EventID)
                                        };

                Common.Set_Procedures("UsersEventsAccess_Bind");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);

                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtContainer;
        }
        #endregion

        #region Method AddUsersEventsAccess
        public DataTable AddUsersEventsAccess(EventPermissionModel model)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@EventID", model.EventID),
                                            new MyParameter("@EventAccessBy", model.UserID),
                                            new MyParameter("@CreatedBy", model.CreatedBy)
                                        };

                Common.Set_Procedures("AddUsersEventsAccess");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);

                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }

        public bool AddAll_UsersAndRoles_EventsAccess(EventPermissionModel model)
        {
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@EventID", model.EventID),
                                             new MyParameter("@CreatedBy", model.CreatedBy)
                                        };

                Common.Set_Procedures("AddAll_UsersAndRoles_EventsAccess");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);

                return Common.Execute_Procedure();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Method RemoveUsersEventsAccess
        public DataTable RemoveUsersEventsAccess(EventPermissionModel model)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@ID", model.ID)
                                        };

                Common.Set_Procedures("RemoveUsersEventsAccess");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);

                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method EventsAccessUsers_Bind
        public DataTable EventsAccessUsers_Bind(EventPermissionModel model)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@UserID", model.UserID),
                                            new MyParameter("@EventID", model.EventID)
                                        };
                Common.Set_Procedures("EventsAccessUsers_Bind");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method EventsAccessPermission
        public DataTable EventsAccessPermission(EventPermissionModel model)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", model.ID),
                                            new MyParameter("@EventID", model.EventID),
                                            new MyParameter("@Type", model.EventAccessType),
                                            new MyParameter("@Permission", model.EventAccessPermission),
                                        };
                Common.Set_Procedures("EventsAccessPermission");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method EventsAccessPermission_ByUser
        public DataTable EventsAccessPermission_ByUser(EventPermissionModel model)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", model.ID),
                                           new MyParameter("@EventID", model.EventID)
                                        };
                Common.Set_Procedures("EventsAccessPermission_ByUser");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method UsersEventsAccessRole
        public DataTable UsersEventsAccessRole(EventPermissionModel model)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@EventID", model.EventID)
                                        };
                Common.Set_Procedures("UsersEventsAccessRole");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method AddRolesEventsAccess
        public DataTable AddRolesEventsAccess(EventPermissionModel model)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@EventID", model.EventID),
                                            new MyParameter("@EventAccessRole", model.RoleID),
                                             new MyParameter("@CreatedBy", model.CreatedBy)
                                        };
                Common.Set_Procedures("AddRolesEventsAccess");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method RemoveRolesEventsAccess
        public DataTable RemoveRolesEventsAccess(EventPermissionModel model)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@ID", model.ID)
                                        };
                Common.Set_Procedures("RemoveRolesEventsAccess");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method EventsAccessRoles_Bind
        public DataTable EventsAccessRoles_Bind(EventPermissionModel model)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@UserID", model.UserID),
                                           new MyParameter("@EventID", model.EventID)
                                        };
                Common.Set_Procedures("EventsAccessRoles_Bind");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method EventsAccessPermissionByRole
        public DataTable EventsAccessPermissionByRole(EventPermissionModel model)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", model.ID),
                                            new MyParameter("@EventID", model.EventID),
                                            new MyParameter("@Type", model.EventAccessType),
                                            new MyParameter("@Permission", model.EventAccessPermission),
                                        };
                Common.Set_Procedures("EventsAccessPermissionByRole");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method EventsAccessPermission_ByRole
        public DataTable EventsAccessPermission_ByRole(EventPermissionModel model)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", model.ID),
                                           new MyParameter("@EventID", model.EventID)
                                        };
                Common.Set_Procedures("EventsAccessPermission_ByRole");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method EventPermissionCheck_User
        public DataTable EventPermissionCheck_User(EventPermissionModel reportsBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@EventID", reportsBase.EventID),
                                            new MyParameter("@EventAccessBy", reportsBase.UserID)
                                             ,new MyParameter("@EventAccessRole", reportsBase.RoleID)
                                        };
                Common.Set_Procedures("EventPermissionCheck_User");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion
    }
}
