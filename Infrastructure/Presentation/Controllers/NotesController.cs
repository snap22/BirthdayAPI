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
    [Route("api/Notes/{profileId:int}/Notes")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly IServiceManager _service;

        public NotesController(IServiceManager service)
        {
            _service = service;
        }

        // GET: api/Profiles/2/Notes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NoteDto>>> GetNotes([FromRoute]int profileId, [FromQuery] NoteParameters noteParameters)
        {
            return Ok(await _service.NoteService.GetNotes(profileId, noteParameters));
        }

        // GET: api/Profiles/2/Notes/5
        [HttpGet("{noteId}")]
        public async Task<ActionResult<NoteDto>> GetNote([FromRoute]int profileId, int noteId)
        {
            return Ok(await _service.NoteService.GetNote(profileId, noteId));
        }

        // PUT: api/Profiles/2/Notes/5
        [HttpPut("{noteId}")]
        public async Task<IActionResult> PutNote([FromRoute]int profileId, int noteId, NoteDto Note)
        {
            return Ok(await _service.NoteService.UpdateNote(profileId, noteId, Note));
        }

        // POST: api/Profiles/2/Notes
        [HttpPost]
        public async Task<ActionResult<NoteDto>> PostNote([FromRoute]int profileId, NoteDto Note)
        {
            var newNote = await _service.NoteService.CreateNote(profileId, Note);

            return CreatedAtAction(nameof(GetNote), new { profileId, newNote.NoteId }, newNote);
        }

        // DELETE: api/Profiles/2/Notes/5
        [HttpDelete("{noteId}")]
        public async Task<ActionResult<NoteDto>> DeleteNote([FromRoute]int profileId, int noteId)
        {
            return Ok(await _service.NoteService.RemoveNote(profileId, noteId));
        }

    }
}