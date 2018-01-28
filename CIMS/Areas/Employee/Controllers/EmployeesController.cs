using CIMS.ActionLayer.Employee;
using CIMS.ActionLayer.Events;
using CIMS.ActionLayer.Subject;
using CIMS.BaseLayer.Employee;
using CIMS.BaseLayer.Events;
using CIMS.BaseLayer.Subject;
using CIMS.Filters;
using CIMS.Helpers;
using CIMS.Models;
using CIMS.Utility;

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CIMS.Areas.Employee.Controllers
{
    [CheckLogin]
    [CheckPermissionAttribute]
    public class EmployeesController : Controller
    {
        EmployeeAction employeeAction = new EmployeeAction();
        EmployeeBase employee = new EmployeeBase();
        SubjectBase subjectBase = new SubjectBase();
        SubjectAction subjectAction = new SubjectAction();
        List<SelectListItem> DisplayNameList = new List<SelectListItem>();
        List<SelectListItem> LocationList = new List<SelectListItem>();
        CIMS.BaseLayer.ActionResult actionResult;
        EventAction EventAction = new EventAction();

        // GET: Employee/Employees
        public ActionResult Employees(int? Id = 0)
        {
            EmployeeModel model = new EmployeeModel();
            List<SelectListItem> genderList = new List<SelectListItem>();
            model.EmployeeLinkedList = new List<EmployeeLinkedList>();

            CIMS.ActionLayer.Setting.SettingAction settingAction = new CIMS.ActionLayer.Setting.SettingAction();

            actionResult = settingAction.MasterSex_Load();
            if (actionResult.IsSuccess)
            {
                genderList = (from DataRow row in actionResult.dtResult.Rows
                              select new SelectListItem
                              {
                                  Text = row["Sex"] != DBNull.Value ? row["Sex"].ToString() : "",
                                  Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                              }).ToList();
            }

            List<SelectListItem> raceList = new List<SelectListItem>();
            actionResult = settingAction.MasterRace_Load();
            if (actionResult.IsSuccess)
            {
                raceList = (from DataRow row in actionResult.dtResult.Rows
                            select new SelectListItem
                            {
                                Text = row["Race"] != DBNull.Value ? row["Race"].ToString() : "",
                                Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                            }).ToList();
            }

            List<SelectListItem> eyesStyleList = new List<SelectListItem>();
            actionResult = settingAction.MasterEyes_Load();
            if (actionResult.IsSuccess)
            {
                eyesStyleList = (from DataRow row in actionResult.dtResult.Rows
                                 select new SelectListItem
                                 {
                                     Text = row["Eyes"] != DBNull.Value ? row["Eyes"].ToString() : "",
                                     Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                 }).ToList();
            }

            List<SelectListItem> buildList = new List<SelectListItem>();
            actionResult = settingAction.Build_Load();
            if (actionResult.IsSuccess)
            {
                buildList = (from DataRow row in actionResult.dtResult.Rows
                             select new SelectListItem
                             {
                                 Text = row["Build"] != DBNull.Value ? row["Build"].ToString() : "",
                                 Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                             }).ToList();
            }


            List<SelectListItem> complexionList = new List<SelectListItem>();
            actionResult = settingAction.Complexion_Load();
            if (actionResult.IsSuccess)
            {
                complexionList = (from DataRow row in actionResult.dtResult.Rows
                                  select new SelectListItem
                                  {
                                      Text = row["Complexion"] != DBNull.Value ? row["Complexion"].ToString() : "",
                                      Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                  }).ToList();
            }

            CIMS.BaseLayer.Setting.SetMetricsBase setMetricsBase = new CIMS.BaseLayer.Setting.SetMetricsBase();
            setMetricsBase.Type = "Height";
            actionResult = settingAction.setmetrics_LoadBy(setMetricsBase);
            if (actionResult.IsSuccess)
            {
                for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                {
                    if (actionResult.dtResult.Rows[i]["ActiveMetrics"].ToString() == "True")
                    {
                        ViewBag.ActiveMetricsHeight = actionResult.dtResult.Rows[i]["metrics"].ToString();
                    }
                }
                if (ViewBag.ActiveMetricsHeight == null)
                {
                    ViewBag.ActiveMetricsHeight = "";
                }
            }
            setMetricsBase.Type = "Weight";
            actionResult = settingAction.setmetrics_LoadBy(setMetricsBase);
            if (actionResult.IsSuccess)
            {
                for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                {
                    if (actionResult.dtResult.Rows[i]["ActiveMetrics"].ToString() == "True")
                    {
                        ViewBag.ActiveMetricsWeight = actionResult.dtResult.Rows[i]["metrics"].ToString();
                    }
                }
                if (ViewBag.ActiveMetricsWeight == null)
                {
                    ViewBag.ActiveMetricsWeight = "";
                }
            }

            CIMS.BaseLayer.Setting.WeightUnitBase setWeightUnitBase = new CIMS.BaseLayer.Setting.WeightUnitBase();
            setWeightUnitBase.IsDefault = true;
            actionResult = settingAction.setWeightUnit_LoadBy(setWeightUnitBase);
            if (actionResult.IsSuccess)
            {
                for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                {
                    if (actionResult.dtResult.Rows[i]["IsDefault"].ToString() == "True")
                    {
                        ViewBag.ActiveDefaultWeight = actionResult.dtResult.Rows[i]["WeightUnitName"].ToString();
                    }
                }
                if (ViewBag.ActiveDefaultWeight == null)
                {
                    ViewBag.ActiveDefaultWeight = "";
                }
            }

            CIMS.BaseLayer.Setting.HeightUnitBase setHeightUnitBase = new CIMS.BaseLayer.Setting.HeightUnitBase();
            setHeightUnitBase.IsDefault = true;
            actionResult = settingAction.setHeightUnit_LoadBy(setHeightUnitBase);
            if (actionResult.IsSuccess)
            {
                for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                {
                    if (actionResult.dtResult.Rows[i]["IsDefault"].ToString() == "True")
                    {
                        ViewBag.ActiveDefaultHeight = actionResult.dtResult.Rows[i]["HeightUnitName"].ToString();
                    }
                }
                if (ViewBag.ActiveDefaultHeight == null)
                {
                    ViewBag.ActiveDefaultHeight = "";
                }
            }

            List<SelectListItem> glassesList = new List<SelectListItem>();
            glassesList.Add(new SelectListItem
            {
                Value = "No",
                Text = "No"
            });
            glassesList.Add(new SelectListItem
            {
                Value = "Yes",
                Text = "Yes"
            });
            ViewBag.GlassesList = glassesList;

            List<SelectListItem> empPositionList = new List<SelectListItem>();
            actionResult = settingAction.EmployeePosition_Load();
            if (actionResult.IsSuccess)
            {
                empPositionList = (from DataRow row in actionResult.dtResult.Rows
                                   select new SelectListItem
                                   {
                                       Text = row["Position"] != DBNull.Value ? row["Position"].ToString() : "",
                                       Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                   }).ToList();
            }
            ViewBag.EmployeePosition = empPositionList;

            ViewBag.BuildList = buildList;
            ViewBag.GenderList = genderList;
            ViewBag.RaceList = raceList;
            ViewBag.EyesStyleList = eyesStyleList;
            ViewBag.AverageList = complexionList;
            ViewBag.ComplexionList = complexionList;

            employee.EmpID = Id.Value;
            employee.UserID = Convert.ToInt32(Session["UserID"]);
            employee.RoleID = Convert.ToInt32(Session["RoleId"]);
            actionResult = employeeAction.Employees_Load(employee);

            if (Id > 0)
            {

                if (actionResult.IsSuccess)
                {
                    DataRow dr = actionResult.dtResult.Rows[0];
                    model.EmployeeID = dr["EmployeeID"] != DBNull.Value ? Convert.ToInt32(dr["EmployeeID"]) : 0;
                    model.EmpNumber = dr["EmpNumber"] != DBNull.Value ? dr["EmpNumber"].ToString() : "";
                    model.Age = dr["Age"] != DBNull.Value ? Convert.ToDecimal(dr["Age"]) : 0;
                    model.FirstName = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : "";
                    model.LastName = dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : "";
                    model.MiddleName = dr["MiddleName"] != DBNull.Value ? dr["MiddleName"].ToString() : "";
                    model.Sex = dr["Sex"] != DBNull.Value ? dr["Sex"].ToString() : "";
                    model.Race = dr["Race"] != DBNull.Value ? dr["Race"].ToString() : "";
                    model.Eyes = dr["Eyes"] != DBNull.Value ? dr["Eyes"].ToString() : "";
                    model.Build = dr["Build"] != DBNull.Value ? dr["Build"].ToString() : "";
                    model.Complexion = dr["Complexion"] != DBNull.Value ? dr["Complexion"].ToString() : "";
                    model.Height = dr["Height"] != DBNull.Value ? dr["Height"].ToString() : "";
                    model.Weight = dr["Weight"] != DBNull.Value ? dr["Weight"].ToString() : "";
                    model.StaffPosition = dr["StaffPosition"] != DBNull.Value ? dr["StaffPosition"].ToString() : "";
                    model.Glasses = dr["Glasses"] != DBNull.Value ? dr["Glasses"].ToString() : "";
                    model.ConvertSubject = dr["ConvertSubject"] != DBNull.Value ? Convert.ToBoolean(dr["ConvertSubject"]) : false;
                    if (dr["DateOfBirth"] != DBNull.Value)
                    {
                        model.DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"]);
                    }
                    model.EditPermission = dr["editpermission"] != DBNull.Value ? Convert.ToBoolean(dr["editpermission"]) : false;
                    model.DeletePermission = dr["deletepermission"] != DBNull.Value ? Convert.ToBoolean(dr["deletepermission"]) : false;
                    model.CreatedDate = dr["CreatedDate"] != DBNull.Value ? dr["CreatedDate"].ToString() : "";
                    model.CreatedByUser = dr["CreatorUser"] != DBNull.Value ? dr["CreatorUser"].ToString() : "";
                    model.UserID = dr["UserID"] != DBNull.Value ? Convert.ToInt32(dr["UserID"]) : 0;
                    model.CreatorFirstName = dr["CreatorFirstName"] != DBNull.Value ? dr["CreatorFirstName"].ToString() : "";
                    model.CreatorLastName = dr["CreatorLastName"] != DBNull.Value ? dr["CreatorLastName"].ToString() : "";
                }
                employee.EmployeeID = model.EmployeeID;
                actionResult = employeeAction.EmployeePersonal_LoadByEmployeeID(employee);
                if (actionResult.IsSuccess)
                {
                    DataRow dr = actionResult.dtResult.Rows[0];
                    model.UD10 = dr["UD10"] != DBNull.Value ? dr["UD10"].ToString() : "";
                    model.UD11 = dr["UD11"] != DBNull.Value ? dr["UD11"].ToString() : "";
                    model.UD12 = dr["UD12"] != DBNull.Value ? dr["UD12"].ToString() : "";
                    model.UD13 = dr["UD13"] != DBNull.Value ? dr["UD13"].ToString() : "";
                    model.UD14 = dr["UD14"] != DBNull.Value ? dr["UD14"].ToString() : "";
                    model.UD15 = dr["UD15"] != DBNull.Value ? dr["UD15"].ToString() : "";
                    model.IDDefault1 = dr["IDDefault1"] != DBNull.Value ? Convert.ToBoolean(dr["IDDefault1"]) : false;
                    model.IDType1 = dr["IDType1"] != DBNull.Value ? dr["IDType1"].ToString() : "";
                    model.IDType2 = dr["IDType2"] != DBNull.Value ? dr["IDType2"].ToString() : "";
                    model.IDType3 = dr["IDType3"] != DBNull.Value ? dr["IDType3"].ToString() : "";
                    model.IDNumber1 = dr["IDNumber1"] != DBNull.Value ? dr["IDNumber1"].ToString() : "";
                    model.IDNumber2 = dr["IDNumber2"] != DBNull.Value ? dr["IDNumber2"].ToString() : "";
                    model.IDNumber3 = dr["IDNumber3"] != DBNull.Value ? dr["IDNumber3"].ToString() : "";
                    
                    if (dr["DateOfBirth"] != DBNull.Value)
                    {
                        model.DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"]);
                        model.Day = Convert.ToDateTime(dr["DateOfBirth"]).Day.ToString();
                        model.Month = Convert.ToDateTime(dr["DateOfBirth"]).Month.ToString();
                        model.Year = Convert.ToDateTime(dr["DateOfBirth"]).Year.ToString();
                    }

                }
                employee.IncidentID = -1;
                actionResult = employeeAction.EmployeeLinked_LoadByEmployeeID(employee);
                List<EmployeeLinkedList> EmployeeLinkedList = new List<EmployeeLinkedList>();

                if (actionResult.IsSuccess)
                {
                    EmployeeLinkedList = (from DataRow row in actionResult.dtResult.Rows
                                          select new EmployeeLinkedList
                                          {
                                              Id = row["ID"] != DBNull.Value ? Convert.ToInt32(row["ID"]) : 0,
                                              FilePath = row["FilePath"] != DBNull.Value ? row["FilePath"].ToString() : "",
                                              Description = row["Description"] != DBNull.Value ? row["Description"].ToString() : "",

                                          }).ToList();

                }
                model.EmployeeLinkedList = EmployeeLinkedList;

            }
            else
            {
                //actionResult = employeeAction.EmployeeIDMax_Load();
                //if (actionResult.IsSuccess)
                //{
                //    model.EmpNumber = actionResult.dtResult.Rows[0][0] != DBNull.Value ? actionResult.dtResult.Rows[0][0].ToString() : " ";
                //}

                Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                model.EmpNumber = unixTimestamp.ToString();
            }

            List<SelectListItem> DepartmentTypeList = new List<SelectListItem>();
            actionResult = employeeAction.MasterDepartmentType_Load();
            if (actionResult.IsSuccess)
            {
                DepartmentTypeList = (from DataRow row in actionResult.dtResult.Rows
                                      select new SelectListItem
                                      {
                                          Text = row["DepartmentType"] != DBNull.Value ? row["DepartmentType"].ToString() : "",
                                          Value = row["id"] != DBNull.Value ? row["id"].ToString() : ""
                                      }).ToList();
            }
            model.DepartmentTypeList = DepartmentTypeList;

            List<SelectListItem> LicenseTypeList = new List<SelectListItem>();
            actionResult = employeeAction.MasterLicenseType_Load();
            if (actionResult.IsSuccess)
            {
                LicenseTypeList = (from DataRow row in actionResult.dtResult.Rows
                                   select new SelectListItem
                                   {
                                       Text = row["LicenseType"] != DBNull.Value ? row["LicenseType"].ToString() : "",
                                       Value = row["id"] != DBNull.Value ? row["id"].ToString() : ""
                                   }).ToList();
            }
            model.LicenseTypeList = LicenseTypeList;

            List<SelectListItem> LicenseStatusList = new List<SelectListItem>();
            actionResult = employeeAction.MasterLicenseStatus_Load();
            if (actionResult.IsSuccess)
            {
                LicenseStatusList = (from DataRow row in actionResult.dtResult.Rows
                                     select new SelectListItem
                                     {
                                         Text = row["LicenseStatus"] != DBNull.Value ? row["LicenseStatus"].ToString() : "",
                                         Value = row["id"] != DBNull.Value ? row["id"].ToString() : ""
                                     }).ToList();
            }
            model.LicenseStatusList = LicenseStatusList;

            List<SelectListItem> AddressTypeList = new List<SelectListItem>();
            actionResult = employeeAction.MasterAddressType_Load();
            if (actionResult.IsSuccess)
            {
                AddressTypeList = (from DataRow row in actionResult.dtResult.Rows
                                   select new SelectListItem
                                   {
                                       Text = row["AddressType"] != DBNull.Value ? row["AddressType"].ToString() : "",
                                       Value = row["id"] != DBNull.Value ? row["id"].ToString() : ""
                                   }).ToList();
            }
            model.AddressTypeList = AddressTypeList;

            return View(model);
        }

        public ActionResult AddEmployeeFromSearch(EmployeeModel model)
        {
            List<SelectListItem> genderList = new List<SelectListItem>();
            model.EmployeeLinkedList = new List<EmployeeLinkedList>();
            model.EditPermission = true; ///For new employee do not disable controls
            model.DeletePermission = true; ///For new employee do not disable controls

            CIMS.ActionLayer.Setting.SettingAction settingAction = new CIMS.ActionLayer.Setting.SettingAction();

            actionResult = settingAction.MasterSex_Load();
            if (actionResult.IsSuccess)
            {
                genderList = (from DataRow row in actionResult.dtResult.Rows
                              select new SelectListItem
                              {
                                  Text = row["Sex"] != DBNull.Value ? row["Sex"].ToString() : "",
                                  Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                              }).ToList();
            }

            List<SelectListItem> raceList = new List<SelectListItem>();
            actionResult = settingAction.MasterRace_Load();
            if (actionResult.IsSuccess)
            {
                raceList = (from DataRow row in actionResult.dtResult.Rows
                            select new SelectListItem
                            {
                                Text = row["Race"] != DBNull.Value ? row["Race"].ToString() : "",
                                Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                            }).ToList();
            }

            List<SelectListItem> eyesStyleList = new List<SelectListItem>();
            actionResult = settingAction.MasterEyes_Load();
            if (actionResult.IsSuccess)
            {
                eyesStyleList = (from DataRow row in actionResult.dtResult.Rows
                                 select new SelectListItem
                                 {
                                     Text = row["Eyes"] != DBNull.Value ? row["Eyes"].ToString() : "",
                                     Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                 }).ToList();
            }

            List<SelectListItem> buildList = new List<SelectListItem>();
            actionResult = settingAction.Build_Load();
            if (actionResult.IsSuccess)
            {
                buildList = (from DataRow row in actionResult.dtResult.Rows
                             select new SelectListItem
                             {
                                 Text = row["Build"] != DBNull.Value ? row["Build"].ToString() : "",
                                 Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                             }).ToList();
            }


            List<SelectListItem> complexionList = new List<SelectListItem>();
            actionResult = settingAction.Complexion_Load();
            if (actionResult.IsSuccess)
            {
                complexionList = (from DataRow row in actionResult.dtResult.Rows
                                  select new SelectListItem
                                  {
                                      Text = row["Complexion"] != DBNull.Value ? row["Complexion"].ToString() : "",
                                      Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                  }).ToList();
            }

            CIMS.BaseLayer.Setting.SetMetricsBase setMetricsBase = new CIMS.BaseLayer.Setting.SetMetricsBase();
            setMetricsBase.Type = "Height";
            actionResult = settingAction.setmetrics_LoadBy(setMetricsBase);
            if (actionResult.IsSuccess)
            {
                for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                {
                    if (actionResult.dtResult.Rows[i]["ActiveMetrics"].ToString() == "True")
                    {
                        ViewBag.ActiveMetricsHeight = actionResult.dtResult.Rows[i]["metrics"].ToString();
                    }
                }
                if (ViewBag.ActiveMetricsHeight == null)
                {
                    ViewBag.ActiveMetricsHeight = "";
                }
            }
            setMetricsBase.Type = "Weight";
            actionResult = settingAction.setmetrics_LoadBy(setMetricsBase);
            if (actionResult.IsSuccess)
            {
                for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                {
                    if (actionResult.dtResult.Rows[i]["ActiveMetrics"].ToString() == "True")
                    {
                        ViewBag.ActiveMetricsWeight = actionResult.dtResult.Rows[i]["metrics"].ToString();
                    }
                }
                if (ViewBag.ActiveMetricsWeight == null)
                {
                    ViewBag.ActiveMetricsWeight = "";
                }
            }

            CIMS.BaseLayer.Setting.WeightUnitBase setWeightUnitBase = new CIMS.BaseLayer.Setting.WeightUnitBase();
            setWeightUnitBase.IsDefault = true;
            actionResult = settingAction.setWeightUnit_LoadBy(setWeightUnitBase);
            if (actionResult.IsSuccess)
            {
                for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                {
                    if (actionResult.dtResult.Rows[i]["IsDefault"].ToString() == "True")
                    {
                        ViewBag.ActiveDefaultWeight = actionResult.dtResult.Rows[i]["WeightUnitName"].ToString();
                    }
                }
                if (ViewBag.ActiveDefaultWeight == null)
                {
                    ViewBag.ActiveDefaultWeight = "";
                }
            }

            CIMS.BaseLayer.Setting.HeightUnitBase setHeightUnitBase = new CIMS.BaseLayer.Setting.HeightUnitBase();
            setHeightUnitBase.IsDefault = true;
            actionResult = settingAction.setHeightUnit_LoadBy(setHeightUnitBase);
            if (actionResult.IsSuccess)
            {
                for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                {
                    if (actionResult.dtResult.Rows[i]["IsDefault"].ToString() == "True")
                    {
                        ViewBag.ActiveDefaultHeight = actionResult.dtResult.Rows[i]["HeightUnitName"].ToString();
                    }
                }
                if (ViewBag.ActiveDefaultHeight == null)
                {
                    ViewBag.ActiveDefaultHeight = "";
                }
            }


            List<SelectListItem> glassesList = new List<SelectListItem>();
            glassesList.Add(new SelectListItem
            {
                Value = "No",
                Text = "No"
            });
            glassesList.Add(new SelectListItem
            {
                Value = "Yes",
                Text = "Yes"
            });
            ViewBag.GlassesList = glassesList;

            List<SelectListItem> empPositionList = new List<SelectListItem>();
            actionResult = settingAction.EmployeePosition_Load();
            if (actionResult.IsSuccess)
            {
                empPositionList = (from DataRow row in actionResult.dtResult.Rows
                                   select new SelectListItem
                                   {
                                       Text = row["Position"] != DBNull.Value ? row["Position"].ToString() : "",
                                       Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                   }).ToList();
            }
            ViewBag.EmployeePosition = empPositionList;

            ViewBag.BuildList = buildList;
            ViewBag.GenderList = genderList;
            ViewBag.RaceList = raceList;
            ViewBag.EyesStyleList = eyesStyleList;
            ViewBag.AverageList = complexionList;
            ViewBag.ComplexionList = complexionList;

            actionResult = employeeAction.Employees_Load(employee);



            List<SelectListItem> DepartmentTypeList = new List<SelectListItem>();
            actionResult = employeeAction.MasterDepartmentType_Load();
            if (actionResult.IsSuccess)
            {
                DepartmentTypeList = (from DataRow row in actionResult.dtResult.Rows
                                      select new SelectListItem
                                      {
                                          Text = row["DepartmentType"] != DBNull.Value ? row["DepartmentType"].ToString() : "",
                                          Value = row["id"] != DBNull.Value ? row["id"].ToString() : ""
                                      }).ToList();
            }
            model.DepartmentTypeList = DepartmentTypeList;

            List<SelectListItem> LicenseTypeList = new List<SelectListItem>();
            actionResult = employeeAction.MasterLicenseType_Load();
            if (actionResult.IsSuccess)
            {
                LicenseTypeList = (from DataRow row in actionResult.dtResult.Rows
                                   select new SelectListItem
                                   {
                                       Text = row["LicenseType"] != DBNull.Value ? row["LicenseType"].ToString() : "",
                                       Value = row["id"] != DBNull.Value ? row["id"].ToString() : ""
                                   }).ToList();
            }
            model.LicenseTypeList = LicenseTypeList;

            List<SelectListItem> LicenseStatusList = new List<SelectListItem>();
            actionResult = employeeAction.MasterLicenseStatus_Load();
            if (actionResult.IsSuccess)
            {
                LicenseStatusList = (from DataRow row in actionResult.dtResult.Rows
                                     select new SelectListItem
                                     {
                                         Text = row["LicenseStatus"] != DBNull.Value ? row["LicenseStatus"].ToString() : "",
                                         Value = row["id"] != DBNull.Value ? row["id"].ToString() : ""
                                     }).ToList();
            }
            model.LicenseStatusList = LicenseStatusList;

            List<SelectListItem> AddressTypeList = new List<SelectListItem>();
            actionResult = employeeAction.MasterAddressType_Load();
            if (actionResult.IsSuccess)
            {
                AddressTypeList = (from DataRow row in actionResult.dtResult.Rows
                                   select new SelectListItem
                                   {
                                       Text = row["AddressType"] != DBNull.Value ? row["AddressType"].ToString() : "",
                                       Value = row["id"] != DBNull.Value ? row["id"].ToString() : ""
                                   }).ToList();
            }
            model.AddressTypeList = AddressTypeList;
            //if (string.IsNullOrEmpty(model.EmpNumber))
            //{
            //    Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            //    model.EmpNumber = unixTimestamp.ToString();
            //}

            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            model.EmpNumber = unixTimestamp.ToString();

            return View("Employees", model);
        }

        [HttpPost]
        public ActionResult Employees(EmployeeModel model, FormCollection fc)
        {
            //EmpNumber, Age, Sex, Race, LastName, FirstName, MiddleName, Height, Weight, StaffPosition, Eyes, Complexion, Build, Glasses, Restricted, RoleName, UD9
            EmployeeBase employee = new EmployeeBase();
            employee.UserID = Convert.ToInt32(Session["UserId"]);
            employee.EmpNumber = model.EmpNumber;
            employee.EmpID = model.EmployeeID;
            employee.Age = Convert.ToDecimal(model.Age);
            employee.DateOfBirth = model.DateOfBirth;
            employee.Eyes = model.Eyes;
            employee.Sex = model.Sex;
            employee.Race = model.Race;

            if (model.FirstName != null)
            {
                employee.FirstName = model.FirstName;
            }
            else
            {
                employee.FirstName = "Unknown";
            }

            if (model.LastName != null)
            {
                employee.LastName = model.LastName;
            }
            else
            {
                employee.LastName = "Unknown";
            }

            employee.MiddleName = model.MiddleName;
            employee.Height = model.Height;
            employee.Weight = model.Weight;
            employee.Complexion = model.Complexion;
            employee.StaffPosition = model.StaffPosition;
            employee.Glasses = model.Glasses;
            employee.Build = model.Build;

            if (model.EmployeeID > 0)
            {
                actionResult = employeeAction.Employees_Update(employee);
                if (actionResult.IsSuccess)
                {
                    TempData["SuccessMessage"] = "Employee Details Updated Successfully.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Some error Occurred, please try again later.";
                }
            }
            else
            {
                actionResult = employeeAction.Employees_Insert(employee);
                if (actionResult.IsSuccess)
                {
                    int result = actionResult.dtResult.Rows[0][0] != DBNull.Value ? Convert.ToInt32(actionResult.dtResult.Rows[0][0]) : 0;
                    model.EmployeeID = result;
                    AddALLUsersRolesEmployeeAccess(model.EmployeeID);
                    TempData["SaveSuccess"] = "Success";
                    TempData["SuccessMessage"] = "Employee Details Added Successfully.";
                }
                else
                {
                    TempData["SaveSuccess"] = "";
                    TempData["ErrorMessage"] = "Some error Occurred, please try again later.";
                }
            }
            return RedirectToAction("Employees", new { Type = "Employee", id = model.EmployeeID });
        }


        [HttpPost]
        public ActionResult EmployeesPersonal(EmployeeModel model, FormCollection fc)
        {
            //EmpNumber, Age, Sex, Race, LastName, FirstName, MiddleName, Height, Weight, StaffPosition, Eyes, Complexion, Build, Glasses, Restricted, RoleName, UD9
            EmployeeBase employee = new EmployeeBase();
            employee.EmployeeID = model.EmployeeID;
            employee.UD10 = model.UD10;
            employee.UD11 = model.UD11;
            employee.UD12 = model.UD12;
            employee.UD13 = model.UD13;
            employee.UD14 = model.UD14;
            employee.UD15 = model.UD15;
            employee.IDType1 = model.IDType1;
            employee.IDType2 = model.IDType2;
            employee.IDType3 = model.IDType3;
            employee.IDNumber1 = model.IDNumber1;
            employee.IDNumber2 = model.IDNumber2;
            employee.IDNumber3 = model.IDNumber3;
            employee.IDDefault1 = model.IDDefault1;

            if (model.Month == null)
            {
                model.Month = "1";
            }
            if (model.Day == null)
            {
                model.Day = "1";
            }
            if (model.Year == null)
            {
                model.Year = "1998";
            }

            employee.DateOfBirth = Convert.ToDateTime(model.Month + "/" + model.Day + "/" + model.Year);
            actionResult = employeeAction.EmployeePersonal_InsertUpdate(employee);


            if (actionResult.IsSuccess)
            {
                ViewBag.message = "";
            }
            else
            {
                ViewBag.errorMessage = "";
            }

            return RedirectToAction("Employees", new { Type = "Employee", Id = model.EmployeeID });
        }


        [HttpPost]
        public ActionResult EmployeesLInkedFiles(EmployeeModel model, FormCollection fc)
        {
            string FilePath = "~/Content/Employee/LinkedFiles/";
            if (!Directory.Exists(Server.MapPath(FilePath)))
            {
                Directory.CreateDirectory(Server.MapPath(FilePath));
            }
            string uploadedfilename = "";
            HttpPostedFileBase pfb = Request.Files["fileUpload"];
            if (pfb != null && pfb.ContentLength > 0)
            {
                var fileName = Path.GetFileName(pfb.FileName);
                uploadedfilename = Guid.NewGuid().ToString().Substring(0, 5) + "_" + fileName;
                string filePath = System.IO.Path.Combine(HttpContext.Server.MapPath(FilePath),
                                   uploadedfilename);

                pfb.SaveAs(filePath);
                //EmpNumber, Age, Sex, Race, LastName, FirstName, MiddleName, Height, Weight, StaffPosition, Eyes, Complexion, Build, Glasses, Restricted, RoleName, UD9

            }

            string site = System.Configuration.ConfigurationManager.AppSettings["site"];
            EmployeeBase employee = new EmployeeBase();
            employee.EmployeeID = model.EmployeeID;
            employee.ID = Convert.ToInt32(fc["LinkedId"]);

            if(!string.IsNullOrEmpty(uploadedfilename))
                employee.FilePath = site + "/Content/Employee/LinkedFiles/" + uploadedfilename;

            employee.Description = fc["Description"];
            employee.IncidentID = -1;
            actionResult = employeeAction.EmployeeLinked_InsertUpdate(employee);
            if (actionResult.IsSuccess)
            {
                ViewBag.message = "";
            }
            else
            {
                ViewBag.errorMessage = "";
            }

            return RedirectToAction("Employees", new { Type = "Employee", Id = model.EmployeeID });
        }
        public ActionResult EmployeeList()
        {

            EmployeeModel employeeModel = new EmployeeModel();

            EmployeeBase employeeBase = new EmployeeBase();
            employeeBase.UserID = Convert.ToInt32(Session["UserID"]);
            employeeBase.RoleID = Convert.ToInt32(Session["RoleId"]);

            //employee.UserID = Convert.ToInt32(Session["UserId"]);
            List<EmployeeModel> employeeList = new List<EmployeeModel>();
            if (TempData["EmployeeList"] != null)
            {
                actionResult = (CIMS.BaseLayer.ActionResult)TempData["EmployeeList"];
            }
            else
            {
                actionResult = employeeAction.Employee_LoadByUserID(employeeBase);
            }
            if (actionResult != null && actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
            {
                employeeList = (from DataRow row in actionResult.dtResult.Rows
                                select new EmployeeModel
                                {
                                    FilePath = row["FilePath"] != DBNull.Value ? Convert.ToString(row["FilePath"]) : null,
                                    EmployeeID = row["EmployeeID"] != DBNull.Value ? Convert.ToInt32(row["EmployeeID"]) : 0,
                                    FirstName = row["FirstName"] != DBNull.Value ? row["FirstName"].ToString() : "",
                                    LastName = row["LastName"] != DBNull.Value ? row["LastName"].ToString() : "",
                                    EmpNumber = row["EmpNumber"] != DBNull.Value ? row["EmpNumber"].ToString() : "",
                                    //Age = row["Age"] != DBNull.Value ? Convert.ToDecimal(row["Age"]) : 0,
                                    CreatedDate = row["CreatedDate"] != DBNull.Value ? Convert.ToString(row["CreatedDate"]) : "",
                                }).ToList();

                employeeModel.EmployeeList = employeeList;
            }
            //Ab
            //EmployeeModel model = new EmployeeModel();
            List<SelectListItem> genderList = new List<SelectListItem>();
            employeeModel.EmployeeLinkedList = new List<EmployeeLinkedList>();

            CIMS.ActionLayer.Setting.SettingAction settingAction = new CIMS.ActionLayer.Setting.SettingAction();

            actionResult = settingAction.MasterSex_Load();
            if (actionResult.IsSuccess)
            {
                genderList = (from DataRow row in actionResult.dtResult.Rows
                              select new SelectListItem
                              {
                                  Text = row["Sex"] != DBNull.Value ? row["Sex"].ToString() : "",
                                  Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                              }).ToList();
            }

            List<SelectListItem> raceList = new List<SelectListItem>();
            actionResult = settingAction.MasterRace_Load();
            if (actionResult.IsSuccess)
            {
                raceList = (from DataRow row in actionResult.dtResult.Rows
                            select new SelectListItem
                            {
                                Text = row["Race"] != DBNull.Value ? row["Race"].ToString() : "",
                                Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                            }).ToList();
            }

            List<SelectListItem> eyesStyleList = new List<SelectListItem>();
            actionResult = settingAction.MasterEyes_Load();
            if (actionResult.IsSuccess)
            {
                eyesStyleList = (from DataRow row in actionResult.dtResult.Rows
                                 select new SelectListItem
                                 {
                                     Text = row["Eyes"] != DBNull.Value ? row["Eyes"].ToString() : "",
                                     Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                 }).ToList();
            }

            List<SelectListItem> buildList = new List<SelectListItem>();
            actionResult = settingAction.Build_Load();
            if (actionResult.IsSuccess)
            {
                buildList = (from DataRow row in actionResult.dtResult.Rows
                             select new SelectListItem
                             {
                                 Text = row["Build"] != DBNull.Value ? row["Build"].ToString() : "",
                                 Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                             }).ToList();
            }


            List<SelectListItem> complexionList = new List<SelectListItem>();
            actionResult = settingAction.Complexion_Load();
            if (actionResult.IsSuccess)
            {
                complexionList = (from DataRow row in actionResult.dtResult.Rows
                                  select new SelectListItem
                                  {
                                      Text = row["Complexion"] != DBNull.Value ? row["Complexion"].ToString() : "",
                                      Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                  }).ToList();
            }

            CIMS.BaseLayer.Setting.SetMetricsBase setMetricsBase = new CIMS.BaseLayer.Setting.SetMetricsBase();
            setMetricsBase.Type = "Height";
            actionResult = settingAction.setmetrics_LoadBy(setMetricsBase);
            if (actionResult.IsSuccess)
            {
                for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                {
                    if (actionResult.dtResult.Rows[i]["ActiveMetrics"].ToString() == "True")
                    {
                        ViewBag.ActiveMetricsHeight = actionResult.dtResult.Rows[i]["metrics"].ToString();
                    }
                }
                if (ViewBag.ActiveMetricsHeight == null)
                {
                    ViewBag.ActiveMetricsHeight = "";
                }
            }
            setMetricsBase.Type = "Weight";
            actionResult = settingAction.setmetrics_LoadBy(setMetricsBase);
            if (actionResult.IsSuccess)
            {
                for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                {
                    if (actionResult.dtResult.Rows[i]["ActiveMetrics"].ToString() == "True")
                    {
                        ViewBag.ActiveMetricsWeight = actionResult.dtResult.Rows[i]["metrics"].ToString();
                    }
                }
                if (ViewBag.ActiveMetricsWeight == null)
                {
                    ViewBag.ActiveMetricsWeight = "";
                }
            }

            CIMS.BaseLayer.Setting.WeightUnitBase setWeightUnitBase = new CIMS.BaseLayer.Setting.WeightUnitBase();
            setWeightUnitBase.IsDefault = true;
            actionResult = settingAction.setWeightUnit_LoadBy(setWeightUnitBase);
            if (actionResult.IsSuccess)
            {
                for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                {
                    if (actionResult.dtResult.Rows[i]["IsDefault"].ToString() == "True")
                    {
                        ViewBag.ActiveDefaultWeight = actionResult.dtResult.Rows[i]["WeightUnitName"].ToString();
                    }
                }
                if (ViewBag.ActiveDefaultWeight == null)
                {
                    ViewBag.ActiveDefaultWeight = "";
                }
            }

            CIMS.BaseLayer.Setting.HeightUnitBase setHeightUnitBase = new CIMS.BaseLayer.Setting.HeightUnitBase();
            setHeightUnitBase.IsDefault = true;
            actionResult = settingAction.setHeightUnit_LoadBy(setHeightUnitBase);
            if (actionResult.IsSuccess)
            {
                for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                {
                    if (actionResult.dtResult.Rows[i]["IsDefault"].ToString() == "True")
                    {
                        ViewBag.ActiveDefaultHeight = actionResult.dtResult.Rows[i]["HeightUnitName"].ToString();
                    }
                }
                if (ViewBag.ActiveDefaultHeight == null)
                {
                    ViewBag.ActiveDefaultHeight = "";
                }
            }

            List<SelectListItem> glassesList = new List<SelectListItem>();
            glassesList.Add(new SelectListItem
            {
                Value = "No",
                Text = "No"
            });
            glassesList.Add(new SelectListItem
            {
                Value = "Yes",
                Text = "Yes"
            });
            ViewBag.GlassesList = glassesList;

            List<SelectListItem> empPositionList = new List<SelectListItem>();
            actionResult = settingAction.EmployeePosition_Load();
            if (actionResult.IsSuccess)
            {
                empPositionList = (from DataRow row in actionResult.dtResult.Rows
                                   select new SelectListItem
                                   {
                                       Text = row["Position"] != DBNull.Value ? row["Position"].ToString() : "",
                                       Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                   }).ToList();
            }
            ViewBag.EmployeePosition = empPositionList;

            ViewBag.BuildList = buildList;
            ViewBag.GenderList = genderList;
            ViewBag.RaceList = raceList;
            ViewBag.EyesStyleList = eyesStyleList;
            ViewBag.AverageList = complexionList;
            ViewBag.ComplexionList = complexionList;



            List<SelectListItem> DepartmentTypeList = new List<SelectListItem>();
            actionResult = employeeAction.MasterDepartmentType_Load();
            if (actionResult.IsSuccess)
            {
                DepartmentTypeList = (from DataRow row in actionResult.dtResult.Rows
                                      select new SelectListItem
                                      {
                                          Text = row["DepartmentType"] != DBNull.Value ? row["DepartmentType"].ToString() : "",
                                          Value = row["id"] != DBNull.Value ? row["id"].ToString() : ""
                                      }).ToList();
            }
            employeeModel.DepartmentTypeList = DepartmentTypeList;

            List<SelectListItem> LicenseTypeList = new List<SelectListItem>();
            actionResult = employeeAction.MasterLicenseType_Load();
            if (actionResult.IsSuccess)
            {
                LicenseTypeList = (from DataRow row in actionResult.dtResult.Rows
                                   select new SelectListItem
                                   {
                                       Text = row["LicenseType"] != DBNull.Value ? row["LicenseType"].ToString() : "",
                                       Value = row["id"] != DBNull.Value ? row["id"].ToString() : ""
                                   }).ToList();
            }
            employeeModel.LicenseTypeList = LicenseTypeList;

            List<SelectListItem> LicenseStatusList = new List<SelectListItem>();
            actionResult = employeeAction.MasterLicenseStatus_Load();
            if (actionResult.IsSuccess)
            {
                LicenseStatusList = (from DataRow row in actionResult.dtResult.Rows
                                     select new SelectListItem
                                     {
                                         Text = row["LicenseStatus"] != DBNull.Value ? row["LicenseStatus"].ToString() : "",
                                         Value = row["id"] != DBNull.Value ? row["id"].ToString() : ""
                                     }).ToList();
            }
            employeeModel.LicenseStatusList = LicenseStatusList;

            List<SelectListItem> AddressTypeList = new List<SelectListItem>();
            actionResult = employeeAction.MasterAddressType_Load();
            if (actionResult.IsSuccess)
            {
                AddressTypeList = (from DataRow row in actionResult.dtResult.Rows
                                   select new SelectListItem
                                   {
                                       Text = row["AddressType"] != DBNull.Value ? row["AddressType"].ToString() : "",
                                       Value = row["id"] != DBNull.Value ? row["id"].ToString() : ""
                                   }).ToList();
            }
            employeeModel.AddressTypeList = AddressTypeList;

            //Ab End
            return View(employeeModel);
        }

        #region Delete Subject
        [HttpPost]
        public JsonResult DeleteEmployee(int? Id = 0)
        {
            string json = string.Empty;
            try
            {
                employee.EmployeeID = Convert.ToInt32(Id);
                actionResult = employeeAction.Employee_Delete(employee);
                if (actionResult.IsSuccess)
                {
                    json = "success";
                }
                else
                {
                    json = "fail";
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

        public JsonResult GetAddress(int EmployeeID)
        {

            string jsonString = string.Empty;
            try
            {
                // employee.EmpID = 1;
                employee.EmployeeID = EmployeeID;
                actionResult = employeeAction.EmployeeAddress_LoadByUserID(employee);

                if (actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr id=" + actionResult.dtResult.Rows[i]["AddressId"].ToString() + ">";
                        jsonString += "<td>" + Convert.ToDateTime(actionResult.dtResult.Rows[i]["ModifiedDate"]).ToShortDateString() + "</td><td class='word-wrap'>" + actionResult.dtResult.Rows[i]["address"].ToString() + "</td><td class='word-wrap'>" + actionResult.dtResult.Rows[i]["apartment"].ToString() + "</td><td>" + actionResult.dtResult.Rows[i]["Addressname"].ToString() + "</td><td><a href='javascript:;' onclick='EditAddress(" + actionResult.dtResult.Rows[i]["AddressId"].ToString() + ",&#39;" + actionResult.dtResult.Rows[i]["AddressType"].ToString() + "&#39;,&#39;" + actionResult.dtResult.Rows[i]["Apartment"].ToString() + "&#39;,&#39;" + actionResult.dtResult.Rows[i]["Address"].ToString() + "&#39;,&#39;" + actionResult.dtResult.Rows[i]["CountryID"].ToString() + "&#39;,&#39;" + actionResult.dtResult.Rows[i]["City"].ToString() + "&#39;,&#39;" + actionResult.dtResult.Rows[i]["ProvState"].ToString() + "&#39;,&#39;" + actionResult.dtResult.Rows[i]["PostalZip"].ToString() + "&#39;,&#39;" + actionResult.dtResult.Rows[i]["Phone"].ToString() + "&#39;);'> <i class='fa fa-pencil'></i></a> | <a href ='#' onclick='DeleteAddress(" + actionResult.dtResult.Rows[i]["AddressId"].ToString() + ");'><i class='fa fa-trash'></i></a></td>";
                        jsonString += "</tr>";
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


        public JsonResult AddEditAddress(int EmployeeID, string addressType, string apartment, string address, int country, string city, string state, int addressId, string zipCode, string phone)
        {
            string jsonString = string.Empty;
            try
            {
                EmployeeBase employee = new EmployeeBase();
                employee.EmployeeID = EmployeeID;
                employee.AddressType = addressType;
                employee.Apartment = apartment;
                employee.Address = address;
                employee.CountryID = country;
                employee.City = city;
                employee.ProvState = state;
                employee.AddressID = addressId;
                employee.PostalZip = zipCode;
                employee.Phone = phone;
                employee.ModifiedDate = DateTime.Now;
                actionResult = employeeAction.EmployeeAddress_AddEdit(employee);

                if (actionResult.dtResult.Rows.Count > 0)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "fail";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);

            }

            return Json(jsonString, JsonRequestBehavior.AllowGet);

        }


        public JsonResult DeleteAddress(int addressID)
        {
            string jsonString = string.Empty;
            try
            {
                EmployeeBase employee = new EmployeeBase();

                employee.AddressID = addressID;

                actionResult = employeeAction.EmployeeAddress_Delete(employee);

                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "fail";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);

            }

            return Json(jsonString, JsonRequestBehavior.AllowGet);

        }

        public JsonResult AddEditLicense(int EmployeeID, string dateOfHire, string terminationDate, string licenseExpirationDate, string department, string licenseType, string licenseStatus, string reasonForLeaving, int licenseId)
        {
            string jsonString = string.Empty;
            try
            {
                EmployeeBase employee = new EmployeeBase();
                employee.EmployeeID = EmployeeID;
                employee.DateOfHire = Convert.ToDateTime(dateOfHire);
                employee.TerminationDate = Convert.ToDateTime(terminationDate);
                employee.LicenseExpirationDate = Convert.ToDateTime(licenseExpirationDate);
                employee.Department = department;
                employee.LicenseType = licenseType;
                employee.LicenseStatus = licenseStatus;
                employee.ReasonForLeaving = reasonForLeaving;
                employee.LicenseID = licenseId;
                actionResult = employeeAction.EmployeeLicense_AddEdit(employee);

                if (actionResult.dtResult.Rows.Count > 0)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "fail";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);

            }

            return Json(jsonString, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetLicense(int? EmployeeID = 0)
        {
            string jsonString = string.Empty;
            try
            {
                employee.EmpID = 1;
                employee.EmployeeID = Convert.ToInt32(EmployeeID);
                List<EmployeeModel> EmployeeList = new List<EmployeeModel>();
                EmployeeModel model = new EmployeeModel();
                actionResult = employeeAction.EmployeeLicense_LoadByEmployeeID(employee);
                if (actionResult.IsSuccess)
                {
                    EmployeeList = CommonMethods.ConvertTo<EmployeeModel>(actionResult.dtResult);
                    if (EmployeeList.Count > 0)
                    {
                        model = EmployeeList.FirstOrDefault();
                        model.DateOfHire = !String.IsNullOrEmpty(model.DateOfHire) ? Convert.ToDateTime(model.DateOfHire).ToShortDateString() : "";
                        model.TerminationDate = !String.IsNullOrEmpty(model.TerminationDate) ? Convert.ToDateTime(model.TerminationDate).ToShortDateString() : "";
                        model.LicenseExpirationDate = !String.IsNullOrEmpty(model.LicenseExpirationDate) ? Convert.ToDateTime(model.LicenseExpirationDate).ToShortDateString() : "";
                    }

                    jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
                return Json(jsonString, JsonRequestBehavior.AllowGet);
            }
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }

        #region SaveEmployeePersonal
        public JsonResult AddEditEmployeePersonal(string UD10, string UD11, string UD12, string UD13, string UD14, string UD15, string IDType1, string IDNumber1, bool IDDefault1, string IDType2, string IDNumber2, bool IDDefault2, string IDType3, string IDNumber3, bool IDDefault3, string DateOfBirth)
        {
            string jsonString = string.Empty;
            try
            {
                EmployeeBase employee = new EmployeeBase();
                employee.EmployeeID = 1;
                employee.UD10 = UD10;
                employee.UD11 = UD11;
                employee.UD12 = UD12;
                employee.UD13 = UD13;
                employee.UD14 = UD14;
                employee.UD15 = UD15;
                employee.IDType1 = IDType1;
                employee.IDNumber1 = IDNumber1;
                employee.IDDefault1 = IDDefault1;
                employee.IDType2 = IDType2;
                employee.IDNumber2 = IDNumber2;
                employee.IDDefault2 = IDDefault2;
                employee.IDType3 = IDType3;
                employee.IDNumber1 = IDNumber1;
                employee.IDDefault3 = IDDefault3;
                employee.DateOfBirth = Convert.ToDateTime(DateOfBirth);
                actionResult = employeeAction.EmployeePersonal_InsertUpdate(employee);

                if (actionResult.dtResult.Rows.Count > 0)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "fail";
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

        #region GetEmployeePersonal
        public JsonResult GetEmployeePersonal()
        {
            string jsonString = string.Empty;
            try
            {
                employee.EmpID = 1;
                employee.EmployeeID = 1;
                List<EmployeeModel> EmployeeList = new List<EmployeeModel>();
                EmployeeModel model = new EmployeeModel();
                actionResult = employeeAction.EmployeePersonal_LoadByEmployeeID(employee);
                if (actionResult.IsSuccess)
                {
                    EmployeeList = CommonMethods.ConvertTo<EmployeeModel>(actionResult.dtResult);
                    if (EmployeeList.Count > 0)
                        model = EmployeeList.FirstOrDefault();
                    jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(model);
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

        #region DEleteLInkedItem
        public JsonResult DeleteLinkedItem(int ID)
        {
            string jsonString = string.Empty;
            try
            {
                EmployeeBase employee = new EmployeeBase();

                employee.ID = ID;

                actionResult = employeeAction.EmployeeLinked_DeleteById(employee);

                if (actionResult.IsSuccess)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "fail";
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

        //#region GetEmployeeIncident
        //public ActionResult EmployeeIncident(int EmpId, int? Id = 0)
        //{
        //    bool permission = (Session["Admin"] == null ? CIMS.Models.CheckPermissions.permissionMenu("Employee Incident Details", Convert.ToInt32(Session["UserId"])) : CIMS.Models.CheckAdminPermissions.permissionMenu("Employees"));
        //    if (!permission)
        //    {
        //        return Redirect("~/Home/NoPermission");
        //    }
        //    EmployeeIncidentModel model = new EmployeeIncidentModel();
        //    List<EmployeeModel> employeeList = new List<EmployeeModel>();
        //    model.EmployeeId = EmpId;
        //    model.IncidentID = Convert.ToInt32(Id);
        //    EmployeeIncidentBase employee = new EmployeeIncidentBase();
        //    List<SelectListItem> AuditTypeList = new List<SelectListItem>();

        //    CIMS.ActionLayer.Setting.SettingAction settingAction = new CIMS.ActionLayer.Setting.SettingAction();

        //    EmployeeBase employeeBase = new EmployeeBase();
        //    EmployeeModel employeeModel = new EmployeeModel();
        //    employeeBase.EmpID = EmpId;
        //    actionResult = employeeAction.Employees_Load(employeeBase);
        //    if (actionResult.IsSuccess)
        //    {
        //        DataRow dr = actionResult.dtResult.Rows[0];
        //        employeeModel.FirstName = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : "";
        //        employeeModel.LastName = dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : "";
        //        employeeModel.MiddleName = dr["MiddleName"] != DBNull.Value ? dr["MiddleName"].ToString() : "";
        //    }
        //    model.EmployeeModel = employeeModel;


        //    employee.IncidentID = model.IncidentID;

        //    if (Id > 0)
        //    {
        //        actionResult = employeeAction.EmployeeIncident_LoadByIncidentID(employee);
        //        if (actionResult.IsSuccess)
        //        {
        //            DataRow dr = actionResult.dtResult.Rows[0];
        //            model.IncidentID = dr["IncidentID"] != DBNull.Value ? Convert.ToInt32(dr["IncidentID"]) : 0;
        //            model.IncidentNumber = dr["IncidentNumber"] != DBNull.Value ? dr["IncidentNumber"].ToString() : "";
        //            model.NatureOfIncident = dr["NatureOfEvent"] != DBNull.Value ? dr["NatureOfEvent"].ToString() : "";
        //            model.ShortDescription = dr["ShortDescriptor"] != DBNull.Value ? dr["ShortDescriptor"].ToString() : "";
        //            model.ActiveStatus = dr["ActiveStatus"] != DBNull.Value ? Convert.ToBoolean(dr["ActiveStatus"]) : false;
        //            model.Status = dr["Status"] != DBNull.Value ? dr["Status"].ToString() : "";
        //            if (dr["IncidentDate"] != DBNull.Value)
        //            {
        //                model.IncidentDate = Convert.ToDateTime(dr["IncidentDate"]);
        //            }

        //            model.Description = dr["Description"] != DBNull.Value ? dr["Description"].ToString() : "";
        //            model.Location = dr["Location"] != DBNull.Value ? dr["Location"].ToString() : "";
        //            model.IncidentRole = dr["IncidentRole"] != DBNull.Value ? dr["IncidentRole"].ToString() : "";
        //            model.StartTime = dr["IncidentTime"] != DBNull.Value ? dr["IncidentTime"].ToString() : "";
        //            model.UD27 = dr["UD27"] != DBNull.Value ? dr["UD27"].ToString() : "";
        //            model.UD34 = dr["UD34"] != DBNull.Value ? dr["UD34"].ToString() : "";
        //            model.UD35 = dr["UD35"] != DBNull.Value ? dr["UD35"].ToString() : "";
        //            model.Notes = dr["Notes"] != DBNull.Value ? dr["Notes"].ToString() : "";
        //            model.IPVRDescription = dr["IPVRDescription"] != DBNull.Value ? dr["IPVRDescription"].ToString() : "";
        //            model.CheckPermissionID = dr["CreatedBy"] != DBNull.Value ? Convert.ToInt32(dr["CreatedBy"]) : 0;
        //        }
        //    }
        //    else
        //    {
        //        //actionResult = employeeAction.EmployeeIncidentsMax_Load();
        //        //if (actionResult.IsSuccess)
        //        //{
        //        //    model.IncidentNumber = actionResult.dtResult.Rows[0][0] != DBNull.Value ? actionResult.dtResult.Rows[0][0].ToString() : " ";

        //        //}
        //        Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        //        model.IncidentNumber = unixTimestamp.ToString();
        //    }

        //    employeeBase.EmployeeID = model.EmployeeId;
        //    employeeBase.IncidentID = model.IncidentID;
        //    actionResult = employeeAction.EmployeeLinked_LoadByEmployeeID(employeeBase);
        //    List<EmployeeLinkedList> EmployeeLinkedList = new List<EmployeeLinkedList>();

        //    if (actionResult.IsSuccess)
        //    {
        //        EmployeeLinkedList = (from DataRow row in actionResult.dtResult.Rows
        //                              select new EmployeeLinkedList
        //                              {
        //                                  Id = row["ID"] != DBNull.Value ? Convert.ToInt32(row["ID"]) : 0,
        //                                  FilePath = row["FilePath"] != DBNull.Value ? row["FilePath"].ToString() : "",
        //                                  Description = row["Description"] != DBNull.Value ? row["Description"].ToString() : "",
        //                              }).ToList();
        //    }
        //    model.EmployeeLinkedList = EmployeeLinkedList;
        //    if (model.IncidentID > 0)
        //    {
        //        employee.IncidentID = model.IncidentID;
        //        actionResult = employeeAction.EmployeeVariance_LoadByIncidentID(employee);

        //        if (actionResult.IsSuccess)
        //        {
        //            DataRow dr = actionResult.dtResult.Rows[0];
        //            model.Resolution = dr["Resolution"] != DBNull.Value ? dr["Resolution"].ToString() : "";
        //            model.VarianceType = dr["VarianceType"] != DBNull.Value ? dr["VarianceType"].ToString() : "";
        //            model.VarianceDescription = dr["Description"] != DBNull.Value ? dr["Description"].ToString() : "";
        //            model.AmountType = dr["AmountType"] != DBNull.Value ? Convert.ToInt32(dr["AmountType"]) : 0;
        //            model.Amount = dr["Amount"] != DBNull.Value ? Convert.ToSingle(dr["Amount"]) : 0;
        //        }

        //        actionResult = employeeAction.EmployeeInvolved_LoadByIncidentID(employee);

        //        employeeList = (from DataRow row in actionResult.dtResult.Rows
        //                        select new EmployeeModel
        //                        {
        //                            EmployeeID = row["EmployeeID"] != DBNull.Value ? Convert.ToInt32(row["EmployeeID"]) : 0,
        //                            FirstName = row["FirstName"] != DBNull.Value ? row["FirstName"].ToString() : "",
        //                            LastName = row["LastName"] != DBNull.Value ? row["LastName"].ToString() : "",
        //                            RoleName = row["RoleName"] != DBNull.Value ? row["RoleName"].ToString() : "",
        //                            Sex = row["Sex"] != DBNull.Value ? row["Sex"].ToString() : "",
        //                            Race = row["Race"] != DBNull.Value ? row["Race"].ToString() : "",
        //                        }).ToList();
        //    }
        //    actionResult = employeeAction.GetDisplayNames();


        //    if (actionResult.IsSuccess)
        //    {
        //        DisplayNameList = (from DataRow row in actionResult.dtResult.Rows
        //                           select new SelectListItem
        //                           {
        //                               Text = row["DisplayName"] != DBNull.Value ? row["DisplayName"].ToString() : "",
        //                               Value = row["DisplayName"] != DBNull.Value ? row["DisplayName"].ToString() : ""
        //                           }).ToList();
        //    }

        //    List<SelectListItem> lstNatureOfIncident = new List<SelectListItem>();
        //    CIMS.BaseLayer.Setting.NatureofIncidentBase natureBase = new CIMS.BaseLayer.Setting.NatureofIncidentBase();
        //    natureBase.NatureType = 2;
        //    actionResult = settingAction.MasterNatureofIncident_Load(natureBase);
        //    if (actionResult.IsSuccess)
        //    {
        //        lstNatureOfIncident = (from DataRow row in actionResult.dtResult.Rows
        //                               select new SelectListItem
        //                               {
        //                                   Text = row["Nature"] != DBNull.Value ? row["Nature"].ToString() : "",
        //                                   Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
        //                               }).ToList();
        //    }
        //    ViewBag.lstNatureOfIncident = lstNatureOfIncident;

        //    employee.UserID = Convert.ToInt32(Session["UserId"]);
        //    employee.IncidentID = model.IncidentID;
        //    actionResult = employeeAction.UsersReportsAccess_LoadAll(employee);
        //    List<EmployeeIncidentModel> UsersList = new List<EmployeeIncidentModel>();
        //    if (actionResult.IsSuccess)
        //    {
        //        UsersList = (from DataRow row in actionResult.dtResult.Rows
        //                     select new EmployeeIncidentModel
        //                     {
        //                         EmployeeId = row["EmployeeID"] != DBNull.Value ? Convert.ToInt32(row["EmployeeID"]) : 0,
        //                         FirstName = row["FirstName"] != DBNull.Value ? row["FirstName"].ToString() : "",
        //                         LastName = row["LastName"] != DBNull.Value ? row["LastName"].ToString() : "",
        //                         UserName = row["UserName"] != DBNull.Value ? row["UserName"].ToString() : "",
        //                         UserID = row["UserID"] != DBNull.Value ? Convert.ToInt32(row["UserID"]) : 0,
        //                         RepPerID = row["RepPerID"] != DBNull.Value ? Convert.ToInt32(row["RepPerID"]) : 0,
        //                         IncidentID = row["ReportID"] != DBNull.Value ? Convert.ToInt32(row["ReportID"]) : 0,
        //                         ReportAccessBy = row["ReportAccessBy"] != DBNull.Value ? Convert.ToInt32(row["ReportAccessBy"]) : 0,
        //                         ReportView = row["ReportView"] != DBNull.Value ? Convert.ToBoolean(row["ReportView"]) : false,
        //                         ReportEdit = row["ReportEdit"] != DBNull.Value ? Convert.ToBoolean(row["ReportEdit"]) : false,
        //                         ReportDelete = row["ReportDelete"] != DBNull.Value ? Convert.ToBoolean(row["ReportDelete"]) : false
        //                     }).ToList();
        //    }
        //    model.empIncidentList = UsersList;

        //    CIMS.BaseLayer.Subject.SubjectIncidentsBase subject = new CIMS.BaseLayer.Subject.SubjectIncidentsBase();
        //    CIMS.ActionLayer.Subject.SubjectAction subjectAction = new CIMS.ActionLayer.Subject.SubjectAction();

        //    List<SelectListItem> LocationList = new List<SelectListItem>();
        //    actionResult = settingAction.Location_Load();
        //    if (actionResult.IsSuccess)
        //    {
        //        LocationList = (from DataRow row in actionResult.dtResult.Rows
        //                        select new SelectListItem
        //                        {
        //                            Text = row["Location"] != DBNull.Value ? row["Location"].ToString() : "",
        //                            Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
        //                        }).ToList();
        //    }
        //    model.LocationList = LocationList;

        //    List<SelectListItem> lstRole = new List<SelectListItem>();
        //    actionResult = settingAction.MasterRole_Load();
        //    if (actionResult.IsSuccess)
        //    {
        //        lstRole = (from DataRow row in actionResult.dtResult.Rows
        //                   select new SelectListItem
        //                   {
        //                       Text = row["Role"] != DBNull.Value ? row["Role"].ToString() : "",
        //                       Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
        //                   }).ToList();
        //    }  
        //    ViewBag.lstRole = lstRole;

        //    AuditTypeList = GetAuditTypeList(AuditTypeList);
        //    model.AuditTypeList = AuditTypeList;
        //    model.EmployeeList = employeeList;
        //    model.DisplayNameList = DisplayNameList;
        //    GetGender_RaceList();
        //    GetGameList();

        //    return View(model);
        //}
        //#endregion

        #region GetEmployeeIncident
        public EmployeeIncidentModel CreateViewModel(EmployeeIncidentModel parammodel)
        {
            List<EmployeeModel> employeeList = new List<EmployeeModel>();
            EmployeeIncidentBase employee = new EmployeeIncidentBase();
            List<SelectListItem> AuditTypeList = new List<SelectListItem>();
            List<EmployeeIncidentProofRead> EmployeeIncidentProofReadList = new List<EmployeeIncidentProofRead>();

            CIMS.ActionLayer.Setting.SettingAction settingAction = new CIMS.ActionLayer.Setting.SettingAction();

            EmployeeBase employeeBase = new EmployeeBase();
            EmployeeModel employeeModel = new EmployeeModel();
            employeeBase.EmpID = parammodel.EmployeeId;
            actionResult = employeeAction.Employees_Load(employeeBase);

            if (actionResult.IsSuccess)
            {
                DataRow dr = actionResult.dtResult.Rows[0];
                employeeModel.LogoFirstName = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : "";
                employeeModel.LogoLastName = dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : "";
                employeeModel.LogoMiddleName = dr["MiddleName"] != DBNull.Value ? dr["MiddleName"].ToString() : "";
            }
            parammodel.EmployeeModel = employeeModel;

            List<SelectListItem> lstNatureOfIncident = new List<SelectListItem>();
            CIMS.BaseLayer.Setting.NatureofIncidentBase natureBase = new CIMS.BaseLayer.Setting.NatureofIncidentBase();
            natureBase.NatureType = 2;
            actionResult = settingAction.MasterNatureofIncident_Load(natureBase);
            if (actionResult.IsSuccess)
            {
                lstNatureOfIncident = (from DataRow row in actionResult.dtResult.Rows
                                       select new SelectListItem
                                       {
                                           Text = row["Nature"] != DBNull.Value ? row["Nature"].ToString() : "",
                                           Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                       }).ToList();
            }
            ViewBag.lstNatureOfIncident = lstNatureOfIncident;

            List<SelectListItem> lstShortDescription = new List<SelectListItem>();
            ViewBag.lstShortDescription = lstShortDescription;

            List<SelectListItem> lstVarianceType = new List<SelectListItem>();
            actionResult = settingAction.VarianceType_Load();
            if (actionResult.IsSuccess)
            {
                lstVarianceType = (from DataRow row in actionResult.dtResult.Rows
                                   select new SelectListItem
                                   {
                                       Text = row["VarianceType"] != DBNull.Value ? row["VarianceType"].ToString() : "",
                                       Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                   }).ToList();
            }
            ViewBag.lstVarianceType = lstVarianceType;

            List<SelectListItem> lstVarianceResoluion = new List<SelectListItem>();
            actionResult = settingAction.VarianceResolution_Load();
            if (actionResult.IsSuccess)
            {
                lstVarianceResoluion = (from DataRow row in actionResult.dtResult.Rows
                                        select new SelectListItem
                                        {
                                            Text = row["Resolution"] != DBNull.Value ? row["Resolution"].ToString() : "",
                                            Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                        }).ToList();
            }
            ViewBag.lstVarianceResoluion = lstVarianceResoluion;

            employee.IncidentID = parammodel.IncidentID;
            employee.ReportAccessRole = Convert.ToInt32(Session["RoleId"]);
            employee.UserID = Convert.ToInt32(Session["UserID"]);
            if (parammodel.IncidentID > 0)
            {
                actionResult = employeeAction.EmployeeIncident_LoadByIncidentID(employee);
                if (actionResult.IsSuccess)
                {
                    DataRow dr = actionResult.dtResult.Rows[0];
                    parammodel.IncidentID = dr["IncidentID"] != DBNull.Value ? Convert.ToInt32(dr["IncidentID"]) : 0;
                    parammodel.IncidentNumber = dr["IncidentNumber"] != DBNull.Value ? dr["IncidentNumber"].ToString() : "";
                    parammodel.NatureOfIncident = dr["NatureOfEvent"] != DBNull.Value ? dr["NatureOfEvent"].ToString() : "";
                    parammodel.ShortDescription = dr["ShortDescriptor"] != DBNull.Value ? dr["ShortDescriptor"].ToString() : "";
                    parammodel.ActiveStatus = dr["ActiveStatus"] != DBNull.Value ? Convert.ToBoolean(dr["ActiveStatus"]) : false;
                    parammodel.Status = dr["Status"] != DBNull.Value ? dr["Status"].ToString() : "";
                    if (dr["IncidentDate"] != DBNull.Value)
                    {
                        parammodel.IncidentDate = Convert.ToDateTime(dr["IncidentDate"]);
                    }
                    else
                    {
                        parammodel.IncidentDate = DateTime.Now.Date;
                    }

                    parammodel.Description = dr["Description"] != DBNull.Value ? dr["Description"].ToString() : "";
                    parammodel.Location = dr["Location"] != DBNull.Value ? dr["Location"].ToString() : "";
                    parammodel.IncidentRole = dr["IncidentRole"] != DBNull.Value ? dr["IncidentRole"].ToString() : "";
                    parammodel.StartTime = dr["IncidentTime"] != DBNull.Value ? dr["IncidentTime"].ToString() : DateTime.Now.ToString("hh:mm tt");
                    parammodel.EndTime = dr["EndTime"] != DBNull.Value ? dr["EndTime"].ToString() : DateTime.Now.ToString("hh:mm tt");
                    if (dr["StartDate"] != DBNull.Value)
                    {
                        parammodel.StartDate = Convert.ToDateTime(dr["StartDate"]).ToShortDateString();
                    }
                    else
                    {
                        parammodel.StartDate = DateTime.Now.Date.ToShortDateString();
                    }
                    if (dr["EndDate"] != DBNull.Value)
                    {
                        parammodel.EndDate = Convert.ToDateTime(dr["EndDate"]).ToShortDateString();
                    }
                    else
                    {
                        parammodel.EndDate = DateTime.Now.Date.ToShortDateString();
                    }
                    parammodel.UD27 = dr["UD27"] != DBNull.Value ? dr["UD27"].ToString() : "";
                    parammodel.UD34 = dr["UD34"] != DBNull.Value ? dr["UD34"].ToString() : "";
                    parammodel.UD35 = dr["UD35"] != DBNull.Value ? dr["UD35"].ToString() : "";
                    parammodel.Notes = dr["Notes"] != DBNull.Value ? dr["Notes"].ToString() : "";
                    parammodel.IPVRDescription = dr["IPVRDescription"] != DBNull.Value ? dr["IPVRDescription"].ToString() : "";
                    parammodel.CheckPermissionID = dr["CreatedBy"] != DBNull.Value ? Convert.ToInt32(dr["CreatedBy"]) : 0;
                    parammodel.ReportCreatorUser = dr["ReportCreatorUser"] != DBNull.Value ? dr["ReportCreatorUser"].ToString() : "";
                    parammodel.ReportCreatorFirstName = dr["ReportCreatorFirstName"] != DBNull.Value ? dr["ReportCreatorFirstName"].ToString() : "";
                    parammodel.ReportCreatorLastName = dr["ReportCreatorLastName"] != DBNull.Value ? dr["ReportCreatorLastName"].ToString() : "";
                    parammodel.ReportCreateDate = dr["CreatedDate"] != DBNull.Value ? dr["CreatedDate"].ToString() : "";
                    parammodel.ReportCreatorView = dr["ReportView"] != DBNull.Value ? Convert.ToBoolean(dr["ReportView"]) : true;
                    parammodel.ReportCreatorEdit = dr["ReportEdit"] != DBNull.Value ? Convert.ToBoolean(dr["ReportEdit"]) : true;
                    parammodel.ReportCreatorDelete = dr["ReportDelete"] != DBNull.Value ? Convert.ToBoolean(dr["ReportDelete"]) : true;

                    parammodel.ViewPermission = dr["viewpermission"] != DBNull.Value ? Convert.ToBoolean(dr["viewpermission"]) : true;
                    parammodel.EditPermission = dr["editpermission"] != DBNull.Value ? Convert.ToBoolean(dr["editpermission"]) : true;
                    parammodel.DeletePermission = dr["deletepermission"] != DBNull.Value ? Convert.ToBoolean(dr["deletepermission"]) : true;
                }
            }
            else
            {
                Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                parammodel.IncidentNumber = unixTimestamp.ToString();
                parammodel.IncidentDate = DateTime.Now.Date;
                parammodel.StartTime = DateTime.Now.ToString("hh:mm tt");
                parammodel.EndTime = DateTime.Now.ToString("hh:mm tt");
            }

            employeeBase.EmployeeID = parammodel.EmployeeId;
            employeeBase.IncidentID = parammodel.IncidentID;
            actionResult = employeeAction.EmployeeLinked_LoadByEmployeeID(employeeBase);
            List<EmployeeLinkedList> EmployeeLinkedList = new List<EmployeeLinkedList>();

            if (actionResult.IsSuccess)
            {
                EmployeeLinkedList = (from DataRow row in actionResult.dtResult.Rows
                                      select new EmployeeLinkedList
                                      {
                                          Id = row["ID"] != DBNull.Value ? Convert.ToInt32(row["ID"]) : 0,
                                          FilePath = row["FilePath"] != DBNull.Value ? row["FilePath"].ToString() : "",
                                          Description = row["Description"] != DBNull.Value ? row["Description"].ToString() : "",
                                      }).ToList();
            }
            parammodel.EmployeeLinkedList = EmployeeLinkedList;

            if (parammodel.IncidentID > 0)
            {
                employee.EmployeeId = parammodel.EmployeeId;
                employee.IncidentID = parammodel.IncidentID;
                actionResult = employeeAction.EmpReportProofread_Bind(employee);
                if (actionResult.IsSuccess)
                {
                    DataRow dr = actionResult.dtResult.Rows[0];
                    parammodel.ProofreadID = dr["ID"] != DBNull.Value ? Convert.ToInt32(dr["ID"]) : 0;
                    parammodel.ProofreadByFirstName = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : "";
                    parammodel.ProofreadByLastName = dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : "";
                    parammodel.ProofreadByUserName = dr["UserName"] != DBNull.Value ? dr["UserName"].ToString() : "";
                    parammodel.DateProofread = dr["CreatedDate"] != DBNull.Value ? dr["CreatedDate"].ToString() : "";
                    parammodel.ReportProofread = dr["ReportProofread"] != DBNull.Value ? Convert.ToBoolean(dr["ReportProofread"]) : false;
                }

                employeeBase.EmployeeID = parammodel.EmployeeId;
                employeeBase.IncidentID = parammodel.IncidentID;
                actionResult = employeeAction.EmployeeIncidentProofRead_LoadByEmployeeID(employeeBase);
                

                if (actionResult.IsSuccess)
                {
                    EmployeeIncidentProofReadList = (from DataRow row in actionResult.dtResult.Rows
                                                     select new EmployeeIncidentProofRead
                                                     {
                                                         UserName = row["UserName"] != DBNull.Value ? row["UserName"].ToString() : "",
                                                         FirstName = row["FirstName"] != DBNull.Value ? row["FirstName"].ToString() : "",
                                                         LastName = row["LastName"] != DBNull.Value ? row["LastName"].ToString() : "",
                                                         ReportProofread = row["ReportProofread"] != DBNull.Value ? row["ReportProofread"].ToString() : "",
                                                         CreatedDate = Convert.ToDateTime(row["CreatedDate"]) 
                                          }).ToList();
                }
                
            }
            if (parammodel.IncidentID > 0)
            {
                employee.IncidentID = parammodel.IncidentID;
                actionResult = employeeAction.EmployeeVariance_LoadByIncidentID(employee);

                if (actionResult.IsSuccess)
                {
                    DataRow dr = actionResult.dtResult.Rows[0];
                    parammodel.Resolution = dr["Resolution"] != DBNull.Value ? dr["Resolution"].ToString() : "";
                    parammodel.VarianceType = dr["VarianceType"] != DBNull.Value ? dr["VarianceType"].ToString() : "";
                    parammodel.VarianceDescription = dr["Description"] != DBNull.Value ? dr["Description"].ToString() : "";
                    parammodel.AmountType = dr["AmountType"] != DBNull.Value ? Convert.ToInt32(dr["AmountType"]) : 0;
                    parammodel.Amount = dr["Amount"] != DBNull.Value ? Convert.ToSingle(dr["Amount"]) : 0;
                }

                actionResult = employeeAction.EmployeeInvolved_LoadByIncidentID(employee);

                employeeList = (from DataRow row in actionResult.dtResult.Rows
                                select new EmployeeModel
                                {
                                    EmployeeInvolvedId = row["ID"] != DBNull.Value ? Convert.ToInt32(row["ID"]) : 0,
                                    InvolvedId = row["InvolvedID"] != DBNull.Value ? Convert.ToInt32(row["InvolvedID"]) : 0,
                                    EmployeeID = row["EmployeeID"] != DBNull.Value ? Convert.ToInt32(row["EmployeeID"]) : 0,
                                    FirstName = row["FirstName"] != DBNull.Value ? row["FirstName"].ToString() : "",
                                    LastName = row["LastName"] != DBNull.Value ? row["LastName"].ToString() : "",
                                    RoleID = row["RoleID"] != DBNull.Value ? Convert.ToInt32(row["RoleID"]) : 0,
                                    RoleName = row["RoleName"] != DBNull.Value ? row["RoleName"].ToString() : "",
                                    Sex = row["Sex"] != DBNull.Value ? row["Sex"].ToString() : "",
                                    Race = row["Race"] != DBNull.Value ? row["Race"].ToString() : "",
                                }).ToList();
            }

            //actionResult = employeeAction.GetDisplayNames();

            //if (actionResult.IsSuccess)
            //{
            //    DisplayNameList = (from DataRow row in actionResult.dtResult.Rows
            //                       select new SelectListItem
            //                       {
            //                           Text = row["DisplayName"] != DBNull.Value ? row["DisplayName"].ToString() : "",
            //                           Value = row["DisplayName"] != DBNull.Value ? row["DisplayName"].ToString() : ""
            //                       }).ToList();
            //}
            DisplayNameList.Add(new SelectListItem { Text = "Select", Value = "0" });
            employee.UserID = Convert.ToInt32(Session["UserId"]);
            employee.IncidentID = parammodel.IncidentID;

            CIMS.BaseLayer.Subject.SubjectIncidentsBase subject = new CIMS.BaseLayer.Subject.SubjectIncidentsBase();
            CIMS.ActionLayer.Subject.SubjectAction subjectAction = new CIMS.ActionLayer.Subject.SubjectAction();

            List<SelectListItem> LocationList = new List<SelectListItem>();
            actionResult = settingAction.Location_Load();
            if (actionResult.IsSuccess)
            {
                LocationList = (from DataRow row in actionResult.dtResult.Rows
                                select new SelectListItem
                                {
                                    Text = row["Location"] != DBNull.Value ? row["Location"].ToString() : "",
                                    Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                }).ToList();
            }
            parammodel.LocationList = LocationList;

            List<SelectListItem> lstRole = new List<SelectListItem>();
            actionResult = settingAction.MasterRole_Load();
            if (actionResult.IsSuccess)
            {
                lstRole = (from DataRow row in actionResult.dtResult.Rows
                           select new SelectListItem
                           {
                               Text = row["Role"] != DBNull.Value ? row["Role"].ToString() : "",
                               Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                           }).ToList();
            }
            ViewBag.lstRole = lstRole;

            AuditTypeList = GetAuditList(AuditTypeList);
            parammodel.AuditTypeList = AuditTypeList;
            parammodel.EmployeeList = employeeList;
            parammodel.DisplayNameList = DisplayNameList;
            parammodel.EmployeeIncidentProofReadList = EmployeeIncidentProofReadList;
            GetGender_RaceList();
            GetGameList();
            return parammodel;
        }

        public ActionResult EmployeeIncident(int EmpId, int? Id = 0)
        {
            bool permission = (Session["Admin"] == null ? CIMS.Models.CheckPermissions.permissionMenu("Employee Incident Details", Convert.ToInt32(Session["UserId"])) : CIMS.Models.CheckAdminPermissions.permissionMenu("Employees"));
            if (!permission)
            {
                return Redirect("~/Home/NoPermission");
            }
            EmployeeIncidentModel parammodel = new EmployeeIncidentModel();
            parammodel.EmployeeId = EmpId;
            parammodel.IncidentID = Convert.ToInt32(Id);

            return View(CreateViewModel(parammodel));
        }

        //public ActionResult EmployeeIncident(int EmpId, int? Id = 0 )
        //{
        //    bool permission = (Session["Admin"] == null ? CIMS.Models.CheckPermissions.permissionMenu("Employee Incident Details", Convert.ToInt32(Session["UserId"])) : CIMS.Models.CheckAdminPermissions.permissionMenu("Employees"));
        //    if (!permission)
        //    {
        //        return Redirect("~/Home/NoPermission");
        //    }
        //    EmployeeIncidentModel parammodel = new EmployeeIncidentModel();
        //    List<EmployeeModel> employeeList = new List<EmployeeModel>();
        //    parammodel.EmployeeId = EmpId;
        //    parammodel.IncidentID = Convert.ToInt32(Id);
        //    EmployeeIncidentBase employee = new EmployeeIncidentBase();
        //    List<SelectListItem> AuditTypeList = new List<SelectListItem>();

        //    CIMS.ActionLayer.Setting.SettingAction settingAction = new CIMS.ActionLayer.Setting.SettingAction();

        //    EmployeeBase employeeBase = new EmployeeBase();
        //    EmployeeModel employeeModel = new EmployeeModel();
        //    employeeBase.EmpID = EmpId;
        //    actionResult = employeeAction.Employees_Load(employeeBase);
        //    if (actionResult.IsSuccess)
        //    {
        //        DataRow dr = actionResult.dtResult.Rows[0];
        //        employeeModel.LogoFirstName = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : "";
        //        employeeModel.LogoLastName = dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : "";
        //        employeeModel.LogoMiddleName = dr["MiddleName"] != DBNull.Value ? dr["MiddleName"].ToString() : "";
        //    }
        //    parammodel.EmployeeModel = employeeModel;

        //    List<SelectListItem> lstNatureOfIncident = new List<SelectListItem>();
        //    CIMS.BaseLayer.Setting.NatureofIncidentBase natureBase = new CIMS.BaseLayer.Setting.NatureofIncidentBase();
        //    natureBase.NatureType = 2;
        //    actionResult = settingAction.MasterNatureofIncident_Load(natureBase);
        //    if (actionResult.IsSuccess)
        //    {
        //        lstNatureOfIncident = (from DataRow row in actionResult.dtResult.Rows
        //                               select new SelectListItem
        //                               {
        //                                   Text = row["Nature"] != DBNull.Value ? row["Nature"].ToString() : "",
        //                                   Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
        //                               }).ToList();
        //    }
        //    ViewBag.lstNatureOfIncident = lstNatureOfIncident;

        //    List<SelectListItem> lstShortDescription = new List<SelectListItem>();
        //    ViewBag.lstShortDescription = lstShortDescription;

        //    List<SelectListItem> lstVarianceType = new List<SelectListItem>();
        //    actionResult = settingAction.VarianceType_Load();
        //    if (actionResult.IsSuccess)
        //    {
        //        lstVarianceType = (from DataRow row in actionResult.dtResult.Rows
        //                           select new SelectListItem
        //                           {
        //                               Text = row["VarianceType"] != DBNull.Value ? row["VarianceType"].ToString() : "",
        //                               Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
        //                           }).ToList();
        //    }
        //    ViewBag.lstVarianceType = lstVarianceType;

        //    List<SelectListItem> lstVarianceResoluion = new List<SelectListItem>();
        //    actionResult = settingAction.VarianceResolution_Load();
        //    if (actionResult.IsSuccess)
        //    {
        //        lstVarianceResoluion = (from DataRow row in actionResult.dtResult.Rows
        //                                select new SelectListItem
        //                                {
        //                                    Text = row["Resolution"] != DBNull.Value ? row["Resolution"].ToString() : "",
        //                                    Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
        //                                }).ToList();
        //    }
        //    ViewBag.lstVarianceResoluion = lstVarianceResoluion;

        //    employee.IncidentID = parammodel.IncidentID;

        //    if (Id > 0)
        //    {
        //        actionResult = employeeAction.EmployeeIncident_LoadByIncidentID(employee);
        //        if (actionResult.IsSuccess)
        //        {
        //            DataRow dr = actionResult.dtResult.Rows[0];
        //            parammodel.IncidentID = dr["IncidentID"] != DBNull.Value ? Convert.ToInt32(dr["IncidentID"]) : 0;
        //            parammodel.IncidentNumber = dr["IncidentNumber"] != DBNull.Value ? dr["IncidentNumber"].ToString() : "";
        //            parammodel.NatureOfIncident = dr["NatureOfEvent"] != DBNull.Value ? dr["NatureOfEvent"].ToString() : "";
        //            parammodel.ShortDescription = dr["ShortDescriptor"] != DBNull.Value ? dr["ShortDescriptor"].ToString() : "";
        //            parammodel.ActiveStatus = dr["ActiveStatus"] != DBNull.Value ? Convert.ToBoolean(dr["ActiveStatus"]) : false;
        //            parammodel.Status = dr["Status"] != DBNull.Value ? dr["Status"].ToString() : "";
        //            if (dr["IncidentDate"] != DBNull.Value)
        //            {
        //                parammodel.IncidentDate = Convert.ToDateTime(dr["IncidentDate"]);
        //            }
        //            else
        //            {
        //                parammodel.IncidentDate = DateTime.Now.Date;
        //            }
        //            parammodel.Description = dr["Description"] != DBNull.Value ? dr["Description"].ToString() : "";
        //            parammodel.Location = dr["Location"] != DBNull.Value ? dr["Location"].ToString() : "";
        //            parammodel.IncidentRole = dr["IncidentRole"] != DBNull.Value ? dr["IncidentRole"].ToString() : "";
        //            parammodel.StartTime = dr["IncidentTime"] != DBNull.Value ? dr["IncidentTime"].ToString() : DateTime.Now.ToString("hh:mm tt");
        //            parammodel.EndTime = dr["EndTime"] != DBNull.Value ? dr["EndTime"].ToString() : DateTime.Now.ToString("hh:mm tt");

        //            parammodel.UD27 = dr["UD27"] != DBNull.Value ? dr["UD27"].ToString() : "";
        //            parammodel.UD34 = dr["UD34"] != DBNull.Value ? dr["UD34"].ToString() : "";
        //            parammodel.UD35 = dr["UD35"] != DBNull.Value ? dr["UD35"].ToString() : "";
        //            parammodel.Notes = dr["Notes"] != DBNull.Value ? dr["Notes"].ToString() : "";
        //            parammodel.IPVRDescription = dr["IPVRDescription"] != DBNull.Value ? dr["IPVRDescription"].ToString() : "";
        //            parammodel.CheckPermissionID = dr["CreatedBy"] != DBNull.Value ? Convert.ToInt32(dr["CreatedBy"]) : 0;
        //            parammodel.ReportCreatorUser = dr["ReportCreatorUser"] != DBNull.Value ? dr["ReportCreatorUser"].ToString() : "";
        //            parammodel.ReportCreatorFirstName = dr["ReportCreatorFirstName"] != DBNull.Value ? dr["ReportCreatorFirstName"].ToString() : "";
        //            parammodel.ReportCreatorLastName = dr["ReportCreatorLastName"] != DBNull.Value ? dr["ReportCreatorLastName"].ToString() : "";
        //            parammodel.ReportCreateDate = dr["CreatedDate"] != DBNull.Value ? dr["CreatedDate"].ToString() : "";
        //            parammodel.ReportCreatorView = dr["ReportView"] != DBNull.Value ? Convert.ToBoolean(dr["ReportView"]) : true;
        //            parammodel.ReportCreatorEdit = dr["ReportEdit"] != DBNull.Value ? Convert.ToBoolean(dr["ReportEdit"]) : true;
        //            parammodel.ReportCreatorDelete = dr["ReportDelete"] != DBNull.Value ? Convert.ToBoolean(dr["ReportDelete"]) : true;
        //        }
        //    }
        //    else
        //    {
        //        //actionResult = employeeAction.EmployeeIncidentsMax_Load();
        //        //if (actionResult.IsSuccess)
        //        //{
        //        //    parammodel.IncidentNumber = actionResult.dtResult.Rows[0][0] != DBNull.Value ? actionResult.dtResult.Rows[0][0].ToString() : " ";

        //        //}
        //        Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        //        parammodel.IncidentNumber = unixTimestamp.ToString();
        //        parammodel.IncidentDate = DateTime.Now.Date;
        //        parammodel.StartTime = DateTime.Now.ToString("hh:mm tt");
        //        parammodel.EndTime = DateTime.Now.ToString("hh:mm tt");
        //    }

        //    employeeBase.EmployeeID = parammodel.EmployeeId;
        //    employeeBase.IncidentID = parammodel.IncidentID;
        //    actionResult = employeeAction.EmployeeLinked_LoadByEmployeeID(employeeBase);
        //    List<EmployeeLinkedList> EmployeeLinkedList = new List<EmployeeLinkedList>();

        //    if (actionResult.IsSuccess)
        //    {
        //        EmployeeLinkedList = (from DataRow row in actionResult.dtResult.Rows
        //                              select new EmployeeLinkedList
        //                              {
        //                                  Id = row["ID"] != DBNull.Value ? Convert.ToInt32(row["ID"]) : 0,
        //                                  FilePath = row["FilePath"] != DBNull.Value ? row["FilePath"].ToString() : "",
        //                                  Description = row["Description"] != DBNull.Value ? row["Description"].ToString() : "",
        //                              }).ToList();
        //    }
        //    parammodel.EmployeeLinkedList = EmployeeLinkedList;

        //    if (parammodel.IncidentID > 0)
        //    {
        //        employee.EmployeeId = parammodel.EmployeeId;
        //        employee.IncidentID = parammodel.IncidentID;
        //        actionResult = employeeAction.EmpReportProofread_Bind(employee);
        //        if (actionResult.IsSuccess)
        //        {
        //            DataRow dr = actionResult.dtResult.Rows[0];
        //            parammodel.ProofreadID = dr["ID"] != DBNull.Value ? Convert.ToInt32(dr["ID"]) : 0;
        //            parammodel.ProofreadByFirstName = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : "";
        //            parammodel.ProofreadByLastName = dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : "";
        //            parammodel.ProofreadByUserName = dr["UserName"] != DBNull.Value ? dr["UserName"].ToString() : "";
        //            parammodel.DateProofread = dr["CreatedDate"] != DBNull.Value ? dr["CreatedDate"].ToString() : "";
        //            parammodel.ReportProofread = dr["ReportProofread"] != DBNull.Value ? Convert.ToBoolean(dr["ReportProofread"]) : false;
        //        }
        //    }
        //    if (parammodel.IncidentID > 0)
        //    {
        //        employee.IncidentID = parammodel.IncidentID;
        //        actionResult = employeeAction.EmployeeVariance_LoadByIncidentID(employee);

        //        if (actionResult.IsSuccess)
        //        {
        //            DataRow dr = actionResult.dtResult.Rows[0];
        //            parammodel.Resolution = dr["Resolution"] != DBNull.Value ? dr["Resolution"].ToString() : "";
        //            parammodel.VarianceType = dr["VarianceType"] != DBNull.Value ? dr["VarianceType"].ToString() : "";
        //            parammodel.VarianceDescription = dr["Description"] != DBNull.Value ? dr["Description"].ToString() : "";
        //            parammodel.AmountType = dr["AmountType"] != DBNull.Value ? Convert.ToInt32(dr["AmountType"]) : 0;
        //            parammodel.Amount = dr["Amount"] != DBNull.Value ? Convert.ToSingle(dr["Amount"]) : 0;
        //        }

        //        actionResult = employeeAction.EmployeeInvolved_LoadByIncidentID(employee);

        //        employeeList = (from DataRow row in actionResult.dtResult.Rows
        //                        select new EmployeeModel
        //                        {
        //                            EmployeeInvolvedId = row["ID"] != DBNull.Value ? Convert.ToInt32(row["ID"]) : 0,
        //                            InvolvedId = row["InvolvedID"] != DBNull.Value ? Convert.ToInt32(row["InvolvedID"]) : 0,
        //                            EmployeeID = row["EmployeeID"] != DBNull.Value ? Convert.ToInt32(row["EmployeeID"]) : 0,
        //                            FirstName = row["FirstName"] != DBNull.Value ? row["FirstName"].ToString() : "",
        //                            LastName = row["LastName"] != DBNull.Value ? row["LastName"].ToString() : "",
        //                            RoleID = row["RoleID"] != DBNull.Value ? Convert.ToInt32(row["RoleID"]) : 0,
        //                            RoleName = row["RoleName"] != DBNull.Value ? row["RoleName"].ToString() : "",
        //                            Sex = row["Sex"] != DBNull.Value ? row["Sex"].ToString() : "",
        //                            Race = row["Race"] != DBNull.Value ? row["Race"].ToString() : "",
        //                        }).ToList();
        //    }
        //    actionResult = employeeAction.GetDisplayNames();


        //    if (actionResult.IsSuccess)
        //    {
        //        DisplayNameList = (from DataRow row in actionResult.dtResult.Rows
        //                           select new SelectListItem
        //                           {
        //                               Text = row["DisplayName"] != DBNull.Value ? row["DisplayName"].ToString() : "",
        //                               Value = row["DisplayName"] != DBNull.Value ? row["DisplayName"].ToString() : ""
        //                           }).ToList();
        //    }

        //    //DisplayNameList = null;

        //    employee.UserID = Convert.ToInt32(Session["UserId"]);
        //    employee.IncidentID = parammodel.IncidentID;
        //    //actionResult = employeeAction.UsersReportsAccess_LoadAll(employee);
        //    //List<EmployeeIncidentModel> UsersList = new List<EmployeeIncidentModel>();
        //    //if (actionResult.IsSuccess)
        //    //{
        //    //    UsersList = (from DataRow row in actionResult.dtResult.Rows
        //    //                 select new EmployeeIncidentModel
        //    //                 {
        //    //                     EmployeeId = row["EmployeeID"] != DBNull.Value ? Convert.ToInt32(row["EmployeeID"]) : 0,
        //    //                     FirstName = row["FirstName"] != DBNull.Value ? row["FirstName"].ToString() : "",
        //    //                     LastName = row["LastName"] != DBNull.Value ? row["LastName"].ToString() : "",
        //    //                     UserName = row["UserName"] != DBNull.Value ? row["UserName"].ToString() : "",
        //    //                     UserID = row["UserID"] != DBNull.Value ? Convert.ToInt32(row["UserID"]) : 0,
        //    //                     RepPerID = row["RepPerID"] != DBNull.Value ? Convert.ToInt32(row["RepPerID"]) : 0,
        //    //                     IncidentID = row["ReportID"] != DBNull.Value ? Convert.ToInt32(row["ReportID"]) : 0,
        //    //                     ReportAccessBy = row["ReportAccessBy"] != DBNull.Value ? Convert.ToInt32(row["ReportAccessBy"]) : 0,
        //    //                     ReportView = row["ReportView"] != DBNull.Value ? Convert.ToBoolean(row["ReportView"]) : false,
        //    //                     ReportEdit = row["ReportEdit"] != DBNull.Value ? Convert.ToBoolean(row["ReportEdit"]) : false,
        //    //                     ReportDelete = row["ReportDelete"] != DBNull.Value ? Convert.ToBoolean(row["ReportDelete"]) : false
        //    //                 }).ToList();
        //    //}
        //    //parammodel.empIncidentList = UsersList;

        //    CIMS.BaseLayer.Subject.SubjectIncidentsBase subject = new CIMS.BaseLayer.Subject.SubjectIncidentsBase();
        //    CIMS.ActionLayer.Subject.SubjectAction subjectAction = new CIMS.ActionLayer.Subject.SubjectAction();

        //    List<SelectListItem> LocationList = new List<SelectListItem>();
        //    actionResult = settingAction.Location_Load();
        //    if (actionResult.IsSuccess)
        //    {
        //        LocationList = (from DataRow row in actionResult.dtResult.Rows
        //                        select new SelectListItem
        //                        {
        //                            Text = row["Location"] != DBNull.Value ? row["Location"].ToString() : "",
        //                            Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
        //                        }).ToList();
        //    }
        //    parammodel.LocationList = LocationList;

        //    List<SelectListItem> lstRole = new List<SelectListItem>();
        //    actionResult = settingAction.MasterRole_Load();
        //    if (actionResult.IsSuccess)
        //    {
        //        lstRole = (from DataRow row in actionResult.dtResult.Rows
        //                   select new SelectListItem
        //                   {
        //                       Text = row["Role"] != DBNull.Value ? row["Role"].ToString() : "",
        //                       Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
        //                   }).ToList();
        //    }
        //    ViewBag.lstRole = lstRole;

        //    //AuditTypeList = GetAuditTypeList(AuditTypeList);
        //    AuditTypeList = GetAuditList(AuditTypeList);
        //    parammodel.AuditTypeList = AuditTypeList;
        //    parammodel.EmployeeList = employeeList;
        //    parammodel.DisplayNameList = DisplayNameList;
        //    GetGender_RaceList();
        //    GetGameList();

        //    return View(parammodel);
        //}
        #endregion

        #region GetAuditTypeList
        private List<SelectListItem> GetAuditTypeList(List<SelectListItem> AuditTypeList)
        {
            actionResult = employeeAction.GetQuestionAuditTypes();
            if (actionResult.IsSuccess)
            {
                AuditTypeList = (from DataRow row in actionResult.dtResult.Rows
                                 select new SelectListItem
                                 {
                                     Text = row["AuditType"] != DBNull.Value ? row["AuditType"].ToString() : "",
                                     Value = row["AuditType"] != DBNull.Value ? row["AuditType"].ToString() : ""
                                 }).ToList();
            }
            return AuditTypeList;
        }
        private List<SelectListItem> GetAuditList(List<SelectListItem> AuditList)
        {
            actionResult = employeeAction.GetAudits();
            if (actionResult.IsSuccess)
            {
                AuditList = (from DataRow row in actionResult.dtResult.Rows
                             select new SelectListItem
                             {
                                 Text = row["AuditType"] != DBNull.Value ? row["AuditType"].ToString() : "",
                                 Value = row["AuditId"] != DBNull.Value ? row["AuditID"].ToString() : ""
                             }).ToList();
            }
            return AuditList;
        }
        #endregion


        #region GetGender_RaceList
        private void GetGender_RaceList()
        {
            CIMS.ActionLayer.Setting.SettingAction settingAction = new CIMS.ActionLayer.Setting.SettingAction();

            List<SelectListItem> genderList = new List<SelectListItem>();
            actionResult = settingAction.MasterSex_Load();
            if (actionResult.IsSuccess)
            {
                genderList = (from DataRow row in actionResult.dtResult.Rows
                              select new SelectListItem
                              {
                                  Text = row["Sex"] != DBNull.Value ? row["Sex"].ToString() : "",
                                  Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                              }).ToList();
            }


            List<SelectListItem> raceList = new List<SelectListItem>();
            actionResult = settingAction.MasterRace_Load();
            if (actionResult.IsSuccess)
            {
                raceList = (from DataRow row in actionResult.dtResult.Rows
                            select new SelectListItem
                            {
                                Text = row["Race"] != DBNull.Value ? row["Race"].ToString() : "",
                                Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                            }).ToList();
            }

            ViewBag.GenderList = genderList;
            ViewBag.RaceList = raceList;
        }
        #endregion

        #region GetGameList
        private void GetGameList()
        {
            CIMS.ActionLayer.Setting.SettingAction settingAction = new CIMS.ActionLayer.Setting.SettingAction();

            List<SelectListItem> GameList = new List<SelectListItem>();
            actionResult = settingAction.MasterGame_Load();
            if (actionResult.IsSuccess)
            {
                GameList = (from DataRow row in actionResult.dtResult.Rows
                            select new SelectListItem
                            {
                                Text = row["Game"] != DBNull.Value ? row["Game"].ToString() : "",
                                Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                            }).ToList();
            }

            ViewBag.GameList = GameList;

        }
        #endregion

        #region SaveEmployeeIncident
        [HttpPost]
        public ActionResult EmployeeIncident(EmployeeIncidentModel model)
        {
            string jsonString = string.Empty;
            try
            {
                if (Convert.ToDateTime(model.EndDate) < Convert.ToDateTime(model.StartDate))
                {
                    TempData["ErrorMessage"] = "End date cannot be before Start date.";
                    jsonString = "fail";
                    return View("EmployeeIncident", CreateViewModel(model));
                }

                EmployeeIncidentBase employee = new EmployeeIncidentBase();
                employee.EmployeeId = model.EmployeeId;
                employee.IncidentID = model.IncidentID;
                //Ab 26/2
                if (model.IncidentID > 0)
                {
                    TempData["SaveSuccess"] = "";
                }
                else
                {
                    TempData["SaveSuccess"] = "Success";
                }
                employee.ActiveStatus = model.ActiveStatus;
                employee.Description = model.Description;
                employee.IncidentDate = model.IncidentDate;
                employee.IncidentNumber = model.IncidentNumber;
                employee.IncidentRole = model.IncidentRole;
                employee.Location = model.Location;
                employee.NatureOfIncident = model.NatureOfIncident;
                employee.ShortDescription = model.ShortDescription;
                employee.StartTime = model.StartTime;
                employee.EndTime = model.EndTime;
                employee.StartDate = model.StartDate;
                employee.EndDate = model.EndDate;
                employee.Status = model.Status;
                employee.UD27 = model.UD27;
                employee.UD34 = model.UD34;
                employee.UD35 = model.UD35;
                employee.Notes = model.Notes;
                employee.IPVRDescription = model.IPVRDescription;
                employee.CreatedBy = Convert.ToInt32(Session["UserId"]);
                employee.ReportCreatorView = true;
                employee.ReportCreatorEdit = true;
                employee.ReportCreatorDelete = true;

                actionResult = employeeAction.EmployeeIncident_InsertUpdate(employee);

                if (actionResult.dtResult.Rows.Count > 0)
                {
                    TempData["SuccessMessage"] = "Incident Detail has been Saved Successfully";
                    model.IncidentID = Convert.ToInt32(actionResult.dtResult.Rows[0][0]);

                    AddALLUsersRolesReportsAccess(model.EmployeeId, model.IncidentID);
                }
                else
                {

                }

                if (actionResult.dtResult.Rows.Count > 0)
                {
                    jsonString = "success";
                    model.IncidentID = Convert.ToInt32(actionResult.dtResult.Rows[0][0]);
                }
                else
                {
                    jsonString = "fail";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";
            }

            return RedirectToAction("EmployeeIncident", new { Id = model.IncidentID, model = model, EmpId = model.EmployeeId });
        }
        #endregion


        #region SaveEmployeeVariance
        [HttpPost]
        public ActionResult EmployeeVariance(EmployeeIncidentModel model)
        {
            string jsonString = string.Empty;
            try
            {
                EmployeeIncidentBase employee = new EmployeeIncidentBase();
                employee.EmployeeId = model.EmployeeId;
                employee.IncidentID = model.IncidentID;
                employee.VarianceType = model.VarianceType;
                employee.Resolution = model.Resolution;
                employee.Amount = model.Amount;
                employee.AmountType = model.AmountType;
                employee.VarianceDescription = model.VarianceDescription;
                actionResult = employeeAction.EmployeeVariance_InsertUpdate(employee);

                if (actionResult.dtResult.Rows.Count > 0)
                {
                    jsonString = "success";
                }
                else
                {
                    jsonString = "fail";
                }
            }
            catch (Exception)
            {
                jsonString = "-1";


            }
            return RedirectToAction("EmployeeIncident", new { Id = model.IncidentID, EmpId = model.EmployeeId });
        }
        #endregion


        #region EmployeeIncidentLInkedFilesSave
        [HttpPost]
        public ActionResult EmployeeIncidentLInkedFiles(EmployeeIncidentModel model, FormCollection fc)
        {
            string FilePath = "~/Content/Employee/LinkedFiles/";
            if (!Directory.Exists(Server.MapPath(FilePath)))
            {
                Directory.CreateDirectory(Server.MapPath(FilePath));
            }
            string uploadedfilename = "";
            HttpPostedFileBase pfb = Request.Files["fileUpload"];
            if (pfb != null && pfb.ContentLength > 0)
            {
                var fileName = Path.GetFileName(pfb.FileName);
                uploadedfilename = Guid.NewGuid().ToString().Substring(0, 5) + "_" + fileName;
                string filePath = System.IO.Path.Combine(HttpContext.Server.MapPath(FilePath),
                                   uploadedfilename);

                pfb.SaveAs(filePath);
                //EmpNumber, Age, Sex, Race, LastName, FirstName, MiddleName, Height, Weight, StaffPosition, Eyes, Complexion, Build, Glasses, Restricted, RoleName, UD9

            }

            string site = System.Configuration.ConfigurationManager.AppSettings["site"];
            EmployeeBase employee = new EmployeeBase();
            employee.EmployeeID = model.EmployeeId;
            employee.ID = Convert.ToInt32(fc["LinkedId"]);
            employee.FilePath = site + "/Content/Employee/LinkedFiles/" + uploadedfilename;
            employee.Description = fc["Description"];
            employee.IncidentID = model.IncidentID;
            actionResult = employeeAction.EmployeeLinked_InsertUpdate(employee);
            if (actionResult.IsSuccess)
            {
                ViewBag.message = "";
            }
            else
            {
                ViewBag.errorMessage = "";
            }

            return RedirectToAction("EmployeeIncident", new { Id = model.IncidentID, EmpId = model.EmployeeId });
        }

        #endregion
        #region UpdateEmployeeInvolved
        [HttpPost]
        public ActionResult EmployeeInvolved(EmployeeIncidentModel model)
        {
            //EmpNumber, Age, Sex, Race, LastName, FirstName, MiddleName, Height, Weight, StaffPosition, Eyes, Complexion, Build, Glasses, Restricted, RoleName, UD9
            EmployeeBase employee = new EmployeeBase();
            employee.EmployeeInvolvedId = Convert.ToInt32(model.EmployeeInvolvedId);
            employee.UserID = Convert.ToInt32(Session["UserID"]);
            employee.EmployeeID = model.EmployeeId;
            employee.InvolvedId = model.InvolvedId;
            employee.IncidentID = model.IncidentID;
            employee.Sex = model.EmployeeModel.Sex;
            employee.Race = model.EmployeeModel.Race;

            if (model.EmployeeModel.FirstName != null && model.EmployeeModel.FirstName != "")
            {
                employee.FirstName = model.EmployeeModel.FirstName;
            }
            else
            {
                employee.FirstName = "Unknown";
            }
            if (model.EmployeeModel.LastName != null && model.EmployeeModel.LastName != "")
            {
                employee.LastName = model.EmployeeModel.LastName;
            }
            else
            {
                employee.LastName = "Involved";
            }


            employee.RoleName = model.EmployeeModel.RoleName;


            actionResult = employeeAction.EmployeesInvolved_InsertUpdate(employee);



            if (actionResult.IsSuccess)
            {
                ViewBag.message = "";
            }
            else
            {
                ViewBag.errorMessage = "";
            }

            return RedirectToAction("EmployeeIncident", new { Id = model.IncidentID, EmpId = model.EmployeeId });
        }
        #endregion


        #region DeleteEmployeeInvolved
        [HttpPost]
        public JsonResult DeleteEmployeeInvolved(int? Id = 0, int? RepId = 0)
        {
            string json = string.Empty;
            try
            {
                employee.ID = Convert.ToInt32(Id);
                employee.IncidentID = Convert.ToInt32(RepId);
                actionResult = employeeAction.EmployeeInvolved_Delete(employee);
                if (actionResult.IsSuccess)
                {
                    json = "success";
                }
                else
                {
                    json = "fail";
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


        #region UpdateEmployeePaceAudit
        [HttpPost]
        public ActionResult EmployeePaceAudit(EmployeeIncidentModel model)
        {

            EmployeeIncidentBase employee = new EmployeeIncidentBase();

            employee.IncidentID = model.IncidentID;
            employee.Game = model.Game;
            employee.DisplayName = model.DisplayName;
            employee.PaceStartTime = model.PaceStartTime;
            employee.PaceEndTime = model.PaceEndTime;
            employee.ShuffleShoe = model.ShuffleShoe;
            employee.TimeTaken = model.TimeTaken;
            employee.PaceAuditPositionsPlayed = model.PaceAuditPositionsPlayed;
            employee.PaceDescription = model.PaceDescription;
            employee.PaceAuditHandsPerHour = model.PaceAuditHandsPerHour;
            employee.PaceAuditHandsPlayed = model.PaceAuditHandsPlayed;
            //employee.Observation = model.Observation;

            actionResult = employeeAction.EmployeesPaceAudit_InsertUpdate(employee);

            if (actionResult.IsSuccess)
            {
                ViewBag.message = "";
            }
            else
            {
                ViewBag.errorMessage = "";
            }

            return RedirectToAction("EmployeeIncident", new { Id = model.IncidentID, EmpId = model.EmployeeId });
        }
        #endregion


        #region LoadPartialPaceAudit
        public PartialViewResult _PartailPaceAudit(int IncidentId, string DisplayName, string Shuffle, string Game)
        {
            EmployeeIncidentModel model = new EmployeeIncidentModel();
            EmployeeIncidentBase employee = new EmployeeIncidentBase();
            if (Game == "Roulette")
            {
                ViewBag.Label = "Spins";
            }
            else
            {
                ViewBag.Label = "Hands";
            }
            employee.IncidentID = IncidentId;
            employee.Game = Game;
            employee.DisplayName = DisplayName;
            employee.ShuffleShoe = Shuffle;
            model.IncidentID = IncidentId;
            model.ShuffleShoe = Shuffle;
            model.Game = Game;
            model.DisplayName = DisplayName;
            actionResult = employeeAction.EmployeePaceAudit_LoadByIncidentID(employee);
            if (actionResult.IsSuccess)
            {
                DataRow dr = actionResult.dtResult.Rows[0];
                model.PaceDescription = dr["Description"] != DBNull.Value ? dr["Description"].ToString() : "";
                model.PaceStartTime = dr["StartTime"] != DBNull.Value ? dr["StartTime"].ToString() : "";
                model.PaceEndTime = dr["EndTime"] != DBNull.Value ? dr["EndTime"].ToString() : "";
                model.PaceAuditPositionsPlayed = dr["PaceAuditPositionsPlayed"] != DBNull.Value ? Convert.ToInt32(dr["PaceAuditPositionsPlayed"]) : 0;
                model.PaceAuditHandsPerHour = dr["PaceAuditHandsPerHour"] != DBNull.Value ? Convert.ToInt32(dr["PaceAuditHandsPerHour"]) : 0;
                model.PaceAuditHandsPlayed = dr["PaceAuditHandsPlayed"] != DBNull.Value ? Convert.ToInt32(dr["PaceAuditHandsPlayed"]) : 0;
                model.ShuffleShoe = dr["ShuffleShoe"] != DBNull.Value ? dr["ShuffleShoe"].ToString() : "";
                model.TimeTaken = dr["TimeTaken"] != DBNull.Value ? dr["TimeTaken"].ToString() : "";


            }
            return PartialView(model);
        }
        #endregion

        #region CalculateAverageTime
        public JsonResult CalculateAverageTime(int IncidentId, string Game, string Shuffle, string TimeTakenCurrent, string DisplayName = null)
        {
            string TimeTkn = "";
            EmployeeIncidentBase employee = new EmployeeIncidentBase();
            employee.IncidentID = IncidentId;
            employee.Game = Game;
            employee.ShuffleShoe = Shuffle;

            actionResult = employeeAction.EmployeePaceAudit_LoadByIncidentID(employee);
            List<string> TimeTakenList = new List<string>();
            if (actionResult.IsSuccess)
            {
                TimeTakenList = (from DataRow row in actionResult.dtResult.Rows
                                 where row["DisplayName"].ToString() != DisplayName
                                 select row["TimeTaken"].ToString()).ToList();



            }
            if (!string.IsNullOrEmpty(TimeTakenCurrent))
            {
                TimeTakenList.Add(TimeTakenCurrent);
            }
            Double avgSeconds = 0;
            foreach (var TimeTaken in TimeTakenList)
            {
                if (TimeTaken != string.Empty)
                {
                    avgSeconds += Convert.ToDouble(TimeTaken.Substring(6, 2));
                    avgSeconds += Convert.ToDouble(TimeTaken.Substring(3, 2)) * 60;
                    avgSeconds += Convert.ToDouble(TimeTaken.Substring(0, 2)) * 3600;
                }
            }
            if (TimeTakenList.Count > 0)
            {
                var SpanTotalTime = TimeSpan.FromSeconds(avgSeconds / TimeTakenList.Count);
                TimeTkn = String.Format("{0:00}:{1:00}:{2:00}", SpanTotalTime.Hours, SpanTotalTime.Minutes, SpanTotalTime.Seconds);
            }
            else
            {
                TimeTkn = String.Format("{0:00}:{1:00}:{2:00}", 0, 0, 0);

            }
            return Json(TimeTkn);
        }
        #endregion

        #region CalculateAverageHandsTime
        public JsonResult CalculateAverageHandsTime(int IncidentId, string Game, string Shuffle, string TimeTaken, int? HandsDealt = 0, string DisplayName = null)
        {
            EmployeeIncidentBase employee = new EmployeeIncidentBase();
            int iCount = 0;
            int TotalHandsDealt = 0;
            double TotalTime = 0;
            string lblHands = "";
            string lblCurrentHands = "";
            employee.IncidentID = IncidentId;
            employee.Game = Game;
            employee.ShuffleShoe = Shuffle;
            actionResult = employeeAction.EmployeePaceAudit_LoadByIncidentID(employee);
            List<SelectListItem> TimeTakenList = new List<SelectListItem>();
            if (actionResult.IsSuccess)
            {
                TimeTakenList = (from DataRow row in actionResult.dtResult.Rows
                                 where row["DisplayName"].ToString() != DisplayName
                                 select new SelectListItem
                                 {
                                     Text = row["TimeTaken"].ToString(),
                                     Value = row["PaceAuditHandsPlayed"].ToString()
                                 }).ToList();



            }
            if (!string.IsNullOrEmpty(TimeTaken) && HandsDealt > 0)
            {
                TimeTakenList.Add(new SelectListItem { Text = TimeTaken, Value = HandsDealt.ToString() });
            }
            for (int i = 0; i <= TimeTakenList.Count - 1; i++)
            {
                if (TimeTaken != string.Empty)
                {
                    iCount += 1;
                    TotalTime += Convert.ToDouble(TimeTakenList[i].Text.Substring(6, 2));
                    TotalTime += Convert.ToDouble(TimeTakenList[i].Text.Substring(3, 2)) * 60;
                    TotalTime += Convert.ToDouble(TimeTakenList[i].Text.Substring(0, 2)) * 3600;
                    if (Convert.ToInt32(TimeTakenList[i].Value) > 0)
                    {
                        TotalHandsDealt += Convert.ToInt32(TimeTakenList[i].Value);
                    }
                }

            }

            if (iCount > 0)
            {
                lblHands = ((TotalHandsDealt / TotalTime) * 3600).ToString("N0");

                int HandsDelt = Convert.ToInt32(HandsDealt);
                double iTime = 0;

                if (TimeTaken.Length > 0)
                {
                    iTime += Convert.ToDouble(TimeTaken.Substring(6, 2));
                    iTime += Convert.ToDouble(TimeTaken.Substring(3, 2)) * 60;
                    iTime += Convert.ToDouble(TimeTaken.Substring(0, 2)) * 3600;
                }
                if (iTime > 0)
                {
                    lblCurrentHands = ((HandsDelt / iTime) * 3600).ToString("N0");
                }
                else
                {
                    lblCurrentHands = "0";
                }
            }
            else
            {
                lblHands = "0";
                lblCurrentHands = "0";
            }


            return Json(lblHands + "|" + lblCurrentHands);
        }
        #endregion


        #region Combine Employee

        #region SearchEmployee
        public ActionResult SearchEmployee(int? id = 0)
        {
            if (id > 0)
            {
                EmployeeModel model = new EmployeeModel();
                List<SelectListItem> codesList = new List<SelectListItem>();
                List<SelectListItem> incidentTypeList = new List<SelectListItem>();
                List<SelectListItem> incidentDescriptionList = new List<SelectListItem>();
                actionResult = subjectAction.Codes_LoadAll();
                if (actionResult.IsSuccess)
                {
                    codesList = actionResult.dtResult.AsEnumerable().Select(v => new SelectListItem
                    {
                        Text = Convert.ToString(v["Description"]),
                        Value = Convert.ToString(v["Description"])
                    }).ToList();
                    ViewBag.StatusList = codesList;
                }
                CIMS.BaseLayer.ActionResult actinResultResult = new BaseLayer.ActionResult();
                actinResultResult = subjectAction.IncidentNatureOfEvent_LoadAll();
                if (actinResultResult.IsSuccess)
                {
                    incidentTypeList = actinResultResult.dtResult.AsEnumerable().Select(v => new SelectListItem
                    {
                        Text = Convert.ToString(v["NatureOfEvent"]),
                        Value = Convert.ToString(v["NatureOfEvent"])
                    }).ToList();
                    ViewBag.NOIList = incidentTypeList;
                }
                ViewBag.DescriptionList = incidentDescriptionList;
                ViewBag.EmployeeID = id;
                return View(model);
            }
            else
            {
                return RedirectToAction("EmployeeList");
            }
        }
        #endregion

        #region GetEmployeeSearchResult
        [HttpGet]
        public JsonResult GetEmployeeSearchResult(string FirstName, string LastName, string Sex, string Race, string DateOfBirth, string IncidentDate, string NatureOfIncident, string Description, string OverallStatus, int CurrentEmployeeId = 0)
        {
            List<EmployeeModel> model = new List<EmployeeModel>();
            string json = "";
            employee.FirstName = FirstName;
            employee.LastName = LastName;
            employee.Sex = Sex;
            employee.Race = Race;
            if (!String.IsNullOrEmpty(DateOfBirth))
                employee.DateOfBirth = Convert.ToDateTime(DateOfBirth);
            else
                employee.DateOfBirth = null;
            employee.IncidentDate = IncidentDate;
            employee.NatureOfIncident = NatureOfIncident;
            employee.ShortDescription = Description;
            employee.OverallStatus = OverallStatus;
            actionResult = employeeAction.SearchEmployees(employee);
            if (actionResult.IsSuccess)
            {
                model = CommonMethods.ConvertTo<EmployeeModel>(actionResult.dtResult);
                model = model.Where(v => v.EmployeeID != CurrentEmployeeId).ToList();
                json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region SearchEmployee
        [HttpPost]
        public ActionResult SearchEmployee(FormCollection fc)
        {
            string CombineEmployeeIDs = !String.IsNullOrEmpty(fc["hdnEmployeeID"]) ? Convert.ToString(fc["hdnEmployeeID"]) : "";
            int empId = !String.IsNullOrEmpty(fc["hdnCurrentEmployeeID"]) ? Convert.ToInt32(fc["hdnCurrentEmployeeID"]) : 0;
            if (CombineEmployeeIDs != "")
            {
                string[] splitCombineEmp = CombineEmployeeIDs.Trim(',').Split(',');
                if (splitCombineEmp.Length > 0)
                {
                    for (int i = 0; i < splitCombineEmp.Length; i++)
                    {
                        employee.EmployeeID = empId;
                        employee.UserID = Convert.ToInt32(splitCombineEmp[i]);
                        actionResult = employeeAction.CombineEmployee(employee);
                        if (actionResult.IsSuccess)
                        {
                            continue;
                        }
                    }
                }
                TempData["SuccessMessage"] = "Employee Combined Successfully.";
            }
            return RedirectToAction("EmployeeList");
        }
        #endregion

        #endregion


        #region EmployeeIncidentList
        public PartialViewResult ALLEmployeeIncidentsList(int EventId)
        {
            EmployeeIncidentModel model = new EmployeeIncidentModel();
            EmployeeIncidentBase employee = new EmployeeIncidentBase();
            employee.UserID = Convert.ToInt32(Session["UserID"]);
            EmployeeBase employeeBase = new EmployeeBase();
            EmployeeModel employeeModel = new EmployeeModel();
            //employeeBase.EmpID = EmpId;
            //actionResult = employeeAction.Employees_Load(employeeBase);
            //if (actionResult.IsSuccess)
            //{
            //    DataRow dr = actionResult.dtResult.Rows[0];
            //    employeeModel.LogoFirstName = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : "";
            //    employeeModel.LogoLastName = dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : "";
            //    employeeModel.LogoMiddleName = dr["MiddleName"] != DBNull.Value ? dr["MiddleName"].ToString() : "";
            //}
            //model.EmployeeModel = employeeModel;

            //employee.EmployeeId = EmpId;
            employee.ReportAccessRole = Convert.ToInt32(Session["RoleId"]);
            employee.AllReport = Convert.ToInt32(Session["ReportProofreadCheck"]);
            employee.EventId = EventId;
            //actionResult = employeeAction.EmployeeIncident_LoadByEmployeeID(employee);
            actionResult = employeeAction.Incidents_LoadAll(employee);

            //model.EmployeeId = EmpId;
            List<EmployeeIncidentModel> EmployeeIncidentList = new List<EmployeeIncidentModel>();
            if (actionResult.IsSuccess)
            {
                EmployeeIncidentList = (from DataRow row in actionResult.dtResult.Rows
                                        select new EmployeeIncidentModel
                                        {
                                            EmployeeId = row["EmployeeID"] != DBNull.Value ? Convert.ToInt32(row["EmployeeID"]) : 0,
                                            IncidentID = row["IncidentID"] != DBNull.Value ? Convert.ToInt32(row["IncidentID"]) : 0,
                                            IncidentNumber = row["IncidentNumber"] != DBNull.Value ? row["IncidentNumber"].ToString() : "",
                                            ShortDescriptionName = row["ShortDescriptorName"] != DBNull.Value ? row["ShortDescriptorName"].ToString() : "",
                                            Status = row["Status"] != DBNull.Value ? row["Status"].ToString() : "",
                                            ReportCreatorUser = row["ReportCreatorUser"] != DBNull.Value ? row["ReportCreatorUser"].ToString() : "",
                                            ImagePath = row["ImagePath"] != DBNull.Value ? row["ImagePath"].ToString() : "",
                                            DefaultImage = row["DefaultImage"] != DBNull.Value ? row["DefaultImage"].ToString() : "",
                                            //LinkWithReport = row["LinkWithReport"] != DBNull.Value ? Convert.ToBoolean(row["LinkWithReport"]) : false,
                                            //LinkEmployeeName = row["LinkEmployeeName"] != DBNull.Value ? row["LinkEmployeeName"].ToString() : "",
                                            //LinkByEmpID = row["LinkByEmpID"] != DBNull.Value ? Convert.ToInt32(row["LinkByEmpID"]) : 0,
                                            //LinkFile = row["LinkFile"] != DBNull.Value ? row["LinkFile"].ToString() : "",
                                            NatureOfIncident = row["noi"] != DBNull.Value ? row["noi"].ToString() : "",
                                            Description = row["textdesc"] != DBNull.Value ? row["textdesc"].ToString() : "",
                                            ReportCreateDate = row["CreatedDate"] != DBNull.Value ? row["CreatedDate"].ToString() : "",
                                            FirstName = row["FirstName"] != DBNull.Value ? row["FirstName"].ToString() : "",
                                            LastName = row["LastName"] != DBNull.Value ? row["LastName"].ToString() : "",
                                            isLinkedEvent = row["isLinkedEvent"].ToString() == "False" ? false : true,
                                        }).ToList();

            }
            model.EmployeeIncidentList = EmployeeIncidentList;
            return PartialView(model);

        }
        public ActionResult EmployeeIncidentList(int EmpId)
        {
            bool permission = (Session["Admin"] == null ? CIMS.Models.CheckPermissions.permissionMenu("Employee Incident Details", Convert.ToInt32(Session["UserId"])) : CIMS.Models.CheckAdminPermissions.permissionMenu("Employees"));
            if (!permission)
            {
                return Redirect("~/Home/NoPermission");
            }
            EmployeeIncidentModel model = new EmployeeIncidentModel();
            EmployeeIncidentBase employee = new EmployeeIncidentBase();
            employee.UserID = Convert.ToInt32(Session["UserID"]);

            EmployeeBase employeeBase = new EmployeeBase();
            EmployeeModel employeeModel = new EmployeeModel();
            employeeBase.EmpID = EmpId;
            actionResult = employeeAction.Employees_Load(employeeBase);
            if (actionResult.IsSuccess)
            {
                DataRow dr = actionResult.dtResult.Rows[0];
                employeeModel.LogoFirstName = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : "";
                employeeModel.LogoLastName = dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : "";
                employeeModel.LogoMiddleName = dr["MiddleName"] != DBNull.Value ? dr["MiddleName"].ToString() : "";
            }
            model.EmployeeModel = employeeModel;

            employee.EmployeeId = EmpId;
            employee.ReportAccessRole = Convert.ToInt32(Session["RoleId"]);
            employee.AllReport = Convert.ToInt32(Session["ReportProofreadCheck"]);
            actionResult = employeeAction.EmployeeIncident_LoadByEmployeeID(employee);

            model.EmployeeId = EmpId;
            List<EmployeeIncidentModel> EmployeeIncidentList = new List<EmployeeIncidentModel>();
            if (actionResult.IsSuccess)
            {
                EmployeeIncidentList = (from DataRow row in actionResult.dtResult.Rows
                                        select new EmployeeIncidentModel
                                        {
                                            IncidentID = row["IncidentID"] != DBNull.Value ? Convert.ToInt32(row["IncidentID"]) : 0,
                                            IncidentNumber = row["IncidentNumber"] != DBNull.Value ? row["IncidentNumber"].ToString() : "",
                                            ShortDescriptionName = row["ShortDescriptorName"] != DBNull.Value ? row["ShortDescriptorName"].ToString() : "",
                                            Status = row["Status"] != DBNull.Value ? row["Status"].ToString() : "",
                                            ReportCreatorUser = row["ReportCreatorUser"] != DBNull.Value ? row["ReportCreatorUser"].ToString() : "",
                                            ImagePath = row["ImagePath"] != DBNull.Value ? row["ImagePath"].ToString() : "",
                                            DefaultImage = row["DefaultImage"] != DBNull.Value ? row["DefaultImage"].ToString() : "",
                                            LinkWithReport = row["LinkWithReport"] != DBNull.Value ? Convert.ToBoolean(row["LinkWithReport"]) : false,
                                            LinkEmployeeName = row["LinkEmployeeName"] != DBNull.Value ? row["LinkEmployeeName"].ToString() : "",
                                            LinkByEmpID = row["LinkByEmpID"] != DBNull.Value ? Convert.ToInt32(row["LinkByEmpID"]) : 0,
                                            LinkFile = row["LinkFile"] != DBNull.Value ? row["LinkFile"].ToString() : "",
                                            NatureOfIncident = row["noi"] != DBNull.Value ? row["noi"].ToString() : "",
                                            Description = row["textdesc"] != DBNull.Value ? row["textdesc"].ToString() : "",
                                            ReportCreateDate = row["CreatedDate"] != DBNull.Value ? row["CreatedDate"].ToString() : "",
                                        }).ToList();

            }
            model.EmployeeIncidentList = EmployeeIncidentList;
            return View(model);
        }
        #endregion

        #region GetObservationByAuditType
        public JsonResult GetDisplayName_ByGame(int Game, int? IncidentId = 0)
        {
            EmployeeIncidentBase employee = new EmployeeIncidentBase();
            employee.Game = Game.ToString();
            employee.IncidentID = Convert.ToInt32(IncidentId);
            actionResult = employeeAction.GetDisplayName_ByGame(employee);

            List<SelectListItem> ObservationList = new List<SelectListItem>();
            if (actionResult.IsSuccess)
            {
                ObservationList = (from DataRow row in actionResult.dtResult.Rows
                                   select new SelectListItem
                                   {
                                       Text = row["DisplayName"] != DBNull.Value ? row["DisplayName"].ToString() : "",
                                       Value = row["DisplayName"] != DBNull.Value ? row["DisplayName"].ToString() : ""
                                   }).ToList();
            }
            return Json(ObservationList);
        }

        //public JsonResult GetObservation_ByAuditType(string AuditType, int? IncidentId = 0)
        //{
        //    EmployeeIncidentBase employee = new EmployeeIncidentBase();
        //    employee.AuditType = AuditType;
        //    employee.IncidentID = Convert.ToInt32(IncidentId);
        //    actionResult = employeeAction.GetObservation_ByAuditType(employee);

        //    List<SelectListItem> ObservationList = new List<SelectListItem>();
        //    if (actionResult.IsSuccess)
        //    {
        //        ObservationList = (from DataRow row in actionResult.dtResult.Rows
        //                           select new SelectListItem
        //                           {
        //                               Text = row["Observation"] != DBNull.Value ? row["Observation"].ToString() : "",
        //                               Value = row["Observation"] != DBNull.Value ? row["Observation"].ToString() : ""
        //                           }).ToList();
        //    }
        //    return Json(ObservationList);
        //}

        public JsonResult GetObservation_ByAuditType(int AuditID, int? IncidentId = 0)
        {
            EmployeeIncidentBase employee = new EmployeeIncidentBase();
            employee.AuditID = AuditID;
            employee.IncidentID = Convert.ToInt32(IncidentId);
            actionResult = employeeAction.GetObservation_ByAuditTypeNew(employee);

            List<SelectListItem> ObservationList = new List<SelectListItem>();
            if (actionResult.IsSuccess)
            {
                ObservationList = (from DataRow row in actionResult.dtResult.Rows
                                   select new SelectListItem
                                   {
                                       Text = row["Observation"] != DBNull.Value ? row["Observation"].ToString() : "",
                                       Value = row["Observation"] != DBNull.Value ? row["Observation"].ToString() : ""
                                   }).ToList();
            }
            return Json(ObservationList);
        }
        #endregion

        #region GetQuestionListByAudit
        //public PartialViewResult GetQuestionsByAudit(int IncidentId,string AuditType, int? Observation = 0)
        //{
        //    EmployeeIncidentBase employee = new EmployeeIncidentBase();
        //    employee.AuditType = AuditType;
        //    employee.Observation = Convert.ToInt32(Observation);
        //    employee.IncidentID = IncidentId;
        //    actionResult = employeeAction.GetQuestionList_ByAuditType(employee);
        //    EmployeeIncidentModel model = new EmployeeIncidentModel();
        //    List<QuestionList> QuestionList = new List<QuestionList>();
        //    List<SelectListItem> AnswerList = new List<SelectListItem>();
        //    AnswerList.Add(new SelectListItem { Text = "N/A", Value = "N/A" });
        //    AnswerList.Add(new SelectListItem { Text = "Yes", Value = "Yes" });
        //    AnswerList.Add(new SelectListItem { Text = "No", Value = "No" });

        //    ViewBag.AnswerList = AnswerList;
        //    if (actionResult.IsSuccess)
        //    {
        //        QuestionList = (from DataRow row in actionResult.dtResult.Rows
        //                        select new QuestionList
        //                        {
        //                            QuestionID = row["QuestionID"] != DBNull.Value ? Convert.ToInt32(row["QuestionID"]) : 0,
        //                            QuestionGroup = row["QuestionGroup"] != DBNull.Value ? row["QuestionGroup"].ToString() : "",
        //                            Question = row["Question"] != DBNull.Value ? row["Question"].ToString() : "",
        //                            AuditScore = row["AuditScore"] != DBNull.Value ? row["AuditScore"].ToString() : "",
        //                            AuditComment = row["AuditComment"] != DBNull.Value ? row["AuditComment"].ToString() : "",
        //                            ScoreType = row["ScoreType"] != DBNull.Value ? Convert.ToBoolean(row["ScoreType"]) : false,
        //                        }).ToList();
        //    }
        //    model.QuestionList = QuestionList.GroupBy(m => m.QuestionID).Select(m => m.First()).ToList();
        //    return PartialView(model);
        //}

        public PartialViewResult GetQuestionsByAudit(int IncidentId, int AuditID, int? Observation = 0)
        {
            EmployeeIncidentBase employee = new EmployeeIncidentBase();
            employee.AuditID = AuditID;
            employee.Observation = Convert.ToInt32(Observation);
            employee.IncidentID = IncidentId;
            actionResult = employeeAction.GetQuestionList_ByAuditTypeNew(employee);
            EmployeeIncidentModel model = new EmployeeIncidentModel();
            List<QuestionListNew> QuestionListNew = new List<QuestionListNew>();

            //            ViewBag.AnswerList = AnswerList;
            if (actionResult.IsSuccess)
            {
                //QuestionListNew = (from DataRow row in actionResult.dtResult.Rows
                //                select new QuestionListNew
                //                {
                //                    AuditID = row["AuditID"] != DBNull.Value ? Convert.ToInt32(row["AuditID"]) : 0,
                //                    QuestionID = row["QuestionID"] != DBNull.Value ? Convert.ToInt32(row["QuestionID"]) : 0,
                //                    Question = row["Question"] != DBNull.Value ? row["Question"].ToString() : "",
                //                    AnswerOrScore = row["AnswerOrScore"] != DBNull.Value ? row["AnswerOrScore"].ToString() : "",
                //                    Comment = row["Comment"] != DBNull.Value ? row["Comment"].ToString() : "",
                //                    QuestionType = row["QuestionType"] != DBNull.Value ? Convert.ToByte(row["QuestionType"]) : Convert.ToByte(0),
                //                }).ToList();

                foreach (DataRow row in actionResult.dtResult.Rows)
                {
                    QuestionListNew ql = new QuestionListNew();
                    ql.AuditID = row["AuditID"] != DBNull.Value ? Convert.ToInt32(row["AuditID"]) : 0;
                    ql.QuestionID = row["QuestionID"] != DBNull.Value ? Convert.ToInt32(row["QuestionID"]) : 0;
                    ql.Question = row["Question"] != DBNull.Value ? row["Question"].ToString() : "";
                    ql.AnswerOrScore = row["AnswerOrScore"] != DBNull.Value ? row["AnswerOrScore"].ToString() : "";
                    ql.Comment = row["Comment"] != DBNull.Value ? row["Comment"].ToString() : "";
                    ql.QuestionType = row["QuestionType"] != DBNull.Value ? Convert.ToByte(row["QuestionType"]) : Convert.ToByte(0);
                    //foreach (SelectListItem item in AnswerList)
                    //{
                    //    if (item.Value == ql.AnswerOrScore)
                    //    {
                    //        item.Selected = true;
                    //        break;
                    //    }
                    //}
                    if (ql.QuestionType == 1)
                    {
                        List<SelectListItem> AnswerList = new List<SelectListItem>();
                        AnswerList.Add(new SelectListItem { Text = "N/A", Value = "N/A" });
                        AnswerList.Add(new SelectListItem { Text = "Yes", Value = "Yes" });
                        AnswerList.Add(new SelectListItem { Text = "No", Value = "No" });
                        if (!string.IsNullOrEmpty(ql.AnswerOrScore))
                        {
                            SelectListItem selected = AnswerList.Where(x => x.Value == ql.AnswerOrScore).First();
                            selected.Selected = true;
                        }
                        else
                        {
                            SelectListItem selected = AnswerList.First();
                            selected.Selected = true;
                        }
                        ql.AnswerList = AnswerList;

                    }
                    QuestionListNew.Add(ql);
                }
            }
            //model.QuestionListNew = QuestionListNew.GroupBy(m => m.AuditID).Select(m => m.First()).ToList();
            model.QuestionListNew = QuestionListNew;
            return PartialView(model);
        }
        #endregion

        #region UpdateEmployeeAudit
        //[HttpPost]
        //[ValidateInput(false)]
        //public ActionResult EmployeeAudit(EmployeeIncidentModel model, FormCollection fc)
        //{
        //    //EmpNumber, Age, Sex, Race, LastName, FirstName, MiddleName, Height, Weight, StaffPosition, Eyes, Complexion, Build, Glasses, Restricted, RoleName, UD9

        //    EmployeeIncidentBase employee = new EmployeeIncidentBase();
        //    int Count = Convert.ToInt32(fc["hdnCount"]);
        //    if (Count > 0)
        //    {
        //        employee.IncidentID = model.IncidentID;
        //        for (int i = 0; i < Count; i++)
        //        {
        //            employee.QuestionId = Convert.ToInt32(fc["QuestionList[" + (i) + "].QuestionId"]);
        //            employee.AuditType = model.AuditType;
        //            employee.Observation = model.Observation;
        //            employee.AuditScore = fc["QuestionList[" + (i) + "].AuditScore"];
        //            employee.AuditComment = fc["QuestionList[" + (i) + "].AuditComment"];
        //            actionResult = employeeAction.IncidentAudit_IU(employee);
        //        }



        //    }




        //    return RedirectToAction("EmployeeIncident", new { Id = model.IncidentID, EmpId = model.EmployeeId });
        //}

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EmployeeAudit(EmployeeIncidentModel model, FormCollection fc)
        {
            //EmpNumber, Age, Sex, Race, LastName, FirstName, MiddleName, Height, Weight, StaffPosition, Eyes, Complexion, Build, Glasses, Restricted, RoleName, UD9

            EmployeeIncidentBase employee = new EmployeeIncidentBase();
            int Count = Convert.ToInt32(fc["hdnCount"]);
            if (Count > 0)
            {
                employee.IncidentID = model.IncidentID;
                for (int i = 0; i < Count; i++)
                {
                    employee.QuestionId = Convert.ToInt32(fc["QuestionListNew[" + (i) + "].QuestionId"]);
                    employee.AuditID = model.AuditID;
                    employee.Observation = model.Observation;
                    if (string.IsNullOrEmpty(fc["QuestionListNew[" + (i) + "].AnswerOrScore"]))
                        employee.AnswerOrScore = "";
                    else
                        employee.AnswerOrScore = Convert.ToString(fc["QuestionListNew[" + (i) + "].AnswerOrScore"]);
                    employee.Comment = fc["QuestionListNew[" + (i) + "].Comment"];
                    actionResult = employeeAction.IncidentAudit_IUNew(employee);
                }

            }

            return RedirectToAction("EmployeeIncident", new { Id = model.IncidentID, EmpId = model.EmployeeId });
        }
        #endregion


        #region DeleteIncidents
        public JsonResult DeleteIncidents(int ID, int EmpID, int RepID)
        {
            string jsonString = string.Empty;
            string jsonProofread = "false";
            string jsonDelete = "DeleteFalse";
            try
            {
                EmployeeBase employee = new EmployeeBase();
                employee.IncidentID = ID;

                EmployeeIncidentBase employeeIncidentBase = new EmployeeIncidentBase();
                employeeIncidentBase.EmployeeId = EmpID;
                employeeIncidentBase.IncidentID = RepID;
                if (Session["ReportProofreadCheck"].ToString() == "1")
                {
                    actionResult = employeeAction.EmployeeIncident_Delete(employee);
                    if (actionResult.IsSuccess)
                    {
                        jsonString = "success";
                    }
                    else
                    {
                        jsonString = "fail";
                    }
                }
                else
                {
                    actionResult = employeeAction.EmpReportProofread_Check(employeeIncidentBase);
                    if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                    {
                        jsonProofread = actionResult.dtResult.Rows[0]["ReportProofread"] != DBNull.Value ? actionResult.dtResult.Rows[0]["ReportProofread"].ToString() : "false";
                    }
                    if (jsonProofread.ToLower() == "false")
                    {
                        actionResult = employeeAction.EmployeeIncident_Edit(employee);
                        if (actionResult.IsSuccess)
                        {
                            jsonDelete = actionResult.dtResult.Rows[0]["ReportDelete"] != DBNull.Value ? actionResult.dtResult.Rows[0]["ReportDelete"].ToString() : "true";
                        }
                        if (jsonDelete.ToLower() == "true")
                        {
                            actionResult = employeeAction.EmployeeIncident_Delete(employee);

                            if (actionResult.IsSuccess)
                            {
                                jsonString = "success";
                            }
                            else
                            {
                                jsonString = "fail";
                            }
                        }
                        else
                        {
                            jsonString = "DeleteFalse";
                        }
                    }
                    else
                    {
                        jsonString = "ReportProfread";
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

        public JsonResult GetEmployeeList()
        {
            string jsonString = string.Empty;
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                EmployeeBase model = new EmployeeBase();
                model.UserID = Convert.ToInt32(Session["UserID"]);
                model.RoleID = Convert.ToInt32(Session["RoleId"]);
                // employee.UserID = Convert.ToInt32(Session["UserId"]);
                actionResult = employeeAction.Employee_LoadByUserID(model);
                if (actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += " <tr id=" + actionResult.dtResult.Rows[i]["EmployeeID"].ToString() + ">";
                        string name = Convert.ToString(actionResult.dtResult.Rows[i]["FirstName"]) + " " + Convert.ToString(actionResult.dtResult.Rows[i]["LastName"]);
                        jsonString += " <td  onclick = \"SelectUser('" + name + "','" + actionResult.dtResult.Rows[i]["EmployeeID"] + "'); \" >" + name + " </td> ";
                        jsonString += " </tr>";
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

        #region GetStates Get
        [HttpGet]
        public JsonResult GetStates(string ID)
        {
            DataTable dt = new DataTable();
            EmployeeBase employee = new EmployeeBase();
            List<SelectListItem> StatesList = new List<SelectListItem>();
            try
            {
                employee.CountryID = Convert.ToInt32(ID);
                actionResult = employeeAction.States_LoadByCountries(employee);

                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    StatesList = (from DataRow row in actionResult.dtResult.Rows
                                  select new SelectListItem
                                  {
                                      Text = row["StateName"] != DBNull.Value ? row["StateName"].ToString() : "",
                                      Value = row["ID"] != DBNull.Value ? row["ID"].ToString() : ""
                                  }).ToList();
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(StatesList, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region GetCities Get
        [HttpGet]
        public JsonResult GetCities(string ID)
        {
            DataTable dt = new DataTable();
            EmployeeBase employee = new EmployeeBase();
            List<SelectListItem> Cities = new List<SelectListItem>();
            try
            {
                employee.Status = ID;
                actionResult = employeeAction.Cities_LoadByStates(employee);

                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    Cities = (from DataRow row in actionResult.dtResult.Rows
                              select new SelectListItem
                              {
                                  Text = row["CityName"] != DBNull.Value ? row["CityName"].ToString() : "",
                                  Value = row["ID"] != DBNull.Value ? row["ID"].ToString() : ""
                              }).ToList();
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(Cities, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #region Employee Reports Access Permission
        [HttpPost]
        public JsonResult EmployeeReportsAccessPermission(int EmpId, int RepId, int UserId, int Id, string View, string Edit, string Delete)
        {
            EmployeeIncidentBase employeeIncidentBase = new EmployeeIncidentBase();

            string json = string.Empty;
            try
            {
                employeeIncidentBase.RepPerID = Id;
                employeeIncidentBase.EmployeeId = EmpId;
                employeeIncidentBase.IncidentID = RepId;
                employeeIncidentBase.ReportAccessBy = UserId;
                employeeIncidentBase.ReportView = Convert.ToBoolean(View);
                employeeIncidentBase.ReportEdit = Convert.ToBoolean(Edit);
                employeeIncidentBase.ReportDelete = Convert.ToBoolean(Delete);
                employeeIncidentBase.CreatedBy = Convert.ToInt32(Session["UserId"]);
                actionResult = employeeAction.EmpReportsAccessPermission_AddEdit(employeeIncidentBase);
                if (actionResult.IsSuccess)
                {
                    json = "success";
                }
                else
                {
                    json = "fail";
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

        #region ReportPermissionCheck Get
        public JsonResult ReportPermissionCheck(int EmpID, int RepID)
        {
            EmployeeIncidentModel EmployeeIncidentModel = new EmployeeIncidentModel();
            EmployeeIncidentBase employeeIncidentBase = new EmployeeIncidentBase();
            List<EmployeeIncidentModel> employeeIncidentList = new List<EmployeeIncidentModel>();

            string jsonString = string.Empty;
            string jsonProofread = "false";
            try
            {
                employeeIncidentBase.EmployeeId = EmpID;
                employeeIncidentBase.IncidentID = RepID;
                employeeIncidentBase.ReportAccessBy = Convert.ToInt32(Session["UserId"]);
                employeeIncidentBase.ReportAccessRole = Convert.ToInt32(Session["RoleId"]);

                actionResult = employeeAction.EmpReportProofread_Check(employeeIncidentBase);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    jsonProofread = actionResult.dtResult.Rows[0]["ReportProofread"] != DBNull.Value ? actionResult.dtResult.Rows[0]["ReportProofread"].ToString() : "false";
                }
                if (jsonProofread.ToLower() == "false")
                {
                    actionResult = employeeAction.ReportPermissionCheck_User(employeeIncidentBase);
                    if (actionResult.IsSuccess)
                    {
                        if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                        {
                            jsonString += actionResult.dtResult.Rows[0]["ViewReport"] != DBNull.Value ? actionResult.dtResult.Rows[0]["ViewReport"].ToString() : "false";
                            jsonString += ",";
                            jsonString += actionResult.dtResult.Rows[0]["EditReport"] != DBNull.Value ? actionResult.dtResult.Rows[0]["EditReport"].ToString() : "false";
                            jsonString += ",";
                            jsonString += actionResult.dtResult.Rows[0]["DeleteReport"] != DBNull.Value ? actionResult.dtResult.Rows[0]["DeleteReport"].ToString() : "false";
                        }

                        //employeeIncidentList = CommonMethods.ConvertTo<EmployeeIncidentModel>(actionResult.dtResult);
                        //if (employeeIncidentList.Count > 0)
                        //{
                        //    EmployeeIncidentModel = employeeIncidentList.FirstOrDefault();
                        //    EmployeeIncidentModel.ReportView = EmployeeIncidentModel.ReportView;
                        //    EmployeeIncidentModel.ReportEdit = EmployeeIncidentModel.ReportEdit;
                        //    EmployeeIncidentModel.ReportDelete = EmployeeIncidentModel.ReportDelete;
                        //}

                        //jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(EmployeeIncidentModel);
                    }
                }
                else
                {
                    jsonString = "ReportProfread";
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

        public JsonResult AdAsInvolved(string datacolumn, string EmployeeID, string IncidentID, string FetchDetailsBy)
        {
            string json = string.Empty;
            var InvolvedId = datacolumn.Split(',');

            foreach (var item in InvolvedId)
            {
                if (item != null && item != string.Empty)
                {
                    EmployeeIncidentBase employeeIncidentBase = new EmployeeIncidentBase();
                    employeeIncidentBase.IncidentID = Convert.ToInt32(IncidentID);
                    employeeIncidentBase.EmployeeId = Convert.ToInt32(EmployeeID);
                    employeeIncidentBase.InvolvedId = Convert.ToInt32(item);
                    employeeIncidentBase.FetchDetailsBy = FetchDetailsBy.Trim();
                    employeeIncidentBase.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    actionResult = employeeAction.EmployeeInvolve_I(employeeIncidentBase);
                }
            }

            if (actionResult.IsSuccess)
            {
                TempData["SuccessMessage"] = "";
            }
            else
            {
                TempData["ErrorMessage"] = "";
            }

            return Json(json, JsonRequestBehavior.AllowGet);

        }

        //public JsonResult AddEmployeeInvolvedbutton(string datacolumn, string SubjectID, string IncidentID)
        //{
        //    string json = string.Empty;
        //    var InvolvedId = datacolumn.Split(',');
        //    DataTable dt = new DataTable();

        //    dt.Columns.Add("InvolvedID");
        //    foreach (var item in InvolvedId)
        //    {
        //        if (item != null && item != string.Empty)
        //        {
        //            DataRow row;
        //            row = dt.NewRow();
        //            row["InvolvedID"] = item;
        //            dt.Rows.Add(row);
        //        }
        //    }
        //    SubjectInvolvedBase SubjectInvolvedBase = new SubjectInvolvedBase();


        //    SubjectInvolvedBase.IncidentID = Convert.ToInt32(IncidentID);
        //    SubjectInvolvedBase.SubjectID = Convert.ToInt32(SubjectID);
        //    SubjectInvolvedBase.IsEmployee = true;
        //    SubjectInvolvedBase.InvolveTable = dt;



        //    actionResult = subjectAction.SubjectInvolve_I(SubjectInvolvedBase);
        //    if (actionResult.IsSuccess)
        //    {
        //        //TempData["SuccessMessage"] = "Banned has been Saved Successfully";
        //    }
        //    else
        //    {
        //        //TempData["ErrorMessage"] = "Error in Saving record";
        //    }

        //    return Json(json, JsonRequestBehavior.AllowGet);

        //}


        #region Convert to Subject
        [HttpPost]
        public JsonResult ConvertEmployeeToSubject(string EmpId)
        {
            EmployeeBase employee = new EmployeeBase();
            string json = string.Empty;
            try
            {
                Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                employee.EmployeeID = Convert.ToInt32(EmpId);
                employee.SubjectVIP = unixTimestamp.ToString();
                employee.CreatedBy = Convert.ToInt32(Session["UserId"]);
                actionResult = employeeAction.ConvertEmployeeToSubject(employee);

                if (actionResult.IsSuccess)
                {
                    json = "success";
                }
                else
                {
                    json = "fail";
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #region AdvancedSearchEmployees

        [HttpGet]
        public ActionResult AdvancedSearchEmployees()
        {
            EmployeeModel model = new EmployeeModel();
            List<SelectListItem> genderList = new List<SelectListItem>();
            model.EmployeeLinkedList = new List<EmployeeLinkedList>();

            CIMS.ActionLayer.Setting.SettingAction settingAction = new CIMS.ActionLayer.Setting.SettingAction();

            actionResult = settingAction.MasterSex_Load();
            if (actionResult.IsSuccess)
            {
                genderList = (from DataRow row in actionResult.dtResult.Rows
                              select new SelectListItem
                              {
                                  Text = row["Sex"] != DBNull.Value ? row["Sex"].ToString() : "",
                                  Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                              }).ToList();
            }

            List<SelectListItem> raceList = new List<SelectListItem>();
            actionResult = settingAction.MasterRace_Load();
            if (actionResult.IsSuccess)
            {
                raceList = (from DataRow row in actionResult.dtResult.Rows
                            select new SelectListItem
                            {
                                Text = row["Race"] != DBNull.Value ? row["Race"].ToString() : "",
                                Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                            }).ToList();
            }

            List<SelectListItem> eyesStyleList = new List<SelectListItem>();
            actionResult = settingAction.MasterEyes_Load();
            if (actionResult.IsSuccess)
            {
                eyesStyleList = (from DataRow row in actionResult.dtResult.Rows
                                 select new SelectListItem
                                 {
                                     Text = row["Eyes"] != DBNull.Value ? row["Eyes"].ToString() : "",
                                     Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                 }).ToList();
            }

            List<SelectListItem> buildList = new List<SelectListItem>();
            actionResult = settingAction.Build_Load();
            if (actionResult.IsSuccess)
            {
                buildList = (from DataRow row in actionResult.dtResult.Rows
                             select new SelectListItem
                             {
                                 Text = row["Build"] != DBNull.Value ? row["Build"].ToString() : "",
                                 Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                             }).ToList();
            }


            List<SelectListItem> complexionList = new List<SelectListItem>();
            actionResult = settingAction.Complexion_Load();
            if (actionResult.IsSuccess)
            {
                complexionList = (from DataRow row in actionResult.dtResult.Rows
                                  select new SelectListItem
                                  {
                                      Text = row["Complexion"] != DBNull.Value ? row["Complexion"].ToString() : "",
                                      Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                  }).ToList();
            }

            CIMS.BaseLayer.Setting.SetMetricsBase setMetricsBase = new CIMS.BaseLayer.Setting.SetMetricsBase();
            setMetricsBase.Type = "Height";
            actionResult = settingAction.setmetrics_LoadBy(setMetricsBase);
            if (actionResult.IsSuccess)
            {
                for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                {
                    if (actionResult.dtResult.Rows[i]["ActiveMetrics"].ToString() == "True")
                    {
                        ViewBag.ActiveMetricsHeight = actionResult.dtResult.Rows[i]["metrics"].ToString();
                    }
                }
                if (ViewBag.ActiveMetricsHeight == null)
                {
                    ViewBag.ActiveMetricsHeight = "ft.";
                }
            }
            setMetricsBase.Type = "Weight";
            actionResult = settingAction.setmetrics_LoadBy(setMetricsBase);
            if (actionResult.IsSuccess)
            {
                for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                {
                    if (actionResult.dtResult.Rows[i]["ActiveMetrics"].ToString() == "True")
                    {
                        ViewBag.ActiveMetricsWeight = actionResult.dtResult.Rows[i]["metrics"].ToString();
                    }
                }
                if (ViewBag.ActiveMetricsWeight == null)
                {
                    ViewBag.ActiveMetricsWeight = "lbs";
                }
            }


            List<SelectListItem> glassesList = new List<SelectListItem>();
            glassesList.Add(new SelectListItem
            {
                Value = "No",
                Text = "No"
            });
            glassesList.Add(new SelectListItem
            {
                Value = "Yes",
                Text = "Yes"
            });
            ViewBag.GlassesList = glassesList;

            List<SelectListItem> empPositionList = new List<SelectListItem>();
            actionResult = settingAction.EmployeePosition_Load();
            if (actionResult.IsSuccess)
            {
                empPositionList = (from DataRow row in actionResult.dtResult.Rows
                                   select new SelectListItem
                                   {
                                       Text = row["Position"] != DBNull.Value ? row["Position"].ToString() : "",
                                       Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                   }).ToList();
            }
            ViewBag.EmployeePosition = empPositionList;

            ViewBag.BuildList = buildList;
            ViewBag.GenderList = genderList;
            ViewBag.RaceList = raceList;
            ViewBag.EyesStyleList = eyesStyleList;
            ViewBag.AverageList = complexionList;
            ViewBag.ComplexionList = complexionList;

            List<SelectListItem> DepartmentTypeList = new List<SelectListItem>();
            actionResult = employeeAction.MasterDepartmentType_Load();
            if (actionResult.IsSuccess)
            {
                DepartmentTypeList = (from DataRow row in actionResult.dtResult.Rows
                                      select new SelectListItem
                                      {
                                          Text = row["DepartmentType"] != DBNull.Value ? row["DepartmentType"].ToString() : "",
                                          Value = row["id"] != DBNull.Value ? row["id"].ToString() : ""
                                      }).ToList();
            }
            model.DepartmentTypeList = DepartmentTypeList;

            List<SelectListItem> LicenseTypeList = new List<SelectListItem>();
            actionResult = employeeAction.MasterLicenseType_Load();
            if (actionResult.IsSuccess)
            {
                LicenseTypeList = (from DataRow row in actionResult.dtResult.Rows
                                   select new SelectListItem
                                   {
                                       Text = row["LicenseType"] != DBNull.Value ? row["LicenseType"].ToString() : "",
                                       Value = row["id"] != DBNull.Value ? row["id"].ToString() : ""
                                   }).ToList();
            }
            model.LicenseTypeList = LicenseTypeList;

            List<SelectListItem> LicenseStatusList = new List<SelectListItem>();
            actionResult = employeeAction.MasterLicenseStatus_Load();
            if (actionResult.IsSuccess)
            {
                LicenseStatusList = (from DataRow row in actionResult.dtResult.Rows
                                     select new SelectListItem
                                     {
                                         Text = row["LicenseStatus"] != DBNull.Value ? row["LicenseStatus"].ToString() : "",
                                         Value = row["id"] != DBNull.Value ? row["id"].ToString() : ""
                                     }).ToList();
            }
            model.LicenseStatusList = LicenseStatusList;

            List<SelectListItem> AddressTypeList = new List<SelectListItem>();
            actionResult = employeeAction.MasterAddressType_Load();
            if (actionResult.IsSuccess)
            {
                AddressTypeList = (from DataRow row in actionResult.dtResult.Rows
                                   select new SelectListItem
                                   {
                                       Text = row["AddressType"] != DBNull.Value ? row["AddressType"].ToString() : "",
                                       Value = row["id"] != DBNull.Value ? row["id"].ToString() : ""
                                   }).ToList();
            }
            model.AddressTypeList = AddressTypeList;

            return View(model);
        }
        #endregion

        #region AdvancedSearchEmployees

        [HttpPost]
        public ActionResult AdvancedSearchEmployees(EmployeeModel model)
        {
            EmployeeBase employee = new EmployeeBase();
            employee.EmpNumber = model.EmpNumber;
            employee.FirstName = model.FirstName;
            employee.MiddleName = model.MiddleName;
            employee.LastName = model.LastName;
            employee.Sex = model.Sex;
            employee.Race = model.Race;
            employee.Complexion = model.Complexion;
            employee.Glasses = model.Glasses;
            employee.Build = model.Build;
            employee.Eyes = model.Eyes;

            actionResult = employeeAction.AdvancedSearchEmployees(employee);
            if (actionResult.IsSuccess)
            {
                List<EmployeeModel> employeeList = new List<EmployeeModel>();
                employeeList = (from DataRow row in actionResult.dtResult.Rows
                                select new EmployeeModel
                                {
                                    EmployeeID = row["EmployeeID"] != DBNull.Value ? Convert.ToInt32(row["EmployeeID"]) : 0,
                                    FilePath = row["FilePath"] != DBNull.Value ? Convert.ToString(row["FilePath"]) : null,
                                    EmpNumber = row["EmpNumber"] != DBNull.Value ? Convert.ToString(row["EmpNumber"]) : null,
                                    FirstName = row["FirstName"] != DBNull.Value ? row["FirstName"].ToString() : "",
                                    LastName = row["LastName"] != DBNull.Value ? row["LastName"].ToString() : "",
                                }).ToList();
                model.EmployeeList = employeeList;
            }


            List<SelectListItem> genderList = new List<SelectListItem>();
            model.EmployeeLinkedList = new List<EmployeeLinkedList>();

            CIMS.ActionLayer.Setting.SettingAction settingAction = new CIMS.ActionLayer.Setting.SettingAction();

            actionResult = settingAction.MasterSex_Load();
            if (actionResult.IsSuccess)
            {
                genderList = (from DataRow row in actionResult.dtResult.Rows
                              select new SelectListItem
                              {
                                  Text = row["Sex"] != DBNull.Value ? row["Sex"].ToString() : "",
                                  Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                              }).ToList();
            }

            List<SelectListItem> raceList = new List<SelectListItem>();
            actionResult = settingAction.MasterRace_Load();
            if (actionResult.IsSuccess)
            {
                raceList = (from DataRow row in actionResult.dtResult.Rows
                            select new SelectListItem
                            {
                                Text = row["Race"] != DBNull.Value ? row["Race"].ToString() : "",
                                Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                            }).ToList();
            }

            List<SelectListItem> eyesStyleList = new List<SelectListItem>();
            actionResult = settingAction.MasterEyes_Load();
            if (actionResult.IsSuccess)
            {
                eyesStyleList = (from DataRow row in actionResult.dtResult.Rows
                                 select new SelectListItem
                                 {
                                     Text = row["Eyes"] != DBNull.Value ? row["Eyes"].ToString() : "",
                                     Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                 }).ToList();
            }

            List<SelectListItem> buildList = new List<SelectListItem>();
            actionResult = settingAction.Build_Load();
            if (actionResult.IsSuccess)
            {
                buildList = (from DataRow row in actionResult.dtResult.Rows
                             select new SelectListItem
                             {
                                 Text = row["Build"] != DBNull.Value ? row["Build"].ToString() : "",
                                 Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                             }).ToList();
            }


            List<SelectListItem> complexionList = new List<SelectListItem>();
            actionResult = settingAction.Complexion_Load();
            if (actionResult.IsSuccess)
            {
                complexionList = (from DataRow row in actionResult.dtResult.Rows
                                  select new SelectListItem
                                  {
                                      Text = row["Complexion"] != DBNull.Value ? row["Complexion"].ToString() : "",
                                      Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                  }).ToList();
            }

            CIMS.BaseLayer.Setting.SetMetricsBase setMetricsBase = new CIMS.BaseLayer.Setting.SetMetricsBase();
            setMetricsBase.Type = "Height";
            actionResult = settingAction.setmetrics_LoadBy(setMetricsBase);
            if (actionResult.IsSuccess)
            {
                for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                {
                    if (actionResult.dtResult.Rows[i]["ActiveMetrics"].ToString() == "True")
                    {
                        ViewBag.ActiveMetricsHeight = actionResult.dtResult.Rows[i]["metrics"].ToString();
                    }
                }
                if (ViewBag.ActiveMetrics == null)
                {
                    ViewBag.ActiveMetricsHeight = "ft.";
                }
            }
            setMetricsBase.Type = "Weight";
            actionResult = settingAction.setmetrics_LoadBy(setMetricsBase);
            if (actionResult.IsSuccess)
            {
                for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                {
                    if (actionResult.dtResult.Rows[i]["ActiveMetrics"].ToString() == "True")
                    {
                        ViewBag.ActiveMetricsWeight = actionResult.dtResult.Rows[i]["metrics"].ToString();
                    }
                }
                if (ViewBag.ActiveMetrics == null)
                {
                    ViewBag.ActiveMetricsWeight = "lbs";
                }
            }


            List<SelectListItem> glassesList = new List<SelectListItem>();
            glassesList.Add(new SelectListItem
            {
                Value = "No",
                Text = "No"
            });
            glassesList.Add(new SelectListItem
            {
                Value = "Yes",
                Text = "Yes"
            });
            ViewBag.GlassesList = glassesList;

            List<SelectListItem> empPositionList = new List<SelectListItem>();
            actionResult = settingAction.EmployeePosition_Load();
            if (actionResult.IsSuccess)
            {
                empPositionList = (from DataRow row in actionResult.dtResult.Rows
                                   select new SelectListItem
                                   {
                                       Text = row["Position"] != DBNull.Value ? row["Position"].ToString() : "",
                                       Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                   }).ToList();
            }
            ViewBag.EmployeePosition = empPositionList;

            ViewBag.BuildList = buildList;
            ViewBag.GenderList = genderList;
            ViewBag.RaceList = raceList;
            ViewBag.EyesStyleList = eyesStyleList;
            ViewBag.AverageList = complexionList;
            ViewBag.ComplexionList = complexionList;

            List<SelectListItem> DepartmentTypeList = new List<SelectListItem>();
            actionResult = employeeAction.MasterDepartmentType_Load();
            if (actionResult.IsSuccess)
            {
                DepartmentTypeList = (from DataRow row in actionResult.dtResult.Rows
                                      select new SelectListItem
                                      {
                                          Text = row["DepartmentType"] != DBNull.Value ? row["DepartmentType"].ToString() : "",
                                          Value = row["id"] != DBNull.Value ? row["id"].ToString() : ""
                                      }).ToList();
            }
            model.DepartmentTypeList = DepartmentTypeList;

            List<SelectListItem> LicenseTypeList = new List<SelectListItem>();
            actionResult = employeeAction.MasterLicenseType_Load();
            if (actionResult.IsSuccess)
            {
                LicenseTypeList = (from DataRow row in actionResult.dtResult.Rows
                                   select new SelectListItem
                                   {
                                       Text = row["LicenseType"] != DBNull.Value ? row["LicenseType"].ToString() : "",
                                       Value = row["id"] != DBNull.Value ? row["id"].ToString() : ""
                                   }).ToList();
            }
            model.LicenseTypeList = LicenseTypeList;

            List<SelectListItem> LicenseStatusList = new List<SelectListItem>();
            actionResult = employeeAction.MasterLicenseStatus_Load();
            if (actionResult.IsSuccess)
            {
                LicenseStatusList = (from DataRow row in actionResult.dtResult.Rows
                                     select new SelectListItem
                                     {
                                         Text = row["LicenseStatus"] != DBNull.Value ? row["LicenseStatus"].ToString() : "",
                                         Value = row["id"] != DBNull.Value ? row["id"].ToString() : ""
                                     }).ToList();
            }
            model.LicenseStatusList = LicenseStatusList;

            List<SelectListItem> AddressTypeList = new List<SelectListItem>();
            actionResult = employeeAction.MasterAddressType_Load();
            if (actionResult.IsSuccess)
            {
                AddressTypeList = (from DataRow row in actionResult.dtResult.Rows
                                   select new SelectListItem
                                   {
                                       Text = row["AddressType"] != DBNull.Value ? row["AddressType"].ToString() : "",
                                       Value = row["id"] != DBNull.Value ? row["id"].ToString() : ""
                                   }).ToList();
            }
            model.AddressTypeList = AddressTypeList;

            return View(model);
        }

        [HttpPost]
        public ActionResult EmployeesSearch(EmployeeModel model, string searchtype, string Radio1, string Phone)
        {
            EmployeeBase employee = new EmployeeBase();
            DataTable dt = new DataTable();

            if (searchtype == "employee")
            {
                employee.EmpNumber = model.EmpNumber;
                employee.FirstName = model.FirstName;
                employee.MiddleName = model.MiddleName;
                employee.LastName = model.LastName;
                employee.Sex = model.Sex;
                employee.Race = model.Race;
                employee.Complexion = model.Complexion;
                employee.Glasses = model.Glasses;
                employee.Build = model.Build;
                employee.Eyes = model.Eyes;

                //
                employee.StaffPosition = model.StaffPosition;
                employee.Height = model.Height;
                employee.Weight = model.Weight;

                actionResult = employeeAction.AdvancedSearchEmployees(employee);

            }

            //AB
            if (searchtype == "employeelist")
            {
                employee.EmpNumber = model.EmpNumber;
                employee.FirstName = model.FirstName;
                employee.MiddleName = model.MiddleName;
                employee.LastName = model.LastName;
                employee.Sex = model.Sex;
                employee.Race = model.Race;
                employee.Complexion = model.Complexion;
                employee.Glasses = model.Glasses;
                employee.Build = model.Build;
                employee.Eyes = model.Eyes;

                //
                employee.StaffPosition = model.StaffPosition;
                employee.Height = model.Height;
                employee.Weight = model.Weight;

                actionResult = employeeAction.AdvancedSearchEmployees(employee);
                TempData["EmployeeList"] = actionResult;
                return RedirectToAction("EmployeeList");


            }

            if (searchtype == "adress")
            {
                dt = SearchAddress(model.AddressType, model.Apartment, model.Address, Radio1, model.City, model.ProvState, model.PostalZip, Phone);

                if (dt != null)
                {
                    actionResult.IsSuccess = true;
                }
            }

            if (searchtype == "licence")
            {
                dt = SearchLicense(model.DateOfHire, model.TerminationDate, model.LicenseExpirationDate, model.Department, model.LicenseType, model.LicenseStatus);

                if (dt != null)
                {
                    actionResult.IsSuccess = true;
                }
            }

            if (actionResult.IsSuccess)
            {
                List<EmployeeModel> employeeList = new List<EmployeeModel>();
                employeeList = (from DataRow row in actionResult.dtResult.Rows
                                select new EmployeeModel
                                {
                                    EmployeeID = row["EmployeeID"] != DBNull.Value ? Convert.ToInt32(row["EmployeeID"]) : 0,
                                    FilePath = row["FilePath"] != DBNull.Value ? Convert.ToString(row["FilePath"]) : null,
                                    EmpNumber = row["EmpNumber"] != DBNull.Value ? Convert.ToString(row["EmpNumber"]) : null,
                                    FirstName = row["FirstName"] != DBNull.Value ? row["FirstName"].ToString() : "",
                                    LastName = row["LastName"] != DBNull.Value ? row["LastName"].ToString() : "",
                                    CreatedDate = row["CreatedDate"] != DBNull.Value ? row["CreatedDate"].ToString() : "",
                                }).ToList();
                model.EmployeeList = employeeList;
            }

            List<SelectListItem> genderList = new List<SelectListItem>();
            model.EmployeeLinkedList = new List<EmployeeLinkedList>();

            CIMS.ActionLayer.Setting.SettingAction settingAction = new CIMS.ActionLayer.Setting.SettingAction();

            actionResult = settingAction.MasterSex_Load();
            if (actionResult.IsSuccess)
            {
                genderList = (from DataRow row in actionResult.dtResult.Rows
                              select new SelectListItem
                              {
                                  Text = row["Sex"] != DBNull.Value ? row["Sex"].ToString() : "",
                                  Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                              }).ToList();
            }

            List<SelectListItem> raceList = new List<SelectListItem>();
            actionResult = settingAction.MasterRace_Load();
            if (actionResult.IsSuccess)
            {
                raceList = (from DataRow row in actionResult.dtResult.Rows
                            select new SelectListItem
                            {
                                Text = row["Race"] != DBNull.Value ? row["Race"].ToString() : "",
                                Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                            }).ToList();
            }

            List<SelectListItem> eyesStyleList = new List<SelectListItem>();
            actionResult = settingAction.MasterEyes_Load();
            if (actionResult.IsSuccess)
            {
                eyesStyleList = (from DataRow row in actionResult.dtResult.Rows
                                 select new SelectListItem
                                 {
                                     Text = row["Eyes"] != DBNull.Value ? row["Eyes"].ToString() : "",
                                     Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                 }).ToList();
            }

            List<SelectListItem> buildList = new List<SelectListItem>();
            actionResult = settingAction.Build_Load();
            if (actionResult.IsSuccess)
            {
                buildList = (from DataRow row in actionResult.dtResult.Rows
                             select new SelectListItem
                             {
                                 Text = row["Build"] != DBNull.Value ? row["Build"].ToString() : "",
                                 Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                             }).ToList();
            }


            List<SelectListItem> complexionList = new List<SelectListItem>();
            actionResult = settingAction.Complexion_Load();
            if (actionResult.IsSuccess)
            {
                complexionList = (from DataRow row in actionResult.dtResult.Rows
                                  select new SelectListItem
                                  {
                                      Text = row["Complexion"] != DBNull.Value ? row["Complexion"].ToString() : "",
                                      Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                  }).ToList();
            }

            CIMS.BaseLayer.Setting.SetMetricsBase setMetricsBase = new CIMS.BaseLayer.Setting.SetMetricsBase();
            setMetricsBase.Type = "Height";
            actionResult = settingAction.setmetrics_LoadBy(setMetricsBase);
            if (actionResult.IsSuccess)
            {
                for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                {
                    if (actionResult.dtResult.Rows[i]["ActiveMetrics"].ToString() == "True")
                    {
                        ViewBag.ActiveMetricsHeight = actionResult.dtResult.Rows[i]["metrics"].ToString();
                    }
                }
                if (ViewBag.ActiveMetrics == null)
                {
                    ViewBag.ActiveMetricsHeight = "ft.";
                }
            }
            setMetricsBase.Type = "Weight";
            actionResult = settingAction.setmetrics_LoadBy(setMetricsBase);
            if (actionResult.IsSuccess)
            {
                for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                {
                    if (actionResult.dtResult.Rows[i]["ActiveMetrics"].ToString() == "True")
                    {
                        ViewBag.ActiveMetricsWeight = actionResult.dtResult.Rows[i]["metrics"].ToString();
                    }
                }
                if (ViewBag.ActiveMetrics == null)
                {
                    ViewBag.ActiveMetricsWeight = "lbs";
                }
            }


            List<SelectListItem> glassesList = new List<SelectListItem>();
            glassesList.Add(new SelectListItem
            {
                Value = "No",
                Text = "No"
            });
            glassesList.Add(new SelectListItem
            {
                Value = "Yes",
                Text = "Yes"
            });
            ViewBag.GlassesList = glassesList;

            List<SelectListItem> empPositionList = new List<SelectListItem>();
            actionResult = settingAction.EmployeePosition_Load();
            if (actionResult.IsSuccess)
            {
                empPositionList = (from DataRow row in actionResult.dtResult.Rows
                                   select new SelectListItem
                                   {
                                       Text = row["Position"] != DBNull.Value ? row["Position"].ToString() : "",
                                       Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                   }).ToList();
            }
            ViewBag.EmployeePosition = empPositionList;

            ViewBag.BuildList = buildList;
            ViewBag.GenderList = genderList;
            ViewBag.RaceList = raceList;
            ViewBag.EyesStyleList = eyesStyleList;
            ViewBag.AverageList = complexionList;
            ViewBag.ComplexionList = complexionList;

            List<SelectListItem> DepartmentTypeList = new List<SelectListItem>();
            actionResult = employeeAction.MasterDepartmentType_Load();
            if (actionResult.IsSuccess)
            {
                DepartmentTypeList = (from DataRow row in actionResult.dtResult.Rows
                                      select new SelectListItem
                                      {
                                          Text = row["DepartmentType"] != DBNull.Value ? row["DepartmentType"].ToString() : "",
                                          Value = row["id"] != DBNull.Value ? row["id"].ToString() : ""
                                      }).ToList();
            }
            model.DepartmentTypeList = DepartmentTypeList;

            List<SelectListItem> LicenseTypeList = new List<SelectListItem>();
            actionResult = employeeAction.MasterLicenseType_Load();
            if (actionResult.IsSuccess)
            {
                LicenseTypeList = (from DataRow row in actionResult.dtResult.Rows
                                   select new SelectListItem
                                   {
                                       Text = row["LicenseType"] != DBNull.Value ? row["LicenseType"].ToString() : "",
                                       Value = row["id"] != DBNull.Value ? row["id"].ToString() : ""
                                   }).ToList();
            }
            model.LicenseTypeList = LicenseTypeList;

            List<SelectListItem> LicenseStatusList = new List<SelectListItem>();
            actionResult = employeeAction.MasterLicenseStatus_Load();
            if (actionResult.IsSuccess)
            {
                LicenseStatusList = (from DataRow row in actionResult.dtResult.Rows
                                     select new SelectListItem
                                     {
                                         Text = row["LicenseStatus"] != DBNull.Value ? row["LicenseStatus"].ToString() : "",
                                         Value = row["id"] != DBNull.Value ? row["id"].ToString() : ""
                                     }).ToList();
            }
            model.LicenseStatusList = LicenseStatusList;

            List<SelectListItem> AddressTypeList = new List<SelectListItem>();
            actionResult = employeeAction.MasterAddressType_Load();
            if (actionResult.IsSuccess)
            {
                AddressTypeList = (from DataRow row in actionResult.dtResult.Rows
                                   select new SelectListItem
                                   {
                                       Text = row["AddressType"] != DBNull.Value ? row["AddressType"].ToString() : "",
                                       Value = row["id"] != DBNull.Value ? row["id"].ToString() : ""
                                   }).ToList();
            }
            model.AddressTypeList = AddressTypeList;

            return View(model);
        }
        #endregion

        #region Bind Users List Reports for Access
        public JsonResult UsersListReportsAccess(int ReportID)
        {
            string jsonString = string.Empty;
            try
            {
                EmployeeIncidentBase incidentBase = new EmployeeIncidentBase();
                incidentBase.UserID = Convert.ToInt32(Session["UserID"]);
                incidentBase.IncidentID = ReportID;
                actionResult = employeeAction.UsersReportsAccess_Bind(incidentBase);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += " <option value = " + actionResult.dtResult.Rows[i]["UserID"] + " > " + actionResult.dtResult.Rows[i]["FullName"] + " - " + actionResult.dtResult.Rows[i]["UserName"] + " </ option >";
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

        #region Add Add UsersReports Access
        [HttpPost]
        public JsonResult AddUsersReportsAccess(string UserID, int EmployeeID, int ReportID)
        {
            string json = string.Empty;
            try
            {
                if (UserID.Length > 0)
                {
                    string[] UserIDList = UserID.Split(',');
                    for (int i = 0; i <= UserIDList.Length - 1; i++)
                    {
                        EmployeeIncidentBase incidentBase = new EmployeeIncidentBase();

                        incidentBase.ReportAccessBy = Convert.ToInt32(UserIDList[i]);
                        incidentBase.EmployeeId = EmployeeID;
                        incidentBase.IncidentID = ReportID;
                        incidentBase.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        actionResult = employeeAction.AddUsersReportsAccess(incidentBase);
                    }
                }

                if (actionResult.IsSuccess)
                {
                    json = "success";
                }
                else
                {
                    json = "fail";
                }

            }
            catch (Exception ex)
            {
                json = "-1";
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public bool AddALLUsersRolesReportsAccess(int EmployeeID, int ReportID)
        {
            try
            {
                EmployeeIncidentBase incidentBase = new EmployeeIncidentBase();
                incidentBase.EmployeeId = EmployeeID;
                incidentBase.IncidentID = ReportID;
                incidentBase.CreatedBy = Convert.ToInt32(Session["UserID"]);
                actionResult = employeeAction.AddAll_UsersAndRoles_SubReportsAccess(incidentBase);
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
                return false;
            }
            return actionResult.IsSuccess;
        }

        #endregion

        #region Remove UsersReports Access 
        [HttpPost]
        public JsonResult RemoveUsersReportsAccess(string ID)
        {
            string json = string.Empty;
            try
            {
                if (ID.Length > 0)
                {
                    string[] UserIDList = ID.Split(',');
                    for (int i = 0; i <= UserIDList.Length - 1; i++)
                    {
                        EmployeeIncidentBase incidentBase = new EmployeeIncidentBase();
                        incidentBase.ReportAccessID = Convert.ToInt32(UserIDList[i]);
                        actionResult = employeeAction.RemoveUsersReportsAccess(incidentBase);
                    }
                }
                if (actionResult.IsSuccess)
                {
                    json = "success";
                }
                else
                {
                    json = "fail";
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

        #region Bind ReportsAccess Users
        public JsonResult ReportsAccessUsers_Bind(int ReportID)
        {
            string jsonString = string.Empty;
            try
            {
                EmployeeIncidentBase incidentBase = new EmployeeIncidentBase();
                incidentBase.UserID = Convert.ToInt32(Session["UserID"]);
                incidentBase.IncidentID = ReportID;
                actionResult = employeeAction.ReportsAccessUsers_Bind(incidentBase);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += " <option value = " + actionResult.dtResult.Rows[i]["ID"] + "  onclick = \"ReportsAccessPermission('" + actionResult.dtResult.Rows[i]["ID"] + "',this); \"> " + actionResult.dtResult.Rows[i]["FullName"] + " - " + actionResult.dtResult.Rows[i]["UserName"] + " </ option >";
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

        #region Save Report Access Permission
        [HttpPost]
        public JsonResult EmpReportAccessPermission(int ID, int ReportID, string Type, string Permission)
        {
            string json = string.Empty;
            try
            {
                if (ID > 0)
                {
                    EmployeeIncidentBase incidentBase = new EmployeeIncidentBase();
                    incidentBase.ReportAccessID = Convert.ToInt32(ID);
                    incidentBase.IncidentID = ReportID;
                    incidentBase.ReportAccessType = Type;
                    incidentBase.ReportAccessPermission = Convert.ToBoolean(Permission);
                    actionResult = employeeAction.EmpReportAccessPermission(incidentBase);
                }
                if (actionResult.IsSuccess)
                {
                    json = "success";
                }
                else
                {
                    json = "fail";
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

        #region Bind ReportsAccess Permission ByUsers
        public JsonResult ReportsAccessPermission_ByUser(int ID, int ReportID)
        {
            string jsonString = string.Empty;
            try
            {
                EmployeeIncidentBase incidentBase = new EmployeeIncidentBase();
                incidentBase.ReportAccessID = ID;
                incidentBase.IncidentID = ReportID;
                actionResult = employeeAction.ReportsAccessPermission_ByUser(incidentBase);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    jsonString += actionResult.dtResult.Rows[0]["ViewReport"] != DBNull.Value ? actionResult.dtResult.Rows[0]["ViewReport"].ToString() : "false";
                    jsonString += ",";
                    jsonString += actionResult.dtResult.Rows[0]["EditReport"] != DBNull.Value ? actionResult.dtResult.Rows[0]["EditReport"].ToString() : "false";
                    jsonString += ",";
                    jsonString += actionResult.dtResult.Rows[0]["DeleteReport"] != DBNull.Value ? actionResult.dtResult.Rows[0]["DeleteReport"].ToString() : "false";
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

        #region Bind Users ReportsAccess Role
        public JsonResult UsersReportsAccessRole(int ReportID)
        {
            string jsonString = string.Empty;
            try
            {
                EmployeeIncidentBase incidentBase = new EmployeeIncidentBase();
                incidentBase.IncidentID = ReportID;
                actionResult = employeeAction.UsersReportsAccessRole(incidentBase);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += " <option value = " + actionResult.dtResult.Rows[i]["RoleId"] + " > " + actionResult.dtResult.Rows[i]["RoleName"] + " </ option >";
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

        #region Add Roles ReportsAccess
        [HttpPost]
        public JsonResult AddRolesReportsAccess(string RoleID, string EmployeeID, string ReportID)
        {
            string json = string.Empty;
            try
            {
                if (RoleID.Length > 0)
                {
                    string[] RoleIDList = RoleID.Split(',');
                    for (int i = 0; i <= RoleIDList.Length - 1; i++)
                    {
                        EmployeeIncidentBase incidentBase = new EmployeeIncidentBase();

                        incidentBase.ReportAccessRole = Convert.ToInt32(RoleIDList[i]);
                        incidentBase.EmployeeId = Convert.ToInt32(EmployeeID);
                        incidentBase.IncidentID = Convert.ToInt32(ReportID);
                        incidentBase.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        actionResult = employeeAction.AddRolesReportsAccess(incidentBase);
                    }
                }

                if (actionResult.IsSuccess)
                {
                    json = "success";
                }
                else
                {
                    json = "fail";
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

        #region Remove Roles ReportsAccess 
        [HttpPost]
        public JsonResult RemoveRolesReportsAccess(string ID)
        {
            string json = string.Empty;
            try
            {
                if (ID.Length > 0)
                {
                    string[] RoleIDList = ID.Split(',');
                    for (int i = 0; i <= RoleIDList.Length - 1; i++)
                    {
                        EmployeeIncidentBase incidentBase = new EmployeeIncidentBase();
                        incidentBase.ReportAccessID = Convert.ToInt32(RoleIDList[i]);
                        actionResult = employeeAction.RemoveRolesReportsAccess(incidentBase);
                    }
                }
                if (actionResult.IsSuccess)
                {
                    json = "success";
                }
                else
                {
                    json = "fail";
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

        #region Bind ReportsAccess Roles
        public JsonResult ReportsAccessRoles_Bind(int ReportID)
        {
            string jsonString = string.Empty;
            try
            {
                EmployeeIncidentBase incidentBase = new EmployeeIncidentBase();
                incidentBase.UserID = Convert.ToInt32(Session["UserID"]);
                incidentBase.IncidentID = ReportID;
                actionResult = employeeAction.ReportsAccessRoles_Bind(incidentBase);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += " <option value = " + actionResult.dtResult.Rows[i]["ID"] + "  onclick = \"ReportsAccessPermissionByRole('" + actionResult.dtResult.Rows[i]["ID"] + "',this); \"> " + actionResult.dtResult.Rows[i]["RoleName"] + " </ option >";
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

        #region Save Report Access Permission By Role
        [HttpPost]
        public JsonResult EmpReportAccessPermissionByRole(int ID, int ReportID, string Type, string Permission)
        {
            string json = string.Empty;
            try
            {
                if (ID > 0)
                {
                    EmployeeIncidentBase incidentBase = new EmployeeIncidentBase();
                    incidentBase.ReportAccessID = Convert.ToInt32(ID);
                    incidentBase.IncidentID = ReportID;
                    incidentBase.ReportAccessType = Type;
                    incidentBase.ReportAccessPermission = Convert.ToBoolean(Permission);
                    actionResult = employeeAction.EmpReportAccessPermissionByRole(incidentBase);
                }
                if (actionResult.IsSuccess)
                {
                    json = "success";
                }
                else
                {
                    json = "fail";
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

        #region Bind ReportsAccess Permission By Roles
        public JsonResult ReportsAccessPermission_ByRole(int ID, int ReportID)
        {
            string jsonString = string.Empty;
            try
            {
                EmployeeIncidentBase incidentBase = new EmployeeIncidentBase();
                incidentBase.ReportAccessID = ID;
                incidentBase.IncidentID = ReportID;
                actionResult = employeeAction.ReportsAccessPermission_ByRole(incidentBase);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    jsonString += actionResult.dtResult.Rows[0]["ViewReport"] != DBNull.Value ? actionResult.dtResult.Rows[0]["ViewReport"].ToString() : "false";
                    jsonString += ",";
                    jsonString += actionResult.dtResult.Rows[0]["EditReport"] != DBNull.Value ? actionResult.dtResult.Rows[0]["EditReport"].ToString() : "false";
                    jsonString += ",";
                    jsonString += actionResult.dtResult.Rows[0]["DeleteReport"] != DBNull.Value ? actionResult.dtResult.Rows[0]["DeleteReport"].ToString() : "false";
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

        #region EmployeeReportProofread
        [HttpPost]
        public ActionResult EmployeeReportProofread(EmployeeIncidentModel model)
        {
            EmployeeIncidentBase reportBase = new EmployeeIncidentBase();
            reportBase.ProofreadID = model.ProofreadID;
            reportBase.EmployeeId = model.EmployeeId;
            reportBase.IncidentID = model.IncidentID;
            reportBase.ReportProofread = model.ReportProofread;
            reportBase.UserID = Convert.ToInt32(Session["UserID"]);
            actionResult = employeeAction.EmpReportProofread_add(reportBase);

            if (actionResult.IsSuccess)
            {
                TempData["SuccessMessage"] = "Report Proofread has been Saved Successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Some error Occurred, please try again later.";
            }

            return RedirectToAction("EmployeeIncident", new { Id = model.IncidentID, EmpId = model.EmployeeId });
        }
        #endregion

        #region Save Report Access Permission By Admin
        [HttpPost]
        public JsonResult EmpReportCreatorPermission(int ReportID, string Type, string Permission)
        {
            string json = string.Empty;
            try
            {
                if (ReportID > 0)
                {
                    EmployeeIncidentBase incidentBase = new EmployeeIncidentBase();
                    incidentBase.IncidentID = ReportID;
                    incidentBase.ReportAccessType = Type;
                    incidentBase.ReportAccessPermission = Convert.ToBoolean(Permission);
                    actionResult = employeeAction.EmpReportCreatorPermission(incidentBase);
                }
                if (actionResult.IsSuccess)
                {
                    json = "success";
                }
                else
                {
                    json = "fail";
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

        #region EditIncidents
        public JsonResult EditIncidents(int ID, int EmpID, int RepID)
        {
            string jsonString = string.Empty;
            string jsonProofread = "false";
            try
            {
                EmployeeBase employee = new EmployeeBase();
                employee.IncidentID = ID;

                EmployeeIncidentBase employeeIncidentBase = new EmployeeIncidentBase();
                employeeIncidentBase.EmployeeId = EmpID;
                employeeIncidentBase.IncidentID = RepID;
                actionResult = employeeAction.EmpReportProofread_Check(employeeIncidentBase);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    jsonProofread = actionResult.dtResult.Rows[0]["ReportProofread"] != DBNull.Value ? actionResult.dtResult.Rows[0]["ReportProofread"].ToString() : "false";
                }
                if (jsonProofread.ToLower() == "false")
                {
                    actionResult = employeeAction.EmployeeIncident_Edit(employee);

                    if (actionResult.IsSuccess)
                    {
                        jsonString = actionResult.dtResult.Rows[0]["ReportEdit"] != DBNull.Value ? actionResult.dtResult.Rows[0]["ReportEdit"].ToString() : "true";
                    }
                    else
                    {
                        jsonString = "fail";
                    }
                }
                else
                {
                    jsonString = "ReportProfread";
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


        public ActionResult EmployeesSearch(int? Id = 0)
        {
            EmployeeModel model = new EmployeeModel();
            List<SelectListItem> genderList = new List<SelectListItem>();
            model.EmployeeLinkedList = new List<EmployeeLinkedList>();

            CIMS.ActionLayer.Setting.SettingAction settingAction = new CIMS.ActionLayer.Setting.SettingAction();

            actionResult = settingAction.MasterSex_Load();
            if (actionResult.IsSuccess)
            {
                genderList = (from DataRow row in actionResult.dtResult.Rows
                              select new SelectListItem
                              {
                                  Text = row["Sex"] != DBNull.Value ? row["Sex"].ToString() : "",
                                  Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                              }).ToList();
            }

            List<SelectListItem> raceList = new List<SelectListItem>();
            actionResult = settingAction.MasterRace_Load();
            if (actionResult.IsSuccess)
            {
                raceList = (from DataRow row in actionResult.dtResult.Rows
                            select new SelectListItem
                            {
                                Text = row["Race"] != DBNull.Value ? row["Race"].ToString() : "",
                                Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                            }).ToList();
            }

            List<SelectListItem> eyesStyleList = new List<SelectListItem>();
            actionResult = settingAction.MasterEyes_Load();
            if (actionResult.IsSuccess)
            {
                eyesStyleList = (from DataRow row in actionResult.dtResult.Rows
                                 select new SelectListItem
                                 {
                                     Text = row["Eyes"] != DBNull.Value ? row["Eyes"].ToString() : "",
                                     Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                 }).ToList();
            }

            List<SelectListItem> buildList = new List<SelectListItem>();
            actionResult = settingAction.Build_Load();
            if (actionResult.IsSuccess)
            {
                buildList = (from DataRow row in actionResult.dtResult.Rows
                             select new SelectListItem
                             {
                                 Text = row["Build"] != DBNull.Value ? row["Build"].ToString() : "",
                                 Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                             }).ToList();
            }


            List<SelectListItem> complexionList = new List<SelectListItem>();
            actionResult = settingAction.Complexion_Load();
            if (actionResult.IsSuccess)
            {
                complexionList = (from DataRow row in actionResult.dtResult.Rows
                                  select new SelectListItem
                                  {
                                      Text = row["Complexion"] != DBNull.Value ? row["Complexion"].ToString() : "",
                                      Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                  }).ToList();
            }

            CIMS.BaseLayer.Setting.SetMetricsBase setMetricsBase = new CIMS.BaseLayer.Setting.SetMetricsBase();
            setMetricsBase.Type = "Height";
            actionResult = settingAction.setmetrics_LoadBy(setMetricsBase);
            if (actionResult.IsSuccess)
            {
                for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                {
                    if (actionResult.dtResult.Rows[i]["ActiveMetrics"].ToString() == "True")
                    {
                        ViewBag.ActiveMetricsHeight = actionResult.dtResult.Rows[i]["metrics"].ToString();
                    }
                }
                if (ViewBag.ActiveMetricsHeight == null)
                {
                    ViewBag.ActiveMetricsHeight = "";
                }
            }
            setMetricsBase.Type = "Weight";
            actionResult = settingAction.setmetrics_LoadBy(setMetricsBase);
            if (actionResult.IsSuccess)
            {
                for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                {
                    if (actionResult.dtResult.Rows[i]["ActiveMetrics"].ToString() == "True")
                    {
                        ViewBag.ActiveMetricsWeight = actionResult.dtResult.Rows[i]["metrics"].ToString();
                    }
                }
                if (ViewBag.ActiveMetricsWeight == null)
                {
                    ViewBag.ActiveMetricsWeight = "";
                }
            }


            List<SelectListItem> glassesList = new List<SelectListItem>();
            glassesList.Add(new SelectListItem
            {
                Value = "No",
                Text = "No"
            });
            glassesList.Add(new SelectListItem
            {
                Value = "Yes",
                Text = "Yes"
            });
            ViewBag.GlassesList = glassesList;

            List<SelectListItem> empPositionList = new List<SelectListItem>();
            actionResult = settingAction.EmployeePosition_Load();
            if (actionResult.IsSuccess)
            {
                empPositionList = (from DataRow row in actionResult.dtResult.Rows
                                   select new SelectListItem
                                   {
                                       Text = row["Position"] != DBNull.Value ? row["Position"].ToString() : "",
                                       Value = row["Id"] != DBNull.Value ? row["Id"].ToString() : ""
                                   }).ToList();
            }
            ViewBag.EmployeePosition = empPositionList;

            ViewBag.BuildList = buildList;
            ViewBag.GenderList = genderList;
            ViewBag.RaceList = raceList;
            ViewBag.EyesStyleList = eyesStyleList;
            ViewBag.AverageList = complexionList;
            ViewBag.ComplexionList = complexionList;

            employee.EmpID = Id.Value;
            actionResult = employeeAction.Employees_Load(employee);

            if (Id > 0)
            {

                if (actionResult.IsSuccess)
                {
                    DataRow dr = actionResult.dtResult.Rows[0];
                    model.EmployeeID = dr["EmployeeID"] != DBNull.Value ? Convert.ToInt32(dr["EmployeeID"]) : 0;
                    model.EmpNumber = dr["EmpNumber"] != DBNull.Value ? dr["EmpNumber"].ToString() : "";
                    model.Age = dr["Age"] != DBNull.Value ? Convert.ToDecimal(dr["Age"]) : 0;
                    model.FirstName = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : "";
                    model.LastName = dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : "";
                    model.MiddleName = dr["MiddleName"] != DBNull.Value ? dr["MiddleName"].ToString() : "";
                    model.Sex = dr["Sex"] != DBNull.Value ? dr["Sex"].ToString() : "";
                    model.Race = dr["Race"] != DBNull.Value ? dr["Race"].ToString() : "";
                    model.Eyes = dr["Eyes"] != DBNull.Value ? dr["Eyes"].ToString() : "";
                    model.Build = dr["Build"] != DBNull.Value ? dr["Build"].ToString() : "";
                    model.Complexion = dr["Complexion"] != DBNull.Value ? dr["Complexion"].ToString() : "";
                    model.Height = dr["Height"] != DBNull.Value ? dr["Height"].ToString() : "";
                    model.Weight = dr["Weight"] != DBNull.Value ? dr["Weight"].ToString() : "";
                    model.StaffPosition = dr["StaffPosition"] != DBNull.Value ? dr["StaffPosition"].ToString() : "";
                    model.Glasses = dr["Glasses"] != DBNull.Value ? dr["Glasses"].ToString() : "";
                    model.ConvertSubject = dr["ConvertSubject"] != DBNull.Value ? Convert.ToBoolean(dr["ConvertSubject"]) : false;
                    if (dr["DateOfBirth"] != DBNull.Value)
                    {
                        model.DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"]);
                    }
                }
                employee.EmployeeID = model.EmployeeID;
                actionResult = employeeAction.EmployeePersonal_LoadByEmployeeID(employee);
                if (actionResult.IsSuccess)
                {
                    DataRow dr = actionResult.dtResult.Rows[0];
                    model.UD10 = dr["UD10"] != DBNull.Value ? dr["UD10"].ToString() : "";
                    model.UD11 = dr["UD11"] != DBNull.Value ? dr["UD11"].ToString() : "";
                    model.UD12 = dr["UD12"] != DBNull.Value ? dr["UD12"].ToString() : "";
                    model.UD13 = dr["UD13"] != DBNull.Value ? dr["UD13"].ToString() : "";
                    model.UD14 = dr["UD14"] != DBNull.Value ? dr["UD14"].ToString() : "";
                    model.UD15 = dr["UD15"] != DBNull.Value ? dr["UD15"].ToString() : "";
                    model.IDDefault1 = dr["IDDefault1"] != DBNull.Value ? Convert.ToBoolean(dr["IDDefault1"]) : false;
                    model.IDType1 = dr["IDType1"] != DBNull.Value ? dr["IDType1"].ToString() : "";
                    model.IDType2 = dr["IDType2"] != DBNull.Value ? dr["IDType2"].ToString() : "";
                    model.IDType3 = dr["IDType3"] != DBNull.Value ? dr["IDType3"].ToString() : "";
                    model.IDNumber1 = dr["IDNumber1"] != DBNull.Value ? dr["IDNumber1"].ToString() : "";
                    model.IDNumber2 = dr["IDNumber2"] != DBNull.Value ? dr["IDNumber2"].ToString() : "";
                    model.IDNumber3 = dr["IDNumber3"] != DBNull.Value ? dr["IDNumber3"].ToString() : "";
                    if (dr["DateOfBirth"] != DBNull.Value)
                    {
                        model.DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"]);
                        model.Day = Convert.ToDateTime(dr["DateOfBirth"]).Day.ToString();
                        model.Month = Convert.ToDateTime(dr["DateOfBirth"]).Month.ToString();
                        model.Year = Convert.ToDateTime(dr["DateOfBirth"]).Year.ToString();
                    }

                }
                employee.IncidentID = -1;
                actionResult = employeeAction.EmployeeLinked_LoadByEmployeeID(employee);
                List<EmployeeLinkedList> EmployeeLinkedList = new List<EmployeeLinkedList>();

                if (actionResult.IsSuccess)
                {
                    EmployeeLinkedList = (from DataRow row in actionResult.dtResult.Rows
                                          select new EmployeeLinkedList
                                          {
                                              Id = row["ID"] != DBNull.Value ? Convert.ToInt32(row["ID"]) : 0,
                                              FilePath = row["FilePath"] != DBNull.Value ? row["FilePath"].ToString() : "",
                                              Description = row["Description"] != DBNull.Value ? row["Description"].ToString() : "",

                                          }).ToList();

                }
                model.EmployeeLinkedList = EmployeeLinkedList;

            }
            else
            {
                //actionResult = employeeAction.EmployeeIDMax_Load();
                //if (actionResult.IsSuccess)
                //{
                //    model.EmpNumber = actionResult.dtResult.Rows[0][0] != DBNull.Value ? actionResult.dtResult.Rows[0][0].ToString() : " ";
                //}

                Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                model.EmpNumber = unixTimestamp.ToString();
            }

            List<SelectListItem> DepartmentTypeList = new List<SelectListItem>();
            actionResult = employeeAction.MasterDepartmentType_Load();
            if (actionResult.IsSuccess)
            {
                DepartmentTypeList = (from DataRow row in actionResult.dtResult.Rows
                                      select new SelectListItem
                                      {
                                          Text = row["DepartmentType"] != DBNull.Value ? row["DepartmentType"].ToString() : "",
                                          Value = row["id"] != DBNull.Value ? row["id"].ToString() : ""
                                      }).ToList();
            }
            model.DepartmentTypeList = DepartmentTypeList;

            List<SelectListItem> LicenseTypeList = new List<SelectListItem>();
            actionResult = employeeAction.MasterLicenseType_Load();
            if (actionResult.IsSuccess)
            {
                LicenseTypeList = (from DataRow row in actionResult.dtResult.Rows
                                   select new SelectListItem
                                   {
                                       Text = row["LicenseType"] != DBNull.Value ? row["LicenseType"].ToString() : "",
                                       Value = row["id"] != DBNull.Value ? row["id"].ToString() : ""
                                   }).ToList();
            }
            model.LicenseTypeList = LicenseTypeList;

            List<SelectListItem> LicenseStatusList = new List<SelectListItem>();
            actionResult = employeeAction.MasterLicenseStatus_Load();
            if (actionResult.IsSuccess)
            {
                LicenseStatusList = (from DataRow row in actionResult.dtResult.Rows
                                     select new SelectListItem
                                     {
                                         Text = row["LicenseStatus"] != DBNull.Value ? row["LicenseStatus"].ToString() : "",
                                         Value = row["id"] != DBNull.Value ? row["id"].ToString() : ""
                                     }).ToList();
            }
            model.LicenseStatusList = LicenseStatusList;

            List<SelectListItem> AddressTypeList = new List<SelectListItem>();
            actionResult = employeeAction.MasterAddressType_Load();
            if (actionResult.IsSuccess)
            {
                AddressTypeList = (from DataRow row in actionResult.dtResult.Rows
                                   select new SelectListItem
                                   {
                                       Text = row["AddressType"] != DBNull.Value ? row["AddressType"].ToString() : "",
                                       Value = row["id"] != DBNull.Value ? row["id"].ToString() : ""
                                   }).ToList();
            }
            model.AddressTypeList = AddressTypeList;

            return View(model);
        }

        public DataTable SearchAddress(string AddressType, string Apartment, string Address, string country, string city, string state, string zipCode, string phone)
        {

            string jsonString = string.Empty;
            try
            {

                actionResult = employeeAction.AdvancedSearchAddress(AddressType, Apartment, Address, country, city, state, zipCode, phone);

                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    return actionResult.dtResult;
                }
            }
            catch (Exception)
            {

            }

            return null;

        }

        public DataTable SearchLicense(string dateOfHire, string terminationDate, string licenseExpirationDate, string department, string licenseType, string licenseStatus)
        {

            string jsonString = string.Empty;
            try
            {
                // employee.EmpID = 1;
                actionResult = employeeAction.AdvancedSearchLicence(dateOfHire, terminationDate, licenseExpirationDate, department, licenseType, licenseStatus);

                if (actionResult.dtResult.Rows.Count > 0)
                {
                    return actionResult.dtResult;
                }
            }
            catch (Exception)
            {

            }

            return null;

        }

        //Ankur
        [HttpPost]
        public JsonResult FirstNameList(string Prefix)
        {
            actionResult = employeeAction.Employees_FirstNameSearch(Prefix);

            var FirstName = (from DataRow row in actionResult.dtResult.Rows
                             select new
                             {
                                 FirstName = row["FirstName"] != DBNull.Value ? row["FirstName"].ToString().ToUpper() : "",
                                 EmployeeID = row["EmployeeID"] != DBNull.Value ? row["EmployeeID"].ToString() : ""
                             }).ToList();


            return Json(FirstName, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SelectionList(string Prefix)
        {
            EmployeeBase employee = new EmployeeBase();

            employee.FirstName = Prefix;

            actionResult = employeeAction.AdvancedSearchEmployees(employee);

            string jsonString = string.Empty;


            if (actionResult.dtResult.Rows.Count > 0)
            {
                jsonString += "" + actionResult.dtResult.Rows[0]["FirstName"].ToString() + "/" + actionResult.dtResult.Rows[0]["LastName"].ToString() + "/" + actionResult.dtResult.Rows[0]["MiddleName"].ToString() + "/" + actionResult.dtResult.Rows[0]["EmpNumber"].ToString() + "/" + actionResult.dtResult.Rows[0]["sex"].ToString();

            }


            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }

        //Ankur
        [HttpPost]
        public JsonResult LastNameList(string Prefix, string FirstNameGet)
        {
            //Note : you can bind same list from database
            actionResult = employeeAction.Employees_LastNameSearch(FirstNameGet.Trim(), Prefix.Trim());

            var LastName = (from DataRow row in actionResult.dtResult.Rows
                            select new
                            {
                                LastName = row["LastName"] != DBNull.Value ? row["LastName"].ToString().ToUpper() : ""
                            }).ToList();


            //Searching records from list using LINQ query  

            return Json(LastName, JsonRequestBehavior.AllowGet);
        }


        #region Bind Users List Employee for Access
        public JsonResult UsersListEmployeeAccess(int EmployeeID)
        {
            string jsonString = string.Empty;
            try
            {
                EmployeeIncidentBase incidentBase = new EmployeeIncidentBase();
                incidentBase.UserID = Convert.ToInt32(Session["UserID"]);
                incidentBase.EmployeeId = EmployeeID;
                actionResult = employeeAction.UsersEmployeeAccess_Bind(incidentBase);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += " <option value = " + actionResult.dtResult.Rows[i]["UserID"] + " > " + actionResult.dtResult.Rows[i]["FullName"] + " - " + actionResult.dtResult.Rows[i]["UserName"] + " </ option >";
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

        #region Add Add UsersEmployee Access
        [HttpPost]
        public JsonResult AddUsersEmployeeAccess(string UserID, int EmployeeID)
        {
            string json = string.Empty;
            try
            {
                if (UserID.Length > 0)
                {
                    string[] UserIDList = UserID.Split(',');
                    for (int i = 0; i <= UserIDList.Length - 1; i++)
                    {
                        EmployeeIncidentBase incidentBase = new EmployeeIncidentBase();

                        incidentBase.ReportAccessBy = Convert.ToInt32(UserIDList[i]);
                        incidentBase.EmployeeId = EmployeeID;
                        incidentBase.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        actionResult = employeeAction.AddUsersEmployeeAccess(incidentBase);
                    }
                }

                if (actionResult.IsSuccess)
                {
                    json = "success";
                }
                else
                {
                    json = "fail";
                }

            }
            catch (Exception ex)
            {
                json = "-1";
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public bool AddALLUsersRolesEmployeeAccess(int EmployeeID)
        {
            try
            {
                EmployeeIncidentBase incidentBase = new EmployeeIncidentBase();
                incidentBase.EmployeeId = EmployeeID;
                incidentBase.CreatedBy = Convert.ToInt32(Session["UserID"]);
                actionResult = employeeAction.AddAll_UsersAndRoles_EmployeeAccess(incidentBase);
            }
            catch (Exception ex)
            {
                ErrorReporting.WebApplicationError(ex);
                return false;
            }
            return actionResult.IsSuccess;
        }

        #endregion

        #region Remove UsersEmployee Access 
        [HttpPost]
        public JsonResult RemoveUsersEmployeeAccess(string ID)
        {
            string json = string.Empty;
            try
            {
                if (ID.Length > 0)
                {
                    string[] UserIDList = ID.Split(',');
                    for (int i = 0; i <= UserIDList.Length - 1; i++)
                    {
                        EmployeeIncidentBase incidentBase = new EmployeeIncidentBase();
                        incidentBase.ReportAccessID = Convert.ToInt32(UserIDList[i]);
                        actionResult = employeeAction.RemoveUsersEmployeeAccess(incidentBase);
                    }
                }
                if (actionResult.IsSuccess)
                {
                    json = "success";
                }
                else
                {
                    json = "fail";
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

        #region Bind EmployeeAccess Users
        public JsonResult EmployeeAccessUsers_Bind(int EmployeeID)
        {
            string jsonString = string.Empty;
            try
            {
                EmployeeIncidentBase incidentBase = new EmployeeIncidentBase();
                incidentBase.UserID = Convert.ToInt32(Session["UserID"]);
                incidentBase.EmployeeId = EmployeeID;
                actionResult = employeeAction.EmployeeAccessUsers_Bind(incidentBase);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += " <option value = " + actionResult.dtResult.Rows[i]["ID"] + "  onclick = \"ReportsAccessPermission('" + actionResult.dtResult.Rows[i]["ID"] + "',this); \"> " + actionResult.dtResult.Rows[i]["FullName"] + " - " + actionResult.dtResult.Rows[i]["UserName"] + " </ option >";
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

        #region Save Employee Access Permission
        [HttpPost]
        public JsonResult EmployeeAccessPermission(int ID, int EmployeeID, string Type, string Permission)
        {
            string json = string.Empty;
            try
            {
                if (ID > 0)
                {
                    EmployeeIncidentBase incidentBase = new EmployeeIncidentBase();
                    incidentBase.ReportAccessID = Convert.ToInt32(ID);
                    incidentBase.EmployeeId = EmployeeID;
                    incidentBase.ReportAccessType = Type;
                    incidentBase.ReportAccessPermission = Convert.ToBoolean(Permission);
                    actionResult = employeeAction.EmployeeAccessPermission(incidentBase);
                }
                if (actionResult.IsSuccess)
                {
                    json = "success";
                }
                else
                {
                    json = "fail";
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

        #region Bind EmployeeAccess Permission ByUsers
        public JsonResult EmployeeAccessPermission_ByUser(int ID, int EmployeeID)
        {
            string jsonString = string.Empty;
            try
            {
                EmployeeIncidentBase incidentBase = new EmployeeIncidentBase();
                incidentBase.ReportAccessID = ID;
                incidentBase.EmployeeId = EmployeeID;
                actionResult = employeeAction.EmployeeAccessPermission_ByUser(incidentBase);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    jsonString += actionResult.dtResult.Rows[0]["ViewReport"] != DBNull.Value ? actionResult.dtResult.Rows[0]["ViewReport"].ToString() : "false";
                    jsonString += ",";
                    jsonString += actionResult.dtResult.Rows[0]["EditReport"] != DBNull.Value ? actionResult.dtResult.Rows[0]["EditReport"].ToString() : "false";
                    jsonString += ",";
                    jsonString += actionResult.dtResult.Rows[0]["DeleteReport"] != DBNull.Value ? actionResult.dtResult.Rows[0]["DeleteReport"].ToString() : "false";
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

        #region Bind Users EmployeeAccess Role
        public JsonResult UsersEmployeeAccessRole(int EmployeeID)
        {
            string jsonString = string.Empty;
            try
            {
                EmployeeIncidentBase incidentBase = new EmployeeIncidentBase();
                incidentBase.EmployeeId = EmployeeID;
                actionResult = employeeAction.UsersEmployeeAccessRole(incidentBase);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += " <option value = " + actionResult.dtResult.Rows[i]["RoleId"] + " > " + actionResult.dtResult.Rows[i]["RoleName"] + " </ option >";
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

        #region Add Roles EmployeeAccess
        [HttpPost]
        public JsonResult AddRolesEmployeeAccess(string RoleID, string EmployeeID)
        {
            string json = string.Empty;
            try
            {
                if (RoleID.Length > 0)
                {
                    string[] RoleIDList = RoleID.Split(',');
                    for (int i = 0; i <= RoleIDList.Length - 1; i++)
                    {
                        EmployeeIncidentBase incidentBase = new EmployeeIncidentBase();

                        incidentBase.ReportAccessRole = Convert.ToInt32(RoleIDList[i]);
                        incidentBase.EmployeeId = Convert.ToInt32(EmployeeID);
                        incidentBase.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        actionResult = employeeAction.AddRolesEmployeeAccess(incidentBase);
                    }
                }

                if (actionResult.IsSuccess)
                {
                    json = "success";
                }
                else
                {
                    json = "fail";
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

        #region Remove Roles EmployeeAccess 
        [HttpPost]
        public JsonResult RemoveRolesEmployeeAccess(string ID)
        {
            string json = string.Empty;
            try
            {
                if (ID.Length > 0)
                {
                    string[] RoleIDList = ID.Split(',');
                    for (int i = 0; i <= RoleIDList.Length - 1; i++)
                    {
                        EmployeeIncidentBase incidentBase = new EmployeeIncidentBase();
                        incidentBase.ReportAccessID = Convert.ToInt32(RoleIDList[i]);
                        actionResult = employeeAction.RemoveRolesEmployeeAccess(incidentBase);
                    }
                }
                if (actionResult.IsSuccess)
                {
                    json = "success";
                }
                else
                {
                    json = "fail";
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

        #region Bind EmployeeAccess Roles
        public JsonResult EmployeeAccessRoles_Bind(int EmployeeID)
        {
            string jsonString = string.Empty;
            try
            {
                EmployeeIncidentBase incidentBase = new EmployeeIncidentBase();
                incidentBase.UserID = Convert.ToInt32(Session["UserID"]);
                incidentBase.EmployeeId = EmployeeID;
                actionResult = employeeAction.EmployeeAccessRoles_Bind(incidentBase);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += " <option value = " + actionResult.dtResult.Rows[i]["ID"] + "  onclick = \"ReportsAccessPermissionByRole('" + actionResult.dtResult.Rows[i]["ID"] + "',this); \"> " + actionResult.dtResult.Rows[i]["RoleName"] + " </ option >";
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

        #region Save Employee Access Permission By Role
        [HttpPost]
        public JsonResult EmployeeAccessPermissionByRole(int ID, int EmployeeID, string Type, string Permission)
        {
            string json = string.Empty;
            try
            {
                if (ID > 0)
                {
                    EmployeeIncidentBase incidentBase = new EmployeeIncidentBase();
                    incidentBase.ReportAccessID = Convert.ToInt32(ID);
                    incidentBase.EmployeeId = EmployeeID;
                    incidentBase.ReportAccessType = Type;
                    incidentBase.ReportAccessPermission = Convert.ToBoolean(Permission);
                    actionResult = employeeAction.EmployeeAccessPermissionByRole(incidentBase);
                }
                if (actionResult.IsSuccess)
                {
                    json = "success";
                }
                else
                {
                    json = "fail";
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

        #region Bind EmployeeAccess Permission By Roles
        public JsonResult EmployeeAccessPermission_ByRole(int ID, int EmployeeID)
        {
            string jsonString = string.Empty;
            try
            {
                EmployeeIncidentBase incidentBase = new EmployeeIncidentBase();
                incidentBase.ReportAccessID = ID;
                incidentBase.EmployeeId = EmployeeID;
                actionResult = employeeAction.EmployeeAccessPermission_ByRole(incidentBase);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    jsonString += actionResult.dtResult.Rows[0]["ViewReport"] != DBNull.Value ? actionResult.dtResult.Rows[0]["ViewReport"].ToString() : "false";
                    jsonString += ",";
                    jsonString += actionResult.dtResult.Rows[0]["EditReport"] != DBNull.Value ? actionResult.dtResult.Rows[0]["EditReport"].ToString() : "false";
                    jsonString += ",";
                    jsonString += actionResult.dtResult.Rows[0]["DeleteReport"] != DBNull.Value ? actionResult.dtResult.Rows[0]["DeleteReport"].ToString() : "false";
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

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult LinkEvents(EmployeeReportEvents objs)
        {
            if (ModelState.IsValid)
            {
                //var customerid = repo.GetCurrentUserCustomerId(_webSecurity.CurrentUserId());
                //repo.ADDAdGroups(customerid, objs);
                actionResult = employeeAction.EmployeeReportEventsLink_Delete(objs.employeeid, objs.incidentid);
                if (objs.listeventid != null)
                {
                    foreach (var item in objs.listeventid)
                    {
                        if (item != 0)
                        {
                            eventemployeereport objreport = new eventemployeereport();
                            objreport.eventid = item;
                            objreport.incidentid = objs.incidentid;
                            objreport.employeeid = objs.employeeid;
                            actionResult = EventAction.Link_EmployeeReport(objreport);
                        }
                    }
                }
                if (actionResult.IsSuccess)
                {
                    return Json("Events updated successfully.");
                }

                return Json("Error occurred while linking events.");

            }
            else
            {
                return Json("Error occurred while linking events.");
            }
        }

        public PartialViewResult EventListLink(int EmployeeID, int IncidentID)
        {
            EventModel EventModel = new EventModel();
            List<EventModel> lstEventModel = new List<Models.EventModel>();
            EventBase model = new EventBase();
            model.UserID = Convert.ToString(Session["UserID"]);
            model.RoleID = Convert.ToInt32(Session["RoleId"]);
            model.EmployeeID = EmployeeID;
            model.IncidentID = IncidentID;

            actionResult = EventAction.EventEmployeeLink_Load(model);

            if (actionResult.IsSuccess)
            {
                lstEventModel = (from DataRow row in actionResult.dtResult.Rows
                                 select new EventModel
                                 {
                                     FilePath = row["FilePath"] != DBNull.Value ? Convert.ToString(row["FilePath"]) : null,
                                     EventID = row["EventID"] != DBNull.Value ? Convert.ToInt32(row["EventID"]) : 0,
                                     AttachedEvent = row["AttachedEvent"] != DBNull.Value ? Convert.ToInt32(row["AttachedEvent"]) : 0,
                                     EventNumber = row["EventNumber"] != DBNull.Value ? Convert.ToInt32(row["EventNumber"]) : 0,
                                     Camera = row["Camera"] != DBNull.Value ? row["Camera"].ToString() : "",
                                     DutyDesc = row["DutyDesc"] != DBNull.Value ? row["DutyDesc"].ToString() : "",
                                     EndTime = row["EndTime"] != DBNull.Value ? row["EndTime"].ToString() : "",
                                     EventDate = row["EventDate"] != DBNull.Value ? row["EventDate"].ToString() : "",
                                     UD21 = row["UD21"] != DBNull.Value ? row["UD21"].ToString() : "",
                                     EventTime = row["EventTime"] != DBNull.Value ? row["EventTime"].ToString() : "",
                                     FromCode = row["Initiated"] != DBNull.Value ? row["Initiated"].ToString() : "",
                                     FromForm = row["FromForm"] != DBNull.Value ? row["FromForm"].ToString() : "",
                                     FromNumber = row["FromNumber"] != DBNull.Value ? row["FromNumber"].ToString() : "",
                                     KeyEvent = row["KeyEvent"] != DBNull.Value ? Convert.ToBoolean(row["KeyEvent"]) : false,
                                     Location = row["Location"] != DBNull.Value ? row["Location"].ToString() : "",
                                     NatureCode = row["NatureOfCode"] != DBNull.Value ? row["NatureOfCode"].ToString() : "",
                                     NatureDesc = row["NatureDesc"] != DBNull.Value ? row["NatureDesc"].ToString() : "",
                                     RoleName = row["RoleName"] != DBNull.Value ? row["RoleName"].ToString() : "",
                                     Site = row["Site"] != DBNull.Value ? row["Site"].ToString() : "",
                                     UD20 = row["UD20"] != DBNull.Value ? row["UD20"].ToString() : "",
                                     UD22 = row["UD22"] != DBNull.Value ? row["UD22"].ToString() : "",
                                     UD23 = row["UD23"] != DBNull.Value ? row["UD23"].ToString() : "",
                                     UD24 = row["UD24"] != DBNull.Value ? row["UD24"].ToString() : "",
                                     UD25 = row["UD25"] != DBNull.Value ? row["UD25"].ToString() : "",
                                     UserID = row["UserID"] != DBNull.Value ? row["UserID"].ToString() : "",
                                     isLinkedEvent = row["isLinkedEvent"].ToString() == "False" ? false : true
                                 }).ToList();

            }
            EventModel.ListEventModel = lstEventModel;
            return PartialView(EventModel);
        }

    }
}