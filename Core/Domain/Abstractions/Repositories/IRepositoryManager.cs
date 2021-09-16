using BirthdayAPI.Core.Domain.Abstractions.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Domain.Abstractions.Repositories
{
    public interface IRepositoryManager
    {
        IAccountRepository AccountRepository { get; }
        IUnitOfWork UnitOfWork { get; }
        IProfileRepository ProfileRepository { get; }
        IContactRepository ContactRepository { get; }
        IGiftRepository GiftRepository { get; }
        INoteRepository NoteRepository { get; }

    }
}
