using MongoDB.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceContracts.Request
{
    public class AddContactInfoByContactIdRequest
    {
        public string ContactId { get; set; }
        public ContactInfo ContactInfo { get; set; }
    }
}
