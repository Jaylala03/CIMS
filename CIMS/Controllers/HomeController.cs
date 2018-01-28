using CIMS.ActionLayer.Account;
using CIMS.ActionLayer.Admin;
using CIMS.BaseLayer.Admin;
using CIMS.Filters;
using CIMS.Helpers;
using CIMS.Models;
using CIMS.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CIMS.Controllers
{
    [CheckLogin]
    public class HomeController : Controller
    {
        AccountAction accountAction = new AccountAction();
        CIMS.BaseLayer.ActionResult actionResult = new CIMS.BaseLayer.ActionResult();
        RoleBase roleBase = new RoleBase();

        public ActionResult Index()
        {
            CIMS.ActionLayer.Employee.EmployeeAction employeeAction = new CIMS.ActionLayer.Employee.EmployeeAction();
            CIMS.BaseLayer.Employee.EmployeeBase employeeBase = new CIMS.BaseLayer.Employee.EmployeeBase();
            List<EmployeeModel> employeeList = new List<EmployeeModel>();
            EmployeeModel model = new EmployeeModel();
            employeeBase.UserID = Convert.ToInt32(Session["UserId"]);
            employeeBase.RoleID = Convert.ToInt32(Session["RoleId"]);
            actionResult = employeeAction.Employees_dashboard(employeeBase);
            if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
            {
                employeeList = (from DataRow row in actionResult.dtResult.Rows
                                select new EmployeeModel
                                {
                                    EmployeeID = row["EmployeeID"] != DBNull.Value ? Convert.ToInt32(row["EmployeeID"]) : 0,
                                    FirstName = row["FirstName"] != DBNull.Value ? row["FirstName"].ToString() : "",
                                    MiddleName = row["MiddleName"] != DBNull.Value ? row["MiddleName"].ToString() : "",
                                    LastName = row["LastName"] != DBNull.Value ? row["LastName"].ToString() : "",
                                    CreatedByUser = row["CreatedByUser"] != DBNull.Value ? row["CreatedByUser"].ToString() : "",
                                    CreatedDate = row["CreatedDate"] != DBNull.Value ? row["CreatedDate"].ToString() : "",
                                    TotalEmployees = row["TotalEmployees"] != DBNull.Value ? row["TotalEmployees"].ToString() : "",
                                    FilePath = row["FilePath"] != DBNull.Value ? Convert.ToString(row["FilePath"]) : null
                                }).ToList();
            }
            CIMS.ActionLayer.VisitorAction visitorAction = new CIMS.ActionLayer.VisitorAction();
            List<VisitorModel> visitorList = new List<VisitorModel>();
            VisitorModel visitorModel = new VisitorModel();

            actionResult = visitorAction.Visitor_dashboard();
            if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
            {
                visitorList = (from DataRow row in actionResult.dtResult.Rows
                               select new VisitorModel
                               {
                                   VisitorID = row["VisitorID"] != DBNull.Value ? Convert.ToInt32(row["VisitorID"]) : 0,
                                   VisitorName = row["VisitorName"] != DBNull.Value ? row["VisitorName"].ToString() : "",
                                   CreatedByUser = row["CreatedByUser"] != DBNull.Value ? row["CreatedByUser"].ToString() : "",
                                   CreatedDate = row["CreatedDate"] != DBNull.Value ? row["CreatedDate"].ToString() : "",
                                   TotalVisit = row["TotalVisit"] != DBNull.Value ? row["TotalVisit"].ToString() : "",
                                   ImagePath = row["ImagePath"] != DBNull.Value ? row["ImagePath"].ToString() : ""
                               }).ToList();
            }
            CIMS.ActionLayer.Subject.SubjectAction subjectAction = new CIMS.ActionLayer.Subject.SubjectAction();
            CIMS.BaseLayer.Subject.SubjectBase subjectBase = new CIMS.BaseLayer.Subject.SubjectBase();
            List<SubjectModel> subjectList = new List<SubjectModel>();
            SubjectModel subjectModel = new SubjectModel();

            subjectBase.CreatedBy = Convert.ToInt32(Session["UserId"]);
            subjectBase.RoleID = Convert.ToInt32(Session["RoleId"]);
            actionResult = subjectAction.Subject_dashboard(subjectBase);
            if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
            {
                subjectList = (from DataRow row in actionResult.dtResult.Rows
                               select new SubjectModel
                               {
                                   SubjectID = row["SubjectID"] != DBNull.Value ? Convert.ToInt32(row["SubjectID"]) : 0,
                                   FirstName = row["FirstName"] != DBNull.Value ? row["FirstName"].ToString() : "",
                                   MiddleName = row["MiddleName"] != DBNull.Value ? row["MiddleName"].ToString() : "",
                                   LastName = row["LastName"] != DBNull.Value ? row["LastName"].ToString() : "",
                                   CreatedByUser = row["CreatedByUser"] != DBNull.Value ? row["CreatedByUser"].ToString() : "",
                                   ModifiedDate = row["ModifiedDate"] != DBNull.Value ? row["ModifiedDate"].ToString() : "",
                                   TotalSubjects = row["TotalSubjects"] != DBNull.Value ? row["TotalSubjects"].ToString() : "",
                                   FilePath = row["FilePath"] != DBNull.Value ? Convert.ToString(row["FilePath"]) : null
                               }).ToList();
            }
            model.EmployeeList = employeeList;

            visitorModel.VisitorList = visitorList;
            model.visitorNewModel = visitorModel;

            subjectModel.SubjectList = subjectList;
            model.subjectNewModel = subjectModel;


            // dhaval

            DataTable dt = new DataTable();
            dt = getbackground("");

            if (dt.Rows.Count > 0 && dt.Rows[0]["Corporate_logo"].ToString().Length > 0)
            {
                ViewBag.Corporate_logo = dt.Rows[0]["Corporate_logo"].ToString();
            }
            else
            {
                ViewBag.Corporate_logo = "admin-logo.png";
            }

            if (dt.Rows.Count > 0 && dt.Rows[0]["Customer_logo"].ToString().Length > 0)
            {
                ViewBag.Customer_logo = dt.Rows[0]["Customer_logo"].ToString();
            }
            else
            {
                ViewBag.Customer_logo = "admin-logo.png";
            }

            if (dt.Rows.Count > 0 && dt.Rows[0]["Corporate_background"].ToString().Length > 0)
            {
                ViewBag.Corporate_background = dt.Rows[0]["Corporate_background"].ToString();

            }
            else
            {
                ViewBag.Corporate_background = "#f79646";
            }

            if (dt.Rows.Count > 0 && dt.Rows[0]["Corporate_back_type"].ToString().Length > 0)
            {
                ViewBag.Corporate_back_type = dt.Rows[0]["Corporate_back_type"].ToString();
            }
            else
            {
                ViewBag.Corporate_back_type = "palette";
            }


            // Employee

            var controller = "Employees";
            var controller1 = "Subject";

            int action = 0;
            bool status = false;

            int action1 = 0;
            bool status1 = false;

            if (Session["Admin"] != null)
            {
                int userId = Convert.ToInt32(Session["Admin"].ToString());
                string[] permission = CheckAdminPermissions.permission(controller, userId);


                if (permission != null)
                {
                    action = Convert.ToInt32(permission[1]);
                    status = Convert.ToBoolean(permission[0]);
                }

                permission = CheckAdminPermissions.permission(controller1, userId);


                if (permission != null)
                {
                    action1 = Convert.ToInt32(permission[1]);
                    status1 = Convert.ToBoolean(permission[0]);
                }

            }

            else if (Session["UserId"] != null)
            {
                int userId = Convert.ToInt32(Session["UserId"].ToString());
                string[] permission = CheckPermissions.permission(controller, userId);


                if (permission != null)
                {
                    action = Convert.ToInt32(permission[1]);
                    status = Convert.ToBoolean(permission[0]);
                }

                permission = CheckPermissions.permission(controller1, userId);


                if (permission != null)
                {
                    action1 = Convert.ToInt32(permission[1]);
                    status1 = Convert.ToBoolean(permission[0]);
                }

            }
            
            ViewBag.Action = action;
            ViewBag.Status = status;

            ViewBag.Action1 = action1;
            ViewBag.Status1 = status1;

            // Subject


            return View(model);
        }



        public DataTable getbackground(string name)
        {
            CorporateBase CorporateBase = new CorporateBase();
            AdminAction adminAction = new AdminAction();

            CorporateBase.Corporate_action = "get";

            actionResult = adminAction.Corporate_update(CorporateBase);

            return (actionResult.dtResult);
        }


        public JsonResult GetAction()
        {
            string jsonString = string.Empty;
            DataTable dt = new DataTable();
            dt = getbackground("");

            if (dt.Rows.Count > 0 && dt.Rows[0]["Corporate_logo"].ToString().Length > 0)
            {
                ViewBag.Corporate_logo = dt.Rows[0]["Corporate_logo"].ToString();
            }
            else
            {
                ViewBag.Corporate_logo = "admin-logo.png";
            }

            if (dt.Rows.Count > 0 && dt.Rows[0]["Customer_logo"].ToString().Length > 0)
            {
                ViewBag.Customer_logo = dt.Rows[0]["Customer_logo"].ToString();
            }
            else
            {
                ViewBag.Customer_logo = "";
            }

            if (dt.Rows.Count > 0 && dt.Rows[0]["Corporate_background"].ToString().Length > 0)
            {
                ViewBag.Corporate_background = dt.Rows[0]["Corporate_background"].ToString();

            }
            else
            {
                ViewBag.Corporate_background = "#f79646";
            }

            if (dt.Rows.Count > 0 && dt.Rows[0]["Corporate_back_type"].ToString().Length > 0)
            {
                ViewBag.Corporate_back_type = dt.Rows[0]["Corporate_back_type"].ToString();
            }
            else
            {
                ViewBag.Corporate_back_type = "palette";
            }

            jsonString = "" + ViewBag.Corporate_logo + "/" + ViewBag.Customer_logo + "/" + ViewBag.Corporate_background + "/" + ViewBag.Corporate_back_type;

            return Json(jsonString, JsonRequestBehavior.AllowGet); ;
        }

        [ChildActionOnly]
        public ActionResult GetAddressAction()
        {
            DataTable dt = new DataTable();
            dt = getbackground("");

            if (dt.Rows.Count > 0 && dt.Rows[0]["Corporate_logo"].ToString().Length > 0)
            {
                ViewBag.Corporate_logo = dt.Rows[0]["Corporate_logo"].ToString();
            }
            else
            {
                ViewBag.Corporate_logo = "admin-logo.png";
            }

            if (dt.Rows.Count > 0 && dt.Rows[0]["Customer_logo"].ToString().Length > 0)
            {
                ViewBag.Customer_logo = dt.Rows[0]["Customer_logo"].ToString();
            }
            else
            {
                ViewBag.Customer_logo = "";
            }

            if (dt.Rows.Count > 0 && dt.Rows[0]["Corporate_background"].ToString().Length > 0)
            {
                ViewBag.Corporate_background = dt.Rows[0]["Corporate_background"].ToString();

            }
            else
            {
                ViewBag.Corporate_background = "#f79646";
            }

            if (dt.Rows.Count > 0 && dt.Rows[0]["Corporate_back_type"].ToString().Length > 0)
            {
                ViewBag.Corporate_back_type = dt.Rows[0]["Corporate_back_type"].ToString();
            }
            else
            {
                ViewBag.Corporate_back_type = "palette";
            }


            return PartialView();
        }

        public ActionResult NoPermission()
        {
            DataTable dt = new DataTable();
            dt = getbackground("");

            if (dt.Rows.Count > 0 && dt.Rows[0]["Corporate_logo"].ToString().Length > 0)
            {
                ViewBag.Corporate_logo = dt.Rows[0]["Corporate_logo"].ToString();
            }
            else
            {
                ViewBag.Corporate_logo = "admin-logo.png";
            }

            if (dt.Rows.Count > 0 && dt.Rows[0]["Customer_logo"].ToString().Length > 0)
            {
                ViewBag.Customer_logo = dt.Rows[0]["Customer_logo"].ToString();
            }
            else
            {
                ViewBag.Customer_logo = "";
            }

            if (dt.Rows.Count > 0 && dt.Rows[0]["Corporate_background"].ToString().Length > 0)
            {
                ViewBag.Corporate_background = dt.Rows[0]["Corporate_background"].ToString();

            }
            else
            {
                ViewBag.Corporate_background = "#f79646";
            }

            if (dt.Rows.Count > 0 && dt.Rows[0]["Corporate_back_type"].ToString().Length > 0)
            {
                ViewBag.Corporate_back_type = dt.Rows[0]["Corporate_back_type"].ToString();
            }
            else
            {
                ViewBag.Corporate_back_type = "palette";
            }

            return View();
        }

        [CheckRole]
        public ActionResult RegisterCustomer(int? Id = 0)
        {
            LicensedCustomers model = new LicensedCustomers();
            UserBase userBase = new UserBase();

            actionResult = accountAction.Customer_LoadById();
            if (actionResult.IsSuccess)
            {
                DataRow dr = actionResult.dtResult.Rows[0];
                model.Id = dr["ID"] != DBNull.Value ? Convert.ToInt32(dr["ID"]) : 0;
                model.FirstName = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : "";
                model.LastName = dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : "";
                model.UserName = dr["UserName"] != DBNull.Value ? dr["UserName"].ToString() : "";
                model.EMail = dr["Email"] != DBNull.Value ? dr["Email"].ToString() : "";
                model.UserName = dr["UserName"] != DBNull.Value ? dr["UserName"].ToString() : "";
                model.Roles = dr["Roles"] != DBNull.Value ? dr["Roles"].ToString() : "";
                model.Country = dr["Country"] != DBNull.Value ? Convert.ToInt32(dr["Country"]) : 0;
                model.State = dr["State"] != DBNull.Value ? Convert.ToInt32(dr["State"]) : 0;
                model.City = dr["City"] != DBNull.Value ? dr["City"].ToString() : "";
                model.Zip = dr["Zip"] != DBNull.Value ? dr["Zip"].ToString() : "";
                model.CustomerLogo = dr["CustomerLogo"] != DBNull.Value ? dr["CustomerLogo"].ToString() : "";
                if (dr["LicenseExpiryDate"] != DBNull.Value)
                {
                    model.LicenseExpiryDate = Convert.ToDateTime(dr["LicenseExpiryDate"]);
                }
            }

            actionResult = accountAction.Menus_LoadAll();
            if (actionResult.IsSuccess)
                model.MenusList = CommonMethods.ConvertTo<Menus>(actionResult.dtResult);
            model.CountryList = new List<Country>();
            model.StateList = new List<State>();
            actionResult = accountAction.Countries_LoadAll();
            if (actionResult.IsSuccess)
                model.CountryList = CommonMethods.ConvertTo<Country>(actionResult.dtResult);

            if (model.CountryList.Count > 0 && (model.Country == 0 || model.Country == null))
            {
                userBase.Country = Convert.ToInt32(model.CountryList[0].ID);
            }
            else
            {
                userBase.Country = Convert.ToInt32(model.Country);
            }
            actionResult = accountAction.State_LoadByCountryId(userBase);
            if (actionResult.IsSuccess)
                model.StateList = CommonMethods.ConvertTo<State>(actionResult.dtResult);



            return View(model);
        }


        [CheckRole]
        [HttpPost]
        public ActionResult RegisterCustomer(LicensedCustomers model)
        {
            try
            {
                UserBase userBase = new UserBase();
                userBase.ID = model.Id;
                userBase.FirstName = model.FirstName;
                userBase.LastName = model.LastName;
                userBase.UserName = model.UserName;
                userBase.EMail = model.EMail;
                userBase.Password = model.Password;
                userBase.Phone = model.Phone;
                userBase.Country = model.Country;
                userBase.State = model.State;
                userBase.City = model.City;
                userBase.Zip = model.Zip;
                userBase.LicenseExpiryDate = model.LicenseExpiryDate;
                userBase.CustomerLogo = model.CustomerLogo;
                userBase.CustomerRoles = model.Roles;
                actionResult = accountAction.Customers_InsertUpdate(userBase);
                if (actionResult.IsSuccess)
                {
                    TempData["SuccessMessage"] = "Customer " + (model.Id > 0 ? "updated" : "created") + " successfully.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Error in " + (model.Id > 0 ? "updating" : "saving") + " customer.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error in " + (model.Id > 0 ? "updating" : "saving") + " customer.";
            }
            return RedirectToAction("RegisterCustomer");
        }






        [CheckRole]
        public JsonResult GetStateListByCountryId(int CountryId = 0)
        {
            LicensedCustomers model = new LicensedCustomers();
            model.StateList = new List<State>();
            UserBase userBase = new UserBase();
            if (CountryId > 0)
            {
                userBase.Country = Convert.ToInt32(CountryId);
                actionResult = accountAction.State_LoadByCountryId(userBase);
                if (actionResult.IsSuccess)
                    model.StateList = CommonMethods.ConvertTo<State>(actionResult.dtResult);



            }
            return Json(model);
        }


        #region Image Count
        public JsonResult ImageCount()
        {
            string jsonString = string.Empty;
            try
            {
                actionResult = accountAction.ImageCount();
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString += "<tr> <th>Total Images in CIMS :</th> <td>" + actionResult.dtResult.Rows[i]["TotalImages"] + "</td></tr>";
                        jsonString += "<tr> <th>Subject Images :</th> <td>" + actionResult.dtResult.Rows[i]["SubjectImages"] + "</td></tr>";
                        jsonString += "<tr> <th>Encoded Images :</th> <td>" + actionResult.dtResult.Rows[i]["EncodedImages"] + "</td></tr>";
                        jsonString += "<tr> <th>Rejected Images :</th> <td>" + actionResult.dtResult.Rows[i]["RejectedImages"] + "</td></tr>";
                        jsonString += "<tr> <th>Employee Images :</th> <td>" + actionResult.dtResult.Rows[i]["EmployeeImages"] + "</td></tr>";
                        jsonString += "<tr> <th>Images Not Encoded :</th> <td>" + actionResult.dtResult.Rows[i]["NotEncodedImages"] + "</td></tr>";
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


    }
}