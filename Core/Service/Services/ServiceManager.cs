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
        private readonly Lazy<IContactService> _lazyContactService;
        private readonly Lazy<INoteService> _lazyNoteService;
        private readonly Lazy<IGiftService> _lazyGiftService;



        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _lazyAccountService = new Lazy<IAccountService>(() => new AccountService(repositoryManager, mapper));
            _lazyProfileService = new Lazy<IProfileService>(() => new ProfileService(repositoryManager, mapper));
            _lazyContactService = new Lazy<IContactService>(() => new ContactService(repositoryManager, mapper));
            _lazyNoteService = new Lazy<INoteService>(() => new NoteService(repositoryManager, mapper));
            _lazyGiftService = new Lazy<IGiftService>(() => new GiftService(repositoryManager, mapper));
        }
        public IAccountService AccountService => _lazyAccountService.Value;

        public IProfileService ProfileService => _lazyProfileService.Value;

        public IContactService ContactService => _lazyContactService.Value;

        public INoteService NoteService => _lazyNoteService.Value;

        public IGiftService GiftService => _lazyGiftService.Value;
    }
}
