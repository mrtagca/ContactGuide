using MongoDB.Bson;
using MongoDB.Models.Entities;
using MongoDB.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace Test.ConsoleApp
{
    public class Program
    {
        public static IContactDataAccess _contactDataAccess;


        public Program(IContactDataAccess contactDataAccess)
        {
            _contactDataAccess = contactDataAccess;
        }
        void Main(string[] args)
        {
            Contact contact = new Contact();
            contact.Id = ObjectId.GenerateNewId().ToString();
            contact.Name = "Mert";
            contact.Surname = "Ağca";


            Task<Contact> task = _contactDataAccess.AddAsync(contact);


        }
    }
}
