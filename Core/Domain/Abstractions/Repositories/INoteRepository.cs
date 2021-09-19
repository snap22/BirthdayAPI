using BirthdayAPI.Core.Domain.Entities;
using BirthdayAPI.Core.Service.Query.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Domain.Abstractions.Repositories
{
    public interface INoteRepository
    {
        Task<IEnumerable<Note>> GetNotes(NoteParameters parameters);
        Task<IEnumerable<Note>> GetNotesOfProfile(int profileId, NoteParameters parameters);
        Task<Note> GetNoteById(int id);
        Task<Note> AddNote(Note newNote);
        Note EditNote(Note note);
        void RemoveNote(Note note);
        bool NoteWithIdExists(int noteId);
    }
}
