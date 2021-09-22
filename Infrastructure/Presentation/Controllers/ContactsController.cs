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
    [Route("api/Profiles/{profileId:int}/Contacts")]
    [ApiController]
    public class ContactsController : BasicController
    {

        public ContactsController(IServiceManager service, LinksCreator links) : base(service, links) { }

        // GET: api/Profiles/2/Contacts
        [HttpGet(Name ="GetContacts")]
        public async Task<ActionResult<IEnumerable<ContactDto>>> GetContacts([FromRoute]int profileId, [FromQuery] ContactParameters ContactParameters)
        {
            var foundContacts = await _service.ContactService.GetContacts(profileId, ContactParameters);
            var linkedContacts = _linksCreator.Contact.GenerateLinksForManyEntities(HttpContext, foundContacts);
            return Ok(linkedContacts);
        }

        // GET: api/Profiles/2/Contacts/5
        [HttpGet("{contactId}", Name = "GetContact")]
        public async Task<ActionResult<ContactDto>> GetContact([FromRoute]int profileId, int contactId)
        {
            var foundContact = await _service.ContactService.GetContact(profileId, contactId);
            var linkedContact = _linksCreator.Contact.GenerateLinksForOneEntity(HttpContext, foundContact);
            return Ok(linkedContact);
        }

        // PUT: api/Profiles/2/Contacts/5
        [HttpPut("{contactId}", Name = "PutContact")]
        public async Task<IActionResult> PutContact([FromRoute]int profileId, int contactId, ContactDto contact)
        {
            return Ok(await _service.ContactService.UpdateContact(profileId, contactId, contact));
        }

        // POST: api/Profiles/2/Contacts
        [HttpPost(Name = "PostContact")]
        public async Task<ActionResult<ContactDto>> PostContact([FromRoute]int profileId, ContactDto contact)
        {
            var newContact = await _service.ContactService.CreateContact(profileId, contact);

            return CreatedAtAction(nameof(GetContact), new { profileId, newContact.ContactId }, newContact);
        }

        // DELETE: api/Profiles/2/Contacts/5
        [HttpDelete("{contactId}", Name = "DeleteContact")]
        public async Task<ActionResult<ContactDto>> DeleteContact([FromRoute]int profileId, int contactId)
        {
            return Ok(await _service.ContactService.RemoveContact(profileId, contactId));
        }
    }
}
