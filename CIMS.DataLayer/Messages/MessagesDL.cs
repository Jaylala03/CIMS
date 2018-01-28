using CIMS.BaseLayer.Messages;
using CIMS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CIMS.DataLayer
{
    public class MessagesDL
    {

        DataTable dtContainer;
        DataSet dsContainer;

        #region Method Messages_Insert
        public DataTable Messages_Insert(MessagesBase messageBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@MessageId", messageBase.MessageID),
                                           new MyParameter("@MessageText", messageBase.MessageText),
                                            new MyParameter("@Description", messageBase.Description),
                                            new MyParameter("@DateSent", messageBase.DateSent)

                                        };
                Common.Set_Procedures("Messages_AddEdit");
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

        #region Method Messages_Sent
        public DataTable Messages_Sent(MessagesBase messageBase)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                            new MyParameter("@MessageID", messageBase.MessageID),
                                           new MyParameter("@MessageText", messageBase.MessageText),
                                            new MyParameter("@Description", messageBase.Description),
                                            new MyParameter("@DateSent", messageBase.DateSent),
                                           new MyParameter("@UserID", messageBase.UserID),
                                           new MyParameter("@SenderID", messageBase.SenderID),
                                            new MyParameter("@SentToSelf", messageBase.SentToSelf),
                                            new MyParameter("@Draft", messageBase.Draft)
                                        };
                Common.Set_Procedures("Message_Sent");
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

        #region Method Message_Received
        public DataTable Message_Received(MessageGroups messageGroups)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                   new MyParameter("@UserID",messageGroups.U_ID)
                                        };
                Common.Set_Procedures("Messages_Received");
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

        #region Method Messages_LoadByID
        public DataTable Message_LoadById(MessagesBase messages)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                    new MyParameter("@MessageID",messages.MessageID)
                                        };
                Common.Set_Procedures("Messages_LoadById");
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

        #region Method MessageRecipients_LoadByMessageID
        public DataTable MessageRecipients_LoadByMessageID(MessagesBase messages)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                    new MyParameter("@MessageID",messages.MessageID)
                                        };
                Common.Set_Procedures("MessageRecipients_LoadByMessageID");
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

        #region Method Messages_Delete
        public DataTable Messages_Delete(MessagesBase messages)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                           new MyParameter("@MessageID", messages.MessageID)
                                        };
                Common.Set_Procedures("Message_Delete");
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

        #region Method MessageGroups_LoadDistinctGroupName
        public DataTable MessageGroups_LoadDistinctGroupName()
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                        };
                Common.Set_Procedures("MessageGroups_LoadDistinctGroupName");
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

        #region Method MessageGroup_DeleteByUserID
        public DataTable MessageGroup_DeleteByUserID(MessageGroups messageGroups)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                         new MyParameter("@UserID",messageGroups.U_ID)
                                        };
                Common.Set_Procedures("MessageGroup_DeleteByUserID");
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

        #region Method MessageGroups_LoadByGroupName
        public DataTable MessageGroups_LoadByGroupName(MessageGroups messageGroups)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                         new MyParameter("@GroupName",messageGroups.GroupName)
                                        };
                Common.Set_Procedures("MessageGroups_LoadByGroupName");
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

        #region Method MessageGroups_Insert
        public DataTable MessageGroups_Insert(MessageGroups messageGroups)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                         new MyParameter("@UserID",messageGroups.UserID),
                                          new MyParameter("@GroupName",messageGroups.GroupName),
                                           new MyParameter("@U_ID",messageGroups.U_ID)
                                        };
                Common.Set_Procedures("MessageGroups_Insert");
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

        #region Method MessageGroups_DeleteByGroupName
        public DataTable MessageGroups_DeleteByGroupName(MessageGroups messageGroups)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                          new MyParameter("@GroupName",messageGroups.GroupName),
                                           new MyParameter("@U_ID",messageGroups.UserID)
                                        };
                Common.Set_Procedures("MessageGroups_DeleteByGroupName");
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


        #region Method MessageGroups_DeleteByGroup
        public DataTable MessageGroups_DeleteByGroup(MessageGroups messageGroups)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                          new MyParameter("@GroupName",messageGroups.GroupName)
                                        };
                Common.Set_Procedures("MessageGroups_DeleteByGroup");
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

        #region Method MessageGroups_AddEdit
        public DataTable MessageGroups_AddEdit(MessageGroups messageGroups)
        {
            dtContainer = new DataTable();
            dsContainer = new DataSet();
            try
            {
                MyParameter[] myParams ={
                                          new MyParameter("@GroupName",messageGroups.GroupName),
                                          new MyParameter("@GroupNameOld",messageGroups.OldGroupName)
                                        };
                Common.Set_Procedures("MessageGroups_AddEdit");
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






    }
}
