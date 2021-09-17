using BirthdayAPI.Core.Domain.Abstractions.Repositories;
using BirthdayAPI.Core.Domain.Entities;
using BirthdayAPI.Core.Service.Query.Parameters;
using BirthdayAPI.Core.Service.Query.Sorting;
using BirthdayAPI.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Service.Repositories
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(ApplicationDbContext context, ISortHelper<Contact> sortHelper) : base(context, sortHelper)
        {

        }
        public async Task AddContact(Contact newContact)
        {
            await base.Add(newContact);
        }

        public bool ContactWithIdExists(int contactId)
        {
            return _context.Contacts.Any(c => c.ContactId == contactId);
        }

        public void EditContact(Contact contact)
        {
            base.Edit(contact);
        }

        public async Task<Contact> GetContactById(int id)
        {
            return await base.GetById(id);
        }

        public async Task<IEnumerable<Contact>> GetContacts(ContactParameters parameters)
        {
            var filteredContacts = base.FilterByCondition(c => (c.Date.Month >= parameters.MinMonth && c.Date.Month <= parameters.MaxMonth));
            ReduceQueryByName(ref filteredContacts, parameters.Name);
            filteredContacts = _sortHelper.ApplySort(filteredContacts, parameters.OrderBy);
            return await base.GetPagedResult(filteredContacts, parameters);
        }

        public void RemoveContact(Contact contact)
        {
            base.Remove(contact);
        }

        private void ReduceQueryByName(ref IQueryable<Contact> contacts, string name)
        {
            contacts = contacts.Where(c => c.Name.ToLower().Contains(name.ToLower()));
        }
    }
}
