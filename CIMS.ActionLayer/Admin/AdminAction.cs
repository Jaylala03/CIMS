using CIMS.BaseLayer;
using CIMS.BaseLayer.Admin;
using CIMS.DataLayer.Account;
using CIMS.DataLayer.Admin;
using CIMS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.ActionLayer.Admin
{
    public class AdminAction
    {

        #region Declaration
        AdminDL admintDL = new AdminDL();
        ActionResult actionResult = new ActionResult();
        #endregion

        #region Role_IU
        public ActionResult Role_IU(RoleBase roleBase)
        {
            try
            {
                actionResult.dtResult = admintDL.Role_IU(roleBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion

        #region RoleAuthorities_IU
        public ActionResult RoleAuthorities_IU(RoleBase roleBase)
        {
            try
            {
                actionResult.dtResult = admintDL.RoleAuthorities_IU(roleBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion

        #region Roles_LoadAll
        public ActionResult Roles_LoadAll()
        {
            try
            {
                actionResult.dtResult = admintDL.Roles_LoadAll();
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion

        #region Role_LoadById
        public ActionResult Role_LoadById(RoleBase roleBase)
        {
            try
            {
                actionResult.dtResult = admintDL.Role_LoadById(roleBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion

        #region Role_DeleteById
        public ActionResult Role_DeleteById(RoleBase roleBase)
        {
            try
            {
                actionResult.dtResult = admintDL.Role_DeleteById(roleBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion

        #region Users_InsertUpdate
        public ActionResult Users_InsertUpdate(UserBase userBase)
        {
            try
            {
                actionResult.dtResult = admintDL.Users_InsertUpdate(userBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion

        #region Users_LoadAll
        public ActionResult Users_LoadAll()
        {
            try
            {
                actionResult.dtResult = admintDL.Users_LoadAll();
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion

        #region User_LoadById
        public ActionResult User_LoadById(UserBase userBase)
        {
            try
            {
                actionResult.dtResult = admintDL.User_LoadById(userBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion

        #region User_DeleteById
        public ActionResult User_DeleteById(UserBase userBase)
        {
            try
            {
                actionResult.dtResult = admintDL.User_DeleteById(userBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion


        #region Menus_LoadAll
        public ActionResult Menus_LoadAll()
        {
            try
            {
                actionResult.dtResult = admintDL.Menus_LoadAll();
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion


        #region UserRoles_LoadAll
        public ActionResult UserRoles_LoadAll()
        {
            try
            {
                actionResult.dtResult = admintDL.UserRoles_LoadAll();
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion

        #region UserRole_IU
        public ActionResult UserRole_IU(RoleBase roleBase)
        {
            try
            {
                actionResult.dtResult = admintDL.UserRole_IU(roleBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion


        #region UserRole_DeleteById
        public ActionResult UserRole_DeleteById(RoleBase roleBase)
        {
            try
            {
                actionResult.dtResult = admintDL.UserRole_DeleteById(roleBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion

        #region Menus_LoadByRoleId
        public ActionResult Menus_LoadByRoleId(RoleBase roleBase)
        {
            try
            {
                actionResult.dtResult = admintDL.Menus_LoadByRoleId(roleBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion


        #region RolePermission_IU
        public ActionResult RolePermission_IU(RoleBase roleBase)
        {
            try
            {
                actionResult.dtResult = admintDL.RolePermission_IU(roleBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion


        #region Login_Load
        public ActionResult Login_Load(UserBase userBase)
        {
            try
            {
                actionResult.dtResult = admintDL.Login_Load(userBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion


        #region Menus_LoadForSiteAdministrator
        public ActionResult Menus_LoadForSiteAdministrator()
        {
            try
            {
                actionResult.dtResult = admintDL.Menus_LoadForSiteAdministrator();
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion
        #region VerifyEmailAccount
        public ActionResult VerifyEmailAccount(UserBase userBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = admintDL.VerifyEmailAccount(userBase);
                if (actionResult.dtResult.Rows.Count > 0)
                {
                    if (actionResult.dtResult.Rows[0][0].ToString() != "-10")
                    {
                        actionResult.IsSuccess = true;
                    }
                    else
                    {
                        actionResult.IsSuccess = false;
                    }
                }
            }
            catch (Exception)
            {


            }
            return actionResult;
        }
        #endregion

        #region VerifyEmailAccount
        public ActionResult CheckDuplicateUser(string UserName, int? ID)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = admintDL.CheckDuplicateUser(UserName, ID);
                if (actionResult.dtResult!= null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
                else
                {
                    actionResult.IsSuccess = false;
                }
            }
            catch (Exception)
            {

            }
            return actionResult;
        }
        #endregion

        #region SubMenu_LoadAll
        public ActionResult SubMenu_LoadAll()
        {
            try
            {
                actionResult.dtResult = admintDL.SubMenu_LoadAll();
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion

        #region SubMenuPermissions
        public ActionResult SubMenuPermissions(RoleBase roleBase)
        {
            try
            {
                actionResult.dtResult = admintDL.SubMenuPermissions(roleBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
                else
                {
                    actionResult.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion

        #region SubMenuPermission_IU
        public ActionResult SubMenuPermission_IU(SubMenuBase subMenuBase)
        {
            try
            {
                actionResult.dtResult = admintDL.SubMenuPermission_IU(subMenuBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion

        #region Corporate Logo
        // *DN
        public ActionResult Corporate_update(CorporateBase corporateBase)
        {
            try
            {
                actionResult.dtResult = admintDL.Corporate_update(corporateBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                ErrorReporting.ActionLayerError(ex);
            }
            return actionResult;
        }
        #endregion

    }
}
