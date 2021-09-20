using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BirthdayAPI.Core.Service.DTOs;
using BirthdayAPI.Core.Service.Query.Parameters;
using BirthdayAPI.Core.Service.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayAPI.Infrastructure.Presentation.Controllers
{
    [Route("api/Profiles/{profileId:int}/Contacts/{contactId:int}/Gifts")]
    [ApiController]
    public class GiftsController : BasicController
    {
        public GiftsController(IServiceManager service) : base(service) { }
        

        // GET: api/Profiles/2/Gifts
        [HttpGet(Name = "GetGifts")]
        public async Task<ActionResult<IEnumerable<GiftDto>>> GetGifts([FromRoute]int profileId, [FromRoute]int contactId, [FromQuery] GiftParameters giftParameters)
        {
            return Ok(await _service.GiftService.GetGifts(profileId, contactId, giftParameters));
        }

        // GET: api/Profiles/2/Gifts/5
        [HttpGet("{giftId}", Name = "GetGift")]
        public async Task<ActionResult<GiftDto>> GetGift([FromRoute]int profileId, [FromRoute]int contactId, int giftId)
        {
            return Ok(await _service.GiftService.GetGift(profileId, contactId, giftId));
        }

        // PUT: api/Profiles/2/Gifts/5
        [HttpPut("{giftId}", Name = "PutGift")]
        public async Task<IActionResult> PutGift([FromRoute]int profileId, [FromRoute]int contactId, int giftId, GiftDto Gift)
        {
            return Ok(await _service.GiftService.UpdateGift(profileId, contactId, giftId, Gift));
        }

        // POST: api/Profiles/2/Gifts
        [HttpPost(Name = "PostGift")]
        public async Task<ActionResult<GiftDto>> PostGift([FromRoute]int profileId, [FromRoute]int contactId, GiftDto Gift)
        {
            var newGift = await _service.GiftService.CreateGift(profileId, contactId, Gift);

            return CreatedAtAction(nameof(GetGift), new { profileId, contactId, newGift.GiftId }, newGift);
        }

        // DELETE: api/Profiles/2/Gifts/5
        [HttpDelete("{giftId}", Name = "DeleteGift")]
        public async Task<ActionResult<GiftDto>> DeleteGift([FromRoute]int profileId, [FromRoute]int contactId, int giftId)
        {
            return Ok(await _service.GiftService.RemoveGift(profileId, contactId, giftId));
        }
    }
}