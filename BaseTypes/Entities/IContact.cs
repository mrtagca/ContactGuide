using BaseTypes.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseTypes.Entities
{
    public interface IContact
    {
        public string UUId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Corporation { get; set; }
    }

    
}
