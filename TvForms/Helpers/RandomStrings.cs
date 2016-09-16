using System;
using System.Linq;

namespace TvForms
{
    // this helper is for generating random security string
    // for reseting user password
    public static class RandomStrings
    {
        // this method will generate security string which will me send to user's email
        public static string ReceivedResetCode()
        {
            Random random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 10)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        // this method will generate temporary password for a user
        // after a received security string via email has been confirmed
        public static string TempPassword()
        {
            Random random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, 10)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}