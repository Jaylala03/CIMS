using CIMS.BaseLayer.Account;
using CIMS.BaseLayer.Admin;
using CIMS.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.DataLayer.Admin
{
   public class AdminDL
    {
        #region Declaration
        DataSet dsContainer;
        DataTable dtContainer;
        #endregion

        #region Role_IU
        public DataTable Role_IU(RoleBase roleBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@ID", roleBase.ID),
                                            new MyParameter("@RoleName",roleBase.RoleName)
                                         };
                Common.Set_Procedures("Role_IU");
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

        #region RoleAuthorities_IU
        public DataTable RoleAuthorities_IU(RoleBase roleBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@ID", roleBase.ID),
                                            new MyParameter("@WatchListEdit", roleBase.WatchListEdit),
                                            new MyParameter("@WatchList", roleBase.WatchList),
                                            new MyParameter("@Visitors", roleBase.Visitors),
                                            new MyParameter("@Vehicles", roleBase.Vehicles),
                                            new MyParameter("@Users", roleBase.Users),
                                            new MyParameter("@TransactionLog", roleBase.TransactionLog),
                                            new MyParameter("@Subjects", roleBase.Subjects),
                                            new MyParameter("@SubjectLinked", roleBase.SubjectLinked),
                                            new MyParameter("@SharedInformation", roleBase.SharedInformation),
                                            new MyParameter("@SharedEmails", roleBase.SharedEmails),
                                            new MyParameter("@ServicesCodes", roleBase.ServicesCodes),
                                            new MyParameter("@Services", roleBase.Services),
                                            new MyParameter("@RestrictedSubjects", roleBase.RestrictedSubjects),
                                            new MyParameter("@ReportOptions", roleBase.ReportOptions),
                                            new MyParameter("@QuickIncident", roleBase.QuickIncident),
                                            new MyParameter("@Permissions", roleBase.Permissions),
                                            new MyParameter("@OccurrenceWrite", roleBase.OccurrenceWrite),
                                            new MyParameter("@OccurrenceAdministration", roleBase.OccurrenceAdministration),
                                            new MyParameter("@Occurrence", roleBase.Occurrence),
                                            new MyParameter("@NatureofIncidentCodes", roleBase.NatureofIncidentCodes),
                                            new MyParameter("@NatureofCallCodes", roleBase.NatureofCallCodes),
                                            new MyParameter("@MultipleAuthorReports", roleBase.MultipleAuthorReports),
                                            new MyParameter("@Messages", roleBase.Messages),
                                            new MyParameter("@MessageGroups", roleBase.MessageGroups),
                                            new MyParameter("@MessageAlerts", roleBase.MessageAlerts),
                                            new MyParameter("@MediaReview", roleBase.MediaReview),
                                            new MyParameter("@MediaCopy", roleBase.MediaCopy),
                                            new MyParameter("@MediaCaptureOptions", roleBase.MediaCaptureOptions),
                                            new MyParameter("@MediaCapture", roleBase.MediaCapture),
                                            new MyParameter("@LCTTotals", roleBase.LCTTotals),
                                            new MyParameter("@LCTDetails", roleBase.LCTDetails),
                                            new MyParameter("@LabelNames", roleBase.LabelNames),
                                            new MyParameter("@Involved", roleBase.Involved),
                                            new MyParameter("@IncidentProtection", roleBase.IncidentProtection),
                                            new MyParameter("@IncidentDetails", roleBase.IncidentDetails),
                                            new MyParameter("@IncidentDescription", roleBase.IncidentDescription),
                                            new MyParameter("@Identification", roleBase.Identification),
                                            new MyParameter("@GameLocations", roleBase.GameLocations),
                                            new MyParameter("@ForeignRates", roleBase.ForeignRates),
                                            new MyParameter("@Features", roleBase.Features),
                                            new MyParameter("@EventsMedia", roleBase.EventsMedia),
                                            new MyParameter("@Events", roleBase.Events),
                                            new MyParameter("@Equipment", roleBase.Equipment),
                                            new MyParameter("@EmployeeVariance", roleBase.EmployeeVariance),
                                            new MyParameter("@EmployeePersonal", roleBase.EmployeePersonal),
                                            new MyParameter("@EmployeePaceAudit", roleBase.EmployeePaceAudit),
                                            new MyParameter("@EmployeeNotes", roleBase.EmployeeNotes),
                                            new MyParameter("@EmployeeLinked", roleBase.EmployeeLinked),
                                            new MyParameter("@EmployeeLicense", roleBase.EmployeeLicense),
                                            new MyParameter("@EmployeeIPVR", roleBase.EmployeeIPVR),
                                            new MyParameter("@EmployeeInvolved", roleBase.EmployeeInvolved),
                                            new MyParameter("@EmployeeIncidentDetails", roleBase.EmployeeIncidentDetails),
                                            new MyParameter("@EmployeeGameAudit", roleBase.EmployeeGameAudit),
                                            new MyParameter("@EmployeeAddress", roleBase.EmployeeAddress),
                                            new MyParameter("@Employee", roleBase.Employee),
                                            new MyParameter("@Emails", roleBase.Emails),
                                            new MyParameter("@DropdownCodes", roleBase.DropdownCodes),
                                            new MyParameter("@DisputeOffense", roleBase.DisputeOffense),
                                            new MyParameter("@DispatchDispatchers", roleBase.DispatchDispatchers),
                                            new MyParameter("@DispatchCallTakers", roleBase.DispatchCallTakers),
                                            new MyParameter("@DispatchAdministration", roleBase.DispatchAdministration),
                                            new MyParameter("@DatabaseOptions", roleBase.DatabaseOptions),
                                            new MyParameter("@CustomReports", roleBase.CustomReports),
                                            new MyParameter("@CombineSubjects", roleBase.CombineSubjects),
                                            new MyParameter("@ChangeRoles", roleBase.ChangeRoles),
                                            new MyParameter("@CashTransactions", roleBase.CashTransactions),
                                            new MyParameter("@Banned", roleBase.Banned),
                                            new MyParameter("@Badges", roleBase.Badges),
                                            new MyParameter("@AuditQuestions", roleBase.AuditQuestions),
                                            new MyParameter("@ApplicationOptions", roleBase.ApplicationOptions),
                                            new MyParameter("@Alias", roleBase.Alias),
                                            new MyParameter("@Address", roleBase.Address),
                                            new MyParameter("@AccessCards",roleBase.AccessCards)
                                         };
                Common.Set_Procedures("RoleAuthorities_IU");
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

        #region Roles_LoadAll
        public DataTable Roles_LoadAll()
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("Roles_LoadAll");
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

        #region Role_LoadById
        public DataTable Role_LoadById(RoleBase roleBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@ID", roleBase.ID)
                                         };
                Common.Set_Procedures("Role_LoadById");
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

        #region Role_DeleteById
        public DataTable Role_DeleteById(RoleBase roleBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@ID", roleBase.ID)
                                         };
                Common.Set_Procedures("Role_DeleteById");
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

        #region Users_InsertUpdate
        public DataTable Users_InsertUpdate(UserBase userBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@ID", userBase.ID),
                                            new MyParameter("@FirstName", userBase.FirstName),
                                            new MyParameter("@LastName", userBase.LastName),
                                            new MyParameter("@Password", userBase.Password),
                                            new MyParameter("@PasswordDate", userBase.PasswordDate),
                                            new MyParameter("@UserCanChangePassword", userBase.UserCanChangePassword),
                                            new MyParameter("@Skills", userBase.Skills),
                                            new MyParameter("@UnitID", userBase.UnitID),
                                            new MyParameter("@RegNumber", userBase.RegNumber),
                                            new MyParameter("@IsDispatchable", userBase.IsDispatchable),
                                            new MyParameter("@Initials", userBase.Initials),
                                            new MyParameter("@EMail", userBase.EMail) ,
                                             new MyParameter("@UserName", userBase.UserName),
                                             new MyParameter("@UserGuid ", userBase.UserGuid),
                                              new MyParameter("@Roles", userBase.Roles)
                                         };
                Common.Set_Procedures("Users_IU");
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

        public DataTable Users_Password_Update(UserBase userBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@UserName", userBase.UserName),                                            
                                            new MyParameter("@Password", userBase.Password)
                                         };
                Common.Set_Procedures("User_Password_update");
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


        #region method VerifyEmailAccount
        public DataTable VerifyEmailAccount(UserBase userBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {

                MyParameter[] myParams ={        
                                         
                                      new MyParameter("@UserGuid",userBase.UserGuid)
                               };
                Common.Set_Procedures("VerifyAccount");
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

        #region method CheckDuplicateUser
        public DataTable CheckDuplicateUser(string UserName, int? ID)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {

                MyParameter[] myParams ={
                                      new MyParameter("@UserName",UserName),
                                      new MyParameter("@ID",ID)
                               };
                Common.Set_Procedures("CheckDuplicateUser");
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

        #region Users_LoadAll
        public DataTable Users_LoadAll()
        {
            dtContainer = new DataTable();
            try
            {

                MyParameter[] myParams = { };
                Common.Set_Procedures("Users_LoadAll");
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

        #region User_LoadById
        public DataTable User_LoadById(UserBase userBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@ID", userBase.ID)
                                         };
                Common.Set_Procedures("User_LoadById");
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

        #region User_DeleteById
        public DataTable User_DeleteById(UserBase userBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@ID", userBase.ID)
                                         };
                Common.Set_Procedures("User_DeleteById");
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

        #region UserRoles_LoadAll
        public DataTable UserRoles_LoadAll()
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = { };
                Common.Set_Procedures("UserRoles_LoadAll");
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


        #region UserRole_IU
        public DataTable UserRole_IU(RoleBase roleBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@Id", roleBase.ID),
                                            new MyParameter("@RoleName",roleBase.RoleName)
                                         };
                Common.Set_Procedures("UserRoles_IU");
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

        #region UserRole_DeleteById
        public DataTable UserRole_DeleteById(RoleBase roleBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@ID", roleBase.ID)
                                         };
                Common.Set_Procedures("UserRole_DeleteById");
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
                                            new MyParameter("@UserId", roleBase.UserId),
                                            new MyParameter("@MenuId", roleBase.MenuName),
                                           
                                         };
                Common.Set_Procedures("GetPermissions_ByRoleId");
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
                Common.Set_Procedures("Permissions_IU");
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


        #region Login_Load
        public DataTable Login_Load(UserBase userBase)
        {
            dtContainer = new DataTable();
            try
            {

                MyParameter[] myParams = {
                                         new MyParameter("@UserName", userBase.UserName),
                                        new MyParameter("@Password", userBase.Password)
                                        };
                Common.Set_Procedures("SuperAdminLogin");
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


        #region Menus_LoadForSiteAdministrator
        public DataTable Menus_LoadForSiteAdministrator()
        {
            dtContainer = new DataTable();
            try
            {

                MyParameter[] myParams = { };
                Common.Set_Procedures("Menus_LoadForSiteAdministrator");
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

        #region SubMenu_LoadAll
        public DataTable SubMenu_LoadAll()
        {
            dtContainer = new DataTable();
            try
            {

                MyParameter[] myParams = { };
                Common.Set_Procedures("SubMenu_LoadAll");
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

        #region SubMenuPermissions
        public DataTable SubMenuPermissions(RoleBase roleBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                             new MyParameter("@RoleID", roleBase.ID)
                                         };
                Common.Set_Procedures("SubMenuPermissions");
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

        #region SubMenuPermission_IU
        public DataTable SubMenuPermission_IU(SubMenuBase subMenuBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@RoleID", subMenuBase.RoleID),
                                            new MyParameter("@ParentID",subMenuBase.ParentID),
                                            new MyParameter("@SubMenus",subMenuBase.Roles)
                                         };
                Common.Set_Procedures("SubMenuPermission_IU");
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
        // *DN
        public DataTable Corporate_update(CorporateBase corporateBase)
        {
            dtContainer = new DataTable();
            try
            {
                MyParameter[] myParams = {
                                            new MyParameter("@Corporate_logo", corporateBase.Corporate_logo),
                                             //AB New
                                             new MyParameter("@Customer_logo", corporateBase.Customer_logo),
                                             new MyParameter("@Corporate_background", corporateBase.Corporate_background),
                                              new MyParameter("@Corporate_back_type", corporateBase.Corporate_back_type),
                                               new MyParameter("@Corporate_action", corporateBase.Corporate_action)
                                         };
                Common.Set_Procedures("Corporate_update");
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
