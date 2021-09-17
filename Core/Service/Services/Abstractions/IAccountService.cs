using BirthdayAPI.Core.Service.DTOs;
using BirthdayAPI.Core.Service.Query.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Service.Services.Abstractions
{
    public interface IAccountService
    {
        Task<AccountDto> GetAccount(int accountId);
        Task<IEnumerable<AccountDto>> GetAccounts(AccountParameters parameters);
        Task<AccountDto> CreateAccount(AccountDto account);
        Task<AccountDto> UpdateAccount(int accountId, AccountDto account);
        Task<AccountDto> RemoveAccount(int accountId);
    }
}
