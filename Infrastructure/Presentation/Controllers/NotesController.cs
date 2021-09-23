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
    [Route("api/Profiles/{profileId:int}/Notes")]
    [ApiController]
    public class NotesController : BasicController
    {

        public NotesController(IServiceManager service, LinksCreator links) : base(service, links) { }

        /// <summary>
        /// Gets a list of notes that belong to a given profile
        /// </summary>
        /// <param name="profileId">ID of a profile </param>
        /// <param name="noteParameters "></param>
        /// <returns>A list of notes</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/Profiles/3/Notes
        ///
        /// </remarks>
        /// <response code="200">Returns a list of notes</response>
        /// <response code="404">If a given profile with id has not been found</response>
        [HttpGet(Name = "GetNotes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<NoteDto>>> GetNotes([FromRoute]int profileId, [FromQuery] NoteParameters noteParameters)
        {
            var foundNotes = await _service.NoteService.GetNotes(profileId, noteParameters);
            var linkedNotes = _linksCreator.Note.GenerateLinksForManyEntities(HttpContext, foundNotes);
            return Ok(linkedNotes);
        }

        /// <summary>
        /// Gets a specific note
        /// </summary>
        /// <param name="profileId">ID of a profile</param>
        /// <param name="noteId">ID of a note</param>
        /// <returns>A note</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/Profiles/5/Notes/4
        ///
        /// </remarks>
        /// <response code="200">Returns a note that has been found</response>
        /// <response code="404">If either a profile or a note hasn't been found</response>
        /// <response code="400">If a found note does not belong to the given profile</response>
        [HttpGet("{noteId}", Name = "GetNote")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<NoteDto>> GetNote([FromRoute]int profileId, int noteId)
        {
            var foundNote = await _service.NoteService.GetNote(profileId, noteId);
            var linkedNote = _linksCreator.Note.GenerateLinksForOneEntity(HttpContext, foundNote);
            return Ok(linkedNote);
        }

        /// <summary>
        /// Updates a specific note
        /// </summary>
        /// <param name="profileId">ID of a profile</param>
        /// <param name="noteId">ID of a note</param>
        /// <param name="Note"></param>
        /// <returns>An updated note</returns>
        /// <remarks>
        /// The NoteId and ProfileId attributes cannot be changed
        /// 
        /// Sample request:
        ///
        ///     PUT /api/Profiles/5/Notes/3
        ///
        /// </remarks>
        /// <response code="200">Returns a note that has been updated</response>
        /// <response code="404">If either a profile or a note has not been found</response>
        /// <response code="400">If the note does not belong to the given profile</response>
        [HttpPut("{noteId}", Name = "PutNote")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutNote([FromRoute]int profileId, int noteId, NoteDto Note)
        {
            return Ok(await _service.NoteService.UpdateNote(profileId, noteId, Note));
        }

        /// <summary>
        /// Creates a new note
        /// </summary>
        /// <param name="profileId">ID of a profile</param>
        /// <param name="Note"></param>
        /// <returns>A new note</returns>
        /// <remarks>
        /// The NoteId attribute is created automatically
        /// 
        /// Sample request:
        ///
        ///     POST /api/Profiles/5/Notes
        ///
        /// </remarks>
        /// <response code="200">Returns a newly created note</response>
        /// <response code="404">If the given profile has not been found</response>
        [HttpPost(Name = "PostNote")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<NoteDto>> PostNote([FromRoute]int profileId, NoteDto Note)
        {
            var newNote = await _service.NoteService.CreateNote(profileId, Note);

            return CreatedAtAction(nameof(GetNote), new { profileId, newNote.NoteId }, newNote);
        }

        /// <summary>
        /// Deletes a specific note
        /// </summary>
        /// <param name="profileId">ID of a profile</param>
        /// <param name="noteId">ID of a note</param>
        /// <returns>A deleted note</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /api/Profiles/5/Notes/1
        ///
        /// </remarks>
        /// <response code="200">Returns a note that has been deleted</response>
        /// <response code="404">If either a profile or a note has not been found</response>
        /// <response code="400">If a note does not belong to the profile</response>
        [HttpDelete("{noteId}", Name = "DeleteNote")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<NoteDto>> DeleteNote([FromRoute]int profileId, int noteId)
        {
            return Ok(await _service.NoteService.RemoveNote(profileId, noteId));
        }

    }
}