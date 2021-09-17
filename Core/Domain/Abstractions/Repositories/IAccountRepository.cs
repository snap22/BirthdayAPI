using BirthdayAPI.Core.Domain.Entities;
using BirthdayAPI.Core.Service.Query.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Domain.Abstractions.Repositories
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAccounts(AccountParameters parameters);
        Task<Account> GetAccountById(int id);
        Task AddAccount(Account newAccount);
        void EditAccount(Account account);
        void RemoveAccount(Account account);
        bool AccountWithIdExists(int accountId);
        bool AccountWithEmailExists(string email);
    }
}
