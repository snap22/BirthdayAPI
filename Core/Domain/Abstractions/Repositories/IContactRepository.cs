using BirthdayAPI.Core.Domain.Entities;
using BirthdayAPI.Core.Service.Query.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Domain.Abstractions.Repositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetContacts(ContactParameters parameters);
        Task<Contact> GetContactById(int id);
        Task AddContact(Contact newContact);
        void EditContact(Contact contact);
        void RemoveContact(Contact contact);
        bool ContactWithIdExists(int contactId);
    }
}
