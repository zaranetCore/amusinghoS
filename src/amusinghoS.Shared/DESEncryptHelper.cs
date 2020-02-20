using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace amusinghoS.Shared
{
    public class DESEncryptHelper
    {
        public static string Encrypt(string value, string encryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] inputByteArray = Encoding.UTF8.GetBytes(value);
                using (DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider())
                {
                    using (MemoryStream mStream = new MemoryStream())
                    {
                        CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                        cStream.Write(inputByteArray, 0, inputByteArray.Length);
                        cStream.FlushFinalBlock();
                        return Convert.ToBase64String(mStream.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                //throw new Exception("Error when encrypting data", ex);
                throw new ArgumentException(ex.Message, ex);
            }
        }
        public static string Decrypt(string value, string encryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] inputByteArray = Convert.FromBase64String(value);
                using (DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider())
                {
                    using (MemoryStream mStream = new MemoryStream())
                    {
                        CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                        cStream.Write(inputByteArray, 0, inputByteArray.Length);
                        cStream.FlushFinalBlock();
                        return Encoding.UTF8.GetString(mStream.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                //throw new Exception("Error when decrypting data", ex);
                throw new ArgumentException(ex.Message, ex);
            }
        }
    }
}
