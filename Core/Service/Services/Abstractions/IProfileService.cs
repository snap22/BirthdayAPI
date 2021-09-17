using BirthdayAPI.Core.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Service.Services.Abstractions
{
    public interface IProfileService
    {
        Task<ProfileDto> GetProfile(int profileId);
        Task<IEnumerable<ProfileDto>> GetProfiles();
        Task<ProfileDto> CreateProfile(ProfileDto profile);
        Task<ProfileDto> UpdateProfile(int profileId, ProfileDto profile);
        Task<ProfileDto> RemoveProfile(int profileId);
    }
}
