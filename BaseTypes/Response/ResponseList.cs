using System;
using System.Collections.Generic;
using System.Text;

namespace BaseTypes.Response
{
    public class ResponseList<T> : ResponseBase
    {
        public List<T> Data { get; set; }
    }
}
