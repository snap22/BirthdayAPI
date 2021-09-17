using BirthdayAPI.Core.Service.DTOs;
using BirthdayAPI.Core.Service.Query.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Service.Services.Abstractions
{
    public interface IContactService
    {
        Task<ContactDto> GetContact(int profileId, int contactId);
        Task<IEnumerable<ContactDto>> GetContacts(int profileId, ContactParameters parameters);
        Task<ContactDto> CreateContact(ContactDto contact);
        Task<ContactDto> UpdateContact(int contactId, ContactDto contact);
        Task<ContactDto> RemoveContact(int contactId);
    }
}
