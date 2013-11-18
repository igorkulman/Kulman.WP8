using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Kulman.WP8.Code;
using Kulman.WP8.Interfaces;

namespace Kulman.WP8.Services
{
    public class CryptographyService : ICryptograhpyService
    {        
        public string GetMd5String(string source)
        {
           return MD5.GetMD5(source);
        }

        public string Encrypt(string input, string password)
        {
            return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(input), password));
        }

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

        public string Decrypt(string input, string password)
        {
            byte[] res = Decrypt(Convert.FromBase64String(input), password);
            return Encoding.UTF8.GetString(res, 0, res.Length);
        }

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
