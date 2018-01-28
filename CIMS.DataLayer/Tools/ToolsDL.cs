using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CIMS.BaseLayer.Tools;

namespace CIMS.DataLayer.Tools
{
    public class ToolsDL
    {
        DataTable dtContainer;
        DataSet dsContainer;
        ToolsBase ToolsBase = new ToolsBase();
        #region Method Data_Group
        public DataTable Data_Group()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                        };
                Common.Set_Procedures("DataGroup");
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
        #region Method LoadReportNames_ReportDesigner
        public DataTable LoadReportNames_ReportDesigner()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                        };
                Common.Set_Procedures("LoadReportNames_ReportDesigner");
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
        #region Method LoadDataTablesTree_ReportDesign
        public DataTable LoadDataTablesTree_ReportDesign(ToolsBase ToolsBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                               new MyParameter("@GroupName", ToolsBase.GroupName)
                                        };
                Common.Set_Procedures("LoadDataTablesTree_ReportDesign");
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
        #region Method SecurityFunctions_LoadAll
        public DataTable SecurityFunctions_LoadAll()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                              
                                        };
                Common.Set_Procedures("SecurityFunctions_LoadAll");
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
        #region Method LoadTableColumnsTreeNode_ReportDesign
        public DataTable LoadTableColumnsTreeNode_ReportDesign(ToolsBase ToolsBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                               new MyParameter("@TableName", ToolsBase.TableName)
                                        };
                Common.Set_Procedures("LoadTableColumnsTreeNode_ReportDesign");
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

        #region Method ExecuteReport_Sql
        public DataTable ExecuteReport_Sql(ToolsBase ToolsBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                               new MyParameter("@datacolumn", ToolsBase.ExecuteSql)
                                        };
                Common.Set_Procedures("ExecuteReport_Sql");
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
        #region Method ReportLayout_Load
        public DataTable ReportLayout_Load(ToolsBase ToolsBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                               new MyParameter("@ReportID", ToolsBase.ReportID)
                                        };
                Common.Set_Procedures("ReportLayout_Load");
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
        #region Method ReportSQL_Load
        public DataTable ReportSQL_Load(ToolsBase ToolsBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                               new MyParameter("@ReportID", ToolsBase.ReportID)
                                        };
                Common.Set_Procedures("ReportSQL_Load");
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
        #region Method ReportDesigner_I
        public DataTable ReportDesigner_I(ToolsBase ToolsBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ReportName", ToolsBase.ReportName ),
                                           new MyParameter("@ReportRole", ToolsBase.Role),
                                           new MyParameter("@ReportLayout", ToolsBase.ReportLayout),
                                           new MyParameter("@ReportSql", ToolsBase.ExecuteSql),
                                           new MyParameter("@ReportID", ToolsBase.ReportID),
                                           new MyParameter("@WholeLayout", ToolsBase.WholeLayout)

                                        };
                Common.Set_Procedures("ReportDesigner_I");
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
