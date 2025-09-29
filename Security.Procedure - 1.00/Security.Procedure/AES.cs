using System;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace Security.Procedure
{
    public class AES // Encrypt and decrypt with AES (Advanced Encryption Standard)
    {
        // Encrypt text with AES
        public static String AESEncrypt(String Input, String EncryptionKey, String InitializationVector)
        {
            String Output = String.Empty;
            String ErrorM = "Warning, the encryption key and/or initialization vector is not valid. Please verify that they have a valid length and characters. Encryption Key: 16, 24 or 32 characters. Initialization Vector: 16 characters.";
            if (EncryptionKey.Length == 16 || EncryptionKey.Length == 24 || EncryptionKey.Length == 32)
            {
                if (InitializationVector.Length == 16)
                {
                    using (Aes AESAlg = Aes.Create())
                    {
                        AESAlg.Key = Encoding.UTF8.GetBytes(EncryptionKey);
                        AESAlg.IV = Encoding.UTF8.GetBytes(InitializationVector);
                        ICryptoTransform Encryptor = AESAlg.CreateEncryptor(AESAlg.Key, AESAlg.IV);
                        using (MemoryStream MSe = new MemoryStream())
                        {
                            using (CryptoStream CSe = new CryptoStream(MSe, Encryptor, CryptoStreamMode.Write))
                            {
                                using (StreamWriter SWe = new StreamWriter(CSe))
                                {
                                    SWe.Write(Input);
                                }
                                Output = Convert.ToBase64String(MSe.ToArray());
                            }
                        }
                    }
                }
                else
                {
                    Output = ErrorM;
                }
            }
            else
            {
                Output = ErrorM;
            }
            return Output;
        }
        // Decrypting AES encrypted text
        public static String AESDecrypt(String Input, String EncryptionKey, String InitializationVector)
        {
            String Output = String.Empty;
            String ErrorM = "Warning, the encryption key and/or initialization vector is not valid. Please verify that they have a valid length and characters. Encryption Key: 16, 24 or 32 characters. Initialization Vector: 16 characters.";
            if (EncryptionKey.Length == 16 || EncryptionKey.Length == 24 || EncryptionKey.Length == 32)
            {
                if (InitializationVector.Length == 16)
                {
                    using (Aes AESAlg = Aes.Create())
                    {
                        AESAlg.Key = Encoding.UTF8.GetBytes(EncryptionKey);
                        AESAlg.IV = Encoding.UTF8.GetBytes(InitializationVector);
                        ICryptoTransform Decryptor = AESAlg.CreateDecryptor(AESAlg.Key, AESAlg.IV);
                        using (MemoryStream MSd = new MemoryStream(Convert.FromBase64String(Input)))
                        {
                            using (CryptoStream CSd = new CryptoStream(MSd, Decryptor, CryptoStreamMode.Read))
                            {
                                using (StreamReader SRd = new StreamReader(CSd))
                                {
                                    Output = SRd.ReadToEnd();
                                }
                            }
                        }
                    }
                }
                else
                {
                    Output = ErrorM;
                }
            }
            else
            {
                Output = ErrorM;
            }
            return Output;
        }
    }
}
