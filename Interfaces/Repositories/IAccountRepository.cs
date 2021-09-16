using BirthdayAPI.Persistence.Models.Normal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Persistence.Repositories
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllAccounts();
        Task<Account> GetAccountById(int id);
        Task<IEnumerable<Account>> GetSpecificAccounts();
        Task AddAccount(Account newAccount);
        void EditAccount(Account account);
        void RemoveAccount(Account account);
        bool AccountExists(int accountId);
    }
}
