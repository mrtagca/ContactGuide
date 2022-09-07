using BaseTypes.Entities;
using MongoDB.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServiceContracts.Request
{
    public class AddContactRequest
    {
        public Contact Contact { get; set; }
    }
}
