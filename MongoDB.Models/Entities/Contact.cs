﻿using BaseTypes.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDB.Models.Entities
{
    public class Contact : MongoDbEntity,IContact 
    { 
        public string UUId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Corporation { get; set; }
        public List<ContactInfo> ContactInfos { get; set; }
    }

}
