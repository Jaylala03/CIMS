using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Web;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Net;
using System.Data;

namespace CIMS.Utility
{
    public class SendMail
    {
        #region Properties
        private static string userName = ConfigurationManager.AppSettings["userName"].ToString();
        private static string password = ConfigurationManager.AppSettings["password"].ToString();
        private static string mailFrom = ConfigurationManager.AppSettings["mailFrom"].ToString();
        private static string mailTo = ConfigurationManager.AppSettings["mailTo"].ToString();
        private static string bccAddress = ConfigurationManager.AppSettings["bccAddress"].ToString();
        private static string smtpServer = ConfigurationManager.AppSettings["smtpServer"].ToString();
        private static string testMode = ConfigurationManager.AppSettings["testMode"].ToString();
        private static string site = ConfigurationManager.AppSettings["site"].ToString();
        private static string commaDelimCCs = "";
        static MailAddress frm = new MailAddress(mailFrom, "Accounting Software");
        #endregion

        #region Method : SendEmail by Mohd
        public static void SendEmail(string subject, string message, bool isBodyHtml)
        {
            MailMessage msg = new MailMessage(mailFrom, mailTo, subject, message);
            msg.IsBodyHtml = isBodyHtml;
            SetBCCAddress(msg);
            SetUserCredentialAndProcessMail(msg);
        }
        #endregion

        #region Method : SendEmail by Mohd
        public static void SendEmail(string emailto, string mailsubject, string emailmessage, bool isBodyHtml)
        {
            MailMessage msg = new MailMessage(mailFrom, emailto, mailsubject, emailmessage);
            msg.IsBodyHtml = isBodyHtml;
            SetBCCAddress(msg);
            SetUserCredentialAndProcessMail(msg);
        }
        #endregion

        #region Method : SendEmail by Mohd
        public static void SendResetPasswordEmail(string toMail, string subject, string message, bool isBodyHtml)
        {
            MailMessage msg = new MailMessage(mailFrom, toMail, subject, message);

            msg.IsBodyHtml = isBodyHtml;
            SetBCCAddress(msg);
            SetUserCredentialAndProcessMail(msg, toMail);
        }
        #endregion

