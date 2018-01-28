using CIMS.BaseLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.DataLayer
{
    public class EquipmentDL
    {
        DataTable dtContainer;
        DataSet dsContainer;

        #region Method EquipmentProblems_AddEdit
        public DataTable EquipmentProblems_AddEdit(Equipment equipment)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                          new MyParameter("@userID", equipment.userID),
                                           new MyParameter("@ProblemID", equipment.problemID ),
                                           new MyParameter("@ProblemType", equipment.ProblemType),
                                           new MyParameter("@EquipNumber", equipment.EquipNumber  ),
                                           new MyParameter("@Problem", equipment.Problem),
                                           new MyParameter("@Details", equipment.Details),
                                           new MyParameter("@Corrected", equipment.Corrected),
                                           new MyParameter("@Solution", equipment.Solution),
                                            new MyParameter("@Replacement", equipment.Replacement),
                                           new MyParameter("@StatusTime", equipment.StatusTime),
                                           new MyParameter("@CompletedTime", equipment.CompletedTime)
                                        };
                Common.Set_Procedures("EquipmentProblems_AddEdit");
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

        #region Method EquipmentProblems_Delete
        public DataTable EquipmentProblems_Delete(Equipment equipment)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ProblemID", equipment.problemID)
                                        };
                Common.Set_Procedures("EquipmentProblems_Delete");
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

        #region Method EquipmentProblems_LoadByUserID
        public DataTable EquipmentProblems_LoadByUserID(Equipment equipment)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@userID", equipment.userID)
                                        };
                Common.Set_Procedures("EquipmentProblems_LoadByUserID");
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

        #region Method Employees_Load
        public DataTable EquipmentProblems_Load(Equipment equipment)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={

                                           new MyParameter("@ProblemID", equipment.problemID)


                                        };
                Common.Set_Procedures("EquipmentProblems_Load");
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


        #region Method Employees_Load
        public DataTable Codes_LoadByPart(string part)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                  new MyParameter("@Part", part)
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

        #region Method EquipmentProblems_Filter
        public DataTable EquipmentProblems_Filter(Equipment equipment)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                  new MyParameter("@isCorrected", equipment.Corrected),
                                   new MyParameter("@StartDate",equipment.StatusTime),
                                    new MyParameter("@EndDate",equipment.CompletedTime),
                                     new MyParameter("@userID", equipment.userID)
                                        };
                Common.Set_Procedures("EquipmentProblems_Filter");
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
