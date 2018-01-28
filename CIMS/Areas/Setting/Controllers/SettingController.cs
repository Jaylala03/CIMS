using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Data;
using CIMS.Models;
using CIMS.BaseLayer.Setting;
using CIMS.ActionLayer.Setting;
using CIMS.Filters;
using System.IO;
using System.Text;
using CIMS.Helpers;
using CIMS.Utility;

namespace CIMS.Areas.Setting.Controllers
{
    [CheckLogin]
    [CheckPermissionAttribute]
    public class SettingController : Controller
    {
        SettingModel settingModel = new SettingModel();
        SettingAction settingAction = new SettingAction();

        CIMS.BaseLayer.ActionResult actionResult;
        //
        // GET: /Setting/Setting/
        public ActionResult Index()
        {

            return View();
        }

        // Department Type
        #region Bind Department Type
        public JsonResult DepartmentType_Load()
        {
            string jsonString = string.Empty;
            try
            {

                CIMS.ActionLayer.Employee.EmployeeAction employeeAction = new CIMS.ActionLayer.Employee.EmployeeAction();
                actionResult = employeeAction.MasterDepartmentType_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["DepartmentType"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditDepartmentType(" + actionResult.dtResult.Rows[i]["id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["DepartmentType"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm' href='javascript:;' onclick='DeleteDepartmentType(" + actionResult.dtResult.Rows[i]["id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion
        
        #region Department Type IU
        public JsonResult DepartmentType_IU(int ID,string Name)
        {
            string jsonString = string.Empty;
            try
            {
                DepartmentTypeBase departmentBase = new DepartmentTypeBase();
                departmentBase.DepartmentID = ID;
                departmentBase.DepartmentName = Name;
                actionResult = settingAction.DepartmentType_IU(departmentBase);
                if (actionResult.IsSuccess)
                {
                    jsonString="success";
                }
                else
                {
                    jsonString="error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Department Type Delete
        public JsonResult DepartmentType_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                DepartmentTypeBase departmentBase = new DepartmentTypeBase();
                departmentBase.DepartmentID = ID;
                actionResult = settingAction.DepartmentType_Delete(departmentBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // License Type
        #region Bind License Type
        public JsonResult LicenseType_Load()
        {
            string jsonString = string.Empty;
            try
            {

                CIMS.ActionLayer.Employee.EmployeeAction employeeAction = new CIMS.ActionLayer.Employee.EmployeeAction();
                actionResult = employeeAction.MasterLicenseType_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["LicenseType"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditLicenseType(" + actionResult.dtResult.Rows[i]["id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["LicenseType"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteLicenseType(" + actionResult.dtResult.Rows[i]["id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region License Type IU
        public JsonResult LicenseType_IU(int ID, string Name)
        {
            string jsonString = string.Empty;
            try
            {
                LicenseTypeBase licenseBase = new LicenseTypeBase();
                licenseBase.LicenseID = ID;
                licenseBase.LicenseName = Name;
                actionResult = settingAction.LicenseType_IU(licenseBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region License Type Delete
        public JsonResult LicenseType_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                LicenseTypeBase licenseBase = new LicenseTypeBase();
                licenseBase.LicenseID = ID;
                actionResult = settingAction.LicenseType_Delete(licenseBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // License Status
        #region Bind License Status
        public JsonResult LicenseStatus_Load()
        {
            string jsonString = string.Empty;
            try
            {

                CIMS.ActionLayer.Employee.EmployeeAction employeeAction = new CIMS.ActionLayer.Employee.EmployeeAction();
                actionResult = employeeAction.MasterLicenseStatus_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["LicenseStatus"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditLicenseStatus(" + actionResult.dtResult.Rows[i]["id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["LicenseStatus"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteLicenseStatus(" + actionResult.dtResult.Rows[i]["id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region License Status IU
        public JsonResult LicenseStatus_IU(int ID, string Name)
        {
            string jsonString = string.Empty;
            try
            {
                LicenseStatusBase licenseStatusBase = new LicenseStatusBase();
                licenseStatusBase.ID = ID;
                licenseStatusBase.LicenseStatus = Name;
                actionResult = settingAction.LicenseStatus_IU(licenseStatusBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region License Status Delete
        public JsonResult LicenseStatus_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                LicenseStatusBase licenseStatusBase = new LicenseStatusBase();
                licenseStatusBase.ID = ID;
                actionResult = settingAction.LicenseStatus_Delete(licenseStatusBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // Feature Type
        #region Bind Feature Type
        public JsonResult FeatureType_Load()
        {
            string jsonString = string.Empty;
            try
            {                
                actionResult = settingAction.FeatureType_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["FeatureType"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditFeatureType(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["FeatureType"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteFeatureType(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Feature Type IU
        public JsonResult FeatureType_IU(int ID, string Name)
        {
            string jsonString = string.Empty;
            try
            {
                FeatureTypeBase featureTypeBase = new FeatureTypeBase();
                featureTypeBase.ID = ID;
                featureTypeBase.FeatureType = Name;
                actionResult = settingAction.FeatureType_IU(featureTypeBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Feature Type Delete
        public JsonResult FeatureType_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                FeatureTypeBase featureTypeBase = new FeatureTypeBase();
                featureTypeBase.ID = ID;
                actionResult = settingAction.FeatureType_Delete(featureTypeBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // Feature Location
        #region Bind Feature Location
        public JsonResult FeatureLocation_Load()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.FeatureLocation_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["FLocation"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditFeatureLocation(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["FLocation"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteFeatureLocation(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Feature Location IU
        public JsonResult FeatureLocation_IU(int ID, string Name)
        {
            string jsonString = string.Empty;
            try
            {
                FeatureLocationBase feaLocationBase = new FeatureLocationBase();
                feaLocationBase.ID = ID;
                feaLocationBase.FLocation = Name;
                actionResult = settingAction.FeatureLocation_IU(feaLocationBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Feature Location Delete
        public JsonResult FeatureLocation_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                FeatureLocationBase feaLocationBase = new FeatureLocationBase();
                feaLocationBase.ID = ID;
                actionResult = settingAction.FeatureLocation_Delete(feaLocationBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // Complexion
        #region Bind Complexion
        public JsonResult Complexion_Load()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.Complexion_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["Complexion"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditComplexion(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["Complexion"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteComplexion(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Complexion IU
        public JsonResult Complexion_IU(int ID, string Name)
        {
            string jsonString = string.Empty;
            try
            {
                ComplexionBase complexionBase = new ComplexionBase();
                complexionBase.ID = ID;
                complexionBase.Complexion = Name;
                actionResult = settingAction.Complexion_IU(complexionBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Complexion Delete
        public JsonResult Complexion_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                ComplexionBase complexionBase = new ComplexionBase();
                complexionBase.ID = ID;
                actionResult = settingAction.Complexion_Delete(complexionBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // Build
        #region Bind Build
        public JsonResult Build_Load()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.Build_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["Build"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditBuild(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["Build"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteBuild(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Build IU
        public JsonResult Build_IU(int ID, string Name)
        {
            string jsonString = string.Empty;
            try
            {
                BuildBase buildBase = new BuildBase();
                buildBase.ID = ID;
                buildBase.Build = Name;
                actionResult = settingAction.Build_IU(buildBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Build Delete
        public JsonResult Build_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                BuildBase buildBase = new BuildBase();
                buildBase.ID = ID;
                actionResult = settingAction.Build_Delete(buildBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        public JsonResult MasterTypeID1_Load()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.MasterTypeID1_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["Value"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditTypeID(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["Value"].ToString() + ",&#39;" +"1" + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DelecteTypeid1(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MasterTypeID2_Load()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.MasterTypeID2_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["Value"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditTypeID(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["Value"].ToString() + ",&#39;" + "2" + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DelecteTypeid2(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MasterTypeID3_Load()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.MasterTypeID3_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["Value"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditTypeID(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["Value"].ToString() + ",&#39;" + "3" + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DelecteTypeid3(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        // Hair Length
        #region Bind Hair Length
        public JsonResult HairLength_Load()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.HairLength_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["HairLength"].ToString() + " </td>";
                        jsonString += "<td class='tableCell'><img style='width: 36px;height: 36px;' src=\'" + actionResult.dtResult.Rows[i]["ImagePath"].ToString() + "\' /> </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditHairLength(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["HairLength"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteHairLength(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        public JsonResult TypeID1_IU(int id, string name)
        {
            string jsonString = string.Empty;
            try
            {
                MasterTypeID hairLengthBase = new MasterTypeID();
                hairLengthBase.ID = id;
                hairLengthBase.Value = name;
                actionResult = settingAction.MasterTypeID1_IU(hairLengthBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        public JsonResult TypeID2_IU(int id, string name)
        {
            string jsonString = string.Empty;
            try
            {
                MasterTypeID hairLengthBase = new MasterTypeID();
                hairLengthBase.ID = id;
                hairLengthBase.Value = name;
                actionResult = settingAction.MasterTypeID2_IU(hairLengthBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        public JsonResult TypeID3_IU(int id, string name)
        {
            string jsonString = string.Empty;
            try
            {
                MasterTypeID hairLengthBase = new MasterTypeID();
                hairLengthBase.ID = id;
                hairLengthBase.Value = name;
                actionResult = settingAction.MasterTypeID3_IU(hairLengthBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #region HairLength IU
        public JsonResult HairLength_IU()
        {
            string jsonString = string.Empty;
            try
            {
                HairLengthBase hairLengthBase = new HairLengthBase();
                hairLengthBase.ID = Convert.ToInt32(Request["ID"]);
                hairLengthBase.HairLength = Convert.ToString(Request["Name"]);

                if (Request.Files != null && Request.Files.Count == 1)
                {
                    HttpPostedFileBase file = Request.Files[0]; //Uploaded file

                    if (file != null && file.ContentLength > 0)
                    {
                        string directory = Server.MapPath("~/Content/ImagesHairLength/");
                        if (!Directory.Exists(directory))
                        {
                            Directory.CreateDirectory(directory);
                        }
                        string fileName = Convert.ToString(Guid.NewGuid()).Substring(0, 5) + Path.GetFileName(file.FileName);
                        string fullpath = "/Content/ImagesHairLength/" + fileName;
                        string path = Path.Combine(directory, fileName);
                        file.SaveAs(path);

                        hairLengthBase.ImagePath = fullpath;
                    }
                }
                actionResult = settingAction.HairLength_IU(hairLengthBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        public JsonResult MasterTypeID1_Delete(int id)
        {
            string jsonString = string.Empty;
            try
            {
                MasterTypeID hairLengthBase = new MasterTypeID();
                hairLengthBase.ID = id;
                actionResult = settingAction.MasterTypeID1_Delete(hairLengthBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MasterTypeID2_Delete(int id)
        {
            string jsonString = string.Empty;
            try
            {
                MasterTypeID hairLengthBase = new MasterTypeID();
                hairLengthBase.ID = id;
                actionResult = settingAction.MasterTypeID2_Delete(hairLengthBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MasterTypeID3_Delete(int id)
        {
            string jsonString = string.Empty;
            try
            {
                MasterTypeID hairLengthBase = new MasterTypeID();
                hairLengthBase.ID = id;
                actionResult = settingAction.MasterTypeID3_Delete(hairLengthBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #region HairLength Delete
        public JsonResult HairLength_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                HairLengthBase hairLengthBase = new HairLengthBase();
                hairLengthBase.ID = ID;
                actionResult = settingAction.HairLength_Delete(hairLengthBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // Hair Color
        #region Bind Hair Color
        public JsonResult HairColor_Load()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.HairColor_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["HairColor"].ToString() + " </td>";

                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditHairColor(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["HairColor"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteHairColor(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region HairColor IU
        public JsonResult HairColor_IU(int ID, string Name)
        {
            string jsonString = string.Empty;
            try
            {
                HairColorBase hairColorBase = new HairColorBase();
                hairColorBase.ID = ID;
                hairColorBase.HairColor = Name;
                actionResult = settingAction.HairColor_IU(hairColorBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region HairColor Delete
        public JsonResult HairColor_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                HairColorBase hairColorBase = new HairColorBase();
                hairColorBase.ID = ID;
                actionResult = settingAction.HairColor_Delete(hairColorBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // Facial Hair
        #region Bind Facial Hair
        public JsonResult FacialHair_Load()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.FacialHair_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["FacialHair"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditFacialHair(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["FacialHair"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteFacialHair(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region FacialHair IU
        public JsonResult FacialHair_IU(int ID, string Name)
        {
            string jsonString = string.Empty;
            try
            {
                FacialHairBase facialHairBase = new FacialHairBase();
                facialHairBase.ID = ID;
                facialHairBase.FacialHair = Name;
                actionResult = settingAction.FacialHair_IU(facialHairBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region FacialHair Delete
        public JsonResult FacialHair_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                FacialHairBase facialHairBase = new FacialHairBase();
                facialHairBase.ID = ID;
                actionResult = settingAction.FacialHair_Delete(facialHairBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // Race
        #region Bind Race
        public JsonResult MasterRace_Load()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.MasterRace_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["Race"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditRace(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["Race"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteRace(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Race IU
        public JsonResult MasterRace_IU(int ID, string Name)
        {
            string jsonString = string.Empty;
            try
            {
                RaceBase raceBase = new RaceBase();
                raceBase.ID = ID;
                raceBase.Race = Name;
                actionResult = settingAction.MasterRace_IU(raceBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Race Delete
        public JsonResult MasterRace_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                RaceBase raceBase = new RaceBase();
                raceBase.ID = ID;
                actionResult = settingAction.MasterRace_Delete(raceBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // Eyes
        #region Bind Eyes
        public JsonResult MasterEyes_Load()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.MasterEyes_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["Eyes"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditEyes(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["Eyes"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteEyes(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Eyes IU
        public JsonResult MasterEyes_IU(int ID, string Name)
        {
            string jsonString = string.Empty;
            try
            {
                EyesBase eyesBase = new EyesBase();
                eyesBase.ID = ID;
                eyesBase.Eyes = Name;
                actionResult = settingAction.MasterEyes_IU(eyesBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Eyes Delete
        public JsonResult MasterEyes_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                EyesBase eyesBase = new EyesBase();
                eyesBase.ID = ID;
                actionResult = settingAction.MasterEyes_Delete(eyesBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // Sex
        #region Bind Sex
        public JsonResult MasterSex_Load()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.MasterSex_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["Sex"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditSex(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["Sex"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteSex(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Sex IU
        public JsonResult MasterSex_IU(int ID, string Name)
        {
            string jsonString = string.Empty;
            try
            {
                SexBase sexBase = new SexBase();
                sexBase.ID = ID;
                sexBase.Sex = Name;
                actionResult = settingAction.MasterSex_IU(sexBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Sex Delete
        public JsonResult MasterSex_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                SexBase sexBase = new SexBase();
                sexBase.ID = ID;
                actionResult = settingAction.MasterSex_Delete(sexBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // Employee Position
        #region Bind Employee Position
        public JsonResult EmployeePosition_Load()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.EmployeePosition_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["Position"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditPosition(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["Position"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeletePosition(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Employee Position IU
        public JsonResult EmployeePosition_IU(int ID, string Name)
        {
            string jsonString = string.Empty;
            try
            {
                EmployeePositionBase empPositionBase = new EmployeePositionBase();
                empPositionBase.ID = ID;
                empPositionBase.Position = Name;
                actionResult = settingAction.EmployeePosition_IU(empPositionBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Employee Position Delete
        public JsonResult EmployeePosition_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                EmployeePositionBase empPositionBase = new EmployeePositionBase();
                empPositionBase.ID = ID;
                actionResult = settingAction.EmployeePosition_Delete(empPositionBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // EquipmentsProblems
        #region Bind Equipments Problems
        public JsonResult EquipmentStatus_Load()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.EquipmentStatus_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["Problems"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditEquipmentProblems(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["Problems"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteEquipmentProblems(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Equipments Problems IU
        public JsonResult EquipmentStatus_IU(int ID, string Name)
        {
            string jsonString = string.Empty;
            try
            {
                EquipmentStatusBase statusBase = new EquipmentStatusBase();
                statusBase.ID = ID;
                statusBase.Problems = Name;
                actionResult = settingAction.EquipmentStatus_IU(statusBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region EquipmentsProblems Delete
        public JsonResult EquipmentStatus_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                EquipmentStatusBase statusBase = new EquipmentStatusBase();
                statusBase.ID = ID;
                actionResult = settingAction.EquipmentStatus_Delete(statusBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // EquipmentsAction
        #region Bind Equipments Action
        public JsonResult EquipmentsAction_Load()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.EquipmentAction_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["Actions"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditEquipmentAction(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["Actions"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteEquipmentAction(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Equipments Action IU
        public JsonResult EquipmentAction_IU(int ID, string Name)
        {
            string jsonString = string.Empty;
            try
            {
                EquipmentActionBase actionBase = new EquipmentActionBase();
                actionBase.ID = ID;
                actionBase.Actions = Name;
                actionResult = settingAction.EquipmentAction_IU(actionBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region EquipmentsAction Delete
        public JsonResult EquipmentAction_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                EquipmentActionBase actionBase = new EquipmentActionBase();
                actionBase.ID = ID;
                actionResult = settingAction.EquipmentAction_Delete(actionBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion


        /// <summary>
        /// Report Setting
        /// </summary>
        public ActionResult ReportSetting()
        {

            return View();
        }

        // Short Descriptor
        #region Bind ShortDescriptor
        public JsonResult MasterShortDescriptor_Load(int NatureID)
        {
            string jsonString = string.Empty;

            ShortDescriptorBase shortBase = new ShortDescriptorBase();
            shortBase.NatureID = NatureID;
            try
            {
                actionResult = settingAction.MasterShortDescriptor_Load(shortBase);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += " <option value = " + actionResult.dtResult.Rows[i]["Id"] + " onclick = \"EditShortDescriptor(" + actionResult.dtResult.Rows[i]["Id"] + ",'" + actionResult.dtResult.Rows[i]["Descriptor"] + "'); \" > " + actionResult.dtResult.Rows[i]["Descriptor"] + " </ option >";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Bind ShortDescriptor
        public JsonResult MasterShortDescriptor_DestilsbyID(int ID)
        {
            string jsonString = string.Empty;

            ShortDescriptorBase shortBase = new ShortDescriptorBase();
            shortBase.ID = ID;
            try
            {
                actionResult = settingAction.MasterShortDescriptor_DestilsbyID(shortBase);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString = actionResult.dtResult.Rows[i]["ProShortDescriptor"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        //Ankur
        //#region Image Short Descriptor IU
        //public ActionResult MasterImageShortDescriptor_IU(int ID, HttpPostedFileBase file)
        //{
        //    string jsonString = string.Empty;
        //    if (file != null && file.ContentLength > 0)
        //        try
        //        {
                    
        //            string path = Path.Combine(Server.MapPath("~/Images"),Path.GetFileName(file.FileName));
        //            string ImageName = Path.GetFileName(file.FileName);
        //            ShortDescriptorBase shortBase = new ShortDescriptorBase();
        //            shortBase.ID = ID;
        //            shortBase.ImageName = ImageName;
        //            //SqlCommand cmd = new SqlCommand("UPDATE AB_Test SET [imageName]='" + ImageName + "' WHERE [Name]='Ankur'", con);
        //            //con.Open();
        //            //result = cmd.ExecuteNonQuery();
        //            actionResult = settingAction.MasterImageShortDescriptor_IU(shortBase);
        //            if (actionResult.IsSuccess)
        //            {
        //                jsonString = "success";
        //            }
        //            else
        //            {
        //                jsonString = "error";
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            jsonString = "-1";
        //            return Json(jsonString, JsonRequestBehavior.AllowGet);
        //        }
        //    else
        //    {
        //        ViewBag.Message = "You have not specified a file.";
        //    }
        //    return View();
        //}
        //#endregion


        //Ankur New 1
        public ActionResult InsertUpdatePreferenceValue(HttpPostedFileBase file)
        {
            
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    string path = Path.Combine(Server.MapPath("~/assets/images"), Path.GetFileName(file.FileName));
                    string ImageName = Path.GetFileName(file.FileName);
                    Incedent_Pref incedentpref = new Incedent_Pref();
                    incedentpref.pref_Type = "narureOfIncedent";
                    incedentpref.pref_Value = ImageName;
                    actionResult = settingAction.InsertUpdatePreferenceValue(incedentpref);
                    file.SaveAs(path);
                    TempData["message"]="Success";
                    return RedirectToAction("ReportSetting");
                }
                catch (Exception ex)
                {
                    TempData["message"] = "ERROR:" + ex.Message.ToString();
                    return View();
                }
            }
            else
            {
                TempData["message"] = "please upload a file";
            }
            return RedirectToAction("ReportSetting");
        }

        //ANkur new 1
        #region Short Descriptor IU
        [HttpPost]
        public JsonResult MasterShortDescriptor_IU(int ID, string Name, int NatureID, string Pro)
        {
            string jsonString = string.Empty;
            try
            {
                ShortDescriptorBase shortBase = new ShortDescriptorBase();
                shortBase.ID = ID;
                shortBase.Descriptor = Name;
                shortBase.NatureID = NatureID;
                shortBase.ProShortDescriptor = Pro;
                actionResult = settingAction.MasterShortDescriptor_IU(shortBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region ShortDescriptor Delete
        public JsonResult MasterShortDescriptor_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                ShortDescriptorBase shortBase = new ShortDescriptorBase();
                shortBase.ID = ID;
                actionResult = settingAction.MasterShortDescriptor_Delete(shortBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // Nature of Incident
        #region Bind Nature of Incident
        public JsonResult MasterNatureofIncident_Load(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                NatureofIncidentBase natureBase = new NatureofIncidentBase();
                natureBase.NatureType = ID;
                actionResult = settingAction.MasterNatureofIncident_Load(natureBase);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += " <option value = " + actionResult.dtResult.Rows[i]["Id"] + " onclick = \"EditNatureofIncident(" + actionResult.dtResult.Rows[i]["Id"] + ",'" + actionResult.dtResult.Rows[i]["Nature"] + "'); \" > " + actionResult.dtResult.Rows[i]["Nature"] + " </ option >";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        public JsonResult GetNatureImage(int ID,string Name)
        {
            string jsonString = string.Empty;
            try
            {
                NatureofIncidentBase natureBase = new NatureofIncidentBase();
                natureBase.NatureType = ID;
                natureBase.Nature = Name;
                actionResult = settingAction.MasterNatureofIncident_Load(natureBase);
                actionResult = settingAction.GetNatureImage(natureBase);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        //jsonString += " <option value = " + actionResult.dtResult.Rows[i]["Id"] + " onclick = \"EditNatureofIncident(" + actionResult.dtResult.Rows[i]["Id"] + ",'" + actionResult.dtResult.Rows[i]["Nature"] + "'); \" > " + actionResult.dtResult.Rows[i]["Nature"] + " </ option >";
                        jsonString += actionResult.dtResult.Rows[i]["NatureImage"];
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }

        #region Nature of Incident IU
        public ActionResult MasterNatureofIncident_IU(int hdNatureofIncidentID, string NatureofIncidentName, int Radio1, HttpPostedFileBase file,string hdNatureimage)
        {
            //string jsonString = string.Empty;
            string path = "";
            string ImageName = "";

            try
            {
                NatureofIncidentBase natureBase = new NatureofIncidentBase();
                if (file != null && file.ContentLength > 0)
                {
                    path = Path.Combine(Server.MapPath("~/assets/images"), Path.GetFileName(file.FileName));
                    ImageName = Path.GetFileName(file.FileName);
                    file.SaveAs(path);

                }
                else
                {
                    ImageName = hdNatureimage;
                }

                natureBase.ID = hdNatureofIncidentID;
                natureBase.Nature = NatureofIncidentName;
                natureBase.NatureType = Radio1;
                natureBase.NatureImage = ImageName;
                
                actionResult = settingAction.MasterNatureofIncident_IU(natureBase);
                if (actionResult.IsSuccess)
                {
                    TempData["SuccessMessage"] = "Short Descriptor save Successfully.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Some error Occurred, please try again later.";
                }
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Some error Occurred, please try again later.";
                //return Json(jsonString, JsonRequestBehavior.AllowGet);
                return RedirectToAction("ReportSetting");
            }
            return RedirectToAction("ReportSetting");
            //return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Nature of Incident Delete
        public JsonResult MasterNatureofIncident_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                NatureofIncidentBase natureBase = new NatureofIncidentBase();
                natureBase.ID = ID;
                actionResult = settingAction.MasterNatureofIncident_Delete(natureBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // Status
        #region Bind Status
        public JsonResult MasterStatus_Load()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.MasterStatus_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["Status"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditStatus(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["Status"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteStatus(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Status IU
        public JsonResult MasterStatus_IU(int ID, string Name)
        {
            string jsonString = string.Empty;
            try
            {
                StatusBase statusBase = new StatusBase();
                statusBase.ID = ID;
                statusBase.Status = Name;
                actionResult = settingAction.MasterStatus_IU(statusBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Status Delete
        public JsonResult MasterStatus_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                StatusBase statusBase = new StatusBase();
                statusBase.ID = ID;
                actionResult = settingAction.MasterStatus_Delete(statusBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // Role
        #region Bind Role
        public JsonResult MasterRole_Load()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.MasterRole_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["Role"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditRole(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["Role"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteRole(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Role IU
        public JsonResult MasterRole_IU(int ID, string Name)
        {
            string jsonString = string.Empty;
            try
            {
                RoleBase roleBase = new RoleBase();
                roleBase.ID = ID;
                roleBase.Role = Name;
                actionResult = settingAction.MasterRole_IU(roleBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Role Delete
        public JsonResult MasterRole_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                RoleBase roleBase = new RoleBase();
                roleBase.ID = ID;
                actionResult = settingAction.MasterRole_Delete(roleBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // Game
        #region Bind Game
        public JsonResult MasterGame_Load()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.MasterGame_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["Game"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditGame(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["Game"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteGame(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Game IU
        public JsonResult MasterGame_IU(int ID, string Name)
        {
            string jsonString = string.Empty;
            try
            {
                GameBase gameBase = new GameBase();
                gameBase.ID = ID;
                gameBase.Game = Name;
                actionResult = settingAction.MasterGame_IU(gameBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Game Delete
        public JsonResult MasterGame_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                GameBase gameBase = new GameBase();
                gameBase.ID = ID;
                actionResult = settingAction.MasterGame_Delete(gameBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // BuyInGame
        #region Bind BuyInGame
        public JsonResult MasterBuyInGame_Load()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.MasterBuyInGame_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["Game"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditBuyInGame(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["Game"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteBuyInGame(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region BuyInGame IU
        public JsonResult MasterBuyInGame_IU(int ID, string Name)
        {
            string jsonString = string.Empty;
            try
            {
                BuyInGameBase gameBase = new BuyInGameBase();
                gameBase.ID = ID;
                gameBase.Game = Name;
                actionResult = settingAction.MasterBuyInGame_IU(gameBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region BuyInGame Delete
        public JsonResult MasterBuyInGame_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                BuyInGameBase gameBase = new BuyInGameBase();
                gameBase.ID = ID;
                actionResult = settingAction.MasterBuyInGame_Delete(gameBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // BuyInGame
        #region Bind CashoutTableNumber
        public JsonResult MasterCashoutTableNumber_Load()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.MasterCashoutTableNumber_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["TableNumber"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditCashoutTableNumber(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["TableNumber"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteCashoutTableNumber(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region CashoutTableName IU
        public JsonResult MasterCashoutTableNumber_IU(int ID, string TableNumber)
        {
            string jsonString = string.Empty;
            try
            {
                CashoutTableNumberBase tablenumberBase = new CashoutTableNumberBase();
                tablenumberBase.ID = ID;
                tablenumberBase.TableNumber = TableNumber;
                actionResult = settingAction.MasterCashoutTableNumber_IU(tablenumberBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region BuyInGame Delete
        public JsonResult MasterCashoutTableNumber_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                CashoutTableNumberBase tablenumberBase = new CashoutTableNumberBase();
                tablenumberBase.ID = ID;
                actionResult = settingAction.MasterCashoutTableNumber_Delete(tablenumberBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // DisputeType
        #region Bind DisputeType
        public JsonResult MasterDisputeType_Load()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.MasterDisputeType_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["DisputeType"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditDisputeType(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["DisputeType"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteDisputeType(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region DisputeType IU
        public JsonResult MasterDisputeType_IU(int ID, string Name)
        {
            string jsonString = string.Empty;
            try
            {
                DisputeTypeBase disputeBase = new DisputeTypeBase();
                disputeBase.ID = ID;
                disputeBase.DisputeType = Name;
                actionResult = settingAction.MasterDisputeType_IU(disputeBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region DisputeType Delete
        public JsonResult MasterDisputeType_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                DisputeTypeBase disputeBase = new DisputeTypeBase();
                disputeBase.ID = ID;
                actionResult = settingAction.MasterDisputeType_Delete(disputeBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // BuyInPitType
        #region Bind BuyInPitType
        public JsonResult MasterBuyInPitType_Load()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.MasterBuyInPitType_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["BuyInPitType"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditBuyInPitType(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["BuyInPitType"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteBuyInPitType(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region BuyInPitType IU
        public JsonResult MasterBuyInPitType_IU(int ID, string Name)
        {
            string jsonString = string.Empty;
            try
            {
                BuyInPitTypeBase buyintypeBase = new BuyInPitTypeBase();
                buyintypeBase.ID = ID;
                buyintypeBase.BuyInPitType = Name;
                actionResult = settingAction.MasterBuyInPitType_IU(buyintypeBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region BuyInPitType Delete
        public JsonResult MasterBuyInPitType_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                BuyInPitTypeBase buyintypeBase = new BuyInPitTypeBase();
                buyintypeBase.ID = ID;
                actionResult = settingAction.MasterBuyInPitType_Delete(buyintypeBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion


        // Dispute Resolution
        #region Bind Dispute Resolution
        public JsonResult DisputeResolution_Load()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.DisputeResolution_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["Resolution"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditResolution(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["Resolution"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteResolution(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Dispute Resolution IU
        public JsonResult DisputeResolution_IU(int ID, string Name)
        {
            string jsonString = string.Empty;
            try
            {
                ResolutionBase resolutionBase = new ResolutionBase();
                resolutionBase.ID = ID;
                resolutionBase.Resolution = Name;
                actionResult = settingAction.DisputeResolution_IU(resolutionBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Dispute Resolution Delete
        public JsonResult DisputeResolution_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                ResolutionBase resolutionBase = new ResolutionBase();
                resolutionBase.ID = ID;
                actionResult = settingAction.DisputeResolution_Delete(resolutionBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // Cashier
        #region Bind Cashier
        public JsonResult CashierName_Load()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.CashierName_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["CashierName"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditCashier(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["CashierName"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteCashier(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Cashier IU
        public JsonResult CashierName_IU(int ID, string Name)
        {
            string jsonString = string.Empty;
            try
            {
                CashierBase cashierBase = new CashierBase();
                cashierBase.ID = ID;
                cashierBase.Cashier = Name;
                actionResult = settingAction.CashierName_IU(cashierBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Cashier Delete
        public JsonResult CashierName_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                CashierBase cashierBase = new CashierBase();
                cashierBase.ID = ID;
                actionResult = settingAction.CashierName_Delete(cashierBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // Location
        #region Bind Location
        public JsonResult Location_Load()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.Location_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["Location"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditLocation(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["Location"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteLocation(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Location IU
        public JsonResult Location_IU(int ID, string Name)
        {
            string jsonString = string.Empty;
            try
            {
                LocationBase locationBase = new LocationBase();
                locationBase.ID = ID;
                locationBase.Location = Name;
                actionResult = settingAction.Location_IU(locationBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Location Delete
        public JsonResult Location_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                LocationBase locationBase = new LocationBase();
                locationBase.ID = ID;
                actionResult = settingAction.Location_Delete(locationBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // Vehicle Color
        #region Bind Vehicle Color
        public JsonResult VehicleColor_Load()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.VehicleColor_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["Color"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditColor(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["Color"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteColor(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Vehicle Color IU
        public JsonResult VehicleColor_IU(int ID, string Name)
        {
            string jsonString = string.Empty;
            try
            {
                VehicleColorBase colorBase = new VehicleColorBase();
                colorBase.ID = ID;
                colorBase.Color = Name;
                actionResult = settingAction.VehicleColor_IU(colorBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Vehicle Color Delete
        public JsonResult VehicleColor_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                VehicleColorBase colorBase = new VehicleColorBase();
                colorBase.ID = ID;
                actionResult = settingAction.VehicleColor_Delete(colorBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        public JsonResult MstBanType_Load()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.MstBanType_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["TypeOfBan"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditBanTypeBy(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["TypeOfBan"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='MSTBanTypeDelete(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MstBanType_IU(int ID, string Name)
        {
            string jsonString = string.Empty;
            try
            {
                TypeofBan authorizedBy = new TypeofBan();
                authorizedBy.ID = ID;
                authorizedBy.BanType = Name;
                actionResult = settingAction.MstBanType_IU(authorizedBy);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MstBanType_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                TypeofBan authorizedBy = new TypeofBan();
                authorizedBy.ID = ID;
                actionResult = settingAction.MstBanType_Delete(authorizedBy);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        // AuthorizedBy
        #region Bind AuthorizedBy
        public JsonResult BanAuthorizedBy_Load()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.BanAuthorizedBy_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["AuthorizedBy"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditAuthorizedBy(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["AuthorizedBy"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteAuthorizedBy(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region AuthorizedBy IU
        public JsonResult BanAuthorizedBy_IU(int ID, string Name)
        {
            string jsonString = string.Empty;
            try
            {
                AuthorizedByBase authorizedBy = new AuthorizedByBase();
                authorizedBy.ID = ID;
                authorizedBy.AuthorizedBy = Name;
                actionResult = settingAction.BanAuthorizedBy_IU(authorizedBy);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region AuthorizedBy Delete
        public JsonResult BanAuthorizedBy_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                AuthorizedByBase authorizedBy = new AuthorizedByBase();
                authorizedBy.ID = ID;
                actionResult = settingAction.BanAuthorizedBy_Delete(authorizedBy);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // AddressType
        #region Bind AddressType
        public JsonResult AddressType_Load()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.AddressType_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["AddressType"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditAddressType(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["AddressType"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteAddressType(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region AddressType IU
        public JsonResult AddressType_IU(int ID, string Name)
        {
            string jsonString = string.Empty;
            try
            {
                AddressTypeBase addressTypeBase = new AddressTypeBase();
                addressTypeBase.ID = ID;
                addressTypeBase.AddressType = Name;
                actionResult = settingAction.AddressType_IU(addressTypeBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region AddressType Delete
        public JsonResult AddressType_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                AddressTypeBase addressTypeBase = new AddressTypeBase();
                addressTypeBase.ID = ID;
                actionResult = settingAction.AddressType_Delete(addressTypeBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // VarianceType
        #region Bind VarianceType
        public JsonResult VarianceType_Load()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.VarianceType_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["VarianceType"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditVarianceType(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["VarianceType"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteVarianceType(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region VarianceType IU
        public JsonResult VarianceType_IU(int ID, string Name)
        {
            string jsonString = string.Empty;
            try
            {
                VarianceTypeBase VarianceTypeBase = new VarianceTypeBase();
                VarianceTypeBase.ID = ID;
                VarianceTypeBase.VarianceType = Name;
                actionResult = settingAction.VarianceType_IU(VarianceTypeBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region VarianceType Delete
        public JsonResult VarianceType_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                VarianceTypeBase VarianceTypeBase = new VarianceTypeBase();
                VarianceTypeBase.ID = ID;
                actionResult = settingAction.VarianceType_Delete(VarianceTypeBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // VarianceResolution
        #region Bind VarianceResolution
        public JsonResult VarianceResolution_Load()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.VarianceResolution_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["Resolution"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditVarianceResolution(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["Resolution"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteVarianceResolution(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region VarianceResolution IU
        public JsonResult VarianceResolution_IU(int ID, string Name)
        {
            string jsonString = string.Empty;
            try
            {
                VarianceResolutionBase varianceResBase = new VarianceResolutionBase();
                varianceResBase.ID = ID;
                varianceResBase.Resolution = Name;
                actionResult = settingAction.VarianceResolution_IU(varianceResBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        //Ab New 22/2
        //Audit

        #region Bind Audit
        public JsonResult Audit_Load()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.Audit_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["QuestionID"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["AuditType"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditAudit(" + actionResult.dtResult.Rows[i]["QuestionID"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["AuditType"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteAudit(" + actionResult.dtResult.Rows[i]["QuestionID"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        //Ab New 22/2
        #region Audit IU
        public JsonResult Audit_IU(int ID, string Name)
        {
            string jsonString = string.Empty;
            try
            {
                //VarianceResolutionBase varianceResBase = new VarianceResolutionBase();
                //varianceResBase.ID = ID;
                //varianceResBase.Resolution = Name;
                actionResult = settingAction.Audit_IU(ID, Name);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateAudit(int AuditID, string AuditName)
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.Audit_IU(AuditID, AuditName);

                if (actionResult.IsSuccess)
                {
                    //jsonString = "success";
                    if(AuditID ==0)
                        AuditID =  Convert.ToInt32(actionResult.dtResult.Rows[0][0]);
                    return RedirectToAction("AddAuditQuestion", new { @AuditID = AuditID, @AuditName = AuditName });

                    //ManageAuditsQuestionsModel model = new ManageAuditsQuestionsModel();
                    //List<AuditsQuestions> auditsQuestionListModel = new List<AuditsQuestions>();
                    //AuditsQuestions auditsQuestionModel = new AuditsQuestions();
                    //model.auditsQuestionList = auditsQuestionListModel;
                    //model.auditsQuestionModel = auditsQuestionModel;

                    //model.auditsQuestionModel.AuditID = Convert.ToInt32(actionResult.dtResult.Rows[0][0]);
                    //actionResult = settingAction.LoadAuditQuestionsByAuditID(model.auditsQuestionModel.AuditID);
                    //if (actionResult.IsSuccess)
                    //{
                    //    model.auditsQuestionModel.Audit = Convert.ToString(actionResult.dtResult.Rows[0]["Audit"]);
                    //    auditsQuestionListModel = CommonMethods.ConvertTo<AuditsQuestions>(actionResult.dtResult);
                    //}
                    //model.auditsQuestionList = auditsQuestionListModel;

                    //return View(model);
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddAuditQuestion(int AuditID, string AuditName)
        {
            string jsonString = string.Empty;

            try
            {
                if (AuditID > 0)
                {
                    //jsonString = "success";
                    ManageAuditsQuestionsModel model = new ManageAuditsQuestionsModel();
                    List<AuditsQuestions> auditsQuestionListModel = new List<AuditsQuestions>();
                    AuditsQuestions auditsQuestionModel = new AuditsQuestions();
                    model.auditsQuestionList = auditsQuestionListModel;
                    model.auditsQuestionModel = auditsQuestionModel;

                    List<SelectListItem> qutype = new List<SelectListItem>();
                    qutype.Add(new SelectListItem() { Value = "1", Text = "Yes/No" });
                    qutype.Add(new SelectListItem() { Value = "2", Text = "Rate On 1-10" });
                    model.auditsQuestionModel.QuestionTypeList = qutype;
                    model.auditsQuestionModel.AuditID = AuditID;
                    model.auditsQuestionModel.Audit = AuditName;
                    actionResult = settingAction.LoadAuditQuestionsByAuditID(model.auditsQuestionModel.AuditID);
                    if (actionResult.IsSuccess)
                    {
                        model.auditsQuestionModel.Audit = Convert.ToString(actionResult.dtResult.Rows[0]["Audit"]);
                        auditsQuestionListModel = CommonMethods.ConvertTo<AuditsQuestions>(actionResult.dtResult);
                    }
                    model.auditsQuestionList = auditsQuestionListModel;

                    return View(model);
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddAuditQuestion(ManageAuditsQuestionsModel model )
        {
            AuditsQuestionsVM aq = new AuditsQuestionsVM();

            try
            {
                aq.AuditID = model.auditsQuestionModel.AuditID;
                aq.Question = model.auditsQuestionModel.Question;
                aq.QuestionType = model.auditsQuestionModel.QuestionType;
                aq.QuestionID = model.auditsQuestionModel.QuestionID;

                actionResult = settingAction.AuditQuestion_IU(aq);
                if (actionResult.IsSuccess)
                {
                    int result = Convert.ToInt32(actionResult.dtResult.Rows[0][0]);
                    if (result > 0)
                    {
                        if (aq.QuestionID > 0)
                            TempData["SuccessMessage"] = "Audit Question Updated Successfully.";
                        else
                            TempData["SuccessMessage"] = "Audit Question Added Successfully.";
                    }
                    else
                        TempData["ErrorMessage"] = "Some error Occurred, please try again later.";

                }
                else
                    TempData["ErrorMessage"] = "Some error Occurred, please try again later.";

            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return RedirectToAction("AddAuditQuestion", new { @AuditID = aq.AuditID });
        }

        [HttpGet]
        public JsonResult GetAuditQuestionById(int? Id = 0)
        {
            string json = "";
            //ManageAuditsQuestionsModel model = new ManageAuditsQuestionsModel();
            List<AuditsQuestionsVM> auditsQuestionListModel = new List<AuditsQuestionsVM>();
            AuditsQuestionsVM auditsQuestionModel = new AuditsQuestionsVM();
            //model.auditsQuestionList = addressListModel;
            //model.auditsQuestionModel = addressModel;
            try
            {
                if (Id > 0)
                {
                    //AuditsQuestions auditquestion = new AuditsQuestions();
                    //auditquestion.QuestionID = Convert.ToInt32(Id);
                    actionResult = settingAction.GetAuditQuestionById(Convert.ToInt32(Id));
                    if (actionResult.IsSuccess)
                    {
                        auditsQuestionListModel = CommonMethods.ConvertTo<AuditsQuestionsVM>(actionResult.dtResult);
                        if (auditsQuestionListModel.Count > 0)
                            auditsQuestionModel = auditsQuestionListModel.FirstOrDefault();
                        json = Newtonsoft.Json.JsonConvert.SerializeObject(auditsQuestionModel);
                    }
                }

            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteAuditQuestion(int? QuestionId = 0)
        {
            string json = "";
            try
            {
                if (QuestionId > 0)
                {
                    actionResult = settingAction.DeleteQuestionById(Convert.ToInt32(QuestionId));
                    if (actionResult.IsSuccess)
                    {
                        json = "success";
                    }
                    else {
                        json = "fail";
                    }
                }

            }
            catch (Exception ex)
            {
                json = "-1";
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        #endregion

        //AB New 22/2
        #region Audit Delete
        public JsonResult Audit_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                //VarianceResolutionBase varianceResBase = new VarianceResolutionBase();
                //varianceResBase.ID = ID;
                actionResult = settingAction.Audit_Delete(ID);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region VarianceResolution Delete
        public JsonResult VarianceResolution_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                VarianceResolutionBase varianceResBase = new VarianceResolutionBase();
                varianceResBase.ID = ID;
                actionResult = settingAction.VarianceResolution_Delete(varianceResBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // AliasNameType
        #region Bind AliasNameType_Load
        public JsonResult AliasNameType_Load()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.AliasNameType_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["NameType"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditAliasNameType(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["NameType"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteAliasNameType(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Alias Name Type IU
        public JsonResult AliasNameType_IU(int ID, string Name)
        {
            string jsonString = string.Empty;
            try
            {
                AliasNameTypeBase aliasBase = new AliasNameTypeBase();
                aliasBase.ID = ID;
                aliasBase.NameType = Name;
                actionResult = settingAction.AliasNameType_IU(aliasBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region AliasNameType Delete
        public JsonResult AliasNameType_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                AliasNameTypeBase varianceResBase = new AliasNameTypeBase();
                varianceResBase.ID = ID;
                actionResult = settingAction.AliasNameType_Delete(varianceResBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // Foreign Exchange Rates Load
        #region Bind ForeignExchangeRates_Load
        public JsonResult ForeignExchangeRates_Load()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.ForeignExchangeRates_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["Country"].ToString() + " </td>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["Rate"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditForeignExchangeRates(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["Country"].ToString() + "&#39;,&#39;" + actionResult.dtResult.Rows[i]["Rate"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteForeignExchangeRates(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Foreign Exchange Rates IU
        public JsonResult ForeignExchangeRates_IU(int ID, string Country,string Rate)
        {
            string jsonString = string.Empty;
            try
            {
                ForeignExchangeRatesBase exchangeBase = new ForeignExchangeRatesBase();
                exchangeBase.ID = ID;
                exchangeBase.Country = Country;
                exchangeBase.Rate = Rate;
                actionResult = settingAction.ForeignExchangeRates_IU(exchangeBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Foreign Exchange Rates Delete
        public JsonResult ForeignExchangeRates_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                ForeignExchangeRatesBase exchangeBase = new ForeignExchangeRatesBase();
                exchangeBase.ID = ID;
                actionResult = settingAction.ForeignExchangeRates_Delete(exchangeBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // Services
        #region Bind Services 
        public JsonResult Services_LoadAll()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.Services_LoadAll();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["ServiceName"].ToString() + " </td>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["DeclinedAvailable"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditServices(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["ServiceName"].ToString() + "&#39;,&#39;" + actionResult.dtResult.Rows[i]["DeclinedAvailable"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteServices(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Services IU
        public JsonResult Services_IU(int ID, string Name, string Declined)
        {
            string jsonString = string.Empty;
            try
            {
                ServicesBase serviceBase = new ServicesBase();
                serviceBase.ID = ID;
                serviceBase.ServiceName = Name;
                serviceBase.DeclinedAvailable = Declined;
                actionResult = settingAction.Services_IU(serviceBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Services Delete
        public JsonResult Services_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                ServicesBase serviceBase = new ServicesBase();
                serviceBase.ID = ID;
                actionResult = settingAction.Services_Delete(serviceBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // InitiatedBy
        #region Bind InitiatedBy
        public JsonResult InitiatedBy_Load()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.InitiatedBy_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["Initiated"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditInitiatedBy(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["Initiated"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteInitiatedBy(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region InitiatedBy IU
        public JsonResult InitiatedBy_IU(int ID, string Name)
        {
            string jsonString = string.Empty;
            try
            {
                InitiatedByBase initiatedBase = new InitiatedByBase();
                initiatedBase.ID = ID;
                initiatedBase.Initiated = Name;
                actionResult = settingAction.InitiatedBy_IU(initiatedBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region InitiatedBy Delete
        public JsonResult InitiatedBy_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                InitiatedByBase initiatedBase = new InitiatedByBase();
                initiatedBase.ID = ID;
                actionResult = settingAction.InitiatedBy_Delete(initiatedBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // Nature of Event Code
        #region Bind NatureCodes
        public JsonResult NatureCodes_LoadAll()
        {
            string jsonString = string.Empty;
            try
            {
                CIMS.ActionLayer.Events.EventAction eventAction = new CIMS.ActionLayer.Events.EventAction();

                actionResult = eventAction.NatureCodes_LoadAll();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["Code"].ToString() + " </td>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["Description"].ToString() + " </td>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["DefaultAction"].ToString() + " </td>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["DefaultCamera"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditNatureCodes(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["Code"].ToString() + "&#39;,&#39;" + actionResult.dtResult.Rows[i]["Description"].ToString() + "&#39;,&#39;" + actionResult.dtResult.Rows[i]["DefaultAction"].ToString() + "&#39;,&#39;" + actionResult.dtResult.Rows[i]["DefaultCamera"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteNatureCodes(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region NatureCodes IU
        public JsonResult NatureCodes_IU(int ID, string Code, string Description, string DefaultAction, string DefaultCamera)
        {
            string jsonString = string.Empty;
            try
            {
                NatureEventBase natureEvent = new NatureEventBase();
                natureEvent.ID = ID;
                natureEvent.Code = Code;
                natureEvent.Description = Description;
                natureEvent.DefaultAction = DefaultAction;
                natureEvent.DefaultCamera = DefaultCamera;
                actionResult = settingAction.NatureCodes_IU(natureEvent);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region NatureCodes Delete
        public JsonResult NatureCodes_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                NatureEventBase natureEvent = new NatureEventBase();
                natureEvent.ID = ID;
                actionResult = settingAction.NatureCodes_Delete(natureEvent);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // Set Metrics
        #region Bind setmetrics
        public JsonResult setmetrics_LoadBy(string Type)
        {
            string jsonString = string.Empty;
            try
            {
                SetMetricsBase setMetricsBase = new SetMetricsBase();
                setMetricsBase.Type = Type;

                actionResult = settingAction.setmetrics_LoadBy(setMetricsBase);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["ID"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["metrics"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='Editsetmetrics(" + actionResult.dtResult.Rows[i]["ID"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["metrics"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='Deletesetmetrics(" + actionResult.dtResult.Rows[i]["ID"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td>";
                        jsonString += "<td class='tableCell'>";
                        if (actionResult.dtResult.Rows[i]["ActiveMetrics"].ToString() == "True")
                        {
                            jsonString += "<a class='btn btn-danger small btn-sm  add' href='javascript:;' title='Activated'><i class='fa fa-times'></i></a>";
                        }
                        else
                        {
                            jsonString += "<a class='btn btn-success small btn-sm add' href='javascript:;' onclick='Activesetmetrics(" + actionResult.dtResult.Rows[i]["ID"].ToString() + ",this);' title='Activate'><i class='fa fa-check-square-o'></i></a>";
                        }
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region setmetrics_IU
        public JsonResult setmetrics_IU(int ID, string Type, string Metrics)
        {
            string jsonString = string.Empty;
            try
            {
                SetMetricsBase setMetricsBase = new SetMetricsBase();
                setMetricsBase.ID = ID;
                setMetricsBase.Type = Type;
                setMetricsBase.Metrics = Metrics;
                actionResult = settingAction.setmetrics_IU(setMetricsBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Setmetrics Delete
        public JsonResult setmetrics_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                SetMetricsBase setMetricsBase = new SetMetricsBase();
                setMetricsBase.ID = ID;
                actionResult = settingAction.setmetrics_Delete(setMetricsBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region ActiveMetrics
        public JsonResult ActiveMetrics(int ID,string Type)
        {
            string jsonString = string.Empty;
            try
            {
                SetMetricsBase setMetricsBase = new SetMetricsBase();
                setMetricsBase.ID = ID;
                setMetricsBase.Type = Type;
                actionResult = settingAction.ActivateMetrics_ByID(setMetricsBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // Visitor Logo Image
        #region Bind Visitor Logo
        public JsonResult VisitorLogo()
        {
            string jsonString = string.Empty;
            try
            {
                LogoImageBase logoImageBase = new LogoImageBase();

                actionResult = settingAction.VistorLogoImage_Bind(logoImageBase);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["ID"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'><img style='width: 100px;' src=\'" + actionResult.dtResult.Rows[i]["ImagePath"].ToString() + "\' /> </td>";
                        jsonString += "<td class='tableCell'>";
                        if (actionResult.dtResult.Rows[i]["SetImage"].ToString() == "True")
                        {
                            jsonString += "<a class='btn btn-danger small btn-sm  add' href='javascript:;' title='Activated'><i class='fa fa-times'></i></a>";
                        }
                        else
                        {
                            jsonString += "<a class='btn btn-success small btn-sm add' href='javascript:;' onclick='SetVisitorLogo(" + actionResult.dtResult.Rows[i]["ID"].ToString() + ",this);' title='Activate'><i class='fa fa-check-square-o'></i></a>";
                        }
                        jsonString += "</td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteVisitorLogo(" + actionResult.dtResult.Rows[i]["ID"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Visitor_Add
        [HttpPost]
        public void Visitor_Add()
        {
           // string jsonString = string.Empty; 
            try
            {
                LogoImageBase logoImageBase = new LogoImageBase();
                string fullpath = "";
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    string directory = Server.MapPath("~/Content/VisitorLogo/");
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }
                    string fileName = Convert.ToString(Guid.NewGuid()).Substring(0, 5) + Path.GetFileName(file.FileName);
                    fullpath = "/Content/VisitorLogo/" + fileName;
                    string path = Path.Combine(directory, fileName);
                    file.SaveAs(path);                    

                    logoImageBase.ImagePath = fullpath;
                    logoImageBase.SetImage = false;
                    logoImageBase.CreatedBy = Session["UserID"].ToString();
                    actionResult = settingAction.VistorLogoImage_Add(logoImageBase);
                    //if (actionResult.IsSuccess)
                    //{
                    //    jsonString = "success";
                    //}
                    //else
                    //{
                    //    jsonString = "error";
                    //}
                }
            }
            catch (Exception)
            {
                //jsonString = "-1";
                //return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
           // return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Visitor Delete
        public JsonResult Visitor_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                LogoImageBase logoImageBase = new LogoImageBase();
                logoImageBase.ImageID = ID;
                actionResult = settingAction.VistorLogoImage_Delete(logoImageBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Active VisitorLogo
        public JsonResult ActiveVisitorLogo(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                LogoImageBase logoImageBase = new LogoImageBase();
                logoImageBase.ImageID = ID;
                actionResult = settingAction.VistorLogoImage_SetImage(logoImageBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // Reports Logo Image
        #region Bind Reports Logo
        public JsonResult ReportsLogo()
        {
            string jsonString = string.Empty;
            try
            {
                LogoImageBase logoImageBase = new LogoImageBase();

                actionResult = settingAction.ReportLogoImage_Bind(logoImageBase);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["ID"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'><img style='width: 100px;' src=\'" + actionResult.dtResult.Rows[i]["ImagePath"].ToString() + "\' /> </td>";
                        jsonString += "<td class='tableCell'>";
                        if (actionResult.dtResult.Rows[i]["SetImage"].ToString() == "True")
                        {
                            jsonString += "<a class='btn btn-danger small btn-sm  add' href='javascript:;' title='Activated'><i class='fa fa-times'></i></a>";
                        }
                        else
                        {
                            jsonString += "<a class='btn btn-success small btn-sm add' href='javascript:;' onclick='SetReportLogo(" + actionResult.dtResult.Rows[i]["ID"].ToString() + ",this);' title='Activate'><i class='fa fa-check-square-o'></i></a>";
                        }
                        jsonString += "</td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteReportLogo(" + actionResult.dtResult.Rows[i]["ID"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Reports_Add
        [HttpPost]
        public void Reports_Add()
        {
            // string jsonString = string.Empty; 
            try
            {
                LogoImageBase logoImageBase = new LogoImageBase();
                string fullpath = "";
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    string directory = Server.MapPath("~/Content/ReportsLogo/");
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }
                    string fileName = Convert.ToString(Guid.NewGuid()).Substring(0, 5) + Path.GetFileName(file.FileName);
                    fullpath = "/Content/ReportsLogo/" + fileName;
                    string path = Path.Combine(directory, fileName);
                    file.SaveAs(path);

                    logoImageBase.ImagePath = fullpath;
                    logoImageBase.SetImage = false;
                    logoImageBase.CreatedBy = Session["UserID"].ToString();
                    actionResult = settingAction.ReportLogoImage_Add(logoImageBase);
                    //if (actionResult.IsSuccess)
                    //{
                    //    jsonString = "success";
                    //}
                    //else
                    //{
                    //    jsonString = "error";
                    //}
                }
            }
            catch (Exception)
            {
                //jsonString = "-1";
                //return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            // return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Reports Delete
        public JsonResult Reports_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                LogoImageBase logoImageBase = new LogoImageBase();
                logoImageBase.ImageID = ID;
                actionResult = settingAction.ReportLogoImage_Delete(logoImageBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Active ReportsLogo
        public JsonResult ActiveReportsLogo(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                LogoImageBase logoImageBase = new LogoImageBase();
                logoImageBase.ImageID = ID;
                actionResult = settingAction.ReportLogoImage_SetImage(logoImageBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion


        // Visitor Email Send
        #region Bind VisitorEmailSend
        public JsonResult VisitorEmailSend_LoadAll()
        {
            string jsonString = string.Empty;
            try
            {
                SettingAction settingAction = new SettingAction();

                actionResult = settingAction.VisitorEmailSend_Bind();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["Email"].ToString() + " </td>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["SMTP"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditVisitorEmailLog(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["Email"].ToString() + "&#39;,&#39;" + actionResult.dtResult.Rows[i]["SMTP"].ToString() + "&#39;,&#39;" + actionResult.dtResult.Rows[i]["Password"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='DeleteVisitorEmailLog(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region VisitorEmailSend IU
        public JsonResult VisitorEmailSend_AddEdit(int ID, string Email, string SMTP, string Password)
        {
            string jsonString = string.Empty;
            try
            {
                EmailLogBase emailLogBase = new EmailLogBase();
                emailLogBase.ID = ID;
                emailLogBase.Email = Email;
                emailLogBase.SMTP = SMTP;
                emailLogBase.Password = Password;
                emailLogBase.CreatedBy = Session["UserID"].ToString();
                actionResult = settingAction.VisitorEmailSend_AddEdit(emailLogBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region VisitorEmailSend Delete
        public JsonResult VisitorEmailSend_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                EmailLogBase emailLogBase = new EmailLogBase();
                emailLogBase.ID = ID;
                actionResult = settingAction.VisitorEmailSend_Delete(emailLogBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // Watch

        #region Bind Watch
        public JsonResult Masterwatch_Load()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = settingAction.Masterwatch_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["Id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["watch"].ToString() + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='Editwatch(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["watch"].ToString() + "&#39;);' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm ' href='javascript:;' onclick='Deletewatch(" + actionResult.dtResult.Rows[i]["Id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Eyes IU
        public JsonResult Masterwatch_IU(int ID, string Name)
        {
            string jsonString = string.Empty;
            try
            {
                watchbase watchbase = new watchbase();
                watchbase.ID = ID;
                watchbase.watch = Name;
                actionResult = settingAction.Masterwatch_IU(watchbase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        public JsonResult Masterwatch_selectall()
        {

            actionResult = settingAction.Masterwatch_Load();

            string jsonString = string.Empty;
            //jsonString = JsonConvert.SerializeObject(actionResult.dtResult);
            for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
            {
                jsonString += "," + actionResult.dtResult.Rows[i]["Id"].ToString() + ":" + actionResult.dtResult.Rows[i]["watch"].ToString();

            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
            // return actionResult.dtResult;


        }

        #region Eyes Delete
        public JsonResult Masterwatch_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                watchbase watchbase = new watchbase();
                watchbase.ID = ID;
                actionResult = settingAction.Masterwatch_Delete(watchbase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion



        // Weight Unit
        #region Bind Weight Unit
        public JsonResult WeightUnit_Load()
        {
            string jsonString = string.Empty;
            try
            {

                CIMS.ActionLayer.Employee.EmployeeAction employeeAction = new CIMS.ActionLayer.Employee.EmployeeAction();
                actionResult = employeeAction.MasterWeightUnit_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["WeightUnitName"].ToString() + " </td>";
                        jsonString += "<td class='tableCell'>" + (Convert.ToBoolean(actionResult.dtResult.Rows[i]["IsDefault"]) == true ? "Yes" : "No") + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditWeightUnit(" + actionResult.dtResult.Rows[i]["id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["WeightUnitName"].ToString() + "&#39;" + Convert.ToBoolean(actionResult.dtResult.Rows[i]["IsDefault"]).ToString() + "&#39;); ' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm' href='javascript:;' onclick='DeleteWeightUnit(" + actionResult.dtResult.Rows[i]["id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception ex)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Weight Unit IU
        public JsonResult WeightUnit_IU(int ID, string Name, bool IsDefault)
        {
            string jsonString = string.Empty;
            try
            {
                WeightUnitBase WeightUnitBase = new WeightUnitBase();
                WeightUnitBase.WeightUnitId = ID;
                WeightUnitBase.WeightUnitName = Name;
                WeightUnitBase.IsDefault = IsDefault;
                actionResult = settingAction.WeightUnit_IU(WeightUnitBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Weight Unit Delete
        public JsonResult WeightUnit_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                WeightUnitBase WeightUnitBase = new WeightUnitBase();
                WeightUnitBase.WeightUnitId = ID;
                actionResult = settingAction.WeightUnit_Delete(WeightUnitBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // Height Unit
        #region Bind Height Unit
        public JsonResult HeightUnit_Load()
        {
            string jsonString = string.Empty;
            try
            {

                CIMS.ActionLayer.Employee.EmployeeAction employeeAction = new CIMS.ActionLayer.Employee.EmployeeAction();
                actionResult = employeeAction.MasterHeightUnit_Load();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr class='tableRow' data-id=" + actionResult.dtResult.Rows[i]["id"].ToString() + " style='cursor: pointer'>";
                        jsonString += "<td class='tableCell'>" + actionResult.dtResult.Rows[i]["HeightUnitName"].ToString() + " </td>";
                        jsonString += "<td class='tableCell'>" + (Convert.ToBoolean(actionResult.dtResult.Rows[i]["IsDefault"]) == true ? "Yes" : "No")  + " </td>";
                        jsonString += "<td class='removefromtable'>";
                        jsonString += "<a href='javascript:;' onclick='EditHeightUnit(" + actionResult.dtResult.Rows[i]["id"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["HeightUnitName"].ToString() + "&#39;" + Convert.ToBoolean(actionResult.dtResult.Rows[i]["IsDefault"]).ToString() + "&#39;); ' class='btn small btn-info btn-sm btn-icon edit' title='Edit'><i class='fa fa-pencil'></i></a>";
                        jsonString += "<a class='btn btn-danger small btn-sm delete-sm' href='javascript:;' onclick='DeleteHeightUnit(" + actionResult.dtResult.Rows[i]["id"].ToString() + ",this);' title='Delete'><i class='fa fa-trash'></i></a>";
                        jsonString += "</td></tr>";
                    }
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Height Unit IU
        public JsonResult HeightUnit_IU(int ID, string Name, bool IsDefault)
        {
            string jsonString = string.Empty;
            try
            {
                HeightUnitBase HeightUnitBase = new HeightUnitBase();
                HeightUnitBase.HeightUnitId = ID;
                HeightUnitBase.HeightUnitName = Name;
                HeightUnitBase.IsDefault = IsDefault;
                actionResult = settingAction.HeightUnit_IU(HeightUnitBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Height Unit Delete
        public JsonResult HeightUnit_Delete(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                HeightUnitBase HeightUnitBase = new HeightUnitBase();
                HeightUnitBase.HeightUnitId = ID;
                actionResult = settingAction.HeightUnit_Delete(HeightUnitBase);
                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "error";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}