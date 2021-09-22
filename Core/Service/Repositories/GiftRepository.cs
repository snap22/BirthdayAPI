using BirthdayAPI.Core.Domain.Abstractions.Repositories;
using BirthdayAPI.Core.Domain.Entities;
using BirthdayAPI.Core.Service.Query.Parameters;
using BirthdayAPI.Core.Service.Query.Sorting;
using BirthdayAPI.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Service.Repositories
{
    public class GiftRepository : BaseRepository<Gift>, IGiftRepository
    {
        public GiftRepository(ApplicationDbContext context, ISortHelper<Gift> sortHelper) : base(context, sortHelper) { }

        public async Task<Gift> AddGift(Gift newGift)
        {
            return await base.Add(newGift);
        }

        public Gift EditGift(Gift gift)
        {
            return base.Edit(gift);
        }

        public async Task<Gift> GetGiftById(int id)
        {
            return await base.GetById(id);
        }

        public async Task<IEnumerable<Gift>> GetGifts(GiftParameters parameters)
        {
            var filteredGifts = base.FilterByCondition(g => (g.EstimatedPrice >= parameters.MinPrice && g.EstimatedPrice <= parameters.MaxPrice));
            ReduceQueryByName(ref filteredGifts, parameters.Name);
            filteredGifts = _sortHelper.ApplySort(filteredGifts, parameters.OrderBy);
            return await base.GetPagedResult(filteredGifts, parameters);
        }

        public async Task<IEnumerable<Gift>> GetGiftsOfContact(int contactId, GiftParameters parameters)
        {
            var filteredGifts = base.FilterByCondition(g => (g.EstimatedPrice >= parameters.MinPrice && g.EstimatedPrice <= parameters.MaxPrice))
                .Where(g => g.ContactId == contactId);
            ReduceQueryByName(ref filteredGifts, parameters.Name);
            filteredGifts = _sortHelper.ApplySort(filteredGifts, parameters.OrderBy);
            return await base.GetPagedResult(filteredGifts, parameters);
        }

        public bool GiftWithIdExists(int giftId)
        {
            return _context.Gifts.Any(g => g.GiftId == giftId);
        }

        public void RemoveGift(Gift gift)
        {
            base.Remove(gift);
        }

        private void ReduceQueryByName(ref IQueryable<Gift> gifts, string name)
        {
            if (gifts.Any() == false || string.IsNullOrWhiteSpace(name))
                return;

            gifts = gifts.Where(g => g.Name.ToLower().Contains(name.ToLower()));
        }
    }
}
