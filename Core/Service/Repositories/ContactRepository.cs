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
        public async Task<Contact> AddContact(Contact newContact)
        {
            return await base.Add(newContact);
        }

        public bool ContactWithIdExists(int contactId)
        {
            return _context.Contacts.Any(c => c.ContactId == contactId);
        }

        public Contact EditContact(Contact contact)
        {
            return base.Edit(contact);
        }

        public async Task<Contact> GetContactById(int id)
        {
            return await base.GetById(id);
        }

        public async Task<IEnumerable<Contact>> GetAllContacts(ContactParameters parameters)
        {
            var filteredContacts = base.FilterByCondition(c => (c.Date.Month >= parameters.MinMonth && c.Date.Month <= parameters.MaxMonth));
            ReduceQueryByName(ref filteredContacts, parameters.Name);
            filteredContacts = _sortHelper.ApplySort(filteredContacts, parameters.OrderBy);
            return await base.GetPagedResult(filteredContacts, parameters);
        }

        public async Task<IEnumerable<Contact>> GetContactsOfProfile(int profileId, ContactParameters parameters)
        {
            var filteredContacts = base.FilterByCondition(c => (c.Date.Month >= parameters.MinMonth && c.Date.Month <= parameters.MaxMonth));
            filteredContacts = filteredContacts.Where(c => c.ProfileId == profileId);
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
            if (contacts.Any() == false || string.IsNullOrWhiteSpace(name))
                return;

            contacts = contacts.Where(c => c.Name.ToLower().Contains(name.ToLower()));
        }

        //private async Task<IEnumerable<Contact>> GetUpcomingContacts(int profileId, ContactParameters parameters)
        //{
        //    var currDate = DateTime.Now;
        //    var contacts = _context.Contacts
        //        .Select(c => new
        //        {
        //            cal = (currDate - CalculateDate(c.Date)).Seconds
        //        })
        //        .Where(c => c.cal > 0)
        //        .OrderBy(c => c.cal);
                

        //    return await base.GetPagedResult(contacts, parameters);
        //}

        //private DateTime CalculateDate(DateTime date)
        //{
        //    var currDate = DateTime.Now;
        //    int newYear = ((date.Month < currDate.Month) || (date.Month == currDate.Month && date.Day < currDate.Day)) ?
        //        currDate.Year + 1 : currDate.Year;

        //    // (Y, M, D)
        //    return new DateTime(newYear, date.Month, date.Day);
        //}
    }
}
