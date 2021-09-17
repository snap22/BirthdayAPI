using BirthdayAPI.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Domain.Abstractions.Repositories
{
    public interface INoteRepository
    {
        Task<IEnumerable<Note>> GetNotes();
        Task<Note> GetNoteById(int id);
        Task AddNote(Note newNote);
        void EditNote(Note note);
        void RemoveNote(Note note);
        bool NoteWithIdExists(int noteId);
    }
}
