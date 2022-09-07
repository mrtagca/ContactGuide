using BaseTypes.Enums;
using BaseTypes.Response;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Models.Entities;
using MongoDB.Repositories.Interfaces;

using ServiceContracts.Request;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost]
        public ResponseBase AddContact(AddContactRequest request)
        {
            try
            {
                Contact cnt = request.Contact;
                cnt.UUId = Guid.NewGuid().ToString();

                Task<Contact> task = _contactDataAccess.AddAsync(cnt);
                Contact ct = task.Result;

                return new ResponseBase()
                {
                    Success = true,
                    RecordId = ct.Id
                };
            }
            catch (Exception ex)
            {
                return new ResponseBase()
                {
                    Success = false,
                    Error = new Error(ex)
                };
            }
        }

        [HttpPost]
        public ResponseBase DeleteContactById(DeleteContactByIdRequest request)
        {
            try
            {
                Task<Contact> task = _contactDataAccess.DeleteAsync(request.Id);
                Contact ct = task.Result;

                return new ResponseBase()
                {
                    Success = true,

                };
            }
            catch (Exception ex)
            {
                return new ResponseBase()
                {
                    Success = false,
                    Error = new Error(ex)
                };
            }
        }
    }
}
