using BirthdayAPI.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Domain.Abstractions.Repositories
{
    public interface IGiftRepository
    {
        Task<IEnumerable<Gift>> GetAllGifts();
        Task<Gift> GetGiftById(int id);
        Task AddGift(Gift newGift);
        void EditGift(Gift gift);
        void RemoveGift(Gift gift);
        bool GiftWithIdExists(int giftId);
    }
}
