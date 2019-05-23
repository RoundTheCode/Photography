using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Photography.Infrastructure.Helpers
{
    public static class StringHelper
    {
        public static string ToMD5(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return value;
            }

            using (var md5 = MD5.Create())
            {
                byte[] data = md5.ComputeHash(Encoding.Default.GetBytes(value));
                var md5String = "";

                for (var i = 0; i < data.Length; i++)
                {
                    md5String += data[i].ToString("x2");
                }

                return md5String;
            }
        }
    }
}
