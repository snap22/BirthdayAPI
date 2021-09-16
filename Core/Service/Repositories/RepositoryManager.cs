using BirthdayAPI.Core.Domain.Abstractions.Repositories;
using BirthdayAPI.Core.Domain.Abstractions.Units;
using BirthdayAPI.Core.Service.Units;
using BirthdayAPI.Infrastructure.Persistence.Context;
using System;

namespace BirthdayAPI.Core.Service.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IAccountRepository> _lazyAccountRepository;
        private readonly Lazy<IProfileRepository> _lazyProfileRepository;
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        public RepositoryManager(ApplicationDbContext context)
        {
            _lazyAccountRepository = new Lazy<IAccountRepository>(() => new AccountRepository(context));
            _lazyProfileRepository = new Lazy<IProfileRepository>(() => new ProfileRepository(context));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new SaveUnit(context));
        }
        public IAccountRepository AccountRepository => _lazyAccountRepository.Value;
        public IProfileRepository ProfileRepository => _lazyProfileRepository.Value;
        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
    }
}
