using BirthdayAPI.Core.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Domain.Abstractions.Services
{
    public interface IAccountService
    {
        Task<AccountDto> GetAccount(int accountId);
        Task<IEnumerable<AccountDto>> GetAccounts();
        Task<IEnumerable<AccountDto>> GetSpecificAccounts();
        Task<AccountDto> CreateAccount(AccountDto account);
        Task<AccountDto> UpdateAccount(int accountId, AccountDto account);
        Task<AccountDto> RemoveAccount(int accountId);
    }
}
