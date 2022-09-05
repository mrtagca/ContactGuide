using System;
using System.Collections.Generic;
using System.Text;

namespace BaseTypes.Response
{
    public class Error
    {

        public Error(Exception ex)
        {
            this.Message = ex.Message;
            this.StackTrace = ex.StackTrace;
        }

        public Error(string errorMessage)
        {
            this.Message = errorMessage;
        }
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
}
