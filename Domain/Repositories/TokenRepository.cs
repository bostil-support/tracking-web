using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tracking.Web.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        public string Decrypt(string data)
        {
            string token = null;
            byte[][] keys = GetHashKeys("kww5jOy6011XIPAf5Muw0i7DcJMFvAEy");

            token = DecryptStringFromBytes_Aes(data, keys[0], keys[1]);

            return token;

        }
        private byte[][] GetHashKeys(string key)
        {
            byte[][] result = new byte[2][];
            Encoding enc = Encoding.UTF8;
            SHA256 sha2 = new SHA256CryptoServiceProvider();
            byte[] rawKey = enc.GetBytes(key);
            byte[] rawIV = enc.GetBytes(key);
            byte[] hashKey = sha2.ComputeHash(rawKey);
            byte[] hashIV = sha2.ComputeHash(rawIV);
            Array.Resize(ref hashIV, 16);
            result[0] = hashKey;
            result[1] = hashIV;
            return result;
        }

        private string DecryptStringFromBytes_Aes(string cipherTextString, byte[] Key, byte[] IV)
        {
            byte[] cipherText = Convert.FromBase64String(cipherTextString);
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            string plaintext = null;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }
        public bool IsBase64Encoded(string cipherTextString)
        {
            try
            {
                byte[] cipherText = Convert.FromBase64String(cipherTextString);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

