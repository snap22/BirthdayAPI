using AutoMapper;
using BirthdayAPI.Core.Domain.Abstractions.Repositories;
using BirthdayAPI.Core.Service.DTOs;
using BirthdayAPI.Core.Service.Query.Parameters;
using BirthdayAPI.Core.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Service.Services
{
    public class ContactService : BaseService, IContactService
    {
        public ContactService(IRepositoryManager repository, IMapper mapper) : base(repository, mapper) { }
        
        public Task<ContactDto> CreateContact(ContactDto contact)
        {
            throw new NotImplementedException();
        }

        public Task<ContactDto> GetContact(int ContactId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ContactDto>> GetContacts(ContactParameters parameters)
        {
            throw new NotImplementedException();
        }

        public Task<ContactDto> RemoveContact(int contactId)
        {
            throw new NotImplementedException();
        }

        public Task<ContactDto> UpdateContact(int contactId, ContactDto contact)
        {
            throw new NotImplementedException();
        }
    }
}
