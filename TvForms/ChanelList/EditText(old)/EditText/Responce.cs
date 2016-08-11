using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EditText
{
    public class Responce
    {
        private string error = String.Empty;
        private string errFunc = String.Empty;
        private string errorChanel = String.Empty;
        private bool isError = false;

        public bool IsError
        {
            get { return isError; }
            set { isError = value; }
        }
        
        public string ErrorMessage
        {
            get { return error; }
            set { error = value; }
        }

        public string ErrorFunc
        {
            get { return errFunc; }
            set { errFunc = value; }
        }

        public string ErrorChanel
        {
            get { return errorChanel; }
            set { errorChanel = value; }
        }

    }
}
