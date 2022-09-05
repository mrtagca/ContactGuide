using System;
using System.Collections.Generic;
using System.Text;

namespace BaseTypes.Response
{
    public class ResponseData<T> : ResponseBase
    {
        public T Data { get; set; }
    }
}
