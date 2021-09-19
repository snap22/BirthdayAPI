using AutoMapper;
using BirthdayAPI.Core.Domain.Abstractions.Repositories;
using BirthdayAPI.Core.Service.DTOs;
using BirthdayAPI.Core.Service.Query.Parameters;
using BirthdayAPI.Core.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Service.Services
{
    public class GiftService : BaseService, IGiftService
    {
        public GiftService(IRepositoryManager repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<GiftDto> CreateGift(int profileId, int contactId, GiftDto Gift)
        {
            throw new NotImplementedException();
        }

        public async Task<GiftDto> GetGift(int profileId, int contactId, int giftId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GiftDto>> GetGifts(int profileId, int contactId, GiftParameters parameters)
        {
            throw new NotImplementedException();
        }

        public async Task<GiftDto> RemoveGift(int profileId, int contactId, int giftId)
        {
            throw new NotImplementedException();
        }

        public async Task<GiftDto> UpdateGift(int profileId, int contactId, int giftId, GiftDto Gift)
        {
            throw new NotImplementedException();
        }

        
    }
}
