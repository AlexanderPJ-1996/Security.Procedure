using System;
using System.Text;
using System.Security.Cryptography;

namespace Security.Procedure
{
    public class SHA // Encrypt text with SHA (Secure Hash Algorithm): MD5, SHA-1, SHA-256 and SHA-512
    {
        private static String EncryptHash(String Input, HashAlgorithm Method)
        {
            Byte[] TextBytes = Encoding.UTF8.GetBytes(Input);
            Byte[] HashBytes = Method.ComputeHash(TextBytes);
            StringBuilder SB = new StringBuilder();
            foreach (Byte B in HashBytes)
            {
                SB.Append(B.ToString("X2"));
            }
            return SB.ToString();
        }
        // Encrypt text with MD5
        public static String MD5Encrypt(String Input)
        {
            MD5 Md5 = MD5.Create();
            return EncryptHash(Input, Md5);
        }
        // Encrypt text with SHA-1
        public static String SHA1Encrypt(String Input)
        {
            SHA1 Sha1 = SHA1.Create();
            return EncryptHash(Input, Sha1);
        }
        // Encrypt text with SHA-256
        public static String SHA256Encrypt(String Input)
        {
            SHA256 sha256 = SHA256.Create();
            return EncryptHash(Input, sha256);
        }
        // Encrypt text with SHA-512
        public static String SHA512Encrypt(String Input)
        {
            SHA512 sha512 = SHA512.Create();
            return EncryptHash(Input, sha512);
        }
    }
}
