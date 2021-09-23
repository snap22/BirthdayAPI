using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BirthdayAPI.Core.Service.DTOs;
using BirthdayAPI.Core.Service.Query.Parameters;
using BirthdayAPI.Core.Service.Services.Abstractions;
using BirthdayAPI.Infrastructure.LinkResources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayAPI.Infrastructure.Presentation.Controllers
{
    [Produces("application/json")]
    [Route("api/Profiles/{profileId:int}/Contacts/{contactId:int}/Gifts")]
    [ApiController]
    public class GiftsController : BasicController
    {
        public GiftsController(IServiceManager service, LinksCreator links) : base(service, links) { }


        /// <summary>
        /// Gets a list of gifts that belong to a given contact
        /// </summary>
        /// <param name="profileId">ID of a profile </param>
        /// <param name="contactId">ID of a contact</param>
        /// <param name="giftParameters"></param>
        /// <returns>A list of gifts</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/Profiles/3/Contacts/12/Gifts
        ///
        /// </remarks>
        /// <response code="200">Returns a list of gifts</response>
        /// <response code="404">If either a profile or a contact has not been found</response>
        [HttpGet(Name = "GetGifts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<GiftDto>>> GetGifts([FromRoute]int profileId, [FromRoute]int contactId, [FromQuery] GiftParameters giftParameters)
        {
            var foundGifts = await _service.GiftService.GetGifts(profileId, contactId, giftParameters);
            var linkedGifts = _linksCreator.Gift.GenerateLinksForManyEntities(HttpContext, foundGifts);
            return Ok(linkedGifts);
        }

        /// <summary>
        /// Gets a specific gift
        /// </summary>
        /// <param name="profileId">ID of a profile</param>
        /// <param name="contactId">ID of a contact</param>
        /// <param name="giftId">ID of a gift</param>
        /// <returns>A gift</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/Profiles/3/Contacts/12/Gifts/7
        ///
        /// </remarks>
        /// <response code="200">Returns a gift that has been found</response>
        /// <response code="404">If a profile, contact or a gift hasn't been found</response>
        /// <response code="400">If a found gift does not belong to the given contact or a contact to the profile</response>
        [HttpGet("{giftId}", Name = "GetGift")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GiftDto>> GetGift([FromRoute]int profileId, [FromRoute]int contactId, int giftId)
        {
            var foundGift = await _service.GiftService.GetGift(profileId, contactId, giftId);
            var linkedGift = _linksCreator.Gift.GenerateLinksForOneEntity(HttpContext, foundGift);
            return Ok(linkedGift);
        }

        /// <summary>
        /// Updates a specific gift
        /// </summary>
        /// <param name="profileId">ID of a profile</param>
        /// <param name="contactId">ID of a contact</param>
        /// <param name="giftId">ID of a gift</param>
        /// <param name="Gift"></param>
        /// <returns>An updated gift</returns>
        /// <remarks>
        /// The GiftId and ContactId attributes cannot be changed
        /// 
        /// Sample request:
        ///
        ///     PUT /api/Profiles/3/Contacts/12/Gifts/7
        ///
        /// </remarks>
        /// <response code="200">Returns a gift that has been updated</response>
        /// <response code="404">If a profile, contact or gift has not been found</response>
        /// <response code="400">If the gift does not belong to the given contact, or the contact to the profile</response>
        [HttpPut("{giftId}", Name = "PutGift")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutGift([FromRoute]int profileId, [FromRoute]int contactId, int giftId, GiftDto Gift)
        {
            return Ok(await _service.GiftService.UpdateGift(profileId, contactId, giftId, Gift));
        }

        /// <summary>
        /// Creates a new gift
        /// </summary>
        /// <param name="profileId">ID of a profile</param>
        /// <param name="contactId">ID of a contact</param>
        /// <param name="Gift"></param>
        /// <returns>A new gift</returns>
        /// <remarks>
        /// The GiftId attribute is created automatically
        /// 
        /// Sample request:
        ///
        ///     POST /api/Profiles/3/Contacts/12/Gifts
        ///
        /// </remarks>
        /// <response code="200">Returns a newly created gift</response>
        /// <response code="404">If the given profile or contact has not been found</response>
        /// <response code="400">If the contact does not belong to the profile</response>
        [HttpPost(Name = "PostGift")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GiftDto>> PostGift([FromRoute]int profileId, [FromRoute]int contactId, GiftDto Gift)
        {
            var newGift = await _service.GiftService.CreateGift(profileId, contactId, Gift);

            return CreatedAtAction(nameof(GetGift), new { profileId, contactId, newGift.GiftId }, newGift);
        }

        /// <summary>
        /// Deletes a specific gift
        /// </summary>
        /// <param name="profileId">ID of a profile</param>
        /// <param name="contactId">ID of a contact</param>
        /// <param name="giftId">ID of a gift</param>
        /// <returns>A deleted gift</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /api/Profiles/3/Contacts/12/Gifts/7
        ///
        /// </remarks>
        /// <response code="200">Returns a gift that has been deleted</response>
        /// <response code="404">If a profile,contact or a gift has not been found</response>
        /// <response code="400">If the gift does not belong to the contact, or the contact to the profile</response>
        [HttpDelete("{giftId}", Name = "DeleteGift")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<GiftDto>> DeleteGift([FromRoute]int profileId, [FromRoute]int contactId, int giftId)
        {
            return Ok(await _service.GiftService.RemoveGift(profileId, contactId, giftId));
        }
    }
}