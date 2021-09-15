using BirthdayAPI.Persistence.Context;
using BirthdayAPI.Persistence.Models.Normal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Persistence.Repositories
{
    public class ProfileRepository : BaseRepository<Profile>
    {
        public ProfileRepository(ApplicationDbContext context) : base(context)
        {

        }
        
    }
}
