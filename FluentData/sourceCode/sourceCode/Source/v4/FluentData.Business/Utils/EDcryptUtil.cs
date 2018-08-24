using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentData.Business.Utils
{
    public class EDcryptUtil
    {
        #region base64加密解密
        public static string EncodeBase64(string source)
        {

            if (string.IsNullOrEmpty(source)) return "";

            byte[] bytes = Encoding.UTF8.GetBytes(source);

            return Convert.ToBase64String(bytes);
        }

        public static string DecodeBase64(string base64String)
        {
            if (string.IsNullOrEmpty(base64String)) return "";

            byte[] bytes = Convert.FromBase64String(base64String);

            return Encoding.UTF8.GetString(bytes);
        } 
        #endregion
    }
}
