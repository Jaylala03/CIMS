using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIMS.BaseLayer.GeneralReports;
using CIMS.DataLayer.GeneralReports;
using CIMS.BaseLayer;
using CIMS.Utility;

namespace CIMS.ActionLayer.GeneralReports
{
    public class GeneralReportsAction
    {
        #region Declaration
        GeneralReportsDL GeneralReportsDL = new GeneralReportsDL();
        ActionResult actionResult = new ActionResult();
        #endregion

        #region Method GeneralReport_AddEdit
        public ActionResult GeneralReport_AddEdit(GeneralReportsBase ReportsBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.GeneralReport_AddEdit(ReportsBase);
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

        #region Method GeneralReport_LoadByUser
        public ActionResult GeneralReport_LoadByUser(GeneralReportsBase ReportsBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.GeneralReport_LoadByUser(ReportsBase);
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

        #region Method GeneralReport_LoadALL
        public ActionResult GeneralReport_LoadALL(GeneralReportsBase ReportsBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.GeneralReport_LoadALL(ReportsBase);
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

        #region Method GeneralReportsMax_Load
        public ActionResult GeneralReportsMax_Load()
        {
            try
            {
                actionResult.dtResult = GeneralReportsDL.GeneralReportsMax_Load();
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

        #region Method GeneralReport_LoadByReportID
        public ActionResult GeneralReport_LoadByReportID(GeneralReportsBase reportsBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.GeneralReport_LoadByReportID(reportsBase);
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

        #region Method DeleteGeneralReport_ByID
        public ActionResult DeleteGeneralReport_ByID(GeneralReportsBase ReportsBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.DeleteGeneralReport_ByID(ReportsBase);
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

        #region Method LCTPitTransactions_GeneralReport
        public ActionResult LCTPitTransactions_GeneralReport(CIMS.BaseLayer.Subject.LCTPitTransactionsBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.LCTPitTransactions_GeneralReport(subject);
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

        #region Method GenRepLCTPitTransactions_Delete
        public ActionResult GenRepLCTPitTransactions_Delete(CIMS.BaseLayer.Subject.LCTPitTransactionsBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.GenRepLCTPitTransactions_Delete(subject);
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

        #region Method LCTForeignExchange_GenReport
        public ActionResult LCTForeignExchange_GenReport(CIMS.BaseLayer.Subject.LCTForeignExchangeBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.LCTForeignExchange_GenReport(subject);
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

        #region Method GenReportLCTForeignExchange_Delete
        public ActionResult GenReportLCTForeignExchange_Delete(CIMS.BaseLayer.Subject.LCTForeignExchangeBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.GenReportLCTForeignExchange_Delete(subject);
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

        #region Method LCTCashOuts_GenReport
        public ActionResult LCTCashOuts_GenReport(CIMS.BaseLayer.Subject.LCTCashOutsBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.LCTCashOuts_GenReport(subject);
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

        #region Method GenRepLCTCashOuts_Delete
        public ActionResult GenRepLCTCashOuts_Delete(CIMS.BaseLayer.Subject.LCTCashOutsBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.GenRepLCTCashOuts_Delete(subject);
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

        #region Method LCTCashCall_GenReports
        public ActionResult LCTCashCall_GenReports(CIMS.BaseLayer.Subject.LCTCashCallBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.LCTCashCall_GenReports(subject);
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

        #region Method GenRepLCTCashCall_Delete
        public ActionResult GenRepLCTCashCall_Delete(CIMS.BaseLayer.Subject.LCTCashCallBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.GenRepLCTCashCall_Delete(subject);
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

        #region Method GenRepLCTPitTransactions_LoadById
        public ActionResult GenRepLCTPitTransactions_LoadById(GeneralReportsBase reportsBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.GenRepLCTPitTransactions_LoadById(reportsBase);
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

        #region Method GenRepLCTCashOuts_LoadById
        public ActionResult GenRepLCTCashOuts_LoadById(GeneralReportsBase reportsBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.GenRepLCTCashOuts_LoadById(reportsBase);
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

        #region Method GenRepLCTForeignExchange_LoadById
        public ActionResult GenRepLCTForeignExchange_LoadById(GeneralReportsBase reportsBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.GenRepLCTForeignExchange_LoadById(reportsBase);
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

        #region Method GenRepLCTCashCall_LoadById
        public ActionResult GenRepLCTCashCall_LoadById(GeneralReportsBase reportsBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.GenRepLCTCashCall_LoadById(reportsBase);
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

        #region Method GenReportsVehicles_LoadById
        public ActionResult GenReportsVehicles_LoadById(GeneralReportsBase reportsBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.GenReportsVehicles_LoadById(reportsBase);
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
        public ActionResult GenReportsVehicles_AddEdit(CIMS.BaseLayer.Subject.VehiclesBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.GenReportsVehicles_AddEdit(subject);
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

        #region Method GenReportsVehicles_Delete
        public ActionResult GenReportsVehicles_Delete(CIMS.BaseLayer.Subject.VehiclesBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.GenReportsVehicles_Delete(subject);
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

        #region Method GenReportsInvolved_LoadAll
        public ActionResult GenReportsInvolved_LoadAll(GeneralReportsBase reportsBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.GenReportsInvolved_LoadAll(reportsBase);
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

        #region Method GenReportsInvolved_AddEdit
        public ActionResult GenReportsInvolved_AddEdit(CIMS.BaseLayer.Subject.SubjectInvolvedBase involved)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.GenReportsInvolved_AddEdit(involved);
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

        #region Method GenReportsInvolved_Delete
        public ActionResult GenReportsInvolved_Delete(CIMS.BaseLayer.Subject.SubjectInvolvedBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.GenReportsInvolved_Delete(subject);
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

        #region Method GeneralReportsDisputes_IU
        public ActionResult GeneralReportsDisputes_IU(CIMS.BaseLayer.Subject.DisputeBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.GeneralReportsDisputes_IU(subject);
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

        #region Method GenReportsDisputes_LoadByID
        public ActionResult GenReportsDisputes_LoadByID(GeneralReportsBase reportsBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.GenReportsDisputes_LoadByID(reportsBase);
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

        #region Method GeneralReportLinked_IU
        public ActionResult GeneralReportLinked_IU(CIMS.BaseLayer.Subject.IncidentLinkedBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.GeneralReportLinked_IU(subject);
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

        #region Method GenReportLinked_LoadByReportID
        public ActionResult GenReportLinked_LoadByReportID(GeneralReportsBase reportsBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.GenReportLinked_LoadByReportID(reportsBase);
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

        #region Method GeneralReportLinked_LoadById
        public ActionResult GeneralReportLinked_LoadById(CIMS.BaseLayer.Subject.IncidentLinkedBase linkBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.GeneralReportLinked_LoadById(linkBase);
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

        #region GeneralReportLinked_DeleteById
        public ActionResult GeneralReportLinked_DeleteById(CIMS.BaseLayer.Subject.IncidentLinkedBase linkBase)
        {
            try
            {
                actionResult.dtResult = GeneralReportsDL.GeneralReportLinked_DeleteById(linkBase);
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

        #region IncidentGeneralReports_IU
        public ActionResult IncidentGeneralReports_IU(CIMS.BaseLayer.Subject.ReportBase subject)
        {
            try
            {
                actionResult.dtResult = GeneralReportsDL.IncidentGeneralReports_IU(subject);
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

        #region IncidentGenReports_LoadByReportID
        public ActionResult IncidentGenReports_LoadByReportID(GeneralReportsBase reportsBase)
        {
            try
            {
                actionResult.dtResult = GeneralReportsDL.IncidentGenReports_LoadByReportID(reportsBase);
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

        #region UserGenReportsAccess_LoadAll
        public ActionResult UserGenReportsAccess_LoadAll(GeneralReportsBase reportsBase)
        {
            try
            {
                actionResult.dtResult = GeneralReportsDL.UserGenReportsAccess_LoadAll(reportsBase);
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

        #region GenReportsAccessPermission_AddEdit
        public ActionResult GenReportsAccessPermission_AddEdit(GeneralReportsBase reportsBase)
        {
            try
            {
                actionResult.dtResult = GeneralReportsDL.GenReportsAccessPermission_AddEdit(reportsBase);
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

        #region GenReportPermissionCheck_User
        public ActionResult GenReportPermissionCheck_User(GeneralReportsBase reportsBase)
        {
            try
            {
                actionResult.dtResult = GeneralReportsDL.GenReportPermissionCheck_User(reportsBase);
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

        #region GeneralReportBanned_LoadByReportID
        public ActionResult GeneralReportBanned_LoadByReportID(GeneralReportsBase reportsBase)
        {
            try
            {
                actionResult.dtResult = GeneralReportsDL.GeneralReportBanned_LoadByReportID(reportsBase);
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

        #region GeneralReportsBanType_LoadByReportID
        public ActionResult GeneralReportsBanType_LoadByReportID(GeneralReportsBase reportsBase)
        {
            try
            {
                actionResult.dtResult = GeneralReportsDL.GeneralReportsBanType_LoadByReportID(reportsBase);
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

        #region GeneralReportsBanType_I
        public ActionResult GeneralReportsBanType_I(CIMS.BaseLayer.Subject.BanTypeBase bantype)
        {
            try
            {
                actionResult.dtResult = GeneralReportsDL.GeneralReportsBanType_I(bantype);
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

        #region GeneralReportBanned_IU
        public ActionResult GeneralReportBanned_IU(CIMS.BaseLayer.Subject.BannedBase subject)
        {
            try
            {
                actionResult.dtResult = GeneralReportsDL.GeneralReportBanned_IU(subject);
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

        #region GenReportServices_IU
        public ActionResult GenReportServices_IU(CIMS.BaseLayer.Subject.ServiceBase subject)
        {
            try
            {
                actionResult.dtResult = GeneralReportsDL.GenReportServices_IU(subject);
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

        #region GenReportServicesOffered_I
        public ActionResult GenReportServicesOffered_I(CIMS.BaseLayer.Subject.ServiceBase subject)
        {
            try
            {
                actionResult.dtResult = GeneralReportsDL.GenReportServicesOffered_I(subject);
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

        #region GenReportsServicesOffered_LoadbyReportID
        public ActionResult GenReportsServicesOffered_LoadbyReportID(GeneralReportsBase reportBase)
        {
            try
            {
                actionResult.dtResult = GeneralReportsDL.GenReportsServicesOffered_LoadbyReportID(reportBase);
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

        #region GenReportServices_LoadbyReportID
        public ActionResult GenReportServices_LoadbyReportID(GeneralReportsBase reportBase)
        {
            try
            {
                actionResult.dtResult = GeneralReportsDL.GenReportServices_LoadbyReportID(reportBase);
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

        #region GeneralReportInvolve_I
        public ActionResult GeneralReportInvolve_I(GeneralReportsBase generalReportsBase)
        {
            try
            {
                actionResult.dtResult = GeneralReportsDL.GeneralReportInvolve_I(generalReportsBase);
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

        #region Method UsersSubReportsAccess_Bind

        public ActionResult UsersSubReportsAccess_Bind(GeneralReportsBase generalReportsBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.UsersSubReportsAccess_Bind(generalReportsBase);
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
        public ActionResult AddUsersSubReportsAccess(GeneralReportsBase generalReportsBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.AddUsersSubReportsAccess(generalReportsBase);
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
        public ActionResult AddAll_UsersAndRoles_SubReportsAccess(GeneralReportsBase generalReportsBase)
        {
            actionResult = new ActionResult();

            try
            {
                actionResult.IsSuccess = GeneralReportsDL.AddAll_UsersAndRoles_SubReportsAccess(generalReportsBase);
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
        public ActionResult RemoveUsersSubReportsAccess(GeneralReportsBase generalReportsBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.RemoveUsersSubReportsAccess(generalReportsBase);
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
        public ActionResult SubReportsAccessUsers_Bind(GeneralReportsBase generalReportsBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.SubReportsAccessUsers_Bind(generalReportsBase);
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
        public ActionResult SubReportAccessPermission(GeneralReportsBase generalReportsBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.SubReportAccessPermission(generalReportsBase);
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
        public ActionResult SubReportsAccessPermission_ByUser(GeneralReportsBase generalReportsBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.SubReportsAccessPermission_ByUser(generalReportsBase);
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
        public ActionResult UsersSubReportsAccessRole(GeneralReportsBase generalReportsBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.UsersSubReportsAccessRole(generalReportsBase);
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
        public ActionResult AddRolesSubReportsAccess(GeneralReportsBase generalReportsBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.AddRolesSubReportsAccess(generalReportsBase);
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
        public ActionResult RemoveRolesSubReportsAccess(GeneralReportsBase generalReportsBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.RemoveRolesSubReportsAccess(generalReportsBase);
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
        public ActionResult SubReportsAccessRoles_Bind(GeneralReportsBase generalReportsBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.SubReportsAccessRoles_Bind(generalReportsBase);
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
        public ActionResult SubReportAccessPermissionByRole(GeneralReportsBase generalReportsBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.SubReportAccessPermissionByRole(generalReportsBase);
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
        public ActionResult SubReportsAccessPermission_ByRole(GeneralReportsBase generalReportsBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.SubReportsAccessPermission_ByRole(generalReportsBase);
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

        #region Method Event_GeneralReportLink
        public ActionResult GeneralReportEventsLink_Delete(int ReportID)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = GeneralReportsDL.GeneralReportEventsLink_Delete(ReportID);
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
