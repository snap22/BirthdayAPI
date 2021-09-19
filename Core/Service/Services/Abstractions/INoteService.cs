using BirthdayAPI.Core.Service.DTOs;
using BirthdayAPI.Core.Service.Query.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Service.Services.Abstractions
{
    public interface INoteService
    {
        Task<NoteDto> GetNote(int profileId, int noteId);
        Task<IEnumerable<NoteDto>> GetNotes(int profileId, NoteParameters parameters);
        Task<NoteDto> CreateNote(int profileId, NoteDto Note);
        Task<NoteDto> UpdateNote(int profileId, int noteId, NoteDto Note);
        Task<NoteDto> RemoveNote(int profileId, int noteId);
    }
}
