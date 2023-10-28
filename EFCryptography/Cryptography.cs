using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCryptography
{
    public class Cryptography : ValueConverter<string, string>
    {
        public Cryptography() : base(toDb => Encrypt(toDb), fromDb => Decrypt(fromDb)) { }

        private static string Encrypt(string plainText)
        {
            using (var aes = Aes.Create())
            {
                aes.IV = AesConfiguration().Item1;
                aes.Key = AesConfiguration().Item2;

                using var encryptor = aes.CreateEncryptor();

                var inputBuffer = Encoding.UTF8.GetBytes(plainText);
                var buffer = encryptor.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);

                plainText = Convert.ToBase64String(buffer);
            }

            return plainText;
        }

        private static string Decrypt(string cipherText)
        {
            using (var aes = Aes.Create())
            {
                aes.IV = AesConfiguration().Item1;
                aes.Key = AesConfiguration().Item2;

                using var decryptor = aes.CreateDecryptor();

                var inputBuffer = Encoding.UTF8.GetBytes(cipherText);
                var buffer = decryptor.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);

                cipherText = Convert.ToBase64String(buffer);
            }

            return cipherText;
        }

        private static Tuple<byte[], byte[]> AesConfiguration()
        {
            var IV = new byte[16];
            var Key = Encoding.UTF8.GetBytes("b14ca5898a4e4133bbce2ea2315a1916");

            return new(IV, Key);
        }
    }
}
