using System;

namespace TvForms
{
    public static class Helper
    {
        public static int GetInt(this string source)
        {
            int i;
            if (Int32.TryParse(source, out i))
            {
                return i;
            }
            return -1;
        }
    }
}