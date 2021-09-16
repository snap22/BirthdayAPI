using BirthdayAPI.Infrastructure.Persistence.Context;
using BirthdayAPI.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BirthdayAPI.Core.Domain.Abstractions.Repositories;

namespace BirthdayAPI.Core.Service.Repositories
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

        public async Task<IEnumerable<Account>> GetSpecificAccounts()
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

        public bool AccountWithId(int accountId)
        {
            return _context.Accounts.Any(x => x.AccountId == accountId);
        }

        public bool AccountWithEmailExists(string email)
        {
            return _context.Accounts.Any(x => x.Email == email);
        }
    }
}
