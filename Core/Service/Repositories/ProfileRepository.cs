using BirthdayAPI.Infrastructure.Persistence.Context;
using BirthdayAPI.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Service.Repositories
{
    public class ProfileRepository : BaseRepository<Profile>
    {
        public ProfileRepository(ApplicationDbContext context) : base(context)
        {

        }
        
    }
}
