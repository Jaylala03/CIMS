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
using CIMS.ActionLayer.Account;


namespace CIMS.Models
{
    public class CheckAdminPermissions
    {
        public static string[] permission(string menu, int userId)
        {

            AccountAction accountAction = new AccountAction();
            CIMS.BaseLayer.ActionResult actionResult = new CIMS.BaseLayer.ActionResult();
            UserBase userBase = new UserBase();
            string userRoles = "";
            userBase.ID = Convert.ToInt32(userId);
            actionResult = accountAction.Customer_LoadById();
            if (actionResult.IsSuccess)
            {
                DataRow dr = actionResult.dtResult.Rows[0];
               var menuNames= userRoles = dr["MenuNames"] != DBNull.Value ? dr["MenuNames"].ToString() : "";
               string[] blankArray = { };
                var menuArray =(menuNames!=null? menuNames.Split(','):blankArray);
                if(menuArray.Contains(menu))
                {
                    string[] result={"true","15"};
                    return result;
                }
            }
            string[] failResult = { "false", "0" };
            return failResult;
        }

        public static bool permissionMenu(string menu)
        {
            AccountAction accountAction = new AccountAction();
            CIMS.BaseLayer.ActionResult actionResult = new CIMS.BaseLayer.ActionResult();
           
            string userRoles = "";
           
            actionResult = accountAction.Customer_LoadById();
            if (actionResult.IsSuccess)
            {
                DataRow dr = actionResult.dtResult.Rows[0];
               var menuNames= userRoles = dr["MenuNames"] != DBNull.Value ? dr["MenuNames"].ToString() : "";
               string[] blankArray = { };
                var menuArray =(menuNames!=null? menuNames.Split(','):blankArray);
                if(menuArray.Contains(menu))
                {
                    return true;
                }
            }
           
            return false;
        }
    }
}