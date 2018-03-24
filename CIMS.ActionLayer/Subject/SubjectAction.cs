using CIMS.BaseLayer;
using CIMS.BaseLayer.Events;
using CIMS.BaseLayer.Subject;
using CIMS.DataLayer.Subject;
using CIMS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.ActionLayer.Subject
{
    public class SubjectAction
    {
        #region Declaration
        SubjectDL subjectDL = new SubjectDL();
        ActionResult actionResult = new ActionResult();
        #endregion

        
        #region Subject
        #region Subject_IU
        public ActionResult Subject_IU(SubjectBase subjectBase)
        {
            try
            {
                actionResult.dtResult = subjectDL.Subject_IU(subjectBase);
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

        #region Subjects_LoadAll
        public ActionResult Subjects_LoadAll(SubjectBase model)
        {
            try
            {
                actionResult.dtResult = subjectDL.Subjects_LoadAll(model);
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

        #region Subject_LoadById
        public ActionResult Subject_LoadById(SubjectBase subjectBase)
        {
            try
            {
                actionResult.dtResult = subjectDL.Subject_LoadById(subjectBase);
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

        #region SubjectIDMax_Load
        public ActionResult SubjectIDMax_Load()
        {
            try
            {
                actionResult.dtResult = subjectDL.SubjectIDMax_Load();
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

        #region Subject_DeleteById
        public ActionResult Subject_DeleteById(SubjectBase subjectBase)
        {
            try
            {
                actionResult.dtResult = subjectDL.Subject_DeleteById(subjectBase);
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
        #endregion

        #region Subject Address
        #region SubjectAddress_InsertUpdate
        public ActionResult SubjectAddress_InsertUpdate(SubjectAddressBase addressBase)
        {
            try
            {
                actionResult.dtResult = subjectDL.SubjectAddress_InsertUpdate(addressBase);
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

        #region SubjectAddress_LoadById
        public ActionResult SubjectAddress_LoadById(SubjectAddressBase addressBase)
        {
            try
            {
                actionResult.dtResult = subjectDL.SubjectAddress_LoadById(addressBase);
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

        #region SubjectAddress_LoadBySubjectId
        public ActionResult SubjectAddress_LoadBySubjectId(SubjectAddressBase addressBase)
        {
            try
            {
                actionResult.dtResult = subjectDL.SubjectAddress_LoadBySubjectId(addressBase);
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

        #region SubjectAddress_DeleteById
        public ActionResult SubjectAddress_DeleteById(SubjectAddressBase addressBase)
        {
            try
            {
                actionResult.dtResult = subjectDL.SubjectAddress_DeleteById(addressBase);
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
        #endregion

        #region Subject Alias
        #region SubjectAlias_InsertUpdate
        public ActionResult SubjectAlias_InsertUpdate(SubjectAliasBase aliasBase)
        {
            try
            {
                actionResult.dtResult = subjectDL.SubjectAlias_InsertUpdate(aliasBase);
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

        #region SubjectAlias_LoadById
        public ActionResult SubjectAlias_LoadById(SubjectAliasBase aliasBase)
        {
            try
            {
                actionResult.dtResult = subjectDL.SubjectAlias_LoadById(aliasBase);
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

        #region SubjectAlias_LoadBySubjectId
        public ActionResult SubjectAlias_LoadBySubjectId(SubjectAliasBase aliasBase)
        {
            try
            {
                actionResult.dtResult = subjectDL.SubjectAlias_LoadBySubjectId(aliasBase);
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

        #region SubjectAlias_DeleteById
        public ActionResult SubjectAlias_DeleteById(SubjectAliasBase aliasBase)
        {
            try
            {
                actionResult.dtResult = subjectDL.SubjectAlias_DeleteById(aliasBase);
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
        #endregion

        #region Subject Mark
        #region SubjectMark_InsertUpdate
        public ActionResult SubjectMark_InsertUpdate(SubjectFeaturesBase featureBase)
        {
            try
            {
                actionResult.dtResult = subjectDL.SubjectMark_InsertUpdate(featureBase);
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

        #region SubjectMarks_LoadById
        public ActionResult SubjectMarks_LoadById(SubjectFeaturesBase featureBase)
        {
            try
            {
                actionResult.dtResult = subjectDL.SubjectMarks_LoadById(featureBase);
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

        #region SubjectMarks_LoadBySubjectId
        public ActionResult SubjectMarks_LoadBySubjectId(SubjectFeaturesBase featureBase)
        {
            try
            {
                actionResult.dtResult = subjectDL.SubjectMarks_LoadBySubjectId(featureBase);
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

        #region SubjectMarks_DeleteById
        public ActionResult SubjectMarks_DeleteById(SubjectFeaturesBase featureBase)
        {
            try
            {
                actionResult.dtResult = subjectDL.SubjectMarks_DeleteById(featureBase);
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
        #endregion

        #region Subject Linked
        #region SubjectLinked_InsertUpdate
        public ActionResult SubjectLinked_InsertUpdate(SubjectLinkedBase linkBase)
        {
            try
            {
                actionResult.dtResult = subjectDL.SubjectLinked_InsertUpdate(linkBase);
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

        #region SubjectLinked_LoadById
        public ActionResult SubjectLinked_LoadById(SubjectLinkedBase linkBase)
        {
            try
            {
                actionResult.dtResult = subjectDL.SubjectLinked_LoadById(linkBase);
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
        #region SubjectLinked_LoadByIncidentId
        public ActionResult SubjectLinked_LoadByIncidentId(IncidentLinkedBase linkBase)
        {
            try
            {
                actionResult.dtResult = subjectDL.SubjectLinked_LoadByIncidentId(linkBase);
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

        #region SubjectLinked_LoadBySubjectId
        public ActionResult SubjectLinked_LoadBySubjectId(SubjectLinkedBase linkBase)
        {
            try
            {
                actionResult.dtResult = subjectDL.SubjectLinked_LoadBySubjectId(linkBase);
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
        #region SubjectLinked_LoadBySubjectId_IncidentID
        public ActionResult SubjectLinked_LoadBySubjectId_IncidentID(IncidentLinkedBase linkBase)
        {
            try
            {
                actionResult.dtResult = subjectDL.SubjectLinked_LoadBySubjectId_IncidentID(linkBase);
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

        #region Method SubjectIncidentProofRead_LoadBySubjectID
        public ActionResult SubjectIncidentProofRead_LoadBySubjectID(SubjectIncidentsBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.SubjectIncidentProofRead_LoadBySubjectID(subject);
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

        #region SubjectLinked_DeleteById
        public ActionResult SubjectLinked_DeleteById(SubjectLinkedBase linkBase)
        {
            try
            {
                actionResult.dtResult = subjectDL.SubjectLinked_DeleteById(linkBase);
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

        #endregion

        #region Subject Identification
        #region SubjectIdentification_InsertUpdate
        public ActionResult SubjectIdentification_InsertUpdate(SubjectIdentificationBase identificationBase)
        {
            try
            {
                actionResult.dtResult = subjectDL.SubjectIdentification_InsertUpdate(identificationBase);
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

        #region SubjectIdentification_LoadBySubjectId
        public ActionResult SubjectIdentification_LoadBySubjectId(SubjectIdentificationBase identificationBase)
        {
            try
            {
                actionResult.dtResult = subjectDL.SubjectIdentification_LoadBySubjectId(identificationBase);
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

        #region Get_NextLCTIDSequential
        public ActionResult Get_NextLCTIDSequential()
        {
            try
            {
                actionResult.dtResult = subjectDL.Get_NextLCTIDSequential();
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
        #endregion

        #region Watch
        #region WatchName_InsertUpdate
        public ActionResult WatchName_InsertUpdate(WatchBase watchBase)
        {
            try
            {
                actionResult.dtResult = subjectDL.WatchName_InsertUpdate(watchBase);
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

        #region WatchName_DeleteById
        public ActionResult WatchName_DeleteById(WatchBase watchBase)
        {
            try
            {
                actionResult.dtResult = subjectDL.WatchName_DeleteById(watchBase);
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

        #region WatchName_LoadById
        public ActionResult WatchName_LoadById(WatchBase watchBase)
        {
            try
            {
                actionResult.dtResult = subjectDL.WatchName_LoadById(watchBase);
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

        #region WatchList_LoadAll
        public ActionResult WatchList_LoadAll()
        {
            try
            {
                actionResult.dtResult = subjectDL.WatchList_LoadAll();
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
        #endregion

        #region SubjectWatch
        #region SubjectWatch_InsertUpdate
        public ActionResult SubjectWatch_InsertUpdate(SubjectWatchListBase subWatchBase)
        {
            try
            {
                actionResult.dtResult = subjectDL.SubjectWatch_InsertUpdate(subWatchBase);
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

        #region SubjectWatch_LoadBySubjectId
        public ActionResult SubjectWatch_LoadBySubjectId(SubjectWatchListBase subWatchBase)
        {
            try
            {
                actionResult.dtResult = subjectDL.SubjectWatch_LoadBySubjectId(subWatchBase);
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

        #endregion

        #region Codes_LoadAll
        public ActionResult Codes_LoadAll()
        {
            try
            {
                actionResult.dtResult = subjectDL.Codes_LoadAll();
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

        #region IncidentNatureOfEvent_LoadAll
        public ActionResult IncidentNatureOfEvent_LoadAll()
        {
            try
            {
                actionResult.dtResult = subjectDL.IncidentNatureOfEvent_LoadAll();
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

        #region IncidentTypeDescription_LoadByEventName
        public ActionResult IncidentTypeDescription_LoadByEventName(SubjectBase subjectBase)
        {
            try
            {
                actionResult.dtResult = subjectDL.IncidentTypeDescription_LoadByEventName(subjectBase);
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

        #region SearchSubject
        public ActionResult SearchSubject(SubjectBase subjectBase)
        {
            try
            {
                actionResult.dtResult = subjectDL.SearchSubject(subjectBase);
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

        #region CombineSubject
        public ActionResult CombineSubject(SubjectBase subjectBase)
        {
            try
            {
                actionResult.dtResult = subjectDL.CombineSubject(subjectBase);
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


        #region Incidents_InsertUpdate

        public ActionResult Incidents_InsertUpdate(SubjectIncidentsBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.Incidents_InsertUpdate(subject);
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
        #region IncidentReports_IU

        public ActionResult IncidentReports_IU(ReportBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.IncidentReports_IU(subject);
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
        #region Subject_IncidentServices_IU

        public ActionResult Subject_IncidentServices_IU(ServiceBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.Subject_IncidentServices_IU(subject);
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
        #region Subject_IncidentServices_IU

        public ActionResult Disputes_IU(DisputeBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.Disputes_IU(subject);
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
        #region SubjectServicesOffered_I

        public ActionResult SubjectServicesOffered_I(ServiceBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.SubjectServicesOffered_I(subject);
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
        #region Method Incidents_LoadBySubjectId
        public ActionResult Incidents_LoadBySubjectId(SubjectIncidentsBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.Incidents_LoadBySubjectId(subject);
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

        #region Method Incidents_LoadBySubjectId
        public ActionResult Incidents_LoadAll(SubjectIncidentsBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.Incidents_LoadAll(subject);
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

        #region Method Incidents_LoadByIncidentID
        public ActionResult Incidents_LoadByIncidentID(SubjectIncidentsBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.Incidents_LoadByIncidentID(subject);
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
        #region Method Reports_LoadByIncidentID
        public ActionResult Reports_LoadByIncidentID(ReportBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.Reports_LoadByIncidentID(subject);
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

        #region Method Disputes_LoadByIncidentID
        public ActionResult Disputes_LoadByIncidentID(DisputeBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.Disputes_LoadByIncidentID(subject);
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
        #region Method Banned_LoadByIncidentID
        public ActionResult Banned_LoadByIncidentID(BannedBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.Banned_LoadByIncidentID(subject);
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

        public ActionResult Banned_LoadByID(int BannedId)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.Banned_LoadByID(BannedId);
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

        public ActionResult Banneds_DeleteById(int BannedId)
        {
            try
            {
                actionResult.dtResult = subjectDL.Banned_DeleteById(BannedId);
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
        #region Method SubjectBanType_LoadByIncidentID
        public ActionResult SubjectBanType_LoadByIncidentID(BanTypeBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.SubjectBanType_LoadByIncidentID(subject);
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
        #region Method LCTForeignExchange_LoadById
        public ActionResult LCTForeignExchange_LoadById(LCTForeignExchangeBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.LCTForeignExchange_LoadById(subject);
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
        #region Method LCTCashOuts_LoadById
        public ActionResult LCTCashOuts_LoadById(LCTCashOutsBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.LCTCashOuts_LoadById(subject);
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
        #region Method LCTCashCall_LoadById
        public ActionResult LCTCashCall_LoadById(LCTCashCallBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.LCTCashCall_LoadById(subject);
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

        #region Method Vehicles_LoadById
        public ActionResult Vehicles_LoadById(VehiclesBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.Vehicles_LoadById(subject);
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
        #region Method SubjectServicesOffered_LoadbyIncidentSubjectID
        public ActionResult SubjectServicesOffered_LoadbyIncidentSubjectID(ServiceBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.SubjectServicesOffered_LoadbyIncidentSubjectID(subject);
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
        #region Method SubjectServices_LoadbyIncidentSubjectID
        public ActionResult SubjectServices_LoadbyIncidentSubjectID(ServiceBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.SubjectServices_LoadbyIncidentSubjectID(subject);
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
        #region Method LCTPitTransactions_LoadById
        public ActionResult LCTPitTransactions_LoadById(LCTPitTransactionsBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.LCTPitTransactions_LoadById(subject);
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
        #region Method Incidents_Delete
        public ActionResult Incidents_Delete(SubjectIncidentsBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.Incidents_Delete(subject);
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
        #region Method LCTPitTransactions_Delete
        public ActionResult LCTPitTransactions_Delete(LCTPitTransactionsBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.LCTPitTransactions_Delete(subject);
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
        #region Method LCTForeignExchange_Delete
        public ActionResult LCTForeignExchange_Delete(LCTForeignExchangeBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.LCTForeignExchange_Delete(subject);
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
        #region Method LCTCashOuts_Delete
        public ActionResult LCTCashOuts_Delete(LCTCashOutsBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.LCTCashOuts_Delete(subject);
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
        #region Method SubjectInvolved_Delete
        public ActionResult SubjectInvolved_Delete(SubjectInvolvedBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.SubjectInvolved_Delete(subject);
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
        #region Method LCTCashCall_Delete
        public ActionResult LCTCashCall_Delete(LCTCashCallBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.LCTCashCall_Delete(subject);
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
        #region Method Vehicles_Delete
        public ActionResult Vehicles_Delete(VehiclesBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.Vehicles_Delete(subject);
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
        #region Method BuyIn_InsertUpdate
        public ActionResult BuyIn_InsertUpdate(LCTPitTransactionsBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.BuyIn_InsertUpdate(subject);
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
        #region Method LCTCashCall_IU
        public ActionResult LCTCashCall_IU(LCTCashCallBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.LCTCashCall_IU(subject);
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
        #region Method SubjectLinked_IU
        public ActionResult SubjectLinked_IU(IncidentLinkedBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.SubjectLinked_IU(subject);
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

        #region Method LCTForeignExchange_IU
        public ActionResult LCTForeignExchange_IU(LCTForeignExchangeBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.LCTForeignExchange_IU(subject);
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

        #region Method Vehicles_IU
        public ActionResult Vehicles_IU(VehiclesBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.Vehicles_IU(subject);
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

        #region Method LCTCashOuts_IU
        public ActionResult LCTCashOuts_IU(LCTCashOutsBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.LCTCashOuts_IU(subject);
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
        #region SubjectIncidentLinked_DeleteById
        public ActionResult SubjectIncidentLinked_DeleteById(IncidentLinkedBase linkBase)
        {
            try
            {
                actionResult.dtResult = subjectDL.SubjectIncidentLinked_DeleteById(linkBase);
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
        #region Method GetAuthorName
        public ActionResult GetAuthorName(int UserId,int ReportId)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.GetAuthorName(UserId,ReportId);
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

        #region Method SubjectInvolved_Insert
        public ActionResult SubjectInvolved_Insert(SubjectInvolvedBase involved)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.SubjectInvolved_Insert(involved);
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
        #region Method IncidentBanned_IU
        public ActionResult IncidentBanned_IU(BannedBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.IncidentBanned_IU(subject);
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
        #region Method IncidentBanType_I
        public ActionResult IncidentBanType_I(BanTypeBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.IncidentBanType_I(subject);
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

        #region Method SubjectInvolve_I
        public ActionResult SubjectInvolve_I(SubjectInvolvedBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.SubjectInvolve_I(subject);
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
        #region Method SubjectInvolved_LoadAll
        public ActionResult SubjectInvolved_LoadAll(SubjectInvolvedBase involved)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.SubjectInvolved_LoadAll(involved);
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

        #region Services_LoadAll
        public ActionResult Services_LoadAll()
        {
            try
            {
                actionResult.dtResult = subjectDL.Services_LoadAll();
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
        #region ForeignRates_LoadAll
        public ActionResult ForeignRates_LoadAll()
        {
            try
            {
                actionResult.dtResult = subjectDL.ForeignRates_LoadAll();
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

        #region Method Codes_LoadByPart
        public ActionResult Codes_LoadByPart(SubjectIncidentsBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.Codes_LoadByPart(subject);
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

        #region IncidentType_LoadDistinct
        public ActionResult IncidentType_LoadDistinct()
        {
            try
            {
                actionResult.dtResult = subjectDL.IncidentType_LoadDistinct();
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

        #region Method IncidentType_LoadByNatureOfEvent
        public ActionResult IncidentType_LoadByNatureOfEvent(SubjectIncidentsBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.IncidentType_LoadByNatureOfEvent(subject);
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

        #region Method Subjects_Search
        public ActionResult Subjects_Search(SubjectInvolvedBase involved)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.Subjects_Search(involved);
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
        public ActionResult Subjects_FirstNameSearch(string Prefix)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.Subjects_FirstNameSearch(Prefix);
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
        public ActionResult Subjects_LastNameSearch(string firstname, string lastnameprefix)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.Subjects_LastNameSearch(firstname, lastnameprefix);
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

        #region Method Employee_Search
        public ActionResult Employee_Search(SubjectInvolvedBase involved)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.Employee_Search(involved);
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

        //Ankur New 1
        #region Method AdvanceSearchSubjectAddress

        public ActionResult AdvancedSearchSubjectAddress(string AddressType, string Apartment, string Address, string country, string city, string state, string zipCode)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.AdvancedSearchSubjectAddress(AddressType, Apartment, Address, country, city, state, zipCode);
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

        //Ankur New 1

        public ActionResult AdvancedSearchSubjectFeatures(string FeatureType, string FeatureLocation,string type,string watchid)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.AdvancedSearchSubjectFeatures(FeatureType, FeatureLocation, type, watchid);
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

        public ActionResult AdvancedSearchSubjectAliases(string NameType, string FirstName, string MiddleName, string LastName)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.AdvancedSearchSubjectAliases(NameType, FirstName, MiddleName, LastName);
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

        #region Method Subject_dashboard
        public ActionResult Subject_dashboard(SubjectBase subjectBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.Subject_dashboard(subjectBase);
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
        
        #region SubjectIncidentsMax_Load
        public ActionResult SubjectIncidentsMax_Load()
        {
            try
            {
                actionResult.dtResult = subjectDL.SubjectIncidentsMax_Load();
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

        #region Method LCTIdentification_ByID
        public ActionResult LCTIdentification_ByID(LCTIdentificationBase lct)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.LCTIdentification_ByID(lct);
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

        #region Method LCTIdentification_AddEdit
        public ActionResult LCTIdentification_AddEdit(LCTIdentificationBase lct)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.LCTIdentification_AddEdit(lct);
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

        #region Method LCTAttestation_AddEdit
        public ActionResult LCTAttestation_AddEdit(LCTIdentificationBase lct)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.LCTAttestation_AddEdit(lct);
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

        #region Method LCTNotes_AddEdit
        public ActionResult LCTNotes_AddEdit(LCTIdentificationBase lct)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.LCTNotes_AddEdit(lct);
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

        #region Method LCTTotalsSubject_Load
        public ActionResult LCTTotalsSubject_Load(LCTIdentificationBase lct)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.LCTTotalsSubject_Load(lct);
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

        #region Method LCTSubjectTotals_Add
        public ActionResult LCTSubjectTotals_Add(LCTIdentificationBase lct)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.LCTSubjectTotals_Add(lct);
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

        #region Method LCTTotals_Load
        public ActionResult LCTTotals_Load(LCTIdentificationBase lct)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dsResult = subjectDL.LCTTotals_Load(lct);
                if (actionResult.dsResult != null)
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

        #region Method SubReportsAccessPermission_AddEdit
        public ActionResult SubReportsAccessPermission_AddEdit(SubjectIncidentsBase subjectIncidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.SubReportsAccessPermission_AddEdit(subjectIncidentBase);
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

        #region Method UsersSubjectReportsAccess_LoadAll
        public ActionResult UsersSubjectReportsAccess_LoadAll(SubjectIncidentsBase subjectIncidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.UsersSubjectReportsAccess_LoadAll(subjectIncidentBase);
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

        #region Method SubjectReportPermissionCheck_User
        public ActionResult SubjectReportPermissionCheck_User(SubjectIncidentsBase subjectIncidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.SubjectReportPermissionCheck_User(subjectIncidentBase);
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

        #region Method ForeignExchangeRates_LoadByID
        public ActionResult ForeignExchangeRates_LoadByID(CIMS.BaseLayer.Setting.ForeignExchangeRatesBase exchangeBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.ForeignExchangeRates_LoadByID(exchangeBase);
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

        #region Method Subjects_AdvancedSearch
        public ActionResult Subjects_AdvancedSearch(SubjectBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.Subjects_AdvancedSearch(subject);
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

        #region Method SubjectLCT_CheckAddress
        public ActionResult SubjectLCT_CheckAddress(SubjectBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dsResult = subjectDL.SubjectLCT_CheckAddress(subject);
                if (actionResult.dsResult != null)
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

        #region Method UsersSubReportsAccess_Bind

        public ActionResult UsersSubReportsAccess_Bind(SubjectIncidentsBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.UsersSubReportsAccess_Bind(incidentBase);
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

        #region Method UsersSubjectAccess_Bind
        public ActionResult UsersSubjectAccess_Bind(SubjectIncidentsBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.UsersSubjectAccess_Bind(incidentBase);
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

        #region Method AddUsersSubReportsAccess
        public ActionResult AddUsersSubReportsAccess(SubjectIncidentsBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.AddUsersSubReportsAccess(incidentBase);
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
        public ActionResult AddAll_UsersAndRoles_SubReportsAccess(SubjectIncidentsBase incidentBase)
        {
            actionResult = new ActionResult();

            try
            {
                actionResult.IsSuccess = subjectDL.AddAll_UsersAndRoles_SubReportsAccess(incidentBase);
            }
            catch (Exception ex)
            {
                actionResult.IsSuccess = false;
                throw ex;
            }
            return actionResult;
        }
        #endregion

        #region Method AddUsersSubjectAccess
        public ActionResult AddUsersSubjectAccess(SubjectIncidentsBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.AddUsersSubjectAccess(incidentBase);
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
        public ActionResult AddAll_UsersAndRoles_SubjectAccess(SubjectIncidentsBase incidentBase)
        {
            actionResult = new ActionResult();

            try
            {
                actionResult.IsSuccess = subjectDL.AddAll_UsersAndRoles_SubjectAccess(incidentBase);
            }
            catch (Exception ex)
            {
                actionResult.IsSuccess = false;
                throw ex;
            }
            return actionResult;
        }
        #endregion

        #region Method RemoveUsersSubReportsAccess
        public ActionResult RemoveUsersSubReportsAccess(SubjectIncidentsBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.RemoveUsersSubReportsAccess(incidentBase);
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

        #region Method RemoveUsersSubjectAccess
        public ActionResult RemoveUsersSubjectAccess(SubjectIncidentsBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.RemoveUsersSubjectAccess(incidentBase);
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

        #region Method SubReportsAccessUsers_Bind
        public ActionResult SubReportsAccessUsers_Bind(SubjectIncidentsBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.SubReportsAccessUsers_Bind(incidentBase);
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

        #region Method SubjectAccessUsers_Bind
        public ActionResult SubjectAccessUsers_Bind(SubjectIncidentsBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.SubjectAccessUsers_Bind(incidentBase);
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

        #region Method SubReportAccessPermission
        public ActionResult SubReportAccessPermission(SubjectIncidentsBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.SubReportAccessPermission(incidentBase);
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

        #region Method SubjectAccessPermission
        public ActionResult SubjectAccessPermission(SubjectIncidentsBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.SubjectAccessPermission(incidentBase);
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

        #region Method SubReportsAccessPermission_ByUser
        public ActionResult SubReportsAccessPermission_ByUser(SubjectIncidentsBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.SubReportsAccessPermission_ByUser(incidentBase);
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

        #region Method SubjectAccessPermission_ByUser
        public ActionResult SubjectAccessPermission_ByUser(SubjectIncidentsBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.SubjectAccessPermission_ByUser(incidentBase);
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


        #region Method UsersSubReportsAccessRole
        public ActionResult UsersSubReportsAccessRole(SubjectIncidentsBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.UsersSubReportsAccessRole(incidentBase);
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

        #region Method UsersSubjectAccessRole
        public ActionResult UsersSubjectAccessRole(SubjectIncidentsBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.UsersSubjectAccessRole(incidentBase);
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


        #region Method AddRolesSubReportsAccess
        public ActionResult AddRolesSubReportsAccess(SubjectIncidentsBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.AddRolesSubReportsAccess(incidentBase);
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

        #region Method AddRolesSubjectAccess
        public ActionResult AddRolesSubjectAccess(SubjectIncidentsBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.AddRolesSubjectAccess(incidentBase);
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

        #region Method RemoveRolesSubReportsAccess
        public ActionResult RemoveRolesSubReportsAccess(SubjectIncidentsBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.RemoveRolesSubReportsAccess(incidentBase);
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

        #region Method RemoveRolesSubjectAccess
        public ActionResult RemoveRolesSubjectAccess(SubjectIncidentsBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.RemoveRolesSubjectAccess(incidentBase);
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

        #region Method SubReportsAccessRoles_Bind
        public ActionResult SubReportsAccessRoles_Bind(SubjectIncidentsBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.SubReportsAccessRoles_Bind(incidentBase);
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

        #region Method SubjectAccessRoles_Bind
        public ActionResult SubjectAccessRoles_Bind(SubjectIncidentsBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.SubjectAccessRoles_Bind(incidentBase);
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

        #region Method SubReportAccessPermissionByRole
        public ActionResult SubReportAccessPermissionByRole(SubjectIncidentsBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.SubReportAccessPermissionByRole(incidentBase);
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

        #region Method SubjectAccessPermissionByRole
        public ActionResult SubjectAccessPermissionByRole(SubjectIncidentsBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.SubjectAccessPermissionByRole(incidentBase);
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

        #region Method SubReportsAccessPermission_ByRole
        public ActionResult SubReportsAccessPermission_ByRole(SubjectIncidentsBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.SubReportsAccessPermission_ByRole(incidentBase);
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

        #region Method SubjectAccessPermission_ByRole
        public ActionResult SubjectAccessPermission_ByRole(SubjectIncidentsBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.SubjectAccessPermission_ByRole(incidentBase);
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

        #region Method SubReportProofread_add
        public ActionResult SubReportProofread_add(SubjectIncidentsBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.SubReportProofread_add(incidentBase);
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

        #region Method SubReportProofread_Bind
        public ActionResult SubReportProofread_Bind(SubjectIncidentsBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.SubReportProofread_Bind(incidentBase);
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

        #region Method SubReportProofread_Check
        public ActionResult SubReportProofread_Check(SubjectIncidentsBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.SubReportProofread_Check(incidentBase);
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

        #region Method SubReportCreatorPermission
        public ActionResult SubReportCreatorPermission(SubjectIncidentsBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.SubReportCreatorPermission(incidentBase);
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

        #region Method SubjectIncident_Edit
        public ActionResult SubjectIncident_Edit(SubjectIncidentsBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.SubjectIncident_Edit(incidentBase);
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

        #region Method Subject permission load by subjectid
        public ActionResult SubjectPermission_LoadBySubjectID(int SubjectID)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.SubjectPermission_LoadBySubjectID(SubjectID);
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

        #region Method Link_SubjectReport
        public ActionResult SubjectReportEventsLink_Delete(int SubjectID, int IncidentID)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = subjectDL.SubjectReportEventsLink_Delete(SubjectID, IncidentID);
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
    }
}
