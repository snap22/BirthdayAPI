using BirthdayAPI.Core.Service.DTOs;
using BirthdayAPI.Core.Service.Query.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Service.Services.Abstractions
{
    public interface IProfileService
    {
        Task<ProfileDto> GetProfile(int profileId);
        Task<ProfileDto> GetProfileByAccountId(int accountId);
        Task<IEnumerable<ProfileDto>> GetProfiles(ProfileParameters parameters);
        Task<ProfileDto> CreateProfile(ProfileDto profile);
        Task<ProfileDto> UpdateProfile(int profileId, ProfileDto profile);
        Task<ProfileDto> RemoveProfile(int profileId);
    }
}
