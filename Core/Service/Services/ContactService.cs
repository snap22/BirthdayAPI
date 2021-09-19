using AutoMapper;
using BirthdayAPI.Core.Domain.Abstractions.Repositories;
using BirthdayAPI.Core.Domain.Entities;
using BirthdayAPI.Core.Domain.Exceptions;
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
        
        public async Task<ContactDto> CreateContact(int profileId, ContactDto contact)
        {
            base.ThrowErrorIfProfileDoesntExist(profileId);

            // set the profileId of a contact to the profileId in route
            contact.ProfileId = profileId;

            var newContact = _mapper.Map<Contact>(contact);
            await _repository.ContactRepository.AddContact(newContact);
            await _repository.UnitOfWork.CompleteAsync();
            return contact;
        }

        public async Task<ContactDto> GetContact(int profileId, int contactId)
        {
            base.ThrowErrorIfProfileDoesntExist(profileId);
            base.ThrowErrorIfContactDoesntExist(contactId);

            var foundContact = await _repository.ContactRepository.GetContactById(contactId);
            base.ThrowErrorIfProfilesNotTheSame(profileId, foundContact.ProfileId);
            return _mapper.Map<ContactDto>(foundContact);
        }

        public async Task<IEnumerable<ContactDto>> GetContacts(int profileId, ContactParameters parameters)
        {
            base.ThrowErrorIfProfileDoesntExist(profileId);
            if (parameters.IsValidMonthRange() == false)
                throw new BadRequestException("Wrong months range!");

            var foundContacts = await _repository.ContactRepository.GetContactsOfProfile(profileId, parameters);
            //var foundContacts = await _repository.ContactRepository.GetAllContacts(parameters);
            return _mapper.Map<IEnumerable<ContactDto>>(foundContacts);
        }

        public async Task<ContactDto> RemoveContact(int profileId, int contactId)
        {
            base.ThrowErrorIfProfileDoesntExist(profileId);
            base.ThrowErrorIfContactDoesntExist(contactId);

            var foundConctact = await _repository.ContactRepository.GetContactById(contactId);
            base.ThrowErrorIfProfilesNotTheSame(profileId, foundConctact.ProfileId);
            _repository.ContactRepository.RemoveContact(foundConctact);
            await _repository.UnitOfWork.CompleteAsync();
            return _mapper.Map<ContactDto>(foundConctact);
        }

        public async Task<ContactDto> UpdateContact(int profileId, int contactId, ContactDto contact)
        {
            base.ThrowErrorIfProfileDoesntExist(profileId);
            base.ThrowErrorIfContactDoesntExist(contactId);

            var existingContact = await _repository.ContactRepository.GetContactById(contactId);
            base.ThrowErrorIfProfilesNotTheSame(profileId, existingContact.ProfileId);

            if (existingContact.ProfileId != contact.ProfileId)
            {
                throw new BadRequestException("Cannot change profile of a contact!");
            }

            _mapper.Map(contact, existingContact);
            _repository.ContactRepository.EditContact(existingContact);
            await _repository.UnitOfWork.CompleteAsync();

            return _mapper.Map<ContactDto>(existingContact); 
        }


    }
}
