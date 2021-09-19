using BirthdayAPI.Core.Domain.Entities;
using BirthdayAPI.Core.Service.Query.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Domain.Abstractions.Repositories
{
    public interface IGiftRepository
    {
        Task<IEnumerable<Gift>> GetGifts(GiftParameters parameters);
        Task<IEnumerable<Gift>> GetGiftsOfContact(int contactId, GiftParameters parameters);
        Task<Gift> GetGiftById(int id);
        Task AddGift(Gift newGift);
        void EditGift(Gift gift);
        void RemoveGift(Gift gift);
        bool GiftWithIdExists(int giftId);
    }
}
