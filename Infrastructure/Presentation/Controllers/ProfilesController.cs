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
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : BasicController
    {
        public ProfilesController(IServiceManager service, LinksCreator links) : base(service, links) { }


        /// <summary>
        /// Gets a list of profiles
        /// </summary>
        /// <param name="profileParameters"></param>
        /// <returns>A list of profiles</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/Profiles
        ///
        /// </remarks>
        /// <response code="200">Returns a list of profiles</response>
        [HttpGet(Name = "GetProfiles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ProfileDto>>> GetProfiles([FromQuery] ProfileParameters profileParameters)
        {
            var foundProfiles = await _service.ProfileService.GetProfiles(profileParameters);
            var linkedProfiles = _linksCreator.Profile.GenerateLinksForManyEntities(HttpContext, foundProfiles);
            return Ok(linkedProfiles);
        }

        /// <summary>
        /// Gets a specific profile
        /// </summary>
        /// <param name="id">ID of a profile</param>
        /// <returns>A profile</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/Profiles/5
        ///
        /// </remarks>
        /// <response code="200">Returns a profile that has been found</response>
        /// <response code="404">If a profile with given id has not been found</response>
        [HttpGet("{id}", Name = "GetProfile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProfileDto>> GetProfile(int id)
        {
            var foundProfile = await _service.ProfileService.GetProfile(id);
            var linkedProfile = _linksCreator.Profile.GenerateLinksForOneEntity(HttpContext, foundProfile);
            return Ok(linkedProfile);
        }

        /// <summary>
        /// Gets a specific profile based on account
        /// </summary>
        /// <param name="accountId">ID of an account</param>
        /// <returns>A profile</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/Profiles/Account/5
        ///
        /// </remarks>
        /// <response code="200">Returns a profile that has been found</response>
        /// <response code="404">If a profile with given account has not been found</response>
        [HttpGet("Account/{accountId}", Name = "GetProfileByAccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProfileDto>> GetProfileByAccount(int accountId)
        {
            var foundProfile = await _service.ProfileService.GetProfileByAccountId(accountId);
            var linkedProfile = _linksCreator.Profile.GenerateLinksForOneEntity(HttpContext, foundProfile);
            return Ok(linkedProfile);
        }

        /// <summary>
        /// Updates a specific profile
        /// </summary>
        /// <param name="id">ID of a profile</param>
        /// <param name="profile"></param>
        /// <returns>An updated profile</returns>
        /// <remarks>
        /// The ProfileId attribute cannot be changed
        /// 
        /// Sample request:
        ///
        ///     PUT /api/Profiles/5
        ///
        /// </remarks>
        /// <response code="200">Returns a profile that has been updated</response>
        /// <response code="404">If a profile with given id has not been found</response>
        /// <response code="400">If the username is already used or the given account already has a profile linked to it</response>
        [HttpPut("{id}", Name = "PutProfile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutProfile(int id, ProfileDto profile)
        {
            return Ok(await _service.ProfileService.UpdateProfile(id, profile));
        }

        /// <summary>
        /// Creates a new profile
        /// </summary>
        /// <param name="profile"></param>
        /// <returns>A new profile</returns>
        /// <remarks>
        /// The ProfileId attribute is created automatically
        /// 
        /// Sample request:
        ///
        ///     POST /api/Profiles
        ///
        /// </remarks>
        /// <response code="200">Returns a newly created profile</response>
        /// <response code="400">If the username is already used or the given account already has a profile linked to it</response>
        [HttpPost(Name = "PostProfile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProfileDto>> PostProfile(ProfileDto profile)
        {
            var newProfile = await _service.ProfileService.CreateProfile(profile);

            return CreatedAtAction(nameof(GetProfile), new { id = newProfile.ProfileId }, newProfile);
        }

        /// <summary>
        /// Deletes a specific profile
        /// </summary>
        /// <param name="id">ID of a profile</param>
        /// <returns>A deleted profile</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /api/Profiles/5
        ///
        /// </remarks>
        /// <response code="200">Returns a profile that has been deleted</response>
        /// <response code="404">If a profile with given id has not been found</response>
        [HttpDelete("{id}", Name = "DeleteProfile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProfileDto>> DeleteProfile(int id)
        {
            return Ok(await _service.ProfileService.RemoveProfile(id));
        }

    }
}