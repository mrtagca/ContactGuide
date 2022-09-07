using BaseTypes.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace BaseTypes.Entities
{
    public interface IContact
    {
        [JsonIgnore]
        public string UUId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string Corporation { get; set; }
    }

    
}
