using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIMS.Utility;
using CIMS.BaseLayer.Account;
using CIMS.BaseLayer.Admin;

namespace CIMS.DataLayer.Account
{
    public class AccountDL
    {
        #region Declaration
        DataSet dsContainer;
        DataTable dtContainer;
        #endregion

        #region Login_Load
        public DataTable Login_Load(UserBase userBase)
        {
            dtContainer = new DataTable();
            try
            {

                MyParameter[] myParams = {
                                         new MyParameter("@UserName", userBase.UserName),
                                        new MyParameter("@Password", userBase.Password),
                                        new MyParameter("@RoleType", userBase.RoleType)
                                        };
                Common.Set_Procedures("Login_Load");
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


        #region Customers_InsertUpdate
        public DataTable Customers_InsertUpdate(UserBase userBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@Id", userBase.ID),
                                            new MyParameter("@FirstName", userBase.FirstName),
                                            new MyParameter("@LastName", userBase.LastName),
                                            new MyParameter("@Password", userBase.Password),
                                            new MyParameter("@EMail", userBase.EMail) ,
                                             new MyParameter("@UserName", userBase.UserName),
                                              new MyParameter("@Roles", userBase.CustomerRoles),
                                               new MyParameter("@Phone", userBase.Phone),
                                                new MyParameter("@Country", userBase.Country),
                                                 new MyParameter("@State", userBase.State),
                                                  new MyParameter("@City", userBase.City),
                                                 new MyParameter("@Zip", userBase.Zip),
                                                 new MyParameter("@LicenseExpiryDate", userBase.LicenseExpiryDate),
                                          new MyParameter("@CustomerLogo", userBase.CustomerLogo)
                                         };
                Common.Set_Procedures("LicensedCustomers_IU");
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

        #region Customers_LoadAll
        public DataTable Customers_LoadAll()
        {
            dtContainer = new DataTable();
            try
            {

                MyParameter[] myParams = { };
                Common.Set_Procedures("LicensedCustomers_LoadAll");
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

        #region Customer_LoadById
        public DataTable Customer_LoadById()
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {

                                         };
                Common.Set_Procedures("LicensedCustomers_LoadById");
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

        #region Customer_DeleteById
        public DataTable Customer_DeleteById(UserBase userBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@ID", userBase.ID)
                                         };
                Common.Set_Procedures("Customer_DeleteById");
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


        #region Countries_LoadAll
        public DataTable Countries_LoadAll()
        {
            dtContainer = new DataTable();
            try
            {

                MyParameter[] myParams = { };
                Common.Set_Procedures("USP_S_Mater_tblCountry");
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

        #region State_LoadByCountryId
        public DataTable State_LoadByCountryId(UserBase userBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@CountryId", userBase.Country)
                                         };
                Common.Set_Procedures("USP_S_Master_tblState");
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



        #region CustomerRoles_LoadAll
        public DataTable CustomerRoles_LoadAll()
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("CustomerRoles_LoadAll");
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


        #region CustomerRole_IU
        public DataTable CustomerRole_IU(RoleBase roleBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@Id", roleBase.ID),
                                            new MyParameter("@RoleName",roleBase.RoleName)
                                         };
                Common.Set_Procedures("CustomerRoles_IU");
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

        #region CustomerRole_DeleteById
        public DataTable CustomerRole_DeleteById(RoleBase roleBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@ID", roleBase.ID)
                                         };
                Common.Set_Procedures("CustomerRole_DeleteById");
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

        #region Menus_LoadByRoleId
        public DataTable Menus_LoadByRoleId(RoleBase roleBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@Id", roleBase.ID),

                                         };
                Common.Set_Procedures("GetCustomerPermissions_ByRoleId");
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

        #region RolePermission_IU
        public DataTable RolePermission_IU(RoleBase roleBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@RoleId", roleBase.ID),
                                            new MyParameter("@PermissionTable",roleBase.permissionTable)
                                         };
                Common.Set_Procedures("CustomerPermissions_IU");
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


        #region Menus_LoadAll
        public DataTable Menus_LoadAll()
        {
            dtContainer = new DataTable();
            try
            {

                MyParameter[] myParams = { };
                Common.Set_Procedures("GetMenuNames");
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

        #region ImageCount
        public DataTable ImageCount()
        {
            dtContainer = new DataTable();
            try
            {

                MyParameter[] myParams = { };
                Common.Set_Procedures("ImageCount");
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
    }

}
