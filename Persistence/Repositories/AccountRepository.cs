using BirthdayAPI.Persistence.Context;
using BirthdayAPI.Persistence.Models.Normal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Persistence.Repositories
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task AddAccount(Account newAccount)
        {
            await base.Add(newAccount);
        }

        public void EditAccount(Account account)
        {
            base.Edit(account);
        }

        public async Task<Account> GetAccountById(int id)
        {
            return await base.GetById(id);
        }

        public async Task<IEnumerable<Account>> GetAccountsWithTag()
        {
            // TODO: hladat podla nazvu / emailu, resp. zoradenie podla nazvu / datumu vytvorenia uctu...
            return await _context.Accounts
                .ToListAsync();
        }

        public async Task<IEnumerable<Account>> GetAllAccounts()
        {
            return await base.GetAll();
        }

        public void RemoveAccount(Account account)
        {
            base.Remove(account);
        }
    }
}
