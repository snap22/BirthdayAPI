using AutoMapper;
using BirthdayAPI.Core.Domain.Abstractions.Repositories;
using BirthdayAPI.Core.Domain.Exceptions;
using BirthdayAPI.Core.Service.DTOs;
using BirthdayAPI.Core.Service.Query.Parameters;
using BirthdayAPI.Core.Service.Services.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Profile = BirthdayAPI.Core.Domain.Entities.Profile;

namespace BirthdayAPI.Core.Service.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public ProfileService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ProfileDto> CreateProfile(ProfileDto profile)
        {
            ThrowErrorIfProfileWithUsernameExists(profile.Username);
            ThrowErrorIfAccountIdAlreadyUsed(profile.AccountId);

            var newProfile = _mapper.Map<Profile>(profile);

            await _repository.ProfileRepository.AddProfile(newProfile);
            await _repository.UnitOfWork.CompleteAsync();
            return profile;
        }

        public async Task<ProfileDto> GetProfile(int profileId)
        {
            ThrowErrorIfProfileDoesntExist(profileId);

            var foundProfile = await _repository.ProfileRepository.GetProfileById(profileId);
            return _mapper.Map<ProfileDto>(foundProfile);
        }

        public async Task<IEnumerable<ProfileDto>> GetProfiles(ProfileParameters parameters)
        {
            return _mapper.Map<IEnumerable<ProfileDto>>(await _repository.ProfileRepository.GetAllProfiles(parameters));
        }

        public async Task<ProfileDto> RemoveProfile(int profileId)
        {
            ThrowErrorIfProfileDoesntExist(profileId);

            var foundProfile = await _repository.ProfileRepository.GetProfileById(profileId);
            _repository.ProfileRepository.RemoveProfile(foundProfile);
            await _repository.UnitOfWork.CompleteAsync();
            return _mapper.Map<ProfileDto>(foundProfile);
        }

        public async Task<ProfileDto> UpdateProfile(int profileId, ProfileDto profile)
        {
            ThrowErrorIfProfileDoesntExist(profileId);

            var existingProfile = await _repository.ProfileRepository.GetProfileById(profileId);
            if (existingProfile.Username != profile.Username)
            {
                ThrowErrorIfProfileWithUsernameExists(profile.Username);
            }
            if (existingProfile.AccountId != profile.AccountId)
            {
                ThrowErrorIfAccountIdAlreadyUsed(profile.AccountId);
            }
            _mapper.Map(profile, existingProfile);
            await _repository.UnitOfWork.CompleteAsync();
            return _mapper.Map<ProfileDto>(existingProfile);
        }

        private void ThrowErrorIfProfileWithUsernameExists(string username)
        {
            if (_repository.ProfileRepository.ProfileWithUsernameExists(username))
                throw new BadRequestException($"Profile with username: {username} already exists!");
        }

        private void ThrowErrorIfProfileDoesntExist(int profileId)
        {
            if (_repository.ProfileRepository.ProfileWithIdExists(profileId) == false)
                throw new NotFoundException($"Profile with id: {profileId} doesn't exist!");
        }

        private void ThrowErrorIfAccountIdDoesnotMatch(int accountId)
        {
            if (_repository.ProfileRepository.GetProfileByAccountId(accountId).AccountId != accountId)
                throw new BadRequestException($"Account with id: {accountId} already has a profile!");
        }

        private void ThrowErrorIfAccountIdAlreadyUsed(int accountId)
        {
            if (_repository.ProfileRepository.GetProfileByAccountId(accountId) != null)
                throw new BadRequestException($"Account with id: {accountId} already has a profile!");
        }
        
    }
}
