using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CIMS.BaseLayer.GeneralReports;
using CIMS.Utility;

namespace CIMS.DataLayer.GeneralReports
{
    public class GeneralReportsDL
    {
        #region Declaration

        DataTable dtContainer;
        DataSet dsContainer;
        #endregion

        #region Method GeneralReport_AddEdit
        public DataTable GeneralReport_AddEdit(GeneralReportsBase reports)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myparams ={
                                           new MyParameter("@Id", reports.ReportID),
                                           new MyParameter("@ReportNumber", reports.ReportNumber),
                                           new MyParameter("@NatureOfEvent", reports.NatureOfEvent),
                                           new MyParameter("@ShortDescriptor", reports.ShortDescriptor),
                                           new MyParameter("@ActiveStatus", reports.ActiveStatus),
                                           new MyParameter("@Status", reports.Status),
                                           new MyParameter("@IncidentDate", reports.IncidentDate),
                                           new MyParameter("@Description", reports.Description),
                                           new MyParameter("@Location", reports.Location),
                                           new MyParameter("@IncidentRole", reports.IncidentRole),
                                           new MyParameter("@OccurrenceNumber", reports.OccurrenceNumber),
                                            new MyParameter("@IncidentTime", reports.IncidentTime),
                                           new MyParameter("@RoleName", reports.RoleName),
                                           new MyParameter("@UD51", reports.UD51),
                                            new MyParameter("@UD52", reports.UD52),
                                           new MyParameter("@UD53", reports.UD53),
                                           new MyParameter("@EventID", reports.EventID),
                                           new MyParameter("@CreatedBy", reports.CreatedBy)
                                    };
                Common.Set_Procedures("GeneralReport_AddEdit");
                Common.Set_ParameterLength(myparams.Length);
                Common.Set_Parameters(myparams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method GeneralReport_LoadByUser
        public DataTable GeneralReport_LoadByUser(GeneralReportsBase reports)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myparams ={
                                           new MyParameter("@UserID", reports.CreatedBy)
                                           ,new MyParameter("@ReportAccessRole", reports.ReportAccessRole)
                                    };
                Common.Set_Procedures("GeneralReport_LoadByUser");
                Common.Set_ParameterLength(myparams.Length);
                Common.Set_Parameters(myparams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region Method GeneralReport_LoadALL
        public DataTable GeneralReport_LoadALL(GeneralReportsBase reports)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myparams ={
                                           new MyParameter("@UserID", reports.CreatedBy)
                                           , new MyParameter("@EventID", reports.EventID)
                                           ,new MyParameter("@ReportAccessRole", reports.ReportAccessRole)
                                    };
                Common.Set_Procedures("GeneralReport_LoadALL");
                Common.Set_ParameterLength(myparams.Length);
                Common.Set_Parameters(myparams);
                dtContainer = Common.Execute_Procedures_LoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtContainer;
        }
        #endregion

        #region GeneralReportsMax_Load
        public DataTable GeneralReportsMax_Load()
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {

                                         };
                Common.Set_Procedures("GeneralReportsMax_Load");
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

        #region Method GeneralReport_LoadByReportID
        public DataTable GeneralReport_LoadByReportID(GeneralReportsBase reportsBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ReportID", reportsBase.ReportID)
                                        };
                Common.Set_Procedures("GeneralReport_LoadByReportID");
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

        #region DeleteGeneralReport_ByID
        public DataTable DeleteGeneralReport_ByID(GeneralReportsBase reports)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@ReportID", reports.ReportID)
                                         };
                Common.Set_Procedures("DeleteGeneralReport_ByID");
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

        #region Method LCTPitTransactions_GeneralReport
        public DataTable LCTPitTransactions_GeneralReport(CIMS.BaseLayer.Subject.LCTPitTransactionsBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ReportID", subject.IncidentID),
                                           new MyParameter("@ID", subject.ID),
                                           new MyParameter("@BuyInTime", subject.BuyInTime.ToString()),
                                           new MyParameter("@BuyInType", subject.BuyInType),
                                           new MyParameter("@Amount", subject.Amount),
                                           new MyParameter("@Game", subject.Game),
                                           new MyParameter("@Pit", subject.Pit)
                                        };
                Common.Set_Procedures("LCTPitTransactions_GeneralReport");
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

