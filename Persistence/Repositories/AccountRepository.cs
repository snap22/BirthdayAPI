using BirthdayAPI.Persistence.Context;
using BirthdayAPI.Persistence.Models.Normal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Persistence.Repositories
{
    public class AccountRepository : BaseRepository<Account>
    {
        public AccountRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async override Task Add(Account entity)
        {
            await _context.Accounts.AddAsync(entity);
        }

        public override void Edit(Account entity)
        {
            _context.Accounts.Update(entity);
        }

        public override void Remove(Account entity)
        {
            _context.Accounts.Remove(entity);
        }

        public async Task<IEnumerable<Account>> GetAccountsWithTag()
        {
            // TODO: hladat podla nazvu / emailu, resp. zoradenie podla nazvu / datumu vytvorenia uctu...
            return await _context.Accounts
                .ToListAsync();
        }
    }
}
