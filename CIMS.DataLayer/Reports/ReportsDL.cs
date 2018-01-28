using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CIMS.BaseLayer.Reports;

namespace CIMS.DataLayer.Reports
{
    public class ReportsDL
    {
        #region Declaration

        DataTable dtContainer;
        DataSet dsContainer;
        #endregion

        #region Ban_Types
        public DataTable Ban_Types()
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("BanTypes");
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

        #region Method Banned_Pictures
        public DataTable Banned_Pictures(ReportsBase reports)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                    new MyParameter("@StartDate",reports.StartDate),
                                     new MyParameter("@EndDate",reports.EndDate),
                                      new MyParameter("@BanName",reports.TypeOfBan)
                                        };
                Common.Set_Procedures("BannedPictures");
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

        #region Method EmailLog_Print
        public DataTable EmailLog_Print(ReportsBase reports)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                    new MyParameter("@StartDate",reports.StartDate),
                                     new MyParameter("@EndDate",reports.EndDate),
                                      new MyParameter("@SortOrder",reports.SortOrder)
                                        };
                Common.Set_Procedures("EmailLog_Print");
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


        #region Method PaceAudit_print
        public DataTable PaceAudits_print(ReportsBase report)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                             new MyParameter("@Game", report.Game),
                                           new MyParameter("@StartDate",report.StartDate),
                                           new MyParameter("@EndDate",report.EndDate),
                                           new MyParameter("@SortBy",report.SortOrder)
                                        };
                Common.Set_Procedures("sp_GetPaceAuditReport");
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

        #region Method WatchNames_Load
        public DataTable WatchNames_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                        };
                Common.Set_Procedures("WatchNames_Load");
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

        #region Method WatchList_Print
        public DataTable WatchList_Print(ReportsWatchListBase reportWatchList)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                             new MyParameter("@WatchName", reportWatchList.WatchName)
                                        };
                Common.Set_Procedures("WatchList_Print");
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

        #region Method LicenseExpiry_print
        public DataTable LicenseExpiry_print(ReportsBase reports)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                    new MyParameter("@StartDate",reports.StartDate),
                                     new MyParameter("@EndDate",reports.EndDate),
                                      new MyParameter("@SortOrder",reports.SortOrder)
                                        };
                Common.Set_Procedures("LicenseExpiry_print");
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

        #region Method Dispatch_print
        public DataTable Dispatch_print(ReportsBase reports)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                    new MyParameter("@StartDate",reports.StartDate),
                                     new MyParameter("@EndDate",reports.EndDate),
                                     new MyParameter("@StartTime",reports.StartTime),
                                     new MyParameter("@EndTime",reports.EndTime),
                                      new MyParameter("@SortOrder",reports.SortOrder)
                                        };
                Common.Set_Procedures("Dispatch_print");
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

        #region Method IncidentCount_print

        public DataTable IncidentCount_print(ReportsStatisticsBase reports)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myparams ={
                                        new MyParameter("@Type",reports.Type),
                                        new MyParameter("@StartDate",reports.StartDate),
                                        new MyParameter("@EndDate",reports.EndDate),
                                        new MyParameter("@ShortLocation",reports.ShortLocation)
                                    };
                Common.Set_Procedures("IncidentCount_print");
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

        #region Method MoneyRecovered_print

        public DataTable MoneyRecovered_print(ReportsStatisticsBase reports)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myparams ={
                                        new MyParameter("@StartDate",reports.StartDate),
                                        new MyParameter("@EndDate",reports.EndDate),
                                        new MyParameter("@ShortLocation",reports.ShortLocation)
                                    };
                Common.Set_Procedures("MoneyRecovered_print");
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

        #region Method VarianceByLocation_print

        public DataTable VarianceByLocation_print(ReportsStatisticsBase reports)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myparams = {
                                        new MyParameter("@Type",reports.Type),
                                        new MyParameter("@StartDate",reports.StartDate),
                                        new MyParameter("@EndDate",reports.EndDate),
                                        new MyParameter("@ShortLocation",reports.ShortLocation)
                                        };
                Common.Set_Procedures("VarianceByLocation_print");
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

        #region Method EmployeeVariance_print
        public DataTable EmployeeVariance_print(ReportsStatisticsBase reports)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myparams = {
                                        new MyParameter("@Type",reports.Type),
                                        new MyParameter("@StartDate",reports.StartDate),
                                        new MyParameter("@EndDate",reports.EndDate)
                                        };
                Common.Set_Procedures("EmployeeVariance_print");
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

        #region Method ShortDescriptor_Graph
        public DataTable ShortDescriptor_Graph(ReportsStatisticsBase reports)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myparams = {
                                        new MyParameter("@ReportType",reports.Type),
                                        new MyParameter("@StartDate",reports.StartDate),
                                        new MyParameter("@EndDate",reports.EndDate)
                                        };
                Common.Set_Procedures("ShortDescriptor_Graph");
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

        #region Method LocationCount_Graph
        public DataTable LocationCount_Graph(ReportsStatisticsBase reports)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myparams = {
                                        new MyParameter("@ReportType",reports.Type),
                                        new MyParameter("@StartDate",reports.StartDate),
                                        new MyParameter("@EndDate",reports.EndDate)
                                        };
                Common.Set_Procedures("LocationCount_Graph");
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



    }
}
