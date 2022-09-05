using System;
using System.Collections.Generic;
using System.Text;

namespace BaseTypes.Response
{
    public class ResponseBase : IDisposable
    {
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
