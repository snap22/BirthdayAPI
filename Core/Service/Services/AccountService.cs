using AutoMapper;
using BirthdayAPI.Core.Service.DTOs;
using BirthdayAPI.Core.Domain.Entities;
using BirthdayAPI.Core.Domain.Abstractions.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using BirthdayAPI.Core.Service.Services.Abstractions;
using BirthdayAPI.Core.Domain.Exceptions;
using BirthdayAPI.Core.Service.Query.Parameters;

namespace BirthdayAPI.Core.Service.Services
{
    public class AccountService : BaseService, IAccountService
    {

        public AccountService(IRepositoryManager repository, IMapper mapper) : base(repository, mapper) { }
        public async Task<AccountDto> CreateAccount(AccountDto account)
        {
            ThrowErrorIfEmailAlreadyUsed(account.Email);

            var newAccount = _mapper.Map<Account>(account);
            await _repository.AccountRepository.AddAccount(newAccount);
            await _repository.UnitOfWork.CompleteAsync();
            return account;
        }

        public async Task<AccountDto> GetAccount(int accountId)
        {
            base.ThrowErrorIfAccountDoesntExist(accountId);

            var foundAccount = await _repository.AccountRepository.GetAccountById(accountId);

            return _mapper.Map<AccountDto>(foundAccount);
        }

        public async Task<IEnumerable<AccountDto>> GetAccounts(AccountParameters parameters)
        {
            if (parameters.IsValidYearRange() == false)
                throw new BadRequestException("Parameters for Minimal year and Maximal year are not valid!");

            var foundAccounts = await _repository.AccountRepository.GetAccounts(parameters);
            return _mapper.Map<IEnumerable<AccountDto>>(foundAccounts);
        }

        public async Task<AccountDto> RemoveAccount(int accountId)
        {
            base.ThrowErrorIfAccountDoesntExist(accountId);

            var foundAccount = await _repository.AccountRepository.GetAccountById(accountId);

            _repository.AccountRepository.RemoveAccount(foundAccount);
            await _repository.UnitOfWork.CompleteAsync();
            return _mapper.Map<AccountDto>(foundAccount);
        }

        public async Task<AccountDto> UpdateAccount(int accountId, AccountDto account)
        {
            base.ThrowErrorIfAccountDoesntExist(accountId);

            var existingAccount = await _repository.AccountRepository.GetAccountById(accountId);

            if (existingAccount.Email != account.Email)
            {
                ThrowErrorIfEmailAlreadyUsed(account.Email);
            }

            _mapper.Map(account, existingAccount);
            _repository.AccountRepository.EditAccount(existingAccount);
            await _repository.UnitOfWork.CompleteAsync();

            var foundAccount = await _repository.AccountRepository.GetAccountById(account.AccountId);
            return _mapper.Map<AccountDto>(foundAccount);
        }

        private void ThrowErrorIfEmailAlreadyUsed(string email)
        {
            if (_repository.AccountRepository.AccountWithEmailExists(email))
                throw new BadRequestException($"Account with email: {email} already exists!");
        }
    }
}
