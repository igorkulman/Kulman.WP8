using System;

namespace Kulman.WP8.Interfaces
{
    public interface ICryptographyService
    {
        string GetMd5(String source);
        string Encrypt(string input, string password);
        string Decrypt(string input, string password);

    }
}
