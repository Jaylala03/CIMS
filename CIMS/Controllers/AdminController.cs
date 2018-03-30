using CIMS.ActionLayer.Admin;
using CIMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CIMS.Helpers;
using CIMS.BaseLayer.Admin;
using CIMS.Utility;
using System.Data;
using CIMS.Filters;
using System.IO;
using Newtonsoft.Json;

namespace CIMS.Controllers
{
    // sd fsd fsd fsd 
    public class AdminController : Controller
    {
        #region Declaration
        RoleBase roleBase = new RoleBase();
        AdminAction adminAction = new AdminAction();
        CIMS.BaseLayer.ActionResult actionResult = new CIMS.BaseLayer.ActionResult();
        #endregion 

        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult AdminLogin(LoginModel model)
        {
            UserBase userBase = new UserBase();
            try
            {
                if (ModelState.IsValid)
                {
                    int result = 0;
                    userBase.UserName = model.UserName;
                    userBase.Password = model.Password;
                    model.RememberMe = model.RememberMe;
                    actionResult = adminAction.Login_Load(userBase);
                    if (actionResult.IsSuccess)
                    {
                        DataRow dr = actionResult.dtResult.Rows[0];
                        result = Convert.ToInt32(dr[0]);
                        if (result < 0)
                        {
                            TempData["ErrorMessage"] = "UserName or PasswOrd is wrong.";
                            return View(model);
                        }
                        else
                        {
                            if (dr["Role"] != DBNull.Value && Convert.ToInt32(dr["Role"]) == 1)
                            {
                                Session["SuperAdmin"] = Convert.ToInt32(dr["Id"]);
                                int id = Convert.ToInt32(dr["Id"]);
                                Session["RoleName"] = "Super Admin";
                                Session["UserName"] = "Super Admin";
                                // return RedirectToAction("Index", "Subject", new { area = "Subject" });
                                return Redirect("~/Home/RegisterCustomer");
                            }
                            else
                            {
                                Session["Admin"] = Convert.ToInt32(dr["ID"]);
                                Session["UserId"] = Convert.ToInt32(dr["ID"]);
                                int id = Convert.ToInt32(dr["ID"]);
                                Session["RoleName"] = "Admin";
                                Session["ReportProofreadCheck"] = Convert.ToInt32(dr["IsAdmin"]);
                                Session["UserName"] = Convert.ToString(dr["UserName"]);
                                // return RedirectToAction("Index", "Subject", new { area = "Subject" });
                                return Redirect("~/Home/Index");
                            }



                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error in login. Please try again later.";
                ErrorReporting.WebApplicationError(ex);
            }
            return RedirectToAction("AdminLogin");
        }
        [CheckLogin]
        [HttpGet]
        public ActionResult Roles()
        {
            ManageRolemodel model = new ManageRolemodel();
            RoleModel roleModel = new RoleModel();
            List<RoleModel> roleList = new List<RoleModel>();
            model.RoleList = roleList;
            model.roleModel = roleModel;
            // roleBase.ID = Convert.ToInt32(Session["UserId"]);
            roleBase.ID = 0;
            actionResult = adminAction.Role_LoadById(roleBase);
            if (actionResult.IsSuccess)
            {
                model.RoleList = CommonMethods.ConvertTo<RoleModel>(actionResult.dtResult);
                model.roleModel = model.RoleList.FirstOrDefault();
            }

            actionResult = adminAction.Roles_LoadAll();
            if (actionResult.IsSuccess)
                model.RoleList = CommonMethods.ConvertTo<RoleModel>(actionResult.dtResult);
            return View(model);
        }

        [CheckLogin]
        [HttpPost]
        public ActionResult Roles(ManageRolemodel model)
        {
            return RedirectToAction("Roles");
        }

        [CheckLogin]
        [HttpGet]
        public ActionResult Users()
        {

            int action = 0;
            bool status = false;
            if (Session["Admin"] != null)
            {
                int userId = Convert.ToInt32(Session["Admin"]);
                string[] permission = CheckAdminPermissions.permission("Manage Users", userId);


                if (permission != null)
                {
                    action = Convert.ToInt32(permission[1]);
                    status = Convert.ToBoolean(permission[0]);
                }
            }
            else if (Session["UserId"] != null)
            {
                int userId = Convert.ToInt32(Session["UserId"]);
                string[] permission = CheckPermissions.permission("Manage Users", userId);


                if (permission != null)
                {
                    action = Convert.ToInt32(permission[1]);
                    status = Convert.ToBoolean(permission[0]);
                }
            }
            if (status == false)
            {
                string url = "~/Home/NoPermission";
                return Redirect(url);
            }
            ViewBag.Action = action;
            ViewBag.Status = status;
            ManageUserModel model = new ManageUserModel();
            List<UserModel> UserList = new List<UserModel>();
            actionResult = adminAction.Users_LoadAll();
            if (actionResult.IsSuccess)
            {
                UserList = CommonMethods.ConvertTo<UserModel>(actionResult.dtResult);
            }
            model.UserList = UserList;
            return View(model);
        }

        [CheckLogin]
        [HttpPost]
        public ActionResult Users(UserModel model)
        {
            //check for duplicate username
            actionResult = adminAction.CheckDuplicateUser(model.UserName, model.ID);
            if (actionResult.IsSuccess)
            {
                TempData["ErrorMessage"] = "User name is duplicate.";
                return View("ManageUsers", model);
            }

            UserBase userBase = new UserBase();
            userBase.ID = model.ID;
            userBase.FirstName = model.FirstName;
            userBase.LastName = model.LastName;
            userBase.Initials = model.Initials;
            userBase.EMail = model.EMail;
            userBase.IsDispatchable = model.IsDispatchable;
            if (model.ID == 0)
            {
                userBase.Password = model.Password;
                userBase.PasswordDate = DateTime.UtcNow;
            }
            userBase.RegNumber = model.RegNumber;
            userBase.Skills = model.Skills;
            userBase.UnitID = model.UnitID;
            userBase.UserGuid = Guid.NewGuid().ToString();
            userBase.UserCanChangePassword = model.UserCanChangePassword;
            userBase.UserName = model.UserName;
            DataTable dt = new DataTable();
            dt.Columns.Add("RoleId");

            if (model.Roles != null && model.Roles.Length > 0)
            {
                var roles = model.Roles.Split(',');
                foreach (var item in roles)
                {

                    DataRow row;
                    row = dt.NewRow();
                    row["RoleId"] = item;

                    dt.Rows.Add(row);

                }
            }
            userBase.Roles = dt;
            actionResult = adminAction.Users_InsertUpdate(userBase);
            if (actionResult.IsSuccess)
            {
                string site = System.Configuration.ConfigurationManager.AppSettings["site"];
                string guid = userBase.UserGuid;
                string token = userBase.EMail;
                string FirstName = model.FirstName + ' ' + model.LastName;
                //string Password = model.Password;
                //string UserName = model.UserName;

                bool res = CIMS.Utility.SendMail.ConfirmationMail(userBase.EMail, FirstName, guid);


            }
            else
            {
                TempData["ErrorMessage"] = "Error in saving user.";
            }
            return RedirectToAction("Users");
        }

        #region ConfirmRegistration

        public ActionResult ConfirmRegistration(string id)
        {
            UserBase userBase = new UserBase();
            try
            {
                if (id != "")
                {


                    userBase.UserGuid = id;
                    actionResult = adminAction.VerifyEmailAccount(userBase);
                    if (actionResult.IsSuccess)
                    {
                        DataRow dr = actionResult.dtResult.Rows[0];
                        if (dr[0].ToString() == "1")
                            TempData["ErrorMessage"] = "Your account has been verified successfully.";
                        else if (dr[0].ToString() == "-10")
                            TempData["ErrorMessage"] = "Your account is not exist in our records.";

                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Error occurred.Please try after sometime.";
                }
            }

            catch (Exception ex)
            {
                TempData["error"] = "Error in verifying account.";
            }
            return RedirectToAction("Login", "Account");

        }
        #endregion

        #region RolePermissions
        [CheckLogin]
        [HttpGet]
        public ActionResult RolePermissions(int? Id = 0)
        {
            int action = 0;
            bool status = false;
            if (Session["Admin"] != null)
            {
                int userId = Convert.ToInt32(Session["Admin"]);
                string[] permission = CheckAdminPermissions.permission("Manage Roles", userId);


                if (permission != null)
                {
                    action = Convert.ToInt32(permission[1]);
                    status = Convert.ToBoolean(permission[0]);
                }
            }

            else if (Session["UserId"] != null)
            {
                int userId = Convert.ToInt32(Session["UserId"]);
                string[] permission = CheckPermissions.permission("Manage Roles", userId);


                if (permission != null)
                {
                    action = Convert.ToInt32(permission[1]);
                    status = Convert.ToBoolean(permission[0]);
                }
            }
            if (status == false)
            {
                string url = "~/Home/NoPermission";
                return Redirect(url);
            }
            ViewBag.Action = action;
            ViewBag.Status = status;
            Roles model = new Roles();
            List<Roles> roleList = new List<Roles>();
            model.RolesList = roleList;
            model.RoleId = Convert.ToInt32(Id);

            actionResult = adminAction.UserRoles_LoadAll();
            if (actionResult.IsSuccess)
                model.RolesList = CommonMethods.ConvertTo<Roles>(actionResult.dtResult);

            if (model.RoleId > 0)
            {
                for (int i = 0; i < model.RolesList.Count; i++)
                {
                    if (model.RolesList[i].RoleId == model.RoleId)
                    {
                        ViewBag.RoleName = model.RolesList[i].RoleName;
                        ViewBag.RoleID = model.RolesList[i].RoleId;
                    }
                }
            }
            if (ViewBag.RoleName == null)
            {
                ViewBag.RoleName = "";
            }

            if (model.RolesList.Count > 0 && Id == 0)
            {
                model.RoleId = model.RolesList[0].RoleId;
            }


            actionResult = adminAction.Menus_LoadForSiteAdministrator();
            if (actionResult.IsSuccess)
                model.MenusList = CommonMethods.ConvertTo<Menus>(actionResult.dtResult);

            //actionResult = adminAction.SubMenu_LoadAll();
            //if (actionResult.IsSuccess)                
            //    model.SubMenusList = CommonMethods.ConvertTo<SubMenus>(actionResult.dtResult);

            //roleBase.ID = Convert.ToInt32(Id);
            //SubMenus subMenusModel = new SubMenus();
            //actionResult = adminAction.SubMenuPermissions(roleBase);
            //if (actionResult.IsSuccess)
            //{
            //    DataRow dr = actionResult.dtResult.Rows[0];
            //    subMenusModel.ParentID = dr["ParentID"] != DBNull.Value ? Convert.ToInt32(dr["ParentID"]) : 0;
            //    subMenusModel.Roles = dr["SubMenus"] != DBNull.Value ? dr["SubMenus"].ToString() : "";
            //}
            //model.SubMenusModel = subMenusModel;
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

            return View(model);
        }
        #endregion

        [CheckLogin]
        [HttpPost]
        public ActionResult UserRoles(Roles model)
        {
            RoleBase roleBase = new RoleBase();
            roleBase.RoleName = model.RoleName;
            roleBase.ID = model.RoleId;
            actionResult = adminAction.UserRole_IU(roleBase);
            if (actionResult.IsSuccess)
            {
                int result = Convert.ToInt32(actionResult.dtResult.Rows[0][0]);
                if (result > 0)
                {

                    TempData["SuccessMessage"] = "Role " + (model.RoleId > 0 ? "updated" : "saved") + " successfully.";
                    if (model.RoleId == 0)
                    {
                        model.RoleId = result;
                    }
                }
                else if (result == -10)
                {
                    TempData["ErrorMessage"] = "Role name already exists. Please try another role name.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Error in saving role.";
                }
            }
            else
                TempData["ErrorMessage"] = "Error in saving role.";
            return RedirectToAction("RolePermissions", new { Id = model.RoleId });
        }


        #region DeleteRole
        [CheckLogin]
        [HttpPost]
        public JsonResult DeleteRole(int? Id = 0)
        {
            string json = string.Empty;
            try
            {
                RoleBase roleBase = new RoleBase();

                roleBase.ID = Convert.ToInt32(Id);
                actionResult = adminAction.UserRole_DeleteById(roleBase);
                if (actionResult.IsSuccess)
                {
                    int result = Convert.ToInt32(actionResult.dtResult.Rows[0][0]);
                    if (result == -10)
                    {
                        json = "-10";
                    }
                    else
                    {
                        json = "success";
                    }

                }
                else
                {
                    json = "-1";
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

        [CheckLogin]
        [HttpPost]
        public ActionResult SavepPermission(Roles model)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MenuId");
            dt.Columns.Add("PermissionType");
            if (model.MenusList != null && model.MenusList.Count > 0)
            {
                foreach (var item in model.MenusList)
                {
                    if (item.PermissionType > 0)
                    {
                        DataRow row;
                        row = dt.NewRow();
                        row["MenuId"] = item.Id;
                        row["PermissionType"] = item.PermissionType;
                        dt.Rows.Add(row);
                    }

                }
            }
            RoleBase roleBase = new RoleBase();
            roleBase.permissionTable = dt;
            roleBase.ID = model.RoleId;
            actionResult = adminAction.RolePermission_IU(roleBase);

            if (actionResult.IsSuccess)
            {
                TempData["SuccessMessage"] = "Permission saved successfully.";
            }
            else
                TempData["ErrorMessage"] = "Error in saving permission.";
            return RedirectToAction("RolePermissions", new { Id = model.RoleId });
        }

        [CheckLogin]
        public ActionResult ManageUsers(int? Id = 0 )
        {
            
            int action = 0;
            bool status = false;
            if (Session["Admin"] != null)
            {
                int userId = Convert.ToInt32(Session["Admin"]);
                string[] permission = CheckAdminPermissions.permission("Manage Users", userId);

                if (permission != null)
                {
                    action = Convert.ToInt32(permission[1]);
                    status = Convert.ToBoolean(permission[0]);
                }
            }
            else if (Session["UserId"] != null)
            {
                int userId = Convert.ToInt32(Session["UserId"]);
                string[] permission = CheckPermissions.permission("Manage Users", userId);
                if (permission != null)
                {
                    action = Convert.ToInt32(permission[1]);
                    status = Convert.ToBoolean(permission[0]);
                }
            }
            if (status == false)
            {
                string url = "~/Home/NoPermission";
                return Redirect(url);
            }
            ViewBag.Action = action;
            ViewBag.Status = status;
            UserModel model = new UserModel();
            if (Id > 0)
            {
                UserBase userBase = new UserBase();
                userBase.ID = Convert.ToInt32(Id);
                actionResult = adminAction.User_LoadById(userBase);
                if (actionResult.IsSuccess)
                {
                    DataRow dr = actionResult.dtResult.Rows[0];
                    model.ID = dr["ID"] != DBNull.Value ? Convert.ToInt32(dr["ID"]) : 0;
                    model.FirstName = dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : "";
                    model.LastName = dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : "";
                    model.Initials = dr["Initials"] != DBNull.Value ? dr["Initials"].ToString() : "";
                    model.UserName = dr["UserName"] != DBNull.Value ? dr["UserName"].ToString() : "";

                    model.RegNumber = dr["RegNumber"] != DBNull.Value ? dr["RegNumber"].ToString() : "";
                    model.Skills = dr["Skills"] != DBNull.Value ? dr["Skills"].ToString() : "";
                    model.EMail = dr["EMail"] != DBNull.Value ? dr["EMail"].ToString() : "";
                    model.UserName = dr["UserName"] != DBNull.Value ? dr["UserName"].ToString() : "";
                    model.Roles = dr["Roles"] != DBNull.Value ? dr["Roles"].ToString() : "";
                    model.UnitID = dr["UnitID"] != DBNull.Value ? Convert.ToInt32(dr["UnitID"]) : 0;
                    model.IsDispatchable = dr["IsDispatchable"] != DBNull.Value ? Convert.ToBoolean(dr["IsDispatchable"]) : false;
                }

                actionResult = adminAction.UserRoles_LoadAll();
                if (actionResult.IsSuccess)
                    model.RolesList = CommonMethods.ConvertTo<Roles>(actionResult.dtResult);
            }
            return View(model);
        }

        #region DeleteRole
        [CheckLogin]
        [HttpPost]
        public ActionResult DeleteUser(int? Id = 0)
        {
            int action = 0;
            bool status = false;
            if (Session["Admin"] != null)
            {
                int userId = Convert.ToInt32(Session["Admin"]);
                string[] permission = CheckAdminPermissions.permission("Manage Users", userId);

                if (permission != null)
                {
                    action = Convert.ToInt32(permission[1]);
                    status = Convert.ToBoolean(permission[0]);
                }
            }
            else if (Session["UserId"] != null)
            {
                int userId = Convert.ToInt32(Session["UserId"]);
                string[] permission = CheckPermissions.permission("Manage Users", userId);
                if (permission != null)
                {
                    action = Convert.ToInt32(permission[1]);
                    status = Convert.ToBoolean(permission[0]);
                }
            }
            if (status == false)
            {
                string url = "~/Home/NoPermission";
                return Redirect(url);
            }
            ViewBag.Action = action;
            ViewBag.Status = status;

            string json = string.Empty;
            try
            {
                UserBase userBase = new UserBase();
                userBase.ID = Convert.ToInt32(Id);

                actionResult = adminAction.User_DeleteById(userBase);
                if (actionResult.IsSuccess)
                {
                    int result = Convert.ToInt32(actionResult.dtResult.Rows[0][0]);
                    if (result == -10)
                    {
                        json = "-10";
                    }
                    else
                    {
                        json = "success";
                    }

                }
                else
                {
                    json = "-1";
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

        #region DeleteRole
        [CheckLogin]
        [HttpPost]
        public ActionResult CheckDuplicateUser(string UserName)
        {
            string json = string.Empty;
            try
            {
                //check for duplicate username
                actionResult = adminAction.CheckDuplicateUser(UserName, null);
                if (actionResult.IsSuccess)
                {
                    TempData["ErrorMessage"] = "User name is duplicate.";
                    json = "-1";
                }
                else
                {
                    json = "success";
                }
            }
            catch (Exception ex)
            {
                json = "-10;" + ex.Message;
                ErrorReporting.WebApplicationError(ex);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #endregion


        #region RolePermissions

        public JsonResult GetPermission(int? Id = 0)
        {

            Roles model = new Roles();
            List<Roles> roleList = new List<Roles>();
            model.RolesList = roleList;
            model.RoleId = Convert.ToInt32(Id);

            RoleBase roleBase = new RoleBase();
            roleBase.ID = model.RoleId;
            actionResult = adminAction.Menus_LoadByRoleId(roleBase);
            if (actionResult.IsSuccess)
                model.MenusList = CommonMethods.ConvertTo<Menus>(actionResult.dtResult);
            return Json(model);
        }
        #endregion

        // *DN

        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                using (System.Drawing.Image image = System.Drawing.Image.FromStream(file.InputStream, true, true))
                {
                    if (image.Width > 150 && image.Height > 50)
                    {
                        TempData["SuccessMessage"] = "Corporate Logo dimention should be as:  Width < 150 px and Height < 50 px.";
                        return RedirectToAction("RolePermissions");
                    }
                }

                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/assets/images/"), pic);
                // file is uploaded
                file.SaveAs(path);

                CorporateBase CorporateBase = new CorporateBase();

                CorporateBase.Corporate_logo = pic;
                CorporateBase.Corporate_action = "logo";

                actionResult = adminAction.Corporate_update(CorporateBase);


                //using (MemoryStream ms = new MemoryStream())
                //{
                //    file.InputStream.CopyTo(ms);
                //    byte[] array = ms.GetBuffer();
                //}

            }
            // after successfully uploading redirect the user
            if (actionResult.IsSuccess)
            {
                TempData["SuccessMessage"] = "Corporate Logo saved successfully.";
            }
            else
                TempData["ErrorMessage"] = "Error in saving Corporate Logo.";

            return RedirectToAction("RolePermissions");
        }

        //AB New
        public ActionResult FileUploadCustomer(HttpPostedFileBase file)
        {
            if (file != null)
            {
                using (System.Drawing.Image image = System.Drawing.Image.FromStream(file.InputStream, true, true))
                {
                    if (image.Width > 150 && image.Height > 50)
                    {
                        TempData["SuccessMessage"] = "Customer Logo dimention should be as:  Width < 150 px and Height < 50 px.";
                        return RedirectToAction("RolePermissions");
                    }
                }

                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/assets/images/"), pic);
                // file is uploaded
                file.SaveAs(path);

                CorporateBase CorporateBase = new CorporateBase();

                CorporateBase.Customer_logo = pic;
                CorporateBase.Corporate_action = "logoCustm";

                actionResult = adminAction.Corporate_update(CorporateBase);


                //using (MemoryStream ms = new MemoryStream())
                //{
                //    file.InputStream.CopyTo(ms);
                //    byte[] array = ms.GetBuffer();
                //}

            }
            // after successfully uploading redirect the user
            if (actionResult.IsSuccess)
            {
                TempData["SuccessMessage"] = "Customer Logo saved successfully.";
            }
            else
                TempData["ErrorMessage"] = "Error in saving Customer Logo.";

            return RedirectToAction("RolePermissions");
        }

        public ActionResult editbackground(HttpPostedFileBase file, string palette, string chkYes)
        {

            if (Request.Form["chkPassPort"].ToString() == "2")
            {
                if (file != null)
                {
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(
                                           Server.MapPath("~/assets/images/"), pic);
                    // file is uploaded
                    file.SaveAs(path);

                    CorporateBase CorporateBase = new CorporateBase();

                    CorporateBase.Corporate_background = pic;
                    CorporateBase.Corporate_back_type = "pic";
                    CorporateBase.Corporate_action = "back";

                    actionResult = adminAction.Corporate_update(CorporateBase);


                    //using (MemoryStream ms = new MemoryStream())
                    //{
                    //    file.InputStream.CopyTo(ms);
                    //    byte[] array = ms.GetBuffer();
                    //}

                }
            }
            else
            {
                CorporateBase CorporateBase = new CorporateBase();

                CorporateBase.Corporate_background = palette;
                CorporateBase.Corporate_back_type = "palette";
                CorporateBase.Corporate_action = "back";

                actionResult = adminAction.Corporate_update(CorporateBase);
            }
            if (actionResult.IsSuccess)
            {
                TempData["SuccessMessage"] = "Background saved successfully.";
            }
            else
                TempData["ErrorMessage"] = "Error in saving Background.";
            // after successfully uploading redirect the user


            return RedirectToAction("RolePermissions");
        }
        public DataTable getbackground(string name)
        {
            CorporateBase CorporateBase = new CorporateBase();

            CorporateBase.Corporate_action = "get";

            actionResult = adminAction.Corporate_update(CorporateBase);

            return (actionResult.dtResult);
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(UserModel model)
        {
            UserBase userBase = new UserBase();
            userBase.ID = model.ID;

            userBase.UserName = Session["UserName"].ToString();

            userBase.Password = model.NewPassword;

            actionResult = adminAction.Users_Password_Update(userBase);
            if (actionResult.IsSuccess)
            {
                TempData["SuccessMessage"] = "Password changed successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Old password is wrong.";
            }
            return RedirectToAction("ChangePassword");
        }
    }    
}