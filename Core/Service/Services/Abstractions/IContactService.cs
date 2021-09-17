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
        Task<ContactDto> CreateContact(int profileId, ContactDto contact);
        Task<ContactDto> UpdateContact(int profileId, int contactId, ContactDto contact);
        Task<ContactDto> RemoveContact(int profileId, int contactId);
    }
}
