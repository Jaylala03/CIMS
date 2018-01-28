using System;
using CIMS.BaseLayer;
using CIMS.BaseLayer.Messages;
using CIMS.DataLayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.ActionLayer.Messages
{
    public class MessagesAction
    {
        #region Declaration
        MessagesDL messageDL = new MessagesDL();
        ActionResult actionResult = new ActionResult();
        #endregion

        #region Method Messages_Insert
        public ActionResult Messages_Insert(MessagesBase messageBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = messageDL.Messages_Insert(messageBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion

        #region Method Messages_Sent
        public ActionResult Messages_Sent(MessagesBase messageBase)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = messageDL.Messages_Sent(messageBase);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion

        #region Method Message_Received
        public ActionResult Message_Received(MessageGroups messageGroups)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = messageDL.Message_Received(messageGroups);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion

        #region Method Message_LoadByID
        public ActionResult Message_LoadByID(MessagesBase message)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = messageDL.Message_LoadById(message);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return actionResult;
        }
        #endregion

        #region Method Messages_Delete
        public ActionResult Messages_Delete(MessagesBase message)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = messageDL.Messages_Delete(message);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return actionResult;
        }
        #endregion

        #region Method MessageRecipients_LoadByMessageID
        public ActionResult MessageRecipients_LoadByMessageID(MessagesBase message)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = messageDL.MessageRecipients_LoadByMessageID(message);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return actionResult;
        }
        #endregion

        #region Method MessageGroups_LoadDistinctGroupName
        public ActionResult MessageGroups_LoadDistinctGroupName()
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = messageDL.MessageGroups_LoadDistinctGroupName();
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion

        #region Method MessageGroup_DeleteByUserID
        public ActionResult MessageGroup_DeleteByUserID(MessageGroups mssageGroups)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = messageDL.MessageGroup_DeleteByUserID(mssageGroups);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion

        #region Method MessageGroups_LoadByGroupName
        public ActionResult MessageGroups_LoadByGroupName(MessageGroups mssageGroups)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = messageDL.MessageGroups_LoadByGroupName(mssageGroups);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion

        #region Method MessageGroups_Insert
        public ActionResult MessageGroups_Insert(MessageGroups mssageGroups)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = messageDL.MessageGroups_Insert(mssageGroups);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion

        #region Method MessageGroups_DeleteByGroupName
        public ActionResult MessageGroups_DeleteByGroupName(MessageGroups mssageGroups)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = messageDL.MessageGroups_DeleteByGroupName(mssageGroups);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion

        #region Method MessageGroups_DeleteByGroup
        public ActionResult MessageGroups_DeleteByGroup(MessageGroups mssageGroups)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = messageDL.MessageGroups_DeleteByGroup(mssageGroups);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion

        #region Method MessageGroups_AddEdit
        public ActionResult MessageGroups_AddEdit(MessageGroups mssageGroups)
        {
            actionResult = new ActionResult();
            try
            {
                actionResult.dtResult = messageDL.MessageGroups_AddEdit(mssageGroups);
                if (actionResult.dtResult != null && actionResult.dtResult.Rows.Count > 0)
                {
                    actionResult.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return actionResult;
        }
        #endregion




    }
}
