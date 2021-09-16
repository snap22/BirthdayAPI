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
        public async Task<IActionResult> PutProfile(int id, ProfileDto Profile)
        {
            return Ok(await _service.ProfileService.UpdateProfile(id, Profile));
        }

        // POST: api/Profiles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProfileDto>> PostProfile(ProfileDto Profile)
        {
            await _service.ProfileService.CreateProfile(Profile);

            return CreatedAtAction(nameof(GetProfile), new { id = Profile.ProfileId }, Profile);
        }

        // DELETE: api/Profiles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProfileDto>> DeleteProfile(int id)
        {
            return Ok(await _service.ProfileService.RemoveProfile(id));
        }
    }
}