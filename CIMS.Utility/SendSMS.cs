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
    public class SendSMS
    {
        #region Properties
        private static string apiURI = ConfigurationManager.AppSettings["apiURI"].ToString();
        private static string apiKEY = ConfigurationManager.AppSettings["apiKEY"].ToString();
        private static string apiSENDERID = ConfigurationManager.AppSettings["apiSENDERID"].ToString();
        private static string apiSECRET = ConfigurationManager.AppSettings["apiSECRET"].ToString();
        #endregion

        #region Method SendSMSToPhone
        public static string SendSMSToPhone(string mobileNumber, string messageBody)
        {
            var jsonResponce = "";
            try
            {
                if (mobileNumber != string.Empty)
                {
                    mobileNumber = "1" + Regex.Replace(mobileNumber, @"[^\d]", "");
                    apiURI += "?api_key={0}&api_secret={1}&from={2}&to={3}&text={4}";
                    apiURI = string.Format(apiURI, apiKEY, apiSECRET, apiSENDERID, mobileNumber, messageBody);
                    jsonResponce = new WebClient().DownloadString(apiURI);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return jsonResponce;
        }
        #endregion
    }
}
