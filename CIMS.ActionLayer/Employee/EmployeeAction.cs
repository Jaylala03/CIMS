using CIMS.BaseLayer;
using CIMS.BaseLayer.Employee;
using CIMS.DataLayer.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.ActionLayer.Employee
{
    public class EmployeeAction
    {
        #region Declaration
        EmployeeDL employeeDL = new EmployeeDL();
        ActionResult actionResult = new ActionResult();
        #endregion

        #region Method Employees_Insert
        public ActionResult Employees_Insert(EmployeeBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.Employees_Insert(employee);
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

        #region Method Employee_Delete
        public ActionResult Employee_Delete(EmployeeBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.Employee_Delete(employee);
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

        #region Method Employee_LoadByUserID
        public ActionResult Employee_LoadByUserID(EmployeeBase model)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.Employee_LoadByUserID(model);
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

        #region Method Employees_Update
        public ActionResult Employees_Update(EmployeeBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.Employees_Update(employee);
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

        #region Method Employees_Load
        public ActionResult Employees_Load(EmployeeBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.Employees_Load(employee);
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

        #region EmployeeAddress
        #region Method Employees_Load
        public ActionResult EmployeeAddress_AddEdit(EmployeeBase employee)
        {
            actionResult = new ActionResult();

            try
            {
                actionResult.dtResult = employeeDL.EmployeeAddress_AddEdit(employee);
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
        #region Method EmployeeAddress_Load
        public ActionResult EmployeeAddress_Load(EmployeeBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmployeeAddress_Load(employee);
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
        #region Method EmployeeAddress_LoadByUserID
        public ActionResult EmployeeAddress_LoadByUserID(EmployeeBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmployeeAddress_LoadByUserID(employee);
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
        #region Method EmployeeAddress_Delete
        public ActionResult EmployeeAddress_Delete(EmployeeBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.IsSuccess = employeeDL.EmployeeAddress_Delete(employee);

            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion
        #endregion

        #region EmployeeLicense
        #region Method EmployeeLicense_AddEdit
        public ActionResult EmployeeLicense_AddEdit(EmployeeBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmployeeLicense_AddEdit(employee);
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

        #region Method EmployeeLicense_LoadByEmployeeID
        public ActionResult EmployeeLicense_LoadByEmployeeID(EmployeeBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmployeeLicense_LoadByEmployeeID(employee);
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
        #endregion

        #region EmployeePersonal_Add
        #region Method EmployeePersonal_Add
        public ActionResult EmployeePersonal_Add(EmployeeBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmployeePersonal_Add(employee);
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
        #endregion

        #region EmployeePersonal_InsertUpdate

        public ActionResult EmployeePersonal_InsertUpdate(EmployeeBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmployeePersonal_InsertUpdate(employee);
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

        #region Method EmployeePersonal_LoadByEmployeeID
        public ActionResult EmployeePersonal_LoadByEmployeeID(EmployeeBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmployeePersonal_LoadByEmployeeID(employee);
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

        #region Method EmployeeLinked_InsertUpdate
        public ActionResult EmployeeLinked_InsertUpdate(EmployeeBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmployeeLinked_InsertUpdate(employee);
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

        #region Method EmployeeLinked_LoadByEmployeeID
        public ActionResult EmployeeLinked_LoadByEmployeeID(EmployeeBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmployeeLinked_LoadByEmployeeID(employee);
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

        #region Method EmployeeIncidentProofRead_LoadByEmployeeID
        public ActionResult EmployeeIncidentProofRead_LoadByEmployeeID(EmployeeBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmployeeIncidentProofRead_LoadByEmployeeID(employee);
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

        #region Method EmployeeLinked_LoadById
        public ActionResult EmployeeLinked_LoadById(EmployeeBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmployeeLinked_LoadById(employee);
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

        #region Method EmployeeLinked_DeleteById
        public ActionResult EmployeeLinked_DeleteById(EmployeeBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmployeeLinked_DeleteById(employee);
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


        #region EmployeeIncident_InsertUpdate

        public ActionResult EmployeeIncident_InsertUpdate(EmployeeIncidentBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmployeeIncident_InsertUpdate(employee);
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

        #region Method EmployeeIncident_LoadByEmployeeID
        public ActionResult EmployeeIncident_LoadByEmployeeID(EmployeeIncidentBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmployeeIncident_LoadByEmployeeID(employee);
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

        #region Method Incidents_LoadByALL
        public ActionResult Incidents_LoadAll(EmployeeIncidentBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.Incidents_LoadAll(employee);
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

        #region Method EmployeeIncident_LoadByIncidentID
        public ActionResult EmployeeIncident_LoadByIncidentID(EmployeeIncidentBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmployeeIncident_LoadByIncidentID(employee);
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

        #region EmployeeVariance_InsertUpdate

        public ActionResult EmployeeVariance_InsertUpdate(EmployeeIncidentBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmployeeVariance_InsertUpdate(employee);
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

        #region Method EmployeeVariance_LoadByIncidentID
        public ActionResult EmployeeVariance_LoadByIncidentID(EmployeeIncidentBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmployeeVariance_LoadByIncidentID(employee);
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

        #region Method EmployeesInvolved_InsertUpdate
        public ActionResult EmployeesInvolved_InsertUpdate(EmployeeBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmployeesInvolved_InsertUpdate(employee);
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

        #region Method EmployeeInvolved_LoadByIncidentID
        public ActionResult EmployeeInvolved_LoadByIncidentID(EmployeeIncidentBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmployeeInvolved_LoadByIncidentID(employee);
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

        #region Method EmployeeInvolved_Delete
        public ActionResult EmployeeInvolved_Delete(EmployeeBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmployeeInvolved_Delete(employee);
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


        #region Method EmployeesPaceAudit_InsertUpdate
        public ActionResult EmployeesPaceAudit_InsertUpdate(EmployeeIncidentBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmployeesPaceAudit_InsertUpdate(employee);
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

        #region Method EmployeePaceAudit_LoadByIncidentID
        public ActionResult EmployeePaceAudit_LoadByIncidentID(EmployeeIncidentBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmployeePaceAudit_LoadByIncidentID(employee);
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


        #region Method GetDisplayNames
        public ActionResult GetDisplayNames()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.GetDisplayNames();
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

        #region Method SearchEmployees
        public ActionResult SearchEmployees(EmployeeBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.SearchEmployees(employee);
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

        public ActionResult Employees_FirstNameSearch(string Prefix)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.Employees_FirstNameSearch(Prefix);
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
        public ActionResult Employees_LastNameSearch(string firstname, string lastnameprefix)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.Employees_LastNameSearch(firstname, lastnameprefix);
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

        #region Method CombineEmployee
        public ActionResult CombineEmployee(EmployeeBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.CombineEmployee(employee);
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


        #region Method GetQuestionAuditTypes
        public ActionResult GetQuestionAuditTypes()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.GetQuestionAuditTypes();
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

        public ActionResult GetAudits()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.GetAudits();
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


        #region Method GetObservation_ByAuditType
        public ActionResult GetObservation_ByAuditType(EmployeeIncidentBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.GetObservation_ByAuditType(employee);
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
        public ActionResult GetObservation_ByAuditTypeNew(EmployeeIncidentBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.GetObservation_ByAuditTypeNew(employee);
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

        public ActionResult GetDisplayName_ByGame(EmployeeIncidentBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.GetDisplayName_ByGame(employee);
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


        #region Method GetQuestionList_ByAuditType
        public ActionResult GetQuestionList_ByAuditType(EmployeeIncidentBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.GetQuestionList_ByAuditType(employee);
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
        public ActionResult GetQuestionList_ByAuditTypeNew(EmployeeIncidentBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.GetQuestionList_ByAuditTypeNew(employee);
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

        #region Method IncidentAudit_IU
        public ActionResult IncidentAudit_IU(EmployeeIncidentBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.IncidentAudit_IU(employee);
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

        public ActionResult IncidentAudit_IUNew(EmployeeIncidentBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.IncidentAudit_IUNew(employee);
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

        #region Method EmployeeIncident_Delete
        public ActionResult EmployeeIncident_Delete(EmployeeBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmployeeIncident_Delete(employee);
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


        #region Method Employees_dashboard
        public ActionResult Employees_dashboard(EmployeeBase model)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.Employees_dashboard(model);
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

        #region Method EmployeeIncidentsMax_Load
        public ActionResult EmployeeIncidentsMax_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmployeeIncidentsMax_Load();
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

        #region Method EmployeeIDMax_Load
        public ActionResult EmployeeIDMax_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmployeeIDMax_Load();
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

        #region Method MasterDepartmentType_Load
        public ActionResult MasterDepartmentType_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.MasterDepartmentType_Load();
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

        #region Method MasterEmployeeDepartment_Load
        public ActionResult MasterEmployeeDepartment_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.MasterEmployeeDepartment_Load();
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

        #region Method MasterTemplateCategory_Load
        public ActionResult MasterTemplateCategory_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.MasterTemplateCategory_Load();
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

        #region Method MasterTemplateCategoryType_Load
        public ActionResult MasterTemplateCategoryType_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.MasterTemplateCategoryType_Load();
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

        #region Method TemplateCategoryTypeByID_Load
        public ActionResult TemplateCategoryTypeByID_Load(int CategoryID)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.TemplateCategoryTypeByID_Load(CategoryID);
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

        #region Method TemplateCategoryTypeByID_ContentLoad
        public ActionResult TemplateCategoryTypeByID_ContentLoad(int CategoryTypeID)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.TemplateCategoryTypeByID_ContentLoad(CategoryTypeID);
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

        #region Method SubjectStatus_Load
        public ActionResult SubjectStatus_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.SubjectStatus_Load();
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

        #region Method EmployeeStatus_Load
        public ActionResult EmployeeStatus_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmployeeStatus_Load();
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

        #region Method MasterLicenseType_Load
        public ActionResult MasterLicenseType_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.MasterLicenseType_Load();
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

        #region Method MasterLicenseStatus_Load
        public ActionResult MasterLicenseStatus_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.MasterLicenseStatus_Load();
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

        #region Method MasterAddressType_Load
        public ActionResult MasterAddressType_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.MasterAddressType_Load();
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

        #region Method States_LoadByCountries
        public ActionResult States_LoadByCountries(EmployeeBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.States_LoadByCountries(employee);
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

        #region Method Cities_LoadByStates
        public ActionResult Cities_LoadByStates(EmployeeBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.Cities_LoadByStates(employee);
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

        #region Method EmpReportsAccessPermission_AddEdit
        public ActionResult EmpReportsAccessPermission_AddEdit(EmployeeIncidentBase employeeIncidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmpReportsAccessPermission_AddEdit(employeeIncidentBase);
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

        #region Method UsersReportsAccess_LoadAll
        public ActionResult UsersReportsAccess_LoadAll(EmployeeIncidentBase employeeIncidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.UsersReportsAccess_LoadAll(employeeIncidentBase);
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

        #region Method ReportPermissionCheck_User
        public ActionResult ReportPermissionCheck_User(EmployeeIncidentBase employeeIncidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.ReportPermissionCheck_User(employeeIncidentBase);
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

        #region Method EmployeeInvolve_I
        public ActionResult EmployeeInvolve_I(EmployeeIncidentBase subject)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmployeeInvolve_I(subject);
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

        #region Method ConvertEmployeeToSubject
        public ActionResult ConvertEmployeeToSubject(EmployeeBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.ConvertEmployeeToSubject(employee);
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

        #region Method AdvancedSearchEmployees
        public ActionResult AdvancedSearchEmployees(EmployeeBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.AdvancedSearchEmployees(employee);
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

        public ActionResult AdvancedSearchLicence(string dateOfHire, string terminationDate, string licenseExpirationDate, string department, string licenseType, string licenseStatus)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.AdvancedSearchLicence(dateOfHire, terminationDate, licenseExpirationDate, department, licenseType, licenseStatus);
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

        public ActionResult AdvancedSearchAddress(string AddressType, string Apartment, string Address, string country, string city, string state, string zipCode, string phone)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.AdvancedSearchAddress(AddressType, Apartment, Address, country, city, state, zipCode, phone);
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

        #region Method UsersReportsAccess_Bind
        public ActionResult UsersReportsAccess_Bind(EmployeeIncidentBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.UsersReportsAccess_Bind(incidentBase);
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

        #region Method UsersEmployeeAccess_Bind
        public ActionResult UsersEmployeeAccess_Bind(EmployeeIncidentBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.UsersEmployeeAccess_Bind(incidentBase);
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

        #region Method AddUsersReportsAccess
        public ActionResult AddUsersReportsAccess(EmployeeIncidentBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.AddUsersReportsAccess(incidentBase);
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

        public ActionResult AddAll_UsersAndRoles_SubReportsAccess(EmployeeIncidentBase incidentBase)
        {
            actionResult = new ActionResult();

            try
            {
                actionResult.IsSuccess = employeeDL.AddAll_UsersAndRoles_SubReportsAccess(incidentBase);
            }
            catch (Exception ex)
            {
                actionResult.IsSuccess = false;
                throw ex;
            }
            return actionResult;
        }

        #endregion

        #region Method AddUsersEmployeeAccess
        public ActionResult AddUsersEmployeeAccess(EmployeeIncidentBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.AddUsersEmployeeAccess(incidentBase);
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

        public ActionResult AddAll_UsersAndRoles_EmployeeAccess(EmployeeIncidentBase incidentBase)
        {
            actionResult = new ActionResult();

            try
            {
                actionResult.IsSuccess = employeeDL.AddAll_UsersAndRoles_EmployeeAccess(incidentBase);
            }
            catch (Exception ex)
            {
                actionResult.IsSuccess = false;
                throw ex;
            }
            return actionResult;
        }

        #endregion

        #region Method RemoveUsersReportsAccess
        public ActionResult RemoveUsersReportsAccess(EmployeeIncidentBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.RemoveUsersReportsAccess(incidentBase);
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

        #region Method RemoveUsersEmployeeAccess
        public ActionResult RemoveUsersEmployeeAccess(EmployeeIncidentBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.RemoveUsersEmployeeAccess(incidentBase);
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

        #region Method ReportsAccessUsers_Bind
        public ActionResult ReportsAccessUsers_Bind(EmployeeIncidentBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.ReportsAccessUsers_Bind(incidentBase);
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

        #region Method EmployeeAccessUsers_Bind
        public ActionResult EmployeeAccessUsers_Bind(EmployeeIncidentBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmployeeAccessUsers_Bind(incidentBase);
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

        #region Method EmpReportAccessPermission
        public ActionResult EmpReportAccessPermission(EmployeeIncidentBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmpReportAccessPermission(incidentBase);
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

        #region Method EmployeeAccessPermission
        public ActionResult EmployeeAccessPermission(EmployeeIncidentBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmployeeAccessPermission(incidentBase);
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

        #region Method ReportsAccessPermission_ByUser
        public ActionResult ReportsAccessPermission_ByUser(EmployeeIncidentBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.ReportsAccessPermission_ByUser(incidentBase);
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

        #region Method EmployeeAccessPermission_ByUser
        public ActionResult EmployeeAccessPermission_ByUser(EmployeeIncidentBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmployeeAccessPermission_ByUser(incidentBase);
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

        #region Method UsersReportsAccessRole
        public ActionResult UsersReportsAccessRole(EmployeeIncidentBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.UsersReportsAccessRole(incidentBase);
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

        #region Method UsersEmployeeAccessRole
        public ActionResult UsersEmployeeAccessRole(EmployeeIncidentBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.UsersEmployeeAccessRole(incidentBase);
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

        #region Method AddRolesReportsAccess
        public ActionResult AddRolesReportsAccess(EmployeeIncidentBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.AddRolesReportsAccess(incidentBase);
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

        #region Method AddRolesEmployeeAccess
        public ActionResult AddRolesEmployeeAccess(EmployeeIncidentBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.AddRolesEmployeeAccess(incidentBase);
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

        #region Method RemoveRolesReportsAccess
        public ActionResult RemoveRolesReportsAccess(EmployeeIncidentBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.RemoveRolesReportsAccess(incidentBase);
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

        #region Method RemoveRolesEmployeeAccess
        public ActionResult RemoveRolesEmployeeAccess(EmployeeIncidentBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.RemoveRolesEmployeeAccess(incidentBase);
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

        #region Method ReportsAccessRoles_Bind
        public ActionResult ReportsAccessRoles_Bind(EmployeeIncidentBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.ReportsAccessRoles_Bind(incidentBase);
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

        #region Method EmployeeAccessRoles_Bind
        public ActionResult EmployeeAccessRoles_Bind(EmployeeIncidentBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmployeeAccessRoles_Bind(incidentBase);
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

        #region Method EmpReportAccessPermissionByRole
        public ActionResult EmpReportAccessPermissionByRole(EmployeeIncidentBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmpReportAccessPermissionByRole(incidentBase);
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

        #region Method EmployeeAccessPermissionByRole
        public ActionResult EmployeeAccessPermissionByRole(EmployeeIncidentBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmployeeAccessPermissionByRole(incidentBase);
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

        #region Method ReportsAccessPermission_ByRole
        public ActionResult ReportsAccessPermission_ByRole(EmployeeIncidentBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.ReportsAccessPermission_ByRole(incidentBase);
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

        #region Method EmployeeAccessPermission_ByRole
        public ActionResult EmployeeAccessPermission_ByRole(EmployeeIncidentBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmployeeAccessPermission_ByRole(incidentBase);
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

        #region Method EmpReportProofread_add
        public ActionResult EmpReportProofread_add(EmployeeIncidentBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmpReportProofread_add(incidentBase);
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

        #region Method EmpReportProofread_Bind
        public ActionResult EmpReportProofread_Bind(EmployeeIncidentBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmpReportProofread_Bind(incidentBase);
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

        #region Method EmpReportProofread_Check
        public ActionResult EmpReportProofread_Check(EmployeeIncidentBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmpReportProofread_Check(incidentBase);
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

        #region Method EmpReportCreatorPermission
        public ActionResult EmpReportCreatorPermission(EmployeeIncidentBase incidentBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmpReportCreatorPermission(incidentBase);
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

        #region Method EmployeeIncident_Edit
        public ActionResult EmployeeIncident_Edit(EmployeeBase employee)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmployeeIncident_Edit(employee);
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

        #region Method MasterWeightUnit_Load
        public ActionResult MasterWeightUnit_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.MasterWeightUnit_Load();
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

        #region Method MasterHeightUnit_Load
        public ActionResult MasterHeightUnit_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.MasterHeightUnit_Load();
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

        #region Method Event_EmployeeReportLink
        public ActionResult EmployeeReportEventsLink_Delete(int EmployeeID, int IncidentID)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.EmployeeReportEventsLink_Delete(EmployeeID, IncidentID);
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

        #region Method MasterFileType_Load
        public ActionResult FileType_Load()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = employeeDL.FileType_Load();
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
