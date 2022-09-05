using System;
using System.Collections.Generic;
using System.Text;

namespace BaseTypes.Request
{
    public class RequestBase : IDisposable
    {
        public RequestBase()
        {

        }

        public void Dispose()
        {
            GC.Collect();
            GC.SuppressFinalize(this);
        }
    }
}
