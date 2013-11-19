using System;

namespace Kulman.WP8.Interfaces
{
    /// <summary>
    /// Interface definition for cryptography service
    /// </summary>
    public interface ICryptographyService
    {
        /// <summary>
        /// Computes MD5 hash of a string
        /// </summary>
        /// <param name="source">Strign to compute has for</param>
        /// <returns>MD5 has</returns>
        string GetMd5(String source);

        /// <summary>
        /// Encrypts a given string with a given password
        /// </summary>
        /// <param name="input">Input string</param>
        /// <param name="password">Password</param>
        /// <returns>Encrypted string</returns>
        string Encrypt(string input, string password);

        /// <summary>
        /// Dencrypts a given string with a given password
        /// </summary>
        /// <param name="input">Input string</param>
        /// <param name="password">Password</param>
        /// <returns>Dencrypted string</returns>
        string Decrypt(string input, string password);

    }
}
