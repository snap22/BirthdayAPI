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
        Task<IEnumerable<Contact>> GetAllContacts(ContactParameters parameters);
        Task<IEnumerable<Contact>> GetContactsOfProfile(int profileId, ContactParameters parameters);
        Task<Contact> GetContactById(int id);
        Task<Contact> AddContact(Contact newContact);
        Contact EditContact(Contact contact);
        void RemoveContact(Contact contact);
        bool ContactWithIdExists(int contactId);
    }
}
