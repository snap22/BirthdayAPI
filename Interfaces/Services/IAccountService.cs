using BirthdayAPI.Persistence.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Persistence.Services
{
    public interface IAccountService
    {
        Task<AccountDto> GetAccount(int accountId);
        Task<IEnumerable<AccountDto>> GetAccounts();
        Task<IEnumerable<AccountDto>> GetSpecificAccounts();
        Task<AccountDto> CreateAccount(AccountDto account);
        Task<AccountDto> UpdateAccount(AccountDto account);
        Task<AccountDto> RemoveAccount(int accountId);
    }
}
