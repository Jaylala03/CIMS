using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Threading;
using System.Globalization;
using System.Xml.Linq;
using System.Web.Mvc;
using CIMS.BaseLayer.Admin;
using CIMS.ActionLayer.Admin;
using System.Data;
using CIMS.Helpers;


namespace CIMS.Models
{
    public class CheckPermissions
    {
        public static string[] permission(string menu, int userId)
        {

            AdminAction adminAction = new AdminAction();
            CIMS.BaseLayer.ActionResult actionResult = new CIMS.BaseLayer.ActionResult();
            
            List<Menus> PermissionList = new List<Menus>();

           
                    RoleBase roleBase = new RoleBase();
                    roleBase.UserId = Convert.ToInt32(userId);
                    roleBase.MenuName=menu;
                    actionResult = adminAction.Menus_LoadByRoleId(roleBase);
                    if (actionResult.IsSuccess)
                    {
                        var permission = CommonMethods.ConvertTo<Menus>(actionResult.dtResult);
                        if (permission[0].PermissionType > 0)
                        {
                            string[] result = { "true", permission[0].PermissionType.ToString() };
                            return result;
                        }
                    }
             
                   
                
                
            
            string[] failResult = { "false", "0" };
            return failResult;
        }

        public static bool permissionMenu(string menu, int userId)
        {

            AdminAction adminAction = new AdminAction();
            CIMS.BaseLayer.ActionResult actionResult = new CIMS.BaseLayer.ActionResult();

            List<Menus> PermissionList = new List<Menus>();


            RoleBase roleBase = new RoleBase();
            roleBase.UserId = Convert.ToInt32(userId);
            roleBase.MenuName = menu;
            actionResult = adminAction.Menus_LoadByRoleId(roleBase);
            if (actionResult.IsSuccess)
            {
                var permission = CommonMethods.ConvertTo<Menus>(actionResult.dtResult);
                if (permission[0].PermissionType > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}