using BirthdayAPI.Core.Domain.Abstractions.Repositories;
using BirthdayAPI.Core.Domain.Abstractions.Units;
using BirthdayAPI.Core.Domain.Entities;
using BirthdayAPI.Core.Service.Units;
using BirthdayAPI.Infrastructure.Persistence.Context;
using BirthdayAPI.Core.Service.Query.Sorting;
using System;

namespace BirthdayAPI.Core.Service.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IAccountRepository> _lazyAccountRepository;
        private readonly Lazy<IProfileRepository> _lazyProfileRepository;
        private readonly Lazy<IContactRepository> _lazyContactRepository;
        private readonly Lazy<INoteRepository> _lazyNoteRepository;
        private readonly Lazy<IGiftRepository> _lazyGiftRepository;
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        

        public RepositoryManager(ApplicationDbContext context,
            ISortHelper<Account> accountSortHelper,
            ISortHelper<Profile> profileSortHelper,
            ISortHelper<Contact> contactSortHelper,
            ISortHelper<Gift> giftSortHelper,
            ISortHelper<Note> noteSortHelper
            )
        {
            _lazyAccountRepository = new Lazy<IAccountRepository>(() => new AccountRepository(context, accountSortHelper));
            _lazyProfileRepository = new Lazy<IProfileRepository>(() => new ProfileRepository(context, profileSortHelper));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new SaveUnit(context));
            _lazyContactRepository = new Lazy<IContactRepository>(() => new ContactRepository(context, contactSortHelper));
            _lazyNoteRepository = new Lazy<INoteRepository>(() => new NoteRepository(context, noteSortHelper));
            //_lazyGiftRepository = new Lazy<IGiftRepository>(() => new GiftRepository(context, giftSortHelper));
        }
        public IAccountRepository AccountRepository => _lazyAccountRepository.Value;
        public IProfileRepository ProfileRepository => _lazyProfileRepository.Value;
        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;

        public IContactRepository ContactRepository => _lazyContactRepository.Value;

        public IGiftRepository GiftRepository => _lazyGiftRepository.Value;

        public INoteRepository NoteRepository => _lazyNoteRepository.Value;
    }
}
