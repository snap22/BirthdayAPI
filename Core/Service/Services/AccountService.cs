using AutoMapper;
using BirthdayAPI.Core.Service.DTOs;
using BirthdayAPI.Core.Domain.Entities;
using BirthdayAPI.Core.Domain.Abstractions.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using BirthdayAPI.Core.Service.Services.Abstractions;
using BirthdayAPI.Core.Domain.Exceptions;

namespace BirthdayAPI.Core.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        

        public AccountService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<AccountDto> CreateAccount(AccountDto account)
        {
            var newAccount = _mapper.Map<Account>(account);
            await _repository.AccountRepository.AddAccount(newAccount);
            await _repository.UnitOfWork.CompleteAsync();
            return account;
        }

        public async Task<AccountDto> GetAccount(int accountId)
        {
            ThrowErrorIfAccountDoesntExist(accountId);

            var foundAccount = await _repository.AccountRepository.GetAccountById(accountId);

            return _mapper.Map<AccountDto>(foundAccount);
        }

        public async Task<IEnumerable<AccountDto>> GetAccounts()
        {
            var foundAccounts = await _repository.AccountRepository.GetAllAccounts();
            return _mapper.Map<IEnumerable<AccountDto>>(foundAccounts);
        }

        public async Task<IEnumerable<AccountDto>> GetSpecificAccounts()
        {
            var foundAccounts = await _repository.AccountRepository.GetSpecificAccounts();
            return _mapper.Map<IEnumerable<AccountDto>>(foundAccounts);
        }

        public async Task<AccountDto> RemoveAccount(int accountId)
        {
            ThrowErrorIfAccountDoesntExist(accountId);

            var foundAccount = await _repository.AccountRepository.GetAccountById(accountId);

            _repository.AccountRepository.RemoveAccount(foundAccount);
            await _repository.UnitOfWork.CompleteAsync();
            return _mapper.Map<AccountDto>(foundAccount);
        }

        public async Task<AccountDto> UpdateAccount(int accountId, AccountDto account)
        {
            ThrowErrorIfAccountDoesntExist(accountId);

            var existingAccount = await _repository.AccountRepository.GetAccountById(accountId);
            _mapper.Map(account, existingAccount);
            _repository.AccountRepository.EditAccount(existingAccount);
            await _repository.UnitOfWork.CompleteAsync();

            var foundAccount = await _repository.AccountRepository.GetAccountById(account.AccountId);
            return _mapper.Map<AccountDto>(foundAccount);
        }

        private void ThrowErrorIfAccountDoesntExist(int accountId)
        {
            if (_repository.AccountRepository.AccountExists(accountId) == false)
                throw new NotFoundException($"Account with id: {accountId} doesn't exist!");
        }
    }
}
