using BaseTypes.Entities;
using BaseTypes.Enums;
using BaseTypes.Response;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Models.Entities;
using MongoDB.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ReportService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReportController : Controller
    {
        IReportDataAccess _reportDataAccess;
        IContactDataAccess _contactDataAccess;

        public ReportController(IReportDataAccess reportDataAccess, IContactDataAccess contactDataAccess)
        {
            _reportDataAccess = reportDataAccess;
            _contactDataAccess = contactDataAccess;
        }

        [HttpGet]
        public ResponseData<LocationReport> GetLocationReport()
        {

            List<Contact> contacts = _contactDataAccess.Get().ToList();

            LocationReport locationReport = new LocationReport();
            List<LocationReportItem> reportItems = new List<LocationReportItem>();

            List<string> locationList = new List<string>();

            //var results = from contact in contacts
            //              group contact by contact.ContactInfos.Where(x => x.InfoType == InfoType.Location).Select(x => x.InfoValue)
            //into individualProducts
            //              select individualProducts;

            foreach (var item in contacts)
            {
                locationList.Add(item.ContactInfos.Where(x => x.InfoType == InfoType.Location).Select(x => x.InfoValue).Single());
            }

            locationList = locationList.Distinct().ToList();

            List<Contact> contactList = new List<Contact>();

            foreach (var loc in locationList)
            {
                contactList.AddRange(contacts.Where(x => x.ContactInfos == x.ContactInfos.Where(x => x.InfoValue == loc)));
            }

            


            foreach (var ct in contacts)
            {
                locationList = ct.ContactInfos.Where(x => x.InfoType == InfoType.Location).Select(x => x.InfoValue).ToList();
                break;
            }

            //mongo db bozuldu. windows service start olmuyor

            return new ResponseData<LocationReport>();
        }
    }
}
