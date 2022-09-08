using BaseTypes.Enums;
using BaseTypes.Response;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Models.Entities;
using MongoDB.Repositories.Interfaces;

using ServiceContracts.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

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
                    Message = "Contact added successfully.",
                    RecordId = ct.Id
                };
            }
            catch (Exception ex)
            {
                return new ResponseBase()
                {
                    Success = false,
                    Message = "Could not add contact!",
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
                    Message = "Contact has been deleted successfully."

                };
            }
            catch (Exception ex)
            {
                return new ResponseBase()
                {
                    Success = false,
                    Message = "Failed to delete contact!",
                    Error = new Error(ex)
                };
            }
        }

        [HttpPost]
        public ResponseBase AddContactInfoByContactId(AddContactInfoByContactIdRequest request)
        {
            try
            {

                Task<Contact> task = _contactDataAccess.GetByIdAsync(request.ContactId);
                Contact contact = task.Result;

                if (contact.ContactInfos.Any(x => x.InfoType == request.ContactInfo.InfoType && x.InfoValue == request.ContactInfo.InfoValue))
                {
                    return new ResponseBase()
                    {
                        Success = false,
                        Error = new Error("Contact info has already been added!")
                    };
                }
                else
                {
                    contact.ContactInfos.Add(request.ContactInfo);
                    Task<Contact> taskUpdate = _contactDataAccess.UpdateAsync(request.ContactId, contact);
                    Contact ct = taskUpdate.Result;

                    return new ResponseBase()
                    {
                        Success = true,
                        Message = "The contact information has been successfully added."

                    };
                }


            }
            catch (Exception ex)
            {
                return new ResponseBase()
                {
                    Success = false,
                    Message = "Could not add contact!",
                    Error = new Error(ex)
                };
            }
        }

        [HttpPost]
        public ResponseBase DeleteContactInfo(DeleteContactInfo request)
        {
            try
            {

                Task<Contact> task = _contactDataAccess.GetAsync(x => x.Id == request.ContactId);
                Contact contact = task.Result;

                if (contact != null)
                {
                    ContactInfo contactInfo = contact.ContactInfos.FirstOrDefault(x => x.ContactInfoId == request.ContactInfoId);

                    if (contactInfo != null)
                    {
                        contact.ContactInfos.Remove(contactInfo);
                        Task<Contact> taskUpdate = _contactDataAccess.UpdateAsync(request.ContactId, contact);
                        Contact ct = taskUpdate.Result;

                        return new ResponseBase()
                        {
                            Success = true,
                            Message = "Contact information deleted successfully."

                        };
                    }
                    else
                    {
                        return new ResponseBase()
                        {
                            Success = false,
                            Message = "Failed to delete contact information!",
                            Error = new Error("Contact info couldn't be deleted. Contact info not found!")
                        };
                    }
                }
                else
                {
                    return new ResponseBase()
                    {
                        Success = false,
                        Message = "Failed to delete contact information!",
                        Error = new Error("Contact not found!")
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseBase()
                {
                    Success = false,
                    Message = "Failed to delete contact information!",
                    Error = new Error(ex)
                };
            }
        }

        [HttpGet]
        public ResponseList<Contact> GetContacts()
        {
            try
            {
                List<Contact> responseList = _contactDataAccess.Get().OrderBy(x => x.Name).OrderBy(x=>x.Surname).Select(x => new Contact
                {
                    UUId = x.UUId,
                    Name = x.Name,
                    Surname = x.Surname,
                    Corporation = x.Corporation

                }).ToList();

                if (responseList!=null)
                {
                    return new ResponseList<Contact>()
                    {
                        Success = true,
                        Message = "Contacts listed",
                        Data = responseList
                    };
                }
                else
                {
                    return new ResponseList<Contact>()
                    {
                        Success = true,
                        Message = "Doesn't have any contact.",
                        Data = responseList
                    };
                }

              
            }
            catch (Exception ex)
            {
                return new ResponseList<Contact>()
                {
                    Success = false,
                    Message = "contacts not listed!",
                    Error = new Error(ex)

                };
            }
        }

        [HttpGet]
        public ResponseList<Contact> GetContactsWithDetails()
        {
            try
            {
                List<Contact> responseList = _contactDataAccess.Get().OrderBy(x => x.Name).OrderBy(x => x.Surname).ToList();

                if (responseList != null)
                {
                    return new ResponseList<Contact>()
                    {
                        Success = true,
                        Message = "Contacts listed",
                        Data = responseList
                    };
                }
                else
                {
                    return new ResponseList<Contact>()
                    {
                        Success = true,
                        Message = "Doesn't have any contact.",
                        Data = responseList
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseList<Contact>()
                {
                    Success = false,
                    Message = "contacts not listed!",
                    Error = new Error(ex)

                };
            }
        }
    }
}
