using BaseTypes.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseTypes.Entities
{
    public interface IContactInfo
    {
        public InfoType InfoType { get; set; }
        public string InfoValue { get; set; }
    }
}
