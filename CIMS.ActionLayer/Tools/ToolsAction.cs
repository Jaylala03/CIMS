using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CIMS.BaseLayer.Tools;
using CIMS.DataLayer.Tools;
using CIMS.BaseLayer;

namespace CIMS.ActionLayer.Tools
{
    public class ToolsAction
    {
        #region Declaration
        ToolsDL toolsDL = new ToolsDL();
        ToolsBase ToolsBase = new ToolsBase();
        ActionResult actionResult = new ActionResult();
        #endregion

        #region Method Data_Group
        public ActionResult Data_Group()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = toolsDL.Data_Group();
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
        #region Method LoadReportNames_ReportDesigner
        public ActionResult LoadReportNames_ReportDesigner()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = toolsDL.LoadReportNames_ReportDesigner();
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
        #region Method SecurityFunctions_LoadAll
        public ActionResult SecurityFunctions_LoadAll()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = toolsDL.SecurityFunctions_LoadAll();
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
        #region Method LoadDataTablesTree_ReportDesign
        public ActionResult LoadDataTablesTree_ReportDesign(ToolsBase ToolsBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = toolsDL.LoadDataTablesTree_ReportDesign(ToolsBase);
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

        #region Method LoadTableColumnsTreeNode_ReportDesign
        public ActionResult LoadTableColumnsTreeNode_ReportDesign(ToolsBase ToolsBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = toolsDL.LoadTableColumnsTreeNode_ReportDesign(ToolsBase);
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

        #region Method ExecuteReport_Sql
        public ActionResult ExecuteReport_Sql(ToolsBase ToolsBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = toolsDL.ExecuteReport_Sql(ToolsBase);
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

        #region Method ReportLayout_Load
        public ActionResult ReportLayout_Load(ToolsBase ToolsBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = toolsDL.ReportLayout_Load(ToolsBase);
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

        #region Method ReportSQL_Load
        public ActionResult ReportSQL_Load(ToolsBase ToolsBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = toolsDL.ReportSQL_Load(ToolsBase);
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
        #region Method ReportDesigner_I
        public ActionResult ReportDesigner_I(ToolsBase ToolsBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = toolsDL.ReportDesigner_I(ToolsBase);
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
