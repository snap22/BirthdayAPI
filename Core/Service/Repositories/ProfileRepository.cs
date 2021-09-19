using BirthdayAPI.Infrastructure.Persistence.Context;
using BirthdayAPI.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BirthdayAPI.Core.Domain.Abstractions.Repositories;
using BirthdayAPI.Core.Service.Query.Sorting;
using BirthdayAPI.Core.Service.Query.Parameters;

namespace BirthdayAPI.Core.Service.Repositories
{
    public class ProfileRepository : BaseRepository<Profile>, IProfileRepository
    {
        public ProfileRepository(ApplicationDbContext context, ISortHelper<Profile> sortHelper) : base(context, sortHelper)
        {

        }

        public async Task<Profile> AddProfile(Profile newprofile)
        {
            return await base.Add(newprofile);
        }

        public Profile EditProfile(Profile profile)
        {
            return base.Edit(profile);
        }

        public async Task<IEnumerable<Profile>> GetAllProfiles(ProfileParameters parameters)
        {
            IQueryable<Profile> profiles = _context.Profiles;
            ReduceQueryByUsername(ref profiles, parameters.Username);
            profiles = _sortHelper.ApplySort(profiles, parameters.OrderBy);
            return await GetPagedResult(profiles, parameters);
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

        private void ReduceQueryByUsername(ref IQueryable<Profile> profiles, string username)
        {
            if (profiles.Any() == false || string.IsNullOrWhiteSpace(username))
                return;

            profiles = profiles.Where(p => p.Username.ToLower().Contains(username.ToLower()));
        }
    }
}
