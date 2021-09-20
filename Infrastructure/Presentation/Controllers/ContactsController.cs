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
    public class ContactsController : BasicController
    {

        public ContactsController(IServiceManager service) : base(service) { }

        // GET: api/Profiles/2/Contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactDto>>> GetContacts([FromRoute]int profileId, [FromQuery] ContactParameters ContactParameters)
        {
            return Ok(await _service.ContactService.GetContacts(profileId, ContactParameters));
        }

        // GET: api/Profiles/2/Contacts/5
        [HttpGet("{contactId}")]
        public async Task<ActionResult<ContactDto>> GetContact([FromRoute]int profileId, int contactId)
        {
            return Ok(await _service.ContactService.GetContact(profileId, contactId));
        }

        // PUT: api/Profiles/2/Contacts/5
        [HttpPut("{contactId}")]
        public async Task<IActionResult> PutContact([FromRoute]int profileId, int contactId, ContactDto contact)
        {
            return Ok(await _service.ContactService.UpdateContact(profileId, contactId, contact));
        }

        // POST: api/Profiles/2/Contacts
        [HttpPost]
        public async Task<ActionResult<ContactDto>> PostContact([FromRoute]int profileId, ContactDto contact)
        {
            var newContact = await _service.ContactService.CreateContact(profileId, contact);

            return CreatedAtAction(nameof(GetContact), new { profileId, newContact.ContactId }, newContact);
        }

        // DELETE: api/Profiles/2/Contacts/5
        [HttpDelete("{contactId}")]
        public async Task<ActionResult<ContactDto>> DeleteContact([FromRoute]int profileId, int contactId)
        {
            return Ok(await _service.ContactService.RemoveContact(profileId, contactId));
        }
    }
}