        #region Method GenRepLCTPitTransactions_Delete
        public DataTable GenRepLCTPitTransactions_Delete(CIMS.BaseLayer.Subject.LCTPitTransactionsBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", subject.ID)
                                        };
                Common.Set_Procedures("GenRepLCTPitTransactions_Delete");
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

        #region Method LCTForeignExchange_GenReport
        public DataTable LCTForeignExchange_GenReport(CIMS.BaseLayer.Subject.LCTForeignExchangeBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ReportID", subject.IncidentID),
                                           new MyParameter("@ID", subject.ID),
                                           new MyParameter("@ForeignAmount", subject.ForeignAmount),
                                           new MyParameter("@ForeignCountry", subject.ForeignCountry),
                                           new MyParameter("@Amount", subject.Amount),
                                           new MyParameter("@Rate", subject.Rate)
                                        };
                Common.Set_Procedures("LCTForeignExchange_GenReport");
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

        #region Method GenReportLCTForeignExchange_Delete
        public DataTable GenReportLCTForeignExchange_Delete(CIMS.BaseLayer.Subject.LCTForeignExchangeBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", subject.ID)
                                        };
                Common.Set_Procedures("GenReportLCTForeignExchange_Delete");
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

        #region Method LCTCashOuts_GenReport
        public DataTable LCTCashOuts_GenReport(CIMS.BaseLayer.Subject.LCTCashOutsBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ReportID", subject.IncidentID),
                                           new MyParameter("@ID", subject.ID),
                                           new MyParameter("@TypeOfWin", subject.TypeOfWin),
                                           new MyParameter("@PaymentType ", subject.PaymentType),
                                           new MyParameter("@ChequeNo", subject.ChequeNo),
                                           new MyParameter("@CashOutTime", subject.CashOutTime),
                                            new MyParameter("@TableNumber", subject.TableNumber),
                                             new MyParameter("@Amount", subject.Amount)
                                        };
                Common.Set_Procedures("LCTCashOuts_GenReport");
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

        #region Method GenRepLCTCashOuts_Delete
        public DataTable GenRepLCTCashOuts_Delete(CIMS.BaseLayer.Subject.LCTCashOutsBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", subject.ID)
                                        };
                Common.Set_Procedures("GenRepLCTCashOuts_Delete");
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

        #region Method LCTCashCall_GenReports
        public DataTable LCTCashCall_GenReports(CIMS.BaseLayer.Subject.LCTCashCallBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ReportID", subject.IncidentID),
                                           new MyParameter("@ID", subject.ID),
                                           new MyParameter("@Cashier", subject.Cashier),
                                           new MyParameter("@CashCallTime", subject.CashCallTime),
                                           new MyParameter("@Amount", subject.Amount)
                                        };
                Common.Set_Procedures("LCTCashCall_GenReports");
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

        #region Method GenRepLCTCashCall_Delete
        public DataTable GenRepLCTCashCall_Delete(CIMS.BaseLayer.Subject.LCTCashCallBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", subject.ID)
                                        };
                Common.Set_Procedures("GenRepLCTCashCall_Delete");
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

        #region Method GenRepLCTPitTransactions_LoadById
        public DataTable GenRepLCTPitTransactions_LoadById(GeneralReportsBase reportsBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ReportID", reportsBase.ReportID)
                                        };
                Common.Set_Procedures("GenRepLCTPitTransactions_LoadById");
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

        #region Method GenRepLCTCashOuts_LoadById
        public DataTable GenRepLCTCashOuts_LoadById(GeneralReportsBase reportsBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ReportID", reportsBase.ReportID)
                                        };
                Common.Set_Procedures("GenRepLCTCashOuts_LoadById");
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

        #region Method GenRepLCTForeignExchange_LoadById
        public DataTable GenRepLCTForeignExchange_LoadById(GeneralReportsBase reportsBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ReportID", reportsBase.ReportID)
                                        };
                Common.Set_Procedures("GenRepLCTForeignExchange_LoadById");
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

        #region Method GenRepLCTCashCall_LoadById
        public DataTable GenRepLCTCashCall_LoadById(GeneralReportsBase reportsBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                         new MyParameter("@ReportID", reportsBase.ReportID)
                                        };
                Common.Set_Procedures("GenRepLCTCashCall_LoadById");
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

