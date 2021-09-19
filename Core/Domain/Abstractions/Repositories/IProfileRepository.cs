using BirthdayAPI.Core.Domain.Entities;
using BirthdayAPI.Core.Service.Query.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Domain.Abstractions.Repositories
{
    public interface IProfileRepository
    {
        Task<IEnumerable<Profile>> GetAllProfiles(ProfileParameters parameters);
        Task<Profile> GetProfileById(int id);
        Profile GetProfileByAccountId(int accountId);
        Task<Profile> AddProfile(Profile newprofile);
        Profile EditProfile(Profile profile);
        void RemoveProfile(Profile profile);
        bool ProfileWithIdExists(int profileId);
        bool ProfileWithUsernameExists(string username);
    }
}
