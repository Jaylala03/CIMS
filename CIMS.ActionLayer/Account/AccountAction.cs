using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIMS.Utility;
using CIMS.BaseLayer;
using CIMS.BaseLayer.Account;
using CIMS.DataLayer.Account;
using CIMS.BaseLayer.Admin;

namespace CIMS.ActionLayer.Account
{
    public class AccountAction
    {
        #region Declaration
        AccountDL accountDL = new AccountDL();
        ActionResult actionResult = new ActionResult();
        #endregion

        #region Login_Load
        public ActionResult Login_Load(UserBase userBase)
        {
            try
            {
                actionResult.dtResult = accountDL.Login_Load(userBase);
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

        #region Customers_InsertUpdate
        public ActionResult Customers_InsertUpdate(UserBase userBase)
        {
            try
            {
                actionResult.dtResult = accountDL.Customers_InsertUpdate(userBase);
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


        #region Customers_LoadAll
        public ActionResult Customers_LoadAll()
        {
            try
            {
                actionResult.dtResult = accountDL.Customers_LoadAll();
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

        #region Customer_LoadById
        public ActionResult Customer_LoadById()
        {
            try
            {
                actionResult.dtResult = accountDL.Customer_LoadById();
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

        #region Customer_DeleteById
        public ActionResult Customer_DeleteById(UserBase userBase)
        {
            try
            {
                actionResult.dtResult = accountDL.Customer_DeleteById(userBase);
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


        #region Countries_LoadAll
        public ActionResult Countries_LoadAll()
        {
            try
            {
                actionResult.dtResult = accountDL.Countries_LoadAll();
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

        #region State_LoadByCountryId
        public ActionResult State_LoadByCountryId(UserBase userBase)
        {
            try
            {
                actionResult.dtResult = accountDL.State_LoadByCountryId(userBase);
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


        #region CustomerRoles_LoadAll
        public ActionResult CustomerRoles_LoadAll()
        {
            try
            {
                actionResult.dtResult = accountDL.CustomerRoles_LoadAll();
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

        #region CustomerRole_IU
        public ActionResult CustomerRole_IU(RoleBase roleBase)
        {
            try
            {
                actionResult.dtResult = accountDL.CustomerRole_IU(roleBase);
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


        #region CustomerRole_DeleteById
        public ActionResult CustomerRole_DeleteById(RoleBase roleBase)
        {
            try
            {
                actionResult.dtResult = accountDL.CustomerRole_DeleteById(roleBase);
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
                actionResult.dtResult = accountDL.Menus_LoadByRoleId(roleBase);
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
                actionResult.dtResult = accountDL.RolePermission_IU(roleBase);
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
                actionResult.dtResult = accountDL.Menus_LoadAll();
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

        #region ImageCount
        public ActionResult ImageCount()
        {
            try
            {
                actionResult.dtResult = accountDL.ImageCount();
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
