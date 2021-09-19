using BirthdayAPI.Core.Service.DTOs;
using BirthdayAPI.Core.Service.Query.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Service.Services.Abstractions
{
    public interface IGiftService
    {
        Task<GiftDto> GetGift(int profileId, int contactId,  int giftId);
        Task<IEnumerable<GiftDto>> GetGifts(int profileId, int contactId, GiftParameters parameters);
        Task<GiftDto> CreateGift(int profileId, int contactId, GiftDto Gift);
        Task<GiftDto> UpdateGift(int profileId, int contactId, int giftId, GiftDto Gift);
        Task<GiftDto> RemoveGift(int profileId, int contactId, int giftId);
    }
}