        #region Method : AccountConfirmationMail
        public static bool ConfirmationMail(string Email, string FirstName, string guid)
        {
            try
            {
                bool isBodyHtml = true;
                string subject = "Registration - CIMS";

                string content = ReadFile("AccountConfirmationEmailTemplate.txt");
                string message = string.Format(content, FirstName, guid);

                MailMessage msg = new MailMessage(mailFrom, Email, subject, message);


                msg.IsBodyHtml = isBodyHtml;
                SetBCCAddress(msg);
                SetUserCredentialAndProcessMail(msg, Email);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        #endregion

        #region Method : SendEmail by Mohd
        public static bool SendEmailReciept(string [] mailTo, string filepath)
        {
            string subject = "Marina Publication Payment Reciept.";
            string content = ReadFile("Reciept.txt");
            string message = content;
            bool isBodyHtml = true;
            using (MailMessage msg = new MailMessage())
            {
                msg.From = new MailAddress(mailFrom);
                foreach (string strMailTo in mailTo)
                {
                    msg.To.Add(strMailTo);
                }
                if (filepath != string.Empty)
                {
                    Attachment attach = new Attachment(filepath);
                    msg.Attachments.Add(attach);
                }
                msg.Subject = subject;
                msg.Body = message;
                msg.IsBodyHtml = isBodyHtml;

                SetBCCAddress(msg);
                SetUserCredentialAndProcessMail(msg);
                return true;
            }

        }
        #endregion

        #region Method : UserConfirmationMail
        public static bool UserConfirmationMail(string Email, string FirstName, string token)
        {
            try
            {
                bool isBodyHtml = true;
                string subject = "User Profile - Marina Publications";

                string content = ReadFile("Profile.txt");
                string message = string.Format(content, FirstName, token, site);

                MailMessage msg = new MailMessage(mailFrom, Email, subject, message);


                msg.IsBodyHtml = isBodyHtml;
                SetBCCAddress(msg);
                SetUserCredentialAndProcessMail(msg, Email);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        #endregion

        #region Method : TransactionMail
        public static bool TransactionMail(string Email, string FirstName, string token)
        {
            try
            {
                bool isBodyHtml = true;
                string subject = "Transaction - Marina Publications";

                string content = ReadFile("Transaction.txt");
                string message = string.Format(content,FirstName,  token, site);

                MailMessage msg = new MailMessage(mailFrom, Email, subject, message);


                msg.IsBodyHtml = isBodyHtml;
                SetBCCAddress(msg);
                SetUserCredentialAndProcessMail(msg, Email);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        #endregion

        #region Method : SendEmail by Mohd
        public static bool pramotionalmails(string[] mailTo, string message,string subject,string filepath)
        {
            bool isBodyHtml=true;
          
            using (MailMessage msg = new MailMessage())
            {
                msg.From = new MailAddress(mailFrom);
                foreach (string strMailTo in mailTo)
                {
                    msg.To.Add(strMailTo);
                }
                if (filepath != string.Empty)
                {
                    Attachment attach = new Attachment(filepath);
                    msg.Attachments.Add(attach);
                }
                msg.Subject = subject;
                msg.Body = message;
                msg.IsBodyHtml = isBodyHtml;

                SetBCCAddress(msg);
                SetUserCredentialAndProcessMail(msg);
                return true;
            }
        }
        #endregion

        #region Method SetUserCredentialAndProcessMail
        private static void SetUserCredentialAndProcessMail(MailMessage msg, string mailTo)
        {
            NetworkCredential cred = new NetworkCredential(userName, password);
            SmtpClient mailClient = testMode == "1" ? new SmtpClient(smtpServer, 587) : new SmtpClient(smtpServer, 25);
            mailClient.EnableSsl = testMode == "1" ? true : false;
            mailClient.UseDefaultCredentials = false;
            mailClient.Credentials = cred;
            try
            {
                if (testMode == "1")
                {
                    MailMessage mailMessage = new MailMessage(mailFrom, mailTo, msg.Subject, msg.Body);
                    mailMessage.IsBodyHtml = msg.IsBodyHtml;
                    if (msg.Attachments != null && msg.Attachments.Count > 0)
                    {
                        AttachmentCollection attachment = msg.Attachments;
                        foreach (Attachment item in attachment)
                        {
                            mailMessage.Attachments.Add(item);
                        }
                    }
                    mailClient.Send(mailMessage);
                }
                else
                {
                    mailClient.Send(msg);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region SendForgotPasswordEmail
        public static bool SendForgotPasswordEmail(string emailid, string passwordreset_token)
        {
            try
            {
                MailAddress to = new MailAddress(emailid);
                MailMessage message = new MailMessage(frm, to);
                message.IsBodyHtml = true;
                message.Subject = "Forgot Password - Kids Cool Ride";
                string content = ReadFile("ForgotPasswordEmailTemplate.txt");
                message.Body = string.Format(content, passwordreset_token);
                SetUserCredentialAndProcessMail(message, emailid);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Method SendEmail
        public static void SendEmail(string mailTo, string subject, string message, bool isBodyHtml, string path)
        {
            using (MailMessage msg = new MailMessage(mailFrom, mailTo, subject, message))
            {
                msg.IsBodyHtml = isBodyHtml;
                if (path != null)
                {
                    Attachment attach = new Attachment(path);
                    msg.Attachments.Add(attach);

                }
                SetBCCAddress(msg);
                SetUserCredentialAndProcessMail(msg);
            }
        }
        #endregion

        #region Method : SendEmail by Mohd
        public static void SendEmail(string[] mailTo, string subject, string message, bool isBodyHtml)
        {
            using (MailMessage msg = new MailMessage())
            {
                msg.From = new MailAddress(mailFrom);
                foreach (string strMailTo in mailTo)
                {
                    msg.To.Add(strMailTo);
                }
                msg.Subject = subject;
                msg.Body = message;
                msg.IsBodyHtml = isBodyHtml;

                //if (path != null)
                //{
                //    Attachment attach = new Attachment(path);
                //    msg.Attachments.Add(attach);

                //}

                SetBCCAddress(msg);
                SetUserCredentialAndProcessMail(msg);
            }
        }
        #endregion        

        #region Method : SendEmail by Mohd
        public static void SendEmail(string mailTo, string subject, string message, bool isBodyHtml, DataTable lstAttachment)
        {
            MailMessage msg = new MailMessage(mailFrom, mailTo, subject, message);
            msg.IsBodyHtml = isBodyHtml;
            if (lstAttachment != null)
            {
                if (lstAttachment.Rows.Count > 0)
                {
                    foreach (DataRow item in lstAttachment.Rows)
                    {
                        Attachment attach = new Attachment(item["FileFullPath"].ToString());
                        msg.Attachments.Add(attach);
                    }
                }
            }
            SetBCCAddress(msg);
            SetUserCredentialAndProcessMail(msg);

        }
        #endregion
        #region Method : EventSendEmail by Mohd
        public static void EventSendEmail(string mailTo, string subject, string message, bool isBodyHtml, string lstAttachment)
        {
            MailMessage msg = new MailMessage(mailFrom, mailTo, subject, message);
            msg.IsBodyHtml = isBodyHtml;

            Attachment attach = new Attachment(lstAttachment.ToString());
             msg.Attachments.Add(attach);
                  
            SetBCCAddress(msg);
            SetUserCredentialAndProcessMail(msg);

        }
        #endregion


        #region Method SetUserCredentialAndProcessMail
        private static void SetUserCredentialAndProcessMail(MailMessage msg)
        {
            NetworkCredential cred = new NetworkCredential(userName, password);
            SmtpClient mailClient = testMode == "1" ? new SmtpClient(smtpServer, 587) : new SmtpClient(smtpServer, 26);
            mailClient.EnableSsl = testMode == "1" ? true : false;
            mailClient.UseDefaultCredentials = false;
            mailClient.Credentials = cred;
            try
            {
                if (testMode == "1")
                {
                    MailMessage mailMessage = new MailMessage(mailFrom, msg.To.ToString(), msg.Subject, msg.Body);
                    mailMessage.IsBodyHtml = msg.IsBodyHtml;

                    if (msg.Attachments != null && msg.Attachments.Count > 0)
                    {
                        AttachmentCollection attachment = msg.Attachments;
                        foreach (Attachment item in attachment)
                        {
                            mailMessage.Attachments.Add(item);
                        }
                    }
                    mailClient.Send(mailMessage);
                }
                else
                {
                    mailClient.Send(msg);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion  

        #region Method SetBCCAddress
        private static void SetBCCAddress(MailMessage msg)
        {
            if (commaDelimCCs != "")
                msg.CC.Add(commaDelimCCs);
            if (bccAddress.Trim() != "")
            {
                string[] bccAddresses = bccAddress.Split(',');
                if (bccAddresses.Length > 0)
                {
                    for (int i = 0; i <= bccAddresses.Length - 1; i++)
                    {
                        msg.Bcc.Add(bccAddresses[i]);
                    }
                }
            }
        }
        #endregion

        #region ReadFile
        public static string ReadFile(string filename)
        {
            try
            {
                string abspath = System.Web.Hosting.HostingEnvironment.MapPath("~/Content/Template/");
                string filepath = System.IO.Path.Combine(abspath, filename);
                string content = string.Empty;
                using (System.IO.StreamReader rdr = new System.IO.StreamReader(filepath))
                {
                    content = rdr.ReadToEnd();
                    content = content.Replace("@info", site);
                }
                return content;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        #endregion
    }
}
