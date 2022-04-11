using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Task3
{
    class HmacFather
    {
        private static Random random = new Random();

        private static readonly string alphabet = "0123456789ABCDEF";
        public static string GetKey()
        {
            var key = new char[64];
            for (int i = 0; i < key.Length; i++) key[i] = alphabet[random.Next(alphabet.Length)];
            return new string(key);
        }
        public static string GetHmac(string str, string key)
        {
            byte[] bkey = Encoding.Default.GetBytes(key);
            using (var hmac = new HMACSHA256(bkey))
            {
                byte[] bstr = Encoding.Default.GetBytes(str);
                var bhash = hmac.ComputeHash(bstr);
                return BitConverter.ToString(bhash).Replace("-", string.Empty).ToLower();
            }
        }
    }
}
