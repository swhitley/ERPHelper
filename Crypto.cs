using System;
using System.Text;
using System.Security.Cryptography;

namespace ERPHelper
{
    class Crypto
    {
        public static string Protect(string stringToEncrypt)
        {
            return Convert.ToBase64String(
                ProtectedData.Protect(
                    Encoding.UTF8.GetBytes(stringToEncrypt)
                    , null
                    , DataProtectionScope.CurrentUser));
        }

        public static string Unprotect(string encryptedString)
        {
            if (String.IsNullOrEmpty(encryptedString))
            {
                return "";
            }
            return Encoding.UTF8.GetString(
                ProtectedData.Unprotect(
                    Convert.FromBase64String(encryptedString)
                    , null
                    , DataProtectionScope.CurrentUser));
        }
    }
}
