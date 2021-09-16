using BirthdayAPI.Infrastructure.Persistence.Context;
using BirthdayAPI.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BirthdayAPI.Core.Domain.Abstractions.Repositories;

namespace BirthdayAPI.Core.Service.Repositories
{
    public class ProfileRepository : BaseRepository<Profile>, IProfileRepository
    {
        public ProfileRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task AddProfile(Profile newprofile)
        {
            await base.Add(newprofile);
        }

        public void EditProfile(Profile profile)
        {
            base.Edit(profile);
        }

        public async Task<IEnumerable<Profile>> GetAllProfiles()
        {
            return await base.GetAll();
        }

        public async Task<Profile> GetProfileById(int id)
        {
            return await base.GetById(id);
        }

        public Profile GetProfileByAccountId(int accountId)
        {
            return  _context.Profiles
                .SingleOrDefault(p => p.AccountId == accountId);
        }

        public async Task<IEnumerable<Profile>> GetSpecificProfiles()
        {
            return await base.GetAll();
        }

        public bool ProfileWithIdExists(int profileId)
        {
            return _context.Profiles.Any(p => p.ProfileId == profileId);
        }

        public bool ProfileWithUsernameExists(string username)
        {
            return _context.Profiles.Any(p => p.Username == username);
        }

        public void RemoveProfile(Profile profile)
        {
            base.Remove(profile);
        }
    }
}
