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
    [Route("api/Profiles/{profileId:int}/Contacts")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IServiceManager _service;
        public ContactsController(IServiceManager service)
        {
            _service = service;
        }

        // GET: api/Contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactDto>>> GetContacts([FromRoute]int profileId, [FromQuery] ContactParameters ContactParameters)
        {
            return Ok(await _service.ContactService.GetContacts(profileId, ContactParameters));
        }

        // GET: api/Contacts/5
        [HttpGet("{contactId}")]
        public async Task<ActionResult<ContactDto>> GetContact([FromRoute]int profileId, int contactId)
        {
            return Ok(await _service.ContactService.GetContact(profileId, contactId));
        }

        // PUT: api/Contacts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkcontactId=2123754.
        [HttpPut("{contactId}")]
        public async Task<IActionResult> PutContact([FromRoute]int profileId, int contactId, ContactDto Contact)
        {
            return Ok(await _service.ContactService.UpdateContact(profileId, contactId, Contact));
        }

        // POST: api/Contacts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkcontactId=2123754.
        [HttpPost]
        public async Task<ActionResult<ContactDto>> PostContact([FromRoute]int profileId, ContactDto Contact)
        {
            await _service.ContactService.CreateContact(profileId, Contact);

            return CreatedAtAction(nameof(GetContact), new { contactId = Contact.ContactId }, Contact);
        }

        // DELETE: api/Contacts/5
        [HttpDelete("{contactId}")]
        public async Task<ActionResult<ContactDto>> DeleteContact([FromRoute]int profileId, int contactId)
        {
            return Ok(await _service.ContactService.RemoveContact(profileId, contactId));
        }
    }
}
