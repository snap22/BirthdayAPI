using AutoMapper;
using BirthdayAPI.Core.Domain.Abstractions.Repositories;
using BirthdayAPI.Core.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Service.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAccountService> _lazyAccountService;
        private readonly Lazy<IProfileService> _lazyProfileService;


        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _lazyAccountService = new Lazy<IAccountService>(() => new AccountService(repositoryManager, mapper));
            _lazyProfileService = new Lazy<IProfileService>(() => new ProfileService(repositoryManager, mapper));
        }
        public IAccountService AccountService => _lazyAccountService.Value;

        public IProfileService ProfileService => _lazyProfileService.Value;

        public IContactService ContactService => throw new NotImplementedException();
    }
}
