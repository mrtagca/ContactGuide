using BaseTypes.Response;
using ServiceContracts.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceContracts.Interfaces
{
    public interface IContactApi
    {
        public ResponseBase AddContact(AddContactRequest request);
    }
}
