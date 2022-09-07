using BaseTypes.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaseTypes.Entities
{
    public interface IContactInfo
    {
        [Required]
        public InfoType InfoType { get; set; }
        [Required]
        public string InfoValue { get; set; }
    }
}
