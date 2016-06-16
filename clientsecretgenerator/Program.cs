using System;
using System.Security.Cryptography;
using System.Text;

namespace clientsecretgenerator
{
    static class Program
    {
        private static void Main()
        {
            var guid = Guid.NewGuid().ToString();
            var secret = guid.Sha256();
            Console.WriteLine(guid);
            Console.WriteLine(secret);
        }
    }

    // Code taken from https://github.com/IdentityServer/IdentityServer3
    internal static class Extensions
    {
        public static string Sha256(this string input)
        {
            if (input.IsMissing()) return string.Empty;

            using (var sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                var hash = sha.ComputeHash(bytes);

                return Convert.ToBase64String(hash);
            }
        }

        private static bool IsMissing(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
    }
}