        #region Method GenReportsVehicles_LoadById
        public DataTable GenReportsVehicles_LoadById(GeneralReportsBase reportsBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ReportID", reportsBase.ReportID)
                                        };
                Common.Set_Procedures("GenReportsVehicles_LoadById");
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

        #region Method GenReportsVehicles_AddEdit
        public DataTable GenReportsVehicles_AddEdit(CIMS.BaseLayer.Subject.VehiclesBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ReportID", subject.IncidentID),
                                           new MyParameter("@VehicleID ", subject.VehicleID),
                                           new MyParameter("@VehicleVIN", subject.VehicleVIN),
                                           new MyParameter("@VehicleColor", subject.VehicleColor),
                                           new MyParameter("@VehicleYear", subject.VehicleYear),
                                           new MyParameter("@VehicleModel", subject.VehicleModel),
                                            new MyParameter("@VehicleMake ", subject.VehicleMake),
                                           new MyParameter("@IssuedIn", subject.IssuedIn),
                                           new MyParameter("@LicensePlate", subject.VehicleModel)


                                        };
                Common.Set_Procedures("GenReportsVehicles_AddEdit");
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

        #region Method GenReportsVehicles_Delete
        public DataTable GenReportsVehicles_Delete(CIMS.BaseLayer.Subject.VehiclesBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", subject.VehicleID)
                                        };
                Common.Set_Procedures("GenReportsVehicles_Delete");
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

        #region Method GenReportsInvolved_LoadAll
        public DataTable GenReportsInvolved_LoadAll(GeneralReportsBase reportsBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                             new MyParameter("@ReportID", reportsBase.ReportID)
                                        };
                Common.Set_Procedures("GenReportsInvolved_LoadAll");
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

        #region Method GenReportsInvolved_AddEdit
        public DataTable GenReportsInvolved_AddEdit(CIMS.BaseLayer.Subject.SubjectInvolvedBase involved)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                             new MyParameter("@CreatedBy", involved.CreatedBy),
                                            new MyParameter("@ID", involved.SubjectIncidentID),
                                            new MyParameter("@InvolvedID", involved.InvolvedID),
                                           new MyParameter("@ReportID", involved.IncidentID),
                                           new MyParameter("@FirstName", involved.FirstName),
                                           new MyParameter("@LastName", involved.LastName),
                                           new MyParameter("@Race", involved.Race),
                                           new MyParameter("@Sex", involved.Sex),
                                           new MyParameter("@RoleName", involved.RoleName),
                                            new MyParameter("@MediaID", involved.MediaID)
                                        };
                Common.Set_Procedures("GenReportsInvolved_AddEdit");
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

        #region Method GenReportsInvolved_Delete
        public DataTable GenReportsInvolved_Delete(CIMS.BaseLayer.Subject.SubjectInvolvedBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                             new MyParameter("@InvolvedID", subject.InvolvedID),
                                               new MyParameter("@ReportID", subject.IncidentID)
                                        };
                Common.Set_Procedures("GenReportsInvolved_Delete");
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

        #region Method GeneralReportsDisputes_IU
        public DataTable GeneralReportsDisputes_IU(CIMS.BaseLayer.Subject.DisputeBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ReportID", subject.IncidentID),
                                           new MyParameter("@DisputeType", subject.DisputeType),
                                           new MyParameter("@Resolution", subject.Resolution),
                                           new MyParameter("@Amount", subject.Amount),
                                           new MyParameter("@Description ", subject.Description),
                                            new MyParameter("@RecoveredMoney", subject.RecoveredMoney)
                                        };
                Common.Set_Procedures("GeneralReportsDisputes_IU");
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

        #region Method GenReportsDisputes_LoadByID
        public DataTable GenReportsDisputes_LoadByID(GeneralReportsBase reportsBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ReportID", reportsBase.ReportID)
                                        };
                Common.Set_Procedures("GenReportsDisputes_LoadByID");
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

        #region Method GeneralReportsServices_IU
        public DataTable GeneralReportsServices_IU(CIMS.BaseLayer.Subject.ServiceBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ReportID", subject.IncidentID),
                                           new MyParameter("@CallTime", subject.CallTime),
                                           new MyParameter("@ArriveTime ", subject.ArriveTime),
                                           new MyParameter("@ServiceBy", subject.ServiceBy),
                                           new MyParameter("@ServiceFor", subject.ServiceFor),
                                            new MyParameter("@Description", subject.Description)
                                        };
                Common.Set_Procedures("GeneralReportsServices_IU");
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

