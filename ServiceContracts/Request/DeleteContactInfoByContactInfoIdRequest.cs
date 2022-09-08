using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceContracts.Request
{
    public class DeleteContactInfo
    {
        public string ContactId { get; set; }
        public string ContactInfoId { get; set; }
    }
}
