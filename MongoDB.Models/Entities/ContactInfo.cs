using BaseTypes.Entities;
using BaseTypes.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDB.Models.Entities
{
    public class ContactInfo : IContactInfo
    {
        public InfoType InfoType { get; set; }
        public string InfoValue { get; set; }
    }
}
