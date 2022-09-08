using System;
using System.Collections.Generic;
using System.Text;

namespace BaseTypes.Response
{
    public class ResponseBase : IDisposable
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string RecordId { get; set; }
        public Error Error { get; set; }

        public ResponseBase()
        {

        }

        public void Dispose()
        {
            GC.Collect();
            GC.SuppressFinalize(this);
        }
    }
}
