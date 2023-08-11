using System;
using System.Security.Cryptography;
using System.Text;


namespace LagDaemon.Akka_MUD.Core.Utilities
{
    public class CryptoFunctions
    {
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
