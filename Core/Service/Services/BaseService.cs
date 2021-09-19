using AutoMapper;
using BirthdayAPI.Core.Domain.Abstractions.Repositories;
using BirthdayAPI.Core.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Service.Services
{
    public class BaseService
    {
        protected readonly IRepositoryManager _repository;
        protected readonly IMapper _mapper;
        public BaseService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        protected void ThrowErrorIfAccountDoesntExist(int accountId)
        {
            if (_repository.AccountRepository.AccountWithIdExists(accountId) == false)
                throw new NotFoundException($"Account with id: {accountId} doesn't exist!");
        }

        protected void ThrowErrorIfProfileDoesntExist(int profileId)
        {
            if (_repository.ProfileRepository.ProfileWithIdExists(profileId) == false)
                throw new NotFoundException($"Profile with id: {profileId} does not exist!");
        }

        protected void ThrowErrorIfContactDoesntExist(int contactId)
        {
            if (_repository.ContactRepository.ContactWithIdExists(contactId) == false)
                throw new NotFoundException($"Contact with id: {contactId} does not exist!");
        }

        protected void ThrowErrorIfGiftDoesntExist(int giftId)
        {
            if (_repository.GiftRepository.GiftWithIdExists(giftId) == false)
                throw new NotFoundException($"Gift with id: {giftId} does not exist!");
        }

        protected void ThrowErrorIfNoteDoesntExist(int noteId)
        {
            if (_repository.NoteRepository.NoteWithIdExists(noteId) == false)
                throw new NotFoundException($"Note with id: {noteId} does not exist!");
        }

        protected void ThrowErrorIfProfilesNotTheSame(int profileId1, int profileId2)
        {
            if (profileId1 != profileId2)
                throw new BadRequestException("Contact does not belong to this profile!");
        }
    }
}
