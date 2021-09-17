using BirthdayAPI.Infrastructure.Persistence.Context;
using BirthdayAPI.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BirthdayAPI.Core.Domain.Abstractions.Repositories;
using BirthdayAPI.Core.Service.Query.Parameters;
using BirthdayAPI.Core.Service.Query.Sorting;

namespace BirthdayAPI.Core.Service.Repositories
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(ApplicationDbContext context, ISortHelper<Account> sortHelper) : base(context, sortHelper)
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

        public async Task<IEnumerable<Account>> GetAccounts(AccountParameters parameters)
        {

            var filteredAccounts = base.FilterByCondition(acc =>
                (acc.DateCreated.Year >= parameters.MinYearOfCreation) &&
                (acc.DateCreated.Year <= parameters.MaxYearOfCreation));

            ReduceQueryByEmail(ref filteredAccounts, parameters.EmailAddress);
            filteredAccounts = _sortHelper.ApplySort(filteredAccounts, parameters.OrderBy);

            return await base.GetPagedResult(filteredAccounts, parameters);
        }

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return await base.GetAll();
        }

        public void RemoveAccount(Account account)
        {
            base.Remove(account);
        }

        public bool AccountWithIdExists(int accountId)
        {
            return _context.Accounts.Any(x => x.AccountId == accountId);
        }

        public bool AccountWithEmailExists(string email)
        {
            return _context.Accounts.Any(x => x.Email == email);
        }

        private void ReduceQueryByEmail(ref IQueryable<Account> accounts, string email)
        {
            if (accounts.Any() == false || string.IsNullOrWhiteSpace(email))
                return;

            accounts = accounts.
                Where(acc => acc.Email.ToLower().Contains(email));
        }
    }
}