        #region Method GeneralReportLinked_IU
        public DataTable GeneralReportLinked_IU(CIMS.BaseLayer.Subject.IncidentLinkedBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ReportID", subject.IncidentID),
                                           new MyParameter("@ID", subject.ID),
                                           new MyParameter("@Description", subject.Description),
                                           new MyParameter("@FilePath ", subject.FilePath)
                                        };
                Common.Set_Procedures("GeneralReportLinked_IU");
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

        #region GenReportLinked_LoadByReportID
        public DataTable GenReportLinked_LoadByReportID(GeneralReportsBase reportsBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                              new MyParameter("@ReportID", reportsBase.ReportID)
                                         };
                Common.Set_Procedures("GenReportLinked_LoadByReportID");
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

        #region GeneralReportLinked_LoadById
        public DataTable GeneralReportLinked_LoadById(CIMS.BaseLayer.Subject.IncidentLinkedBase linkBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@ID", linkBase.ID)
                                         };
                Common.Set_Procedures("GeneralReportLinked_LoadById");
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

        #region GeneralReportLinked_DeleteById
        public DataTable GeneralReportLinked_DeleteById(CIMS.BaseLayer.Subject.IncidentLinkedBase linkBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@ID", linkBase.ID)
                                         };
                Common.Set_Procedures("GeneralReportLinked_DeleteById");
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

