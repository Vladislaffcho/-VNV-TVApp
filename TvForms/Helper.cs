using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvForms
{
    public static class Helper
    {

        /// <summary>
        /// Parse string to int
        /// </summary>
        /// <param name="source"></param>
        /// <returns>
        /// If unable parse to int return -1
        /// </returns>
        
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
