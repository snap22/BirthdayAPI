using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BirthdayAPI.Core.Service.DTOs;
using BirthdayAPI.Core.Service.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayAPI.Infrastructure.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly IServiceManager _service;

        public ProfilesController(IServiceManager service)
        {
            _service = service;
        }

        #region Profile


        // GET: api/Profiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfileDto>>> GetProfiles()
        {
            return Ok(await _service.ProfileService.GetProfiles());
        }

        // GET: api/Profiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfileDto>> GetProfile(int id)
        {
            return Ok(await _service.ProfileService.GetProfile(id));
        }

        // PUT: api/Profiles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfile(int id, ProfileDto profile)
        {
            return Ok(await _service.ProfileService.UpdateProfile(id, profile));
        }

        // POST: api/Profiles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProfileDto>> PostProfile(ProfileDto profile)
        {
            await _service.ProfileService.CreateProfile(profile);

            return CreatedAtAction(nameof(GetProfile), new { id = profile.ProfileId }, profile);
        }

        // DELETE: api/Profiles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProfileDto>> DeleteProfile(int id)
        {
            return Ok(await _service.ProfileService.RemoveProfile(id));
        }


        #endregion Profile


        #region Contact




        #endregion Contact

        #region Gift



        #endregion Gift

        #region Note



        #endregion Note
    }
}