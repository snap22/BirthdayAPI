using BirthdayAPI.Core.Domain.Abstractions.Repositories;
using BirthdayAPI.Core.Domain.Entities;
using BirthdayAPI.Core.Service.Query.Parameters;
using BirthdayAPI.Core.Service.Query.Sorting;
using BirthdayAPI.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayAPI.Core.Service.Repositories
{
    public class NoteRepository : BaseRepository<Note>, INoteRepository
    {
        public NoteRepository(ApplicationDbContext context, ISortHelper<Note> sortHelper) : base(context, sortHelper) { }

        
        public Task AddNote(Note newNote)
        {
            throw new NotImplementedException();
        }

        public void EditNote(Note note)
        {
            throw new NotImplementedException();
        }

        public Task<Note> GetNoteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Note>> GetNotes(NoteParameters parameters)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Note>> GetNotesOfProfile(int profileId, NoteParameters parameters)
        {
            throw new NotImplementedException();
        }

        public bool NoteWithIdExists(int noteId)
        {
            throw new NotImplementedException();
        }

        public void RemoveNote(Note note)
        {
            throw new NotImplementedException();
        }
    }
}
