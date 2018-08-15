using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Security.Cryptography;

namespace FluentData.Business.Utils
{
    public class MD5Util
    {
        /// <summary>
        /// 转为md5字符串
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string GetMD5(string source)
        {
            if (string.IsNullOrEmpty(source)) return string.Empty;

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] input = Encoding.UTF8.GetBytes(source);
            byte[] output = md5.ComputeHash(input);

            return BitConverter.ToString(output).Replace("-","").ToLower();
        }
    }
}
