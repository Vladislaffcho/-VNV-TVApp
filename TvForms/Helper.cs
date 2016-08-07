﻿namespace TVAppVNV
{
    public static class Helper
    {
        /// <summary>
        /// Parse string to int
        /// </summary>
        /// <param name="source"></param>
        /// <returns>
        /// If unable parse to int or double returns 0
        /// </returns>
        public static int GetInt(this string source)
        {
            int i;
            if (int.TryParse(source, out i))
            {
                return i;
            }
            return -1;
        }
    }
}