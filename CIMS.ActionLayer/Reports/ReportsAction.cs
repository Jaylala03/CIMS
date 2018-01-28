using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIMS.DataLayer.Reports;
using CIMS.BaseLayer;
using CIMS.BaseLayer.Reports;

namespace CIMS.ActionLayer.Reports
{
    public class ReportsAction
    {
        #region Declaration
        ReportsDL reportsDL = new ReportsDL();
        ActionResult actionResult = new ActionResult();
        #endregion

        #region Ban_Types
        public ActionResult Ban_Types()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = reportsDL.Ban_Types();
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

        #region Method Banned_Pictures
        public ActionResult Banned_Pictures(ReportsBase reports)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = reportsDL.Banned_Pictures(reports);
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

        #region Method PaceAudit_print
        public ActionResult PaceAudit_print(ReportsBase ReportBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = reportsDL.PaceAudits_print(ReportBase);
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

        #region Method EmailLog_Print
        public ActionResult EmailLog_Print(ReportsBase reports)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = reportsDL.EmailLog_Print(reports);
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

        #region Method WatchNames_Load
        public ActionResult WatchNames_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = reportsDL.WatchNames_Load();
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

        #region Method WatchList_Print
        public ActionResult WatchList_Print(ReportsWatchListBase reportsWatchList)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = reportsDL.WatchList_Print(reportsWatchList);
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

        #region Method LicenseExpiry_print
        public ActionResult LicenseExpiry_print(ReportsBase reports)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = reportsDL.LicenseExpiry_print(reports);
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

        #region Method Dispatch_print
        public ActionResult Dispatch_print(ReportsBase reports)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = reportsDL.Dispatch_print(reports);
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

        #region Method IncidentCount_print
        public ActionResult IncidentCount_print(ReportsStatisticsBase reports)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = reportsDL.IncidentCount_print(reports);
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

        #region Method MoneyRecovered_print
        public ActionResult MoneyRecovered_print(ReportsStatisticsBase reports)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = reportsDL.MoneyRecovered_print(reports);
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

        #region Method VarianceByLocation_print
        public ActionResult VarianceByLocation_print(ReportsStatisticsBase reports)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = reportsDL.VarianceByLocation_print(reports);
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

        #region Method EmployeeVariance_print
        public ActionResult EmployeeVariance_print(ReportsStatisticsBase reports)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = reportsDL.EmployeeVariance_print(reports);
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

        #region Method ShortDescriptor_Graph
        public ActionResult ShortDescriptor_Graph(ReportsStatisticsBase reports)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = reportsDL.ShortDescriptor_Graph(reports);
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

        #region Method LocationCount_Graph
        public ActionResult LocationCount_Graph(ReportsStatisticsBase reports)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = reportsDL.LocationCount_Graph(reports);
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

    }
}
