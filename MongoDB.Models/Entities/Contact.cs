using MongoDB.BaseTypes.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDB.Models.Entities
{
    public class Contact 
    {
        public Guid UUId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Corporation { get; set; }
        public List<ContactInfo> ContactInfos { get; set; }
        public DateTime CreatedDate { get; set; }

    }

    public class ContactInfo
    {
        public InfoType InfoType { get; set; }
        public string InfoValue { get; set; }
    }
}
