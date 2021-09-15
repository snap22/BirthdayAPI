using AutoMapper;
using BirthdayAPI.Interfaces;
using BirthdayAPI.Persistence.Models.DTO;
using BirthdayAPI.Persistence.Models.Normal;
using BirthdayAPI.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Persistence.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unit;

        public AccountService(IAccountRepository repository, IMapper mapper, IUnitOfWork unit)
        {
            _repository = repository;
            _mapper = mapper;
            _unit = unit;
        }
        public async Task<AccountDto> CreateAccount(AccountDto account)
        {
            var newAccount = _mapper.Map<Account>(account);
            await _repository.AddAccount(newAccount);
            await _unit.CompleteAsync();
            return account;
        }

        public async Task<AccountDto> GetAccount(int accountId)
        {
            var foundAccount = await _repository.GetAccountById(accountId);
            return _mapper.Map<AccountDto>(foundAccount);
        }

        public async Task<IEnumerable<AccountDto>> GetAccounts()
        {
            var foundAccounts = await _repository.GetAllAccounts();
            return _mapper.Map<IEnumerable<AccountDto>>(foundAccounts);
        }

        public async Task<IEnumerable<AccountDto>> GetSpecificAccounts()
        {
            var foundAccounts = await _repository.GetSpecificAccounts();
            return _mapper.Map<IEnumerable<AccountDto>>(foundAccounts);
        }

        public async Task<AccountDto> RemoveAccount(int accountId)
        {
            var foundAccount = await _repository.GetAccountById(accountId);
            _repository.RemoveAccount(foundAccount);
            await _unit.CompleteAsync();
            return _mapper.Map<AccountDto>(foundAccount);
        }

        public async Task<AccountDto> UpdateAccount(AccountDto account)
        {
            var editedAccount = _mapper.Map<Account>(account);
            _repository.EditAccount(editedAccount);
            await _unit.CompleteAsync();
            return _mapper.Map<AccountDto>(account);
        }
    }
}
