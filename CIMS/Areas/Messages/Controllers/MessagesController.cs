using CIMS.ActionLayer.Messages;
using CIMS.BaseLayer.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CIMS.Models;
using System.Data;
using CIMS.Utility;
using CIMS.Helpers;
using CIMS.ActionLayer.Employee;
using CIMS.ActionLayer.Admin;
using CIMS.Filters;

namespace CIMS.Areas.Messages.Controllers
{
    [CheckLogin]
    [CheckPermissionAttribute]
    public class MessagesController : Controller
    {
        DataSet dsResult = new DataSet();
        DataTable drResult = new DataTable();
        MessagesAction messagesAction = new MessagesAction();
        CIMS.BaseLayer.Messages.MessagesBase messages = new CIMS.BaseLayer.Messages.MessagesBase();
        CIMS.BaseLayer.Messages.MessageGroups messagesGroups = new CIMS.BaseLayer.Messages.MessageGroups();
        CIMS.BaseLayer.ActionResult actionResult = new CIMS.BaseLayer.ActionResult();
        MessageGroups messageGroupBase = new MessageGroups();
        AdminAction adminAction = new AdminAction();

        // GET: Messages/Messages

        #region Message Index
        public ActionResult Index(int? messageID = 0)
        {
            MessagesModel model = new MessagesModel();
            List<MessagesModel> messagesList = new List<MessagesModel>();

            MessageGroups messageGroup = new MessageGroups();
            MessageGroupsModel messageGroupModel = new MessageGroupsModel();
            List<MessageGroupsModel> msgGroupList = new List<MessageGroupsModel>();
            actionResult = messagesAction.MessageGroups_LoadDistinctGroupName();

            if (actionResult.IsSuccess)
            {
                msgGroupList = (from DataRow row in actionResult.dtResult.Rows
                                select new MessageGroupsModel
                                {
                                    GroupName = row["GroupName"] != DBNull.Value ? row["GroupName"].ToString() : ""
                                }).ToList();
            }
            model.msgGroupList = msgGroupList;

            if (messageID.Value > 0)
            {
                messages.MessageID = messageID.Value;
                actionResult = messagesAction.Message_LoadByID(messages);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    DataRow row = actionResult.dtResult.Rows[0];

                    model.MessageID = row["MessageID"] != DBNull.Value ? Convert.ToInt32(row["MessageID"]) : 0;
                    model.Description = row["Description"] != DBNull.Value ? row["Description"].ToString() : "";
                    model.MessageText = row["MessageText"] != DBNull.Value ? row["MessageText"].ToString() : "";
                }
            }

            //MessageGroupsModel msgGroupModel = new MessageGroupsModel();
            List<UserModel> userList = new List<UserModel>();
            UserModel userModel = new UserModel();
            actionResult = adminAction.Users_LoadAll();
            userList = (from DataRow row in actionResult.dtResult.Rows
                        select new UserModel
                        {
                            UserID = row["ID"] != DBNull.Value ? row["ID"].ToString() : "",
                            UserName = row["UserName"] != DBNull.Value ? row["UserName"].ToString() : "",
                            FirstName = row["FirstName"] != DBNull.Value ? row["FirstName"].ToString() : "",
                            FullName = row["FullName"] != DBNull.Value ? row["FullName"].ToString() : "",
                        }).ToList();
            model.userList = userList;
           

            return View(model);
        }
        #endregion

        #region MessageDistribution
        public ActionResult MessageDistribution()
        {
            MessageGroupsModel model = new MessageGroupsModel();
            List<UserModel> userList = new List<UserModel>();
            UserModel userModel = new UserModel();
            actionResult = adminAction.Users_LoadAll();
            userList = (from DataRow row in actionResult.dtResult.Rows
                        select new UserModel
                        {
                            UserID = row["ID"] != DBNull.Value ? row["ID"].ToString() : "",
                            UserName = row["UserName"] != DBNull.Value ? row["UserName"].ToString() : "",
                            FirstName = row["FirstName"] != DBNull.Value ? row["FirstName"].ToString() : "",
                            FullName = row["FullName"] != DBNull.Value ? row["FullName"].ToString() : "",
                        }).ToList();
            model.userList = userList;
            return View(model);
        }
        #endregion

