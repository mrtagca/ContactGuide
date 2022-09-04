using BaseTypes.Enums;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Models.Entities;
using MongoDB.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactController : Controller
    {
        public IContactDataAccess _contactDataAccess;

        public ContactController(IContactDataAccess contactDataAccess)
        {
          _contactDataAccess = contactDataAccess;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Contact contact = new Contact();
            contact.UUId = Guid.NewGuid().ToString();
            contact.Id = ObjectId.GenerateNewId().ToString();
            contact.Name = "Mert";
            contact.Surname = "Ağca";
            contact.Corporation = "Test";
            List<ContactInfo> ContactInfos = new List<ContactInfo>();
            ContactInfo cf1 = new ContactInfo { InfoType = InfoType.Email, InfoValue = "mrtagcaa@gmail.com" };
            ContactInfo cf2 = new ContactInfo { InfoType = InfoType.PhoneNumber, InfoValue = "5313745671" };
            ContactInfo cf3 = new ContactInfo { InfoType = InfoType.Location, InfoValue = "Istanbul" };

            ContactInfos.Add(cf1);
            ContactInfos.Add(cf2);
            ContactInfos.Add(cf3);
            contact.ContactInfos = ContactInfos;

            Task<Contact> task = _contactDataAccess.AddAsync(contact);

            Contact ct = task.Result;

            return View();
        }
    }
}
