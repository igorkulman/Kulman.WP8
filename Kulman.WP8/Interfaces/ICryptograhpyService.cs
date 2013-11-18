using System;

namespace Kulman.WP8.Interfaces
{
    public interface ICryptograhpyService
    {
        string GetMd5String(String source);
        string Encrypt(string input, string password);
        string Decrypt(string input, string password);

    }
}
