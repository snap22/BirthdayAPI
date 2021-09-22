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
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : BasicController
    {
        public ProfilesController(IServiceManager service, LinksCreator links) : base(service, links) { }


        // GET: api/Profiles
        [HttpGet(Name = "GetProfiles")]
        public async Task<ActionResult<IEnumerable<ProfileDto>>> GetProfiles([FromQuery] ProfileParameters profileParameters)
        {
            return Ok(await _service.ProfileService.GetProfiles(profileParameters));
        }

        // GET: api/Profiles/5
        [HttpGet("{id}", Name = "GetProfile")]
        public async Task<ActionResult<ProfileDto>> GetProfile(int id)
        {
            return Ok(await _service.ProfileService.GetProfile(id));
        }

        // GET: api/Profiles/5
        
        [HttpGet("Account/{accountId}", Name = "GetProfileByAccount")]
        public async Task<ActionResult<ProfileDto>> GetProfileByAccount(int accountId)
        {
            return Ok(await _service.ProfileService.GetProfileByAccountId(accountId));
        }

        // PUT: api/Profiles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}", Name = "PutProfile")]
        public async Task<IActionResult> PutProfile(int id, ProfileDto profile)
        {
            return Ok(await _service.ProfileService.UpdateProfile(id, profile));
        }

        // POST: api/Profiles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost(Name = "PostProfile")]
        public async Task<ActionResult<ProfileDto>> PostProfile(ProfileDto profile)
        {
            var newProfile = await _service.ProfileService.CreateProfile(profile);

            return CreatedAtAction(nameof(GetProfile), new { id = newProfile.ProfileId }, newProfile);
        }

        // DELETE: api/Profiles/5
        [HttpDelete("{id}", Name = "DeleteProfile")]
        public async Task<ActionResult<ProfileDto>> DeleteProfile(int id)
        {
            return Ok(await _service.ProfileService.RemoveProfile(id));
        }

    }
}