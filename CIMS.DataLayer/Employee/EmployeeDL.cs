using CIMS.BaseLayer.Employee;
using CIMS.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CIMS.DataLayer.Employee
{
    public class EmployeeDL
    {
        DataTable dtContainer;
        DataSet dsContainer;

        #region Method Employees_Insert
        public DataTable Employees_Insert(EmployeeBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@UserID", employee.UserID),
                                           new MyParameter("@EmpNumber", employee.EmpNumber ),
                                           new MyParameter("@Age", employee.Age),
                                           new MyParameter("@Sex", employee.Sex ),
                                           new MyParameter("@Race", employee.Race),
                                           new MyParameter("@LastName", employee.LastName),
                                           new MyParameter("@FirstName", employee.FirstName),
                                           new MyParameter("@MiddleName", employee.MiddleName),
                                            new MyParameter("@Height", employee.Height),
                                           new MyParameter("@DateOfBirth", employee.DateOfBirth),
                                           new MyParameter("@Weight", employee.Weight ),
                                           new MyParameter("@StaffPosition", employee.StaffPosition),
                                           new MyParameter("@Eyes", employee.Eyes),
                                           new MyParameter("@Complexion", employee.Complexion),
                                           new MyParameter("@Build", employee.Build),
                                            new MyParameter("@Glasses", employee.Glasses),
                                           new MyParameter("@Restricted", employee.Restricted),
                                           new MyParameter("@Status", employee.Status),
                                           new MyParameter("@RoleName", employee.RoleName),
                                            new MyParameter("@UD9", employee.UD9),
                                            new MyParameter("@Department", employee.EmployeeDepartment),
                                            new MyParameter("@EmployeeNumber", employee.EmployeeNumber)

                                        };
                Common.Set_Procedures("Employees_Insert");
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

        #region Method Employee_Delete
        public DataTable Employee_Delete(EmployeeBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@EmployeeID", employee.EmployeeID)
                                        };
                Common.Set_Procedures("Employee_Delete");
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

        #region Method Employee_LoadByUserID
        public DataTable Employee_LoadByUserID(EmployeeBase model)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = {
                    new MyParameter("@UserID", model.UserID)
                    ,new MyParameter("@ReportAccessRole", model.RoleID)
                    };
                Common.Set_Procedures("Employee_LoadByUserID");
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
        public DataTable Employees_Load(EmployeeBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={

                                           new MyParameter("@employeeID", employee.EmpID)
                                           ,new MyParameter("@ReportAccessRole", employee.RoleID)
                                           ,new MyParameter("@UserID", employee.UserID)
                                        };
                Common.Set_Procedures("Employees_Load");
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



        #region Method Employees_Update
        public DataTable Employees_Update(EmployeeBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={

                                           new MyParameter("@UserID", employee.UserID),
                                           new MyParameter("@empID", employee.EmpID),
                                           new MyParameter("@EmpNumber", employee.EmpNumber ),
                                           new MyParameter("@Age", employee.Age),
                                           new MyParameter("@Sex", employee.Sex ),
                                           new MyParameter("@Race", employee.Race),
                                           new MyParameter("@LastName", employee.LastName),
                                           new MyParameter("@FirstName", employee.FirstName),
                                           new MyParameter("@MiddleName", employee.MiddleName),
                                           new MyParameter("@Height", employee.Height),
                                           new MyParameter("@Weight", employee.Weight ),
                                           new MyParameter("@DateOfBirth", employee.DateOfBirth ),
                                           new MyParameter("@StaffPosition", employee.StaffPosition),
                                           new MyParameter("@Eyes", employee.Eyes),
                                           new MyParameter("@Complexion", employee.Complexion),
                                           new MyParameter("@Build", employee.Build),
                                            new MyParameter("@Glasses", employee.Glasses),
                                            new MyParameter("@UD9", employee.UD9),
                                            new MyParameter("@Department", employee.EmployeeDepartment),
                                            new MyParameter("@EmployeeNumber", employee.EmployeeNumber)

                                        };
                Common.Set_Procedures("Employees_Update");
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

        #region Method EmployeeAddress
        #region Method EmployeeAddress_AddEdit
        public DataTable EmployeeAddress_AddEdit(EmployeeBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@AddressID", employee.AddressID ),
                                           new MyParameter("@EmployeeID", employee.EmployeeID),
                                           new MyParameter("@IncidentID", employee.IncidentID),
                                           new MyParameter("@ModifiedDate", employee.ModifiedDate),
                                           new MyParameter("@Apartment", employee.Apartment),
                                           new MyParameter("@Address", employee.Address),
                                           new MyParameter("@CountryID", employee.CountryID),
                                           new MyParameter("@City", employee.City),
                                           new MyParameter("@ProvState", employee.ProvState),
                                            new MyParameter("@PostalZip", employee.PostalZip),
                                            new MyParameter("@Phone", employee.Phone),
                                           new MyParameter("@AddressType", employee.AddressType)

                                        };
                Common.Set_Procedures("EmployeeAddress_AddEdit");
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
        #region Method EmployeeAddress_Load
        public DataTable EmployeeAddress_Load(EmployeeBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={

                                           new MyParameter("@AddressID", employee.AddressID)


                                        };
                Common.Set_Procedures("EmployeeAddress_Load");
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
        #region Method EmployeeAddress_LoadByUserID
        public DataTable EmployeeAddress_LoadByUserID(EmployeeBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={

                                           new MyParameter("@employeeID", employee.EmployeeID)


                                        };
                Common.Set_Procedures("EmployeeAddress_LoadByUserID");
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
        #region Method EmployeeAddress_LoadByUserID
        public bool EmployeeAddress_Delete(EmployeeBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            bool result = false;
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@AddressID", employee.AddressID)
                                        };
                Common.Set_Procedures("EmployeeAddress_Delete");
                Common.Set_ParameterLength(myParams.Length);
                Common.Set_Parameters(myParams);
                result = Common.Execute_Procedures_IUD(dsContainer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        #endregion 
        #endregion

        #region Method EmployeeLicense
        #region Method EmployeeLicense_AddEdit
        public DataTable EmployeeLicense_AddEdit(EmployeeBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@LicenseID", employee.LicenseID ),
                                           new MyParameter("@EmployeeID", employee.EmployeeID),
                                           new MyParameter("@DateOfHire", employee.DateOfHire),
                                           new MyParameter("@TerminationDate", employee.TerminationDate),
                                           new MyParameter("@LicenseExpirationDate", employee.LicenseExpirationDate),
                                           new MyParameter("@Department", employee.Department),
                                           new MyParameter("@LicenseType", employee.LicenseType),
                                           new MyParameter("@LicenseStatus", employee.LicenseStatus),
                                           new MyParameter("@ReasonForLeaving", employee.ReasonForLeaving)
                                        };
                Common.Set_Procedures("EmployeeLicense_AddEdit");
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

        #region Method EmployeeLicense_LoadByEmployeeID
        public DataTable EmployeeLicense_LoadByEmployeeID(EmployeeBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@EmployeeID", employee.EmployeeID)
                                        };
                Common.Set_Procedures("EmployeeLicense_LoadByEmployeeID");
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
        #endregion

        #region Method EmployeePersonal
        #region Method EmployeePersonal_Add
        public DataTable EmployeePersonal_Add(EmployeeBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@EmployeeID", employee.EmployeeID),
                                           new MyParameter("@IDType1", employee.IDType1),
                                           new MyParameter("@IDNumber1", employee.IDNumber1),
                                           new MyParameter("@IDDefault1", employee.IDDefault1),
                                           new MyParameter("@IDType2", employee.IDType2),
                                           new MyParameter("@IDNumber2", employee.IDNumber2),
                                           new MyParameter("@IDDefault2", employee.IDDefault2),
                                           new MyParameter("@IDType3", employee.IDType3),
                                           new MyParameter("@IDNumber3", employee.IDNumber3),
                                           new MyParameter("@IDDefault3", employee.IDDefault3),
                                           new MyParameter("@DateOfBirth", employee.DateOfBirth)
                                        };
                Common.Set_Procedures("EmployeePersonal_Add");
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
        #endregion

        #region Method EmployeePersonal_InsertUpdate
        public DataTable EmployeePersonal_InsertUpdate(EmployeeBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@EmployeeID", employee.EmployeeID),
                                           new MyParameter("@UD10", employee.UD10),
                                           new MyParameter("@UD11", employee.UD11),
                                           new MyParameter("@UD12", employee.UD12),
                                           new MyParameter("@UD13", employee.UD13),
                                           new MyParameter("@UD14", employee.UD14),
                                           new MyParameter("@UD15", employee.UD15),
                                           new MyParameter("@IDType1", employee.IDType1),
                                           new MyParameter("@IDNumber1", employee.IDNumber1),
                                           new MyParameter("@IDDefault1", employee.IDDefault1),
                                           new MyParameter("@IDType2", employee.IDType2),
                                           new MyParameter("@IDNumber2", employee.IDNumber2),
                                           new MyParameter("@IDDefault2", employee.IDDefault2),
                                           new MyParameter("@IDType3", employee.IDType3),
                                           new MyParameter("@IDNumber3", employee.IDNumber3),
                                           new MyParameter("@IDDefault3", employee.IDDefault3),
                                           new MyParameter("@DateOfBirth", employee.DateOfBirth)
                                        };
                Common.Set_Procedures("EmployeePersonal_IU");
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

        #region Method EmployeePersonal_LoadByEmployeeID
        public DataTable EmployeePersonal_LoadByEmployeeID(EmployeeBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@EmployeeID", employee.EmployeeID)
                                        };
                Common.Set_Procedures("EmployeePersonal_LoadByEmployeeID");
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

        #region Method EmployeeLinked_InsertUpdate
        public DataTable EmployeeLinked_InsertUpdate(EmployeeBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", employee.ID),
                                           new MyParameter("@EmployeeID", employee.EmployeeID),
                                           new MyParameter("@IncidentID", employee.IncidentID),
                                           new MyParameter("@Description", employee.Description),
                                           new MyParameter("@FilePath", employee.FilePath),
                                        };
                Common.Set_Procedures("EmployeeLinked_IU");
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

        #region Method EmployeeLinked_LoadByEmployeeID
        public DataTable EmployeeLinked_LoadByEmployeeID(EmployeeBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@EmployeeID", employee.EmployeeID),
                                           new MyParameter("@IncidentId", employee.IncidentID)
                                        };
                Common.Set_Procedures("EmployeeLinked_LoadByEmployeeID");
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

        #region Method EmployeeLinked_LoadByEmployeeID
        public DataTable EmployeeIncidentProofRead_LoadByEmployeeID(EmployeeBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@EmployeeID", employee.EmployeeID),
                                           new MyParameter("@ReportID", employee.IncidentID)
                                        };
                Common.Set_Procedures("EmpReportProofread_Log_Bind");
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

        #region Method EmployeeLinked_LoadById
        public DataTable EmployeeLinked_LoadById(EmployeeBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", employee.ID)
                                        };
                Common.Set_Procedures("EmployeeLinked_LoadById");
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

        #region Method EmployeeLinked_DeleteById
        public DataTable EmployeeLinked_DeleteById(EmployeeBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", employee.ID)
                                        };
                Common.Set_Procedures("EmployeeLinked_DeleteById");
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

        #region Method EmployeeIncident_InsertUpdate
        public DataTable EmployeeIncident_InsertUpdate(EmployeeIncidentBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@EmployeeID", employee.EmployeeId),
                                           new MyParameter("@Id", employee.IncidentID),
                                           new MyParameter("@ActiveStatus", employee.ActiveStatus),
                                           new MyParameter("@Description", employee.Description),
                                           new MyParameter("@IncidentDate", employee.IncidentDate),
                                           new MyParameter("@IncidentNumber", employee.IncidentNumber),
                                           new MyParameter("@IncidentRole", employee.IncidentRole),
                                           new MyParameter("@Location", employee.Location),
                                           new MyParameter("@NatureOfIncident", employee.NatureOfIncident),
                                           new MyParameter("@ShortDescription", employee.ShortDescription),
                                           new MyParameter("@StartTime", employee.StartTime),
                                           new MyParameter("@EndTime", employee.EndTime),
                                           new MyParameter("@StartDate", employee.StartDate),
                                           new MyParameter("@EndDate", employee.EndDate),
                                           new MyParameter("@Status", employee.Status),
                                            new MyParameter("@UD27", employee.ShortDescription),
                                           new MyParameter("@UD34", employee.StartTime),
                                           new MyParameter("@UD35", employee.Status),
                                            new MyParameter("@Notes", employee.Notes),
                                           new MyParameter("@IPVRDescription", employee.IPVRDescription),
                                           new MyParameter("@CreatedBy", employee.CreatedBy),
                                            new MyParameter("@ReportView", employee.ReportCreatorView),
                                           new MyParameter("@ReportEdit", employee.ReportCreatorEdit),
                                           new MyParameter("@ReportDelete", employee.ReportCreatorDelete)
                                        };
                Common.Set_Procedures("EmployeeIncident_IU");
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

        #region Method EmployeeIncident_LoadByEmployeeID
        public DataTable EmployeeIncident_LoadByEmployeeID(EmployeeIncidentBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@UserID", employee.UserID),
                                           new MyParameter("@EmployeeId", employee.EmployeeId),
                                           new MyParameter("@ReportAccessRole", employee.ReportAccessRole),
                                           new MyParameter("@AllReport", employee.AllReport),
                                        };
                Common.Set_Procedures("EmployeeIncident_LoadByEmployeeID");
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

        #region Method Incidents_LoadAll
        public DataTable Incidents_LoadAll(EmployeeIncidentBase employee)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@UserID", employee.UserID),
                                           new MyParameter("@EventId", employee.EventId),
                                           new MyParameter("@ReportAccessRole", employee.ReportAccessRole),
                                           new MyParameter("@AllReport", employee.AllReport)
                                        };
                Common.Set_Procedures("EmployeeIncident_LoadALL");
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

        #region Method EmployeeIncident_LoadByIncidentID
        public DataTable EmployeeIncident_LoadByIncidentID(EmployeeIncidentBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@IncidentId", employee.IncidentID)
                                           , new MyParameter("@UserID", employee.UserID)
                                           , new MyParameter("@ReportAccessRole", employee.ReportAccessRole)
                                        };
                Common.Set_Procedures("EmployeeIncident_LoadByIncidentID");
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

        #region Method EmployeeVariance_InsertUpdate
        public DataTable EmployeeVariance_InsertUpdate(EmployeeIncidentBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", employee.IncidentID),
                                           new MyParameter("@VarianceDescription", employee.VarianceDescription),
                                           new MyParameter("@VarianceType", employee.VarianceType),
                                           new MyParameter("@Resolution", employee.Resolution),
                                           new MyParameter("@Amount", employee.Amount),
                                           new MyParameter("@AmountType", employee.AmountType)

                                        };
                Common.Set_Procedures("EmployeeVariance_IU");
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

        #region Method EmployeeVariance_LoadByIncidentID
        public DataTable EmployeeVariance_LoadByIncidentID(EmployeeIncidentBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@IncidentId", employee.IncidentID)
                                        };
                Common.Set_Procedures("EmployeeVariance_LoadByIncidentID");
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


        #region Method EmployeesInvolved_InsertUpdate
        public DataTable EmployeesInvolved_InsertUpdate(EmployeeBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", employee.EmployeeInvolvedId),
                                           new MyParameter("@UserID", employee.UserID),
                                           new MyParameter("@EmployeeId", employee.EmployeeID),
                                           new MyParameter("@IncidentID", employee.IncidentID ),
                                           new MyParameter("@InvolvedId", employee.InvolvedId ),
                                           new MyParameter("@Sex", employee.Sex ),
                                           new MyParameter("@Race", employee.Race),
                                           new MyParameter("@LastName", employee.LastName),
                                           new MyParameter("@FirstName", employee.FirstName),
                                           new MyParameter("@RoleName", employee.RoleName),
                                        };
                Common.Set_Procedures("EmployeesInvolved_InsertUpdate");
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

        #region Method EmployeeInvolved_LoadByIncidentID
        public DataTable EmployeeInvolved_LoadByIncidentID(EmployeeIncidentBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@IncidentId", employee.IncidentID)
                                        };
                Common.Set_Procedures("EmployeeInvolved_LoadByIncidentID");
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

        #region Method EmployeeInvolved_Delete
        public DataTable EmployeeInvolved_Delete(EmployeeBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", employee.ID),
                                           new MyParameter("@ReportID", employee.IncidentID)
                                        };
                Common.Set_Procedures("EmployeeInvolved_Delete");
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

        #region Method EmployeesPaceAudit_InsertUpdate
        public DataTable EmployeesPaceAudit_InsertUpdate(EmployeeIncidentBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@IncidentId", employee.IncidentID),
                                           new MyParameter("@Game", employee.Game),
                                           //new MyParameter("@Observation", employee.Observation),
                                           new MyParameter("@ShuffleShoe", employee.ShuffleShoe ),
                                           new MyParameter("@TimeTaken", employee.TimeTaken ),
                                           new MyParameter("@DisplayName", employee.DisplayName ),
                                           new MyParameter("@StartTime", employee.PaceStartTime),
                                           new MyParameter("@EndTime", employee.PaceEndTime),
                                           new MyParameter("@Descripton", employee.PaceDescription),
                                           new MyParameter("@PaceAuditPositionsPlayed", employee.PaceAuditPositionsPlayed),
                                           new MyParameter("@PaceAuditHandsPlayed", employee.PaceAuditHandsPlayed),
                                            new MyParameter("@PaceAuditHandsPerHour", employee.PaceAuditHandsPerHour),

                                        };
                Common.Set_Procedures("EmployeePaceAudit_IU");
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

        #region Method EmployeePaceAudit_LoadByIncidentID
        public DataTable EmployeePaceAudit_LoadByIncidentID(EmployeeIncidentBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@IncidentId", employee.IncidentID),
                                           new MyParameter("@Game", employee.Game),
                                           new MyParameter("@ShuffleShoe", employee.ShuffleShoe),
                                           new MyParameter("@DisplayName", employee.DisplayName)
                                        };
                Common.Set_Procedures("GetPaceAudit_ByIncidentID");
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

        #region Method GetDisplayNames
        public DataTable GetDisplayNames()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={

                                        };
                Common.Set_Procedures("GetDisplayNames");
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


        #region Method GetQuestionAuditTypes
        public DataTable GetQuestionAuditTypes()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={

                                        };
                Common.Set_Procedures("GetQuestionAuditTypes");
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
        public DataTable GetAudits()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={

                                        };
                Common.Set_Procedures("GetAudits");
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


        #region SearchEmployees
        public DataTable SearchEmployees(EmployeeBase empBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@FirstName", empBase.FirstName),
                                            new MyParameter("@LastName", empBase.LastName),
                                            new MyParameter("@Sex", empBase.Sex),
                                            new MyParameter("@Race", empBase.Race),
                                            new MyParameter("@DOB", empBase.DateOfBirth),
                                            new MyParameter("@DateOfIncident", empBase.IncidentDate),
                                            new MyParameter("@NatureOfEvent", empBase.NatureOfIncident),
                                            new MyParameter("@ShortDescriptor", empBase.ShortDescription),
                                            new MyParameter("@Status", empBase.OverallStatus)
                                         };
                Common.Set_Procedures("SearchEmployees");
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

        public DataTable Employees_FirstNameSearch(string firstnameprefix)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@FirstName", firstnameprefix)
                                        };
                Common.Set_Procedures("Employees_FirstNameSearch");
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
        public DataTable Employees_LastNameSearch(string firstname, string lastnameprefix)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@FirstName", firstname)
                                           ,new MyParameter("@LastName", lastnameprefix)
                                        };
                Common.Set_Procedures("Employees_LastNameSearch");
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

        #region CombineEmployee
        public DataTable CombineEmployee(EmployeeBase empBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@CurrentEmployeeID", empBase.EmployeeID),
                                            new MyParameter("@CombineEmployeeID", empBase.UserID)
                                         };
                Common.Set_Procedures("CombineEmployee");
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

        #region Method GetObservation_ByAuditType
        public DataTable GetObservation_ByAuditType(EmployeeIncidentBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@AuditType", employee.AuditType),
                                           new MyParameter("@IncidentId", employee.IncidentID),

                                        };
                Common.Set_Procedures("GetObservation_ByAuditType");
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
        public DataTable GetObservation_ByAuditTypeNew(EmployeeIncidentBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@AuditID", employee.AuditID),
                                           new MyParameter("@IncidentId", employee.IncidentID),

                                        };
                Common.Set_Procedures("GetObservation_ByAuditTypeNew");
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

        public DataTable GetDisplayName_ByGame(EmployeeIncidentBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Game", employee.Game),
                                           new MyParameter("@IncidentId", employee.IncidentID),

                                        };
                Common.Set_Procedures("GetDisplayNames_ByGame");
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


        #region Method GetQuestionList_ByAuditType
        public DataTable GetQuestionList_ByAuditType(EmployeeIncidentBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@AuditType", employee.AuditType),
                                            new MyParameter("@Observation", employee.Observation),
                                             new MyParameter("@IncidentId", employee.IncidentID),
                                        };
                Common.Set_Procedures("GetQuestions_ByAuditType");
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

        public DataTable GetQuestionList_ByAuditTypeNew(EmployeeIncidentBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@AuditID", employee.AuditID),
                                            new MyParameter("@Observation", employee.Observation),
                                             new MyParameter("@IncidentId", employee.IncidentID),
                                        };
                Common.Set_Procedures("GetQuestions_ByAuditTypeNew");
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


        #region Method IncidentAudit_IU
        public DataTable IncidentAudit_IU(EmployeeIncidentBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@IncidentId", employee.IncidentID),
                                           new MyParameter("@QuestionId", employee.QuestionId),
                                           new MyParameter("@AuditType", employee.AuditType ),
                                           new MyParameter("@AuditScore", employee.AuditScore ),
                                           new MyParameter("@AuditComment", employee.AuditComment ),
                                           new MyParameter("@Observation", employee.Observation)


                                        };
                Common.Set_Procedures("IncidentAudit_IU");
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

        public DataTable IncidentAudit_IUNew(EmployeeIncidentBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@IncidentId", employee.IncidentID),
                                           new MyParameter("@QuestionId", employee.QuestionId),
                                           new MyParameter("@AuditId", employee.AuditID ),
                                           new MyParameter("@AnswerOrScore", employee.AnswerOrScore ),
                                           new MyParameter("@Comment", employee.Comment ),
                                           new MyParameter("@Observation", employee.Observation)


                                        };
                Common.Set_Procedures("IncidentAudit_IUNew");
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

        #region Method EmployeeIncident_Delete
        public DataTable EmployeeIncident_Delete(EmployeeBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", employee.IncidentID)
                                        };
                Common.Set_Procedures("DEleteIncident_ByIncidentId");
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



        #region Method Employees_dashboard
        public DataTable Employees_dashboard(EmployeeBase model)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = {new MyParameter("@UserID", model.UserID),
                                           new MyParameter("@ReportAccessRole", model.RoleID) };
                Common.Set_Procedures("Employees_dashboard");
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


        #region Method EmployeeIDMax_Load
        public DataTable EmployeeIDMax_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={

                                        };
                Common.Set_Procedures("EmployeeIDMax_Load");
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
        #region Method EmployeeIncidentsMax_Load
        public DataTable EmployeeIncidentsMax_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={

                                        };
                Common.Set_Procedures("EmployeeIncidentsMax_Load");
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

        #region Method MasterDepartmentType_Load
        public DataTable MasterDepartmentType_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("MasterDepartmentType_Load");
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

        #region Method MasterEmployeeDepartment_Load
        public DataTable MasterEmployeeDepartment_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("MasterEmployeeDepartment_Load");
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


        #region Method MasterLicenseType_Load
        public DataTable MasterLicenseType_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("MasterLicenseType_Load");
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

        #region Method MasterLicenseStatus_Load
        public DataTable MasterLicenseStatus_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("MasterLicenseStatus_Load");
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

        #region Method MasterAddressType_Load
        public DataTable MasterAddressType_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("AddressType_Load");
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

        #region Method States_LoadByCountries
        public DataTable States_LoadByCountries(EmployeeBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@CountryID", employee.CountryID)
                                        };
                Common.Set_Procedures("States_LoadByCountries");
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

        #region Method Cities_LoadByStates
        public DataTable Cities_LoadByStates(EmployeeBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@StateID", employee.Status)
                                        };
                Common.Set_Procedures("Cities_LoadByStates");
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

        #region Method EmpReportsAccessPermission_AddEdit
        public DataTable EmpReportsAccessPermission_AddEdit(EmployeeIncidentBase EmployeeIncidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@ID", EmployeeIncidentBase.RepPerID),
                                            new MyParameter("@EmployeeID", EmployeeIncidentBase.EmployeeId),
                                            new MyParameter("@ReportID", EmployeeIncidentBase.IncidentID),
                                            new MyParameter("@ReportAccessBy", EmployeeIncidentBase.ReportAccessBy),
                                            new MyParameter("@ReportView", EmployeeIncidentBase.ReportView),
                                            new MyParameter("@ReportEdit", EmployeeIncidentBase.ReportEdit),
                                            new MyParameter("@ReportDelete", EmployeeIncidentBase.ReportDelete),
                                            new MyParameter("@CreatedBy", EmployeeIncidentBase.CreatedBy)
                                        };
                Common.Set_Procedures("EmpReportsAccessPermission_AddEdit");
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

        #region Method UsersReportsAccess_LoadAll
        public DataTable UsersReportsAccess_LoadAll(EmployeeIncidentBase EmployeeIncidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = {
                                        new MyParameter("@UserID", EmployeeIncidentBase.UserID),
                                        new MyParameter("@ReportID", EmployeeIncidentBase.IncidentID)
                                        };
                Common.Set_Procedures("UsersReportsAccess_LoadAll");
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

        #region Method ReportPermissionCheck_User
        public DataTable ReportPermissionCheck_User(EmployeeIncidentBase EmployeeIncidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@EmployeeID", EmployeeIncidentBase.EmployeeId),
                                            new MyParameter("@ReportID", EmployeeIncidentBase.IncidentID),
                                            new MyParameter("@ReportAccessBy", EmployeeIncidentBase.ReportAccessBy),
                                            new MyParameter("@ReportAccessRole", EmployeeIncidentBase.ReportAccessRole)
                                        };
                Common.Set_Procedures("ReportPermissionCheck_User");
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

        #region Method EmployeeInvolve_I
        public DataTable EmployeeInvolve_I(EmployeeIncidentBase bantype)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@EmployeeID", bantype.EmployeeId),
                                           new MyParameter("@IncidentID", bantype.IncidentID),
                                           new MyParameter("@InvolvedID", bantype.InvolvedId),
                                           new MyParameter("@MediaID ", 0),
                                           new MyParameter("@InvolvedRole", null),
                                           new MyParameter("@FetchDetailsBy", bantype.FetchDetailsBy),
                                            new MyParameter("@CreatedBy", bantype.CreatedBy),

                                        };
                Common.Set_Procedures("EmployeeInvolve_I");
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

        #region Method ConvertEmployeeToSubject
        public DataTable ConvertEmployeeToSubject(EmployeeBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@ConvertEmployeeID", employee.EmployeeID),
                                            new MyParameter("@SubjectVIP", employee.SubjectVIP),
                                            new MyParameter("@CreatedBy", employee.CreatedBy),
                                        };
                Common.Set_Procedures("ConvertEmployeeToSubject");
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

        #region AdvancedSearchEmployees
        public DataTable AdvancedSearchEmployees(EmployeeBase empBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@EmpNumber", empBase.EmpNumber),
                                            new MyParameter("@FirstName", empBase.FirstName),
                                            new MyParameter("@MiddleName", empBase.MiddleName),
                                            new MyParameter("@LastName", empBase.LastName),
                                            new MyParameter("@Sex", empBase.Sex),
                                            new MyParameter("@Race", empBase.Race),
                                            new MyParameter("@Complexion", empBase.Complexion),
                                            new MyParameter("@Eyes", empBase.Eyes),
                                            new MyParameter("@Build", empBase.Build),
                                            new MyParameter("@Glasses", empBase.Glasses),
                                            new MyParameter("@Height", empBase.Height),
                                            new MyParameter("@StaffPosition", empBase.StaffPosition),
                                            new MyParameter("@Weight", empBase.Weight),
                                            new MyParameter("@EmployeeNumber", empBase.EmployeeNumber)
                                         };
                Common.Set_Procedures("AdvancedSearchEmployees");
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

        public DataTable AdvancedSearchLicence(string dateOfHire, string terminationDate, string licenseExpirationDate, string department, string licenseType, string licenseStatus)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@dateOfHire", dateOfHire),
                                            new MyParameter("@terminationDate", terminationDate),
                                            new MyParameter("@licenseExpirationDate", licenseExpirationDate),
                                            new MyParameter("@department", department),
                                            new MyParameter("@licenseType", licenseType),
                                            new MyParameter("@licenseStatus", licenseStatus),
                                            new MyParameter("@type", "L"),
                                         };
                Common.Set_Procedures("AdvancedSearch");
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

        public DataTable AdvancedSearchAddress(string AddressType, string Apartment, string Address, string country, string city, string state, string zipCode, string phone)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@AddressType", AddressType),
                                            new MyParameter("@Apartment", Apartment),
                                            new MyParameter("@Address", Address),
                                            new MyParameter("@country", country),
                                            new MyParameter("@city", city),
                                            new MyParameter("@state", state),
                                             new MyParameter("@zipCode", zipCode),
                                            new MyParameter("@phone", phone),
                                            new MyParameter("@type", "A"),
                                         };
                Common.Set_Procedures("AdvancedSearch");
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


        #region Method UsersReportsAccess_Bind
        public DataTable UsersReportsAccess_Bind(EmployeeIncidentBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@UserID", incidentBase.UserID),
                                            new MyParameter("@ReportID", incidentBase.IncidentID)
                                        };
                Common.Set_Procedures("UsersReportsAccess_Bind");
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

        #region Method UsersEmployeeAccess_Bind
        public DataTable UsersEmployeeAccess_Bind(EmployeeIncidentBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@UserID", incidentBase.UserID),
                                            new MyParameter("@EmployeeID", incidentBase.EmployeeId)
                                        };
                Common.Set_Procedures("UsersEmployeeAccess_Bind");
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


        #region Method AddUsersReportsAccess
        public DataTable AddUsersReportsAccess(EmployeeIncidentBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@EmployeeID", incidentBase.EmployeeId),
                                            new MyParameter("@ReportID", incidentBase.IncidentID),
                                            new MyParameter("@ReportAccessBy", incidentBase.ReportAccessBy),
                                             new MyParameter("@CreatedBy", incidentBase.CreatedBy)
                                        };
                Common.Set_Procedures("AddUsersReportsAccess");
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

        public bool AddAll_UsersAndRoles_SubReportsAccess(EmployeeIncidentBase incidentBase)
        {
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@EmployeeID", incidentBase.EmployeeId),
                                            new MyParameter("@ReportID", incidentBase.IncidentID),
                                             new MyParameter("@CreatedBy", incidentBase.CreatedBy)
                                        };
                Common.Set_Procedures("AddAll_UsersAndRoles_EmpReportsAccess");
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

        #region Method AddUsersEmployeeAccess
        public DataTable AddUsersEmployeeAccess(EmployeeIncidentBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@EmployeeID", incidentBase.EmployeeId),
                                            new MyParameter("@ReportAccessBy", incidentBase.ReportAccessBy),
                                             new MyParameter("@CreatedBy", incidentBase.CreatedBy)
                                        };
                Common.Set_Procedures("AddUsersEmployeeAccess");
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

        public bool AddAll_UsersAndRoles_EmployeeAccess(EmployeeIncidentBase incidentBase)
        {
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@EmployeeID", incidentBase.EmployeeId),
                                             new MyParameter("@CreatedBy", incidentBase.CreatedBy)
                                        };
                Common.Set_Procedures("AddAll_UsersAndRoles_EmployeeAccess");
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

        #region Method RemoveUsersReportsAccess
        public DataTable RemoveUsersReportsAccess(EmployeeIncidentBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@ID", incidentBase.ReportAccessID)
                                        };
                Common.Set_Procedures("RemoveUsersReportsAccess");
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

        #region Method RemoveUsersEmployeeAccess
        public DataTable RemoveUsersEmployeeAccess(EmployeeIncidentBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@ID", incidentBase.ReportAccessID)
                                        };
                Common.Set_Procedures("RemoveUsersEmployeeAccess");
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

        #region Method ReportsAccessUsers_Bind
        public DataTable ReportsAccessUsers_Bind(EmployeeIncidentBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@UserID", incidentBase.UserID),
                                            new MyParameter("@ReportID", incidentBase.IncidentID)
                                        };
                Common.Set_Procedures("ReportsAccessUsers_Bind");
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

        #region Method EmployeeAccessUsers_Bind
        public DataTable EmployeeAccessUsers_Bind(EmployeeIncidentBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@UserID", incidentBase.UserID),
                                            new MyParameter("@EmployeeID", incidentBase.EmployeeId)
                                        };
                Common.Set_Procedures("EmployeeAccessUsers_Bind");
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

        #region Method EmpReportAccessPermission
        public DataTable EmpReportAccessPermission(EmployeeIncidentBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", incidentBase.ReportAccessID),
                                            new MyParameter("@ReportID", incidentBase.IncidentID),
                                            new MyParameter("@Type", incidentBase.ReportAccessType),
                                            new MyParameter("@Permission", incidentBase.ReportAccessPermission),
                                        };
                Common.Set_Procedures("EmpReportAccessPermission");
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

        #region Method EmployeeAccessPermission
        public DataTable EmployeeAccessPermission(EmployeeIncidentBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", incidentBase.ReportAccessID),
                                            new MyParameter("@EmployeeID", incidentBase.EmployeeId),
                                            new MyParameter("@Type", incidentBase.ReportAccessType),
                                            new MyParameter("@Permission", incidentBase.ReportAccessPermission),
                                        };
                Common.Set_Procedures("EmployeeAccessPermission");
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

        #region Method ReportsAccessPermission_ByUser
        public DataTable ReportsAccessPermission_ByUser(EmployeeIncidentBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", incidentBase.ReportAccessID),
                                           new MyParameter("@ReportID", incidentBase.IncidentID)
                                        };
                Common.Set_Procedures("ReportsAccessPermission_ByUser");
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

        #region Method EmployeeAccessPermission_ByUser
        public DataTable EmployeeAccessPermission_ByUser(EmployeeIncidentBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", incidentBase.ReportAccessID),
                                           new MyParameter("@EmployeeID", incidentBase.EmployeeId)
                                        };
                Common.Set_Procedures("EmployeeAccessPermission_ByUser");
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

        #region Method UsersReportsAccessRole
        public DataTable UsersReportsAccessRole(EmployeeIncidentBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@ReportID", incidentBase.IncidentID)
                                        };
                Common.Set_Procedures("UsersReportsAccessRole");
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

        #region Method UsersEmployeeAccessRole
        public DataTable UsersEmployeeAccessRole(EmployeeIncidentBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@EmployeeID", incidentBase.EmployeeId)
                                        };
                Common.Set_Procedures("UsersEmployeeAccessRole");
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

        #region Method AddRolesReportsAccess
        public DataTable AddRolesReportsAccess(EmployeeIncidentBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@EmployeeID", incidentBase.EmployeeId),
                                            new MyParameter("@ReportID", incidentBase.IncidentID),
                                            new MyParameter("@ReportAccessRole", incidentBase.ReportAccessRole),
                                             new MyParameter("@CreatedBy", incidentBase.CreatedBy)
                                        };
                Common.Set_Procedures("AddRolesReportsAccess");
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

        #region Method AddRolesEmployeeAccess
        public DataTable AddRolesEmployeeAccess(EmployeeIncidentBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@EmployeeID", incidentBase.EmployeeId),
                                            new MyParameter("@ReportAccessRole", incidentBase.ReportAccessRole),
                                             new MyParameter("@CreatedBy", incidentBase.CreatedBy)
                                        };
                Common.Set_Procedures("AddRolesEmployeeAccess");
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

        #region Method RemoveRolesReportsAccess
        public DataTable RemoveRolesReportsAccess(EmployeeIncidentBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@ID", incidentBase.ReportAccessID)
                                        };
                Common.Set_Procedures("RemoveRolesReportsAccess");
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

        #region Method RemoveRolesEmployeeAccess
        public DataTable RemoveRolesEmployeeAccess(EmployeeIncidentBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@ID", incidentBase.ReportAccessID)
                                        };
                Common.Set_Procedures("RemoveRolesEmployeeAccess");
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

        #region Method ReportsAccessRoles_Bind
        public DataTable ReportsAccessRoles_Bind(EmployeeIncidentBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@UserID", incidentBase.UserID),
                                            new MyParameter("@ReportID", incidentBase.IncidentID)
                                        };
                Common.Set_Procedures("ReportsAccessRoles_Bind");
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

        #region Method EmployeeAccessRoles_Bind
        public DataTable EmployeeAccessRoles_Bind(EmployeeIncidentBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@UserID", incidentBase.UserID),
                                            new MyParameter("@EmployeeID", incidentBase.EmployeeId)
                                        };
                Common.Set_Procedures("EmployeeAccessRoles_Bind");
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

        #region Method EmpReportAccessPermissionByRole
        public DataTable EmpReportAccessPermissionByRole(EmployeeIncidentBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", incidentBase.ReportAccessID),
                                            new MyParameter("@ReportID", incidentBase.IncidentID),
                                            new MyParameter("@Type", incidentBase.ReportAccessType),
                                            new MyParameter("@Permission", incidentBase.ReportAccessPermission),
                                        };
                Common.Set_Procedures("EmpReportAccessPermissionByRole");
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

        #region Method EmployeeAccessPermissionByRole
        public DataTable EmployeeAccessPermissionByRole(EmployeeIncidentBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", incidentBase.ReportAccessID),
                                            new MyParameter("@EmployeeID", incidentBase.EmployeeId),
                                            new MyParameter("@Type", incidentBase.ReportAccessType),
                                            new MyParameter("@Permission", incidentBase.ReportAccessPermission),
                                        };
                Common.Set_Procedures("EmployeeAccessPermissionByRole");
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

        #region Method ReportsAccessPermission_ByRole
        public DataTable ReportsAccessPermission_ByRole(EmployeeIncidentBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", incidentBase.ReportAccessID),
                                           new MyParameter("@ReportID", incidentBase.IncidentID)
                                        };
                Common.Set_Procedures("ReportsAccessPermission_ByRole");
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

        #region Method EmployeeAccessPermission_ByRole
        public DataTable EmployeeAccessPermission_ByRole(EmployeeIncidentBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@ID", incidentBase.ReportAccessID),
                                           new MyParameter("@EmployeeID", incidentBase.EmployeeId)
                                        };
                Common.Set_Procedures("EmployeeAccessPermission_ByRole");
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

        #region Method EmpReportProofread_add
        public DataTable EmpReportProofread_add(EmployeeIncidentBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@ProofreadID", incidentBase.ProofreadID),
                                           new MyParameter("@EmployeeID", incidentBase.EmployeeId),
                                            new MyParameter("@ReportID", incidentBase.IncidentID),
                                            new MyParameter("@ReportProofread", incidentBase.ReportProofread),
                                            new MyParameter("@UserID", incidentBase.UserID),
                                        };
                Common.Set_Procedures("EmpReportProofread_add");
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

        #region Method EmpReportProofread_Bind
        public DataTable EmpReportProofread_Bind(EmployeeIncidentBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@EmployeeID", incidentBase.EmployeeId),
                                            new MyParameter("@ReportID", incidentBase.IncidentID)
                                        };
                Common.Set_Procedures("EmpReportProofread_Bind");
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

        #region Method EmpReportProofread_Check
        public DataTable EmpReportProofread_Check(EmployeeIncidentBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@EmployeeID", incidentBase.EmployeeId),
                                            new MyParameter("@ReportID", incidentBase.IncidentID)
                                        };
                Common.Set_Procedures("EmpReportProofread_Check");
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

        #region Method EmpReportCreatorPermission
        public DataTable EmpReportCreatorPermission(EmployeeIncidentBase incidentBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@ReportID", incidentBase.IncidentID),
                                            new MyParameter("@Type", incidentBase.ReportAccessType),
                                            new MyParameter("@Permission", incidentBase.ReportAccessPermission)
                                        };
                Common.Set_Procedures("EmpReportCreatorPermission");
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

        #region Method EmployeeIncident_Edit
        public DataTable EmployeeIncident_Edit(EmployeeBase employee)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@Id", employee.IncidentID)
                                        };
                Common.Set_Procedures("EditIncident_ByIncidentId");
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

        #region Method MasterWeightUnit_Load
        public DataTable MasterWeightUnit_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("MasterWeightUnit_Load");
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

        #region Method MasterHeightUnit_Load
        public DataTable MasterHeightUnit_Load()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("MasterHeightUnit_Load");
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

        #region Method Event_EmployeeReportLink
        public DataTable EmployeeReportEventsLink_Delete(int EmployeeID, int IncidentID)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = { new MyParameter("@EmployeeID", EmployeeID)
                        , new MyParameter("@IncidentID", IncidentID) };
                Common.Set_Procedures("EmployeeReportEventsLink_Delete");
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
