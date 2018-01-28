using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CIMS.BaseLayer.IncidentList;


namespace CIMS.DataLayer.IncidentList
{
    public class IncidentListDL
    {
        #region Declaration

        DataTable dtContainer;
        DataSet dsContainer;
        #endregion

        #region Method IncidentList_print
        public DataTable IncidentList_print(IncidentListBase reports)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myparams ={
                                    new MyParameter("@Type",reports.Type),
                                    new MyParameter("@StartDate",reports.StartDate),
                                    new MyParameter("@EndDate",reports.EndDate)
                                    };
                Common.Set_Procedures("IncidentList_print");
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