        #region Show Messages
        public ActionResult MessageReceive(int? messageID = 0)
        {
            MessagesModel model = new MessagesModel();
            List<MessagesModel> MessagesList = new List<MessagesModel>();

            messagesGroups.U_ID = Convert.ToInt32(Session["UserId"]);
            actionResult = messagesAction.Message_Received(messagesGroups);
            if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
            {
                MessagesList = (from DataRow row in actionResult.dtResult.Rows
                                select new MessagesModel
                                {
                                    MessageID = row["MessageID"] != DBNull.Value ? Convert.ToInt32(row["MessageID"]) : 0,
                                    DateSent = row["DateSent"] != DBNull.Value ? row["DateSent"].ToString() : "",
                                    FirstName = row["FirstName"] != DBNull.Value ? row["FirstName"].ToString() : "",
                                    LastName = row["LastName"] != DBNull.Value ? row["LastName"].ToString() : "",
                                    Description = row["Description"] != DBNull.Value ? row["Description"].ToString() : "",
                                    MessageText = row["MessageText"] != DBNull.Value ? row["MessageText"].ToString() : "",
                                    Draft = row["Draft"] != DBNull.Value ? row["Draft"].ToString() : "",
                                    SentToSelf = row["SentToSelf"] != DBNull.Value ? row["SentToSelf"].ToString() : ""
                                }).ToList();
            }
            model.MessagesList = MessagesList;
            return View(model);
        }
        #endregion

