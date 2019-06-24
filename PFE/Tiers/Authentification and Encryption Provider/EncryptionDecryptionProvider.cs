using System.Web.Configuration;
using System.Configuration;
using System;
using System.Security.Cryptography;
using System.Web.Mvc;

namespace PFE.Tiers.simple_Authentification_Security_Layer
{
    public class EncryptionDecryptionProvider
    {
        public EncryptionDecryptionProvider() { }

        public String CreateSalt(int size)
        {

            byte[] buffer = new byte[size];


            new RNGCryptoServiceProvider().GetBytes(buffer);

            return Convert.ToBase64String(buffer);
        }

        public String CreateHash(String passwrd, String staticSalt, String dynamicSalt)
        {
            byte[] plainPassNSalt = System.Text.Encoding.UTF8.GetBytes(passwrd + staticSalt + dynamicSalt);


            return Convert.ToBase64String(new SHA256Managed().ComputeHash(plainPassNSalt));
        }
    }
}