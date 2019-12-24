using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace YinJianEShop.pwdMD5
{
    public static class PasswdMD5Locker
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="input">需要加密的字符串</param>
        /// <param name="encoding">加密字符串的编码</param>
        /// <returns></returns>
        public static string MD5Encrypt(string input, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            System.Security.Cryptography.MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(encoding.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        /// <summary>
        /// 验证加密的字符串是否为明文得到
        /// </summary>
        /// <param name="input">原明文</param>
        /// <param name="hash">MD5哈希</param>
        /// <param name="encoding">字符编码</param>
        /// <returns></returns>
        public static bool MD5Verify(string input, string hash, Encoding encoding = null)
        {
            string hashOfInput = MD5Encrypt(input, encoding); // Create a StringComparer and compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            return 0 == comparer.Compare(hashOfInput, hash);
        }
    }
}