        #region View Message ByID
        public JsonResult ViewMessage(int? messageID = 0)
        {
            string jsonString = string.Empty;
            try
            {
                messages.MessageID = Convert.ToInt32(messageID);
                actionResult = messagesAction.Message_LoadByID(messages);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString = actionResult.dtResult.Rows[i]["MessageText"].ToString();
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

        #region Delete Message
        public JsonResult DeleteMessage(int messageID)
        {
            string jsonString = string.Empty;
            try
            {
                messages.MessageID = messageID;
                actionResult = messagesAction.Messages_Delete(messages);

                if (actionResult.IsSuccess)
                {
                    jsonString = "Success";
                }
                else
                {
                    jsonString = "Fail";
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

        #region ShowRecipients
        public JsonResult ShowRecipients(int messageID)
        {
            string jsonString = string.Empty;
            try
            {
                messages.MessageID = messageID;
                actionResult = messagesAction.MessageRecipients_LoadByMessageID(messages);
                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {
                        jsonString = "<tr><td>" + actionResult.dtResult.Rows[i]["FirstName"].ToString()
                                        + " " + actionResult.dtResult.Rows[i]["LastName"].ToString()
                                        + "</td><tr>";
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

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult MessageInsert(MessagesModel model, FormCollection fc)
        {
            messages.MessageID = model.MessageID;
            messages.MessageText = model.MessageText.Trim();
            messages.Description = model.Description.Trim();
            messages.DateSent = DateTime.Now.ToString();
            messages.SenderID = Session["UserId"].ToString().Trim();
            messages.Draft = fc["hdfDraftValue"].ToString().Trim();
            
            if (fc["hdfDraftValue"].ToString() != "1")
            {
                if (fc["hdnMembers"].ToString() == Session["UserId"].ToString())
                {
                    messages.SentToSelf = "1";
                }
                else
                {
                    messages.SentToSelf = "0";
                }
            }
            else
            {
                messages.SentToSelf = "0";
            }

            if (fc["hdnMembers"].ToString().Contains(","))
            {
                string[] sUserID = fc["hdnMembers"].ToString().Split(',');

                for (int i = 0; i < sUserID.Length; i++)
                {
                    messages.UserID = sUserID[i];
                    actionResult = messagesAction.Messages_Sent(messages);
                }
            }
            else
            {
                messages.UserID = fc["hdnMembers"].ToString().Trim();
                actionResult = messagesAction.Messages_Sent(messages);
            }
            
            
            if (actionResult.IsSuccess)
            {
                TempData["SuccessMessage"] = "Successfully Saved !!";
            }
            else
            {
                TempData["ErrorMessage"] = "Error in Request !!";
            }
            return RedirectToAction("Index");

            //messages.MessageID = model.MessageID;
            //messages.MessageText = model.MessageText;
            //messages.Description = model.Description;
            //messages.DateSent = DateTime.Now.ToString();
            //if (model.MessageID > 0)
            //{
            //    actionResult = messagesAction.Messages_Insert(messages);
            //}
            //else
            //{
            //    actionResult = messagesAction.Messages_Insert(messages);
            //    if (actionResult.IsSuccess)
            //    {
            //        int result = actionResult.dtResult.Rows[0][0] != DBNull.Value ? Convert.ToInt32(actionResult.dtResult.Rows[0][0]) : 0;
            //        model.MessageID = result;
            //    }
            //}

            //if (actionResult.IsSuccess)
            //{
            //    TempData["SuccessMessage"] = "Successfully Saved !!";
            //}
            //else
            //{
            //    TempData["ErrorMessage"] = "Error in Request !!";
            //}

            //return RedirectToAction("index");
        }


        [HttpPost]
        public JsonResult MessageGroups_Insert(string GroupName, string UserID)
        {
            string json = string.Empty;
            try
            {
                if (UserID.Length > 0)
                {
                    string[] UserIDList = UserID.Split(',');
                    for (int i = 0; i <= UserIDList.Length - 1; i++)
                    {
                        messageGroupBase.GroupName = GroupName;
                        messageGroupBase.UserID = UserIDList[i];
                        messageGroupBase.U_ID = Convert.ToInt32(UserIDList[i]);
                        actionResult = messagesAction.MessageGroups_Insert(messageGroupBase);
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

        #region Delete GroupName 
        [HttpPost]
        public JsonResult MessageGroups_DeleteByGroupName(string GroupName, string userID)
        {
            string json = string.Empty;
            try
            {
                messageGroupBase.GroupName = GroupName;
                messageGroupBase.UserID = userID;
                actionResult = messagesAction.MessageGroups_DeleteByGroupName(messageGroupBase);
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

        #region  MessageGroups_AddEdit 
        [HttpPost]
        public JsonResult MessageGroups_AddEdit(string GroupName, string oldGroupName)
        {
            string json = string.Empty;
            try
            {
                messageGroupBase.GroupName = GroupName;
                messageGroupBase.OldGroupName = oldGroupName;
                actionResult = messagesAction.MessageGroups_AddEdit(messageGroupBase);
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

        #region Delete GroupName 
        [HttpPost]
        public JsonResult MessageGroups_DeleteByGroup(string GroupName)
        {
            string json = string.Empty;
            try
            {
                messageGroupBase.GroupName = GroupName;
                actionResult = messagesAction.MessageGroups_DeleteByGroup(messageGroupBase);
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

        [HttpPost]
        public JsonResult MessageGroup_DeleteByUserID(string GroupName, string UserID)
        {
            string json = string.Empty;
            try
            {
                messageGroupBase.GroupName = GroupName;
                messageGroupBase.UserID = UserID;
                messageGroupBase.U_ID = Convert.ToInt32(Session["UserId"]);
                actionResult = messagesAction.MessageGroup_DeleteByUserID(messageGroupBase);
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

        public JsonResult LoadMessageDistribution()
        {
            string jsonString = string.Empty;
            try
            {
                MessageGroups messageGroup = new MessageGroups();
                MessageGroupsModel messageGroupModel = new MessageGroupsModel();
                List<MessageGroupsModel> messageGroupList = new List<MessageGroupsModel>();
                actionResult = messagesAction.MessageGroups_LoadDistinctGroupName();

                //messageGroupList = (from DataRow row in actionResult.dtResult.Rows
                //                    select new MessageGroupsModel
                //                    {
                //                        GroupName = row["GroupName"] != DBNull.Value ? row["GroupName"].ToString() : "",
                //                    }).ToList();
                //messageGroupModel.MessageGroupsList = messageGroupList;

                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {

                        jsonString += " <option value = " + actionResult.dtResult.Rows[i]["GroupName"] + "  onclick = \"Fillgroup('" + actionResult.dtResult.Rows[i]["GroupName"] + "'); \" > " + actionResult.dtResult.Rows[i]["GroupName"] + " </ option >";

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


        public JsonResult Load_MessageMembers(string GroupName)
        {
            string jsonString = string.Empty;
            try
            {
                MessageGroups messageGroup = new MessageGroups();
                MessageGroupsModel messageGroupModel = new MessageGroupsModel();
                List<MessageGroupsModel> messageGroupList = new List<MessageGroupsModel>();
                messageGroup.GroupName = GroupName;
                actionResult = messagesAction.MessageGroups_LoadByGroupName(messageGroup);

                if (actionResult.IsSuccess && actionResult.dtResult.Rows.Count > 0)
                {
                    for (int i = 0; i < actionResult.dtResult.Rows.Count; i++)
                    {

                        jsonString += " <option value = " + actionResult.dtResult.Rows[i]["ID"] + " > " + actionResult.dtResult.Rows[i]["FullName"] + " </ option >";

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



    }
}