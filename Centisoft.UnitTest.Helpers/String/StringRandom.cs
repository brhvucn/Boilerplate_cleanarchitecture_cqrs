using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.UnitTest.Helpers.String
{
    public static class StringRandom
    {
        public static string GetRandomString(int length)
        {
            Random r = new Random();

            const string allowedChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789!@$?_-";
            char[] chars = new char[length];

            for (int i = 0; i < length; i++)
            {
                chars[i] = allowedChars[r.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }
    }
}
