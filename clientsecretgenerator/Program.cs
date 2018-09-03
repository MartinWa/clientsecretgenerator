using System;
using IdentityServer4.Models;

namespace clientsecretgenerator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var secret = Guid.NewGuid();
            if (args.Length > 0)
            {
                Guid.TryParse(args[0], out secret);
            }
            var secretString = secret.ToString();
            var hashString = secretString.Sha256();
            Console.WriteLine(secretString);
            Console.WriteLine(hashString);
        }
    }
}