        #region Method IncidentGeneralReports_IU
        public DataTable IncidentGeneralReports_IU(CIMS.BaseLayer.Subject.ReportBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={

                                           new MyParameter("@ReportID", subject.IncidentID),
                                           new MyParameter("@UserId", subject.UserID),
                                           new MyParameter("@ReportDate", subject.ReportDate),
                                           new MyParameter("@Report", subject.Description)
                                        };
                Common.Set_Procedures("IncidentGeneralReports_IU");
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

        #region Method IncidentGenReports_LoadByReportID
        public DataTable IncidentGenReports_LoadByReportID(GeneralReportsBase reportsBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ReportID", reportsBase.ReportID)
                                        };
                Common.Set_Procedures("IncidentGenReports_LoadByReportID");
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

        #region Method UserGenReportsAccess_LoadAll
        public DataTable UserGenReportsAccess_LoadAll(GeneralReportsBase reportsBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = {
                                        new MyParameter("@UserID", reportsBase.UserID),
                                        new MyParameter("@ReportID", reportsBase.ReportID)
                                        };
                Common.Set_Procedures("UserGenReportsAccess_LoadAll");
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

        #region Method GenReportsAccessPermission_AddEdit
        public DataTable GenReportsAccessPermission_AddEdit(GeneralReportsBase reportsBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@ID", reportsBase.RepPerID),
                                            new MyParameter("@ReportID", reportsBase.ReportID),
                                            new MyParameter("@ReportAccessBy", reportsBase.ReportAccessBy),
                                            new MyParameter("@ReportView", reportsBase.ReportView),
                                            new MyParameter("@ReportEdit", reportsBase.ReportEdit),
                                            new MyParameter("@ReportDelete", reportsBase.ReportDelete),
                                            new MyParameter("@CreatedBy", reportsBase.CreatedBy)
                                        };
                Common.Set_Procedures("GenReportsAccessPermission_AddEdit");
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

        #region Method GenReportPermissionCheck_User
        public DataTable GenReportPermissionCheck_User(GeneralReportsBase reportsBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@ReportID", reportsBase.ReportID),
                                            new MyParameter("@ReportAccessBy", reportsBase.ReportAccessBy)
                                             ,new MyParameter("@ReportAccessRole", reportsBase.ReportAccessRole)
                                        };
                Common.Set_Procedures("GenReportPermissionCheck_User");
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

        #region Method GeneralReportBanned_LoadByReportID
        public DataTable GeneralReportBanned_LoadByReportID(GeneralReportsBase reportsBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ReportID", reportsBase.ReportID)
                                        };
                Common.Set_Procedures("GeneralReportBanned_LoadByReportID");
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

        #region Method GeneralReportsBanType_LoadByReportID
        public DataTable GeneralReportsBanType_LoadByReportID(GeneralReportsBase reportsBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ReportID", reportsBase.ReportID)
                                        };
                Common.Set_Procedures("GeneralReportsBanType_LoadByReportID");
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

        #region Method GeneralReportsBanType_I
        public DataTable GeneralReportsBanType_I(CIMS.BaseLayer.Subject.BanTypeBase bantype)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ReportID", bantype.IncidentID),
                                           new MyParameter("@ReportsBanTypeTable", bantype.BanTypeTable)
                                        };
                Common.Set_Procedures("GeneralReportsBanType_I");
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

        #region Method GeneralReportBanned_IU
        public DataTable GeneralReportBanned_IU(CIMS.BaseLayer.Subject.BannedBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={

                                           new MyParameter("@ReportID", subject.IncidentID),
                                           new MyParameter("@StartDate", subject.StartDate),
                                           new MyParameter("@EndDate", subject.EndDate),
                                           new MyParameter("@EntryDate", subject.Currentdate),
                                           new MyParameter("@AuthorizedBy ", subject.AuthorizedBy),
                                           new MyParameter("@Description", subject.Description),
                                           new MyParameter("@BanYears", subject.year),
                                           new MyParameter("@BanMonths", subject.month),
                                           new MyParameter("@BanDays", subject.Day)
                                        };
                Common.Set_Procedures("GeneralReportBanned_IU");
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

        #region Method GenReportServices_IU
        public DataTable GenReportServices_IU(CIMS.BaseLayer.Subject.ServiceBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ReportID", subject.IncidentID),
                                           new MyParameter("@CallTime", subject.CallTime),
                                           new MyParameter("@ArriveTime ", subject.ArriveTime),
                                           new MyParameter("@ServiceBy", subject.ServiceBy),
                                           new MyParameter("@ServiceFor", subject.ServiceFor),
                                            new MyParameter("@Description", subject.Description)
                                        };
                Common.Set_Procedures("GenReportServices_IU");
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

        #region Method GenReportServicesOffered_I
        public DataTable GenReportServicesOffered_I(CIMS.BaseLayer.Subject.ServiceBase subject)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ReportID", subject.IncidentID),
                                           new MyParameter("@ServiceName", subject.ServiceName),
                                           new MyParameter("@Offered ", subject.Offered),
                                           new MyParameter("@Declined", subject.DeclinedAvailable)
                                        };
                Common.Set_Procedures("GenReportServicesOffered_I");
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

        #region Method GenReportsServicesOffered_LoadbyReportID
        public DataTable GenReportsServicesOffered_LoadbyReportID(GeneralReportsBase reportBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ReportID", reportBase.ReportID)
                                        };
                Common.Set_Procedures("GenReportsServicesOffered_LoadbyReportID");
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

        #region Method GenReportServices_LoadbyReportID
        public DataTable GenReportServices_LoadbyReportID(GeneralReportsBase reportBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ReportID", reportBase.ReportID)
                                        };
                Common.Set_Procedures("GenReportServices_LoadbyReportID");
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

        #region Method GeneralReportInvolve_I
        public DataTable GeneralReportInvolve_I(GeneralReportsBase generalReportsBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ReportID", generalReportsBase.ReportID),
                                           new MyParameter("@InvolvedID", generalReportsBase.InvolvedID),
                                            new MyParameter("@MediaID ", 0),
                                             new MyParameter("@InvolvedRole", null),
                                            new MyParameter("@IsEmployee", generalReportsBase.IsEmployee)

                                        };
                Common.Set_Procedures("GeneralReportInvolve_I");
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

        #region Method UsersSubReportsAccess_Bind
        public DataTable UsersSubReportsAccess_Bind(GeneralReportsBase generalReportsBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();

            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@UserID", generalReportsBase.UserID),
                                            new MyParameter("@ReportID", generalReportsBase.ReportID)
                                        };

                Common.Set_Procedures("UsersGenSubReportsAccess_Bind");
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

        #region Method AddUsersSubReportsAccess
        public DataTable AddUsersSubReportsAccess(GeneralReportsBase generalReportsBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@ReportID", generalReportsBase.ReportID),
                                            new MyParameter("@ReportAccessBy", generalReportsBase.ReportAccessBy),
                                            new MyParameter("@CreatedBy", generalReportsBase.CreatedBy)
                                        };

                Common.Set_Procedures("AddUsersGenSubReportsAccess");
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

        public bool AddAll_UsersAndRoles_SubReportsAccess(GeneralReportsBase generalReportsBase)
        {
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@ReportID", generalReportsBase.ReportID),
                                             new MyParameter("@CreatedBy", generalReportsBase.CreatedBy)
                                        };

                Common.Set_Procedures("AddAll_UsersAndRoles_GenSubReportsAccess");
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

        #region Method RemoveUsersSubReportsAccess
        public DataTable RemoveUsersSubReportsAccess(GeneralReportsBase generalReportsBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@ID", generalReportsBase.ReportAccessID)
                                        };

                Common.Set_Procedures("RemoveUsersGenSubReportsAccess");
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

        #region Method SubReportsAccessUsers_Bind
        public DataTable SubReportsAccessUsers_Bind(GeneralReportsBase generalReportsBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@UserID", generalReportsBase.UserID),
                                            new MyParameter("@ReportID", generalReportsBase.ReportID)
                                        };
                Common.Set_Procedures("GenSubReportsAccessUsers_Bind");
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

        #region Method SubReportAccessPermission
        public DataTable SubReportAccessPermission(GeneralReportsBase generalReportsBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", generalReportsBase.ReportAccessID),
                                            new MyParameter("@ReportID", generalReportsBase.ReportID),
                                            new MyParameter("@Type", generalReportsBase.ReportAccessType),
                                            new MyParameter("@Permission", generalReportsBase.ReportAccessPermission),
                                        };
                Common.Set_Procedures("GenSubReportAccessPermission");
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

        #region Method SubReportsAccessPermission_ByUser
        public DataTable SubReportsAccessPermission_ByUser(GeneralReportsBase generalReportsBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", generalReportsBase.ReportAccessID),
                                           new MyParameter("@ReportID", generalReportsBase.ReportID)
                                        };
                Common.Set_Procedures("GenSubReportsAccessPermission_ByUser");
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

        #region Method UsersSubReportsAccessRole
        public DataTable UsersSubReportsAccessRole(GeneralReportsBase generalReportsBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@ReportID", generalReportsBase.ReportID)
                                        };
                Common.Set_Procedures("GenUsersSubReportsAccessRole");
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

        #region Method AddRolesSubReportsAccess
        public DataTable AddRolesSubReportsAccess(GeneralReportsBase generalReportsBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@ReportID", generalReportsBase.ReportID),
                                            new MyParameter("@ReportAccessRole", generalReportsBase.ReportAccessRole),
                                             new MyParameter("@CreatedBy", generalReportsBase.CreatedBy)
                                        };
                Common.Set_Procedures("AddRolesGenSubReportsAccess");
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

        #region Method RemoveRolesSubReportsAccess
        public DataTable RemoveRolesSubReportsAccess(GeneralReportsBase generalReportsBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@ID", generalReportsBase.ReportAccessID)
                                        };
                Common.Set_Procedures("RemoveRolesGenSubReportsAccess");
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

        #region Method SubReportsAccessRoles_Bind
        public DataTable SubReportsAccessRoles_Bind(GeneralReportsBase generalReportsBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@UserID", generalReportsBase.UserID),
                                           new MyParameter("@ReportID", generalReportsBase.ReportID)
                                        };
                Common.Set_Procedures("GenSubReportsAccessRoles_Bind");
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

        #region Method SubReportAccessPermissionByRole
        public DataTable SubReportAccessPermissionByRole(GeneralReportsBase generalReportsBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", generalReportsBase.ReportAccessID),
                                            new MyParameter("@ReportID", generalReportsBase.ReportID),
                                            new MyParameter("@Type", generalReportsBase.ReportAccessType),
                                            new MyParameter("@Permission", generalReportsBase.ReportAccessPermission),
                                        };
                Common.Set_Procedures("GenSubReportAccessPermissionByRole");
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

        #region Method SubReportsAccessPermission_ByRole
        public DataTable SubReportsAccessPermission_ByRole(GeneralReportsBase generalReportsBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", generalReportsBase.ReportAccessID),
                                           new MyParameter("@ReportID", generalReportsBase.ReportID)
                                        };
                Common.Set_Procedures("GenSubReportsAccessPermission_ByRole");
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
        public DataTable GeneralReportEventsLink_Delete(int ReportID)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = { 
                         new MyParameter("@ReportID", ReportID) };
                Common.Set_Procedures("GeneralReportEventsLink_Delete");
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
