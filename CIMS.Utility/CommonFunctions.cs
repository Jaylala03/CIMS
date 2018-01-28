using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;
using System.Web;
using System.Collections;
using System.IO;

namespace CIMS.Utility
{
    public class CommonFunctions
    {
        #region Method Encrypt
        public static string EncryptTripleDES(string Plaintext, string Key)
        {
            byte[] Buffer = new byte[0];
            System.Security.Cryptography.TripleDESCryptoServiceProvider DES = new System.Security.Cryptography.TripleDESCryptoServiceProvider();

            System.Security.Cryptography.MD5CryptoServiceProvider hashMD5 = new System.Security.Cryptography.MD5CryptoServiceProvider();

            DES.Key = hashMD5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(Key));

            DES.Mode = System.Security.Cryptography.CipherMode.ECB;

            System.Security.Cryptography.ICryptoTransform DESEncrypt = DES.CreateEncryptor();

            Buffer = System.Text.ASCIIEncoding.ASCII.GetBytes(Plaintext);

            string TripleDES = Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));

            return TripleDES;

        }
        #endregion

        //Decryption Method

        #region Method Decrypt
        public static string DecryptTripleDES(string base64Text, string Key)
        {
            byte[] Buffer = new byte[0];
            System.Security.Cryptography.TripleDESCryptoServiceProvider DES = new System.Security.Cryptography.TripleDESCryptoServiceProvider();

            System.Security.Cryptography.MD5CryptoServiceProvider hashMD5 = new System.Security.Cryptography.MD5CryptoServiceProvider();

            DES.Key = hashMD5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(Key));

            DES.Mode = System.Security.Cryptography.CipherMode.ECB;

            System.Security.Cryptography.ICryptoTransform DESDecrypt = DES.CreateDecryptor();

            Buffer = Convert.FromBase64String(base64Text);

            string DecTripleDES = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));

            return DecTripleDES;

        }
        #endregion

        public static string GetPdfPath()
        {
            return ReadWebConfig("pdfPath");
        }
        public static string ReadWebConfig(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString();
        }

        public static string ReadQueryString(string key, string defVal)
        {
            try
            {
                
                return  HttpContext.Current.Request.QueryString[key].ToString();
            }
            catch
            {
                return "";
            }
        }


        public static ArrayList GetInvoicePDFs(string path, string SearchPattern)
        {
            ArrayList FileList = new ArrayList();
            if (Directory.Exists(path))
            {
                DirectoryInfo folder = new DirectoryInfo(path);
                foreach (System.IO.FileInfo f in folder.GetFiles(SearchPattern))
                {
                    if (Extensions.Left(Extensions.Right(f.Name, 5), 1).ToLower() != "i")
                    {
                        FileList.Add(f.FullName);
                    }
                }
                folder = null;
            }
            return FileList;
        }

     

      
      

    }

}
static class Extensions
{
    /// <summary>
    /// Get substring of specified number of characters on the right.
    /// </summary>
    public static string Right(this string value, int length)
    {
        if (String.IsNullOrEmpty(value)) return string.Empty;

        return value.Length <= length ? value : value.Substring(value.Length - length);
    }

    public static string Left(this string value, int maxLength)
    {
        if (string.IsNullOrEmpty(value)) return value;
        maxLength = Math.Abs(maxLength);

        return (value.Length <= maxLength
               ? value
               : value.Substring(0, maxLength)
               );
    }
}

