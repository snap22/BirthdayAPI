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
    public class GiftService : BaseService, IGiftService
    {
        public GiftService(IRepositoryManager repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<GiftDto> CreateGift(int profileId, int contactId, GiftDto gift)
        {
            base.ThrowErrorIfProfileDoesntExist(profileId);
            base.ThrowErrorIfContactDoesntExist(contactId);

            var foundProfile = await _repository.ContactRepository.GetContactById(contactId);
            ThrowErrorIfProfilesNotTheSame(foundProfile.ProfileId, profileId);

            gift.ContactId = contactId;
            var newGift = _mapper.Map<Gift>(gift);
            var createdGift = await _repository.GiftRepository.AddGift(newGift);
            await _repository.UnitOfWork.CompleteAsync();
            return _mapper.Map<GiftDto>(createdGift);
        }

        public async Task<GiftDto> GetGift(int profileId, int contactId, int giftId)
        {
            base.ThrowErrorIfProfileDoesntExist(profileId);
            base.ThrowErrorIfContactDoesntExist(contactId);
            base.ThrowErrorIfGiftDoesntExist(giftId);

            var foundGift = await _repository.GiftRepository.GetGiftById(giftId);
            return _mapper.Map<GiftDto>(foundGift);
        }

        public async Task<IEnumerable<GiftDto>> GetGifts(int profileId, int contactId, GiftParameters parameters)
        {
            base.ThrowErrorIfProfileDoesntExist(profileId);
            base.ThrowErrorIfContactDoesntExist(contactId);

            if (parameters.IsValidPriceRange() == false)
                throw new BadRequestException("Price range is not valid!");

            var foundGifts = await _repository.GiftRepository.GetGiftsOfContact(contactId, parameters);
            return _mapper.Map<IEnumerable<GiftDto>>(foundGifts);
        }

        public async Task<GiftDto> RemoveGift(int profileId, int contactId, int giftId)
        {
            base.ThrowErrorIfProfileDoesntExist(profileId);
            base.ThrowErrorIfContactDoesntExist(contactId);
            base.ThrowErrorIfGiftDoesntExist(giftId);

            var foundContact = await _repository.ContactRepository.GetContactById(contactId);
            ThrowErrorIfProfilesNotTheSame(foundContact.ProfileId, profileId);

            var foundGift = await _repository.GiftRepository.GetGiftById(giftId);
            ThrowErrorIfContactsNotTheSame(contactId, foundGift.ContactId);

            _repository.GiftRepository.RemoveGift(foundGift);
            await _repository.UnitOfWork.CompleteAsync();

            return _mapper.Map<GiftDto>(foundGift);
        }

        public async Task<GiftDto> UpdateGift(int profileId, int contactId, int giftId, GiftDto gift)
        {
            base.ThrowErrorIfProfileDoesntExist(profileId);
            base.ThrowErrorIfContactDoesntExist(contactId);
            base.ThrowErrorIfGiftDoesntExist(giftId);

            var foundContact = await _repository.ContactRepository.GetContactById(contactId);
            ThrowErrorIfProfilesNotTheSame(foundContact.ProfileId, profileId);

            var foundGift = await _repository.GiftRepository.GetGiftById(giftId);
            ThrowErrorIfContactsNotTheSame(contactId, foundGift.ContactId);

            if (foundGift.ContactId != gift.ContactId)
                throw new BadRequestException("Cannot change the contact of a gift");

            _mapper.Map(gift, foundGift);
            var editedGift = _repository.GiftRepository.EditGift(foundGift);
            await _repository.UnitOfWork.CompleteAsync();

            return _mapper.Map<GiftDto>(editedGift);
        }

        private void ThrowErrorIfContactsNotTheSame(int contact1, int contact2)
        {
            if (contact1 != contact2)
                throw new BadRequestException("Gift doesnt belong to this contact!");
        }
    }
}
