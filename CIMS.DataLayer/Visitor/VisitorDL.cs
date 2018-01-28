using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CIMS.BaseLayer;

namespace CIMS.DataLayer
{
    public class VisitorDL
    {
        DataTable dtContainer;
        DataSet dsContainer;

        #region Method Visitor_AddEdit
        public DataTable Visitor_AddEdit(VisitorBase visitor)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@VisitorID", visitor.VisitorID),
                                           new MyParameter("@VisitorName", visitor.VisitorName ),
                                           new MyParameter("@Description", visitor.Description),
                                           new MyParameter("@FromHoursMinutes", visitor.FromHoursMinutes),
                                           new MyParameter("@ToHoursMinutes", visitor.ToHoursMinutes),
                                           new MyParameter("@VisitorDate", visitor.VisitorDate),
                                           new MyParameter("@GroupIdentifier", visitor.GroupIdentifier),
                                           new MyParameter("@CreatedBy", visitor.CreatedBy)
                                        };
                Common.Set_Procedures("Visitor_AddEdit");
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

        #region Method Visitor_Delete
        public DataTable Visitor_Delete(VisitorBase visitor)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@VisitorID", visitor.VisitorID)
                                        };
                Common.Set_Procedures("Visitor_Delete");
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

        #region Method Visitor_Load
        public DataTable Visitor_Load(VisitorBase visitor)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={

                                           new MyParameter("@VisitorID", visitor.VisitorID)
                                        };
                Common.Set_Procedures("Visitor_Load");
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

        #region Method Visitor_Filter
        public DataTable Visitor_Filter(VisitorBase visitor)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                   new MyParameter("@StartDate",visitor.StartDate),
                                    new MyParameter("@EndDate",visitor.EndDate)
                                        };
                Common.Set_Procedures("Visitor_Filter");
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


        #region Method Visitor_dashboard
        public DataTable Visitor_dashboard()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("Visitor_dashboard");
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
