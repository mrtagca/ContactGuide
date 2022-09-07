using BaseTypes.Entities;
using BaseTypes.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MongoDB.Models.Entities
{
    public class ContactInfo : IContactInfo
    {
        [JsonIgnore]
        public string ContactInfoId { get; set; } = Guid.NewGuid().ToString();
        public InfoType InfoType { get; set; }
        public string InfoValue { get; set; }
    }
}
