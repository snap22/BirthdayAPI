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
    public class GiftsController : ControllerBase
    {
        private readonly IServiceManager _service;
        public GiftsController(IServiceManager service)
        {
            _service = service;
        }

        // GET: api/Profiles/2/Gifts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GiftDto>>> GetGifts([FromRoute]int profileId, [FromRoute]int contactId, [FromQuery] GiftParameters giftParameters)
        {
            return Ok(await _service.GiftService.GetGifts(profileId, contactId, giftParameters));
        }

        // GET: api/Profiles/2/Gifts/5
        [HttpGet("{giftId}")]
        public async Task<ActionResult<GiftDto>> GetGift([FromRoute]int profileId, [FromRoute]int contactId, int giftId)
        {
            return Ok(await _service.GiftService.GetGift(profileId, contactId, giftId));
        }

        // PUT: api/Profiles/2/Gifts/5
        [HttpPut("{giftId}")]
        public async Task<IActionResult> PutGift([FromRoute]int profileId, [FromRoute]int contactId, int giftId, GiftDto Gift)
        {
            return Ok(await _service.GiftService.UpdateGift(profileId, contactId, giftId, Gift));
        }

        // POST: api/Profiles/2/Gifts
        [HttpPost]
        public async Task<ActionResult<GiftDto>> PostGift([FromRoute]int profileId, [FromRoute]int contactId, GiftDto Gift)
        {
            await _service.GiftService.CreateGift(profileId, contactId, Gift);

            return CreatedAtAction(nameof(GetGift), new { profileId, contactId, Gift.GiftId }, Gift);
        }

        // DELETE: api/Profiles/2/Gifts/5
        [HttpDelete("{giftId}")]
        public async Task<ActionResult<GiftDto>> DeleteGift([FromRoute]int profileId, [FromRoute]int contactId, int giftId)
        {
            return Ok(await _service.GiftService.RemoveGift(profileId, contactId, giftId));
        }
    }
}