using System;
using System.Text;

namespace Security.Procedure
{
    public class Base64 // Encrypt and decrypt with Base64
    {
        // Encrypt text with Base64
        public static String Base64Encrypt(String Input)
        {
            Byte[] Bytes = Encoding.Unicode.GetBytes(Input);
            String Output = Convert.ToBase64String(Bytes);
            return Output;
        }
        // Decrypting Base64 encrypted text
        public static String Base64Decrypt(String Input)
        {
            Byte[] Bytes = Convert.FromBase64String(Input);
            String Output = Encoding.Unicode.GetString(Bytes);
            return Output;
        }
    }
}
