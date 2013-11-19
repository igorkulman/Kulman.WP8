using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Kulman.WP8.Code;
using Kulman.WP8.Interfaces;

namespace Kulman.WP8.Services
{
    /// <summary>
    /// Cryprography service
    /// </summary>
    public class CryptographyService : ICryptographyService
    {
        /// <summary>
        /// Computes MD5 hash of a string
        /// </summary>
        /// <param name="source">Strign to compute has for</param>
        /// <returns>MD5 has</returns>
        public string GetMd5(string source)
        {
           return MD5.GetMD5(source);
        }

        /// <summary>
        /// Encrypts a given string with a given password
        /// </summary>
        /// <param name="input">Input string</param>
        /// <param name="password">Password</param>
        /// <returns>Encrypted string</returns>
        public string Encrypt(string input, string password)
        {
            return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(input), password));
        }

        /// <summary>
        /// Encrypts a given byte array with a given password
        /// </summary>
        /// <param name="input">Input given byte array</param>
        /// <param name="password">Password</param>
        /// <returns>Encrypted given byte array</returns>
        private byte[] Encrypt(byte[] input, string password)
        {
            var pdb = new Rfc2898DeriveBytes(password,
                                             new byte[] { 0x43, 0x87, 0x23, 0x72, 0x45, 0x56, 0x68, 0x14, 0x62, 0x84 });
            var ms = new MemoryStream();
            Aes aes = new AesManaged();
            aes.Key = pdb.GetBytes(aes.KeySize / 8);
            aes.IV = pdb.GetBytes(aes.BlockSize / 8);
            var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(input, 0, input.Length);
            cs.Close();
            return ms.ToArray();
        }

        /// <summary>
        /// Dencrypts a given string with a given password
        /// </summary>
        /// <param name="input">Input string</param>
        /// <param name="password">Password</param>
        /// <returns>Dencrypted string</returns>
        public string Decrypt(string input, string password)
        {
            byte[] res = Decrypt(Convert.FromBase64String(input), password);
            return Encoding.UTF8.GetString(res, 0, res.Length);
        }

        /// <summary>
        /// Dencrypts a given byte array with a given password
        /// </summary>
        /// <param name="input">Input given byte array</param>
        /// <param name="password">Password</param>
        /// <returns>Dencrypted given byte array</returns>
        private byte[] Decrypt(byte[] input, string password)
        {
            var pdb = new Rfc2898DeriveBytes(password,
                                             new byte[] { 0x43, 0x87, 0x23, 0x72, 0x45, 0x56, 0x68, 0x14, 0x62, 0x84 });
            var ms = new MemoryStream();
            Aes aes = new AesManaged();
            aes.Key = pdb.GetBytes(aes.KeySize / 8);
            aes.IV = pdb.GetBytes(aes.BlockSize / 8);
            var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(input, 0, input.Length);
            cs.Close();
            return ms.ToArray();
        }
    }
}
