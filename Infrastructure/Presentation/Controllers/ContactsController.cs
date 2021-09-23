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
    [Route("api/Profiles/{profileId:int}/Contacts")]
    [ApiController]
    public class ContactsController : BasicController
    {

        public ContactsController(IServiceManager service, LinksCreator links) : base(service, links) { }

        /// <summary>
        /// Gets a list of contacts that belong to a given profile
        /// </summary>
        /// <param name="profileId">ID of a profile </param>
        /// <param name="ContactParameters"></param>
        /// <returns>A list of contacts</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/Profiles/3/Contacts
        ///
        /// </remarks>
        /// <response code="200">Returns a list of contacts</response>
        /// <response code="404">If a given profile with id has not been found</response>
        [HttpGet(Name ="GetContacts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ContactDto>>> GetContacts([FromRoute]int profileId, [FromQuery] ContactParameters ContactParameters)
        {
            var foundContacts = await _service.ContactService.GetContacts(profileId, ContactParameters);
            var linkedContacts = _linksCreator.Contact.GenerateLinksForManyEntities(HttpContext, foundContacts);
            return Ok(linkedContacts);
        }

        /// <summary>
        /// Gets a specific contact
        /// </summary>
        /// <param name="profileId">ID of a profile</param>
        /// <param name="contactId">ID of a contact</param>
        /// <returns>A contact</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/Profiles/5/Contacts/4
        ///
        /// </remarks>
        /// <response code="200">Returns a contact that has been found</response>
        /// <response code="404">If either a profile or a contact hasn't been found</response>
        /// <response code="400">If a found contact does not belong to the given profile</response>
        [HttpGet("{contactId}", Name = "GetContact")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContactDto>> GetContact([FromRoute]int profileId, int contactId)
        {
            var foundContact = await _service.ContactService.GetContact(profileId, contactId);
            var linkedContact = _linksCreator.Contact.GenerateLinksForOneEntity(HttpContext, foundContact);
            return Ok(linkedContact);
        }

        /// <summary>
        /// Updates a specific contact
        /// </summary>
        /// <param name="profileId">ID of a profile</param>
        /// <param name="contactId">ID of a contact</param>
        /// <param name="contact"></param>
        /// <returns>An updated contact</returns>
        /// <remarks>
        /// The ContactId and ProfileId attributes cannot be changed
        /// 
        /// Sample request:
        ///
        ///     PUT /api/Profiles/5/Contacts/3
        ///
        /// </remarks>
        /// <response code="200">Returns a contact that has been updated</response>
        /// <response code="404">If either a profile or a contact has not been found</response>
        /// <response code="400">If the contact does not belong to the given profile</response>
        [HttpPut("{contactId}", Name = "PutContact")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutContact([FromRoute]int profileId, int contactId, ContactDto contact)
        {
            return Ok(await _service.ContactService.UpdateContact(profileId, contactId, contact));
        }

        /// <summary>
        /// Creates a new contact
        /// </summary>
        /// <param name="profileId">ID of a profile</param>
        /// <param name="contact"></param>
        /// <returns>A new contact</returns>
        /// <remarks>
        /// The ContactId attribute is created automatically
        /// 
        /// Sample request:
        ///
        ///     POST /api/Profiles/5/Contacts
        ///
        /// </remarks>
        /// <response code="200">Returns a newly created contact</response>
        /// <response code="404">If the given profile has not been found</response>
        [HttpPost(Name = "PostContact")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContactDto>> PostContact([FromRoute]int profileId, ContactDto contact)
        {
            var newContact = await _service.ContactService.CreateContact(profileId, contact);

            return CreatedAtAction(nameof(GetContact), new { profileId, newContact.ContactId }, newContact);
        }

        /// <summary>
        /// Deletes a specific contact
        /// </summary>
        /// <param name="profileId">ID of a profile</param>
        /// <param name="contactId">ID of a contact</param>
        /// <returns>A deleted contact</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /api/Profiles/5/Contacts/1
        ///
        /// </remarks>
        /// <response code="200">Returns a contact that has been deleted</response>
        /// <response code="404">If either a profile or a contact has not been found</response>
        /// <response code="400">If a contact does not belong to the profile</response>
        [HttpDelete("{contactId}", Name = "DeleteContact")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContactDto>> DeleteContact([FromRoute]int profileId, int contactId)
        {
            return Ok(await _service.ContactService.RemoveContact(profileId, contactId));
        }
    }
}
